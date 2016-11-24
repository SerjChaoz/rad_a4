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

        public ProductInfoForm()
        {
            InitializeComponent();
        }

        private void SaveToFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // properties for save file
            saveFileDialog.Filter = "Text Files(*.txt) | *.txt ";
            saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog.Title = "Save as";

            DialogResult result = saveFileDialog.ShowDialog();

            if(result != DialogResult.Cancel)
            {
                // create an instance of writer object
                StreamWriter writer = new StreamWriter(saveFileDialog.FileName, true);

                // write to file

                // close
                writer.Close();
            }

        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.previousForm = this;
            orderForm.Show();
            this.Hide();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            previousForm.Show();
            this.Hide();
        }
    }
}
