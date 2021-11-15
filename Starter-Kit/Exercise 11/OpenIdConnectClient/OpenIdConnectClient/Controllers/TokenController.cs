using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OpenIdConnectClient.Controllers
{
    [Authorize]
    public class TokenController : Controller
    {
        /// <summary>
        /// Request the user details from the UserInfo endpoint using the
        /// IdentityModel library.
        ///
        /// Read more about the library here:
        /// https://identitymodel.readthedocs.io/
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> UseAccessToken()
        {
            string idToken = HttpContext.GetTokenAsync("id_token").Result;
            string accessToken = HttpContext.GetTokenAsync("access_token").Result;

            var client = new HttpClient();

            //First get the discovery document 
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:6001");

            //Then get the user info details
            var response = await client.GetUserInfoAsync(new UserInfoRequest
            {
                Address = disco.UserInfoEndpoint,
                Token = accessToken
            });

            if (response.IsError)
            {
                ViewData["error"] = response.Error;
                ViewData["accessToken"] = accessToken;
                ViewData["idToken"] = idToken;
                ViewData["claims"] = null;
            }
            else
            {
                IEnumerable<Claim> claims = response.Claims;
                ViewData["error"] = "OK";
                ViewData["accessToken"] = accessToken;
                ViewData["idToken"] = idToken;
                ViewData["claims"] = claims;
            }

            //Decode the tokens into an object and extract the alg and kid claims
            var at_jwt = new JwtSecurityTokenHandler().ReadJwtToken(accessToken);
            ViewData["at-alg"] = at_jwt.Header.Alg ?? "";
            ViewData["at-kid"] = at_jwt.Header.Kid ?? "(kid missing)";
            
            var id_jwt = new JwtSecurityTokenHandler().ReadJwtToken(idToken);
            ViewData["id-alg"] = id_jwt.Header.Alg ?? "";
            ViewData["id-kid"] = id_jwt.Header.Kid ?? "(kid missing)";




            return View();
        }

    }
}
