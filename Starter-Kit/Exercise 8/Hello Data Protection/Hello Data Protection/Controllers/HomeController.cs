using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _7___Demo___Data_Protection.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace _7___Demo___Data_Protection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IKeyManager _keyManager;

        public HomeController(ILogger<HomeController> logger, IKeyManager keyManager)
        {
            _logger = logger;
            _keyManager = keyManager;
        }

        public IActionResult Index()
        {
            return View(null);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View();

        }


        public IActionResult ShowForm()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        public IActionResult Submit(string Comments)
        {
            ViewData["data"] = Comments;

            return View();
        }


        public IActionResult login()
        {

            var claims = new Claim[]
            {
                //Standard claims
                new Claim(ClaimTypes.Name, "Joe Svensson"),
                new Claim(ClaimTypes.Country, "Sweden"),
                new Claim(ClaimTypes.Email, "joe@tn-data.se"),

                //Custom claims
                new Claim("JobTitle", "Developer"),
                new Claim("JobLevel", "Senior"),
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims: claims, "test");
            ClaimsPrincipal user = new ClaimsPrincipal(identity: identity);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true

            };

            //Sign-in the user
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, authProperties).Wait();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult logout()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateNewKey()
        {
            //Create a new key that will be valid for 10 seconds
            _keyManager.CreateNewKey(
                activationDate: DateTimeOffset.Now,
                expirationDate: DateTimeOffset.Now.AddSeconds(10));https://localhost:5001/home/CreateNewKey

            return RedirectToAction("Index");
        }


        /// <summary>
        /// Ask the Data Protection API to revoke
        /// the keys in the key ring. A new key will then be issued.
        /// </summary>
        /// <returns></returns>
        public IActionResult RevokeAllKeys()
        {
            //All keys with a creation date before this value will be revoked.
            _keyManager.RevokeAllKeys(DateTimeOffset.Now, "We got hacked!!!");

            return RedirectToAction("Index");
        }   
        
        
        //public Dictionary<string, string> GetTheKeyRing()
        //{
        //    var keys = new Dictionary<string, string>();

        //    int counter = 1;
        //    foreach (var entry in _keyManager.GetAllKeys())
        //    {
        //        var keyElement = new XElement(KeyElementName,
        //            new XAttribute(IdAttributeName, entry.KeyId),
        //            new XAttribute(VersionAttributeName, 1),
        //            new XElement(CreationDateElementName, entry.CreationDate),
        //            new XElement(ActivationDateElementName, entry.ActivationDate),
        //            new XElement(ExpirationDateElementName, entry.ExpirationDate),
        //            new XElement(DescriptorElementName, entry.Descriptor.ExportToXml(), new XElement("encryption", entry.Descriptor.)));


        //        IAuthenticatedEncryptorDescriptor data = entry.Descriptor;
      
        //        string str = PrettyXml(keyElement);
        //        keys.Add("Entry" + counter, str);
        //        counter++;
        //    }

        //    return keys;
        //}

        ///// <summary>
        ///// Helper method to pretty format XML 
        ///// </summary>
        ///// <param name="element"></param>
        ///// <returns></returns>
        //private string PrettyXml(XElement element)
        //{
        //    var stringBuilder = new StringBuilder();

        //    var settings = new XmlWriterSettings();
        //    settings.OmitXmlDeclaration = true;
        //    settings.Indent = true;
        //    settings.NewLineOnAttributes = true;
        //    settings.NewLineChars = "\r\n";

        //    using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
        //    {
        //        element.Save(xmlWriter);
        //    }

        //    return stringBuilder.ToString();
        //}
    }
}
