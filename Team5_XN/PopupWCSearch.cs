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
    public partial class PopupWCSearch : Form
    {
        SearchService searchServ = null;
        List<WCSearchVO> list = null;

        private WCSearchVO sendInfo = new WCSearchVO();
        public WCSearchVO Send { get { return sendInfo; } set { sendInfo = value; } }

        public PopupWCSearch()
        {
            InitializeComponent();
        }

        private void PopupWCSearch_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {  ////Wc_Code, Wc_Name, Wc_Group, Process_Name
            searchServ = new SearchService();
            dgvList.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvList);
            DataGridViewUtil.AddGridTextColumn(dgvList, "작업장코드", "Wc_Code", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "작업장 명", "Wc_Name", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "작업장 그룹", "Wc_Group", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "공정 명", "Process_Name", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);

            list = searchServ.GetWCList();
            dgvList.DataSource = list;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string wcCode = dgvList[0, e.RowIndex].Value.ToString();

            List<WCSearchVO> wcLsit = (List<WCSearchVO>)dgvList.DataSource;
            WCSearchVO searchWc = wcLsit.Find((item) => item.Wc_Code == wcCode);

            if (searchWc != null)
            {
                r_txtWcCode.Text = searchWc.Wc_Code;
                r_txtWcName.Text = searchWc.Wc_Name;
                r_txtPrcName.Text = searchWc.Process_Name;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            r_txtWcCode.Text = "";
            r_txtWcName.Text = "";
            r_txtPrcName.Text = "";
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sendInfo.Wc_Code = r_txtWcCode.Text;
            sendInfo.Wc_Name = r_txtWcName.Text;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            r_txtWcCode.Text = "";
            r_txtWcName.Text = "";
            r_txtPrcName.Text = "";

            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                MessageBox.Show("검색어를 입력해주세요.");
                return;
            }

            string search = txtSearch.Text.ToUpper().Trim();

            List<WCSearchVO> listFilter = null;

            listFilter = (from item in list
                          where item.Wc_Code.Contains(search)
                          || item.Wc_Name.Contains(search)
                          ||item.Wc_Group.Contains(search)
                          ||item.Process_Name.Contains(search)
                          select item).ToList();

            dgvList.DataSource = listFilter;
        }
    }
}
