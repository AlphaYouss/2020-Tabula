using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.DALs
{
    public class CardDAL : Databasehandler, ICard
    {
        private SqlCommand command { get; set; }
        private DataTable table { get; set; }

        public List<Card> GetCards(int listID)
        {
            table = new DataTable();

            command = new SqlCommand("SELECT * FROM [Card] WHERE List_ID = @List_ID", GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            CloseConnectionToDB();

            List<Card> cards = new List<Card>();
            Card card;

            foreach (DataRow row in table.Rows)
            {
                card = new Card();

                card.id = Convert.ToInt32(row["ID"]);
                card.orderID = Convert.ToInt32(row["Order_ID"]);
                card.name = row["Name"].ToString();
                card.description = row["Description"].ToString();

                if (row["Deadline"] != DBNull.Value)
                {
                    card.deadline = Convert.ToDateTime(row["Deadline"]);
                }

                string priority = row["Priority"].ToString();

                switch (priority)
                {
                    case "Critical":
                        card.priority = Card.Priorities.Critical;
                        break;
                    case "Important":
                        card.priority = Card.Priorities.Important;
                        break;
                    case "Normal":
                        card.priority = Card.Priorities.Normal;
                        break;
                    case "Low":
                        card.priority = Card.Priorities.Low;
                        break;
                    case "None":
                        card.priority = Card.Priorities.None;
                        break;
                }
                card.createdAt = Convert.ToDateTime(row["Created_at"]);

                if (row["Updated_at"] != DBNull.Value)
                {
                    card.updatedAt = Convert.ToDateTime(row["Updated_at"]);
                }

                cards.Add(card);
            }
            return cards;
        }

        public void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt)
        {
            command = new SqlCommand("INSERT INTO [Card] VALUES(@List_ID, @Order_ID, @Name, @Description, @Priority, @Deadline, @Created_at, @Updated_at)", GetCon());
            command.Parameters.AddWithValue("List_ID", listID);
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("Priority", priority);

            if (deadline == null)
            {
                command.Parameters.AddWithValue("Deadline", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Deadline", deadline);
            }

            command.Parameters.AddWithValue("Created_at", createdAt);
            command.Parameters.AddWithValue("Updated_at", DBNull.Value);

            OpenConnectionToDB();
            command.ExecuteScalar();
            CloseConnectionToDB();
        }

        public void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT)
        {
            command = new SqlCommand("UPDATE [Card] SET Order_ID = @Order_ID, Name = @Name, Description = @Description, Priority = @Priority, Deadline = @Deadline, Updated_AT = @Updated_AT WHERE ID = @cardID", GetCon());
            command.Parameters.AddWithValue("cardID", cardID);
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Name", name);
            command.Parameters.AddWithValue("Description", description);
            command.Parameters.AddWithValue("Priority", priority);

            if (deadline == null)
            {
                command.Parameters.AddWithValue("Deadline", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Deadline", deadline);
            }

            command.Parameters.AddWithValue("Updated_AT", updatedAT);

            OpenConnectionToDB();
            command.ExecuteNonQuery();
            CloseConnectionToDB();
        }

        public void DeleteCard(int cardID)
        {
            command = new SqlCommand("DELETE FROM [Card] WHERE ID = @Card_ID", GetCon());
            command.Parameters.AddWithValue("Card_ID", cardID);

            OpenConnectionToDB();
            command.ExecuteScalar();
            CloseConnectionToDB();
        }

        public void DeleteCards(int list_ID)
        {
            command = new SqlCommand("DELETE FROM [Card] WHERE List_ID = @List_ID", GetCon());
            command.Parameters.AddWithValue("List_ID", list_ID);

            OpenConnectionToDB();
            command.ExecuteScalar();
            CloseConnectionToDB();
        }
    }
}