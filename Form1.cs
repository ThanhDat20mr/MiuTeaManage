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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MiuTeaEntities con = new MiuTeaEntities();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (con.ACCOUNTs.Where(p => p.Username == txtUsername.Text && p.Password == txtPwd.Text).Count() > 0)
            {
                MessageBox.Show("Login successful");
                fHome f = new fHome();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", " Message", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            fResign f = new fResign();
            f.ShowDialog();
            this.Show();
           
        }
    }
}
