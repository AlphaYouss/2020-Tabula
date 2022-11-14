using ASP_Tabula.Containers;
using ASP_Tabula.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CardUnitTest.Stubs;

namespace CardUnitTest
{
    [TestClass]
    public class CardContainerUnitTest
    {
        // Count cards

        [TestMethod]
        public void TestCountCards()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.numberReturnValue = 0;

            cardContainer.CountCards(0);

            Assert.AreEqual(cardContainerStubs.numberReturnValue, 0);
        }


        [TestMethod]
        public void TestCountCards2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = true;
            cardContainerStubs.numberReturnValue = 1;

            cardContainer.CreateCard(0, 0, "", "", "", default, DateTime.Now);
            cardContainer.CountCards(0);

            Assert.AreEqual(cardContainerStubs.numberReturnValue, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
        "Invalid use of stub code. First set field existsReturnValue.")]
        public void TestCountCardsFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.numberReturnValue = 1;

            cardContainer.CreateCard(0, 0, "", "", "", default, DateTime.Now);
            cardContainer.CountCards(0);

            Assert.AreEqual(cardContainerStubs.numberReturnValue, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field numberReturnValue.")]
        public void TestCountCardsFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = true;

            cardContainer.CreateCard(0, 0, "", "", "", default, DateTime.Now);
            cardContainer.CountCards(0);

            Assert.AreEqual(cardContainerStubs.numberReturnValue, 1);
        }


        [TestMethod]
        public void TestCountCardsFailed3()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = true;
            cardContainerStubs.numberReturnValue = 1;

            cardContainer.CreateCard(0, 0, "", "", "", default, DateTime.Now);
            cardContainer.CountCards(0);

            Assert.AreNotEqual(cardContainerStubs.numberReturnValue, 0);
        }

        // Create card

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
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field numberReturnValue.")]
        public void TestCreateCardFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);

            Assert.AreEqual(cardContainerStubs.cards.Count, 1);
        }


        [TestMethod]
        public void TestCreateCardFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);

            Assert.AreNotEqual(cardContainerStubs.cards.Count, 0);
        }

        // Delete card

        [TestMethod]
        public void TestDeleteCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.DeleteCard(0);

            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
"Index out of range.")]
        public void TestDeleteCardFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.DeleteCard(0);

            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }


        [TestMethod]
        public void TestDeleteCardFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.DeleteCard(0);

            Assert.AreNotEqual(cardContainerStubs.cards.Count, 1);
        }

        // Delete cards

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
"Index out of range.")]
        public void TestDeleteCardsFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.DeleteCards(0);

            Assert.AreEqual(cardContainerStubs.cards.Count, 0);
        }


        [TestMethod]
        public void TestDeleteCardsFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.DeleteCards(1);

            Assert.AreNotEqual(cardContainerStubs.cards.Count, 1);
        }

        // Edit card

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
        [ExpectedException(typeof(ArgumentOutOfRangeException),
"Index out of range")]
        public void TestEditCardsFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.EditCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);

            Assert.AreEqual(cardContainerStubs.cards.Count, 1);
        }


        [TestMethod]
        public void TestEditCardsFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.EditCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);

            Assert.AreNotEqual(cardContainerStubs.cards.Count, 0);
        }

        // Edit card v2

        [TestMethod]
        public void TestEditCardV2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.EditCard(0, 0, 0, DateTime.Now);

            Assert.AreSame(cardContainerStubs.cards[0].name, "test");
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestEditCardV2Failed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.EditCard(0, 0, 0, DateTime.Now);

            Assert.AreSame(cardContainerStubs.cards[0].name, "test");
        }


        [TestMethod]
        public void TestEditCardV2Failed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            cardContainer.EditCard(0, 0, 0, DateTime.Now);

            Assert.AreNotSame(cardContainerStubs.cards[0].name, "testa");
        }

        // Get card

        [TestMethod]
        public void TestGetCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Card currentCard = cardContainer.GetCard(0);

            Assert.AreEqual(currentCard.id, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestGetCardFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Card currentCard = cardContainer.GetCard(0);

            Assert.AreEqual(currentCard.id, 0);
        }


        [TestMethod]
        public void TestGetCardFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            cardContainer.CreateCard(0, 0, "", "", "", DateTime.Now, DateTime.Now);
            Card currentCard = cardContainer.GetCard(0);

            Assert.AreNotEqual(currentCard.id, 1);
        }

        // Get cards

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


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void TestGetCardsFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            Assert.AreEqual(cardContainer.GetCards(0).Count, 0);
        }


        [TestMethod]
        public void TestGetCardsFailed2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            Assert.AreNotEqual(cardContainer.GetCards(0).Count, 1);
        }

        // Has access to card

        [TestMethod]
        public void HasAccessToCard()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = true;

            bool result = cardContainer.HasAccessToCard(0, 0, 0);

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void HasAccessToCard2()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);
            cardContainerStubs.existReturnValue = false;

            bool result = cardContainer.HasAccessToCard(0, 0, 0);

            Assert.IsFalse(result);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existsReturnValue.")]
        public void HasAccessToCardFailed()
        {
            CardContainerStubs cardContainerStubs = new CardContainerStubs();
            CardContainer cardContainer = new CardContainer(cardContainerStubs);

            bool result = cardContainer.HasAccessToCard(0, 0, 0);

            Assert.IsTrue(result);
        }
    }
}
