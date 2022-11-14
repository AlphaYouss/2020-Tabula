using System;
using System.Collections.Generic;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.Containers
{
    public class CardContainer
    {
        ICard cardDAL;

        public CardContainer(ICard cardDAL)
        {
            this.cardDAL = cardDAL;
        }

        public List<Card> GetCards(int listID)
        {
            return cardDAL.GetCards(listID);
        }

        public void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt)
        {
            cardDAL.CreateCard(listID, orderID, name, description, priority, deadline, createdAt);      
        }

        public void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT)
        {
            cardDAL.EditCard(cardID, orderID, name, description, priority, deadline, updatedAT);
        }

        public void DeleteCard(int cardID)
        {
            cardDAL.DeleteCard(cardID);
        }

        public void DeleteCards(int listID)
        {
            cardDAL.DeleteCards(listID);
        }
    }
}