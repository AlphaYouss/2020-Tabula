using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ListUnitTest.Stubs;
using ASP_Tabula.Containers;
using ASP_Tabula.Models;

namespace ListUnitTest
{
    [TestClass]
    public class ListContainerUnitTest
    {
        // Count lists

        [TestMethod]
        public void TestCountLists()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.numberReturnValue = 0;

            listContainer.CountLists(0);

            Assert.AreEqual(listContainerStubs.numberReturnValue, 0);
        }


        [TestMethod]
        public void TestCountLists2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = true;
            listContainerStubs.numberReturnValue = 0;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.CountLists(0);

            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
        "Invalid use of stub code. First set field numberReturnValue.")]
        public void TestCountListsFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainer.CountLists(0);

            Assert.AreEqual(listContainerStubs.numberReturnValue, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field numberReturnValue.")]
        public void TestCountListsFailed2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainerStubs.numberReturnValue = 0;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.CountLists(0);

            Assert.AreEqual(listContainerStubs.numberReturnValue, 0);
        }

        // Create list

        [TestMethod]
        public void TestCreateList()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);

            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestCreateListFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainer.CreateList(0, 0, "", DateTime.Now);

            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }


        [TestMethod]
        public void TestCreateListFailed2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);

            Assert.AreNotEqual(listContainerStubs.lists.Count, 0);
        }

        // Delete list

        [TestMethod]
        public void TestDeleteList()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.DeleteList(0);

            Assert.AreEqual(listContainerStubs.lists.Count, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
"Index out of range.")]
        public void TestDeleteListFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainer.DeleteList(0);

            Assert.AreEqual(listContainerStubs.lists.Count, 0);
        }


        [TestMethod]
        public void TestDeleteListFailed2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.DeleteList(0);

            Assert.AreNotEqual(listContainerStubs.lists.Count, 1);
        }

        // Edit list

        [TestMethod]
        public void TestEditList()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.EditList(0, 0, "", DateTime.Now);

            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
"Index out of range")]
        public void TestEditListFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.EditList(0, 0, "", DateTime.Now);
            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }

        // Edit list v2

        [TestMethod]
        public void TestEditListV2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.EditList(0, 0, DateTime.Now);

            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestEditListV2Failed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainer.EditList(0, 0, DateTime.Now);
            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }


        [TestMethod]
        public void TestEditListV2Failed2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            listContainer.EditList(0, 0, DateTime.Now);

            Assert.AreNotEqual(listContainerStubs.lists.Count, 0);
        }

        // Get List

        [TestMethod]
        public void TestGetCard()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            List currentList = listContainer.GetList(0);

            Assert.AreEqual(currentList.id, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestGetCardFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainer.CreateList(0, 0, "", DateTime.Now);
            List currentList = listContainer.GetList(0);

            Assert.AreEqual(currentList.id, 0);
        }


        [TestMethod]
        public void TestGetCardFailed2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            List currentList = listContainer.GetList(0);

            Assert.AreNotEqual(currentList.id, 1);
        }

        // Get Lists

        [TestMethod]
        public void TestGetLists()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            Assert.AreEqual(listContainer.GetLists(0).Count, 0);
        }


        [TestMethod]
        public void TestGetLists2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.CreateList(0, 0, "", DateTime.Now);
            Assert.AreEqual(listContainer.GetLists(0).Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestGetListsFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            Assert.AreEqual(listContainer.GetLists(0).Count, 0);
        }


        [TestMethod]
        public void TestGetListsFailed2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            Assert.AreNotEqual(listContainer.GetLists(0).Count, 1);
        }

        // Has access to card

        [TestMethod]
        public void HasAccessToList()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = true;

            bool result = listContainer.HasAccessToList(0, 0);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void HasAccessToList2()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            bool result = listContainer.HasAccessToList(0, 0);

            Assert.IsFalse(result);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void HasAccessToListFailed()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            bool result = listContainer.HasAccessToList(0, 0);

            Assert.IsTrue(result);
        }
    }
}
