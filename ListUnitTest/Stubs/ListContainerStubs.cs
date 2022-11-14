using System;
using System.Collections.Generic;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace ListUnitTest.Stubs
{
    class ListContainerStubs : IList
    {
        public List<List> lists = new List<List>();

        public bool? existReturnValue = null;

        public void CreateList(int boardID, int orderID, string name, DateTime createdAT)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            List newList = new List();
            lists.Add(newList);
        }

        public void DeleteList(int listID)
        {
            if (lists.Count > 0)
            {
                lists.RemoveAt(0);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }

        public void EditList(int listID, int orderID, string name, DateTime updatedAT)
        {
            if (lists.Count > 0)
            {
                List editedList = new List();
                lists[0] = editedList;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index out of range.");
            }
        }

        public List<List> GetLists(int boardID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            return lists;
        }
    }
}