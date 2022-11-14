using System;
using System.Data;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace UserUnitTest.Stubs
{
    class UserContainerStubs : IUser
    {
        public bool? existReturnValue = null;
        public int value;

        public bool UsernameExists(string username)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
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
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            Random rnd = new Random();
            value = rnd.Next(0, 10000);

            return value;
        }

        public bool UsernameEmailExists(string usernameEmail)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            return existReturnValue.Value;
        }

        public bool IsValidLogin(string usernameEmail, string password)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            return existReturnValue.Value;
        }

        public DataTable GetUserDetails(string usernameEmail)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            return new DataTable();
        }
    }
}