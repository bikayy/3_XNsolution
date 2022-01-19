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

namespace Team5_XN
{
    public partial class frmDashBoard : Form
    {
        MenuDAC mDac;
        DataTable dt1;
        DataTable dt2;
        DataTable dt3;
        DataTable dt4;
        Main main = null;
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            LoadData();
        }

        private void LoadData()
        {
            
            //WorkOrderNo, Start_Hour, In_Qty_Sub, In_Qty_Main, Out_Qty_Main, Out_Qty_Sub, Prd_Qty, Prd_Unit
            DataGridViewUtil.SetInitGridView(dgvTimeProduct);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "작업지시번호", "WorkOrderNo", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "작업지시상태", "Wo_Status", colWidth: 100);
            

            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "작업지시일자", "Plan_Date", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "작업지시수량", "Plan_Qty_Box", colWidth: 80);

            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "품목코드", "Item_Code", colWidth: 160);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "품목명", "Item_Name", colWidth: 160);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "퓸목명(영문)", "Item_Name_Eng", colWidth: 170);

            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "작업장", "Wc_Name", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "공정", "Process_Name", colWidth: 130);

            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "생산일자", "Prd_Date", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "생산시작", "Prd_StartTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "생산종료", "Prd_EndTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "생산수량", "Prd_Qty", colWidth: 70);
            mDac = new MenuDAC();


            dt1 = mDac.GetTimeProductHistory();
            dgvTimeProduct.DataSource = dt1;

            DataGridViewUtil.SetInitGridView(dgvDayProduct);

            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "작업지시번호", "WorkOrderNo", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "공정", "Process_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "작업장", "Wc_Name", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "제품코드", "Item_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "제품명", "Item_Name", colWidth: 180);

            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "계획수량", "Plan_Qty_Box", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "생산수량", "Prd_Qty", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "달성률(%)", "Achieve_Rate", colWidth: 90);

            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "생산시작", "Prd_StartTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "생산종료", "Prd_EndTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "생산시간(hr)", "Prd_Time", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvDayProduct, "시간당생산량", "Prd_Qty_Time", colWidth: 90);

            dt2 = mDac.GetDayProduction();
            dgvDayProduct.DataSource = dt2;

            DataGridViewUtil.SetInitGridView(dgvNopInfo);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "Seq", "Nop_Seq", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "작업장코드", "Wc_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "작업장명", "Wc_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동시작시간", "Nop_HappenTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동종료시간", "Nop_CancelTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동시간(분)", "Nop_Time", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동대분류코드", "Nop_Ma_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동대분류명", "Nop_Ma_Name", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동상세분류코드", "Nop_Mi_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvNopInfo, "비가동상세분류명", "Nop_Mi_Name", colWidth: 150);

            dgvNopInfo.Columns["Nop_HappenTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dgvNopInfo.Columns["Nop_CancelTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            dt3 = mDac.GetNopHistory();
            dgvNopInfo.DataSource = dt3;

            DataGridViewUtil.SetInitGridView(dgvDayDefect);

            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "작업지시번호", "WorkOrderNo", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "공정", "Process_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "작업장", "Wc_Name", colWidth: 120);

            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "제품코드", "Item_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "제품명", "Item_Name", colWidth: 180);

            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "계획수량", "Plan_Qty_Box", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "생산수량", "Prd_Qty", colWidth: 90);

            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "불량수량", "Bad_Qty", colWidth: 90);
            DataGridViewUtil.AddGridTextColumn(dgvDayDefect, "불량률(%)", "Defect_Rate", colWidth: 90);

            dt4 = mDac.GetDayDefect();
            dgvDayDefect.DataSource = dt4;
            
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
