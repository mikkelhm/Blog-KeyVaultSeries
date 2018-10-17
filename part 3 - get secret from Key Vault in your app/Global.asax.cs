using KeyVaultSeries.Core;
using Microsoft.Azure.KeyVault;
using System;

namespace GetSecretsInYourApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            KeyVaultClient keyVaultClient = new KeyVaultClient(
                new KeyVaultClient.AuthenticationCallback(
                    TokenBasedAccessHelper.GetToken));
            keyVaultClient.GetSecretAsync("url-to-secret");
        }
    }
}