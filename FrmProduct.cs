using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDbFirstProduct
{
    public partial class FrmProduct : Form
    {
        public FrmProduct()
        {
            InitializeComponent();
        }
        DbProductEntities database = new DbProductEntities();
        Product TableProduct = new Product();

        private void clearTextBoxes()
        {
            TxtProductId.Clear();
            TxtProductName.Clear();
            TxtProductPrice.Clear ();
            TxtProductStock.Clear();
            CmbProductCategory.Text = "";
        }

        private void ProductList()
        {
            dataGridView1.DataSource = database.Product.ToList();
        }
        private void AddProduct()
        {
            string productName = TxtProductName.Text.Trim();
            int productStock = int.Parse(TxtProductStock.Text.Trim());
            decimal productPrice = decimal.Parse(TxtProductPrice.Text.Trim());
            int selectedCategory = int.Parse(CmbProductCategory.SelectedValue.ToString());
            
            if(productName.Length >= 2 && productPrice.ToString() != "" && productStock.ToString()!="") 
            {
                TableProduct.ProductName = productName.ToString();
                TableProduct.ProductPrice = productPrice;
                TableProduct.ProductStock = productStock;
                TableProduct.CategoryId = selectedCategory;
                database.Product.Add(TableProduct);
                database.SaveChanges();
                ProductList();
                
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız", "Alanları kontrol ediniz", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }





        private void FrmProduct_Load(object sender, EventArgs e)
        {
            ProductList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }
    }
}
