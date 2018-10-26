using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace KeyVaultSeries.Core
{
    public class CertificateBasedAccessHelper
    {
        private static ClientAssertionCertificate GetKeyVaultCertificate()
        {
            var thumbprint = ConfigurationManager.AppSettings["KeyVaultThumbprint"];
            var clientId = ConfigurationManager.AppSettings["KeyVaultApplicationId"];
            var storeLocation = StoreLocation.CurrentUser;
            var clientAssertionCertPfx = FindCertificateByThumbprint(thumbprint, storeLocation);
            return new ClientAssertionCertificate(clientId, clientAssertionCertPfx);
        }

        public static async Task<string> GetKeyVaultAccessToken(string authority, string resource, string scope)
        {
            var cert = GetKeyVaultCertificate();
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);
            var result = await context.AcquireTokenAsync(resource, cert);
            return result.AccessToken;
        }

        private static X509Certificate2 FindCertificateByThumbprint(string findValue, StoreLocation storeLocation)
        {
            X509Store store = new X509Store(StoreName.My, storeLocation);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection col = store.Certificates.Find(X509FindType.FindByThumbprint, findValue, false);
                if (col.Count == 0)
                    return null;
                return col[0];
            }
            finally
            {
                store.Close();
            }
        }
    }
}
