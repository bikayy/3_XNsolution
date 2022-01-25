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
    public partial class frmRegister : Form
    {
        UserService srv = null;

        public frmRegister()
        {
            InitializeComponent();
            srv = new UserService();
        }

        private void btnIDCheck_Click(object sender, EventArgs e)
        {
            txtID.Text = txtID.Text.Replace(" ", "");
            bool check = srv.IDCheck(txtID.Text);
            if (string.IsNullOrWhiteSpace(txtID.Text.Trim()))
            {
                MessageBox.Show("아이디를 입력해주세요.");
                return;
            }
            if (!check)
            {
                txtID.ReadOnly = true;
                MessageBox.Show("회원가입이 가능한 아이디 입니다.");
            }
            else
            {
                MessageBox.Show("회원가입이 불가능한 아이디 입니다.");
            }
        }

        private void btnCreateID_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text.Trim()))
            {
                MessageBox.Show("아이디를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword1.Text.Trim()))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword2.Text.Trim()))
            {
                MessageBox.Show("비밀번호를 입력해주세요.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text.Trim()))
            {
                MessageBox.Show("이름을 입력해주세요.");
                return;
            }
            UserVO user = new UserVO()
            {
                
                User_ID = txtID.Text,
                User_PW = txtPassword1.Text,
                User_Name = txtName.Text
            };
            DialogResult message = MessageBox.Show("회원 가입 하시겠습니까?", "회원가입", MessageBoxButtons.YesNo);
            if (message == DialogResult.Yes)
            {
                bool result = false;

                result = srv.AddID(user);
                if (result)
                {
                    MessageBox.Show("회원가입 완료");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("회원가입 실패");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
