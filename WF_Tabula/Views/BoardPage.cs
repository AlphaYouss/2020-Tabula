using System;
using System.Windows.Forms;
using WF_Tabula.Models;
using WF_Tabula.Containers;
using WF_Tabula.DALs;

namespace WF_Tabula.Views
{
    public partial class BoardPage : Form
    {
        private ListContainer listContainer { get; set; }
        private CardContainer cardContainer { get; set; }

        private User user { get; set; }
        private Board selectedBoard { get; set; }
        private List selectedList { get; set; }
        private Card selectedCard { get; set; }

        private int selectedListValue { get; set; }
        private int selectedCardValue { get; set; }

        public BoardPage(User user, Board selectedBoard)
        {
            InitializeComponent();

            listContainer = new ListContainer(new ListDAL());
            cardContainer = new CardContainer(new CardDAL());

            this.user = user;
            this.selectedBoard = selectedBoard;

            SetUp();
        }

        private void SetUp()
        {
            selectedBoard.lists = listContainer.GetLists(selectedBoard.id).AsReadOnly();

            lblBoardName.Text = selectedBoard.name;

            foreach (List list in selectedBoard.lists)
            {
                lbLists.Items.Add(list.name);
            }

            lbCardPriorities.Items.Add(Card.Priorities.Critical);
            lbCardPriorities.Items.Add(Card.Priorities.Important);
            lbCardPriorities.Items.Add(Card.Priorities.Normal);
            lbCardPriorities.Items.Add(Card.Priorities.Low);
            lbCardPriorities.Items.Add(Card.Priorities.None);

            lbCardPriorities.SelectedIndex = 4;
        }

        private void TSMIMain_Click(object sender, EventArgs e)
        {
            Hide();

            MainPage mainPage = new MainPage(user);
            mainPage.ShowDialog();

            Close();
        }

        private void lbLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedListValue = lbLists.SelectedIndex;

            if (selectedListValue >= 0)
            {
                cbNewList.Checked = false;

                cbEditCard.Checked = false;
                cbDeleteCard.Checked = false;

                cbEditList.Enabled = true;
                cbDeleteList.Enabled = true;

                tbCardName.Text = "";
                tbCardDesription.Text = "";

                lbCardPriorities.SelectedIndex = 4;

                cbCardDeadline.Checked = false;

                cbNewCard.Enabled = true;
                cbEditCard.Enabled = false;
                cbDeleteCard.Enabled = false;

                cbNewCard.Checked = false;

                selectedList = selectedBoard.lists[selectedListValue];
                selectedList.cards = cardContainer.GetCards(selectedList.id).AsReadOnly();

                tbListname.Text = selectedList.name;

                lbCards.Items.Clear();

                if (selectedList.cards != null)
                {
                    for (int i = 0; i < selectedList.cards.Count; i++)
                    {
                        lbCards.Items.Add(selectedList.cards[i].name);
                    }
                }

                lbCards.Enabled = true;
            }
            else
            {
                cbNewCard.Checked = false;

                cbNewCard.Enabled = false;

                cbEditList.Enabled = false;
                cbDeleteList.Enabled = false;

                selectedList = null;

                lbCards.Items.Clear();
                lbLists.ClearSelected();
            }
        }

        private void lbCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCardValue = lbCards.SelectedIndex;

