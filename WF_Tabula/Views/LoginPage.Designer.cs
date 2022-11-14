namespace WF_Tabula.Views
{
    partial class LoginPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUsernameEmail = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblCantLogin = new System.Windows.Forms.Label();
            this.lblCreateAccount = new System.Windows.Forms.Label();
            this.lblUsernameEmail = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbUsernameEmail
            // 
            this.tbUsernameEmail.Location = new System.Drawing.Point(50, 70);
            this.tbUsernameEmail.MaxLength = 320;
            this.tbUsernameEmail.Name = "tbUsernameEmail";
            this.tbUsernameEmail.Size = new System.Drawing.Size(163, 20);
            this.tbUsernameEmail.TabIndex = 0;
            this.tbUsernameEmail.Text = "AlphaYouss";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(50, 124);
            this.tbPassword.MaxLength = 20;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(163, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.Text = "Welkom12345";
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(50, 169);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(163, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblCantLogin
            // 
            this.lblCantLogin.Location = new System.Drawing.Point(12, 204);
            this.lblCantLogin.Name = "lblCantLogin";
            this.lblCantLogin.Size = new System.Drawing.Size(240, 13);
            this.lblCantLogin.TabIndex = 3;
            this.lblCantLogin.Text = "Can\'t login?";
            this.lblCantLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCantLogin.Click += new System.EventHandler(this.lblCantLogin_Click);
            // 
            // lblCreateAccount
            // 
            this.lblCreateAccount.Location = new System.Drawing.Point(12, 233);
            this.lblCreateAccount.Name = "lblCreateAccount";
            this.lblCreateAccount.Size = new System.Drawing.Size(240, 13);
            this.lblCreateAccount.TabIndex = 4;
            this.lblCreateAccount.Text = "Create an account here!";
            this.lblCreateAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCreateAccount.Click += new System.EventHandler(this.lblCreateAccount_Click);
            // 
            // lblUsernameEmail
            // 
            this.lblUsernameEmail.AutoSize = true;
            this.lblUsernameEmail.Location = new System.Drawing.Point(47, 54);
            this.lblUsernameEmail.Name = "lblUsernameEmail";
            this.lblUsernameEmail.Size = new System.Drawing.Size(84, 13);
            this.lblUsernameEmail.TabIndex = 5;
            this.lblUsernameEmail.Text = "Username/email";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(47, 108);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // lblPage
            // 
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(12, 24);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(240, 20);
            this.lblPage.TabIndex = 7;
            this.lblPage.Text = "Login";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(13, 153);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(240, 13);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 257);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsernameEmail);
            this.Controls.Add(this.lblCreateAccount);
            this.Controls.Add(this.lblCantLogin);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUsernameEmail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabula - Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsernameEmail;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblCantLogin;
        private System.Windows.Forms.Label lblCreateAccount;
        private System.Windows.Forms.Label lblUsernameEmail;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblMessage;
    }
}

