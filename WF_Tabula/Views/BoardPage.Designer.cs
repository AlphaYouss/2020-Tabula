namespace WF_Tabula.Views
{
    partial class BoardPage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSM = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIMain = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIProjectboard = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMISettings = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMILogout = new System.Windows.Forms.ToolStripMenuItem();
            this.lbLists = new System.Windows.Forms.ListBox();
            this.tbListname = new System.Windows.Forms.TextBox();
            this.btnAddList = new System.Windows.Forms.Button();
            this.btnEditList = new System.Windows.Forms.Button();
            this.btnDeleteList = new System.Windows.Forms.Button();
            this.lblListname = new System.Windows.Forms.Label();
            this.lblBoardName = new System.Windows.Forms.Label();
            this.lblLists = new System.Windows.Forms.Label();
            this.lbCards = new System.Windows.Forms.ListBox();
            this.lblCards = new System.Windows.Forms.Label();
            this.tbCardName = new System.Windows.Forms.TextBox();
            this.tbCardDesription = new System.Windows.Forms.TextBox();
            this.lbCardPriorities = new System.Windows.Forms.ListBox();
            this.dtpCardDeadline = new System.Windows.Forms.DateTimePicker();
            this.btnAddCard = new System.Windows.Forms.Button();
            this.btnEditCard = new System.Windows.Forms.Button();
            this.btnDeleteCard = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbNewList = new System.Windows.Forms.CheckBox();
            this.cbNewCard = new System.Windows.Forms.CheckBox();
            this.cbEditCard = new System.Windows.Forms.CheckBox();
            this.cbEditList = new System.Windows.Forms.CheckBox();
            this.cbDeleteList = new System.Windows.Forms.CheckBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cbDeleteCard = new System.Windows.Forms.CheckBox();
            this.cbCardDeadline = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSM});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSM
            // 
            this.TSM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIMain,
            this.TSMIProjectboard,
            this.TSMISettings,
            this.TSMILogout});
            this.TSM.Name = "TSM";
            this.TSM.Size = new System.Drawing.Size(50, 20);
            this.TSM.Text = "Menu";
            // 
            // TSMIMain
            // 
            this.TSMIMain.Name = "TSMIMain";
            this.TSMIMain.Size = new System.Drawing.Size(145, 22);
            this.TSMIMain.Text = "Main";
            this.TSMIMain.Click += new System.EventHandler(this.TSMIMain_Click);
            // 
            // TSMIProjectboard
            // 
            this.TSMIProjectboard.Name = "TSMIProjectboard";
            this.TSMIProjectboard.Size = new System.Drawing.Size(145, 22);
            this.TSMIProjectboard.Text = "Project board";
            // 
            // TSMISettings
            // 
            this.TSMISettings.Name = "TSMISettings";
            this.TSMISettings.Size = new System.Drawing.Size(145, 22);
            this.TSMISettings.Text = "Settings";
            // 
            // TSMILogout
            // 
            this.TSMILogout.Name = "TSMILogout";
            this.TSMILogout.Size = new System.Drawing.Size(145, 22);
            this.TSMILogout.Text = "Logout";
            // 
            // lbLists
            // 
            this.lbLists.FormattingEnabled = true;
            this.lbLists.Location = new System.Drawing.Point(13, 77);
            this.lbLists.Name = "lbLists";
            this.lbLists.Size = new System.Drawing.Size(238, 290);
            this.lbLists.TabIndex = 1;
            this.lbLists.SelectedIndexChanged += new System.EventHandler(this.lbLists_SelectedIndexChanged);
            // 
            // tbListname
            // 
            this.tbListname.Enabled = false;
            this.tbListname.Location = new System.Drawing.Point(93, 386);
            this.tbListname.Name = "tbListname";
            this.tbListname.Size = new System.Drawing.Size(157, 20);
            this.tbListname.TabIndex = 2;
            // 
            // btnAddList
            // 
            this.btnAddList.Enabled = false;
            this.btnAddList.Location = new System.Drawing.Point(93, 415);
            this.btnAddList.Name = "btnAddList";
            this.btnAddList.Size = new System.Drawing.Size(75, 23);
            this.btnAddList.TabIndex = 3;
            this.btnAddList.Text = "Add";
            this.btnAddList.UseVisualStyleBackColor = true;
            this.btnAddList.Click += new System.EventHandler(this.btnAddList_Click);
            // 
            // btnEditList
            // 
            this.btnEditList.Enabled = false;
            this.btnEditList.Location = new System.Drawing.Point(176, 415);
            this.btnEditList.Name = "btnEditList";
            this.btnEditList.Size = new System.Drawing.Size(75, 23);
            this.btnEditList.TabIndex = 4;
            this.btnEditList.Text = "Edit";
            this.btnEditList.UseVisualStyleBackColor = true;
            this.btnEditList.Click += new System.EventHandler(this.btnEditList_Click);
            // 
            // btnDeleteList
            // 
            this.btnDeleteList.Enabled = false;
            this.btnDeleteList.Location = new System.Drawing.Point(257, 415);
            this.btnDeleteList.Name = "btnDeleteList";
            this.btnDeleteList.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteList.TabIndex = 5;
            this.btnDeleteList.Text = "Delete";
            this.btnDeleteList.UseVisualStyleBackColor = true;
            this.btnDeleteList.Click += new System.EventHandler(this.btnDeleteList_Click);
            // 
            // lblListname
            // 
            this.lblListname.AutoSize = true;
            this.lblListname.Location = new System.Drawing.Point(91, 370);
            this.lblListname.Name = "lblListname";
            this.lblListname.Size = new System.Drawing.Size(55, 13);
            this.lblListname.TabIndex = 6;
            this.lblListname.Text = "List name:";
            // 
            // lblBoardName
            // 
            this.lblBoardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoardName.Location = new System.Drawing.Point(13, 36);
            this.lblBoardName.Name = "lblBoardName";
            this.lblBoardName.Size = new System.Drawing.Size(775, 23);
            this.lblBoardName.TabIndex = 7;
            this.lblBoardName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLists
            // 
            this.lblLists.AutoSize = true;
            this.lblLists.Location = new System.Drawing.Point(12, 59);
            this.lblLists.Name = "lblLists";
            this.lblLists.Size = new System.Drawing.Size(31, 13);
            this.lblLists.TabIndex = 8;
            this.lblLists.Text = "Lists:";
            // 
            // lbCards
            // 
            this.lbCards.Enabled = false;
            this.lbCards.FormattingEnabled = true;
            this.lbCards.Location = new System.Drawing.Point(349, 77);
            this.lbCards.Name = "lbCards";
            this.lbCards.Size = new System.Drawing.Size(238, 290);
            this.lbCards.TabIndex = 9;
            this.lbCards.SelectedIndexChanged += new System.EventHandler(this.lbCards_SelectedIndexChanged);
            // 
            // lblCards
            // 
            this.lblCards.AutoSize = true;
            this.lblCards.Location = new System.Drawing.Point(346, 59);
            this.lblCards.Name = "lblCards";
            this.lblCards.Size = new System.Drawing.Size(37, 13);
            this.lblCards.TabIndex = 10;
            this.lblCards.Text = "Cards:";
            // 
            // tbCardName
            // 
            this.tbCardName.Enabled = false;
            this.tbCardName.Location = new System.Drawing.Point(610, 100);
            this.tbCardName.Name = "tbCardName";
            this.tbCardName.Size = new System.Drawing.Size(178, 20);
            this.tbCardName.TabIndex = 11;
            // 
            // tbCardDesription
            // 
            this.tbCardDesription.Enabled = false;
            this.tbCardDesription.Location = new System.Drawing.Point(610, 150);
            this.tbCardDesription.Name = "tbCardDesription";
            this.tbCardDesription.Size = new System.Drawing.Size(178, 20);
            this.tbCardDesription.TabIndex = 12;
            // 
            // lbCardPriorities
            // 
            this.lbCardPriorities.Enabled = false;
            this.lbCardPriorities.FormattingEnabled = true;
            this.lbCardPriorities.Location = new System.Drawing.Point(610, 200);
            this.lbCardPriorities.Name = "lbCardPriorities";
            this.lbCardPriorities.Size = new System.Drawing.Size(178, 30);
            this.lbCardPriorities.TabIndex = 13;
            // 
            // dtpCardDeadline
            // 
            this.dtpCardDeadline.Enabled = false;
            this.dtpCardDeadline.Location = new System.Drawing.Point(610, 284);
            this.dtpCardDeadline.Name = "dtpCardDeadline";
            this.dtpCardDeadline.Size = new System.Drawing.Size(178, 20);
            this.dtpCardDeadline.TabIndex = 14;
            // 
            // btnAddCard
            // 
            this.btnAddCard.Enabled = false;
            this.btnAddCard.Location = new System.Drawing.Point(607, 368);
            this.btnAddCard.Name = "btnAddCard";
            this.btnAddCard.Size = new System.Drawing.Size(75, 23);
            this.btnAddCard.TabIndex = 15;
            this.btnAddCard.Text = "Add";
            this.btnAddCard.UseVisualStyleBackColor = true;
            this.btnAddCard.Click += new System.EventHandler(this.btnAddCard_Click);
            // 
            // btnEditCard
            // 
            this.btnEditCard.Enabled = false;
            this.btnEditCard.Location = new System.Drawing.Point(701, 368);
            this.btnEditCard.Name = "btnEditCard";
            this.btnEditCard.Size = new System.Drawing.Size(75, 23);
            this.btnEditCard.TabIndex = 16;
            this.btnEditCard.Text = "Edit";
            this.btnEditCard.UseVisualStyleBackColor = true;
            this.btnEditCard.Click += new System.EventHandler(this.btnEditCard_Click);
            // 
            // btnDeleteCard
            // 
            this.btnDeleteCard.Enabled = false;
            this.btnDeleteCard.Location = new System.Drawing.Point(648, 407);
            this.btnDeleteCard.Name = "btnDeleteCard";
            this.btnDeleteCard.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCard.TabIndex = 17;
            this.btnDeleteCard.Text = "Delete";
            this.btnDeleteCard.UseVisualStyleBackColor = true;
            this.btnDeleteCard.Click += new System.EventHandler(this.btnDeleteCard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(607, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Card name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Card description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Card priority:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 268);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Card deadline:";
            // 
            // cbNewList
            // 
            this.cbNewList.AutoSize = true;
            this.cbNewList.Location = new System.Drawing.Point(16, 373);
            this.cbNewList.Name = "cbNewList";
            this.cbNewList.Size = new System.Drawing.Size(63, 17);
            this.cbNewList.TabIndex = 22;
            this.cbNewList.Text = "New list";
            this.cbNewList.UseVisualStyleBackColor = true;
            this.cbNewList.CheckedChanged += new System.EventHandler(this.cbNewList_CheckedChanged);
            // 
            // cbNewCard
            // 
            this.cbNewCard.AutoSize = true;
            this.cbNewCard.Enabled = false;
            this.cbNewCard.Location = new System.Drawing.Point(610, 322);
            this.cbNewCard.Name = "cbNewCard";
            this.cbNewCard.Size = new System.Drawing.Size(72, 17);
            this.cbNewCard.TabIndex = 23;
            this.cbNewCard.Text = "New card";
            this.cbNewCard.UseVisualStyleBackColor = true;
            this.cbNewCard.CheckedChanged += new System.EventHandler(this.cbNewCard_CheckedChanged);
            // 
            // cbEditCard
            // 
            this.cbEditCard.AutoSize = true;
            this.cbEditCard.Enabled = false;
            this.cbEditCard.Location = new System.Drawing.Point(701, 322);
            this.cbEditCard.Name = "cbEditCard";
            this.cbEditCard.Size = new System.Drawing.Size(68, 17);
            this.cbEditCard.TabIndex = 24;
            this.cbEditCard.Text = "Edit card";
            this.cbEditCard.UseVisualStyleBackColor = true;
            this.cbEditCard.CheckedChanged += new System.EventHandler(this.cbEditCard_CheckedChanged);
            // 
            // cbEditList
            // 
            this.cbEditList.AutoSize = true;
            this.cbEditList.Enabled = false;
            this.cbEditList.Location = new System.Drawing.Point(16, 396);
            this.cbEditList.Name = "cbEditList";
            this.cbEditList.Size = new System.Drawing.Size(59, 17);
            this.cbEditList.TabIndex = 25;
            this.cbEditList.Text = "Edit list";
            this.cbEditList.UseVisualStyleBackColor = true;
            this.cbEditList.CheckedChanged += new System.EventHandler(this.cbEditList_CheckedChanged);
            // 
            // cbDeleteList
            // 
            this.cbDeleteList.AutoSize = true;
            this.cbDeleteList.Enabled = false;
            this.cbDeleteList.Location = new System.Drawing.Point(16, 419);
            this.cbDeleteList.Name = "cbDeleteList";
            this.cbDeleteList.Size = new System.Drawing.Size(72, 17);
            this.cbDeleteList.TabIndex = 26;
            this.cbDeleteList.Text = "Delete list";
            this.cbDeleteList.UseVisualStyleBackColor = true;
            this.cbDeleteList.CheckedChanged += new System.EventHandler(this.cbDeleteList_CheckedChanged);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(346, 423);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 27;
            // 
            // cbDeleteCard
            // 
            this.cbDeleteCard.AutoSize = true;
            this.cbDeleteCard.Enabled = false;
            this.cbDeleteCard.Location = new System.Drawing.Point(651, 345);
            this.cbDeleteCard.Name = "cbDeleteCard";
            this.cbDeleteCard.Size = new System.Drawing.Size(81, 17);
            this.cbDeleteCard.TabIndex = 28;
            this.cbDeleteCard.Text = "Delete card";
            this.cbDeleteCard.UseVisualStyleBackColor = true;
            this.cbDeleteCard.CheckedChanged += new System.EventHandler(this.cbDeleteCard_CheckedChanged);
            // 
            // cbCardDeadline
            // 
            this.cbCardDeadline.AutoSize = true;
            this.cbCardDeadline.Enabled = false;
            this.cbCardDeadline.Location = new System.Drawing.Point(610, 248);
            this.cbCardDeadline.Name = "cbCardDeadline";
            this.cbCardDeadline.Size = new System.Drawing.Size(68, 17);
            this.cbCardDeadline.TabIndex = 29;
            this.cbCardDeadline.Text = "Deadline";
            this.cbCardDeadline.UseVisualStyleBackColor = true;
            this.cbCardDeadline.CheckedChanged += new System.EventHandler(this.cbCardDeadline_CheckedChanged);
            // 
            // BoardPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbCardDeadline);
            this.Controls.Add(this.cbDeleteCard);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cbDeleteList);
            this.Controls.Add(this.cbEditList);
            this.Controls.Add(this.cbEditCard);
            this.Controls.Add(this.cbNewCard);
            this.Controls.Add(this.cbNewList);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDeleteCard);
            this.Controls.Add(this.btnEditCard);
            this.Controls.Add(this.btnAddCard);
            this.Controls.Add(this.dtpCardDeadline);
            this.Controls.Add(this.lbCardPriorities);
            this.Controls.Add(this.tbCardDesription);
            this.Controls.Add(this.tbCardName);
            this.Controls.Add(this.lblCards);
            this.Controls.Add(this.lbCards);
            this.Controls.Add(this.lblLists);
            this.Controls.Add(this.lblBoardName);
            this.Controls.Add(this.lblListname);
            this.Controls.Add(this.btnDeleteList);
            this.Controls.Add(this.btnEditList);
            this.Controls.Add(this.btnAddList);
            this.Controls.Add(this.tbListname);
            this.Controls.Add(this.lbLists);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "BoardPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Board";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListBox lbLists;
        private System.Windows.Forms.TextBox tbListname;
        private System.Windows.Forms.Button btnAddList;
        private System.Windows.Forms.Button btnEditList;
        private System.Windows.Forms.Button btnDeleteList;
        private System.Windows.Forms.Label lblListname;
        private System.Windows.Forms.Label lblBoardName;
        private System.Windows.Forms.Label lblLists;
        private System.Windows.Forms.ListBox lbCards;
        private System.Windows.Forms.Label lblCards;
        private System.Windows.Forms.TextBox tbCardName;
        private System.Windows.Forms.TextBox tbCardDesription;
        private System.Windows.Forms.ListBox lbCardPriorities;
        private System.Windows.Forms.DateTimePicker dtpCardDeadline;
        private System.Windows.Forms.Button btnAddCard;
        private System.Windows.Forms.Button btnEditCard;
        private System.Windows.Forms.Button btnDeleteCard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbNewList;
        private System.Windows.Forms.CheckBox cbNewCard;
        private System.Windows.Forms.CheckBox cbEditCard;
        private System.Windows.Forms.CheckBox cbEditList;
        private System.Windows.Forms.ToolStripMenuItem TSM;
        private System.Windows.Forms.ToolStripMenuItem TSMIMain;
        private System.Windows.Forms.ToolStripMenuItem TSMISettings;
        private System.Windows.Forms.ToolStripMenuItem TSMILogout;
        private System.Windows.Forms.ToolStripMenuItem TSMIProjectboard;
        private System.Windows.Forms.CheckBox cbDeleteList;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.CheckBox cbDeleteCard;
        private System.Windows.Forms.CheckBox cbCardDeadline;
    }
}