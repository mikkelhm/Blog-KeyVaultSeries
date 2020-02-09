using System.Configuration;
using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoWithKeyVault.Core.Secrets;

namespace UmbracoWithKeyVault.Core.Composers
{
    public class SecretComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var settingsInstance = GetSecretSettings();
            composition.Register<SecretSettings>(settingsInstance);
        }

        private SecretSettings GetSecretSettings()
        {
            return new SecretSettings()
            {
                SomeSecretConnectionString = ConfigurationManager.AppSettings["SomeSecretConnectionString"],
                SomeSecretValue = ConfigurationManager.AppSettings["SomeSecretValue"],
                SomeSecretTokenToAnAmazingIntegration = ConfigurationManager.AppSettings["SomeSecretTokenToAnAmazingIntegration"]
            };
        }
    }
}
