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
    public partial class fHome : Form
    {
        public fHome()
        {
            InitializeComponent();
        }

        private void scriptAM_Click(object sender, EventArgs e)
        {
            this.Hide();
            fStaff f = new fStaff();
            f.ShowDialog();
            this.Show();
        }
    }
}
