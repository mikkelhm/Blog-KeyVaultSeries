namespace UmbracoWithKeyVault.Core.Secrets
{
    public class SecretSettings
    {
        public SecretSettings()
        {

        }

        public string SomeSecretConnectionString { get; set; }
        public string SomeSecretValue { get; set; }
        public string SomeSecretTokenToAnAmazingIntegration { get; set; }
    }
}
