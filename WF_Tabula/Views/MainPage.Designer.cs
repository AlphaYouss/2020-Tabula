namespace WF_Tabula.Views
{
    partial class MainPage
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnPersonalBoard = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIPersonalboard = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIProjectboards = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISettings = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMILogout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnProjectBoards = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.Location = new System.Drawing.Point(12, 34);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(249, 23);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPersonalBoard
            // 
            this.btnPersonalBoard.Location = new System.Drawing.Point(12, 240);
            this.btnPersonalBoard.Name = "btnPersonalBoard";
            this.btnPersonalBoard.Size = new System.Drawing.Size(90, 23);
            this.btnPersonalBoard.TabIndex = 2;
            this.btnPersonalBoard.Text = "Personal board";
            this.btnPersonalBoard.UseVisualStyleBackColor = true;
            this.btnPersonalBoard.Click += new System.EventHandler(this.btnPersonalBoard_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(273, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSM
            // 
            this.TSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIPersonalboard,
            this.TSMIProjectboards,
            this.TSMISettings,
            this.TSMILogout});
            this.TSM.Name = "TSM";
            this.TSM.Size = new System.Drawing.Size(50, 20);
            this.TSM.Text = "Menu";
            // 
            // TSMIPersonalboard
            // 
            this.TSMIPersonalboard.Name = "TSMIPersonalboard";
            this.TSMIPersonalboard.Size = new System.Drawing.Size(180, 22);
            this.TSMIPersonalboard.Text = "Personal board";
            this.TSMIPersonalboard.Click += new System.EventHandler(this.TSMIPersonalboard_Click);
            // 
            // TSMIProjectboards
            // 
            this.TSMIProjectboards.Name = "TSMIProjectboards";
            this.TSMIProjectboards.Size = new System.Drawing.Size(180, 22);
            this.TSMIProjectboards.Text = "Project boards";
            this.TSMIProjectboards.Click += new System.EventHandler(this.TSMIProjectboards_Click);
            // 
            // TSMISettings
            // 
            this.TSMISettings.Name = "TSMISettings";
            this.TSMISettings.Size = new System.Drawing.Size(180, 22);
            this.TSMISettings.Text = "Settings";
            this.TSMISettings.Click += new System.EventHandler(this.TSMISettings_Click);
            // 
            // TSMILogout
            // 
            this.TSMILogout.Name = "TSMILogout";
            this.TSMILogout.Size = new System.Drawing.Size(180, 22);
            this.TSMILogout.Text = "Logout";
            this.TSMILogout.Click += new System.EventHandler(this.TSMILogout_Click);
            // 
            // btnProjectBoards
            // 
            this.btnProjectBoards.Location = new System.Drawing.Point(171, 240);
            this.btnProjectBoards.Name = "btnProjectBoards";
            this.btnProjectBoards.Size = new System.Drawing.Size(90, 23);
            this.btnProjectBoards.TabIndex = 4;
            this.btnProjectBoards.Text = "Project boards";
            this.btnProjectBoards.UseVisualStyleBackColor = true;
            this.btnProjectBoards.Click += new System.EventHandler(this.btnProjectBoards_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 275);
            this.Controls.Add(this.btnProjectBoards);
            this.Controls.Add(this.btnPersonalBoard);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnPersonalBoard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSM;
        private System.Windows.Forms.ToolStripMenuItem TSMILogout;
        private System.Windows.Forms.ToolStripMenuItem TSMIPersonalboard;
        private System.Windows.Forms.ToolStripMenuItem TSMIProjectboards;
        private System.Windows.Forms.ToolStripMenuItem TSMISettings;
        private System.Windows.Forms.Button btnProjectBoards;
    }
}