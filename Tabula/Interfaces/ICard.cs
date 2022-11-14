using System;
using System.Collections.Generic;
using ASP_Tabula.Models;

namespace ASP_Tabula.Interfaces
{
    public interface ICard
    {
        // Card methods

        List<Card> GetCards(int listID);
        Card GetCard(int cardID);
        void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt);
        void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT);
        void EditCard(int cardID, int listID, int orderID, DateTime updatedAT);
        void DeleteCard(int cardID);
        void DeleteCards(int listID);
        int CountCards(int listID);
        bool HasAccessToCard(int userID, int listID, int cardID);
    }
}