using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.DALs
{
    public class CardDAL : ICard
    {
        private Databasehandler databasehandler { get; set; }

        private SqlCommand command { get; set; }
        private DataTable table { get; set; }


        public CardDAL(IConfiguration config)
        {
            // Set database and tests connection

            databasehandler = new Databasehandler(config);
            databasehandler.TestConnection();
        }


        public void CreateCard(int listID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime createdAt)
        {
            // Create card

            command = new SqlCommand("INSERT INTO [Card] VALUES(@List_ID, @Order_ID, @Name, @Description, @Priority, @Deadline, @Created_at, @Updated_at)", databasehandler.GetCon());
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

            databasehandler.OpenConnectionToDB();
            command.ExecuteScalar();
            databasehandler.CloseConnectionToDB();
        }


        public void DeleteCard(int cardID)
        {
            // Delete card

            command = new SqlCommand("DELETE FROM [Card] WHERE ID = @Card_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Card_ID", cardID);

            databasehandler.OpenConnectionToDB();
            command.ExecuteScalar();
            databasehandler.CloseConnectionToDB();
        }


        public void DeleteCards(int listID)
        {
            // Delete all cards

            command = new SqlCommand("DELETE FROM [Card] WHERE List_ID = @List_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();
            command.ExecuteScalar();
            databasehandler.CloseConnectionToDB();
        }


        public void EditCard(int cardID, int orderID, string name, string description, string priority, DateTime? deadline, DateTime updatedAT)
        {
            // Edit card

            command = new SqlCommand("UPDATE [Card] SET Order_ID = @Order_ID, Name = @Name, Description = @Description, Priority = @Priority, Deadline = @Deadline, Updated_AT = @Updated_AT WHERE ID = @cardID", databasehandler.GetCon());
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

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();
        }


        public void EditCard(int cardID, int listID, int orderID, DateTime updatedAT)
        {
            // Edit card (reorder)

            command = new SqlCommand("UPDATE [Card] SET Order_ID = @Order_ID, List_ID = @List_ID, Updated_AT = @Updated_AT WHERE ID = @cardID", databasehandler.GetCon());
            command.Parameters.AddWithValue("cardID", cardID);
            command.Parameters.AddWithValue("List_ID", listID);
            command.Parameters.AddWithValue("Order_ID", orderID);
            command.Parameters.AddWithValue("Updated_AT", updatedAT);

            databasehandler.OpenConnectionToDB();
            command.ExecuteNonQuery();
            databasehandler.CloseConnectionToDB();
        }


        public List<Card> GetCards(int listID)
        {
            // Get all cards

            table = new DataTable();

            command = new SqlCommand("SELECT * FROM [Card] WHERE List_ID = @List_ID ORDER BY Order_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            databasehandler.CloseConnectionToDB();

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


        public Card GetCard(int cardID)
        {
            // Get a specific card

            command = new SqlCommand("SELECT * FROM [Card] WHERE ID = @Card_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Card_ID", cardID);

            databasehandler.OpenConnectionToDB();

            SqlDataReader dataReader = command.ExecuteReader();

            Card card = new Card();

            while (dataReader.Read())
            {
                card.id = Convert.ToInt32(dataReader["ID"]);
                card.orderID = Convert.ToInt32(dataReader["Order_ID"]);
                card.name = Convert.ToString(dataReader["Name"]);
                card.description = Convert.ToString(dataReader["Description"]);

                if (dataReader["Deadline"] != DBNull.Value)
                {
                    card.deadline = Convert.ToDateTime(dataReader["Deadline"]);
                }

                string priority = dataReader["Priority"].ToString();

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

                card.createdAt = Convert.ToDateTime(dataReader["Created_at"]);

                if (dataReader["Updated_at"] != DBNull.Value)
                {
                    card.updatedAt = Convert.ToDateTime(dataReader["Updated_at"]);
                }
            }

            dataReader.Close();
            databasehandler.CloseConnectionToDB();

            return card;
        }


        public int CountCards(int listID)
        {
            // Count cards in list

            command = new SqlCommand("SELECT COUNT(*) FROM [Card] WHERE List_ID = @List_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("List_ID", listID);

            databasehandler.OpenConnectionToDB();
            int count = Convert.ToInt32(command.ExecuteScalar());
            databasehandler.CloseConnectionToDB();

            return count;
        }


        public bool HasAccessToCard(int userID, int listID, int cardID)
        {
            // Check if user has access to the card

            command = new SqlCommand("SELECT COUNT([Card].Name) FROM [Card] INNER JOIN [List] ON [Card].List_ID = [List].ID INNER JOIN [Board] ON [List].Board_ID = [Board].ID WHERE Owner_ID = @userID AND [Card].ID = @cardID AND [List].ID = @listID", databasehandler.GetCon());
            command.Parameters.AddWithValue("userID", userID);
            command.Parameters.AddWithValue("cardID", cardID);
            command.Parameters.AddWithValue("listID", listID);

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