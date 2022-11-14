using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ListUnitTest.Stubs;
using WF_Tabula.Containers;

namespace ListUnitTest
{
    [TestClass]
    public class ListContainerUnitTest
    {
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
        [ExpectedException(typeof(ArgumentOutOfRangeException),
        "Index out of range")]
        public void TestFailedDeleteList()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);

            listContainer.DeleteList(0);
            Assert.AreEqual(listContainerStubs.lists.Count, 0);
        }

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
        "Index out of range")]
        public void TestFailedEditList()
        {
            ListContainerStubs listContainerStubs = new ListContainerStubs();
            ListContainer listContainer = new ListContainer(listContainerStubs);
            listContainerStubs.existReturnValue = false;

            listContainer.EditList(0, 0, "", DateTime.Now);
            Assert.AreEqual(listContainerStubs.lists.Count, 1);
        }

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
    }
}