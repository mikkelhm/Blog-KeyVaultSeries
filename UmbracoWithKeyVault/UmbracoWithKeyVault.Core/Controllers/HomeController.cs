using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using UmbracoWithKeyVault.Core.Models;
using UmbracoWithKeyVault.Core.Secrets;

namespace UmbracoWithKeyVault.Core.Controllers
{
    public class HomeController : RenderMvcController
    {
        private readonly SecretSettings _secretSettings;

        public HomeController(SecretSettings secretSettings)
        {
            _secretSettings = secretSettings;
        }

        public override ActionResult Index(ContentModel model)
        {
            var secretModel = new HomeModelWithSecrets(model.Content) { Secrets = _secretSettings };
            return CurrentTemplate(secretModel);
        }
    }
}
