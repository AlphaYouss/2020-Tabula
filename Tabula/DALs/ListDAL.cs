using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.DALs
{
    public class ListDAL : IList
    {
        private Databasehandler databasehandler { get; set; }

        private SqlCommand command { get; set; }
        private DataTable table { get; set; }


        public ListDAL(IConfiguration config)
        {
            // Set database and tests connection

            databasehandler = new Databasehandler(config);
            databasehandler.TestConnection();
        }


        public void CreateList(int boardID, int orderID, string name, DateTime createdAT)
        {
            // Create list

            command = new SqlCommand("INSERT INTO [List] VALUES(@Board_ID, @Order_ID, @Name, @Created_at, @Updated_at)", databasehandler.GetCon());
            command.Parameters.AddWithValue("Board_ID", boardID);
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Created_at", createdAT);
            command.Parameters.AddWithValue("Updated_at", DBNull.Value);

            databasehandler.OpenConnectionToDB();
            command.ExecuteScalar();
            databasehandler.CloseConnectionToDB();
        }


        public void DeleteList(int listID)
        {
            // Delete list

            command = new SqlCommand("DELETE FROM [List] WHERE ID = @List_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();
            command.ExecuteScalar();
            databasehandler.CloseConnectionToDB();
        }


        public void EditList(int listID, int orderID, string name, DateTime updatedAT)
        {
            // Update list

            command = new SqlCommand("UPDATE [List] SET Order_ID = @Order_ID, Name = @Name, Updated_AT = @Updated_AT WHERE ID = @List_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Updated_AT", updatedAT);
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();
        }


        public void EditList(int listID, int orderID, DateTime updatedAT)
        {
            // Update list

            command = new SqlCommand("UPDATE [List] SET Order_ID = @Order_ID, Updated_AT = @Updated_AT WHERE ID = @List_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Updated_AT", updatedAT);
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();
        }


        public List<List> GetLists(int boardID)
        {
            // Get all lists

            table = new DataTable();

            command = new SqlCommand("SELECT * FROM [List] WHERE Board_ID = @Board_ID ORDER BY Order_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Board_ID", boardID);

            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            databasehandler.CloseConnectionToDB();

            List<List> lists = new List<List>();
            List list;

            foreach (DataRow row in table.Rows)
            {
                list = new List();

                list.id = Convert.ToInt32(row["ID"]);
                list.orderID = Convert.ToInt32(row["Order_ID"]);
                list.name = row["Name"].ToString();
                list.createdAt = Convert.ToDateTime(row["Created_at"]);

                if (row["Updated_at"] != DBNull.Value)
                {
                    list.updatedAt = Convert.ToDateTime(row["Updated_at"]);
                }

                lists.Add(list);
            }
            return lists;
        }


        public List GetList(int listID)
        {
            // Get a specific list

            command = new SqlCommand("SELECT * FROM [List] WHERE ID = @List_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();

            SqlDataReader dataReader = command.ExecuteReader();

            List list = new List();

            while (dataReader.Read())
            {
                list.id = Convert.ToInt32(dataReader["ID"]);
                list.orderID = Convert.ToInt32(dataReader["Order_ID"]);
                list.name = Convert.ToString(dataReader["Name"]);
                list.createdAt = Convert.ToDateTime(dataReader["Created_at"]);

                if (dataReader["Updated_at"] != DBNull.Value)
                {
                    list.updatedAt = Convert.ToDateTime(dataReader["Updated_at"]);
                }
            }

            dataReader.Close();
            databasehandler.CloseConnectionToDB();

            return list;
        }


        public int CountLists(int boardID)
        {
            // Count lists in board

            command = new SqlCommand("SELECT COUNT(*) FROM [List] WHERE Board_ID = @Board_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Board_ID", boardID);

            databasehandler.OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            return count;
        }


        public bool HasAccessToList(int userID, int listID)
        {
            // Check if user has access to the list

            command = new SqlCommand("SELECT COUNT([List].Name) FROM [List] INNER JOIN [Board] ON [List].Board_ID = [Board].ID WHERE Owner_ID = @userID AND [List].ID = @ListID", databasehandler.GetCon());
            command.Parameters.AddWithValue("userID", userID);
            command.Parameters.AddWithValue("ListID", listID);

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
    }
}