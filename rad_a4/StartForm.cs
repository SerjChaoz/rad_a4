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
        public StartForm()
        {
            InitializeComponent();
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

        private void StartOrderButton_Click(object sender, EventArgs e)
        {
            SelectForm selectForm = new SelectForm();
            selectForm.previousForm = this;
            selectForm.Show();
            this.Hide();
        }

        private void OpenSavedOrderButton_Click(object sender, EventArgs e)
        {
            // create object open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // set properties
            openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog.Title = "Open File";
            openFileDialog.Filter = "Text Files(*.txt) | *.txt | All Files(*.*) | *.*";

            // open dialog box
            DialogResult result = openFileDialog.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                try
                {
                    // create reader
                    StreamReader reader = new StreamReader(openFileDialog.FileName);

                    // read in the data with readline to the object

                    // close the streams
                    reader.Close();
                        
                }
                catch (Exception)
                {
                    MessageBox.Show("Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

        }
    }
}
