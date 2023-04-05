using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MiuTea
{
    public partial class fStaff : Form
    {
        public fStaff()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            using (MiuTeaEntities db = new MiuTeaEntities())
            {
                var result = from c in db.ACCOUNTs
                             select new { Username = c.Username, Password = c.Password, ID = c.ID, Name = c.STAFF.Name, Gender = c.STAFF.Gender, DOB = c.STAFF.DOB, Phone = c.STAFF.Phone, Address = c.STAFF.Address };

                dtgvAcc.DataSource = result.ToList();
                dtgvAcc.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        MiuTeaEntities con = new MiuTeaEntities();
        void AddBinding()
        {
            txtID.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtName.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtUsername.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "Username", true, DataSourceUpdateMode.Never));
            txtPwd.DataBindings.Add(new Binding("Text", dtgvAcc.DataSource, "Password", true, DataSourceUpdateMode.Never));

        }
        
        private void dtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvAcc.CurrentRow.Index;
            txtUsername.Text = dtgvAcc.Rows[i].Cells[0].Value.ToString();
            txtPwd.Text = dtgvAcc.Rows[i].Cells[1].Value.ToString();
            txtID.Text = dtgvAcc.Rows[i].Cells[2].Value.ToString();
            txtName.Text = dtgvAcc.Rows[i].Cells[3].Value.ToString();
            txtGender.Text = dtgvAcc.Rows[i].Cells[4].Value.ToString();
            dpDOB.Text = dtgvAcc.Rows[i].Cells[5].Value.ToString();
            txtPhone.Text = dtgvAcc.Rows[i].Cells[6].Value.ToString();
            txtAddress.Text = dtgvAcc.Rows[i].Cells[7].Value.ToString();
        }
    }
}
