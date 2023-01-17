using Nuke.Common.IO;
using Nuke.Common.ProjectModel;

namespace NukeBuild;

partial class Build {

    [Solution] readonly Solution Solution;
    const string Configuration = "Release";
    static AbsolutePath SourceDirectory => RootDirectory / "src";
    static AbsolutePath OutputDirectory => RootDirectory / "output";
    static AbsolutePath DockerfileDirectory => RootDirectory / "Docker";
    const string BaseImageName = "ghcr.io/mitchfen/mitchfen.xyz";
}
