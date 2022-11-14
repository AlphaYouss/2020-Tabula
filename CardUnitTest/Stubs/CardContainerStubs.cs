using System;
using System.Collections.Generic;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace CardUnitTest.Stubs
{
    class CardContainerStubs : ICard
    {
        public List<Card> cards = new List<Card>();

        public bool? existReturnValue = null;

        public void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            Card newCard = new Card();
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

        public List<Card> GetCards(int listID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            return cards;
        }
    }
}