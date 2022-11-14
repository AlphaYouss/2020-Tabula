using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.DALs;
using ASP_Tabula.Models;
using ASP_Tabula.Containers;

namespace ASP_Tabula.Controllers
{
    public class UserController : Controller
    {
        // User related methods

        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration config;

        private static User user { get; set; }

        private static List<Board> projectBoards { get; set; }
        private static Board personalBoard { get; set; }
        private static Board currentBoard { get; set; }

        string errorMessage;

        private UserContainer userContainer { get; set; }
        private BoardContainer boardContainer { get; set; }


        public UserController (ILogger<UserController> logger, IConfiguration config)
        {
            // Set containers and config

            _logger = logger;
            this.config = config;

            userContainer = new UserContainer(new UserDAL(config));
            boardContainer = new BoardContainer(new BoardDAL(config));
        }


        public IActionResult SetData(string emailUsername)
        {
            // Get userdata

            DataTable userData = userContainer.GetUserDetails(emailUsername);

            SetUser(userData);
            SetCookie();
            SeperateBoards();

            return RedirectToAction("Index");
        }


        private void SetUser(DataTable userData)
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

            user.boards = boardContainer.GetBoards(user.id).AsReadOnly();
        }


        private void SetCookie()
        {
            // Set cookie

            HttpContext.Session.SetString("isLoggedIn", "yes");
        }


        private void SeperateBoards()
        {
            // Seperates boards

            projectBoards = new List<Board>();
            personalBoard = new Board();

            foreach (Board board in user.boards)
            {
                if (board.type == Models.Board.types.Personal)
                {
                    personalBoard = board;
                }
                else if (board.type == Models.Board.types.Project)
                {
                    projectBoards.Add(board);
                }
            }
        }


        public IActionResult Index()
        {
            // Main page

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                // Redirects to login page

                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["username"] = user.firstname;
                ViewData["personalBoard"] = personalBoard;
                return View("Index", projectBoards);
            }
        }


        public IActionResult Board(int id)
        {
            // Set selected board

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                // Redirects to login page

                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Get userdetails

                if (InvalidAccessToBoard(id))
                {
                    // Unable to create array of ints

                    ModelState.AddModelError("error", errorMessage);

                    ViewData["personalBoard"] = personalBoard;
                    return View("Index", projectBoards);
                }

                return RedirectToAction("GetUserDetails", "Board", new { emailUsername = user.email, boardID = id });
            }
        }

        private bool InvalidAccessToBoard(int boardID)
        {
            if (!boardContainer.HasAccessToBoard(user.id, boardID))
            {
                // No access to the board

                errorMessage = "Access denied.";
                return true;
            }
            else
            {
                return false;
            }
        }


        public IActionResult Details()
        {
            // Main page

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                // Redirects to login page

                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("GetUserDetails", "Details", new { emailUsername = user.email } );
            }
        }


        public ActionResult Logout()
        {
            // Logout

            user = new User();
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Login");
        }
    }
}