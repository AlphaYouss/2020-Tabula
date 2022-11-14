namespace WF_Tabula.Views
{
    partial class SignupPage_2
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
            this.btnBack = new System.Windows.Forms.Button();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.lblPasswordRepeat = new System.Windows.Forms.Label();
            this.tbPasswordRepeat = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.dtpDate_of_birth = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 14);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(54, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(47, 167);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 26;
            this.lblPassword.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(50, 183);
            this.tbPassword.MaxLength = 20;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(163, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // lblPage
            // 
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(12, 30);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(240, 20);
            this.lblPage.TabIndex = 24;
            this.lblPage.Text = "Sign up";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Location = new System.Drawing.Point(47, 114);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(65, 13);
            this.lblDateOfBirth.TabIndex = 23;
            this.lblDateOfBirth.Text = "Date of birth";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(47, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 22;
            this.lblEmail.Text = "E-mail";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(50, 284);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(163, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Create account";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(50, 76);
            this.tbEmail.MaxLength = 320;
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(163, 20);
            this.tbEmail.TabIndex = 2;
            // 
            // lblPasswordRepeat
            // 
            this.lblPasswordRepeat.AutoSize = true;
            this.lblPasswordRepeat.Location = new System.Drawing.Point(47, 219);
            this.lblPasswordRepeat.Name = "lblPasswordRepeat";
            this.lblPasswordRepeat.Size = new System.Drawing.Size(86, 13);
            this.lblPasswordRepeat.TabIndex = 29;
            this.lblPasswordRepeat.Text = "Password repeat";
            // 
            // tbPasswordRepeat
            // 
            this.tbPasswordRepeat.Location = new System.Drawing.Point(50, 235);
            this.tbPasswordRepeat.MaxLength = 20;
            this.tbPasswordRepeat.Name = "tbPasswordRepeat";
            this.tbPasswordRepeat.Size = new System.Drawing.Size(163, 20);
            this.tbPasswordRepeat.TabIndex = 5;
            this.tbPasswordRepeat.UseSystemPasswordChar = true;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(13, 258);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(249, 23);
            this.lblMessage.TabIndex = 30;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDate_of_birth
            // 
            this.dtpDate_of_birth.CustomFormat = "dd-MM-yyyy";
            this.dtpDate_of_birth.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate_of_birth.Location = new System.Drawing.Point(50, 130);
            this.dtpDate_of_birth.MaxDate = new System.DateTime(2008, 12, 31, 0, 0, 0, 0);
            this.dtpDate_of_birth.MinDate = new System.DateTime(1910, 1, 1, 0, 0, 0, 0);
            this.dtpDate_of_birth.Name = "dtpDate_of_birth";
            this.dtpDate_of_birth.Size = new System.Drawing.Size(163, 18);
            this.dtpDate_of_birth.TabIndex = 31;
            this.dtpDate_of_birth.Value = new System.DateTime(2008, 12, 31, 0, 0, 0, 0);
            // 
            // Signup_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 321);
            this.Controls.Add(this.dtpDate_of_birth);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblPasswordRepeat);
            this.Controls.Add(this.tbPasswordRepeat);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.lblDateOfBirth);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tbEmail);
            this.MaximizeBox = false;
            this.Name = "Signup_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Signup_2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label lblPasswordRepeat;
        private System.Windows.Forms.TextBox tbPasswordRepeat;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DateTimePicker dtpDate_of_birth;
    }
}