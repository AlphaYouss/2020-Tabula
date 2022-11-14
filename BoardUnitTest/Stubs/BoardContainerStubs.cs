using System;
using System.Collections.Generic;
using WF_Tabula.Interfaces;
using WF_Tabula.Models;

namespace BoardUnitTest.Stubs
{
    class BoardContainerStubs : IBoard
    {
        public List<Board> boards = new List<Board>();

        public bool? existReturnValue = null;

        public void CreatePersonalBoard(int userID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            Board newBoard = new Board();
            newBoard.type = Board.types.Project;

            boards.Add(newBoard);
        }

        public List<Board> GetBoards(int userID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue");
            }

            return boards;
        }
    }
}