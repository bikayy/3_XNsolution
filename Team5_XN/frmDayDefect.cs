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
    public partial class frmDayDefect : Form
    {
        DayProductionService dserv;
        CommonService cserv;

        DataTable dt;
        //DataTable dt_Chart;

        DataView dv_SerchList; //선택한 조회조건별 검색 리스트

        Main main = null;
        DateTime date;

        public frmDayDefect()
        {
            InitializeComponent();
        }

        private void frmDayDefect_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Reset += OnReset;


            //생산일자, 작업지시번호, 작업장명, 품목코드, 품목명, 계획수량, 생산수량, 불량수량, 불량률, 불량상세코드, 생산시작, 생산종료
            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업지시번호", "WorkOrderNo", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정", "Process_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장", "Wc_Name", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "제품코드", "Item_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "제품명", "Item_Name", colWidth: 180);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "계획수량", "Plan_Qty_Box", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산수량", "Prd_Qty", colWidth: 90);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "정상수량", "Good_Qty", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "불량수량", "Bad_Qty", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "불량률(%)", "Defect_Rate", colWidth: 90);

            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산시작", "Prd_StartTime", colWidth: 130);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산종료", "Prd_EndTime", colWidth: 130);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산시간(hr)", "Prd_Time", colWidth: 90);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "시간당생산량", "Prd_Qty_Time", colWidth: 90);
            //DataGridViewUtil.AddGridTextColumn(dataGridView1, "생산수량(BOX)", "Prd_Qty_Box", colWidth: 80);

            //dataGridView1.Columns["Prd_StartTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            //dataGridView1.Columns["Prd_EndTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
            dataGridView1.AutoGenerateColumns = false;
        }

        private void OnReset(object sender, EventArgs e)
        {
            
        }

        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;


            dserv = new DayProductionService();
            dt = dserv.GetDayDefect(dateTimePicker1.Value, dateTimePicker2.Value, txtProcessCode.Text, txtWcName.Text, txtWorkOrderNo.Text);

            dataGridView1.DataSource = dt;

            //dv_SerchList = new DataView(dt);

            //StringBuilder sb = new StringBuilder();
            //sb.Append(" 1 = 1 ");

            //if (!string.IsNullOrWhiteSpace(txtProcessName.Text))
            //{
            //    sb.Append(" AND Process_Name = '" + txtProcessName.Text + "'");
            //}
            //if (!string.IsNullOrWhiteSpace(txtWcName.Text))
            //{
            //    //if (sb.Length > 0) sb.Append(" AND ");
            //    sb.Append(" AND Wc_Name = '" + txtWcName.Text + "'");
            //}
            //if (!string.IsNullOrWhiteSpace(txtWorkOrderNo.Text))
            //{
            //    //if (sb.Length > 0) sb.Append(" AND ");
            //    sb.Append(" AND WorkOrderNo LIKE '%" + txtWorkOrderNo.Text + "%'");
            //}

            //dv_SerchList.RowFilter = sb.ToString();
            //dataGridView1.DataSource = dv_SerchList.ToTable();
            Chart(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void Chart(DateTime dateFrom, DateTime dateTo)
        {
            //chart1.Series.Clear();

            //chart1.Series.Add(new Series("chart0"));
            //chart1.Series.Add(new Series("chart1"));

            //chart1.Series[0].ChartType = SeriesChartType.Column;
            //chart1.Series[1].ChartType = SeriesChartType.Column;

            //chart1.Series[0].LegendText = "시간대별 실적";

            //chart1.Legends[0].Alignment = StringAlignment.Center;
            //chart1.Legends[0].Docking = Docking.Top;


            //DataTable chart = dserv.GetDayDefect_Chart(dateTimePicker1.Value, dateTimePicker2.Value);
            DataTable chart = dserv.GetDayDefect_Chart(dateTimePicker1.Value, dateTimePicker2.Value);

            DataView dv_Serchchart = new DataView(chart);

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
            dv_Serchchart.RowFilter = sb.ToString();
            DataTable dt2 = dv_Serchchart.ToTable();

            DataTable dt_temp = new DataTable();
            dt_temp.Columns.Add(new DataColumn("Prd_Date", typeof(string)));
            //dt_temp.Columns.Add(new DataColumn("workorderno", typeof(string)));
            //dt_temp.Columns.Add(new DataColumn("Item_Code", typeof(string)));
            //dt_temp.Columns.Add(new DataColumn("Item_Name", typeof(string)));

            //dt_temp.Columns.Add(new DataColumn("Wc_Name", typeof(string)));
            //dt_temp.Columns.Add(new DataColumn("Process_Name", typeof(string)));

            dt_temp.Columns.Add(new DataColumn("Plan_Qty_Box", typeof(int)));
            dt_temp.Columns.Add(new DataColumn("Prd_Qty", typeof(int)));
            dt_temp.Columns.Add(new DataColumn("Good_qty", typeof(int))); 
            dt_temp.Columns.Add(new DataColumn("bad_qty", typeof(int)));
            dt_temp.Columns.Add(new DataColumn("Defect_Rate", typeof(decimal)));


            string date = "";
            foreach (DataRow dr in dt2.Rows)
            {
                if (date == "" || date != dr["Prd_Date"].ToString())
                {
                    DataRow drNew = dt_temp.NewRow();
                    drNew["Prd_Date"] = dr["Prd_Date"];
                    //drNew["workorderno"] = dr["workorderno"];
                    //drNew["Item_Code"] = dr["Item_Code"];
                    //drNew["Item_Name"] = dr["Item_Name"];

                    //drNew["Wc_Name"] = dr["Wc_Name"];
                    //drNew["Process_Name"] = dr["Process_Name"];

                    drNew["Plan_Qty_Box"] = dr["Plan_Qty_Box"];
                    drNew["Prd_Qty"] = dr["Prd_Qty"];
                    drNew["Good_qty"] = dr["Good_qty"];
                    drNew["bad_qty"] = dr["bad_qty"];
                    drNew["Defect_Rate"] = dr["Defect_Rate"];
                    dt_temp.Rows.Add(drNew);
                }
                else if (date == dr["Prd_Date"].ToString())
                {
                    foreach (DataRow dr_temp in dt_temp.Rows) 
                    {
                        if (dr_temp["Prd_Date"].ToString() == date) { 
                            dr_temp["Plan_Qty_Box"] = Convert.ToInt32(dr_temp["Plan_Qty_Box"]) + Convert.ToInt32(dr["Plan_Qty_Box"]);

                            dr_temp["Prd_Qty"] = Convert.ToInt32(dr_temp["Prd_Qty"]) + Convert.ToInt32(dr["Prd_Qty"]);
                            dr_temp["Good_qty"] = Convert.ToInt32(dr_temp["Good_qty"]) + Convert.ToInt32(dr["Good_qty"]);

                            dr_temp["bad_qty"] = Convert.ToInt32(dr_temp["bad_qty"]) + Convert.ToInt32(dr["bad_qty"]);
                        
                            dr_temp["Defect_Rate"] = Convert.ToDecimal(dr_temp["bad_qty"]) / Convert.ToInt32(dr_temp["Prd_Qty"])*100;
                        }
                    }
                }
                    date = dr["Prd_Date"].ToString();
                
            }
            chart1.DataSource = dt_temp;


            // create clustered column series
            //var columnSeries1 = new ColumnSeries();
            //columnSeries1.ValueMemberPath = "Coal";
            //columnSeries1.XAxis = sharedXAxis;
            //columnSeries1.YAxis = sharedYAxis;
            //var columnSeries2 = new ColumnSeries();
            //columnSeries2.ValueMemberPath = "Hydro";
            //columnSeries2.XAxis = sharedXAxis;
            //columnSeries2.YAxis = sharedYAxis;

            //// create a line series
            //var lineSeries = new LineSeries();
            //lineSeries.ValueMemberPath = "Nuclear";
            //lineSeries.XAxis = sharedXAxis;
            //lineSeries.YAxis = sharedYAxis;

            //// add created series to the chart
            //this.DataChart.Series.Add(columnSeries1);
            //this.DataChart.Series.Add(columnSeries2);
            //this.DataChart.Series.Add(lineSeries);


            //chart1.Series[0].Points.x
            //chart1.Series[0].XValueMember = "Prd_Date";
            //chart1.Series[0].YValueMembers = "Good_Qty";
            //chart1.Series[0].IsValueShownAsLabel = true; //각 요소 값 출력
            //chart1.Series[0].IsVisibleInLegend = false; //범례 숨기기
            //chart1.Series.Add(new Series("chart2"));

            //chart1.Series[1].XValueMember = "Prd_Date";
            //chart1.Series[1].YValueMembers = "Bad_Qty";
            //chart1.Series[1].IsValueShownAsLabel = true; //각 요소 값 출력
            //chart1.Series[1].IsVisibleInLegend = false; //범례 숨기기

            chart1.ChartAreas[0].AxisY2.Minimum = 0;
            chart1.ChartAreas[0].AxisY2.Maximum = 100;

            //chart1.ChartAreas[0].AxisX.Interval = 1; //X축 간격 설정
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //X축 그리드 숨기기
            //chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray; //X축 그리드 숨기기
            chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            //chart1.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray; //X축 그리드 숨기기
            //chart1.ChartAreas[0].AxisY2.Enabled = false;
            chart1.ChartAreas[0].AxisX.Title = "일자";
            chart1.ChartAreas[0].AxisY.Title = "수량";
            chart1.ChartAreas[0].Position = new ElementPosition(-1, 3, 102, 95);
            //chart1.ChartAreas[2].AxisY.Title = "%";



            chart1.DataBind();

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

        bool IsTheSameCellValue(int column, int row)
        {
            if (column == 0)
                return true;
            else if(column < 5)
            {
                DataGridViewCell cell1 = dataGridView1[column, row];
                DataGridViewCell cell2 = dataGridView1[column - 1, row];
                //if (cell1.Value == null || cell2.Value == null)
                //{
                //    return false;
                //}
                return cell1.Value == cell2.Value;
            }
            else
                return false;
             
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (e.RowIndex != ((DataGridView)sender).Rows.Count - 1 || e.ColumnIndex > 5)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Right = dataGridView1.AdvancedCellBorderStyle.Right;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 1 || e.ColumnIndex < 1)
                return;
            if (e.RowIndex != ((DataGridView)sender).Rows.Count - 1 || e.ColumnIndex > 6)
                return;

            if (IsTheSameCellValue(e.ColumnIndex-1, e.RowIndex))
            {
                if (e.ColumnIndex != 5)
                {
                    e.Value = "";                    

                }
                else
                {
                    e.Value = " 총 계  ▶";
                }
                e.FormattingApplied = true;
            }
            
        }
    }
}
