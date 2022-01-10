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
    public partial class frmSystemCode : Form
    {
        DataTable list;
        CommonService commServ = new CommonService();
        Main main = null;
        public frmSystemCode()
        {
            InitializeComponent();
        }

        private void pnlSelect_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSystemCode_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvSysMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysMaster);

            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류코드", "Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류명", "Name", colWidth: 200);
            list = commServ.GetSystemCodeMaster();
            dgvSysMaster.DataSource = list;
            
            dgvSysDetail.Columns.Clear();
            DataGridViewUtil.SetInitGridView(dgvSysDetail);

            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류코드", "DetailCode", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류명", "DetailName", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "사용여부", "UseYN", colWidth: 100);
            
        }

        private void dgvSysMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = Convert.ToString(dgvSysMaster.Rows[e.RowIndex].Cells[1].Value);
            list = commServ.GetSystemCodeDetail(name);
            dgvSysDetail.DataSource = list;
        }
    }
}
