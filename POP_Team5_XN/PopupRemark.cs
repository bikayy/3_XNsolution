using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POP_Team5_XN
{
    public partial class PopupRemark : Form
    {
        private string msg = string.Empty;
        public string GetMsg { get { return msg; } set { msg = value; } }

        public PopupRemark()
        {
            InitializeComponent();
        }

        private void PopupRemark_Load(object sender, EventArgs e)
        {
            textBox1.Text = msg;
        }
    }
}
