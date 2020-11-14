provider "azurerm" {
    version = "2.5.0"
    features {}
}

terraform {
    backend "azurerm" {
        resource_group_name  = "terraform_rg_blobstorage"
        storage_account_name = "terraformblobcodecmdapi"
        container_name       = "terraformstate"
        key                  = "terraform.tfstate"
    }
}

variable "imagebuild" {
  type        = string
  description = "Latest Image Build"
}

resource "azurerm_resource_group" "terraform_codecmdapi" {
  name = "terraform_rg_codecmdapi"
  location = "Southeast Asia"
}

resource "azurerm_container_group" "terraform_container_codecmdapi" {
  name                      = "codecmdapi"
  location                  = azurerm_resource_group.terraform_codecmdapi.location
  resource_group_name       = azurerm_resource_group.terraform_codecmdapi.name

  ip_address_type     = "public"
  dns_name_label      = "azzulhisham"
  os_type             = "Linux"

  container {
      name            = "codecmdapi"
      image           = "azzulhisham/codecmdapi:${var.imagebuild}"
        cpu             = "1"
        memory          = "1"

        ports {
            port        = 80
            protocol    = "TCP"
        }
  }
}

