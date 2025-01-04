using System;
using System.Linq;
using System.Windows.Forms;

namespace EntityFrameworkDbFirstProduct
{
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        DbProductEntities entities = new DbProductEntities();
        Category category = new Category();

        private void clearTextAreas()
        {
            TxtCategoryId.Clear();
            TxtCategoryName.Clear();
        }

        private void CategoryList()
        {
            dataGridView1.DataSource = entities.Category.ToList();
        }
        private void addToCategory()
        {
            string categoryName = TxtCategoryName.Text.Trim();
            if (categoryName.Length >= 2 && categoryName != "")
            {
                category.CategoryName = categoryName.ToString();
                entities.Category.Add(category);
                entities.SaveChanges();
                CategoryList();
                clearTextAreas();
            }
            else
            {
                MessageBox.Show("Hatalı veri girişi", "Tekrar deneyiniz", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private void deleteCategory()
        {
            int categoryId = Convert.ToInt32(TxtCategoryId.Text.Trim());
            if(categoryId >= 0)
            {
                var value = entities.Category.Find(categoryId);
                entities.Category.Remove(value);
                entities.SaveChanges();
                CategoryList();
                clearTextAreas();
            }
            else
            {
                MessageBox.Show("Hatalı veri girişi ", "Lütfen tekrar deneyiniz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updateCategory()
        {
            string categoryName = TxtCategoryName.Text.Trim();
            int categoryId = Convert.ToInt32(TxtCategoryId.Text.Trim());
            var values = entities.Category.Find(categoryId);
            
            if (categoryId.ToString() != "" && categoryName.Length>=2)
            {
                values.CategoryName = categoryName.ToString();
                entities.SaveChanges();
                CategoryList();
                clearTextAreas();
            }   
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            addToCategory();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            deleteCategory();
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            updateCategory();
        }
    }
}
