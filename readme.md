[![Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml/badge.svg)](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml)
[![Close staging environment](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml/badge.svg)](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml)
## Mitchell Fenner's personal website

My personal site built with Blazor WebAssembly.

## CI/CD
* On pull request creation, the [build and deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml) workflow fires off to build the site and deploy it to a staging environment on Azure.  
* On pushes/merges to main, the [build and deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml) workflow builds the site, publishes an updated [Docker image](https://github.com/mitchfen/mitchfen.xyz/pkgs/container/mitchfen.xyz), and publishes to [production](https://mitchfen.xyz). It also uses [my reusable GitHub action](https://github.com/mitchfen/cleanup-untagged-container-images) to remove untagged images and save space on the container image registry.
* On pull request close, the staging environment associated with that pull request is closed by the [close staging environment](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml) workflow.
* Dependabot is configured to update NuGet and GitHub Actions dependencies.

## Building the site
The site is built using [Nuke build](https://nuke.build/). This allows me to write both the website and build scripts in C#. 
```PowerShell
# To publish the site to /output run:
./build.ps1 --Target Publish
```
