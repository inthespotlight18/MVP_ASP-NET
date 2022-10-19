//using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using MVP_ASP_NET.Models;

namespace MVP_ASP_NET.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ProcessLogin(RegFormsData RegFormsData)
        {
            // https://learn.microsoft.com/en-us/dotnet/api/system.uri?view=net-7.0

            //http://gp04.garnet.ca/wcfDaniil/UserAdd?UserName=

            string webDaniilUrl = "http://gp04.garnet.ca/wcfDaniil/UserAdd?UserName=";

            //Only should be used for small data
            Uri siteUri = new Uri(webDaniilUrl+RegFormsData.Name);     

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, siteUri);
            HttpResponseMessage response = client.Send(request);

            if (RegFormsData.Name == "Daniil" && RegFormsData.Email == "1234")
            {
                return View("LoginSucces", RegFormsData);
            } 
            else
            {
                return View("LoginFailure", RegFormsData);
            }
            

        }

    }
}
