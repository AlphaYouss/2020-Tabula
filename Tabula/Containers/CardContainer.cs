using System;
using System.Collections.Generic;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.Containers
{
    public class CardContainer
    {
        // Card methods based on the dal

        ICard cardDAL;

        public CardContainer(ICard cardDAL)
        {
            this.cardDAL = cardDAL;
        }

        public List<Card> GetCards(int listID)
        {
            return cardDAL.GetCards(listID);
        }

        public Card GetCard(int cardID)
        {
            return cardDAL.GetCard(cardID);
        }

        public void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt)
        {
            cardDAL.CreateCard(listID, orderID, name, description, priority, deadline, createdAt);      
        }

        public void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT)
        {
            cardDAL.EditCard(cardID, orderID, name, description, priority, deadline, updatedAT);
        }

        public void EditCard(int cardID, int listID, int orderID, DateTime updatedAT)
        {
            cardDAL.EditCard(cardID, listID, orderID, updatedAT);
        }

        public void DeleteCard(int cardID)
        {
            cardDAL.DeleteCard(cardID);
        }

        public void DeleteCards(int listID)
        {
            cardDAL.DeleteCards(listID);
        }

        public int CountCards(int listID)
        {
            return cardDAL.CountCards(listID);
        }
        public bool HasAccessToCard(int userID, int listID, int cardID)
        {
            return cardDAL.HasAccessToCard(userID, listID, cardID);
        }
    }
}