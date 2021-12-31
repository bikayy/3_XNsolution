using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN.Service;
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
            UserVO customer = new UserVO()
            {
                
                User_ID = txtID.Text,
                User_PW = txtPassword1.Text,
                User_Name = txtName.Text
            };

            bool result = false;

            result = srv.AddID(customer);


            if (result)
            {
                MessageBox.Show("회원가입 완료");
                // this.Close();
            }
            else
            {
                MessageBox.Show("회원가입 실패");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
