using Nuke.Common.IO;

namespace NukeBuild;

partial class Build : Nuke.Common.NukeBuild {

    static AbsolutePath SourceDirectory => RootDirectory / "src";
    static AbsolutePath OutputDirectory => RootDirectory / "output";
    static AbsolutePath DockerfileDirectory => RootDirectory / "Docker";
    const string BaseImageName = "ghcr.io/mitchfen/mitchfen.xyz";
}
