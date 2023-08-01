param location string = resourceGroup().location
param staticSites_mitchfenxyz_name string = 'mitchfenxyz'

resource staticSites_mitchfenxyz_name_resource 'Microsoft.Web/staticSites@2022-09-01' = {
  name: staticSites_mitchfenxyz_name
  location: location
  sku: {
    name: 'Free'
    tier: 'Free'
  }
  properties: {
    repositoryUrl: 'https://github.com/mitchfen/mitchfen.xyz'
    branch: 'main'
    stagingEnvironmentPolicy: 'Enabled'
    allowConfigFileUpdates: true
    provider: 'GitHub'
    enterpriseGradeCdnStatus: 'Disabled'
  }
}

resource staticSites_mitchfenxyz_name_mitchfen_xyz 'Microsoft.Web/staticSites/customDomains@2022-09-01' = {
  parent: staticSites_mitchfenxyz_name_resource
  name: 'mitchfen.xyz'
  location: location
  properties: {}
}

resource staticSites_mitchfenxyz_name_www_mitchfen_xyz 'Microsoft.Web/staticSites/customDomains@2022-09-01' = {
  parent: staticSites_mitchfenxyz_name_resource
  name: 'www.mitchfen.xyz'
  location: location
  properties: {}
}
