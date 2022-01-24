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
    public partial class PopupBoxingGrade : Form
    {
        BoxingGradeService boxServ = null;
        List<BoxingGradeVO> list = null;

        BoxingGradeVO sendInfo = new BoxingGradeVO();
        public BoxingGradeVO Send
        {
            get { return sendInfo; }
            set { sendInfo = value; }
        }
        public PopupBoxingGrade()
        {
            InitializeComponent();
        }

        private void PopupBoxingGrade_Load(object sender, EventArgs e)
        {
            boxServ = new BoxingGradeService();

            LoadData();
        }

        private void LoadData()
        {
            dgvList.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvList);
            DataGridViewUtil.AddGridTextColumn(dgvList, "포장등급 코드", "Boxing_Grade_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvList, "포장등급 명", "Boxing_Grade_Name", colWidth: 120);

            list = boxServ.GetBoxingGradeList();
            dgvList.DataSource = list;
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string groupCode = dgvList[0, e.RowIndex].Value.ToString();

            List<BoxingGradeVO> groupList = (List<BoxingGradeVO>)dgvList.DataSource;
            BoxingGradeVO searchGroup = groupList.Find((nop) => nop.Boxing_Grade_Code == groupCode);

            if (searchGroup != null)
            {
                txtBoxCode.Text = searchGroup.Boxing_Grade_Code;
                txtBoxName.Text = searchGroup.Boxing_Grade_Name;
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

            List<BoxingGradeVO> listFilter = null;

            listFilter = (from box in list
                          where box.Boxing_Grade_Code.Contains(search)
                          || box.Boxing_Grade_Name.Contains(search)
                          select box).ToList();

            dgvList.DataSource = listFilter;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtBoxCode.Text = "";
            txtBoxName.Text = "";
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sendInfo.Boxing_Grade_Code = txtBoxCode.Text;
            sendInfo.Boxing_Grade_Name = txtBoxName.Text;
        }
    }
}
