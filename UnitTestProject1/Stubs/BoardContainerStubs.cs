using System;
using System.Collections.Generic;
using ASP_Tabula.Interfaces;
using ASP_Tabula.Models;

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
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            Board newBoard = new Board();
            newBoard.type = Board.types.Project;
            newBoard.id = 1;

            boards.Add(newBoard);
        }


        public Board GetBoard(int boardID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }

            Board board = new Board();

            for (int i = 0; i < boards.Count; i++)
            {
                if (boards[i].id == boardID)
                {
                    board = boards[i];
                }
            }
            return board;
        }


        public List<Board> GetBoards(int userID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return boards;
        }


        public bool HasAccessToBoard(int userID, int boardID)
        {
            if (existReturnValue == null)
            {
                throw new NullReferenceException("Invalid use of stub code. First set field existsReturnValue.");
            }
            return existReturnValue.Value;
        }
    }
}