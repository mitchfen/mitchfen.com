output "static_site_url" {
  value = azurerm_static_site.staticSite.default_host_name
}
output "container_url" {
  value = azurerm_app_service.main.default_site_hostname
}
