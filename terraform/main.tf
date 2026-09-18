resource "azurerm_resource_group" "this" {
  name     = var.resource_group_name
  location = var.location
}

resource "azurerm_static_web_app" "this" {
  name                = var.static_web_app_name
  resource_group_name = azurerm_resource_group.this.name
  location            = azurerm_resource_group.this.location
  sku_tier            = var.sku_tier
  sku_size            = var.sku_size

  lifecycle {
    ignore_changes = [repository_branch, repository_url]
  }
}

resource "azurerm_static_web_app_custom_domain" "this" {
  for_each          = var.custom_domains
  static_web_app_id = azurerm_static_web_app.this.id
  domain_name       = each.value
  validation_type   = "cname-delegation"

  lifecycle {
    ignore_changes = [validation_type]
  }
}
