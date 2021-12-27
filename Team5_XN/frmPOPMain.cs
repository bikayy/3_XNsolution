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
    public partial class frmPOPMain : Form
    {
        public frmPOPMain()
        {
            InitializeComponent();
        }

        private void 작업장선택ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POPWorkCenter pop = new POPWorkCenter();
            pop.MdiParent = this;
            pop.WindowState = FormWindowState.Maximized;
            pop.Show();
        }

        private void 작업지시현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POPWorkOrderStatus pop = new POPWorkOrderStatus();
            pop.MdiParent = this;
            pop.WindowState = FormWindowState.Maximized;
            pop.Show();
        }

        private void 비가동등록ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            POPNopRegister pop = new POPNopRegister();
            pop.MdiParent = this;
            pop.WindowState = FormWindowState.Maximized;
            pop.Show();
        }
    }
}
