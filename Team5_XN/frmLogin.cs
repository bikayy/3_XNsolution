using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN_VO;

namespace Team5_XN
{
    public partial class frmLogin : Form
    {
        UserService userServ;
        public frmLogin()
        {
            InitializeComponent();
            userServ = new UserService();
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
            UserVO user = new UserVO()
            {
                User_ID = txtID.Text,
                User_PW = txtPassword.Text
            };
            bool bResult = userServ.LoginCheck(user);

            if (bResult) // 로그인 성공
            {
                CurrentLoginID.LoginName = userServ.GetMemberName(txtID.Text);
                CurrentLoginID.LoginID = txtID.Text;
                //this.Visible = false; // 로그인창 가리기
                this.Hide();
                Main main = new Main(txtID.Text.Trim());
                if (main.ShowDialog() == DialogResult.OK)
                {
                    this.Visible = true;
                }
                else
                    Application.Exit();
            }
            else // 로그인 실패
            {
                MessageBox.Show("아이디 혹은 비밀번호가 맞지 않습니다.");
            }
            //this.Hide();
            //Main main = new Main(txtID.Text.Trim());
            //main.Show();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister Regi = new frmRegister();
            Regi.Show();
        }

        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin_Click(sender, e);
        }
    }
    public static class CurrentLoginID
    {
        public static string LoginID { get; set; }
        public static string LoginName { get; set; }
    } //현재로그인 아이디
}
