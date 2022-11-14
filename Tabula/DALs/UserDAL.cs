using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.Tools;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.DALs
{
    public class UserDAL : IUser
    {
        private Databasehandler databasehandler { get; set; }

        private SqlCommand command { get; set; }
        private DataTable table { get; set; }

        private Passwordhandler passwordhandler { get; set; }


        public UserDAL(IConfiguration config)
        {
            // Set database and tests connection

            databasehandler = new Databasehandler(config);
            databasehandler.TestConnection();

            passwordhandler = new Passwordhandler();
        }


        public bool UsernameExists(string username)
        {
            // Check if username exists 

            command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username", databasehandler.GetCon());
            command.Parameters.AddWithValue("Username", username);

            databasehandler.OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

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
            // Check if email exists

            command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Email = @Email", databasehandler.GetCon());
            command.Parameters.AddWithValue("Email", email);

            databasehandler.OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

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
            // Create user and return userID

            command = new SqlCommand("INSERT INTO [User] VALUES(@Username, @First_name, @Last_name, @Email, @Date_of_birth, @Password, @Salt, @Created_at); SELECT SCOPE_IDENTITY();", databasehandler.GetCon());
            command.Parameters.AddWithValue("Username", user.username);
            command.Parameters.AddWithValue("First_name", user.firstname);
            command.Parameters.AddWithValue("Last_name", user.lastname);
            command.Parameters.AddWithValue("Email", user.email);
            command.Parameters.AddWithValue("Date_of_birth", user.dateOfBirth);
            command.Parameters.AddWithValue("Password", passwordData[0]);
            command.Parameters.AddWithValue("Salt", passwordData[1]);
            command.Parameters.AddWithValue("Created_at", user.createdAt);

            databasehandler.OpenConnectionToDB();
            int userID = Convert.ToInt32(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            return userID;
        }


        public bool UsernameEmailExists(string usernameEmail)
        {
            // Check if username or email exists

            command = new SqlCommand("SELECT COUNT(*) FROM [User] WHERE Username = @Username OR Email = @Email", databasehandler.GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            databasehandler.OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool IsValidLoginCredentials(string usernameEmail, string password)
        {
            // Check if valid login credentials

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


        private string GetPassword(string usernameEmail)
        {
            // Get password hash

            command = new SqlCommand("SELECT Password FROM [User] WHERE Username = @Username OR Email = @Email", databasehandler.GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            databasehandler.OpenConnectionToDB();
            string password = Convert.ToString(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            return password;
        }


        private string GetSalt(string usernameEmail)
        {
            // Get password salt

            command = new SqlCommand("SELECT Salt FROM [User] WHERE Username = @Username OR Email = @Email", databasehandler.GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            databasehandler.OpenConnectionToDB();
            string salt = Convert.ToString(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            return salt;
        }


        public DataTable GetUserDetails(string usernameEmail)
        {
            // Get Userdetails

            table = new DataTable();

            command = new SqlCommand("SELECT ID, First_name, Last_name, Username, Email, Date_of_birth, Created_at FROM [User] WHERE Username = @Username OR Email = @Email", databasehandler.GetCon());
            command.Parameters.AddWithValue("Username", usernameEmail);
            command.Parameters.AddWithValue("Email", usernameEmail);

            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            databasehandler.CloseConnectionToDB();

            return table;
        }


        public void EditPassword(int userID, string[] passwordData)
        {
            // Update password and salt

            command = new SqlCommand("UPDATE [User] SET Password = @Password, Salt = @Salt WHERE ID = @userID", databasehandler.GetCon());
            command.Parameters.AddWithValue("userID", userID);
            command.Parameters.AddWithValue("Password", passwordData[0]);
            command.Parameters.AddWithValue("Salt", passwordData[1]);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();
        }


        public void EditEmail(int userID, string email)
        {
            // Update email

            command = new SqlCommand("UPDATE [User] SET Email = @Email WHERE ID = @userID", databasehandler.GetCon());
            command.Parameters.AddWithValue("userID", userID);
            command.Parameters.AddWithValue("Email", email);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();
        }
    }
}