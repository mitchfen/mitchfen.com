using Serilog;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.Tools.Docker;
using static Nuke.Common.Tooling.ProcessTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace NukeBuild;

[ShutdownDotNetAfterServerBuild]
class Build : Nuke.Common.NukeBuild {

    public static int Main () => Execute<Build>(x => x.Compile);
    [Solution] readonly Solution Solution;

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Parameter("Docker image tag - Default is 'blazor'")]
    readonly string Tag = "blazor";

    static AbsolutePath SourceDirectory => RootDirectory / "src";
    static AbsolutePath OutputDirectory => RootDirectory / "output";
    static AbsolutePath DockerfileDirectory => RootDirectory / "Docker";
    const string BaseImageName = "ghcr.io/mitchfen/mitchfen.xyz";

    Target StartupInformation => _ => _
        .Before(Clean)
        .Executes(() =>
        {
            Log.Information($"Configuration: {Configuration}");
            Log.Information($"Output directory: {OutputDirectory}");
        });

    Target Clean => _ => _
        .DependsOn(StartupInformation)
        .Executes(() =>
        {
            if (IsLocalBuild) 
            {
                Log.Information("Detected that build is running locally. Cleaning...");
                SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
                EnsureCleanDirectory( OutputDirectory );
            }
            else {
                Log.Information("Clean step is skipped on CI environments.");
            }
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            StartShell($"dotnet workload restore {Solution}").AssertZeroExitCode();
            DotNetRestore(settings => settings
                .SetProjectFile(Solution)
                .EnableUseLockFile()
            );
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(settings => settings
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoLogo()
            );
        });
    
    Target Publish => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            CopyFileToDirectory(DockerfileDirectory / "Dockerfile", OutputDirectory);
            CopyFileToDirectory(DockerfileDirectory / "nginx.conf", OutputDirectory);
            DotNetPublish(settings => settings
                .SetProject(SourceDirectory / "MitchfenSite.csproj")
                .SetConfiguration(Configuration)
                .EnableNoBuild()
                .EnableNoLogo()
                .SetOutput(OutputDirectory)
            );
        });

    Target BuildContainerImage => _ => _
        .DependsOn(Publish)
        .Executes(() =>
        {
            Log.Information("Building docker image...");
            var fullImageName = $"{BaseImageName}:{Tag}";
            DockerTasks.DockerImageBuild(settings => settings
                .SetCacheFrom(fullImageName)
                .SetPath(".")
                .SetTag(fullImageName)
                .SetProcessWorkingDirectory(OutputDirectory)
            );

            Log.Information($"Pushing {fullImageName}...");
            DockerTasks.DockerImagePush(settings => settings
                .SetName(fullImageName)
            );
        });

}
