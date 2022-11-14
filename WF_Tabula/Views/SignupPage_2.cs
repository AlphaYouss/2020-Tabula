using System;
using System.Windows.Forms;
using WF_Tabula.Models;
using WF_Tabula.Containers;
using WF_Tabula.Tools;
using WF_Tabula.DALs;

namespace WF_Tabula.Views
{
    public partial class SignupPage_2 : Form
    {
        private UserContainer userContainer { get; set; }
        private BoardContainer boardContainer { get; set; }

        private User user { get; set; }

        private Validator validator { get; set; }
        private Passwordhandler passwordhandler { get; set; }

        public SignupPage_2(User user)
        {
            InitializeComponent();

            userContainer = new UserContainer(new UserDAL());
            boardContainer = new BoardContainer(new BoardDAL());

            validator = new Validator();
            passwordhandler = new Passwordhandler();

            this.user = user;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();

            SignupPage_1 signupPage_1 = new SignupPage_1(user);
            signupPage_1.ShowDialog();

            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (!CheckEmail())
            {
                lblMessage.Text = "Please fill in a valid email.";
            }
            else if(!CheckIfEmailExists())
            {
                lblMessage.Text = "The email is already in use.";
            }
            else if (!CheckPasswords())
            {
                lblMessage.Text = "Both passwords are not the same.";
            }
            else if (!CheckPassword())
            {
                lblMessage.Text = "Please fill in a valid password.";
            }
            else
            {
                user.email = tbEmail.Text;
                user.dateOfBirth = dtpDate_of_birth.Value.Date;
                user.createdAt = DateTime.Now;

                CreateUserWithBoard();
            }
        }

        private Boolean CheckEmail()
        {
            if (validator.ValidateEmail(tbEmail.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckIfEmailExists()
        {
            if (userContainer.EmailExists(tbEmail.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean CheckPasswords()
        {
            if (tbPassword.Text == tbPasswordRepeat.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean CheckPassword()
        {
            if (validator.ValidatePassword(tbPassword.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CreateUserWithBoard()
        {
            int user_ID = userContainer.CreateUser(user, passwordhandler.GenerateSaltAndHash(tbPassword.Text));
            boardContainer.CreatePersonalBoard(user_ID);

            DisplayLogin();
        }

        private void DisplayLogin()
        {
            Hide();

            LoginPage loginPage = new LoginPage("You have successfully created your account!");
            loginPage.ShowDialog();

            Close();
        }
    }
}