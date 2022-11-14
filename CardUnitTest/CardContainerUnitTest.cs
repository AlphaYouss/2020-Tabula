using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CardUnitTest.Stubs;
using WF_Tabula.Containers;

namespace CardUnitTest
{
    [TestClass]
    public class CardContainerUnitTest
    {
        [TestMethod]
        public void TestCreateCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Assert.AreEqual(cardContainerStubs.cards.Count, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
            "Index out of range")]
        public void TestFailedDeleteCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.DeleteCard(0);
            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }

        [TestMethod]
        public void TestDeleteCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.DeleteCard(0); ;

            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
    "Index out of range")]
        public void TestFailedDeleteCards()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.DeleteCards(0);
            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }

        [TestMethod]
        public void TestDeleteCards()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.DeleteCards(1);

            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
    "Index out of range")]
        public void TestFailedEditCards()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.EditCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Assert.AreEqual(cardContainerStubs.cards.Count, 1);
        }

        [TestMethod]
        public void TestEditCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.EditCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Assert.AreEqual(cardContainerStubs.cards.Count, 1);
        }

        [TestMethod]
        public void TestGetCards()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            Assert.AreEqual(cardContainer.GetCards(0).Count, 0);
        }

        [TestMethod]
        public void TestGetCards2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Assert.AreEqual(cardContainer.GetCards(0).Count, 1);
        }
    }
}