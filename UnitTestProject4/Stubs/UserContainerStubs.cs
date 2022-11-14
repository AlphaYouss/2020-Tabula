using System;
using System.Data;
using ASP_Tabula.Interfaces;
using ASP_Tabula.Models;

namespace UserUnitTest.Stubs
{
    class UserContainerStubs : IUser
    {
        public bool? existReturnValue = null;
        public int? numberReturnValue = null;
        public string stringReturnValue = null;


        public bool UsernameExists(string username)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return existReturnValue.Value;
        }


        public bool EmailExists(string email)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }
            return existReturnValue.Value;
        }


        public int CreateUser(User user, string[] passwordData)
        {
            if (numberReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field numberReturnValue.");
            }
            return numberReturnValue.Value;
        }


        public bool UsernameEmailExists(string usernameEmail)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return existReturnValue.Value;
        }


        public DataTable GetUserDetails(string usernameEmail)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return new DataTable();
        }


        public bool IsValidLoginCredentials(string usernameEmail, string password)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return existReturnValue.Value;
        }


        public void EditPassword(int userID, string[] passwordData)
        {
            if (stringReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field stringReturnValue.");
            }
            stringReturnValue = "password";
        }


        public void EditEmail(int userID, string email)
        {
            if (stringReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field stringReturnValue.");
            }
            stringReturnValue = "email";
        }
    }
}