namespace SalesforceOAuth
{
    public class SalesforceConfig {
        public string AuthorizationGrantType { get; set; }
        public string ClientId { get; set;}
        public string ClientSecret { get; set;}
        public string RedirectUrl {get; set;}
        public string OAuthTokenUrl { get; set;}
        public string OAuthAuthorizeUrl { get; set;}
    }
}
