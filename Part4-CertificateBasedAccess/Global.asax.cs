using KeyVaultSeries.Core;
using Microsoft.Azure.KeyVault;
using System;

namespace Part4_CertificateBasedAccess
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            KeyVaultClient keyVaultClient = new KeyVaultClient(CertificateBasedAccessHelper.GetKeyVaultAccessToken);
            var secretValut = keyVaultClient.GetSecretAsync("[uri-to-secret]")
                // Don't try this at home :)
                .GetAwaiter().GetResult().Value;
        }
    }
}