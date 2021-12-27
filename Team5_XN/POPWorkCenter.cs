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
    public partial class POPWorkCenter : Form
    {
        public POPWorkCenter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POPWorkOrderStatus pop = new POPWorkOrderStatus();
            pop.ShowDialog();
            this.Hide();
        }
    }
}
