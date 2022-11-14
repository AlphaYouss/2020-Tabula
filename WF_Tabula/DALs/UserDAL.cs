using System;
using System.Data;
using System.Data.SqlClient;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;
using WF_Tabula.Tools;

namespace WF_Tabula.DALs
{
    public class UserDAL : Databasehandler, IUser
    {
        private SqlCommand command { get; set; }
        private DataTable table { get; set; }
        private Passwordhandler passwordhandler { get; set; }

        public UserDAL()
        {
            passwordhandler = new Passwordhandler();
        }

        public bool UsernameExists(string username)
        {
            command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username", GetCon());
            command.Parameters.AddWithValue("Username", username);

            OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            CloseConnectionToDB();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EmailExists(string email)
        {
            command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email = @Email", GetCon());
            command.Parameters.AddWithValue("Email", email);

            OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            CloseConnectionToDB();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CreateUser(User user, string[] passwordData)
        {
            command = new SqlCommand("INSERT INTO [User] VALUES(@Username, @First_name, @Last_name, @Email, @Date_of_birth, @Password, @Salt, @Created_at); SELECT SCOPE_IDENTITY();", GetCon());
            command.Parameters.AddWithValue("Username", user.username);
            command.Parameters.AddWithValue("First_name", user.firstname);
            command.Parameters.AddWithValue("Last_name", user.lastname);
            command.Parameters.AddWithValue("Email", user.email);
            command.Parameters.AddWithValue("Date_of_birth", user.dateOfBirth);
            command.Parameters.AddWithValue("Password", passwordData[0]);
            command.Parameters.AddWithValue("Salt", passwordData[1]);
            command.Parameters.AddWithValue("Created_at", user.createdAt);

            OpenConnectionToDB();
            int userID = Convert.ToInt32(command.ExecuteScalar());
            CloseConnectionToDB();

            return userID;
        }

        public bool UsernameEmailExists(string usernameEmail)
        {
            command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email", GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            CloseConnectionToDB();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsValidLogin(string usernameEmail, string password)
        {
            string[] passwordData = new string[2];

            passwordData[0] = GetPassword(usernameEmail);
            passwordData[1] = GetSalt(usernameEmail);

            if (passwordhandler.VerifyPassword(passwordData[1], password, passwordData[0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetPassword(string usernameEmail)
        {
            command = new SqlCommand("SELECT Password FROM [User] WHERE Username = @Username OR Email = @Email", GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            OpenConnectionToDB();
            string password = Convert.ToString(command.ExecuteScalar());
            CloseConnectionToDB();

            return password;
        }

        public string GetSalt(string usernameEmail)
        {
            command = new SqlCommand("SELECT Salt FROM [User] WHERE Username = @Username OR Email = @Email", GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            OpenConnectionToDB();
            string salt = Convert.ToString(command.ExecuteScalar());
            CloseConnectionToDB();

            return salt;
        }

        public DataTable GetUserDetails(string usernameEmail)
        {
            table = new DataTable();

            command = new SqlCommand("SELECT ID, First_name, Last_name, Username, Email, Date_of_birth, Created_at FROM [User] WHERE Username = @Username OR Email = @Email", GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            CloseConnectionToDB();

            return table;
        }
    }
}