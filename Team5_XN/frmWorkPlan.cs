using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public partial class frmWorkPlan : Form
    {
        public frmWorkPlan()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSearchPopup frm = new frmSearchPopup();
            frm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PopupCreatePlan frm = new PopupCreatePlan();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopupAddPlan frm = new PopupAddPlan();
            frm.ShowDialog();
        }
    }
}