            if (selectedCardValue >= 0)
            {
                cbNewCard.Checked = false;
                cbEditCard.Checked = false;
                cbDeleteCard.Checked = false;

                selectedCard = selectedList.cards[selectedCardValue];

                tbCardName.Text = selectedCard.name;
                tbCardDesription.Text = selectedCard.description;

                switch (selectedCard.priority)
                {
                    case Card.Priorities.Critical:
                        lbCardPriorities.SelectedIndex = 0;
                        break;
                    case Card.Priorities.Important:
                        lbCardPriorities.SelectedIndex = 1;
                        break;
                    case Card.Priorities.Normal:
                        lbCardPriorities.SelectedIndex = 2;
                        break;
                    case Card.Priorities.Low:
                        lbCardPriorities.SelectedIndex = 3;
                        break;
                    case Card.Priorities.None:
                        lbCardPriorities.SelectedIndex = 4;
                        break;
                    default:
                        lbCardPriorities.SelectedIndex = 4;
                        break;
                }

                if (selectedCard.deadline != null)
                {
                    cbCardDeadline.Checked = true;

                    dtpCardDeadline.Value = selectedCard.deadline.Value;
                }
                else
                {
                    cbCardDeadline.Checked = false;

                    dtpCardDeadline.Value = DateTime.Today;
                }

                dtpCardDeadline.Enabled = false;

                cbEditCard.Enabled = true;
                cbDeleteCard.Enabled = true;
            }
            else
            {
                selectedCard = null;

                lbCards.ClearSelected();
            }
        }

        private void cbNewList_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNewList.Checked == true)
            {
                cbEditList.Checked = false;
                cbDeleteList.Checked = false;

                lbLists.SelectedIndex = -1;

                tbListname.Text = "";
                tbListname.Enabled = true;

                btnAddList.Enabled = true;
            }
            else
            {
                tbListname.Enabled = false;

                btnAddList.Enabled = false;
            }
        }

        private void cbEditList_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditList.Checked == true)
            {
                btnEditList.Enabled = true;

                cbDeleteList.Checked = false;

                tbListname.Enabled = true;
            }
            else
            {
                btnEditList.Enabled = false;

                if (selectedList != null)
                {
                    tbListname.Text = selectedList.name;
                }
                else
                {
                    tbListname.Text = "";
                }

                tbListname.Enabled = false;
            }
        }

        private void cbDeleteList_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeleteList.Checked == true)
            {
                cbEditList.Checked = false;

                btnDeleteList.Enabled = true;
            }
            else
            {
                btnDeleteList.Enabled = false;
            }
        }

        private void btnAddList_Click(object sender, EventArgs e)
        {
            if (tbListname.TextLength > 0)
            {
                listContainer.CreateList(selectedBoard.id, selectedBoard.lists.Count + 1, tbListname.Text, DateTime.Now);
                
                selectedBoard.lists = listContainer.GetLists(selectedBoard.id).AsReadOnly();

                lbLists.Items.Clear();

                foreach (List list in selectedBoard.lists)
                {
                    lbLists.Items.Add(list.name);
                }

                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Please fill in a list name.";
            }
        }

        private void btnEditList_Click(object sender, EventArgs e)
        {
            if (tbListname.Text == selectedList.name)
            {
                lblMessage.Text = "Please fill in a different list name.";
            }
            else if(selectedList == null)
            {
                lblMessage.Text = "Please pick a list.";
            }
            else if (tbListname.TextLength > 0)
            {
                listContainer.EditList(selectedList.id, selectedList.orderID, tbListname.Text, DateTime.Now);
                
                selectedBoard.lists = listContainer.GetLists(selectedBoard.id).AsReadOnly();

                lbLists.Items.Clear();

                foreach (List list in selectedBoard.lists)
                {
                    lbLists.Items.Add(list.name);
                }

                selectedList = null;

                cbEditList.Checked = false;

                cbEditList.Enabled = false;
                cbDeleteList.Enabled = false;

                lbCards.Items.Clear();

                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Please fill in a list name.";
            }
        }

        private void btnDeleteList_Click(object sender, System.EventArgs e)
        {
            if (selectedList != null)
            {
                cardContainer.DeleteCards(selectedList.id);

                listContainer.DeleteList(selectedList.id);

                selectedBoard.lists = listContainer.GetLists(selectedBoard.id).AsReadOnly();

                lbLists.Items.Clear();

                foreach (List list in selectedBoard.lists)
                {
                    lbLists.Items.Add(list.name);
                }

                lbCards.Items.Clear();

                cbNewCard.Enabled = false;

                cbDeleteList.Checked = false;
                cbDeleteList.Enabled = false;

                cbEditList.Enabled = false;

                tbListname.Text = "";

                selectedList = null;
            }
            else
            {
                lblMessage.Text = "There is no list to delete!";
            }
        }

        private void cbNewCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbNewCard.Checked == true)
            {
                cbDeleteCard.Checked = false;

                cbNewList.Checked = false;

                cbEditList.Enabled = true;
                cbDeleteList.Enabled = true;

                tbCardName.Text = "";
                tbCardDesription.Text = "";

                lbCardPriorities.SelectedIndex = 4;

                cbCardDeadline.Checked = false;

                cbEditCard.Enabled = false;
                cbDeleteCard.Enabled = false;

                lbCards.SelectedIndex = -1;

                tbCardName.Enabled = true;
                tbCardDesription.Enabled = true;

                lbCardPriorities.Enabled = true;

                cbCardDeadline.Enabled = true;

                btnAddCard.Enabled = true;
            }
            else
            {
                cbDeleteCard.Checked = false;

                tbCardName.Text = "";
                tbCardName.Enabled = false;

                tbCardDesription.Text = "";
                tbCardDesription.Enabled = false;

                lbCardPriorities.SelectedIndex = 4;
                lbCardPriorities.Enabled = false;

                cbCardDeadline.Checked = false;
                cbCardDeadline.Enabled = false;

                btnAddCard.Enabled = false;
            }
        }

        private void cbCardDeadline_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCardDeadline.Checked == true)
            {
                dtpCardDeadline.Enabled = true;
            }
            else
            {
                dtpCardDeadline.Enabled = false;
            }
        }

        private void btnAddCard_Click(object sender, EventArgs e)
        {
            if (tbCardName.TextLength <= 0 )
            {
                lblMessage.Text = "Please fill in a card name.";
            }
            else if(selectedList == null)
            {
                lblMessage.Text = "Please pick a list.";
            }
            else
            {
                if (cbCardDeadline.Checked == true)
                {
                    cardContainer.CreateCard(selectedList.id, selectedList.cards.Count + 1, tbCardName.Text, tbCardDesription.Text, lbCardPriorities.SelectedItem.ToString(), dtpCardDeadline.Value.Date, DateTime.Now);
                }
                else
                {
                    Nullable<DateTime> deadline = new Nullable<DateTime>();
                    cardContainer.CreateCard(selectedList.id, selectedList.cards.Count + 1, tbCardName.Text, tbCardDesription.Text, lbCardPriorities.SelectedItem.ToString(), deadline, DateTime.Now);
                }

                selectedList.cards = cardContainer.GetCards(selectedList.id).AsReadOnly();

                lbCards.Items.Clear();

                foreach (Card card in selectedList.cards)
                {
                    lbCards.Items.Add(card.name);
                }

                lblMessage.Text = "";
            }
        }

        private void cbEditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEditCard.Checked == true)
            {
                tbCardName.Enabled = true;
                tbCardDesription.Enabled = true;

                lbCardPriorities.Enabled = true;
                cbCardDeadline.Enabled = true;

                if (cbCardDeadline.Checked == true)
                {
                    dtpCardDeadline.Enabled = true;
                }

                btnEditCard.Enabled = true;
            }
            else
            {
                tbCardName.Enabled = false;
                tbCardDesription.Enabled = false;

                lbCardPriorities.Enabled = false;

                cbCardDeadline.Enabled = false;

                dtpCardDeadline.Enabled = false;

                btnEditCard.Enabled = false;
            }
        }

        private void cbDeleteCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDeleteCard.Checked == true)
            {
                cbEditCard.Checked = false;

                btnDeleteCard.Enabled = true;
            }
            else
            {
                btnDeleteCard.Enabled = false;
            }
        }

        private void btnDeleteCard_Click(object sender, EventArgs e)
        {
            if (selectedList != null && selectedCard != null)
            {
                cardContainer.DeleteCard(selectedCard.id);
                selectedList.cards = cardContainer.GetCards(selectedList.id).AsReadOnly();

                lbCards.Items.Clear();

                foreach (Card card in selectedList.cards)
                {
                    lbCards.Items.Add(card.name);
                }

                tbCardName.Text = "";
                tbCardName.Enabled = false;

                tbCardDesription.Text = "";
                tbCardDesription.Enabled = false;

                lbCardPriorities.SelectedIndex = 4;
                lbCardPriorities.Enabled = false;

                cbCardDeadline.Checked = false;
                cbCardDeadline.Enabled = false;

                cbEditCard.Checked = false;
                cbEditCard.Enabled = false;

                cbDeleteCard.Checked = false;
                cbDeleteCard.Enabled = false;

                selectedCard = null;
            }
            else
            {
                lblMessage.Text = "There is no card to delete!";
            }
        }

        private void btnEditCard_Click(object sender, EventArgs e)
        {
            if (tbCardName.TextLength <= 0)
            {
                lblMessage.Text = "Please fill in a card name.";
            }
            else if(selectedList == null || selectedCard == null)
            {
                lblMessage.Text = "Please pick a list with a card.";
            }
            else
            {
                if (cbCardDeadline.Checked == true)
                {
                    cardContainer.EditCard(selectedCard.id, selectedCard.orderID, tbCardName.Text, tbCardDesription.Text, lbCardPriorities.SelectedItem.ToString(), dtpCardDeadline.Value.Date, DateTime.Now);
                }
                else
                {
                    Nullable<DateTime> deadline = new Nullable<DateTime>();
                    cardContainer.EditCard(selectedCard.id, selectedCard.orderID, tbCardName.Text, tbCardDesription.Text, lbCardPriorities.SelectedItem.ToString(), deadline, DateTime.Now);
                }
                selectedList.cards = cardContainer.GetCards(selectedList.id).AsReadOnly();

                selectedCard = null;

                lbCards.SelectedItem = -1;

                lbCards.Items.Clear();

                foreach (Card card in selectedList.cards)
                {
                    lbCards.Items.Add(card.name);
                }

                lblMessage.Text = "";

                tbCardName.Text = "";
                tbCardDesription.Text = "";
                lbCardPriorities.SelectedItem = 4;
                cbCardDeadline.Checked = false;

                tbCardName.Enabled = false;
                tbCardDesription.Enabled = false;
                lbCardPriorities.Enabled = false;
                cbCardDeadline.Enabled = false;
                dtpCardDeadline.Enabled = false;

                cbEditCard.Checked = false;

                cbEditCard.Enabled = false;
                cbDeleteCard.Enabled = false;

                lblMessage.Text = "";
            }
        }
    }
}