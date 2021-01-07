using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaterialDAL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            BL.Material.IMaterialBL material = new BL.Material.MaterialSQLiteBL();

            if (material.add(new Models.Material("natah", "Kies", 2000, 10)))
                MessageBox.Show("تمت الإضافة بنجاح");
            else
                MessageBox.Show("هناك خطأ بالإضافة");
        }

        private void btnExecuteReturned_Click(object sender, EventArgs e)
        {
            BL.Material.IMaterialBL material = new BL.Material.MaterialSQLiteBL();

            if (material.update(new Models.Material(3,"Theen", "Shwal", 12000, 8)))
                MessageBox.Show("تم الحذف بنجاح");
            else
                MessageBox.Show("هناك خطأ بالحذف");
        }

        private void btnSelectData_Click(object sender, EventArgs e)
        {
            BL.Material.IMaterialBL material = new BL.Material.MaterialSQLiteBL();

            dataGridView1.DataSource = material.selectAllMaterials();
        }
    }
}
