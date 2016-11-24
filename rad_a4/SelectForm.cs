using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rad_a4
{
    public partial class SelectForm : Form
    {
        public StartForm previousForm;

        public SelectForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Show();
            this.Hide();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            ProductInfoForm productInfoForm = new ProductInfoForm();
            productInfoForm.previousForm = this;
            productInfoForm.Show();
            this.Hide();

        }
    }
}
