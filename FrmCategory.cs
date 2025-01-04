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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }
        DbProductEntities entities = new DbProductEntities();
        Category category = new Category();

        private void clearTextAres()
        {
            TxtCategoryId.Clear();
            TxtCategoryName.Clear();
        }

        private void CategoryList()
        {
            dataGridView1.DataSource= entities.Category.ToList(); 
        }
        private void addToCategory()
        {
            
        }


        private void BtnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }
    }
}
