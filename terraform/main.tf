terraform {
  required_version = ">= 1.0"

  required_providers {
    digitalocean = {
      source  = "digitalocean/digitalocean"
      version = "~> 2.0"
    }
  }
}

provider "digitalocean" {
  token = var.do_token
}

locals {
  app_name = "mitchfen-com"
  region   = "nyc"
}

# DigitalOcean App Platform
resource "digitalocean_app" "mitchfen" {
  spec {
    name   = local.app_name
    region = local.region

    service {
      name             = "web"
      github_repo      = var.github_repo
      github_branch    = var.github_branch
      source_dir       = "."
      build_command    = ""
      run_command      = ""
      dockerfile_path  = "deploy/Dockerfile"

      # Resource constraints
      instance_count       = var.instance_count
      instance_size_slug   = "basic-xs"

      # Container port configuration
      http_port = 80

      # Health check
      health_check {
        http_path = "/"
      }

      # Environment variables
      env {
        key   = "ASPNETCORE_ENVIRONMENT"
        value = "Production"
        scope = "RUN_AND_BUILD_TIME"
      }

      log_destinations {
        name = "default"
      }
    }

    # Domain configuration
    domain {
      name = var.domain_name
    }
  }
}
