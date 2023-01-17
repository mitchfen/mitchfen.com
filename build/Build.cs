using Serilog;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using Nuke.Common.Tools.Docker;
using static Nuke.Common.Tooling.ProcessTasks;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

namespace NukeBuild;

[ShutdownDotNetAfterServerBuild]
partial class Build : Nuke.Common.NukeBuild {

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Docker image tag - default is 'blazor'")]
    readonly string Tag = "blazor";

    Target LogStartupInformation => _ => _
        .Before(Clean)
        .Executes(() =>
        {
            Log.Information($"Configuration: {Configuration}");
            Log.Information($"Output directory: {OutputDirectory}");
        });

    Target Clean => _ => _
        .DependsOn(LogStartupInformation)
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
