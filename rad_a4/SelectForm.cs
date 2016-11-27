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

        product orderedProduct = Program.orderedProduct;
        // add db connection variable
        public ProductsContext db = new ProductsContext();

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
        /// data grid click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowSelected(e);
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
        // form methods
        /// <summary>
        /// this method select data from products table and add it to data grid biew
        /// </summary>
        private void getProducts()
        {
            
            // select from db
            List<product> productList = (from product in db.products select product).ToList();

            // fill data grid view from product list
            ProductsDataGridView.DataSource = productList;
        }
        /// <summary>
        /// highlight the row and unlock next button
        /// </summary>
        /// <param name="e"></param>
        private void rowSelected(DataGridViewCellEventArgs e)
        {
            // row selected
            var row = ProductsDataGridView.Rows[e.RowIndex];
            row.Selected = true;
            // get product ID
            int selectedProductID = Convert.ToInt32(row.Cells[0].Value);
            // get product from DB
            var selectedProduct = (from product
                                   in db.products
                                   where product.productID == selectedProductID
                                   select product).FirstOrDefault();

            // store data in product object
            orderedProduct = selectedProduct;

            // put data from object to text field
            SummaryTextBox.Text = orderedProduct.manufacturer + " " + orderedProduct.model +
                ". Priced at: $" + Math.Round(Convert.ToDouble(orderedProduct.cost), 2);
            // unlock next button
            NextButton.Enabled = true;
        }
    }
}
