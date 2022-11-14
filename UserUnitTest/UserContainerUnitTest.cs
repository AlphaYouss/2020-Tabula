using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using UserUnitTest.Stubs;
using WF_Tabula.Containers;
using WF_Tabula.Models;

namespace UserUnitTest
{
    [TestClass]
    public class UserContainerUnitTest
    {
        [TestMethod]
        public void TestUsernameExist()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);
            userContainerStubs.existReturnValue = true;

            bool result = userContainer.UsernameExists("");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUsernameDoesntExist()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);
            userContainerStubs.existReturnValue = false;

            bool result = userContainer.UsernameExists("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            Random random = new Random();

            userContainerStubs.existReturnValue = true;
            Assert.AreEqual(userContainer.CreateUser(new User(), new string[2]), userContainerStubs.value);
        }

        [TestMethod]
        public void TestUsernameEmailExist()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = true;

            bool result = userContainer.UsernameEmailExists("");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUsernameEmailDoesntExist()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = false;

            bool result = userContainer.UsernameEmailExists("");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestCheckPassword()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = true;

            bool result = userContainer.IsValidLogin("", "");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestCheckPasswordFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = false;

            bool result = userContainer.IsValidLogin("", "");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestGetUserDetails()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = false;

            DataTable result = userContainer.GetUserDetails("");

            Assert.IsNotNull(result);
        }
    }
}