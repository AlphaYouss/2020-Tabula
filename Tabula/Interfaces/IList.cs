using System;
using System.Collections.Generic;
using ASP_Tabula.Models;

namespace ASP_Tabula.Interfaces
{
    public interface IList
    {
        // List methods

        List<List> GetLists(int boardID);
        List GetList(int listID);
        void CreateList(int boardID, int orderID, string name, DateTime createdAT);
        void EditList(int listID, int orderID, string name, DateTime updatedAT);
        void EditList(int listID, int orderID, DateTime updatedAT);
        void DeleteList(int listID);
        int CountLists(int boardID);
        bool HasAccessToList(int userID, int listID);
    }
}