[![Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml/badge.svg)](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml)
[![Close staging environment](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml/badge.svg)](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml)
## Mitchell Fenner's personal website

A tiny Blazor WebAssembly site with links to my accounts.  
As a DevOps engineer, I enjoy automating and overengineering the CI/CD more than designing a nice UI 😉.

## CI/CD
* On pull request creation, the [Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml) workflow fires off to build the site and deploy it to a staging environment on Azure.  
* On push/merge to main, the [Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml) workflow builds the site, publishes an updated [Docker image](https://github.com/mitchfen/mitchfen.xyz/pkgs/container/mitchfen.xyz), and publishes to [production](https://mitchfen.xyz). It also utilized the [reusable GitHub action I wrote](https://github.com/mitchfen/cleanup-untagged-container-images) to remove untagged images and save space on the container registry.
* On pull request close, the staging environment associated with that pull request is closed by the [close staging environment](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml) workflow.
* Dependabot is configured to update NuGet and GitHub Actions dependencies.

