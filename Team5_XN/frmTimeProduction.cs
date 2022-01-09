using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public partial class frmTimeProduction : Form
    {
        WorkCenterService wserv;
        CommonService cserv;

        DataTable dt;

        DataView dv_SerchList; //선택한 조회조건별 검색 리스트

        Main main = null;


        public frmTimeProduction()
        {
            InitializeComponent();
        }

        private void frmTimeProduction_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;

            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장코드", "Wc_Code", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장명", "Wc_Name", colWidth: 250, align: DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장그룹", "Wc_Group", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정코드", "Process_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정명", "Process_Name", colWidth: 150);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "모니터링여부", "Monitoring_YN", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "팔렛생성유무", "Pallet_YN", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "사용유무", "Use_YN", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비고", "Remark", colWidth: 150);


            string[] code = { "WC_STATUS" };

            //cdac = new CommonDAC();
            cserv = new CommonService();

            DataTable dtSysCode = cserv.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboWoStatus, "WC_STATUS", dtSysCode.Copy());
        }

        private void OnSelect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
