using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Team5_XN
{
    public partial class frmTimeProduction : Form
    {
        TimeProductionService tserv;
        CommonService cserv;

        DataTable dt;
        //DataTable dt_Chart;

        DataView dv_SerchList; //선택한 조회조건별 검색 리스트

        Main main = null;
        DateTime date;
        //private event Myevent;
        CancelEventArgs args = new CancelEventArgs();
        static public event CancelEventHandler MyEvent;
        //_myEvent.DynamicInvoke(new object[] { this, args });


        public frmTimeProduction()
        {
            InitializeComponent();
        }


        private void frmTimeProduction_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Reset += OnReset;

            MyEvent += OnMyEvent;

            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업지시상태", "Wo_Status", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "WorkOrderNo", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업지시일자", "Plan_Date", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업지시수량", "Plan_Qty_Box", colWidth: 80);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장", "Wc_Name", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정", "Process_Name", colWidth: 130);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "품목코드", "Item_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "품목명", "Item_Name", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "퓸목명(영문)", "Item_Name_Eng", colWidth: 180);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산일자", "Prd_Date", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산시작", "Prd_StartTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산종료", "Prd_EndTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산수량", "Prd_Qty", colWidth: 70);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산수량(BOX)", "Prd_Qty_Box", colWidth: 80);

            dataGridView1.Columns["Prd_StartTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            dataGridView1.Columns["Prd_EndTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";


            string[] code = { "WO_STATUS" };

            //cdac = new CommonDAC();
            cserv = new CommonService();

            DataTable dtSysCode = cserv.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboWoStatus, "WO_STATUS", dtSysCode.Copy());

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

        }



        private void OnMyEvent(object sender, CancelEventArgs e)
        {
            if (!(dateTimePicker1.Value.Date <= dateTimePicker2.Value.Date))
            {
                MessageBox.Show("선택한 생산일자의 시작 일자가 종료 일자보다 이후일 수 없습니다.");
                e.Cancel = true;
            }
        }



        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;


            tserv = new TimeProductionService();
            dt = tserv.GetTimeProduction(dateTimePicker1.Value, dateTimePicker2.Value);
            //dataGridView1.DataSource = dt;

            dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtSelectItemCode.Text))
            {
                sb.Append(" AND Item_Code LIKE '%" + txtSelectItemCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectProcessCode.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Process_Name LIKE '%" + txtSelectProcessName.Text + "%'");
            }
            if (!cboWoStatus.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Wo_Status = '" + cboWoStatus.Text + "'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectWoNo.Text))
            {
                sb.Append(" AND WorkOrderNo LIKE '%" + txtSelectWoNo.Text + "%'");
            }

            dv_SerchList.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv_SerchList;
            chart1.Series.Clear();
            if (dataGridView1.Rows.Count > 0)
                dataGridView1_RowEnter(dataGridView1, new DataGridViewCellEventArgs(0, 0));

        }

        private void OnReset(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            dateTimePicker1.Value = dateTimePicker2.Value = DateTime.Now;
            txtSelectProcessCode.Text = txtSelectProcessName.Text = txtSelectItemCode.Text = txtSelectItemName.Text = "";
            cboWoStatus.SelectedIndex = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Chart(dataGridView1["WorkOrderNo", e.RowIndex].Value.ToString());
        }

        private void Chart(string workOrderNo)
        {
            chart1.Series.Clear();

            chart1.Series.Add(new Series("Series"));
            chart1.Series[0].ChartType = SeriesChartType.Column;

            //chart1.Series[0].LegendText = "시간대별 실적";

            //chart1.Legends[0].Alignment = StringAlignment.Center;
            //chart1.Legends[0].Docking = Docking.Top;


            DataTable chart = tserv.GetTimeProduction_Chart(workOrderNo);

            chart1.DataSource = chart;

            //chart1.Series[0].Points.x
            chart1.Series[0].XValueMember = "Start_Hour";
            chart1.Series[0].YValueMembers = "Prd_Qty";
            chart1.Series[0].IsValueShownAsLabel = true; //각 요소 값 출력
            chart1.Series[0].IsVisibleInLegend = false; //범례 숨기기


            //chart1.ChartAreas[0].AxisX.Minimum = 8; //X축(시간) 최소값 고정
            //chart1.ChartAreas[0].AxisX.Maximum = 23;//X축(시간) 최대값 고정
            chart1.ChartAreas[0].AxisX.Interval = 1; //X축 간격 설정
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //X축 그리드 숨기기

            chart1.ChartAreas[0].AxisX.Title = "시간";
            chart1.ChartAreas[0].AxisY.Title = "생산량";


            chart1.DataBind();

        }

        private void btnSelectProcess_Click(object sender, EventArgs e)
        {
            PopupSearchProcess sp = new PopupSearchProcess();

            if (sp.ShowDialog() == DialogResult.OK)
            {
                txtSelectProcessCode.Text = sp.Send.Process_Code;
                txtSelectProcessName.Text = sp.Send.Process_Name;
            }
        }

        private void btnSelectItem_Click(object sender, EventArgs e)
        {
            PopupSearch si = new PopupSearch();
            if (si.ShowDialog() == DialogResult.OK)
            {
                txtSelectItemCode.Text = si.Send.Item_Code;
                txtSelectItemName.Text = si.Send.Item_Name;
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

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            Chart(dataGridView1["WorkOrderNo", e.RowIndex].Value.ToString());
        }
    }
}
