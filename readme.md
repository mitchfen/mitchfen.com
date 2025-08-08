[![Build and Deploy](https://github.com/mitchfen/mitchfen.com/actions/workflows/buildAndDeploy.yml/badge.svg)](https://github.com/mitchfen/mitchfen.com/actions/workflows/buildAndDeploy.yml)
[![Close staging environment](https://github.com/mitchfen/mitchfen.com/actions/workflows/closeStaging.yml/badge.svg)](https://github.com/mitchfen/mitchfen.com/actions/workflows/closeStaging.yml)
## Mitchell Fenner's personal website

My personal site built with Blazor WebAssembly.

## Building the site
The site is built using [Nuke build](https://nuke.build/). This allows me to write both the website and build scripts in C#.  
You can publish the site as a zip using `dotnet run --project ./build/NukeBuild.csproj --target Publish`

## CI/CD
* On pull request creation, the [build and deploy](https://github.com/mitchfen/mitchfen.com/actions/workflows/buildAndDeploy.yml) workflow fires off to build the site and deploy it to a staging environment on Azure.
* On pushes/merges to main, the [build and deploy](https://github.com/mitchfen/mitchfen.com/actions/workflows/buildAndDeploy.yml) workflow builds the site, publishes an updated [Docker image](https://github.com/mitchfen/mitchfen.com/pkgs/container/mitchfen.com), and publishes to [mitchfen.com](https://mitchfen.com).
* On pull request close, the staging environment associated with that pull request is closed by the [cleanup](https://github.com/mitchfen/mitchfen.com/actions/workflows/closeStaging.yml) workflow.
* The cleanup workflow also uses [my reusable GitHub action](https://github.com/mitchfen/cleanup-untagged-container-images) to remove untagged images and save space on the container image registry.
* Dependabot is configured to update NuGet and GitHub Actions dependencies.
