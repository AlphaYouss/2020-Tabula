using System;
using System.Collections.Generic;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.Containers
{
    public class ListContainer
    {
        IList listDAL;

        public ListContainer(IList listDAL)
        {
            this.listDAL = listDAL;
        }

        public List<List> GetLists(int boardID)
        {
            return listDAL.GetLists(boardID);
        }

        public void CreateList(int boardID, int orderID, string name, DateTime createdAT)
        {
            listDAL.CreateList(boardID, orderID, name, createdAT);
        }

        public void EditList(int listID, int orderID, string name, DateTime updatedAT)
        {
            listDAL.EditList(listID, orderID, name, updatedAT);
        }

        public void DeleteList(int listID)
        {
            listDAL.DeleteList(listID);    
        }
    }
}