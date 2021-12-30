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
    public partial class PopupSearch : Form
    {
        SearchService searchServ = null;
        List<SearchVO> list = null;

        SearchVO sendInfo = new SearchVO();
        public SearchVO Send 
        {
            get { return sendInfo; }
            set { sendInfo = value; }
        }

        public PopupSearch()
        {
            InitializeComponent();
        }

        private void PopupSearch_Load(object sender, EventArgs e)
        {   //Item_Code, Item_Name
            searchServ = new SearchService();

            LoadData();
        }

        private void LoadData()
        {
            dgvList.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvList);
            DataGridViewUtil.AddGridTextColumn(dgvList, "품목코드", "Item_Code", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "품목 명", "Item_Name", DataGridViewContentAlignment.MiddleLeft, colWidth: 120);

            list = searchServ.GetItemList();
            dgvList.DataSource = list;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string itemCode = dgvList[0, e.RowIndex].Value.ToString();

            List<SearchVO> itemLsit = (List<SearchVO>)dgvList.DataSource;
            SearchVO searchItem = itemLsit.Find((item) => item.Item_Code == itemCode);

            if (searchItem != null)
            {
                r_txtItemCode.Text = searchItem.Item_Code;
                r_txtItemName.Text = searchItem.Item_Name;
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

            List<SearchVO> listFilter = null;

            listFilter = (from item in list
                          where item.Item_Code.Contains(search)
                          || item.Item_Name.Contains(search)
                          select item).ToList();

            dgvList.DataSource = listFilter;

            //if (! string.IsNullOrWhiteSpace(txtItemCode.Text))
            //{
            //    listFilter = (from item in list
            //                  where item.Item_Code.Contains(code)
            //                  && item.Item_Name.Contains(name)
            //                  select item).ToList();

            //    //listFilter = (from item in list
            //    //              where item.Item_Name.Contains(name)
            //    //              select item).ToList();
            //}
            //else
            //{
            //    listFilter = (from item in list
            //                  where item.Item_Code.Contains(code)
            //                  select item).ToList();
            //}
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            r_txtItemCode.Text = "";
            r_txtItemName.Text = "";
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sendInfo.Item_Code = r_txtItemCode.Text;
            sendInfo.Item_Name = r_txtItemName.Text;
        }
    }
}
