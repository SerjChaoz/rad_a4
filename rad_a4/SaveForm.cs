﻿// RAD-Assignment4, Sergei #200325005, 30-11-2016. 
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
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Confirm",MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes) {
                    // create writer
                    StreamWriter writer = new StreamWriter("Name2s.txt", true);
                    writer.WriteLine(FirstNameTextBox.Text + " " + LastNameTextBox.Text);

                    // close connections
                    writer.Close();

                    // reset the form fields
                    FirstNameTextBox.Clear();
                    LastNameTextBox.Clear();

                    FirstNameTextBox.Focus();
                }
                else
                {
                    FirstNameTextBox.Focus();
                    FirstNameTextBox.SelectAll();
                }
                

            } catch
            {
                Console.WriteLine("problems");
            }
            
        }
    }
}
