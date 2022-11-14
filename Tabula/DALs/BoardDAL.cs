using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.DALs
{
    public class BoardDAL: IBoard
    {
        private Databasehandler databasehandler { get; set; }

        private SqlCommand command { get; set; }
        private DataTable table { get; set; }


        public BoardDAL(IConfiguration config)
        {
            // Set database and tests connection

            databasehandler = new Databasehandler(config);
            databasehandler.TestConnection();
        }


        public void CreatePersonalBoard(int userID)
        {
            // Create personal board

            command = new SqlCommand("INSERT INTO [Board] VALUES(@Owner_ID, @Name, @Type, @Created_at)", databasehandler.GetCon());
            command.Parameters.AddWithValue("Owner_ID", userID);
            command.Parameters.AddWithValue("Name", Board.types.Personal.ToString());
            command.Parameters.AddWithValue("Type", "Personal");
            command.Parameters.AddWithValue("Created_at", DateTime.Now);

            databasehandler.OpenConnectionToDB();
            command.ExecuteReader();

            databasehandler.CloseConnectionToDB();
        }


        public List<Board> GetBoards(int userID)
        {
            // Get all boards

            table = new DataTable();

            command = new SqlCommand("SELECT * FROM [Board] WHERE Owner_ID = @Owner_ID", databasehandler.GetCon());
            command.Parameters.AddWithValue("Owner_ID", userID);

            databasehandler.OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            databasehandler.CloseConnectionToDB();

            List<Board> boards = new List<Board>();
            Board board;

            foreach (DataRow row in table.Rows)
            {
                board = new Board();

                board.id = Convert.ToInt32(row["ID"]);
                board.name = row["Name"].ToString();

                switch (row["Type"])
                {
                    case Board.types.Personal:
                        board.type = Board.types.Personal;
                        break;
                    case Board.types.Project:
                        board.type = Board.types.Project;
                        break;
                }

                board.createdAt = Convert.ToDateTime(row["Created_at"]);

                boards.Add(board);
            }
            return boards;
        }


        public Board GetBoard(int boardID)
        {
            // Get specific board

            command = new SqlCommand("SELECT * FROM [Board] WHERE ID = @boardID", databasehandler.GetCon());
            command.Parameters.AddWithValue("boardID", boardID);

            databasehandler.OpenConnectionToDB();

            SqlDataReader dataReader = command.ExecuteReader();

            Board board = new Board();

            while (dataReader.Read())
            {
                board.id = Convert.ToInt32(dataReader["ID"]);
                board.name = Convert.ToString(dataReader["Name"]);

                if (Convert.ToString(dataReader["Type"]) == "Personal")
                {
                    board.type = Board.types.Personal;
                }
                else
                {
                    board.type = Board.types.Project;
                }

                board.createdAt = Convert.ToDateTime(dataReader["Created_at"]);
            }

            dataReader.Close();
            databasehandler.CloseConnectionToDB();

            return board;
        }


        public bool HasAccessToBoard(int userID, int boardID)
        {
            // Check if user has acces to the board

            command = new SqlCommand("SELECT COUNT([Board].Name) FROM [Board] WHERE ID = @boardID AND Owner_ID = @userID", databasehandler.GetCon());
            command.Parameters.AddWithValue("boardID", boardID);
            command.Parameters.AddWithValue("userID", userID);

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