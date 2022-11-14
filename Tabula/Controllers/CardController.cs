using System;
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
    public class CardController : Controller
    {
        // Card related methods & properties

        private readonly ILogger<CardController> _logger;
        private readonly IConfiguration config;

        static List currentList;
        static Card currentCard;
        static int currentBoardID;

        string errorMessage;

        private BoardContainer boardContainer { get; set; }
        private ListContainer listContainer { get; set; }
        private CardContainer cardContainer { get; set; }


        public CardController(ILogger<CardController> logger, IConfiguration config)
        {
            // Set container and config

            _logger = logger;
            this.config = config;

            boardContainer = new BoardContainer(new BoardDAL(config));
            listContainer = new ListContainer(new ListDAL(config));
            cardContainer = new CardContainer(new CardDAL(config));
        }


        public IActionResult ReorderCards(string json, int boardID, int userID)
        {
            // Reorder cards

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            currentBoardID = boardID;

            if (InValidJSON(json) || InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID))
            {
                // Invalid JSON, boardID or has no access to the board

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            json = UpdateJson(json);

            // JSON to list of JSLists

            List<JSList> JSLists = new JavaScriptSerializer().Deserialize<List<JSList>>(json);

            if (JSONToListUnSuccessful(JSLists.Count))
            {
                // Unable to create list of JSLists

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            ChangeOrderIDsInList(JSLists);

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = boardID });
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
            // Removes parts from JSON

            string jsonV2 = json.Replace("allCardIDs", string.Empty);
            jsonV2 = jsonV2.Substring(4, jsonV2.Length - 4);
            jsonV2 = jsonV2.Remove(jsonV2.Length - 1);

            return jsonV2;
        }


        private bool JSONToListUnSuccessful(int count)
        {
            if (count < 1)
            {
                // Unable to create JSLists

                errorMessage = "Unable to change the card order, please try again.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private void ChangeOrderIDsInList(List<JSList> JSLists)
        {
            foreach (JSList JSList in JSLists)
            {
                // Loop through every list and update the orderID

                for (int i = 0; i < JSList.cardIDs.Length; i++)
                {
                    cardContainer.EditCard(JSList.cardIDs[i], JSList.ID, JSList.cardOrderIDs[i], DateTime.Now);
                }
            }
        }


        public IActionResult Create(int boardID, int listID, int userID)
        {
            // Create card modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns create card modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID))
                {
                    // Invalid boardID, no access to the board or list

                    return new EmptyResult();
                }

                // Return create card modal

                return PartialView("../User/Card/_CreateCard", currentList);
            }
        }


        public IActionResult View(int boardID, int listID, int cardID, int userID)
        {
            // View card modal 

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns edit card modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);
                currentCard = cardContainer.GetCard(cardID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID) || InvalidAccessToCard(userID))
                {
                    // Invalid boardID, no access to the board, list or card

                    return new EmptyResult();
                }

                ViewData["listName"] = currentList.name;

                // Return View card modal

                return PartialView("../User/Card/_ViewCard", currentCard);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult CreateNewCard(string cardname, string description, string priority, DateTime deadline)
        {
            // Create new card

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ValidCardnameCheck(cardname) || ValidPriorityCheck(priority))
            {
                // Invalid priority or cardname

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            description = SetDescription(description);

            CreateCard(cardname, description, priority, deadline);

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = currentBoardID });
        }

        
        private void CreateCard(string cardname, string description, string priority, DateTime deadline)
        {
            // Create card based on deadline

            int cardsCount = cardContainer.CountCards(currentList.id);

            if (deadline.Date.Year == 1)
            {
                cardContainer.CreateCard(currentList.id, cardsCount, cardname, description, priority, default, DateTime.Now);
            }
            else
            {
                cardContainer.CreateCard(currentList.id, cardsCount, cardname, description, priority, deadline, DateTime.Now);
            }
        }


        public IActionResult Edit(int boardID, int listID, int cardID, int userID)
        {
            // Edit card modal 

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns edit card modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);
                currentCard = cardContainer.GetCard(cardID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID) || InvalidAccessToCard(userID))
                {
                    // Invalid boardId, no access to the board, list or card

                    return new EmptyResult();
                }

                ViewData["listName"] = currentList.name;

                // Return edit card modal

                return PartialView("../User/Card/_EditCard", currentCard);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult EditCurrentCard(string cardname, string description, string priority, DateTime deadline)
        {
            // Edit current card

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ValidCardnameCheck(cardname) || CurrentCardnameCheck(cardname) || ValidPriorityCheck(priority))
            {
                // Invalid priority, cardname or priority

                return RedirectToAction("Fail", "Board", new { message = errorMessage });
            }

            description = SetDescription(description);

            UpdateCard(cardname, description, priority, default);

            // Board page

            return RedirectToAction("SetCurrentBoard", "Board", new { id = currentBoardID });
        }


        private void UpdateCard(string cardname, string description, string priority, DateTime deadline)
        {
            // Edit card based on deadline

            if (deadline.Date.Year == 1)
            {
                cardContainer.EditCard(currentCard.id, currentCard.orderID, cardname, description, priority, default, DateTime.Now);
            }
            else
            {
                cardContainer.EditCard(currentCard.id, currentCard.orderID, cardname, description, priority, deadline, DateTime.Now);
            }
        }


        public IActionResult Delete(int boardID, int listID, int cardID, int userID)
        {
            // Delete card modal

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                // Returns delete card modal

                currentBoardID = boardID;
                currentList = listContainer.GetList(listID);
                currentCard = cardContainer.GetCard(cardID);

                if (InvalidBoardID(currentBoardID) || InvalidAccessToBoard(userID) || InvalidAccessToList(userID) || InvalidAccessToCard(userID))
                {
                    // No access to the board, list or card

                    return new EmptyResult();
                }

                ViewData["listName"] = currentList.name;

                // Return delete card modal

                return PartialView("../User/Card/_DeleteCard", currentCard);
            }
        }


        [ValidateAntiForgeryToken]
        public IActionResult DeleteCurrentCard()
        {
            // Delete current card

            if (HttpContext.Session.GetString("isLoggedIn") == "" || HttpContext.Session.GetString("isLoggedIn") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            cardContainer.DeleteCard(currentCard.id);

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


        private bool InvalidAccessToCard(int userID)
        {
            if (!cardContainer.HasAccessToCard(userID, currentList.id, currentCard.id))
            {
                // No access to the card

                errorMessage = "Access denied.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool ValidCardnameCheck(string cardname)
        {
            if (cardname == null)
            {
                // Not a valid cardname

                errorMessage = "Please fill in a valid cardname.";
                return true;
            }
            else if (cardname.Length <= 1)
            {
                // Not a valid cardname

                errorMessage = "Please fill in a valid cardname.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private bool ValidPriorityCheck(string priority)
        {
            // Put all priorities in a list

            List<string> priorities = new List<string>();
            Array arrPriorities = Enum.GetValues(typeof(Card.Priorities));
            Array.Reverse(arrPriorities);

            foreach (var arrPriorityItem in arrPriorities)
            {
                priorities.Add(arrPriorityItem.ToString());
            }

            // Check if current priority exists

            bool priorityExist = priorities.Contains(priority);

            if (priorityExist == false)
            {
                // Invalid priority

                errorMessage = "Please select a valid priority.";
                return true;
            }
            else
            {
                return false;
            }
        }


        private string SetDescription(string description)
        {
            if (description == null)
            {
                // Empty description

                description = string.Empty;
            }

            return description;
        }


        private bool CurrentCardnameCheck(string cardname)
        {
            if (cardname == currentCard.name)
            {
                // The current card has the same name as before

                errorMessage = "The cardname is cannot be the same.";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}