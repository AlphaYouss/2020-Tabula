using System.Collections.Generic;
using ASP_Tabula.Models;

namespace ASP_Tabula.Interfaces
{
   public interface IBoard
    {
        // Board methods

        void CreatePersonalBoard(int userID);
        bool HasAccessToBoard(int userID, int boardID);
        Board GetBoard(int boardID);
        List<Board> GetBoards(int userID);
    }
}