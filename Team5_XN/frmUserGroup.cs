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

namespace Team5_XN
{
    public partial class frmUserGroup : Form
    {
        DataTable list;
        UserService UserServ = new UserService();
        Main main = null;

        public frmUserGroup()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvUserGroup.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserGroup);

            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹코드", "UserGroup_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹명", "UserGroup_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용여부", "Use_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "Admin 여부", "Admin", colWidth: 100);
            list = UserServ.GetUserGroupMaster();
            dgvUserGroup.DataSource = list;
        }
    }
}
