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
using System.Diagnostics;

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
        /// <summary>
        /// highlight the row and unlock next button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // row selected
            var row = Convert.ToString(ProductsDataGridView.Rows[e.RowIndex]);
            //int selectedProductID = Convert.ToInt32(row);
            Debug.WriteLine(row);
        }
    }
}
