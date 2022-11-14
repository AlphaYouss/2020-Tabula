using System;
using System.Data;
using ASP_Tabula.DALs;
using ASP_Tabula.Models;
using ASP_Tabula.Containers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace ASP_Tabula.Controllers
{
    public class BoardController : Controller
    {
        // Board related methods & properties

        private readonly ILogger<BoardController> _logger;
        private readonly IConfiguration config;

        private static User user { get; set; }

        private static Board currentBoard { get; set; }

        private UserContainer userContainer { get; set; }
        private BoardContainer boardContainer { get; set; }
        private ListContainer listContainer { get; set; }
        private CardContainer cardContainer { get; set; }


        public BoardController(ILogger<BoardController> logger, IConfiguration config)
        {
            // Set containers and config

            _logger = logger;
            this.config = config;

            userContainer = new UserContainer(new UserDAL(config));
            boardContainer = new BoardContainer(new BoardDAL(config));
            listContainer = new ListContainer(new ListDAL(config));
            cardContainer = new CardContainer(new CardDAL(config));
        }


        public IActionResult GetUserDetails(string emailUsername, int boardID)
        {
            // Get userdetails

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Set userdetails

                return RedirectToAction("SetUser", new { emailUsername = emailUsername, boardID = boardID});
            }
        }


        public IActionResult SetUser(string emailUsername, int boardID)
        {
            // Set userdata

            DataTable userData = userContainer.GetUserDetails(emailUsername);

            user = new User();
            user.id = Convert.ToInt32(userData.Rows[0]["ID"]);

            user.firstname = Convert.ToString(userData.Rows[0]["First_name"]);
            user.lastname = Convert.ToString(userData.Rows[0]["Last_name"]);
            user.username = Convert.ToString(userData.Rows[0]["Username"]);

            user.email = Convert.ToString(userData.Rows[0]["Email"]);
            user.dateOfBirth = Convert.ToDateTime(userData.Rows[0]["Date_of_birth"]);
            user.createdAt = Convert.ToDateTime(userData.Rows[0]["Created_at"]);

            user.boards = boardContainer.GetBoards(user.id).AsReadOnly();

            return RedirectToAction("SetCurrentBoard", new { id = boardID });
        }


        public IActionResult SetCurrentBoard(int id)
        {
            // Set current selected board

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Set selected board

                currentBoard = boardContainer.GetBoard(id);
                currentBoard.lists = listContainer.GetLists(currentBoard.id).AsReadOnly();

                foreach (List list in currentBoard.lists)
                {
                    list.cards = cardContainer.GetCards(list.id).AsReadOnly();
                }

                return RedirectToAction("Index");
            }
        }


        public IActionResult Index()
        {
            // Shows board page

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Board page

                ViewData["UserID"] = user.id;
                return View("../User/Board", currentBoard);
            }
        }


        public IActionResult Fail(string message)
        {
            // Shows error message based on the incoming message

            ModelState.AddModelError("error", message);

            ViewData["UserID"] = user.id;
            return View("../User/Board", currentBoard);
        }
    }
}