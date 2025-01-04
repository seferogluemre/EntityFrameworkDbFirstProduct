using System;
using System.Linq;
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

        // CRUD METHODS 
        private void clearTextBoxes()
        {
            TxtProductId.Clear();
            TxtProductName.Clear();
            TxtProductPrice.Clear();
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

            if (productName.Length >= 2 && productPrice.ToString() != "" && productStock.ToString() != "")
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
        private void deleteProduct()
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Ürünü silmek istediginize emin misiniz", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            int productId = int.Parse(TxtProductId.Text.Trim());
            if (productId.ToString() != "")
            {
                if (dialog == DialogResult.Yes)
                {
                    var values = database.Product.Find(productId);
                    database.Product.Remove(values);
                    database.SaveChanges();
                    ProductList();
                    clearTextBoxes();
                }
            }
            else
            {
                MessageBox.Show("Hatalı id girişi", "Lütfen tekrar deneyiniz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void FrmProduct_Load(object sender, EventArgs e)
        {
            ProductList();
            var values = database.Category.ToList();
            CmbProductCategory.ValueMember = "CategoryId";
            CmbProductCategory.DisplayMember = "CategoryName";
            CmbProductCategory.DataSource = values;
            dataGridView1.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            deleteProduct();
        }
    }
}
