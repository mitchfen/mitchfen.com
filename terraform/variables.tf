variable "subscription_id" {
  type        = string
  default     = "c50e892e-1a7b-4ce6-8880-fc52843e6c4b"
}

variable "resource_group_name" {
  type        = string
  default     = "mitchfenxyz"
}

variable "location" {
  type        = string
  default     = "eastus2"
}

variable "static_web_app_name" {
  type        = string
  default     = "mitchfenxyz"
}

variable "sku_tier" {
  type        = string
  default     = "Free"
}

variable "sku_size" {
  type        = string
  default     = "Free"
}

variable "custom_domains" {
  type        = set(string)
  default     = ["mitchfen.com", "mitchfen.xyz"]
}


