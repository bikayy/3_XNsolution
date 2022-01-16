using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN_DAC;
using Team5_XN_VO;

namespace Team5_XN
{
    public partial class PopupUserGroup : Form
    {
        UserService userServ = null;
        List<UGSearchVO> list = null;

        UGSearchVO sendInfo = new UGSearchVO();
        public UGSearchVO Send
        {
            get { return sendInfo; }
            set { sendInfo = value; }
        }
        public PopupUserGroup()
        {
            InitializeComponent();
        }

        private void PopupUserGroup_Load(object sender, EventArgs e)
        {
            userServ = new UserService();

            LoadData();
        }

        private void LoadData()
        {
            dgvList.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvList);
            DataGridViewUtil.AddGridTextColumn(dgvList, "사용자그룹코드", "UserGroup_Code", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "사용자그룹명", "UserGroup_Name", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);

            list = userServ.GetUGList();
            dgvList.DataSource = list;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string groupCode = dgvList[0, e.RowIndex].Value.ToString();

            List<UGSearchVO> groupList = (List<UGSearchVO>)dgvList.DataSource;
            UGSearchVO searchGroup = groupList.Find((user) => user.UserGroup_Code == groupCode);

            if (searchGroup != null)
            {
                txtGroupCode.Text = searchGroup.UserGroup_Code;
                txtGroupName.Text = searchGroup.UserGroup_Name;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                MessageBox.Show("검색어를 입력해주세요.");
                return;
            }

            string search = txtSearch.Text.ToUpper().Trim();

            List<UGSearchVO> listFilter = null;

            listFilter = (from user in list
                          where user.UserGroup_Code.Contains(search)
                          || user.UserGroup_Name.Contains(search)
                          select user).ToList();

            dgvList.DataSource = listFilter;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtGroupCode.Text = "";
            txtGroupName.Text = "";
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sendInfo.UserGroup_Code = txtGroupCode.Text;
            sendInfo.UserGroup_Name = txtGroupName.Text;
        }
    }
}
