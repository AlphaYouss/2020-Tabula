using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.DALs;
using ASP_Tabula.Containers;

namespace ASP_Tabula.Controllers
{
    public class LoginController : Controller
    {
        // Login related methods & properties

        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration config;

        private UserContainer userContainer { get; set; }

        public LoginController(ILogger<LoginController> logger, IConfiguration config)
        {
            // Set container and config

            _logger = logger;
            this.config = config;

            userContainer = new UserContainer(new UserDAL(config));
        }


        public IActionResult Index()
        {
            // Main page

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return View();
            }
            else
            {
                // Redirects to user main page

                return RedirectToAction("Index", "User");
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult Login(string emailUsername, string password)
        {
            // User login

            if (CheckInputs(emailUsername, password) == true)
            {
                // Redirects to SetData method

                ClearPartsOfCookie();
                return RedirectToAction("SetData", "User", new { emailUsername = emailUsername });
            }
            else
            {
                // Redirects to the index

                return View("Index");
            }
        }


        private bool CheckInputs(string emailUsername, string password)
        {
            // Checks userinput

            bool validResult = true;

            if (!userContainer.UsernameEmailExists(emailUsername))
            {
                // Email error

                ModelState.AddModelError("emailUsername", "The username/email doesn't exist.");
                validResult = false;
            }
            else if (!userContainer.IsValidLoginCredentials(emailUsername, password))
            {
                // Password error

                ModelState.AddModelError("password", "Wrong password!");
                validResult = false;
            }
            return validResult;
        }


        private void ClearPartsOfCookie()
        {
            // Clear cookie

            HttpContext.Session.Remove("username");
            HttpContext.Session.Remove("firstname");
            HttpContext.Session.Remove("lastname");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("dateOfBirth");
            HttpContext.Session.Remove("createdAt");
        }
    }
}