[![Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml/badge.svg)](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml)
[![Cleanup tagless images](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/cleanupImages.yml/badge.svg)](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/cleanupImages.yml)
## Mitchell Fenner's personal website

A tiny Blazor WebAssembly site with links to my accounts. 
As a DevOps engineer, I enjoy automating and overengineering the CI/CD more than designing a nice UI 😉.

## Automation
* When a pull request is created or updated, the [Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml) workflow fires off to build the site and deploy it to a staging environment on Azure.  

* On pull request close, the staging environment associated with that pull request is closed by the [Close staging environment](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/closeStaging.yml) workflow.

* On push to main the [Build and Deploy](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/buildAndDeploy.yml) workflow builds the site, publishes an updated [Docker image](https://github.com/mitchfen/mitchfen.xyz/pkgs/container/mitchfen.xyz), and publishes to [production](https://mitchfen.xyz).

* Once a week, the [Cleanup Tagless Images](https://github.com/mitchfen/mitchfen.xyz/actions/workflows/cleanupImages.yml) workflow fires off to remove untagged images and save space on the container registry.

* Dependabot is configured to update NuGet and GitHub Actions dependencies.
