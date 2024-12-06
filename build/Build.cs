using Serilog;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.Docker;
using System.Runtime.InteropServices;
using Nuke.Common.ProjectModel;
using Nuke.Common.Utilities.Collections;
using static Nuke.Common.Tooling.ProcessTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace NukeBuild;

[ShutdownDotNetAfterServerBuild]
class Build : Nuke.Common.NukeBuild {
    
    public static int Main () => Execute<Build>(x => x.Compile);
    
    [Parameter("Docker image tag - default is 'blazor'")]
    readonly string Tag = "blazor";
    
    [Parameter("Build configuration (Debug or Release)")]
    readonly string Configuration = "Release";
    
    [Solution] readonly Solution Solution;
    static AbsolutePath SourceDirectory => RootDirectory / "src";
    static AbsolutePath OutputDirectory => RootDirectory / "output";
    static AbsolutePath DeployDirectory => RootDirectory / "deploy";
    string FullImageName => $"ghcr.io/mitchfen/mitchfen.xyz:{Tag}";
    
    Target LogStartupInformation => targetDefinition => targetDefinition
        .Before(Clean)
        .Executes(() =>
        {
            Log.Information($"Configuration: {Configuration}");
            Log.Information($"Output directory: {OutputDirectory}");
        });

    Target Clean => targetDefinition => targetDefinition
        .DependsOn(LogStartupInformation)
        .Executes(() =>
        {
            if (IsLocalBuild) 
            {
                Log.Information("Detected that build is running locally. Cleaning...");
                SourceDirectory.GlobDirectories("**/bin", "**/obj")
                    .ForEach(dir => dir.DeleteDirectory());
                OutputDirectory.DeleteDirectory();
            }
            else {
                Log.Information("Clean step is skipped on CI environments.");
            }
        });

    Target Restore => targetDefinition => targetDefinition
        .DependsOn(Clean)
        .Executes(() =>
        {
            var workloadRestoreCmd = $"dotnet workload restore {Solution}";
            if ( RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                workloadRestoreCmd = $"sudo {workloadRestoreCmd}";
            }
            StartShell(workloadRestoreCmd).AssertZeroExitCode();
            
            DotNetRestore(settings => settings
                .SetProjectFile(Solution)
                .EnableUseLockFile()
            );
        });

    Target Compile => targetDefinition => targetDefinition
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(settings => settings
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoLogo()
                .EnableNoRestore()
            );
        });

    Target Publish => targetDefinition => targetDefinition
        .DependsOn(Compile)
        .Executes(() =>
        {
            var dockerFilePath = DeployDirectory / "Dockerfile";
            var nginxConfigFilePath = DeployDirectory / "nginx.conf";
            dockerFilePath.CopyToDirectory(OutputDirectory);
            nginxConfigFilePath.CopyToDirectory(OutputDirectory);
            DotNetPublish(settings => settings
                .SetProject(SourceDirectory / "MitchfenSite.csproj")
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild()
                .EnableNoLogo()
                .SetOutput(OutputDirectory)
            );
        });

    Target BuildContainerImage => targetDefinition => targetDefinition
        .DependsOn(Publish)
        .Executes(() =>
        {
            Log.Information("Building docker image...");
            DockerTasks.DockerImageBuild(settings => settings
                .SetCacheFrom(FullImageName)
                .SetPath(".")
                .SetTag(FullImageName)
                .SetProcessWorkingDirectory(OutputDirectory)
                .SetProcessLogOutput(false)
                .EnableProcessAssertZeroExitCode()
            );
        });
    
    Target PushContainerImage => targetDefinition => targetDefinition
        .DependsOn(BuildContainerImage)
        .Executes(() =>
        {
            Log.Information($"Pushing {FullImageName}...");
            DockerTasks.DockerImagePush(settings => settings
                .SetName(FullImageName)
                .SetProcessLogOutput(false)
                .EnableProcessAssertZeroExitCode()
            );
        });
}
