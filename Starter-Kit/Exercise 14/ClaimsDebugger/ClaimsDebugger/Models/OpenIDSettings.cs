using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenID_Connect_client.Models
{
    public class OpenIDSettings : IOpenIDSettings
    {
        public string EndPoint { get; }
        public string Issuer { get; }
        public string jwks_uri { get; }
        public string authorization_endpoint { get; }
        public string token_endpoint { get; }
        public string userinfo_endpoint { get; }
        public string end_session_endpoint { get; }
        public string check_session_iframe { get; }
        public string revocation_endpoint { get; }
        public string introspection_endpoint { get; }
        public string device_authorization_endpoint { get; }

        public ICollection<string> scopes_supported { get; }
        public ICollection<string> claims_supported { get; }
        public ICollection<string> IdTokenSigningAlgValuesSupported { get; }
        public ICollection<string> ResponseModesSupported { get; }
        public ICollection<string> ResponseTypesSupported { get; }
        public ICollection<string> GrantTypesSupported { get; }

        /// <summary>
        /// Will download and parse the token service openid-configuration document
        /// </summary>
        /// <param name="endpoint"></param>
        public OpenIDSettings(string endpoint)
        {
            EndPoint = $"{endpoint}/.well-known/openid-configuration";

            var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                                           metadataAddress: EndPoint,
                                           configRetriever: new OpenIdConnectConfigurationRetriever());

            //If you get an exception here, then your Identity Server is not running or reachable 
            var document = configurationManager.GetConfigurationAsync().Result;

            Issuer = document.Issuer;
            jwks_uri = document.JwksUri;
            authorization_endpoint = document.AuthorizationEndpoint;
            token_endpoint = document.TokenEndpoint;
            userinfo_endpoint = document.UserInfoEndpoint;
            end_session_endpoint = document.EndSessionEndpoint;
            check_session_iframe = document.CheckSessionIframe;
          
            scopes_supported = document.ScopesSupported;
            claims_supported = document.ClaimsSupported;
            IdTokenSigningAlgValuesSupported = document.IdTokenSigningAlgValuesSupported;
            ResponseModesSupported = document.ResponseModesSupported;
            ResponseTypesSupported = document.ResponseTypesSupported;
            GrantTypesSupported = document.GrantTypesSupported;
            introspection_endpoint = document.IntrospectionEndpoint;

            if (document.AdditionalData.ContainsKey("revocation_endpoint"))
                revocation_endpoint = (string)(document.AdditionalData["revocation_endpoint"]);

            if (document.AdditionalData.ContainsKey("device_authorization_endpoint"))
                device_authorization_endpoint = (string)(document.AdditionalData["device_authorization_endpoint"]);
        }
    }
}
