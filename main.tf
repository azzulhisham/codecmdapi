provider "azurerm" {
    version = "2.5.0"
    features {}
}

terraform {
    backend "azurerm" {
        resource_group_name  = "tf_rg_blobstore"
        storage_account_name = "tfstorageazzulhisham"
        container_name       = "tfstate"
        key                  = "terraform.tfstate"
    }
}

variable "imagebuild" {
  type        = string
  description = "Latest Image Build"
}



resource "azurerm_resource_group" "tf_codecmdapi" {
  name = "tfmainrg"
  location = "Australia East"
}

resource "azurerm_container_group" "tfcg_codecmdapi" {
  name                      = "codecmdapi"
  location                  = azurerm_resource_group.tf_codecmdapi.location
  resource_group_name       = azurerm_resource_group.tf_codecmdapi.name

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
