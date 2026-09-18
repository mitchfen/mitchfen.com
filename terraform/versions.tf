terraform {
  backend "azurerm" {
    resource_group_name  = "shared"
    storage_account_name = "mitchfenner"
    container_name       = "tfstate"
    key                  = "mitchfenxyz.tfstate"
    subscription_id      = "c50e892e-1a7b-4ce6-8880-fc52843e6c4b"
    use_azuread_auth     = true
  }

  required_version = ">= 1.7.0"

  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.0"
    }
  }
}

provider "azurerm" {
  features {}
  subscription_id = var.subscription_id
}
