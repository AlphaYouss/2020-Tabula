using System;
using System.Data;
using ASP_Tabula.DALs;
using ASP_Tabula.Tools;
using ASP_Tabula.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ASP_Tabula.Containers
{
    public class DetailsController : Controller
    {
        // Personal details related methods & properties

        private readonly ILogger<DetailsController> _logger;
        private readonly IConfiguration config;

        private static User user { get; set; }

        private Passwordhandler passwordhandler { get; set; }
        private Validator validator { get; set; }

        string errorMessage;

        private UserContainer userContainer { get; set; }


        public DetailsController(ILogger<DetailsController> logger, IConfiguration config)
        {
            // Set containers and config

            _logger = logger;
            this.config = config;

            userContainer = new UserContainer(new UserDAL(config));

            passwordhandler = new Passwordhandler();
            validator = new Validator();
        }


        public IActionResult GetUserDetails(string emailUsername)
        {
            // Get userdata

            DataTable userData = userContainer.GetUserDetails(emailUsername);

            SetUserDetails(userData);

            return RedirectToAction("Index");
        }


        private void SetUserDetails(DataTable userData)
        {
            // Set userdata

            user = new User();
            user.id = Convert.ToInt32(userData.Rows[0]["ID"]);

            user.firstname = Convert.ToString(userData.Rows[0]["First_name"]);
            user.lastname = Convert.ToString(userData.Rows[0]["Last_name"]);
            user.username = Convert.ToString(userData.Rows[0]["Username"]);

            user.email = Convert.ToString(userData.Rows[0]["Email"]);
            user.dateOfBirth = Convert.ToDateTime(userData.Rows[0]["Date_of_birth"]);
            user.createdAt = Convert.ToDateTime(userData.Rows[0]["Created_at"]);
        }


        public IActionResult Index()
        {
            // Details page

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns details page

                return View("../User/Details", user);
            }
        }


        public IActionResult ChangeEmail()
        {
            // Email modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns change email modal

                return PartialView("../User/Details/_ChangeEmail");
            }
        }

        [ValidateAntiForgeryToken]
        public IActionResult UpdateEmail(string currentEmail, string newEmail)
        {
            // Edit email

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (InValidCurrentEmailCheck(currentEmail) || InValidNewEmailCheck(newEmail) || InValidCurrentEmailCheck(currentEmail, newEmail) || CheckEmailExistance(newEmail))
            {
                // Invalid current email, invalid new mail or the new mail is the old one

                ModelState.AddModelError("error", errorMessage);
                return View("../User/Details", user);
            }

            user.email = newEmail;
            userContainer.EditEmail(user.id, newEmail);

            // Details page

            return RedirectToAction("Index", "Details");
        }

        private bool InValidCurrentEmailCheck(string currentEmail)
        {
            if (currentEmail != user.email)
            {
                // The filled email is not the same as we have in the system

                errorMessage = "The filled email is not your current email.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InValidNewEmailCheck(string newEmail)
        {
            if (!validator.ValidateEmail(newEmail))
            {
                // Email error

                errorMessage = "Type in a valid email.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InValidCurrentEmailCheck(string currentEmail, string newEmail)
        {
            if (currentEmail == newEmail)
            {
                // The filled email is the same as your current email

                errorMessage = "The filled email is your current email.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckEmailExistance(string newEmail)
        {
            if (userContainer.EmailExists(newEmail))
            {
                // This email is already being used by another user

                errorMessage = "The filled email is already being used by another user.";
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult ChangePassword()
        {
            // Password modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns change password modal

                return PartialView("../User/Details/_ChangePassword");
            }
        }

        [ValidateAntiForgeryToken]
        public IActionResult UpdatePassword(string oldPassword, string newPassword, string newPasswordRepeat)
        {
            // Edit email

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (SamePasswordCheck(oldPassword, newPassword) || InValidOldPasswordCheck(oldPassword) || InValidNewPasswordCheck(newPassword, newPasswordRepeat))
            {
                // Invalid current email, invalid new mail or the new mail is the old one

                ModelState.AddModelError("error", errorMessage);
                return View("../User/Details", user);
            }

            userContainer.EditPassword(user.id, passwordhandler.GenerateSaltAndHash(newPassword));

            // Details page

            return RedirectToAction("Index", "Details");
        }

        private bool SamePasswordCheck(string oldPassword, string newPassword)
        {
            if (oldPassword == newPassword)
            {
                // The new filled password is already the old one

                errorMessage = "The new filled password is the old one.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InValidOldPasswordCheck(string oldPassword)
        {
            if (!userContainer.IsValidLoginCredentials(user.email, oldPassword))
            {
                // Email error

                errorMessage = "Invalid old password.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool InValidNewPasswordCheck(string newPassword, string newPasswordRepeat)
        {
            if (newPassword != newPasswordRepeat)
            {
                // The new filled passwords are not the same

                errorMessage = "The new filled passwords are not the same.";
                return true;
            }
            else if (!validator.ValidatePassword(newPassword))
            {
                // The new filled password is not strong enough

                errorMessage = "Please fill in a strong password that contains captial letters and numbers.";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}