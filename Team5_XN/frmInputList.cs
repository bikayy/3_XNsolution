using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN_VO;

namespace Team5_XN
{
    public partial class frmInputList : Form
    {
        WcService wcServ = new WcService();
        InputListService inServ = new InputListService();
        List<SelectInputVO> list = new List<SelectInputVO>();
        InputVO input = null;
        //private BindingList<object> cboList = new BindingList<object>();

        public frmInputList()
        {
            InitializeComponent();
        }

        private void frmInputList_Load(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Now.AddDays(-3);
            dtpToDate.Value = DateTime.Now;

            DataTable dt = new DataTable();
            dt = wcServ.SelectGrade();
            Combo(cboGrade, dt, blankText: "선택");

            //cboGrade.Items.Add("전체");
            ////cboList.Add(new { Text = "선택", Value = "C1000 and c.DetailCode = C2000" });
            //cboList.Add(new { Text = "상품", Value = "C1000" });
            //cboList.Add(new { Text = "하품", Value = "C2000" });

            //cboGrade.DataSource = cboList;
            //cboGrade.DisplayMember = "Text";
            //cboGrade.ValueMember = "Value";
            //cboGrade.SelectedIndex = 0;

            DataGridViewUtil.SetInitGridView(dgvInput);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "품목명", "Item_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "포장등급", "DetailName", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "포장등급상세코드", "Grade_Detail_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "포장등급상세명", "Grade_Detail_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "팔렛번호", "Pallet_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "입고수량", "In_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "마감시각", "Closed_Time", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvInput, "작업지시번호", "WorkOrderNo", colWidth: 120);

            dgvInput.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Combo(ComboBox cbo, DataTable dt, bool blankItem = true, string blankText = "")
        {
            if (blankItem)
            {
                GradeVO blank = new GradeVO
                {
                    DetailCode = "",
                    DetailName = blankText
                };
            }

            cbo.DisplayMember = "DetailName";
            cbo.ValueMember = "DetailCode";
            cbo.Text = "DetailName";
            cbo.DataSource = dt;
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
           input = new InputVO
            {
                FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                WorkOrderNo = txtWoNo.Text,
                ItemCode = txtItemCode.Text,
                DetailCode = cboGrade.SelectedValue.ToString()
            };
            list = inServ.SelectInput(input);
            dgvInput.DataSource = list;
        }

        private void btnItemSearch_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtItemCode.Text = frm.Send.Item_Code;
                txtItemName.Text = frm.Send.Item_Name;
            }
        }

    }
}
