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

        List<RequestVO> reqList = new List<RequestVO>();
        ReqSearchVO rs = null;

        PlanSearchVO ps = null;


        Main main = null;

        /// <summary>
        /// 0:기본, 1:추가, 2:편집, 3:삭제
        /// </summary>
        int check = 0; //추가,편집 구분을 위한 숫자 -- 1:추가, 2:편집, 3:삭제, 


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
            if (string.IsNullOrWhiteSpace(rp_txtReqNo.Text))
            {
                MessageBox.Show("생산요청을 먼저 선택해주십시오.");
                return;
            }

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
            if (rp_txtPlanQty.ReadOnly) return;


            PlanService planServ = new PlanService();
            TextBox[] textboxes = { rp_txtPlanQty, rp_txtWCName };
            Label[] labels = { lblPlanQty, lblWC };
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{lblReqNo.Text} : {rp_txtReqNo.Text}");
            sb.AppendLine($"{lblItem.Text} : {rp_txtItemName.Text}");

            for (int i = 0; i < textboxes.Length; i++)
            {
                bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                if (isChecked)
                {
                    MessageBox.Show($"{labels[i].Text}을(를) 입력해주십시오.");
                    return;
                }
                else
                {
                    sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
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
                    Ins_Emp = "수정수정"
                };

                bool resultPlan = planServ.CreatePlan(pr);
                if (resultPlan) MessageBox.Show("생산계획이 등록되었습니다.");
                else MessageBox.Show("생산계획 등록에 실패하였습니다.\n다시 확인하여주십시오.");

                ClearItems(pnlReqInfo);
                
            }
        }


        private void LoadReq(ReqSearchVO rs)
        {
            dgvRequest.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvRequest);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산요청번호", "Prd_Req_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청일자", "Req_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청순번", "Req_Seq", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "품목명", "Item_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "요청수량", "Req_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "거래처", "Customer_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "비고", "Remark", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "프로젝트명", "Project_Nm", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "영업담당자명", "Sale_Prsn_Nm", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "납기일자", "Delivery_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "생산반영수량", "Plan_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvRequest, "진행상태", "Prd_Progress_Status", colWidth: 120);


            dgvRequest.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            reqList = reqServ.GetRequestSearch(rs);
            dgvRequest.DataSource = reqList;
        }

        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            //if (check > 0)
            //{
            //    if (this.DialogResult == DialogResult.No)
            //        return;
            //}

            ChangeValue_Check(0);

            if (tabControl1.SelectedTab.Name.Equals("req"))
            {
                if (rdoReqDate.Checked)
                {
                    rs = new ReqSearchVO()
                    {
                        Tag = rdoReqDate.Tag.ToString(),
                        FromDate = r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                        ToDate = r_dtpToDate.Value.ToString("yyyy-MM-dd"),
                        ItemCode = r_txtItemCode.Text
                    };
                    LoadReq(rs);
                }
                else
                {
                    rs = new ReqSearchVO()
                    {
                        Tag = rdoDeliDate.Tag.ToString(),
                        FromDate = r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
                        ToDate = r_dtpToDate.Value.ToString("yyyy-MM-dd"),
                        ItemCode = r_txtItemCode.Text
                    };
                    LoadReq(rs);
                }

                if (dgvRequest.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                    dgvRequest_CellClick(this, args);
                }
            }
            else
            {
                ps = new PlanSearchVO()
                {
                    PlanMonth = p_dtpPlanDate.Value.ToString("yyyy-MM"),
                    ItemCode = p_txtItemCode.Text,
                    WCCode = txtWCCode.Text
                };

                LoadPlan(ps);

                if (dgvRequest.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                    dgvPlan_CellClick(this, args);
                }
            }
        }





        /// <summary>
        /// check의 value를 변경 (1:기본, 1:추가, 2:편집, 3:삭제)
        /// </summary>
        /// <param name="check"></param>
        private void ChangeValue_Check(int check)
        {
            this.check = check;

            //기본
            if (check == 0)
            {
                main.toolSelect.Enabled = true;
                main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
                main.toolCreate.BackColor = main.toolUpdate.BackColor = Color.DarkGray;
                //foreach (Control ctrl in pnlDetail.Controls)
                //{
                //    if (ctrl is TextBox txt)
                //    {
                //        txt.ReadOnly = true;
                //        txt.Text = "";
                //    }
                //    else if (ctrl is ComboBox cbo)
                //    {
                //        cbo.Enabled = false;
                //        cbo.Text = "";
                //    }
                //}

            }
            //추가
            //else if (check == 1)
            //{
            //    main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
            //    main.toolUpdate.Enabled = main.toolDelete.Enabled = false;

            //    main.toolCreate.BackColor = Color.Yellow;

            //}
            ////편집
            //else if (check == 2)
            //{
            //    main.toolSelect.Enabled = main.toolUpdate.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
            //    main.toolCreate.Enabled = main.toolDelete.Enabled = false;

            //    main.toolUpdate.BackColor = Color.Yellow;
            //}

            //삭제
            //else if (check == 3)
            //{

            //}
        }



        private void RpClearItem()
        {
            rp_txtReqNo.Text = "";
            rp_txtReqDate.Text = "";
            rp_txtReqSeq.Text = "";
            rp_txtItemCode.Text = "";
            rp_txtItemName.Text = "";
            rp_txtWCCode.Text = "";
            rp_txtWCName.Text = "";
            rp_txtReqQty.Text = "";
            rp_txtPlanQty.Text = "";
            rp_txtCustomerName.Text = "";
            rp_txtDeliDate.Text = "";
            rp_txtRemark.ReadOnly = true;

            rp_dtpPlanMonth.Value = DateTime.Now;
            rp_dtpPlanMonth.Enabled = false;

            rp_btnWCSearch.BackColor = Color.Gray;
            rp_btnWCSearch.Enabled = false;

            rp_dtpPlanMonth.Enabled = false;
            rp_txtPlanQty.ReadOnly = true;
            rp_btnWCSearch.Enabled = false;
            rp_btnWCSearch.BackColor = Color.Gray;
            rp_txtRemark.ReadOnly = true;

        }

        private void frmWorkPlan_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;

            r_dtpFromDate.Value = DateTime.Now.AddDays(-3);
            r_dtpToDate.Value = DateTime.Now;

            ChangeValue_Check(0);

            p_btnSave.Enabled = false;
            p_btnCancle.Enabled = false;

            //LoadDataRequest();
            //LoadDataPlan();
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
        private void LoadPlan(PlanSearchVO ps)
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

            listPlan = planServ.GetPlanList(ps);
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
            //PpClearItem();

            p_btnCancle.Enabled = true;
            p_btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            ClearItems(panel3);

            pp_dtpPlanMonth.Enabled = true;
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
        private void PpClearItem()
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

        private void ClearItems(Panel pnl)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.ReadOnly = true;
                    txt.Text = "";
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                    dtp.Enabled = false;
                }
                else
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = Color.Gray;
                        btn.Enabled = false;
                    }
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadDataRequest();
            //LoadDataPlan();
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
            //dgvPlan.EndEdit();
            if (string.IsNullOrWhiteSpace(pp_txtPlanNo.Text))
            {
                MessageBox.Show("수정할 생산계획을 먼저 선택하여주십시오.");
                return;
            }

            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            p_btnCancle.Enabled = true;
            p_btnSave.Enabled = true;

            pp_txtPlanQty.ReadOnly = false;
            pp_txtRemark.ReadOnly = false;
            pp_btnItemSearch.BackColor = Color.Black;
            pp_btnItemSearch.Enabled = true;
            pp_btnWCSearch.BackColor = Color.Black;
            pp_btnWCSearch.Enabled = true;

            
        }

        /// <summary>
        /// 생산계획 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //dgvPlan.EndEdit();

            if (string.IsNullOrWhiteSpace(pp_txtPlanNo.Text))
            {
                MessageBox.Show("삭제할 생산계획을 먼저 선택하여주십시오.");
                return;
            }

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
                    //LoadDataPlan();
                }
                else MessageBox.Show("삭제에 실패하였습니다.\n생산계획 상태를 확인하여주십시오.");
            }
            p_dtpPlanDate.Text = pp_dtpPlanMonth.Value.ToString("yyyy-MM");

            ps = new PlanSearchVO()
            {
                PlanMonth = pp_dtpPlanMonth.Value.ToString("yyyy-MM"),
                ItemCode = p_txtItemCode.Text,
                WCCode = txtWCCode.Text
            };

            LoadPlan(ps);
            ClearItems(panel3);
        }

        /// <summary>
        /// 생산계획 마감
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(pp_txtPlanNo.Text))
            {
                MessageBox.Show("마감할 생산계획을 선택하여주십시오.");
                return;
            }

            DialogResult reqResult = MessageBox.Show($"{pp_txtPlanNo.Text}을 마감하시겠습니까?", "생산계획 마감", MessageBoxButtons.YesNo);

            if (reqResult == DialogResult.Yes)
            {
                bool eResult = planServ.EndPlan(pp_txtPlanNo.Text);
                if (eResult)
                {
                    MessageBox.Show("생산계획 마감이 완료되었습니다.");

                    ps = new PlanSearchVO()
                    {
                        PlanMonth = pp_dtpPlanMonth.Value.ToString("yyyy-MM"),
                        ItemCode = "",
                        WCCode = ""
                    };

                    p_dtpPlanDate.Text = pp_dtpPlanMonth.Value.ToString("yyyy-MM");
                    LoadPlan(ps);
                }
                else MessageBox.Show("생산계획 마감에 실패하였습니다.\n생산계획 상태가 '작업지시생성'인 경우에만 마감할 수 있습니다.");

            }
        }

        /// <summary>
        /// 생산계획 마감취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndCancle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pp_txtPlanNo.Text))
            {
                MessageBox.Show("마감 취소할 생산계획을 선택하여주십시오.");
                return;
            }

            DialogResult reqResult = MessageBox.Show($"{pp_txtPlanNo.Text}을 마감하시겠습니까?", "생산계획 마감 취소", MessageBoxButtons.YesNo);

            if (reqResult == DialogResult.Yes)
            {
                bool ecResult = planServ.EndCanclePlan(pp_txtPlanNo.Text);
                if (ecResult)
                {
                    MessageBox.Show("생산계획 마감 취소가 완료되었습니다.");

                    ps = new PlanSearchVO()
                    {
                        PlanMonth = pp_dtpPlanMonth.Value.ToString("yyyy-MM"),
                        ItemCode = "",
                        WCCode = ""
                    };

                    p_dtpPlanDate.Text = pp_dtpPlanMonth.Value.ToString("yyyy-MM");
                    LoadPlan(ps);
                }
                else MessageBox.Show("생산계획 마감 취소에 실패하였습니다.\n생산계획 상태가 '생산계획마감'인 경우에만 마감 취소할 수 있습니다.");

            }
        }

        private void btnWCSearch_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtWCCode.Text = frm.Send.Wc_Code;
                txtWCName.Text = frm.Send.Wc_Name;
            }
        }


        /// <summary>
        /// 계획수량 유효성(숫자여부)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPlan_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        /// <summary>
        /// 검색조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void OnSelect(object sender, EventArgs e)
        //{
        //    if (tabControl1.SelectedTab.Name.Equals("req"))
        //    {
        //        if (rdoReqDate.Checked)
        //        {
        //            if (string.IsNullOrWhiteSpace(r_txtItemCode.Text))
        //            {
        //                LoadReqSearch(rdoReqDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
        //                    r_dtpToDate.Value.ToString("yyyy-MM-dd"), "");
        //            }
        //            else
        //            {
        //                LoadReqSearch(rdoReqDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
        //                    r_dtpToDate.Value.ToString("yyyy-MM-dd"), r_txtItemCode.Text);
        //            }
        //        }
        //        else if (rdoDeliDate.Checked)
        //        {
        //            if (string.IsNullOrWhiteSpace(r_txtItemCode.Text))
        //            {
        //                LoadReqSearch(rdoDeliDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
        //                    r_dtpToDate.Value.ToString("yyyy-MM-dd"), "");
        //            }
        //            else
        //            {
        //                LoadReqSearch(rdoDeliDate.Tag.ToString(), r_dtpFromDate.Value.ToString("yyyy-MM-dd"),
        //                    r_dtpToDate.Value.ToString("yyyy-MM-dd"), r_txtItemCode.Text);
        //            }
        //        }
        //        else
        //        {
        //            LoadReqSearch("", "", "", r_txtItemCode.Text);
        //        }
        //    }
        //    else
        //    {

        //    }
        //}

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

            //List<RequestVO> listReqSearch = reqServ.GetRequestSearch(tag, fromDate, toDate, item);
            dgvRequest.Columns["Req_Qty"].ReadOnly = false;
            dgvRequest.Columns["Customer_Name"].ReadOnly = false;
            dgvRequest.Columns["Project_Nm"].ReadOnly = false;
            dgvRequest.Columns["Delivery_Date"].ReadOnly = false;
            //dgvRequest.DataSource = listReqSearch;
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




        private void rp_txtPlanQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
                MessageBox.Show("수량은 숫자로 입력하여주십시오.");
                rp_txtPlanQty.Text = "";
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void rp_dtpPlanMonth_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(rp_dtpPlanMonth.Value.ToString("yyyyMM"))
                < Convert.ToInt32(DateTime.Now.ToString("yyyyMM")))
            {
                MessageBox.Show("생산계획 월은 현재보다 과거일 수 없습니다.");
                rp_dtpPlanMonth.Value = DateTime.Now;
                return;
            }
        }

        private void frmWorkPlan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e.KeyChar == 13)
            //{
            //    SendKeys.Send("{Tab}");
            //}
        }

        private void rp_txtPlanQty_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(rp_txtPlanQty.Text.Trim())
                && int.Parse(rp_txtReqQty.Text) < int.Parse(rp_txtPlanQty.Text))
            {
                MessageBox.Show("생산계획 수량은 요청수량을 넘길 수 없습니다.");
                rp_txtPlanQty.Text = "";
                rp_txtPlanQty.Focus();
                return;
            }

            if (rp_txtPlanQty.Text == "0")
            {
                MessageBox.Show("생산계획 수량은 0일 수 없습니다.");
                rp_txtPlanQty.Text = "";
                rp_txtPlanQty.Focus();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearItems(pnlReqInfo);

            OnSelect(this, e);
        }

        private void p_btnItemSearch_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                p_txtItemCode.Text = frm.Send.Item_Code;
                p_txtItemName.Text = frm.Send.Item_Name;
            }
        }

        private void p_btnSave_Click(object sender, EventArgs e)
        {

            if (pp_dtpPlanMonth.Enabled)
            {
                PlanService planServ = new PlanService();
                TextBox[] textboxes = {pp_txtItemName, pp_txtWCName, pp_txtPlanQty };
                Label[] labels = {pp_lblItme, pp_lblWC, pp_lblPlanQty};
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < textboxes.Length; i++)
                {
                    bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                    if (isChecked)
                    {
                        MessageBox.Show($"{labels[i].Text}을(를) 입력해주십시오.");
                        return;
                    }
                    else
                    {
                        sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
                    }
                }

                sb.AppendLine($"{pp_lblPlanMonth.Text} : {pp_dtpPlanMonth.Value.ToString("yyyy-MM")}");
                sb.AppendLine($"{pp_lblRemark.Text} : {pp_txtRemark.Text}");
                sb.AppendLine("위의 정보로 생산계획을 등록하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "생산계획", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    PlanVO ap = new PlanVO()
                    {
                        Plan_Month = pp_dtpPlanMonth.Value.ToString("yyyy-MM"),
                        Item_Code = pp_txtItemCode.Text,
                        Plan_Qty = Convert.ToInt32(pp_txtPlanQty.Text),
                        Wc_Code = pp_txtWCCode.Text,
                        Remark = pp_txtRemark.Text,
                        Ins_Emp = "추가테"
                    };

                    bool ipResult = planServ.AddPlan(ap);
                    if (ipResult)
                    {
                        MessageBox.Show("생산계획이 등록되었습니다.");
                        btnAdd.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        p_btnSave.Enabled = false;
                        p_btnCancle.Enabled = false;

                        ps = new PlanSearchVO()
                        {
                            PlanMonth = pp_dtpPlanMonth.Value.ToString("yyyy-MM"),
                            ItemCode = "",
                            WCCode = ""
                        };

                        p_dtpPlanDate.Text = pp_dtpPlanMonth.Value.ToString("yyyy-MM");
                        LoadPlan(ps);
                        ClearItems(panel3);
                    }
                    else MessageBox.Show("생산계획 등록에 실패하였습니다.\n다시 확인하여 주십시오.");
                }

                
                
            }
            else
            {
                pp_dtpPlanMonth.Enabled = false;

                if (string.IsNullOrWhiteSpace(pp_txtPlanNo.Text))
                {
                    MessageBox.Show("수정할 생산계획을 먼저 선택하여주십시오.");
                    return;
                }

                PlanService planServ = new PlanService();

                #region 유효성 검사, 출력 정보 입력
                TextBox[] textboxes = { pp_txtPlanNo, pp_txtItemName, pp_txtWCName, pp_txtPlanQty };
                Label[] labels = { pp_lblPlanNo, pp_lblItme, pp_lblWC, pp_lblPlanQty };
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
                sb.AppendLine($"{pp_lblRemark.Text} : {pp_txtRemark.Text}");
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

                    bool rPlanUpdate = planServ.UpdatePlan(up);
                    if (rPlanUpdate)
                    {
                        MessageBox.Show("생산계획이 수정되었습니다.");
                        btnAdd.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        p_btnSave.Enabled = false;
                        p_btnCancle.Enabled = false;

                        p_dtpPlanDate.Text = pp_dtpPlanMonth.Value.ToString("yyyy-MM");

                        ps = new PlanSearchVO()
                        {
                            PlanMonth = pp_dtpPlanMonth.Value.ToString("yyyy-MM"),
                            ItemCode = p_txtItemCode.Text,
                            WCCode = txtWCCode.Text
                        };
                        LoadPlan(ps);
                        ClearItems(panel3);
                    }
                    else MessageBox.Show("생산계획 수정에 실패하였습니다.\n다시 확인하여주십시오.");

                    
                    #endregion
                }
            }
        }

        private void pp_txtPlanQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
                MessageBox.Show("수량은 숫자로 입력하여주십시오.");
                pp_txtPlanQty.Text = "";
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void pp_txtPlanQty_Leave(object sender, EventArgs e)
        {
            if (pp_txtPlanQty.Text == "0")
            {
                MessageBox.Show("생산계획 수량은 0일 수 없습니다.");
                pp_txtPlanQty.Text = "";
                pp_txtPlanQty.Focus();
                return;
            }
        }

        private void p_btnCancle_Click(object sender, EventArgs e)
        {
            ClearItems(panel3);
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            p_btnSave.Enabled = false;
            p_btnCancle.Enabled = false;
        }

        private void pp_dtpPlanMonth_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(pp_dtpPlanMonth.Value.ToString("yyyyMM"))
               < Convert.ToInt32(DateTime.Now.ToString("yyyyMM")))
            {
                MessageBox.Show("생산계획 월은 현재보다 과거일 수 없습니다.");
                pp_dtpPlanMonth.Value = DateTime.Now;
                return;
            }
        }

        private void rp_dtpPlanMonth_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(rp_dtpPlanMonth.Value.ToString("yyyyMM"))
               < Convert.ToInt32(DateTime.Now.ToString("yyyyMM")))
            {
                MessageBox.Show("생산계획 월은 현재보다 과거일 수 없습니다.");
                rp_dtpPlanMonth.Value = DateTime.Now;
                return;
            }
        }

        private void rp_btnWCSearch_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                rp_txtWCCode.Text = frm.Send.Wc_Code;
                rp_txtWCName.Text = frm.Send.Wc_Name;
            }
        }
    }
}
