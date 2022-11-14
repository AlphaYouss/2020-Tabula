using System;
using System.Collections.Generic;
using WF_Tabula.Models;

namespace WF_Tabula.Interfaces
{
    public interface IList
    {
        List<List> GetLists(int boardID);
        void CreateList(int boardID, int orderID, string name, DateTime createdAT);
        void EditList(int listID, int orderID, string name, DateTime updatedAT);
        void DeleteList(int listID);
    }
}