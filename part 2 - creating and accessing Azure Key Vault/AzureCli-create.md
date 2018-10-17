#Scripts to create and gain an access token for Azure Key Vault via the Azure Cli
## Create Key Vault

az keyvault create --name "myVault" --resource-group "myResources" --location "West Europe"

## Create Service Principal for access
az ad sp create-for-rbac -n myVault --skip-assignment --password MyRandomAccesst0ken --years 100

## Add Access policy for the Service Principal to allow access to the Key Vault

az keyvault set-policy --name myVault --spn appId-from-previous-command --secret-permissions get