using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.DALs
{
    public class BoardDAL : Databasehandler , IBoard
    {
        private SqlCommand command { get; set; }
        private DataTable table { get; set; }

        public void CreatePersonalBoard(int userID)
        {
            command = new SqlCommand("INSERT INTO [Board] VALUES(@Owner_ID, @Name, @Type, @Created_at)", GetCon());
            command.Parameters.AddWithValue("Owner_ID", userID);
            command.Parameters.AddWithValue("Name", Board.types.Personal.ToString());
            command.Parameters.AddWithValue("Type", "Personal");
            command.Parameters.AddWithValue("Created_at", DateTime.Now);

            OpenConnectionToDB();
            command.ExecuteReader();

            CloseConnectionToDB();
        }

        public List<Board> GetBoards(int userID)
        {
            table = new DataTable();

            command = new SqlCommand("SELECT * FROM [Board] WHERE Owner_ID = @Owner_ID", GetCon());
            command.Parameters.AddWithValue("Owner_ID", userID);

            OpenConnectionToDB();

            SqlDataAdapter adapt = new SqlDataAdapter(command);
            adapt.Fill(table);

            CloseConnectionToDB();

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
    }
}