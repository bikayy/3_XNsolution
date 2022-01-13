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

        /// <summary>
        /// 생산계획 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            rp_dtpPlanMonth.Enabled = true;
            rp_txtPlanQty.ReadOnly = false;
            rp_btnWCSearch.Enabled = true;
            rp_btnWCSearch.BackColor = Color.Black;
            rp_txtRemark.ReadOnly = false;            
        }

        /// <summary>
        /// 생산계획 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {  //Prd_Req_No, Plan_Month, Item_Code, Plan_Qty, Wc_Code, Remark, Ins_Emp
            PlanService planServ = new PlanService();
            TextBox[] textboxes = { rp_txtPlanQty, rp_txtWCName, rp_txtWCCode, rp_txtRemark, rp_txtReqNo, rp_txtReqDate, rp_txtReqSeq, rp_txtItemCode,
                                                 rp_txtItemName, rp_txtReqQty, rp_txtCustomerName, rp_txtDeliDate};
            Label[] labels = { lblPlanQty, lblWC };
            StringBuilder sb = new StringBuilder();
            //int j = 0;

            if (Convert.ToInt32(rp_dtpPlanMonth.Value.ToString("yyyyMM"))
                < Convert.ToInt32(DateTime.Now.ToString("yyyyMM")))
            {
                MessageBox.Show("생산계획월을 다시 확인하여주십시오.");
                return;
            }

            sb.AppendLine($"{lblReqNo.Text} : {rp_txtReqNo.Text}");
            sb.AppendLine($"{lblItem.Text} : {rp_txtItemName.Text}");

            for (int i = 0; i < 2; i++)
            {
                bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                if (isChecked)
                {
                    MessageBox.Show($"{labels[i].Text}을(를) 입력해주세요.");
                    return;
                }
                else
                {
                    //if (i == 1) continue;

                    sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
                    //j++;
                }
            }

            sb.AppendLine($"{lblPlanMonth.Text} : {rp_dtpPlanMonth.Value.ToString("yyyy-MM")}");
            sb.AppendLine("위의 정보로 생산계획을 등록하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "생산계획", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                PlanVO pr = new PlanVO()
                {
                    Prd_Req_No = rp_txtReqNo.Text,
                    Plan_Month = rp_dtpPlanMonth.Value.ToString(),
                    Item_Code = rp_txtItemCode.Text,
                    Plan_Qty = Convert.ToInt32(rp_txtPlanQty.Text),
                    Wc_Code = rp_txtWCCode.Text,
                    Remark = rp_txtRemark.Text,
                    Ins_Emp = "스벅"
                };

                bool resultPlan = planServ.CreatePlan(pr);
                if (resultPlan) MessageBox.Show("생산계획이 등록되었습니다.");
                else MessageBox.Show("생산계획 등록에 실패하였습니다.\n다시 확인하여주십시오.");

                for (int i = 0; i < textboxes.Length; i++)
                {
                    textboxes[i].Text = "";
                }
                rp_dtpPlanMonth.Value = DateTime.Now;
                rp_dtpPlanMonth.Enabled = false;
                rp_txtPlanQty.ReadOnly = true;
                rp_btnWCSearch.BackColor = Color.Gray;
                rp_btnWCSearch.Enabled = false;
                rp_txtRemark.ReadOnly = true;
            }
        }

        private void frmWorkPlan_Load(object sender, EventArgs e)
        {
            //Main main = (Main)this.MdiParent;

            //main.Select += OnSelect;

            r_dtpFromDate.Value = DateTime.Now.AddDays(-3);
            r_dtpToDate.Value = DateTime.Now;

            LoadDataRequest();
            LoadDataPlan();
        }

        /// <summary>
        /// 생산요청 페이지 로드데이터
        /// </summary>
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

        /// <summary>
        /// 생산계획 페이지 로드데이터
        /// </summary>
        private void LoadDataPlan()
        {  //pp.Prd_Plan_No,  pp.Wc_Code, Wc_Name, pp.Item_Code, Item_Name, 
            //pp.Plan_Qty, Customer_Name, Delivery_Date,
            //Prd_Plan_Status, pp.Remark

            dgvPlan.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvPlan);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획번호", "Prd_Plan_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "작업장코드", "Wc_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "작업장명", "Wc_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "품목명", "Item_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "계획수량", "Plan_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획월", "Plan_Month", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "거래처", "Customer_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "납기일자", "Delivery_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "생산계획상태", "Prd_Plan_Status", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "비고", "Remark", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvPlan, "담당자", "Ins_Emp", colWidth: 120);


            dgvPlan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listPlan = planServ.GetPlanList();
            dgvPlan.Columns["Plan_Qty"].ReadOnly = false;
            dgvPlan.Columns["Remark"].ReadOnly = false;
            dgvPlan.Columns["Plan_Month"].ReadOnly = false;
            dgvPlan.DataSource = listPlan;

        }

        /// <summary>
        /// 생산요청 페이지 품목 검색
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 생산요청 페이지 그리드뷰 셀 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string reqNo = dgvRequest[0, e.RowIndex].Value.ToString();
            List<RequestVO> reqList = (List<RequestVO>)dgvRequest.DataSource;

            RequestVO req = reqList.Find((item) => item.Prd_Req_No == reqNo);

            if (req != null)
            {
                rp_txtReqNo.Text = req.Prd_Req_No;
                rp_txtReqDate.Text = req.Req_Date;
                rp_txtReqSeq.Text = req.Req_Seq;
                rp_txtItemCode.Text = req.Item_Code;
                rp_txtItemName.Text = req.Item_Name;
                rp_txtReqQty.Text = req.Req_Qty.ToString();
                rp_txtCustomerName.Text = req.Customer_Name;
                rp_txtDeliDate.Text = req.Delivery_Date;
            }
        }

        /// <summary>
        /// 생산계획 - 생산계획 추가(단독 추가)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearItem();

            pp_dtpPlanMonth.Enabled = true;
            pp_txtItemCode.ReadOnly = false;
            pp_txtItemName.ReadOnly = false;
            pp_txtWCCode.ReadOnly = false;
            pp_txtWCName.ReadOnly = false;
            pp_txtPlanQty.ReadOnly = false;
            pp_txtRemark.ReadOnly = false;
            pp_btnItemSearch.BackColor = Color.Black;
            pp_btnItemSearch.Enabled = true;
            pp_btnWCSearch.BackColor = Color.Black;
            pp_btnWCSearch.Enabled = true;
        }

        /// <summary>
        /// 항목 초기화
        /// </summary>
        private void ClearItem()
        {
            pp_txtPlanNo.Text = "";
            pp_dtpPlanMonth.Value = DateTime.Now;
            pp_txtItemCode.Text = "";
            pp_txtItemName.Text = "";
            pp_txtWCCode.Text = "";
            pp_txtWCName.Text = "";
            pp_txtPlanQty.Text = "";
            pp_txtCustomerName.Text = "";
            pp_txtDeliDate.Text = "";
            pp_txtRemark.Text = "";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataRequest();
            LoadDataPlan();
        }

        /// <summary>
        /// 생산계획 그리드뷰 셀 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string planNo = dgvPlan[0, e.RowIndex].Value.ToString();
            List<GetPlanListVO> planList = (List<GetPlanListVO>)dgvPlan.DataSource;

            GetPlanListVO plan = planList.Find((item) => item.Prd_Plan_No == planNo);

            if (plan != null)
            {
                pp_txtPlanNo.Text = plan.Prd_Plan_No;
                pp_dtpPlanMonth.Text = plan.Plan_Month;
                pp_txtItemCode.Text = plan.Item_Code;
                pp_txtItemName.Text = plan.Item_Name;
                pp_txtWCCode.Text = plan.Wc_Code;
                pp_txtWCName.Text = plan.Wc_Name;
                pp_txtPlanQty.Text = plan.Plan_Qty.ToString();
                pp_txtCustomerName.Text = plan.Customer_Name;
                pp_txtDeliDate.Text = plan.Delivery_Date;
                pp_txtRemark.Text = plan.Remark;
            }
        }

        /// <summary>
        /// 생산계획 수정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dgvPlan.EndEdit();
            pp_dtpPlanMonth.Enabled = false;

            PlanService planServ = new PlanService();

            #region 유효성 검사, 출력 정보 입력
            TextBox[] textboxes = { pp_txtPlanNo, pp_txtItemName, pp_txtWCName, pp_txtPlanQty, pp_txtRemark};
            Label[] labels = { pp_lblPlanNo, pp_lblItme, pp_lblWC, pp_lblPlanQty, pp_lblRemark };
            StringBuilder sb = new StringBuilder();

            if (Convert.ToInt32(pp_dtpPlanMonth.Value.ToString("yyyyMM"))
                < Convert.ToInt32(DateTime.Now.ToString("yyyyMM")))
            {
                MessageBox.Show("생산계획월을 다시 확인하여주십시오.");
                return;
            }

            for (int i = 0; i < textboxes.Length; i++)
            {
                bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                if (isChecked)
                {
                    MessageBox.Show($"{labels[i].Text}을(를) 입력해주세요.");
                    return;
                }
                else //출력 정보 입력
                {
                    sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
                }
            }
            #endregion

            #region 생산계획 수정 실행
            sb.AppendLine("위의 정보로 생산계획을 수정하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "생산계획 수정", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                GetPlanListVO up = new GetPlanListVO
                {
                    Wc_Code = pp_txtWCCode.Text,
                    Item_Code = pp_txtItemCode.Text,
                    Plan_Qty = Convert.ToInt32(pp_txtPlanQty.Text),
                    Remark = pp_txtRemark.Text,
                    Prd_Plan_No = pp_txtPlanNo.Text,
                    Ins_Emp = "수정해야함"
                };

                bool rPlanUpdate =planServ.UpdatePlan(up);
                if (rPlanUpdate) MessageBox.Show("생산계획이 수정되었습니다.");
                else MessageBox.Show("생산계획 수정에 실패하였습니다.\n다시 확인하여주십시오.");

                ClearItem();
                #endregion
            }


            //List<string> planNoList = new List<string>();

            //foreach (DataGridViewRow row in dgvPlan.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
            //    if (Convert.ToBoolean(chk.Value))
            //    {
            //        planNoList.Add(row.Cells["Prd_Plan_No"].Value.ToString());
            //        if (row.Cells["Prd_Plan_Status"].Value.ToString() != "대기중")
            //        {
            //            MessageBox.Show("생산계획상태가 대기중인 생산계획만 수정할 수 있습니다.");
            //            return;
            //        }
            //    }
            //}

            //if (planNoList.Count < 1)
            //{
            //    MessageBox.Show("선택된 생산계획이 없습니다.");
            //    return;
            //}

            //DialogResult planResult = MessageBox.Show("선택된 생산계획을 수정하시겠습니까?", "생산계획 수정", MessageBoxButtons.YesNo);

            //if (planResult == DialogResult.Yes)
            //{
            //    List<GetPlanListVO> planList = (List<GetPlanListVO>)dgvPlan.DataSource;
            //    GetPlanListVO sendUp = null;
            //    bool result = false;

            //    for (int i = 0; i < planNoList.Count; i++)
            //    {
            //        string no = planNoList[i];
            //        sendUp = planList.Find((item) => item.Prd_Plan_No == no);

            //        //pp.Wc_Code,  pp.Item_Code,  Plan_Qty, Remark
            //        GetPlanListVO up = new GetPlanListVO
            //        {
            //            Wc_Code = sendUp.Wc_Code,
            //            Item_Code = sendUp.Item_Code,
            //            Plan_Qty = sendUp.Plan_Qty,
            //            Remark = sendUp.Remark,
            //            Prd_Plan_No = sendUp.Prd_Plan_No,
            //            Plan_Month = sendUp.Plan_Month,
            //            Ins_Emp = "수정해야함"
            //        };

            //        result = planServ.UpdatePlan(up);
            //    }

            //    if (result)
            //    {
            //        MessageBox.Show("수정이 완료되었습니다.");
            //        LoadDataPlan();
            //    }
            //    else MessageBox.Show("수정에 실패하였습니다.\n다시 시도하여주십시오.");
            //}
        }

        /// <summary>
        /// 생산계획 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvPlan.EndEdit();

            TextBox[] textboxes = { pp_txtPlanNo, pp_txtItemName, pp_txtWCName, pp_txtPlanQty};
            Label[] labels = { pp_lblPlanNo, pp_lblItme, pp_lblWC, pp_lblPlanQty };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textboxes.Length; i++)
            {
                sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
            }

            sb.AppendLine("해당 생산계획을 삭제하시겠습니까?");
            DialogResult dResult = MessageBox.Show(sb.ToString(), "생산계획 삭제", MessageBoxButtons.YesNo);

            if (dResult == DialogResult.Yes)
            {
                bool result = planServ.DeletePlan(pp_txtPlanNo.Text);
                if (result)
                {
                    MessageBox.Show("삭제가 완료되었습니다.");
                    LoadDataPlan();
                }
                else MessageBox.Show("삭제에 실패하였습니다.\n다시 시도하여주십시오.");
            }
        }

        /// <summary>
        /// 생산계획 마감
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            dgvPlan.EndEdit();

            //List<string> planNoList = new List<string>();

            //foreach (DataGridViewRow row in dgvPlan.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
            //    if (Convert.ToBoolean(chk.Value))
            //    {
            //        planNoList.Add(row.Cells["Prd_Plan_No"].Value.ToString());
            //    }
            //}

            //if (planNoList.Count < 1)
            //{
            //    MessageBox.Show("선택된 생산계획이 없습니다.");
            //    return;
            //}

            //DialogResult reqResult = MessageBox.Show("선택된 생산계획을 마감하시겠습니까?", "생산계획 마감", MessageBoxButtons.YesNo);

            //if (reqResult == DialogResult.Yes)
            //{
            //    bool result = false;

            //    for (int i = 0; i < planNoList.Count; i++)
            //    {
            //        string id = planNoList[i];
            //        result = planServ.PlanEnd(id);
            //    }

            //    if (result)
            //    {
            //        MessageBox.Show("생산계획 마감이 완료되었습니다.");
            //        LoadDataPlan();
            //    }
            //    else MessageBox.Show("생산계획 마감에 실패하였습니다.\n다시 시도하여주십시오.");
            //}
        }

        /// <summary>
        /// 생산계획 마감취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCancle_Click(object sender, EventArgs e)
        {
            dgvPlan.EndEdit();

            //List<string> planNoList = new List<string>();

            //foreach (DataGridViewRow row in dgvPlan.Rows)
            //{
            //    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
            //    if (Convert.ToBoolean(chk.Value))
            //    {
            //        planNoList.Add(row.Cells["Prd_Plan_No"].Value.ToString());
            //    }
            //}

            //if (planNoList.Count < 1)
            //{
            //    MessageBox.Show("선택된 생산계획이 없습니다.");
            //    return;
            //}

            //DialogResult reqResult = MessageBox.Show("선택된 생산계획을 마감취소하시겠습니까?", "생산계획 마감취소", MessageBoxButtons.YesNo);

            //if (reqResult == DialogResult.Yes)
            //{
            //    bool result = false;

            //    for (int i = 0; i < planNoList.Count; i++)
            //    {
            //        string id = planNoList[i];
            //        result = planServ.PlanEndCancle(id);
            //    }

            //    if (result)
            //    {
            //        MessageBox.Show("생산계획 마감취소가 완료되었습니다.");
            //        LoadDataPlan();
            //    }
            //    else MessageBox.Show("생산계획 마감취소에 실패하였습니다.\n다시 시도하여주십시오.");
            //}
        }

        private void btnWCSearch_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 생산계획 수정 시 유효성 검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPlan_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //#region 생산계획월 유효성
            //DateTime ch;
            //if (e.ColumnIndex == 7 &&
            //    DateTime.TryParse(e.FormattedValue.ToString(), out ch) == false)
            //{
            //    MessageBox.Show("생산계획월은 yyyy-MM 형태로 입력해주십시오.");
            //    e.Cancel = true;
            //}
            //else
            //{
            //    if (e.ColumnIndex == 7 && Convert.ToDateTime(e.FormattedValue.ToString()) < DateTime.Now.AddMonths(-1))
            //    {
            //        MessageBox.Show("생산계획월은 현재월보다 과거일 수 없습니다.");
            //        e.Cancel = true;
            //    }
            //}
            //#endregion

            //#region 계획수량 유효성
            //if (e.ColumnIndex == 6 && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            //{
            //    MessageBox.Show("계획수량 항목은 공란일 수 없습니다.");
            //    e.Cancel = true;
            //}
            //else
            //{
            //    int planNum;
            //    if (e.ColumnIndex == 6
            //        && Int32.TryParse(e.FormattedValue.ToString(), out planNum)
            //        && planNum < 1)
            //    {
            //        MessageBox.Show("계획수량을 다시 설정하여주십시오.");
            //        e.Cancel = true;
            //    }

            //}
            //#endregion
        }

        /// <summary>
        /// 계획수량 유효성(숫자여부)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //if (e.ColumnIndex == 6)
            //{
            //    MessageBox.Show("계획수량은 숫자로 입력해주십시오.");
            //}
        }

        /// <summary>
        /// 검색조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelect(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Equals("req"))
            {
                if (rdoReqDate.Checked)
                {
                    if (string.IsNullOrWhiteSpace(r_txtItemCode.Text))
                    {
                        LoadReqSearch(rdoReqDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            r_dtpToDate.Value.ToString("yyyy-MM-dd"), "");
                    }
                    else
                    {
                        LoadReqSearch(rdoReqDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            r_dtpToDate.Value.ToString("yyyy-MM-dd"), r_txtItemCode.Text);
                    }
                }
                else if (rdoDeliDate.Checked)
                {
                    if (string.IsNullOrWhiteSpace(r_txtItemCode.Text))
                    {
                        LoadReqSearch(rdoDeliDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            r_dtpToDate.Value.ToString("yyyy-MM-dd"), "");
                    }
                    else
                    {
                        LoadReqSearch(rdoDeliDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            r_dtpToDate.Value.ToString("yyyy-MM-dd"), r_txtItemCode.Text);
                    }
                }
                else
                {
                    LoadReqSearch("", "", "", r_txtItemCode.Text);
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// 생산요청검색데이터
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="item"></param>
        private void LoadReqSearch(string tag, string fromDate, string toDate, string item)
        {
            dgvRequest.Columns.Clear();

            DataGridViewCheckBoxColumn chkBox = new DataGridViewCheckBoxColumn();
            chkBox.HeaderText = "선택";
            chkBox.Name = "check";
            dgvRequest.Columns.Add(chkBox);

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

            List<RequestVO> listReqSearch = reqServ.GetRequestSearch(tag, fromDate, toDate, item);
            dgvRequest.Columns["Req_Qty"].ReadOnly = false;
            dgvRequest.Columns["Customer_Name"].ReadOnly = false;
            dgvRequest.Columns["Project_Nm"].ReadOnly = false;
            dgvRequest.Columns["Delivery_Date"].ReadOnly = false;
            dgvRequest.DataSource = listReqSearch;
        }

        /// <summary>
        /// 검색조건 초기화
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            r_txtItemCode.Text = "";
            r_txtItemName.Text = "";
            r_dtpFromDate.Value = DateTime.Now.AddDays(-3);
            r_dtpToDate.Value = DateTime.Now;
            rdoDeliDate.Checked = false;
            rdoReqDate.Checked = true;

            LoadReqSearch(rdoReqDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            r_dtpToDate.Value.ToString("yyyy-MM-dd"), "");
        }

        private void r_btnWCSearch_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                rp_txtWCCode.Text = frm.Send.Wc_Code;
                rp_txtWCName.Text = frm.Send.Wc_Name;
            }
        }

        private void pp_btnItemSearch_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                pp_txtItemCode.Text = frm.Send.Item_Code;
                pp_txtItemName.Text = frm.Send.Item_Name;
            }
        }

        private void pp_btnWCSearch_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                pp_txtWCCode.Text = frm.Send.Wc_Code;
                pp_txtWCName.Text = frm.Send.Wc_Name;
            }
        }
    }
}
