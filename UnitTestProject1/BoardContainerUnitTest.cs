using ASP_Tabula.Containers;
using ASP_Tabula.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BoardUnitTest.Stubs;

namespace BoardUnitTest
{
    [TestClass]
    public class BoardContainerUnitTest
    {
        // Create personal board

        [TestMethod]
        public void TestCreatePersonalBoard()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            boardContainer.CreatePersonalBoard(0);

            Assert.AreEqual(boardContainerStubs.boards.Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
        "Invalid use of stub code. First set field existsReturnValue.")]
        public void TestCreatePersonalBoardFailed()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);

            boardContainer.CreatePersonalBoard(0);

            Assert.AreEqual(boardContainerStubs.boards.Count, 1);
        }


        [TestMethod]
        public void TestCreatePersonalBoardFailed2()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            boardContainer.CreatePersonalBoard(0);

            Assert.AreNotEqual(boardContainerStubs.boards.Count, 0);
        }

        // Get board

        [TestMethod]
        public void TestGetBoard()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            boardContainer.CreatePersonalBoard(0);
            Board currentBoard = boardContainer.GetBoard(1);

            Assert.AreEqual(currentBoard.id, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestGetBoardFailed()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);

            boardContainer.CreatePersonalBoard(0);
            Board currentBoard = boardContainer.GetBoard(1);

            Assert.AreEqual(currentBoard.id, 1);
        }


        [TestMethod]
        public void TestGetBoardFailed2()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            boardContainer.CreatePersonalBoard(0);
            Board currentBoard = boardContainer.GetBoard(1);

            Assert.AreNotEqual(currentBoard.id, 0);
        }

        // Get boards

        [TestMethod]
        public void TestGetBoards()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            Assert.AreEqual(boardContainer.GetBoards(0).Count, 0);
        }


        [TestMethod]
        public void TestGetBoards2()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            boardContainer.CreatePersonalBoard(0);

            Assert.AreEqual(boardContainer.GetBoards(0).Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestGetBoardsFailed()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);

            Assert.AreEqual(boardContainer.GetBoards(0).Count, 0);
        }


        [TestMethod]
        public void TestGetBoardsFailed2()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            Assert.AreNotEqual(boardContainer.GetBoards(0).Count, 1);
        }

        // Has access to board

        [TestMethod]
        public void TestHasAccessToBoard()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = true;

            bool result = boardContainer.HasAccessToBoard(0, 0);

            Assert.IsTrue(result);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestHasAccessToBoardFailed()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);

            bool result = boardContainer.HasAccessToBoard(0, 0);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestHasAccessToBoardFailed2()
        {
            BoardContainerStubs boardContainerStubs = new BoardContainerStubs();
            BoardContainer boardContainer = new BoardContainer(boardContainerStubs);
            boardContainerStubs.existReturnValue = false;

            bool result = boardContainer.HasAccessToBoard(0, 0);

            Assert.IsFalse(result);
        }
    }
}
