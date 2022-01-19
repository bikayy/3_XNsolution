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
    public partial class PopupNopSearch : Form
    {
        NopCodeService nopServ = null;
        List<NopCodeVO> list = null;

        NopCodeVO sendInfo = new NopCodeVO();
        public NopCodeVO Send
        {
            get { return sendInfo; }
            set { sendInfo = value; }
        }
        public PopupNopSearch()
        {
            InitializeComponent();
        }

        private void PopupNopSearch_Load(object sender, EventArgs e)
        {
            nopServ = new NopCodeService();

            LoadData();
        }

        private void LoadData()
        {
            dgvList.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvList);
            DataGridViewUtil.AddGridTextColumn(dgvList, "비가동 대분류 코드", "Nop_Ma_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "비가동 대분류 명", "Nop_Ma_Name", colWidth: 120);

            list = nopServ.GetNopList();
            dgvList.DataSource = list;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string groupCode = dgvList[0, e.RowIndex].Value.ToString();

            List<NopCodeVO> groupList = (List<NopCodeVO>)dgvList.DataSource;
            NopCodeVO searchGroup = groupList.Find((nop) => nop.Nop_Ma_Code == groupCode);

            if (searchGroup != null)
            {
                txtNopCode.Text = searchGroup.Nop_Ma_Code;
                txtNopName.Text = searchGroup.Nop_Ma_Name;
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

            List<NopCodeVO> listFilter = null;

            listFilter = (from nop in list
                          where nop.Nop_Ma_Code.Contains(search)
                          || nop.Nop_Ma_Name.Contains(search)
                          select nop).ToList();

            dgvList.DataSource = listFilter;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtNopCode.Text = "";
            txtNopName.Text = "";
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sendInfo.Nop_Ma_Code = txtNopCode.Text;
            sendInfo.Nop_Ma_Name = txtNopName.Text;
        }
    }
}
