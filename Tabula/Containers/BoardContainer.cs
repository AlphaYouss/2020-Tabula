using System.Collections.Generic;
using ASP_Tabula.Models;
using ASP_Tabula.Interfaces;

namespace ASP_Tabula.Containers
{
    public class BoardContainer
    {   
        // Board methods based on the dal

        IBoard boardDAL;

        public BoardContainer(IBoard boardDAL)
        {
            this.boardDAL = boardDAL;
        }

        public void CreatePersonalBoard(int userID)
        {
            boardDAL.CreatePersonalBoard(userID);
        }

        public Board GetBoard(int boardID)
        {
            return boardDAL.GetBoard(boardID);
        }

        public List<Board> GetBoards(int userID)
        {      
            return boardDAL.GetBoards(userID);
        }

        public bool HasAccessToBoard(int userID, int BoardID)
        {
            return boardDAL.HasAccessToBoard(userID, BoardID);
        }
    }
}