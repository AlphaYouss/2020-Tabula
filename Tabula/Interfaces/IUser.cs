using System.Data;
using ASP_Tabula.Models;

namespace ASP_Tabula.Interfaces
{
    public interface IUser
    {
        // User methods

        bool UsernameExists(string username);
        bool EmailExists(string email);
        int CreateUser(User user, string[] passwordData);
        bool UsernameEmailExists(string usernameEmail);
        bool IsValidLoginCredentials(string usernameEmail, string password);
        void EditPassword(int userID, string[] passwordData);
        void EditEmail(int userID, string email);
        DataTable GetUserDetails(string usernameEmail);
    }
}