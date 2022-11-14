using System;
using System.Collections.Generic;
using WF_Tabula.Models;

namespace WF_Tabula.Interfaces
{
    public interface ICard
    {
        List<Card> GetCards(int listID);
        void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt);
        void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT);
        void DeleteCard(int cardID);
        void DeleteCards(int listID);
    }
}