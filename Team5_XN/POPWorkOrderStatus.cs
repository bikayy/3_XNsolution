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
    public partial class POPWorkOrderStatus : Form
    {
        public POPWorkOrderStatus()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POPCreateWork pop = new POPCreateWork();
            pop.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            POPPalette pop = new POPPalette();
            pop.ShowDialog();
        }
    }
}
