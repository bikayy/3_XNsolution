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
    public partial class frmSiyuOrder : Form
    {
        List<GetPlanListVO> listPlan = new List<GetPlanListVO>();
        List<OrderVO> listOrder = new List<OrderVO>();
        PlanSearchVO ps = null;

        OrderService orderServ = new OrderService();
        PlanService planServ = new PlanService();

        //PlanSearchVO ps = null;


        Main main = null;


        /// <summary>
        /// 0:기본, 1:추가, 2:편집, 3:삭제
        /// </summary>
        int check = 0; //추가,편집 구분을 위한 숫자 -- 1:추가, 2:편집, 3:삭제, 

        public frmSiyuOrder()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtItemCode.Text) && string.IsNullOrWhiteSpace(txtWCCode.Text))
            {
                ps = new PlanSearchVO()
                {
                    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    ItemCode = "",
                    WCCode = ""
                };

                LoadPlan(ps);
                //LoadOrder(ps);

                if (dgvPlan.Rows.Count > 0)
                {
                    DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                    dgvPlan_CellClick(this, args);
                }

            }
            else if (!string.IsNullOrWhiteSpace(txtItemCode.Text) && string.IsNullOrWhiteSpace(txtWCCode.Text))
            {
                ps = new PlanSearchVO()
                {
                    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    ItemCode = txtItemCode.Text,
                    WCCode = ""
                };

                LoadPlan(ps);
                //LoadOrder(ps);
            }
            else if (string.IsNullOrWhiteSpace(txtItemCode.Text) && !string.IsNullOrWhiteSpace(txtWCCode.Text))
            {
                ps = new PlanSearchVO()
                {
                    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    ItemCode = "",
                    WCCode = txtWCCode.Text
                };

                LoadPlan(ps);
                //LoadOrder(ps);
            }
            else
            {
                ps = new PlanSearchVO()
                {
                    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    ItemCode = txtItemCode.Text,
                    WCCode = txtWCCode.Text
                };

                LoadPlan(ps);
                //LoadOrder(ps);
            }
        }

        private void LoadPlan(PlanSearchVO ps)
        {
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
            dgvPlan.DataSource = listPlan;

        }

        private void LoadOrder(string planNo)//PlanSearchVO ps)
        {  //Wo_Status, WorkOrderNo, Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code,
            //Prd_Date, Prd_Qty, Plan_StartTime, Plan_EndTime, Prd_StartTime, Prd_EndTime,
            //Worker_CloseTime, Manager_CloseTime, Close_CancelTime, Remark, 
            //Prd_Plan_No, Ins_Date, Ins_Emp, Up_Date, Up_Emp
            dgvOrder.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvOrder);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업지시상태", "Wo_Status", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업지시번호", "WorkOrderNo", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업계획일자", "Plan_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업계획수량", "Plan_Qty_Box",  colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "품목코드", "Item_Code",  colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "품목명", "Item_Name",  colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업장코드", "Wc_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업장명", "Wc_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "계획시작시간", "Plan_StartTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "계획종료시간", "Plan_EndTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "비고", "Remark", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "생산수량", "Prd_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업시작시간", "Prd_StartTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "작업종료시간", "Prd_EndTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "현장마감시간", "Worker_CloseTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "관리자마감시간", "Manager_CloseTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "마감취소시간", "Close_CancelTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "생산계획번호", "Prd_Plan_No", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "최초입력일자", "Ins_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "최초입력자", "Ins_Emp", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "최종수정일자", "Up_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvOrder, "최종수정자", "Up_Emp", colWidth: 120);


            dgvOrder.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            listOrder = orderServ.SelectOrder(planNo);
            dgvOrder.DataSource = listOrder;

            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                string status = dgvOrder.Rows[i].Cells["Wo_Status"].Value.ToString();

                switch (status)
                {
                    case "생산대기":
                        dgvOrder.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Orange;
                        break;
                    case "생산중":
                        dgvOrder.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Green;
                        break;
                    case "생산중지":
                        dgvOrder.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Gold;
                        break;
                    case "현장마감":
                        dgvOrder.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.LightSteelBlue;
                        break;
                    case "작업지시마감":
                        dgvOrder.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Blue;
                        break;
                    default: break;
                }
            }
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

        private void dgvPlan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            ClearItems(grbOrder);

            string planNo = dgvPlan[0, e.RowIndex].Value.ToString();
            List<GetPlanListVO> planInfo = (List<GetPlanListVO>)dgvPlan.DataSource;
            GetPlanListVO plan = planInfo.Find((item) => item.Prd_Plan_No == planNo);

            if (plan != null)
            {
                p_txtItemCode.Text = plan.Item_Code;
                p_txtItemName.Text = plan.Item_Name;
                p_txtPlanNo.Text = plan.Prd_Plan_No;
                p_txtCustomer.Text = plan.Customer_Name;
                p_txtPlanQty.Text = plan.Plan_Qty.ToString();
                p_txtWCCode.Text = plan.Wc_Code;
                p_txtWCName.Text = plan.Wc_Name;
                p_dtpPlanDate.Text = plan.Plan_Month;
            }

            LoadOrder(planNo);
            if (dgvOrder.Rows.Count > 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                dgvOrder_CellClick(this, args);
            }
        }

        private void p_btnWCSearch_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                p_txtWCCode.Text = frm.Send.Wc_Code;
                p_txtWCName.Text = frm.Send.Wc_Name;
            }
        }


        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            dgvOrder.Enabled = false;

            if (string.IsNullOrWhiteSpace(p_txtPlanNo.Text))
            {
                MessageBox.Show("생산계획을 먼저 선택하여주십시오.");
                return;
            }

            ClearItems(grbOrder);
            VitalOrderInfo();
        }

        private void VitalOrderInfo()
        {
            o_btnWCSearch.Enabled = true;
            o_btnWCSearch.BackColor = Color.Black;
            o_txtOrderQty.ReadOnly = false;
            ///aaa.Enabled = true;
            o_dtpFromTime.Enabled = true;
            o_dtpToTime.Enabled = true;
            o_txtRemark.ReadOnly = false;

            o_txtItemCode.Text = p_txtItemCode.Text;
            o_txtItemName.Text = p_txtItemName.Text;
            o_txtWCCode.Text = p_txtWCCode.Text;
            o_txtWCName.Text = p_txtWCName.Text;
        }

        private void ClearItems(GroupBox grb)
        {
            foreach (Control ctrl in grb.Controls)
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

        private void p_btnWCSearch_Click_1(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                p_txtWCCode.Text = frm.Send.Wc_Code;
                p_txtWCName.Text = frm.Send.Wc_Name;
            }
        }

        

        private void frmSiyuOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(o_txtOrderNo.Text))
            {
                if (o_txtOrderQty.ReadOnly)
                {
                    MessageBox.Show("작업지시 생성을 먼저 클릭하여주십시오.");
                    return;
                }

                TextBox[] textboxes = { p_txtPlanNo, o_txtItemName, o_txtWCName, o_txtOrderQty };
                Label[] labels = { p_lblPlanNo, o_lblItem, o_lblWC, o_lblOrderQty };
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < textboxes.Length; i++)
                {
                    bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                    if (isChecked)
                    {
                        MessageBox.Show($"{labels[i].Text}을(를) 입력하여주십시오.");
                        return;
                    }
                    else
                    {
                        sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
                    }
                }

                //sb.AppendLine($"{o_lblOPDate.Text} : {o_dtpOPDate.Value.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"{o_lblOPTime.Text} : {o_dtpFromTime.Value.ToString("yyyy-MM-dd HH:mm")} ~ \n{o_dtpToTime.Value.ToString("yyyy-MM-dd HH:mm")}");
                sb.AppendLine($"{o_lblRemark.Text} : {o_txtRemark.Text}");
                sb.AppendLine("위의 정보로 작업지시를 등록하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "작업지시생성", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OrderVO io = new OrderVO()
                    {  //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Plan_StartTime,
                       //Plan_EndTime, Remark, Prd_Plan_No, Ins_Date, Ins_Emp
                        Plan_Date = o_dtpFromTime.Value.ToString("yyyy-MM-dd"),
                        Plan_Qty_Box = Convert.ToInt32(o_txtOrderQty.Text),
                        Item_Code = o_txtItemCode.Text,
                        Wc_Code = o_txtWCCode.Text,
                        Plan_StartTime = o_dtpFromTime.Value.ToString("yyyy-MM-dd HH:mm"),
                        Plan_EndTime = o_dtpToTime.Value.ToString("yyyy-MM-dd HH:mm"),
                        Remark = o_txtRemark.Text,
                        Prd_Plan_No = p_txtPlanNo.Text,
                        Ins_Emp = "수정수정!"
                    };
                    bool orResult = orderServ.CreateOrder(io);

                    if (orResult)
                    {
                        MessageBox.Show("작업지시가 생성되었습니다.");
                        ClearItems(grbOrder);
                        LoadOrder(p_txtPlanNo.Text);
                        if (dgvOrder.Rows.Count > 0)
                        {
                            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                            dgvOrder_CellClick(this, args);
                        }
                    }
                    else MessageBox.Show("작업지시 생성에 실패하였습니다.\n작업지시 상태를 확인하여주십시오.");

                    //ps = new PlanSearchVO()
                    //{
                    //    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    //    ItemCode = txtItemCode.Text,
                    //    WCCode = txtWCCode.Text
                    //};
                    //LoadOrder(ps);
                }

                //ClearItems(grbPlan);
                //ClearItems(grbOrder);
                dgvOrder.Enabled = true;
            }
            else //수정기능
            {
                if (string.IsNullOrWhiteSpace(o_txtOrderNo.Text))
                {
                    MessageBox.Show("수정할 작업지시를 선택하여주십시오.");
                    return;
                }

                TextBox[] textboxes = { o_txtOrderNo, o_txtItemName, o_txtWCName, o_txtOrderQty };
                Label[] labels = { o_lblPlanNo, o_lblItem, o_lblWC, o_lblOrderQty };
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < textboxes.Length; i++)
                {
                    bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                    if (isChecked)
                    {
                        MessageBox.Show($"{labels[i].Text}을(를) 입력하여주십시오.");
                        return;
                    }
                    else
                    {
                        sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
                    }
                }

                //sb.AppendLine($"{o_lblOPDate.Text} : {o_dtpOPDate.Value.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"{o_lblOPTime.Text} : {o_dtpFromTime.Value.ToString("yyyy-MM-dd HH:mm")} ~ \n{o_dtpToTime.Value.ToString("yyyy-MM-dd HH:mm")}");
                sb.AppendLine($"{o_lblRemark.Text} : {o_txtRemark.Text}");
                sb.AppendLine($"{o_lblRemark.Text} : {o_txtRemark.Text}");
                sb.AppendLine("위의 정보로 작업지시를 수정하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "작업지시수정", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    OrderVO uo = new OrderVO()
                    {  //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Plan_StartTime,
                       //Plan_EndTime, Remark, Prd_Plan_No, Ins_Date, Ins_Emp
                        WorkOrderNo = o_txtOrderNo.Text,
                        Plan_Date = o_dtpFromTime.Value.ToString("yyyy-MM-dd"),
                        Plan_Qty_Box = Convert.ToInt32(o_txtOrderQty.Text),
                        Wc_Code = o_txtWCCode.Text,
                        Plan_StartTime = o_dtpFromTime.Value.ToString("yyyy-MM-dd HH:mm"),
                        Plan_EndTime = o_dtpToTime.Value.ToString("yyyy-MM-dd HH:mm"),
                        Remark = o_txtRemark.Text,
                        Up_Emp = "업뎃수정!"
                    };
                    bool orResult = orderServ.UpdateOrder(uo);

                    if (orResult)
                    {
                        MessageBox.Show("작업지시가 수정되었습니다.");
                        ClearItems(grbOrder);
                        LoadOrder(p_txtPlanNo.Text);
                        if (dgvOrder.Rows.Count > 0)
                        {
                            DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                            dgvOrder_CellClick(this, args);
                        }
                    }
                    else MessageBox.Show("작업지시 수정에 실패하였습니다.\n작업지시 상태를 확인하여주십시오.");

                    //ps = new PlanSearchVO()
                    //{
                    //    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    //    ItemCode = txtItemCode.Text,
                    //    WCCode = txtWCCode.Text
                    //};
                    //LoadOrder(ps);
                }
                
                //ClearItems(grbPlan);
                //ClearItems(grbOrder);
                //dgvOrder.Enabled = true;
            }

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(o_txtOrderNo.Text))
            {
                MessageBox.Show("수정할 작업지시를 선택하여주십시오.");
                return;
            }

            o_btnWCSearch.Enabled = true;
            o_btnWCSearch.BackColor = Color.Black;
            o_txtOrderQty.ReadOnly = false;
            ///aaa.Enabled = true;
            o_dtpFromTime.Enabled = true;
            o_dtpToTime.Enabled = true;
            o_txtRemark.ReadOnly = false;
        }




        private void o_txtOrderQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
                MessageBox.Show("수량은 숫자로 입력해주십시오.");
                o_txtOrderQty.Text = "";
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void o_dtpOPDate_Validating(object sender, CancelEventArgs e)
        {
            if (aaa.Value < DateTime.Now.AddDays(-1))
            {
                MessageBox.Show("생산일자가 현재일보다  이전일 수 없습니다.");
                aaa.Value = DateTime.Now;
                aaa.Focus();
                return;
            }

            if (Convert.ToInt32(p_dtpPlanDate.Value.ToString("yyyyMM")) < Convert.ToInt32(aaa.Value.ToString("yyyyMM")))
            {
                MessageBox.Show("생산일자는 생산계획월을 넘어갈 수 없습니다.");
                aaa.Value = DateTime.Now;
                aaa.Focus();
                return;
            }
        }

        private void o_btnWCSearch_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();
            
            if (frm.DialogResult == DialogResult.OK)
            {
                o_txtWCCode.Text = frm.Send.Wc_Code;
                o_txtWCName.Text = frm.Send.Wc_Name;
            }
        }

        private void o_txtOrderQty_Leave(object sender, EventArgs e)
        {
            if (o_txtOrderQty.Text.Equals("0"))
            {
                MessageBox.Show("작업지시수량은 0일 수 없습니다.");
                o_txtOrderQty.Text = "";
                o_txtOrderQty.Focus();
                return;
            }

            if (!string.IsNullOrWhiteSpace(o_txtOrderQty.Text)
                && int.Parse(o_txtOrderQty.Text) > int.Parse(p_txtPlanQty.Text))
            {
                MessageBox.Show("작업지시수량은 생산계획수량을 넘을 수 없습니다.");
                o_txtOrderQty.Text = "";
                o_txtOrderQty.Focus();
                return;
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(o_txtOrderNo.Text))
            {
                MessageBox.Show("마감할 작업지시를 선택하여주십시오.");
                return;
            }

            DialogResult result = MessageBox.Show($"{ o_txtOrderNo.Text}의 작업지시를 마감하시겠습니까?", "작업지시마감", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                bool endResult = orderServ.EndOrder(o_txtOrderNo.Text);
                if (endResult)
                {
                    MessageBox.Show("작업지시가 마감되었습니다.");
                    ps = new PlanSearchVO()
                    {
                        PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                        ItemCode = txtItemCode.Text,
                        WCCode = txtWCCode.Text
                    };
                    //LoadOrder(ps);
                    ClearItems(grbOrder);
                }
                else MessageBox.Show("작업지시 마감에 실패하였습니다.\n작업지시 상태를 확인하여주십시오.");
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            ClearItems(grbPlan);

            string orderNo = dgvOrder[1, e.RowIndex].Value.ToString();
            List<OrderVO> orderInfo = (List<OrderVO>)dgvOrder.DataSource;
            OrderVO order = orderInfo.Find((item) => item.WorkOrderNo == orderNo);

            if (order != null)
            {
                o_txtOrderNo.Text = order.WorkOrderNo;
                o_txtItemCode.Text = order.Item_Code;
                o_txtItemName.Text = order.Item_Name;
                o_txtWCCode.Text = order.Wc_Code;
                o_txtWCName.Text = order.Wc_Name;
                o_txtOrderQty.Text = order.Plan_Qty_Box.ToString();
                //aaa.Text = order.Plan_Date;
                o_dtpFromTime.Text = order.Plan_StartTime;
                o_dtpToTime.Text = order.Plan_EndTime;
                o_txtRemark.Text = order.Remark;
            }

            string planNo = dgvOrder[18, e.RowIndex].Value.ToString();
            List<GetPlanListVO> planInfo = (List<GetPlanListVO>)dgvPlan.DataSource;
            GetPlanListVO plan = planInfo.Find((item) => item.Prd_Plan_No == planNo);

            if (plan != null)
            {
                p_txtItemCode.Text = plan.Item_Code;
                p_txtItemName.Text = plan.Item_Name;
                p_txtPlanNo.Text = plan.Prd_Plan_No;
                p_txtCustomer.Text = plan.Customer_Name;
                p_txtPlanQty.Text = plan.Plan_Qty.ToString();
                p_txtWCCode.Text = plan.Wc_Code;
                p_txtWCName.Text = plan.Wc_Name;
                p_dtpPlanDate.Text = plan.Plan_Month;
            }
        }

        private void btnEndCancle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(o_txtOrderNo.Text))
            {
                MessageBox.Show("마감 취소할 작업지시를 선택하여주십시오.");
                return;
            }

            DialogResult result = MessageBox.Show($"{ o_txtOrderNo.Text}의 작업지시를 마감 취소하시겠습니까?", "작업지시마감취소", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                bool endCancleResult = orderServ.EndCancleOrder(o_txtOrderNo.Text);
                if (endCancleResult)
                {
                    MessageBox.Show("작업지시가 마감 취소되었습니다.");
                    ps = new PlanSearchVO()
                    {
                        PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                        ItemCode = txtItemCode.Text,
                        WCCode = txtWCCode.Text
                    };
                    //LoadOrder(ps);
                    ClearItems(grbOrder);
                }
                else MessageBox.Show("작업지시 마감 취소에 실패하였습니다.\n작업지시 상태를 확인하여주십시오.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            VitalOrderInfo();
        }

        private void o_dtpFromTime_Validating(object sender, CancelEventArgs e)
        {
            if (aaa.Value.ToString("yyymmdd") == DateTime.Now.ToString("yyyymmdd") &&
                Convert.ToInt32(o_dtpFromTime.Value.ToString("HHmm")) < Convert.ToInt32(DateTime.Now.ToString("HHmm")))
            {
                MessageBox.Show("계획시작시간은 현재시각 이전일 수 없습니다.");
                o_dtpFromTime.Text = DateTime.Now.ToString("tt HH:mm");
                o_dtpFromTime.Focus();
                return;
            }
        }

        private void o_dtpToTime_Validating(object sender, CancelEventArgs e)
        {
            if (Convert.ToInt32(o_dtpFromTime.Value.ToString("HHmm")) > Convert.ToInt32(o_dtpToTime.Value.ToString("HHmm")))
            {
                MessageBox.Show("계획종료시간은 계획시작시간 이후로 설정하여주십시오.");
                o_dtpToTime.Focus();
                return;
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
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = true;
                main.toolSave.Enabled = main.toolCancle.Enabled = false;
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
            else if (check == 1)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolUpdate.Enabled = false;

                main.toolCreate.BackColor = Color.Yellow;

            }
            //편집
            else if (check == 2)
            {
                main.toolSelect.Enabled = main.toolUpdate.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolCreate.Enabled = main.toolDelete.Enabled = false;

                main.toolUpdate.BackColor = Color.Yellow;
            }

            //ControlState();
            //삭제
            //else if (check == 3)
            //{

            //}
        }

        private void frmSiyuOrder_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            //main.Select += OnSelect;
            //main.Create += OnCreate;
            //main.Update += OnUpdate;
            //main.Save += OnSave;
            //main.Delete += OnDelete;
            //main.Cancle += OnCancle;
        }


        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (check > 0)
            {
                OnCancle(this, e);

                if (this.DialogResult == DialogResult.No)
                    return;
            }

            ChangeValue_Check(0);
        }


        private void OnCancle(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            string menu;
            if (main.toolCreate.BackColor == Color.Yellow)
                menu = "추가";
            else
                menu = "편집";

            if (MessageBox.Show($"{menu}한 데이터를 저장하지 않고 기능을 취소하시겠습니까?.", "취소확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ChangeValue_Check(0);

                OnSelect(this, e);
                //this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void btnOrderDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(o_txtOrderNo.Text))
            {
                MessageBox.Show("삭제할 작업지시를 선택하여주십시오.");
                return;
            }

            DialogResult result = MessageBox.Show($"{o_txtOrderNo.Text}의 작업지시를 삭제하시겠습니까?", "작업지시삭제", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool dResult = orderServ.DeleteOrder(o_txtOrderNo.Text);

                if (dResult)
                {
                    MessageBox.Show("작업지시가 삭제되었습니다.");
                    ClearItems(grbOrder);
                    LoadOrder(p_txtPlanNo.Text);
                    if (dgvOrder.Rows.Count > 0)
                    {
                        DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                        dgvOrder_CellClick(this, args);
                    }
                }
                else MessageBox.Show("작업지시 삭제에 실패하였습니다.\n작업지시 상태를 확인하여주십시오.");

                ps = new PlanSearchVO()
                {
                    PlanMonth = dtpPlanMonth.Value.ToString("yyyy-MM"),
                    ItemCode = txtItemCode.Text,
                    WCCode = txtWCCode.Text
                };
                //LoadOrder(ps);
                //ClearItems(grbPlan);
                //ClearItems(grbOrder);
                dgvOrder.Enabled = true;
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            dgvOrder.Enabled = true;
            //ClearItems(grbPlan);
            ClearItems(grbOrder);

            LoadOrder(p_txtPlanNo.Text);
            if (dgvOrder.Rows.Count > 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                dgvOrder_CellClick(this, args);
            }
        }




        //private void ControlState()
        //{
        //    if (check <= 1) //0:기본, 1:추가
        //        if (check == 1 && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= rowCount) //추가한 행
        //        {

        //            foreach (Control ctrl in pnlDetail.Controls)
        //            {
        //                if (ctrl is Label) continue;

        //                else if (ctrl is TextBox txt)
        //                    txt.ReadOnly = false;
        //                else if (ctrl is ComboBox cbo)
        //                    cbo.Enabled = true;
        //            }
        //        }
        //        else //기존 행
        //        {
        //            foreach (Control ctrl in pnlDetail.Controls)
        //            {
        //                if (ctrl is Label) continue;
        //                else if (ctrl is TextBox txt)
        //                    txt.ReadOnly = true;
        //                else if (ctrl is ComboBox cbo)
        //                    cbo.Enabled = false;
        //            }
        //        }
        //    else if (check == 2) //2:편집
        //    {

        //        foreach (Control ctrl in pnlDetail.Controls)
        //        {
        //            if (ctrl is Label) continue;
        //            else if (ctrl is TextBox txt)
        //            {
        //                if (ctrl.Name.Equals("txtProcessCode")) continue;
        //                txt.ReadOnly = false;
        //            }
        //            else if (ctrl is ComboBox cbo)
        //                cbo.Enabled = true;
        //        }
        //    }
        //}



    }
}
