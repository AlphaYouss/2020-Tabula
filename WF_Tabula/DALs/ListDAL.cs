using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.DALs
{
    public class ListDAL : Databasehandler, IList
    {
        private SqlCommand command { get; set; }
        private DataTable table { get; set; }

        public List<List> GetLists(int boardID)
        {
            table = new DataTable();

            command = new SqlCommand("SELECT * FROM [List] WHERE Board_ID = @Board_ID", GetCon());
            command.Parameters.AddWithValue("Board_ID", boardID);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            CloseConnectionToDB();

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

        public void CreateList(int boardID, int orderID, string name, DateTime createdAT)
        {
            command = new SqlCommand("INSERT INTO [List] VALUES(@Board_ID, @Order_ID, @Name, @Created_at, @Updated_at)", GetCon());
            command.Parameters.AddWithValue("Board_ID", boardID);
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Created_at", createdAT);
            command.Parameters.AddWithValue("Updated_at", DBNull.Value);

            OpenConnectionToDB();
            command.ExecuteScalar();
            CloseConnectionToDB();
        }

        public void EditList(int listID, int orderID, string name, DateTime updatedAT)
        {
            command = new SqlCommand("UPDATE [List] SET Order_ID = @Order_ID, Name = @Name, Updated_AT = @Updated_AT WHERE ID = @List_ID", GetCon());
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Updated_AT", updatedAT);
            command.Parameters.AddWithValue("List_ID", listID);

            OpenConnectionToDB();
            command.ExecuteNonQuery();
            CloseConnectionToDB();
        }

        public void DeleteList(int listID)
        {
            command = new SqlCommand("DELETE FROM [List] WHERE ID = @List_ID", GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            OpenConnectionToDB();
            command.ExecuteScalar();
            CloseConnectionToDB();
        }
    }
}