using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;
using UmbracoWithKeyVault.Core.Secrets;

namespace UmbracoWithKeyVault.Core.Models
{
    public class HomeModelWithSecrets : ContentModel
    {
        public HomeModelWithSecrets(IPublishedContent content) : base(content)
        {
        }

        public SecretSettings Secrets { get; set; }
    }
}
