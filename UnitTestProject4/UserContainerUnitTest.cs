using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using UserUnitTest.Stubs;
using ASP_Tabula.Containers;
using ASP_Tabula.Models;

namespace UserUnitTest
{
    [TestClass]
    public class UserContainerUnitTest
    {
        // Username

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
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existReturnValue.")]
        public void TestUsernameExistFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            bool result = userContainer.UsernameExists("");

            Assert.IsTrue(result);
        }

        // Email

        [TestMethod]
        public void TestEmailExist()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);
            userContainerStubs.existReturnValue = true;

            bool result = userContainer.EmailExists("");

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestEmailDoesntExist()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);
            userContainerStubs.existReturnValue = false;

            bool result = userContainer.EmailExists("");

            Assert.IsFalse(result);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existReturnValue.")]
        public void TestEmailExistFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            bool result = userContainer.EmailExists("");

            Assert.IsTrue(result);
        }

        // Create user

        [TestMethod]
        public void TestCreateUser()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);
            userContainerStubs.numberReturnValue = 1;

            userContainerStubs.existReturnValue = true;
            Assert.AreEqual(userContainer.CreateUser(new User(), new string[2]), userContainerStubs.numberReturnValue);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field numberReturnValue.")]
        public void TestCreateUserFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = true;
            Assert.AreEqual(userContainer.CreateUser(new User(), new string[2]), 0);
        }


        [TestMethod]
        public void TestCreateUserFailed2()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);
            userContainerStubs.numberReturnValue = 1;

            userContainerStubs.existReturnValue = true;
            Assert.AreNotEqual(userContainer.CreateUser(new User(), new string[2]), 0);
        }

        // Username email

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
        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existReturnValue.")]
        public void TestUsernameEmailExistFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            bool result = userContainer.UsernameEmailExists("");
            Assert.IsTrue(result);
        }

        // Userdetails

        [TestMethod]
        public void TestGetUserDetails()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = false;

            DataTable result = userContainer.GetUserDetails("");

            Assert.IsNotNull(result);
        }


        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existReturnValue.")]
        [TestMethod]
        public void TestGetUserDetailsFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            DataTable result = userContainer.GetUserDetails("");

            Assert.IsNotNull(result);
        }

        // Is valid login credentials

        [TestMethod]
        public void TestCheckPassword()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = true;

            bool result = userContainer.IsValidLoginCredentials("", "");

            Assert.IsTrue(result);
        }


        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field existReturnValue.")]
        [TestMethod]
        public void TestCheckPasswordFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            bool result = userContainer.IsValidLoginCredentials("", "");

            Assert.IsTrue(result);
        }


        [TestMethod]
        public void TestCheckPasswordFailed2()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.existReturnValue = false;

            bool result = userContainer.IsValidLoginCredentials("", "");

            Assert.IsFalse(result);
        }

        // Edit password

        [TestMethod]
        public void TestEditPassword()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.stringReturnValue = "yes";

            userContainer.EditPassword(0, new string[2]);

            Assert.AreEqual(userContainerStubs.stringReturnValue, "password");
        }


        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field stringReturnValue.")]
        [TestMethod]
        public void TestEditPasswordFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainer.EditPassword(0, new string[2]);

            Assert.AreEqual(userContainerStubs.stringReturnValue, "password");
        }


        [TestMethod]
        public void TestEditPasswordFailed2()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.stringReturnValue = "yes";

            userContainer.EditPassword(0, new string[2]);

            Assert.AreNotEqual(userContainerStubs.stringReturnValue, "passwordd");
        }

        // Edit email

        [TestMethod]
        public void TestEditEmail()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.stringReturnValue = "yes";

            userContainer.EditEmail(0, "");

            Assert.AreEqual(userContainerStubs.stringReturnValue, "email");
        }


        [ExpectedException(typeof(NullReferenceException),
"Invalid use of stub code. First set field stringReturnValue.")]
        [TestMethod]
        public void TestEditEmailFailed()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainer.EditEmail(0, "");

            Assert.AreEqual(userContainerStubs.stringReturnValue, "email");
        }


        [TestMethod]
        public void TestEditEmailFailed2()
        {
            UserContainerStubs userContainerStubs = new UserContainerStubs();
            UserContainer userContainer = new UserContainer(userContainerStubs);

            userContainerStubs.stringReturnValue = "yes";

            userContainer.EditEmail(0, "");

            Assert.AreNotEqual(userContainerStubs.stringReturnValue, "emaill");
        }
    }
}
