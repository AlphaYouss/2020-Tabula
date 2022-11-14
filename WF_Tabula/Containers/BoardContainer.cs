using System.Collections.Generic;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace WF_Tabula.Containers
{
    public class BoardContainer
    {
        IBoard boardDAL;

        public BoardContainer(IBoard boardDAL)
        {
            this.boardDAL = boardDAL;
        }

        public void CreatePersonalBoard(int userID)
        {
            boardDAL.CreatePersonalBoard(userID);
        }

        public List<Board> GetBoards(int userID)
        {      
            return boardDAL.GetBoards(userID);
        }
    }
}