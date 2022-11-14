using System;
using System.Collections.Generic;
using ASP_Tabula.Interfaces;
using ASP_Tabula.Models;

namespace CardUnitTest.Stubs
{
    class CardContainerStubs : ICard
    {
        public List<Card> cards = new List<Card>();

        public bool? existReturnValue = null;
        public int? numberReturnValue = null;


        public int CountCards(int listID)
        {
            if (numberReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field numberReturnValue.");
            }
            return numberReturnValue.Value;
        }


        public void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            Card newCard = new Card();
            newCard.id = 0;

            cards.Add(newCard);
        }


        public void DeleteCard(int cardID)
        {
            if (cards.Count > 0)
            {
                cards.RemoveAt(0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }


        public void DeleteCards(int listID)
        {
            if (cards.Count > 0)
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    cards.RemoveAt(i);
                    i--;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }


        public void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT)
        {
            if (cards.Count > 0)
            {
                Card editedCard = new Card();
                cards[0] = editedCard;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }


        public void EditCard(int cardID, int listID, int orderID, DateTime updatedAT)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            Card card = new Card();

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].id == cardID)
                {
                    cards[i].name = "test";
                }
            }
        }


        public Card GetCard(int cardID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            Card card = new Card();

            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].id == cardID)
                {
                    card = cards[i];
                }
            }
            return card;
        }


        public List<Card> GetCards(int listID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return cards;
        }


        public bool HasAccessToCard(int userID, int listID, int cardID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return existReturnValue.Value;
        }
    }
}