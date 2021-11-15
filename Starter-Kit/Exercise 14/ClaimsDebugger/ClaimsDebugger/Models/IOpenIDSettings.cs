using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenID_Connect_client.Models
{
    public interface IOpenIDSettings
    {
        public string EndPoint { get; }
        string Issuer { get; }
        string jwks_uri { get; }
        string authorization_endpoint { get; }
        string token_endpoint { get; }
        string userinfo_endpoint { get; }
        string end_session_endpoint { get; }
        string check_session_iframe { get; }
        string revocation_endpoint { get; }
        string introspection_endpoint { get; }
        string device_authorization_endpoint { get; }

        ICollection<string> scopes_supported { get; }
        ICollection<string> claims_supported { get; }
        public ICollection<string> IdTokenSigningAlgValuesSupported { get; }
        public ICollection<string> ResponseModesSupported { get; }
        public ICollection<string> ResponseTypesSupported { get; }
        public ICollection<string> GrantTypesSupported { get; }
    }
}
