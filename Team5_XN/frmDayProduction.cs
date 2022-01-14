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
    public partial class frmDayProduction : Form
    {

        DayProductionService dserv;
        CommonService cserv;

        DataTable dt;
        //DataTable dt_Chart;

        DataView dv_SerchList; //선택한 조회조건별 검색 리스트

        Main main = null;
        DateTime date;

        public frmDayProduction()
        {
            InitializeComponent();
        }

        private void frmTimeProduction_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Reset += OnReset;

            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "WorkOrderNo", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정", "Process_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장", "Wc_Name", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "제품코드", "Item_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "제품명", "Item_Name", colWidth: 180);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "계획수량", "Plan_Qty_Box", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산수량", "Prd_Qty", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "달성률(%)", "Achieve_Rate", colWidth: 90);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산시작", "Prd_StartTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산종료", "Prd_EndTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산시간(hr)", "Prd_Time", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "시간당생산량", "Prd_Qty_Time", colWidth: 90);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산수량(BOX)", "Prd_Qty_Box", colWidth: 80);

            dataGridView1.Columns["Prd_StartTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dataGridView1.Columns["Prd_EndTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
           
            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

        }




        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;


            dserv = new DayProductionService();
            dt = dserv.GetDayProduction(dateTimePicker1.Value, dateTimePicker2.Value);
            dataGridView1.DataSource = dt;

            dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtProcessName.Text))
            {
                sb.Append(" AND Process_Name = '" + txtProcessName.Text + "'");
            }
            if (!string.IsNullOrWhiteSpace(txtWcName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Wc_Name = '" + txtWcName.Text + "'");
            }
            if (!string.IsNullOrWhiteSpace(txtWorkOrderNo.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND WorkOrderNo LIKE '%" + txtWorkOrderNo.Text + "%'");
            }

            dv_SerchList.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv_SerchList.ToTable();


        }

        private void OnReset(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
            txtProcessCode.Text = txtProcessName.Text = txtWcCode.Text = txtWcName.Text = txtWorkOrderNo.Text = "";
        }



        private void btnSelectProcess_Click(object sender, EventArgs e)
        {
            PopupSearchProcess sp = new PopupSearchProcess();
            if (sp.ShowDialog() == DialogResult.OK)
            {
                txtProcessCode.Text = sp.Send.Process_Code;
                txtProcessName.Text = sp.Send.Process_Name;

            }
        }

        private void btnSelectWc_Click(object sender, EventArgs e)
        {
            PopupWCSearch sw = new PopupWCSearch();
            if (sw.ShowDialog() == DialogResult.OK)
            {
                txtWcCode.Text = sw.Send.Wc_Code;
                txtWcName.Text = sw.Send.Wc_Name;
            }
        }


        //private void dateTimePicker1_ValueChanged(object sender, CancelEventArgs e)
        //{
        //    if (!(dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date))
        //    {
        //        MessageBox.Show("선택한 생산일자의 시작 일자가 종료 일자보다 이후일 수 없습니다.");
        //        e.Cancel = true;
        //    }
        //}

        private void dateTimePicker_Enter(object sender, EventArgs e)
        {
            date = ((DateTimePicker)sender).Value;
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!(dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date))
            {
                MessageBox.Show("선택한 생산일자의 시작 일자가 종료 일자보다 이후일 수 없습니다.");
                ((DateTimePicker)sender).Value = date;
                return;

            }
            date = ((DateTimePicker)sender).Value;
        }
    }
}
