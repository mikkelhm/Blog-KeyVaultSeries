using KeyVaultSeries.Core;
using Microsoft.Azure.KeyVault;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Part5_AccessViaAzureWebApps.Controllers
{
    public class HomeController : Controller
    {
        private KeyVaultClient _keyVaultClient;
        public HomeController()
        {
            
            //var secretValut = keyVaultClient.GetSecretAsync("[uri-to-secret]")
            //    // Don't try this at home :)
            //    .GetAwaiter().GetResult().Value;
        }
        public async Task<ActionResult> Index()
        {
            _keyVaultClient = new KeyVaultClient(CertificateBasedAccessHelper.GetKeyVaultAccessToken);
            ViewBag.AppSettingValue = ConfigurationManager.AppSettings["MyValue"];
            ViewBag.EnvironmentVariableName = Environment.GetEnvironmentVariable("MyValue");
            try
            {
                ViewBag.KeyVaultValue = (await _keyVaultClient.GetSecretAsync(
                    ConfigurationManager.AppSettings["KeyVaultBaseUrl"],
                    ConfigurationManager.AppSettings["KeyVaultSecretKey"])).Value;
            }catch(Exception ex)
            {
                ViewBag.KeyVaultValue = ex.ToString();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}