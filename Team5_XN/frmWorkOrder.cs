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
    public partial class frmWorkOrder : Form
    {
        WorkOrderService woServ = new WorkOrderService();
        List<WOSelectVO> listWo = new List<WOSelectVO>();
        string status = string.Empty;
        Main main = null;


        public frmWorkOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopupUpdatePalette frm = new PopupUpdatePalette();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PopupCreatePalette frm = new PopupCreatePalette();
            frm.ShowDialog();
        }

        private void s_btnProcess_Click(object sender, EventArgs e)
        {
            PopupSearchProcess frm = new PopupSearchProcess();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                s_txtPrCode.Text = frm.Send.Process_Code;
                s_txtPrName.Text = frm.Send.Process_Name;
            }
        }

        private void i_btnItem_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                i_txtItemCode.Text = frm.Send.Item_Code;
                i_txtItemName.Text = frm.Send.Item_Name;
            }
        }

        private void i_btnProcess_Click(object sender, EventArgs e)
        {
            PopupSearchProcess frm = new PopupSearchProcess();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                i_txtPrCode.Text = frm.Send.Process_Code;
                i_txtPrName.Text = frm.Send.Process_Name;
            }
        }

        private void i_btnWc_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                i_txtWcCode.Text = frm.Send.Wc_Code;
                i_txtWcName.Text = frm.Send.Wc_Name;
            }
        }


        private void ClearItems(Panel pnl)
        {
            //i_txtOrNo.Text = "";
            //i_txtItemCode.Text = "";
            //i_txtItemName.Text = "";
            //i_txtPrCode.Text = "";
            //i_txtPrName.Text = "";
            //i_txtWcCode.Text = "";
            //i_txtWcName.Text = "";

            //i_txtPlanQty.Text = "";
            i_txtPlanQty.ReadOnly = true;
            //i_txtRemark.Text = "";
            i_txtRemark.ReadOnly = true;

            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is DateTimePicker dtp)
                {
                    //dtp.Value = DateTime.Now;
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

        private void activeItems(Panel pnl)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                    dtp.Enabled = true;
                }
                else
                {
                    if (ctrl is Button btn)
                    {
                        btn.BackColor = Color.Black;
                        btn.Enabled = true;
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            i_txtOrNo.Text = "";
            i_txtItemCode.Text = "";
            i_txtItemName.Text = "";
            i_txtPrCode.Text = "";
            i_txtPrName.Text = "";
            i_txtWcCode.Text = "";
            i_txtWcName.Text = "";

            i_txtPlanQty.Text = "";
            i_txtPlanQty.ReadOnly = false;
            i_txtRemark.Text = "";
            i_txtRemark.ReadOnly = false;

            activeItems(pnlDetail);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (status != "생산대기")
            {
                MessageBox.Show("작업지시상태가 '생산대기'인 경우에만 수정할 수 있습니다.");
                return;
            }

            activeItems(pnlDetail);
            i_txtPlanQty.ReadOnly = false;
            i_txtRemark.ReadOnly = false;
            i_btnProcess.Enabled = false;
            i_btnProcess.BackColor = Color.Gray;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            ClearItems(pnlDetail);

            LoadData(s_dtpFrom.Value.ToString("yyyy-MM-dd"), s_dtpTo.Value.ToString("yyyy-MM-dd"),
                s_txtPrCode.Text, s_txtWcCode.Text);
            if (dgvWo.Rows.Count > 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                dgvWo_CellClick(this, args);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ClearItems(pnlDetail);

            LoadData(s_dtpFrom.Value.ToString("yyyy-MM-dd"), s_dtpTo.Value.ToString("yyyy-MM-dd"),
                s_txtPrCode.Text, s_txtWcCode.Text);
            if (dgvWo.Rows.Count > 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                dgvWo_CellClick(this, args);
            }
            else
            {
                i_txtOrNo.Text = "";
                i_txtItemCode.Text = "";
                i_txtItemName.Text = "";
                i_txtPrCode.Text = "";
                i_txtPrName.Text = "";
                i_txtWcCode.Text = "";
                i_txtWcName.Text = "";

                i_txtPlanQty.Text = "";
                i_txtPlanQty.ReadOnly = true;
                i_txtRemark.Text = "";
                i_txtRemark.ReadOnly = true;
            }
        }

        private void LoadData(string planFrom, string planTo, string prCode, string wcCode)
        {
            listWo = woServ.WOSelect(planFrom, planTo, prCode, wcCode);
            dgvWo.DataSource = listWo;

            for (int i = 0; i < dgvWo.Rows.Count; i++)
            {

                switch (dgvWo.Rows[i].Cells["Wo_Status"].Value.ToString())
                {
                    case "생산대기":
                        dgvWo.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Orange;
                        break;
                    case "생산중":
                        dgvWo.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Green;
                        break;
                    case "생산중지":
                        dgvWo.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Gold;
                        break;
                    case "현장마감":
                        dgvWo.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.LightSteelBlue;
                        break;
                    case "작업지시마감":
                        dgvWo.Rows[i].Cells["Wo_Status"].Style.BackColor = Color.Blue;
                        break;
                    default: break;
                }
            }
        }

        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;

            //main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
            //main.toolCreate.BackColor = main.toolUpdate.BackColor = Color.DarkGray;

            DataGridViewUtil.SetInitGridView(dgvWo);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업지시상태", "Wo_Status", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업지시번호", "WorkOrderNo", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업지시일자", "Plan_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업지시수량", "Plan_Qty_Box", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "품목코드", "Item_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "품목명", "Item_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업장코드", "Wc_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업장명", "Wc_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "공정코드", "Process_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "공정명", "Process_Name", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "생산일자", "Prd_Date", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "생산수량", "Prd_Qty", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "지시시작시간", "Plan_StartTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "지시종료시간", "Plan_EndTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업시작시간", "Prd_StartTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "작업종료시간", "Prd_EndTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "현장마감시간", "Worker_CloseTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "관리자마감시간", "Manager_CloseTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "마감취소시간", "Close_CancelTime", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "비고", "Remark", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dgvWo, "생산계획번호", "Prd_Plan_No", colWidth: 120);

            dgvWo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void s_btnWc_Click(object sender, EventArgs e)
        {
            PopupWCSearch frm = new PopupWCSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                s_txtWcCode.Text = frm.Send.Wc_Code;
                s_txtWcName.Text = frm.Send.Wc_Name;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(i_txtOrNo.Text))
            {
                TextBox[] textboxes = { i_txtItemName, i_txtPrName, i_txtWcName, i_txtPlanQty };
                Label[] labels = { i_lblItem, i_lblProcess, i_lblWc, i_lblPlanQty };
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

                sb.AppendLine($"{i_lblPlanDate.Text} : {i_dtpPlanStart.Value.ToString("yyyy-MM-dd HH:mm")} ~ " +
                    $"{i_dtpPlanEnd.Value.ToString("yyyy-MM-dd HH:mm")}");
                sb.AppendLine($"{i_lblRemark.Text} : {i_txtRemark.Text}");
                sb.AppendLine("위의 정보로 작업지시를 등록하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "작업지시생성", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                { //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Process_Code,
                  //Plan_StartTime, Plan_EndTime, Remark, Ins_Emp

                    WOUpsertVO woInsert = new WOUpsertVO
                    {
                        Plan_Date = i_dtpPlanStart.Value.ToString("yyyy-MM-dd"),
                        Plan_Qty_Box = Convert.ToInt32(i_txtPlanQty.Text),
                        Item_Code = i_txtItemCode.Text,
                        Wc_Code = i_txtWcCode.Text,
                        Process_Code = i_txtPrCode.Text,
                        Plan_StartTime = i_dtpPlanStart.Value,
                        Plan_EndTime = i_dtpPlanEnd.Value,
                        Remark = i_txtRemark.Text,
                        Ins_Emp = "홍길동수정"
                    };

                    bool inResult = woServ.WOInsert(woInsert);

                    if (inResult)
                    {
                        MessageBox.Show("작업지시가 생성되었습니다.");
                        LoadData(i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), "", "");
                        s_dtpTo.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                        s_dtpFrom.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                    }
                    else MessageBox.Show("작업지시 생성에 실패하였습니다.\n다시 확인하여주십시오.");
                }
            }
            else
            {
                TextBox[] textboxes = { i_txtItemName, i_txtPrName, i_txtWcName, i_txtPlanQty };
                Label[] labels = { i_lblItem, i_lblProcess, i_lblWc, i_lblPlanQty };
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{i_lblOrNo.Text} : {i_txtOrNo.Text}");

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

                sb.AppendLine($"{i_lblPlanDate.Text} : {i_dtpPlanStart.Value.ToString("yyyy-MM-dd HH:mm")} ~ " +
                    $"{i_dtpPlanEnd.Value.ToString("yyyy-MM-dd HH:mm")}");
                sb.AppendLine($"{i_lblRemark.Text} : {i_txtRemark.Text}");
                sb.AppendLine("위의 정보로 작업지시를 수정하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "작업지시수정", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                { //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Process_Code,
                  //Plan_StartTime, Plan_EndTime, Remark, Ins_Emp

                    WOUpsertVO woUpdate = new WOUpsertVO
                    {
                        WorkOrderNo = i_txtOrNo.Text,
                        Plan_Date = i_dtpPlanStart.Value.ToString("yyyy-MM-dd"),
                        Plan_Qty_Box = Convert.ToInt32(i_txtPlanQty.Text),
                        Item_Code = i_txtItemCode.Text,
                        Wc_Code = i_txtWcCode.Text,
                        Plan_StartTime = i_dtpPlanStart.Value,
                        Plan_EndTime = i_dtpPlanEnd.Value,
                        Remark = i_txtRemark.Text,
                        Up_Emp = "홍길동업뎃수정"
                    };

                    bool inResult = woServ.WOUpdate(woUpdate);

                    if (inResult)
                    {
                        MessageBox.Show("작업지시가 수정되었습니다.");
                        //btnSelect.PerformClick();
                        LoadData(i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), "", "");
                        s_dtpTo.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                        s_dtpFrom.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                    }
                    else MessageBox.Show("작업지시 수정에 실패하였습니다.\n작업지시상태가 '생산대기'인 경우에만 수정할 수 있습니다.");

                }
            }
        }

        private void btnUSave_Click(object sender, EventArgs e)
        {
            //TextBox[] textboxes = { i_txtItemName, i_txtPrName, i_txtWcName, i_txtPlanQty };
            //Label[] labels = { i_lblItem, i_lblProcess, i_lblWc, i_lblPlanQty };
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"{i_lblOrNo.Text} : {i_txtOrNo.Text}");

            //for (int i = 0; i < textboxes.Length; i++)
            //{
            //    bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
            //    if (isChecked)
            //    {
            //        MessageBox.Show($"{labels[i].Text}을(를) 입력하여주십시오.");
            //        return;
            //    }
            //    else
            //    {
            //        sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
            //    }
            //}

            //sb.AppendLine($"{i_lblPlanDate.Text} : {i_dtpPlanStart.Value.ToString("yyyy-MM-dd HH:mm")} ~ " +
            //    $"{i_dtpPlanEnd.Value.ToString("yyyy-MM-dd HH:mm")}");
            //sb.AppendLine($"{i_lblRemark.Text} : {i_txtRemark.Text}");
            //sb.AppendLine("위의 정보로 작업지시를 수정하시겠습니까?");

            //DialogResult result = MessageBox.Show(sb.ToString(), "작업지시수정", MessageBoxButtons.YesNo);
            //if (result == DialogResult.Yes)
            //{ //Plan_Date, Plan_Qty_Box, Item_Code, Wc_Code, Process_Code,
            //  //Plan_StartTime, Plan_EndTime, Remark, Ins_Emp

            //    WOUpsertVO woUpdate = new WOUpsertVO
            //    {
            //        WorkOrderNo = i_txtOrNo.Text,
            //        Plan_Date = i_dtpPlanStart.Value.ToString("yyyy-MM-dd"),
            //        Plan_Qty_Box = Convert.ToInt32(i_txtPlanQty.Text),
            //        Item_Code = i_txtItemCode.Text,
            //        Wc_Code = i_txtWcCode.Text,
            //        Plan_StartTime = i_dtpPlanStart.Value,
            //        Plan_EndTime = i_dtpPlanEnd.Value,
            //        Remark = i_txtRemark.Text,
            //        Up_Emp = "홍길동업뎃수정"
            //    };

            //    bool inResult = woServ.WOUpdate(woUpdate);

            //    if (inResult)
            //    {
            //        MessageBox.Show("작업지시가 수정되었습니다.");
            //        LoadData(i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), "", "");
            //        s_dtpTo.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
            //        s_dtpFrom.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
            //    }
            //    else MessageBox.Show("작업지시 수정에 실패하였습니다.\n작업지시상태가 '생산대기'인 경우에만 수정할 수 있습니다.");

            //}
        }

        private void dgvWo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //ClearItems(grbOrder);
            if (dgvWo.Rows.Count < 1)
            {
                return;
            }
            status = dgvWo[0, e.RowIndex].Value.ToString();
            string woNo = dgvWo[1, e.RowIndex].Value.ToString();
            List<WOSelectVO> woInfo = (List<WOSelectVO>)dgvWo.DataSource;
            WOSelectVO wo = woInfo.Find((item) => item.WorkOrderNo == woNo);

            if (wo != null)
            {
                i_txtOrNo.Text = wo.WorkOrderNo;
                i_txtItemCode.Text = wo.Item_Code;
                i_txtItemName.Text = wo.Item_Name;
                i_txtPrCode.Text = wo.Process_Code;
                i_txtPrName.Text = wo.Process_Name;
                i_txtWcCode.Text = wo.Wc_Code;
                i_txtWcName.Text = wo.Wc_Name;
                i_dtpPlanStart.Text = wo.Plan_StartTime.ToString("yyyy-MM-dd HH:mm");
                i_dtpPlanEnd.Text = wo.Plan_EndTime.ToString("yyyy-MM-dd HH:mm");
                i_txtPlanQty.Text = wo.Plan_Qty_Box.ToString();
                i_txtRemark.Text = wo.Remark;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (status != "생산대기")
            {
                MessageBox.Show("작업지시상태가 '생산대기'인 경우에만 삭제할 수 있습니다.");
                return;
            }

            TextBox[] textboxes = { i_txtOrNo, i_txtItemName, i_txtPrName, i_txtWcName, i_txtPlanQty };
            Label[] labels = { i_lblOrNo,  i_lblItem, i_lblProcess, i_lblWc, i_lblPlanQty };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textboxes.Length; i++)
            {
                sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
            }

            sb.AppendLine($"{i_lblPlanDate.Text} : {i_dtpPlanStart.Value.ToString("yyyy-MM-dd HH:mm")} ~ " +
                $"{i_dtpPlanEnd.Value.ToString("yyyy-MM-dd HH:mm")}");
            sb.AppendLine($"{i_lblRemark.Text} : {i_txtRemark.Text}");
            sb.AppendLine("해당 작업지시를 삭제하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "작업지시삭제", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool dResult = woServ.WODelete(i_txtOrNo.Text);

                if (dResult)
                {
                    MessageBox.Show("작업지시가 삭제되었습니다.");
                    btnSelect.PerformClick();
                    //LoadData(i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), "", "");
                    //s_dtpTo.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                    //s_dtpFrom.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                }
                else MessageBox.Show("작업지시 삭제에 실패하였습니다.\n작업지시상태가 '생산대기'인 경우에만 삭제할 수 있습니다.");

            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (status != "현장마감")
            {
                MessageBox.Show("작업지시상태가 '현장마감'인 경우에만 작업지시를 마감할 수 있습니다.");
                return;
            }

            TextBox[] textboxes = { i_txtOrNo, i_txtItemName, i_txtPrName, i_txtWcName, i_txtPlanQty };
            Label[] labels = { i_lblOrNo, i_lblItem, i_lblProcess, i_lblWc, i_lblPlanQty };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textboxes.Length; i++)
            {
                sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
            }

            sb.AppendLine($"{i_lblPlanDate.Text} : {i_dtpPlanStart.Value.ToString("yyyy-MM-dd HH:mm")} ~ " +
                $"{i_dtpPlanEnd.Value.ToString("yyyy-MM-dd HH:mm")}");
            sb.AppendLine($"{i_lblRemark.Text} : {i_txtRemark.Text}");
            sb.AppendLine("해당 작업지시를 마감하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "작업지시마감", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool dResult = woServ.WOEnd(i_txtOrNo.Text);

                if (dResult)
                {
                    MessageBox.Show("작업지시가 마감되었습니다.");
                    btnSelect.PerformClick();
                    //LoadData(i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), "", "");
                    //s_dtpTo.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                    //s_dtpFrom.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                }
                else MessageBox.Show("작업지시 마감에 실패하였습니다.\n작업지시상태가 '현장마감'인 경우에만 마감할 수 있습니다.");

            }
        }

        private void btnEndCancle_Click(object sender, EventArgs e)
        {
            if (status != "작업지시마감")
            {
                MessageBox.Show("작업지시상태가 '작업지시마감'인 경우에만 작업마감을 취소할 수 있습니다.");
                return;
            }

            TextBox[] textboxes = { i_txtOrNo, i_txtItemName, i_txtPrName, i_txtWcName, i_txtPlanQty };
            Label[] labels = { i_lblOrNo, i_lblItem, i_lblProcess, i_lblWc, i_lblPlanQty };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < textboxes.Length; i++)
            {
                sb.AppendLine($"{labels[i].Text} : {textboxes[i].Text}");
            }

            sb.AppendLine($"{i_lblPlanDate.Text} : {i_dtpPlanStart.Value.ToString("yyyy-MM-dd HH:mm")} ~ " +
                $"{i_dtpPlanEnd.Value.ToString("yyyy-MM-dd HH:mm")}");
            sb.AppendLine($"{i_lblRemark.Text} : {i_txtRemark.Text}");
            sb.AppendLine("해당 작업지시를 마감 취소하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "작업지시마감취소", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool dResult = woServ.WOEndCancle(i_txtOrNo.Text);

                if (dResult)
                {
                    MessageBox.Show("작업지시가 마감 취소되었습니다.");
                    btnSelect.PerformClick();
                    //LoadData(i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), i_dtpPlanStart.Value.ToString("yyyy-MM-dd"), "", "");
                    //s_dtpTo.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                    //s_dtpFrom.Text = i_dtpPlanStart.Value.ToString("yyyy-MM-dd");
                }
                else MessageBox.Show("작업지시 마감 취소에 실패하였습니다.\n작업지시상태가 '작업지시마감'인 경우에만 마감할 수 있습니다.");

            }
        }
    }
}
