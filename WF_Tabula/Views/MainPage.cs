using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WF_Tabula.Models;

namespace WF_Tabula.Views
{
    public partial class MainPage : Form
    {
        private User user { get; set; }
        private List<Board> projectBoards { get; set; }
        private Board personalBoard { get; set; }

        public MainPage(User user)
        {
            InitializeComponent();

            this.user = user;

            lblMessage.Text = "Welcome " + user.username + "!";

            projectBoards = new List<Board>();
            personalBoard = new Board();

            foreach (Board board in user.boards)
            {
                if (board.type == Board.types.Personal)
                {
                    personalBoard = board;
                }
                else if (board.type == Board.types.Project)
                {
                    projectBoards.Add(board);
                }
            }
        }

        private void TSMIPersonalboard_Click(object sender, EventArgs e)
        {

        }

        private void TSMIProjectboards_Click(object sender, EventArgs e)
        {

        }

        private void TSMISettings_Click(object sender, EventArgs e)
        {

        }

        private void TSMILogout_Click(object sender, EventArgs e)
        {
            Hide();

            LoginPage Login = new LoginPage();
            Login.ShowDialog();

            Close();
        }

        private void btnPersonalBoard_Click(object sender, EventArgs e)
        {
            Hide();

            BoardPage boardPage = new BoardPage(user, personalBoard);
            boardPage.ShowDialog();

            Close();
        }

        private void btnProjectBoards_Click(object sender, EventArgs e)
        {

        }
    }
}