// RAD-Assignment4, Sergei #200325005, 30-11-2016. 
// This program select product table from Microsoft Azure and put products list to Data Grid,
// user can choose any product, save and read from files
// final form show all data and calculate total cost
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace rad_a4
{
    public partial class StartForm : Form
    {
        public bool openFromFile = Program.openFromFile;
        public StartForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// create new select form and show it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartOrderButton_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm();
            selectForm.previousForm = this;
            selectForm.Show();
            this.Hide();
        }
        /// <summary>
        /// Create new product info form and show it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSavedOrderButton_Click(object sender, EventArgs e)
        {
            openFromFile = true;
            ProductInfoForm productInfoForm = new ProductInfoForm();
            productInfoForm.Show();
            this.Hide();
        }
        /// <summary>
        /// close application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
