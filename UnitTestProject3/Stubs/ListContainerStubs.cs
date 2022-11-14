using System;
using System.Collections.Generic;
using ASP_Tabula.Interfaces;
using ASP_Tabula.Models;

namespace ListUnitTest.Stubs
{
    class ListContainerStubs : IList
    {
        public List<List> lists = new List<List>();

        public bool? existReturnValue = null;
        public int? numberReturnValue = null;


        public int CountLists(int boardID)
        {
            if (numberReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field numberReturnValue.");
            }
            return numberReturnValue.Value;
        }


        public void CreateList(int boardID, int orderID, string name, DateTime createdAT)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
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


        public void EditList(int listID, int orderID, DateTime updatedAT)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            List list = new List();

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].id == listID)
                {
                    lists[i].name = "test";
                }
            }
        }


        public List GetList(int listID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            List list = new List();

            for (int i = 0; i < lists.Count; i++)
            {
                if (lists[i].id == listID)
                {
                    list = lists[i];
                }
            }
            return list;
        }


        public List<List> GetLists(int boardID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return lists;
        }


        public bool HasAccessToList(int userID, int listID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return existReturnValue.Value;
        }
    }
}