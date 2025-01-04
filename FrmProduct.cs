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

        string productName;
        decimal productPrice;
        int productStock;
        int selectedCategory;

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
            if(productName.Length >= 2 && productPrice.ToString() != "" && productStock.ToString()!="") 
            {
                TableProduct.ProductName = productName.ToString();
                TableProduct.ProductPrice = productPrice;
                TableProduct.ProductStock = productStock;
                TableProduct.CategoryId = selectedCategory;
                database.Product.Add(TableProduct);
                database.SaveChanges();
                ProductList();
                clearTextBoxes();
            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız", "Alanları kontrol ediniz", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }





        private void FrmProduct_Load(object sender, EventArgs e)
        {
            ProductList();
            productName = TxtProductName.Text.Trim();
            productPrice = decimal.Parse(TxtProductPrice.Text.Trim());
            productStock= int.Parse(TxtProductStock.Text.Trim());
            selectedCategory = int.Parse(CmbProductCategory.SelectedValue.ToString());
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
