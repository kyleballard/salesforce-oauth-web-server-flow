using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace SalesforceOAuth.Infrastructure
{
    public class SalesforceClient
    {
        private HttpClient client;
        private readonly SalesforceConfig configuration;
        private string authorizeUrl = string.Empty;

        public string AuthorizeUrl 
        {
            get 
            {
                if (!string.IsNullOrEmpty(authorizeUrl)) return authorizeUrl;

                // See:  https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/intro_understanding_web_server_oauth_flow.htm 
                //    for all/additional parameters including display options, application state passthrough data, security options.
                authorizeUrl = configuration.OAuthAuthorizeUrl + "?response_type=code" + 
                                "&client_id=" + HttpUtility.UrlEncode(configuration.ClientId) +
                                "&redirect_uri=" + HttpUtility.UrlEncode(configuration.RedirectUrl);
                return authorizeUrl;
            }
        }

        public SalesforceClient(HttpClient httpClient, IOptions<SalesforceConfig> configurationOptions)
        {
            client = httpClient;
            this.configuration = configurationOptions.Value;
        }

        public async Task<AuthToken> GetToken(string code)
        {
            var nvc = new List<KeyValuePair<string, string>>();
            nvc.Add(new KeyValuePair<string, string>("grant_type", configuration.AuthorizationGrantType));
            nvc.Add(new KeyValuePair<string, string>("client_id", configuration.ClientId));
            nvc.Add(new KeyValuePair<string, string>("code", code));
            nvc.Add(new KeyValuePair<string, string>("client_secret", configuration.ClientSecret));
            nvc.Add(new KeyValuePair<string, string>("redirect_uri", configuration.RedirectUrl));

            var req = new HttpRequestMessage(HttpMethod.Post, configuration.OAuthTokenUrl) { Content = new FormUrlEncodedContent(nvc) };
            var response = await client.SendAsync(req);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthToken>(content);
        }
    }
}