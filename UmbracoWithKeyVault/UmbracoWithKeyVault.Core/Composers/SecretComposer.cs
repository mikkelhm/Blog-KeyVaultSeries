using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoWithKeyVault.Core.Secrets;

namespace UmbracoWithKeyVault.Core.Composers
{
    public class SecretComposer : IUserComposer
    {
        private readonly KeyVaultClient _keyVaultClient;

        public SecretComposer()
        {
            _keyVaultClient = new KeyVaultClient(GetToken);
        }

        public void Compose(Composition composition)
        {
            var settingsInstance = GetSecretSettings();
            composition.Register<SecretSettings>(settingsInstance);
        }

        private SecretSettings GetSecretSettings()
        {
            return new SecretSettings()
            {
                SomeSecretConnectionString = GetKeyVaultSecret("SomeSecretConnectionString"),
                SomeSecretValue = GetKeyVaultSecret("SomeSecretValue"),
                SomeSecretTokenToAnAmazingIntegration = GetKeyVaultSecret("SomeSecretTokenToAnAmazingIntegration")
            };
        }

        private string GetKeyVaultSecret(string secretKey)
        {
            var secret = _keyVaultClient.GetSecretAsync(ConfigurationManager.AppSettings["KeyVaultRootUrl"], secretKey).GetAwaiter().GetResult();
            return secret?.Value;
        }

        public static async Task<string> GetToken(string authority, string resource, string scope)
        {
            var authContext = new AuthenticationContext(authority);
            ClientCredential clientCred = new ClientCredential(ConfigurationManager.AppSettings["ClientId"],
                ConfigurationManager.AppSettings["ClientSecret"]);
            AuthenticationResult result = await authContext.AcquireTokenAsync(resource, clientCred);

            if (result == null)
                throw new InvalidOperationException("Failed to obtain the JWT token");

            return result.AccessToken;
        }
    }
}
