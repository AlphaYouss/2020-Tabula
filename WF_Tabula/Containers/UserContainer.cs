using System.Data;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.Containers
{
    public class UserContainer
    {
        IUser userDAL;

        public UserContainer(IUser userDAL)
        {
            this.userDAL = userDAL;
        }

        public bool UsernameExists(string username)
        {
            return userDAL.UsernameExists(username);
        }

        public bool EmailExists(string email)
        {        
            return userDAL.EmailExists(email);
        }

        public int CreateUser(User user, string[] passwordData)
        {
            return userDAL.CreateUser(user, passwordData);
        }

        public bool UsernameEmailExists(string usernameEmail)
        {
            return userDAL.UsernameEmailExists(usernameEmail);
        }

        public bool IsValidLogin(string usernameEmail, string password)
        {
            return userDAL.IsValidLogin(usernameEmail, password);
        }

        public DataTable GetUserDetails(string usernameEmail)
        {
            return userDAL.GetUserDetails(usernameEmail);
        }
    }
}