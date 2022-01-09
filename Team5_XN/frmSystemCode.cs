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
        }

        private void dgvSysMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
