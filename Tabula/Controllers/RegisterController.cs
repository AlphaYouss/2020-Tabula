using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.DALs;
using ASP_Tabula.Tools;
using ASP_Tabula.Models;
using ASP_Tabula.Containers;

namespace ASP_Tabula.Controllers
{
    public class RegisterController : Controller
    {
        // Register related methods & properties

        private readonly ILogger<RegisterController> _logger;
        private readonly IConfiguration config;

        private Validator validator = new Validator();
        private Passwordhandler passwordhandler = new Passwordhandler();

        private UserContainer userContainer { get; set; }
        private BoardContainer boardContainer { get; set; }


        public RegisterController(ILogger<RegisterController> logger, IConfiguration config)
        {
            // Set containers and config

            _logger = logger;
            this.config = config;

            userContainer = new UserContainer(new UserDAL(config));
            boardContainer = new BoardContainer(new BoardDAL(config));
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
        public IActionResult Finish(string firstname, string lastname, string username)
        {
            // Saves data and checks it

            SaveIndexStrings(firstname, lastname, username);

            if (CheckIndexInputs() == true)
            {
                return View();
            }
            else
            {
                return View("Index");
            }
        }


        private void SaveIndexStrings(string firstname, string lastname, string username)
        {
            // Saves data in cookie

            HttpContext.Session.SetString("firstname", firstname);
            HttpContext.Session.SetString("lastname", lastname);
            HttpContext.Session.SetString("username", username);
        }


        private bool CheckIndexInputs()
        {
            // Checks userinput

            bool validResult = true;

            if (!validator.ValidateNames(HttpContext.Session.GetString("firstname")))
            {
                // Firstname error

                ModelState.AddModelError("firstname", "Type in a valid firstname.");
                validResult = false;
            }
            else if (!validator.ValidateNames(HttpContext.Session.GetString("lastname")))
            {
                // Lastname error

                ModelState.AddModelError("lastname", "Type in a valid lastname.");
                validResult = false;
            }
            else if (!validator.ValidateUsername(HttpContext.Session.GetString("username")))
            {
                // Username error

                ModelState.AddModelError("username", "Please fill in a valid username.");
                validResult = false;
            }
            else if (userContainer.UsernameExists(HttpContext.Session.GetString("username")))
            {
                // Username error

                ModelState.AddModelError("username" , "The username is already in use.");
                validResult = false;
            }
            return validResult;
        }


        [ValidateAntiForgeryToken]
        public IActionResult CreateAccount(string email, string dateOfBirth, string password, string passwordRepeat)
        {
            // Creates account

            if (CheckFinishInputs(email, dateOfBirth, password, passwordRepeat) == true)
            {
                // Set cookie

                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("dateOfBirth", dateOfBirth);

                // Create new account

                CreateUserWithBoard(password);

                ViewData["succesMessage"] = "You have successfully created your account!";

                return View("../Login/Index");
            }
            else
            {
                return View("Finish");
            }
        }


        private bool CheckFinishInputs(string email, string dateOfBirth, string password, string passwordRepeat)
        {
            // Checks userinput

            bool result = true;

            if (!validator.ValidateEmail(email))
            {
                // Email error

                ModelState.AddModelError("email", "Type in a valid email.");
                result = false;
            }
            else if (userContainer.EmailExists(email))
            {
                // Email error

                ModelState.AddModelError("email", "The email is already in use.");
                result = false;
            }
            else if (password != passwordRepeat)
            {
                // Password error

                ModelState.AddModelError("password", "Both password are not the same.");
                result = false;
            }
            else if (!validator.ValidatePassword(password))
            {
                // Password error

                ModelState.AddModelError("password", "Please fill in a strong password that contains captial letters and numbers");
                result = false;
            }
            return result;
        }


        private void CreateUserWithBoard(string password)
        {
            // Create user with personal board

            User user = new User();

            user.firstname = HttpContext.Session.GetString("firstname");
            user.lastname = HttpContext.Session.GetString("lastname");
            user.username = HttpContext.Session.GetString("username");
            user.email = HttpContext.Session.GetString("email");
            user.dateOfBirth = Convert.ToDateTime(HttpContext.Session.GetString("dateOfBirth"));
            user.createdAt = DateTime.Now;


            int user_ID = userContainer.CreateUser(user, passwordhandler.GenerateSaltAndHash(password));
            boardContainer.CreatePersonalBoard(user_ID);
        }
    }
}