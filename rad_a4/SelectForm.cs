using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using rad_a4.Modules;

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
        /// <summary>
        /// load event that runs get products method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectForm_Load(object sender, EventArgs e)
        {
            getProducts();
        }
        /// <summary>
        /// this method select data from products table and add it to data grid biew
        /// </summary>
        private void getProducts()
        {
            // add db connection variable
            ProductsContext db = new ProductsContext();

            // select from db
            List<product> productList = (from product in db.products select product).ToList();

            // fill data grid view from product list
            ProductsDataGridView.DataSource = productList;
        }
    }
}
