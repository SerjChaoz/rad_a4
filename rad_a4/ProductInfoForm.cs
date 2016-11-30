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
    public partial class ProductInfoForm : Form
    {
        public SelectForm previousForm;
        public bool openFromFile = Program.openFromFile;

        public ProductInfoForm()
        {
            InitializeComponent();
        }

        // method section
        /// <summary>
        /// this method save form information to file
        /// </summary>
        private static void saveToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // properties for save file
            saveFileDialog.Filter = "Text Files(*.txt) | *.txt ";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Title = "Save as";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result != DialogResult.Cancel)
            {
                // create an instance of writer object
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName, true);

                // write to file

                // close
                writer.Close();
            }
        }
        /// <summary>
        /// this method open file and use reader to get information
        /// </summary>
        private void OpenFile()
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

        /// <summary>
        /// fill form with information from product object
        /// </summary>
        private void fillForm()
        {
            throw new NotImplementedException();
        }

        // events section

        private void ProductInfoForm_Load(object sender, EventArgs e)
        {
            // add if statement here 
            if(openFromFile)
            {
                OpenFile();
                openFromFile = false;
            } else
            {
                fillForm();
            }
            
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            saveToFile();

        }
        /// <summary>
        /// go to next form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextButton_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.previousForm = this;
            orderForm.Show();
            this.Hide();
        }
        /// <summary>
        /// go to previous form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Hide();
        }
    }
}
