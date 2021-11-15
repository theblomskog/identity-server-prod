using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Flurl;
using Flurl.Http;
using IdentityModel.Client;
using OpenID_Connect_client.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OpenID_Connect_client.Controllers
{
    public class ClientCredentialsController : Controller
    {
        private readonly IOpenIDSettings _openIdSettings;
        private string scope;
        private string clientId;
        private string clientSecret;
        private string tokenIntrospectionClientId;
        private string tokenIntrospectionClientSecret;
        
        public ClientCredentialsController(IOpenIDSettings openIdSettings)
        {
            _openIdSettings = openIdSettings;
            scope = "apiscope1";
            clientId = "authcodeflowclient_dev";
            clientSecret = "mysecret";

            //For the request to the token introspection endpoint (Should be the ApiResource name and secret here)
            tokenIntrospectionClientId = "apiresource1";
            tokenIntrospectionClientSecret = "myapisecret";
        }

        public IActionResult Index()
        {
            var url = new Url(_openIdSettings.token_endpoint);

            ViewData["scope"] = scope;

            var token = url.PostUrlEncodedAsync(new
            {
                grant_type = "client_credentials",
                client_id = clientId,
                client_secret = clientSecret,
                scope = scope

            }).ReceiveJson<Token>().Result;

            //To be secure then the state parameter should be compared to the state sent in the previous step

            string accessToken = token.access_token;
            string idToken = token.id_token;


            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken accessTokenObj = handler.ReadJwtToken(accessToken);

            ViewData["accessTokenObj"] = accessTokenObj.Payload;
            ViewData["idTokenObj"] = null;

            var tokenIntrospectionData = GetTokenIntrospectionData(accessToken);

            ViewData["tokenIntrospection"] = JToken.Parse(tokenIntrospectionData).ToString(Formatting.Indented);
            ViewData["userInfo"] = "UserInfo is not allowed in this flow";

            return View("Callback");
        }



        private string GetTokenIntrospectionData(string accessToken)
        {
            var client = new HttpClient();

            var request = new TokenIntrospectionRequest
            {
                //The introspection endpoint requires authentication - since the client of an introspection endpoint is an API, you configure the secret on the ApiResource.
                Address = _openIdSettings.introspection_endpoint,
                ClientId = "apiresource1",
                ClientSecret = "myapisecret",

                Token = accessToken
            };

            TokenIntrospectionResponse response = client.IntrospectTokenAsync(request).Result;
            return response.Raw;
        }



    }
}
