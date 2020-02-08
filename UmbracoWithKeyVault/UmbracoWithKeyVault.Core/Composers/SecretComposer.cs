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
                SomeSecretConnectionString = "SomeSecretConnectionString",
                SomeSecretValue = "SomeSecretValue",
                SomeSecretTokenToAnAmazingIntegration = "SomeSecretTokenToAnAmazingIntegration"
            };
        }
    }
}
