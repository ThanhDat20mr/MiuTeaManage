using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiuTea
{
    public partial class fResign : Form 
    {
        public fResign()
        {
            InitializeComponent();
        }
        string gender;

        MiuTeaEntities con = new MiuTeaEntities();
        void removeError()
        {
            errorProvider1.SetError(txtUsername, null);
            errorProvider1.SetError(txtName, null);
            errorProvider1.SetError(txtID, null);
            errorProvider1.SetError(txtPwd, null);
            errorProvider1.SetError(txtPhone, null);
            errorProvider1.SetError(txtAddress, null);
            errorProvider1.SetError(txtRepwd, null);
        }
        void setError()
        {
            if (string.IsNullOrEmpty(txtUsername.Text)|| con.ACCOUNTs.Where(p => p.Username == txtUsername.Text).Count() > 0   || string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtID.Text) || con.ACCOUNTs.Where(p => p.ID == txtID.Text).Count() > 0|| string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtPwd.Text)|| string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtPhone.Text) || string.IsNullOrEmpty(txtRepwd.Text) || txtRepwd.Text.CompareTo(txtPwd.Text) != 0)
            {
                if (con.ACCOUNTs.Where(p => p.Username == txtUsername.Text).Count() > 0 || string.IsNullOrEmpty(txtUsername.Text))
                {
                    if (string.IsNullOrEmpty(txtUsername.Text))
                    {
                        errorProvider1.SetError(txtUsername, "Không được để trống");
                    }
                    else
                    {
                        errorProvider1.SetError(txtUsername, "Already exist");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtUsername, null);
                }                
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    errorProvider1.SetError(txtName, "Vui lòng nhập tên.");
                }
                else
                {
                    errorProvider1.SetError(txtName, null);
                }
                if (con.ACCOUNTs.Where(p => p.ID == txtID.Text).Count() > 0 || string.IsNullOrEmpty(txtID.Text))
                {
                    if (string.IsNullOrEmpty(txtID.Text))
                    {
                        errorProvider1.SetError(txtID, "Không được để trống");
                    }
                    else
                    {
                        errorProvider1.SetError(txtID, "Already exist");
                    }
                }
                else
                {
                    errorProvider1.SetError(txtID, null);
                }
                if (string.IsNullOrEmpty(txtPwd.Text))
                {
                    errorProvider1.SetError(txtPwd, "Vui lòng nhập mật khẩu.");
                }
                else
                {
                    errorProvider1.SetError(txtPwd, null);
                }
                if (string.IsNullOrEmpty(txtRepwd.Text))
                {
                    errorProvider1.SetError(txtRepwd, "Vui lòng nhập lại mật khẩu.");
                }
                else
                {
                    errorProvider1.SetError(txtRepwd, null);
                }
                if (txtRepwd.Text.CompareTo(txtPwd.Text) != 0)
                {
                    errorProvider1.SetError(txtRepwd, "Không giống mật khẩu đã nhập.");
                }
                else
                {
                    errorProvider1.SetError(txtRepwd, null);
                }
                if (string.IsNullOrEmpty(txtAddress.Text))
                {
                    errorProvider1.SetError(txtAddress, "Vui lòng nhập địa chỉ.");
                }
                else
                {
                    errorProvider1.SetError(txtAddress, null);
                }
                if (string.IsNullOrEmpty(txtPhone.Text))
                {
                    errorProvider1.SetError(txtPhone, "Vui lòng nhập số điện thoại.");
                }
                else
                {
                    errorProvider1.SetError(txtPhone, null);
                }

            }
            else
            {

                MessageBox.Show("Register successful!");
                using (MiuTeaEntities db = new MiuTeaEntities())
                {
                    if (radbtnNam.Checked)
                    {
                        gender = "Nam";
                    }
                    if (radbtnNu.Checked)
                    {
                        gender = "Nu";
                    }
                    db.ACCOUNTs.Add(new ACCOUNT() { ID = txtID.Text, Username = txtUsername.Text, Password = txtPwd.Text });
                    db.STAFFs.Add(new STAFF() { ID = txtID.Text, Name = txtName.Text, Address = txtAddress.Text, Phone = txtPhone.Text, Gender = gender, DOB = dpDOB.Value });
                    db.SaveChanges();
                    this.Close();
                    removeError();
                }
            }
            
        }
        private void listAcc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {           
            setError();
        }
        private void fResign_Load(object sender, EventArgs e)
        {

        }
  
    }

}