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
    public partial class frmWorkPlan : Form
    {
        List<RequestVO> listReq = new List<RequestVO>();
        RequestService reqServ = new RequestService();
        RequestVO sendInfo = new RequestVO();
        List<GetPlanListVO> listPlan = new List<GetPlanListVO>();
        PlanService planServ = new PlanService();

        public frmWorkPlan()
        {
            InitializeComponent();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            frmSearchPopup frm = new frmSearchPopup();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopupAddPlan frm = new PopupAddPlan();
            frm.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            PopupCreatePlan frm = new PopupCreatePlan();
            frm.Get.Prd_Req_No = sendInfo.Prd_Req_No;
            frm.Get.Req_Date = sendInfo.Req_Date;
            frm.Get.Req_Seq = sendInfo.Req_Seq;
            frm.Get.Item_Code = sendInfo.Item_Code;
            frm.Get.Item_Name = sendInfo.Item_Name;
            frm.Get.Req_Qty = sendInfo.Req_Qty;
            frm.Get.Customer_Name = sendInfo.Customer_Name;
            frm.Get.Delivery_Date = sendInfo.Delivery_Date;
            frm.ShowDialog();
        }

        private void frmWorkPlan_Load(object sender, EventArgs e)
        {
            LoadDataRequest();
            LoadDataPlan();
        }

        private void LoadDataRequest()
        {  //Prd_Req_No, Req_Date, Req_Seq, Item_Code,
            //Req_Qty, Customer_Name, Project_Nm, Sale_Prsn_Nm, 
            //Delivery_Date, Plan_Qty, Prd_Progress_Status

            dgvRequest.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvRequest);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산요청번호", "Prd_Req_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청일자", "Req_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청순번", "Req_Seq", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "품목명", "Item_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청수량", "Req_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "거래처", "Customer_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "프로젝트명", "Project_Nm", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "영업담당자명", "Sale_Prsn_Nm", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "납기일자", "Delivery_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산반영수량", "Plan_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산진행상태", "Prd_Progress_Status", colWidth: 120);


            dgvRequest.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listReq = reqServ.GetRequestList();
            dgvRequest.DataSource = listReq;

        }

        private void LoadDataPlan()
        {  //pp.Prd_Plan_No,  pp.Wc_Code, Wc_Name, pp.Item_Code, Item_Name, 
            //pp.Plan_Qty, Customer_Name, Delivery_Date,
            //Prd_Plan_Status, pp.Remark

            dgvPlan.Columns.Clear();

            DataGridViewCheckBoxColumn chkBox = new DataGridViewCheckBoxColumn();
            chkBox.HeaderText = "선택";
            chkBox.Name = "check";
            dgvPlan.Columns.Add(chkBox);

            DataGridViewUtil.SetInitGridView(dgvPlan);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획번호", "Prd_Plan_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "작업장코드", "Wc_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "작업장명", "Wc_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "품목명", "Item_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획수량", "Plan_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획월", "Plan_Month", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "거래처", "Customer_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "납기일자", "Delivery_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획상태", "Prd_Plan_Status", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "비고", "Remark", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "담당자", "Ins_Emp", colWidth: 120);


            dgvRequest.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listPlan = planServ.GetPlanList();
            dgvPlan.Columns["Plan_Qty"].ReadOnly = false;
            dgvPlan.Columns["Remark"].ReadOnly = false;
            dgvPlan.Columns["Plan_Month"].ReadOnly = false;
            dgvPlan.DataSource = listPlan;

        }

        private void r_btnItemSearch_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                r_txtItemCode.Text = frm.Send.Item_Code;
                r_txtItemName.Text = frm.Send.Item_Name;
            }
        }

        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string reqNo = dgvRequest[0, e.RowIndex].Value.ToString();
            List<RequestVO> reqList = (List<RequestVO>)dgvRequest.DataSource;

            RequestVO req = reqList.Find((item) => item.Prd_Req_No == reqNo);

            if (req != null)
            {
                sendInfo.Prd_Req_No = req.Prd_Req_No;
                sendInfo.Req_Date = req.Req_Date;
                sendInfo.Req_Seq = req.Req_Seq;
                sendInfo.Item_Code = req.Item_Code;
                sendInfo.Item_Name = req.Item_Name;
                sendInfo.Req_Qty = req.Req_Qty;
                sendInfo.Customer_Name = req.Customer_Name;
                sendInfo.Delivery_Date = req.Delivery_Date;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PopupIndPlan frm = new PopupIndPlan();
            frm.ShowDialog();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataRequest();
            LoadDataPlan();
        }

        private void dgvPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                PopupWCSearch frm = new PopupWCSearch();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    dgvPlan[2, e.RowIndex].Value = frm.Send.Wc_Code;
                    dgvPlan[3, e.RowIndex].Value = frm.Send.Wc_Name;
                }
            }

            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                PopupSearch frm = new PopupSearch();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    dgvPlan[4, e.RowIndex].Value = frm.Send.Item_Code;
                    dgvPlan[5, e.RowIndex].Value = frm.Send.Item_Name;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {  
            dgvPlan.EndEdit();

            List<string> planNoList = new List<string>();

            foreach (DataGridViewRow row in dgvPlan.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(chk.Value))
                {
                    planNoList.Add(row.Cells["Prd_Plan_No"].Value.ToString());
                }
            }

            if (planNoList.Count < 1)
            {
                MessageBox.Show("선택된 생산계획이 없습니다.");
                return;
            }

            DialogResult planResult = MessageBox.Show("선택된 생산계획을 수정하시겠습니까?", "생산계획 수정", MessageBoxButtons.YesNo);

            if (planResult == DialogResult.Yes)
            {
                List<GetPlanListVO> planList = (List<GetPlanListVO>)dgvPlan.DataSource;
                GetPlanListVO sendUp = null;
                bool result = false;

                for (int i = 0; i < planNoList.Count; i++)
                {
                    string no = planNoList[i];
                    sendUp = planList.Find((item) => item.Prd_Plan_No == no);

                    //pp.Wc_Code,  pp.Item_Code,  Plan_Qty, Remark
                    GetPlanListVO up = new GetPlanListVO
                    {
                        Wc_Code = sendUp.Wc_Code,
                        Item_Code = sendUp.Item_Code,
                        Plan_Qty = sendUp.Plan_Qty,
                        Remark = sendUp.Remark,
                        Prd_Plan_No = sendUp.Prd_Plan_No,
                        Plan_Month = sendUp.Plan_Month,
                        Ins_Emp = "수정해야함"
                    };

                    result = planServ.UpdatePlan(up);
                }

                if (result)
                {
                    MessageBox.Show("수정이 완료되었습니다.");
                    LoadDataPlan();
                }
                else MessageBox.Show("수정에 실패하였습니다.\n다시 시도하여주십시오.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvPlan.EndEdit();

            List<string> planNoList = new List<string>();

            foreach (DataGridViewRow row in dgvPlan.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(chk.Value))
                {
                    planNoList.Add(row.Cells["Prd_Plan_No"].Value.ToString());
                }
            }

            if (planNoList.Count < 1)
            {
                MessageBox.Show("선택된 생산계획이 없습니다.");
                return;
            }

            DialogResult reqResult = MessageBox.Show("선택된 생산계획을 삭제하시겠습니까?", "생산계획 삭제", MessageBoxButtons.YesNo);

            if (reqResult == DialogResult.Yes)
            {
                bool result = false;

                for (int i = 0; i < planNoList.Count; i++)
                {
                    string id = planNoList[i];
                    result = planServ.DeletePlan(id);
                }

                if (result)
                {
                    MessageBox.Show("삭제가 완료되었습니다.");
                    LoadDataPlan();
                }
                else MessageBox.Show("삭제에 실패하였습니다.\n다시 시도하여주십시오.");
            }
        }
    }
}
