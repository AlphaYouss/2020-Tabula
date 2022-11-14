using System;
using System.Collections.Generic;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.Containers
{
    public class ListContainer
    {
        // List methods based on the dal

        IList listDAL;

        public ListContainer(IList listDAL)
        {
            this.listDAL = listDAL;
        }

        public List<List> GetLists(int boardID)
        {
            return listDAL.GetLists(boardID);
        }

        public List GetList(int listID)
        {
            return listDAL.GetList(listID);
        }

        public void CreateList(int boardID, int orderID, string name, DateTime createdAT)
        {
            listDAL.CreateList(boardID, orderID, name, createdAT);
        }

        public void EditList(int listID, int orderID, string name, DateTime updatedAT)
        {
            listDAL.EditList(listID, orderID, name, updatedAT);
        }

        public void EditList(int listID, int orderID, DateTime updatedAT)
        {
            listDAL.EditList(listID, orderID, updatedAT);
        }

        public void DeleteList(int listID)
        {
            listDAL.DeleteList(listID);    
        }

        public int CountLists(int boardID)
        {
            return listDAL.CountLists(boardID);
        }

        public bool HasAccessToList(int userID, int listID)
        {
            return listDAL.HasAccessToList(userID, listID);
        }
    }
}