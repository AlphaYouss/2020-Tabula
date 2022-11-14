using System.Collections.Generic;
using WF_Tabula.Models;

namespace WF_Tabula.Interfaces
{
   public interface IBoard
    {
        void CreatePersonalBoard(int userID);
        List<Board> GetBoards(int userID);
    }
}