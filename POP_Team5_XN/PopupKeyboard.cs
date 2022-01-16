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
    public partial class PopupKeyboard : Form
    {
        int qty = 0;
        public int SendQty { get { return qty; } set { qty = value; } }

        public PopupKeyboard()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            qty = int.Parse(qty.ToString() + btn.Text);

            txtQty.Text = qty.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            qty = 0;
            txtQty.Text = "";
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            int txtLength = txtQty.Text.Length;
            if (txtLength > 0)
            {
                txtQty.Text = txtQty.Text.Substring(0, txtLength - 1);
            }
            txtQty.SelectionStart = txtQty.Text.Length;
            txtQty.SelectionLength = 0;
            qty = int.Parse(txtQty.Text);
        }

    }
}
