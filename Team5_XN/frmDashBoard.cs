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
        public frmDashBoard()
        {
            InitializeComponent();
        }

        private void frmDashBoard_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            //WorkOrderNo, Start_Hour, In_Qty_Sub, In_Qty_Main, Out_Qty_Main, Out_Qty_Sub, Prd_Qty, Prd_Unit
            DataGridViewUtil.SetInitGridView(dgvTimeProduct);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "작업지시번호", "WorkOrderNo", colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "시작시간", "Start_Hour", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "거래처명", "In_Qty_Sub", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "사업자번호", "In_Qty_Main", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "가격", "Out_Qty_Main", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "단위", "Out_Qty_Sub", colWidth: 40);
            DataGridViewUtil.AddGridTextColumn(dgvTimeProduct, "거래처번호", "Prd_Qty", colWidth: 100);
            mDac = new MenuDAC();


            dt1 = mDac.GetTimeProductHistory();
            dgvTimeProduct.DataSource = dt1;

            DataGridViewUtil.SetInitGridView(dataGridView2);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "작업지시번호", "WorkOrderNo", colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "시작시간", "Start_Hour", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "거래처명", "In_Qty_Sub", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "사업자번호", "In_Qty_Main", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "가격", "Out_Qty_Main", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "단위", "Out_Qty_Sub", colWidth: 40);
            DataGridViewUtil.AddGridTextColumn(dataGridView2, "거래처번호", "Prd_Qty", colWidth: 100);

            dt2 = mDac.GetTimeProductHistory();
            dataGridView2.DataSource = dt2;

            DataGridViewUtil.SetInitGridView(dataGridView3);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "작업지시번호", "WorkOrderNo", colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "시작시간", "Start_Hour", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "거래처명", "In_Qty_Sub", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "사업자번호", "In_Qty_Main", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "가격", "Out_Qty_Main", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "단위", "Out_Qty_Sub", colWidth: 40);
            DataGridViewUtil.AddGridTextColumn(dataGridView3, "거래처번호", "Prd_Qty", colWidth: 100);

            dt3 = mDac.GetTimeProductHistory();
            dataGridView3.DataSource = dt3;

            DataGridViewUtil.SetInitGridView(dataGridView4);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "작업지시번호", "WorkOrderNo", colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "시작시간", "Start_Hour", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "거래처명", "In_Qty_Sub", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "사업자번호", "In_Qty_Main", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "가격", "Out_Qty_Main", DataGridViewContentAlignment.MiddleRight, colWidth: 70);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "단위", "Out_Qty_Sub", colWidth: 40);
            DataGridViewUtil.AddGridTextColumn(dataGridView4, "거래처번호", "Prd_Qty", colWidth: 100);

            dt4 = mDac.GetTimeProductHistory();
            dataGridView4.DataSource = dt4;
        }
    }
}
