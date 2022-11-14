using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardUnitTest.Stubs;
using WF_Tabula.Containers;

namespace BoardUnitTest
{
    [TestClass]
    public class BoardContainerUnitTest
    {
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
    }
}