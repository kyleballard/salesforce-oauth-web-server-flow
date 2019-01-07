using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using SalesforceOAuth.Infrastructure;
using SalesforceOAuth.Models;

namespace SalesforceOAuth
{
    // For an outline of how the Web Server Flow works, see here: 
    //    https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/intro_understanding_web_server_oauth_flow.htm
    public class SalesforceController : Controller
    {
        private readonly SalesforceClient client;

        public SalesforceController(SalesforceClient client)
        {
            this.client = client;
        }

        [HttpGet("/")]
         public ViewResult Index()
         {           
            return View(model:client.AuthorizeUrl); 
        }

        [HttpGet("/salesforce/callback")] // Note, this is same as redirect_uri above
        public async Task<string> Login(string code) 
        {
            var token = await client.GetToken(code);

            // Note:  Once we have the access token, we can call the REST API same as with other flows.  
            //  See:  https://ballardsoftware.com/introduction-to-the-salesforce-rest-api-using-postman/

            return $"You have the access token {token.AccessToken} - you can use this bearer token to call the Salesforce REST API";
        }

    }
}