using System;
using System.Data;
using System.Windows.Forms;
using WF_Tabula.Models;
using WF_Tabula.Containers;
using WF_Tabula.DALs;

namespace WF_Tabula.Views
{
    public partial class LoginPage : Form
    {
        private UserContainer userContainer { get; set; }
        private BoardContainer boardContainer { get; set; }

        private User user { get; set; }

        public LoginPage()
        {
            InitializeComponent();

            SetUp();
        }

        public LoginPage(string message)
        {
            InitializeComponent();

            lblMessage.Text = message;

            SetUp();
        }

        public void SetUp()
        {
            userContainer = new UserContainer(new UserDAL());
            boardContainer = new BoardContainer(new BoardDAL());
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (!userContainer.UsernameEmailExists(tbUsernameEmail.Text))
            {
                lblMessage.Text = "The username/email doesn't exist.";
            }
            else if (!userContainer.IsValidLogin(tbUsernameEmail.Text, tbPassword.Text))
            {
                lblMessage.Text = "Wrong password!";
            }
            else
            {
                GetUserData();
                DisplayMainPage();
            }
        }

        private void DisplayMainPage()
        {
            Hide();

            MainPage mainPage = new MainPage(user);
            mainPage.ShowDialog();

            Close();
        }

        private void GetUserData()
        {
            user = new User();
            DataTable userData = userContainer.GetUserDetails(tbUsernameEmail.Text);

            SetUserData(userData);
        }

        private void SetUserData(DataTable userData)
        {
            user.id = Convert.ToInt32(userData.Rows[0]["ID"]);

            user.firstname = Convert.ToString(userData.Rows[0]["First_name"]);
            user.lastname = Convert.ToString(userData.Rows[0]["Last_name"]);
            user.username = Convert.ToString(userData.Rows[0]["Username"]);

            user.email = Convert.ToString(userData.Rows[0]["Email"]);
            user.dateOfBirth = Convert.ToDateTime(userData.Rows[0]["Date_of_birth"]);
            user.createdAt = Convert.ToDateTime(userData.Rows[0]["Created_at"]);

            user.boards = boardContainer.GetBoards(user.id).AsReadOnly();
        }

        private void lblCantLogin_Click(object sender, EventArgs e)
        {

        }

        private void lblCreateAccount_Click(object sender, EventArgs e)
        {
            user = new User();

            Hide();

            SignupPage_1 signupPage_1 = new SignupPage_1(user);
            signupPage_1.ShowDialog();

            Close();
        }
    }
}