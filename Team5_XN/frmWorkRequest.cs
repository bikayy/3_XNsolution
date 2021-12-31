using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN_VO;

namespace Team5_XN
{
    public partial class frmWorkRequest : Form
    {
        List<RequestVO> list = new List<RequestVO>();
        RequestService reqServ = new RequestService();

        public frmWorkRequest()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PopupRequest frm = new PopupRequest();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.Cancel) LoadData();
        }

        private void frmWorkRequest_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {  //Prd_Req_No, Req_Date, Req_Seq, Item_Code,
            //Req_Qty, Customer_Name, Project_Nm, Sale_Prsn_Nm, 
            //Delivery_Date, Plan_Qty, Prd_Progress_Status

            dgvRequest.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvRequest);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산요청번호", "Prd_Req_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청일자", "Req_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청순번", "Req_Seq", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청수량", "Req_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "거래처", "Customer_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "프로젝트명", "Project_Nm", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "영업담당자명", "Sale_Prsn_Nm", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "납기일자", "Delivery_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산반영수량", "Plan_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산진행상태", "Prd_Progress_Status", colWidth: 120);


            list = reqServ.GetRequestList();
            dgvRequest.DataSource = new AdvancedList<RequestVO>(list);
            dgvRequest.Columns["Req_Qty"].ReadOnly = false;
            dgvRequest.Columns["Customer_Name"].ReadOnly = false;
            dgvRequest.Columns["Project_Nm"].ReadOnly = false;
            dgvRequest.Columns["Delivery_Date"].ReadOnly = false;
        }

        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            if (e.ColumnIndex == 3)
            {
                PopupSearch frm = new PopupSearch();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    dgvRequest[3, e.RowIndex].Value = frm.Send.Item_Code;
                    DateTimePicker dt = new DateTimePicker();
                }
            }
        }


        private void dgvRequest_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                MessageBox.Show("요청수량은 숫자로 입력해주십시오.");
            }

            if (e.ColumnIndex == 8)
            {
                //bool result = 
                //MessageBox.Show("요청수량은 숫자로 입력해주십시오.");
            }
            //MessageBox.Show("입력값을 확인해주십시오.");
        }

        private static bool CheckDate(string date)
        {
            return Regex.IsMatch(date, @"^(19|20)\d{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[0-1])$");
        }
    }
}
