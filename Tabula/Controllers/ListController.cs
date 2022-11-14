using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.DALs;
using ASP_Tabula.Models;
using ASP_Tabula.Containers;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASP_Tabula.Controllers
{
    public class ListController : Controller
    {
        // List related methods & properties

        private readonly ILogger<ListController> _logger;
        private readonly IConfiguration config;

        static List currentList;
        static int currentBoardID;

        string errorMessage;

        private BoardContainer boardContainer { get; set; }
        private ListContainer listContainer { get; set; }
        private CardContainer cardContainer { get; set; }


        public ListController(ILogger<ListController> logger, IConfiguration config)
        {
            // Set container and config

            _logger = logger;
            this.config = config;

            boardContainer = new BoardContainer(new BoardDAL(config));
            listContainer = new ListContainer(new ListDAL(config));
            cardContainer = new CardContainer(new CardDAL(config));
        }


        public IActionResult Reorder(int boardID, int userID)
        {
            // Reorder lists modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns reorder lists modal

                currentBoardID = boardID;

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID))
                {
                    // Invalid boardID or no access to the board

                    return new EmptyResult();
                }

                List<List> boardLists = listContainer.GetLists(boardID);

                // Return reorder list modal

                return PartialView("../User/List/_ReorderLists", boardLists);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult ReorderLists(string json)
        {
            // Reorder lists

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (InValidJSON(json))
            {
                // Invalid JSON

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            json = UpdateJson(json);

            int[] listIDs = new JavaScriptSerializer().Deserialize<int[]>(json);

            if (JSONToArrayUnSuccessful(listIDs.Length))
            {
                // Unable to create array of ints

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            // Reorder lists

            ChangeListOrderIDs(listIDs);

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = currentBoardID });
        }


        private bool InValidJSON(string json)
        {
            try
            {
                // Valid JSON

                JToken.Parse(json);
                return false;
            }
            catch (JsonReaderException)
            {
                errorMessage = "Unable to change the card order, please try again.";
                return true;
            }
        }


        private string UpdateJson(string json)
        {
            // Update JSON

            string jsonV2 = json.Replace("listIDs", string.Empty);
            jsonV2 = jsonV2.Substring(4, jsonV2.Length - 4);
            jsonV2 = jsonV2.Remove(jsonV2.Length - 1);

            return jsonV2;
        }


        private bool JSONToArrayUnSuccessful(int count)
        {
            if (count < 1)
            {
                // Unable to create array of ints

                errorMessage = "Unable to change the list order, please try again.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ChangeListOrderIDs(int[] listIDs)
        {
            // Loop through all listsIDs

            for (int i = 0; i < listIDs.Length; i++)
            {
                // Update the orderID of the list

                listContainer.EditList(listIDs[i], i, DateTime.Now);
            }
        }


        public IActionResult View(int boardID, int listID, int userID)
        {
            // View list modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns edit list modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID))
                {
                    // Invalid boardID, no access to the board or no access to the list

                    return new EmptyResult();
                }

                // Return View list modal

                return PartialView("../User/List/_ViewList", currentList);
            }
        }


        public IActionResult Create(int boardID, int userID)
        {
            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns create list modal

                currentList = new List();
                currentBoardID = boardID;

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID))
                {
                    // Invalid boardID or no access to the board

                    return new EmptyResult();
                }

                // Return create list modal

                return PartialView("../User/List/_CreateList");
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult CreateNewList(string listname)
        {
            // Create new list

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ValidListnameCheck(listname))
            {
                // Invalid listname

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            int listsCount = listContainer.CountLists(currentBoardID);

            // Create list

            listContainer.CreateList(currentBoardID, listsCount, listname, DateTime.Now);

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = currentBoardID });
        }


        public IActionResult Edit(int boardID, int listID, int userID)
        {
            // Edit list modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns edit list modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID))
                {
                    // Invalid boardID, no access to the board or no access to the list

                    return new EmptyResult();
                }

                // Return edit list modal

                return PartialView("../User/List/_EditList", currentList);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult EditCurrentList(string listname)
        {
            // Edit current list

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ValidListnameCheck(listname) || CurrentListnameCheck(listname))
            {
                // Invalid listname

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            // Edit list

            listContainer.EditList(currentList.id, currentList.orderID, listname, DateTime.Now);

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = currentBoardID });
        }


        public IActionResult Delete(int boardID, int listID, int userID)
        {
            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns delete list modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID))
                {
                    // Invalid boardID, no access to the board or no access to the list

                    return new EmptyResult();
                }

                // Delete list modal

                return PartialView("../User/List/_DeleteList", currentList);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult DeleteCurrentList()
        {
            // Delete current list

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            // Remove cards in list before deleting the list itself

            cardContainer.DeleteCards(currentList.id);
            listContainer.DeleteList(currentList.id);

            // Gather all lists

            List<List> allLists = listContainer.GetLists(currentBoardID).OrderBy(o => o.orderID).ToList();

            // Loop through all lists

            for (int i = 0; i < allLists.Count; i++)
            {
                // Update the orderID of the list

                listContainer.EditList(allLists[i].id, i, allLists[i].name, DateTime.Now);
            }

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = currentBoardID });
        }


        private bool InvalidBoardID(int boardID)
        {
            if (boardID <= 1)
            {
                // Not a valid boardID

                errorMessage = "Access denied.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool InvalidAccessToBoard(int userID)
        {
            if (!boardContainer.HasAccessToBoard(userID, currentBoardID))
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


        private bool InvalidAccessToList(int userID)
        {
            if (!listContainer.HasAccessToList(userID, currentList.id))
            {
                // No access to the list

                errorMessage = "Access denied.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool ValidListnameCheck(string listname)
        { 
            if (listname == null)
            {
                // Not a valid name

                errorMessage = "Please fill in a valid listname.";
                return true;
            }
            else if (listname.Length <= 1)
            {
                // Not a valid name

                errorMessage = "Please fill in a valid listname.";
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CurrentListnameCheck(string listname)
        {
            if (listname == currentList.name)
            {
                // The current card has the same name as before

                errorMessage = "The listname is cannot be the same.";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}