variable "do_token" {
  description = "DigitalOcean API token"
  type        = string
  sensitive   = true
}

variable "github_repo" {
  description = "GitHub repository in format 'owner/repo'"
  type        = string
  default     = "mitchfen/mitchfen.com"
}

variable "github_branch" {
  description = "GitHub branch to deploy from"
  type        = string
  default     = "main"
}

variable "domain_name" {
  description = "Custom domain name for the app"
  type        = string
  default     = "mitchfen.com"
}

variable "instance_count" {
  description = "Number of instances to run"
  type        = number
  default     = 1

  validation {
    condition     = var.instance_count >= 1
    error_message = "Instance count must be at least 1."
  }
}
