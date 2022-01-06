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

    public partial class frmUserInfo : Form
    {
        DataTable list;
        UserService UserServ = new UserService();
        Main main = null;
        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            LoadData();
        }

        private void OnSelect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadData()
        {
            dgvUserInfo.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserInfo);

            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용자 ID", "User_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용자 이름", "User_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "권한그룹 코드", "Customer_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "권한그룹 명", "UserGroup_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "기본 공정 코드", "Default_Major_Process_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "기본 공정 명", "Process_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "IP 보안 적용여부", "IP_Security_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "패스워드 초기화 횟수", "PW_Reset_Count", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용여부", "Use_YN", colWidth: 100);
            list = UserServ.GetUserInfo();
            dgvUserInfo.DataSource = list;
        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            //UserServ.UpdateID();
        }
    }
}
