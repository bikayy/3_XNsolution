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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text.Trim()))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                MessageBox.Show("아이디와 비밀번호를 입력해주세요.");
                return;
            }
            this.Hide();
            Main main = new Main(txtID.Text.Trim());
            main.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister Regi = new frmRegister();
            Regi.Show();
        }

        
    }
}
