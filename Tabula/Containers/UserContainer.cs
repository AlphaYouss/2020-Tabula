using System.Data;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.Containers
{
    public class UserContainer
    {
        // User methods based on the dal

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

        public bool IsValidLoginCredentials(string usernameEmail, string password)
        {
            return userDAL.IsValidLoginCredentials(usernameEmail, password);
        }

        public DataTable GetUserDetails(string usernameEmail)
        {
            return userDAL.GetUserDetails(usernameEmail);
        }

        public void EditPassword(int userID, string[] passwordData)
        {
            userDAL.EditPassword(userID, passwordData);
        }

        public void EditEmail(int userID, string email)
        {
            userDAL.EditEmail(userID, email);
        }
    }
}