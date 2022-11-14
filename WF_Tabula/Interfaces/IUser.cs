using System.Data;
using WF_Tabula.Models;

namespace WF_Tabula.Interfaces
{
    public interface IUser
    {
        bool UsernameExists(string username);
        bool EmailExists(string email);
        int CreateUser(User user, string[] passwordData);
        bool UsernameEmailExists(string usernameEmail);
        bool IsValidLogin(string usernameEmail, string password);
        DataTable GetUserDetails(string usernameEmail);
    }
}