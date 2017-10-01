using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MegaDesk_3_JesusArredondo
{
    public partial class AddQuote : Form
    {
        MainMenuForm mainMenu;
        const int MIN_WITH = 24;
        public int MAX_WITH = 96;
        const int MIN_DEPTH = 12;
        const int MAX_DEPTH = 48;

        public AddQuote(MainMenuForm mainMenuForm)
        {
            InitializeComponent();
            mainMenu = mainMenuForm;
            this.SaveQuote.Enabled = false;
            this.setDate(DateTime.Today);
            
        }


        private void MainMenuButton_Click(object sender, EventArgs e)
        {
            mainMenu.Show();
            this.Hide();
        }

        public int getDeskWidth() {
            return Convert.ToInt32(this.DeskWidth.Text);
        }

        public int getDeskDepth() {
            return Convert.ToInt32(this.DeskDepth.Text);
        }

        public int getDeskDrawers() {
            return Convert.ToInt32(this.DeskDrawers.Text);
        }

        public String getClientName() {
            return this.ClientName.Text;
        }

        public int getRushDays() {
            return Convert.ToInt32(this.rushDays.Text);
        }

        public string getMaterial() {
            return this.Material.Text;
        }

        public void checkFields() {
            if (this.ClientName.Text != "" && this.DeskDepth.Text != "" && this.DeskWidth.Text != ""
                && this.DeskDrawers.Text != "" && this.rushDays.Text != "")
            {
                this.SaveQuote.Enabled = true;
            }
        }

        public bool checkWidth() {
            int width = Convert.ToInt32(this.DeskWidth.Text);

            if (width < MIN_WITH || width > MAX_WITH)
            {
                return false;
            }
            else {
                return true;
            }

        }

        public bool checkDepth() {
            int depth = Convert.ToInt32(this.DeskDepth.Text);

            if (depth < MIN_DEPTH || depth > MAX_DEPTH)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setSize(int size) {
            this.size.Text = size.ToString();
        }

        public void setPrice(int price) {
            this.Price.Text = price.ToString();
        }

        public void setDate(DateTime date) {
            this.TodayDate.Text = date.ToString();
        }

        private void SaveQuote_Click(object sender, EventArgs e)
        {
            DeskQuote deskQuote = new DeskQuote();
            deskQuote.saveQuote(this);
            this.SaveQuote.Enabled = false;
            System.Windows.Forms.MessageBox.Show("The quote has been saved successfully");
        }

        private void ClientName_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskWidth_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskDepth_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void rushDays_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void Material_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskDrawers_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskSurface_TextChanged(object sender, EventArgs e)
        {
            checkFields();
        }

        private void DeskWidth_Validating(object sender, CancelEventArgs e)
        {
            bool result = checkWidth();
            string errorMessage = "Width not correct";

            if (!result) {
                e.Cancel = true;
                DeskWidth.Select(0, DeskWidth.Text.Length);
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
        }

        private void DeskDepth_Validating(object sender, CancelEventArgs e)
        {
            bool result = checkDepth();
            string errorMessage = "Depth not correct";

            if (!result) {
                DeskWidth.Select(0, DeskWidth.Text.Length);
                System.Windows.Forms.MessageBox.Show(errorMessage);
            }
            
        }
    }
}
