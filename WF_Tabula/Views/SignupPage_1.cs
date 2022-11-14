using System;
using System.Windows.Forms;
using WF_Tabula.Models;
using WF_Tabula.Containers;
using WF_Tabula.Tools;
using WF_Tabula.DALs;

namespace WF_Tabula.Views
{
    public partial class SignupPage_1 : Form
    {
        private UserContainer userContainer { get; set; }

        private User user { get; set; }

        private Validator validator { get; set; } 

        public SignupPage_1(User user)
        {
            InitializeComponent();

            userContainer = new UserContainer(new UserDAL());

            validator = new Validator();

            this.user = user;

            tbFirstname.Text = user.firstname;
            tbLastname.Text = user.lastname;
            tbUsername.Text = user.username;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();

            LoginPage loginPage = new LoginPage();
            loginPage.ShowDialog();

            Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (!validator.ValidateNames(tbFirstname.Text) & !validator.ValidateNames(tbLastname.Text))
            {
                lblMessage.Text = "Please fill in a valid first name and last name.";
            }
            else if (!validator.ValidateUsername(tbUsername.Text))
            {
                lblMessage.Text = "Please fill in a valid username.";
            }
            else if (userContainer.UsernameExists(tbUsername.Text))
            {
                lblMessage.Text = "The username is already in use.";
            }
            else
            {
                user.firstname = tbFirstname.Text;
                user.lastname = tbLastname.Text;
                user.username =  tbUsername.Text;

                DisplayNextPage();
            }
        }

        private void DisplayNextPage()
        {
            Hide();

            SignupPage_2 signupPage_2 = new SignupPage_2(user);
            signupPage_2.ShowDialog();

            Close();
        }
    }
}