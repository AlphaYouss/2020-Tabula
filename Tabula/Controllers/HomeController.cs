using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ASP_Tabula.Models;

namespace ASP_Tabula.Controllers
{
    public class HomeController : Controller
    {
        // Home related methods

        public IActionResult Index()
        {
            // Main page

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                SetCookie();
            }

            return View();
        }

        private void SetCookie()
        {
            // Sets cookie

            HttpContext.Session.SetString("isLoggedIn", "");
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("firstname", "");
            HttpContext.Session.SetString("lastname", "");
            HttpContext.Session.SetString("email", "");
            HttpContext.Session.SetString("dateOfBirth", "");
            HttpContext.Session.SetString("createdAt", "");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Display error if an error occurs

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}