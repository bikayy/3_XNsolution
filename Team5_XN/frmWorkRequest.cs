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
        ReqSearchVO rs = null;

        Main main = null;

        /// <summary>
        /// 0:기본, 1:추가, 2:편집, 3:삭제
        /// </summary>
        int check = 0; //추가,편집 구분을 위한 숫자 -- 1:추가, 2:편집, 3:삭제, 

        public frmWorkRequest()
        {
            InitializeComponent();
        }

        private void frmWorkRequest_Load(object sender, EventArgs e)
        {
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

            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Delete += OnDelete;
            main.Cancle += OnCancle;
            main.Reset += OnReset;
            ChangeValue_Check(0);
            dtpFromDate.Value = DateTime.Now.AddDays(-3);
            dtpToDate.Value = DateTime.Now;
            dtpDeliDate.Value = DateTime.Now.AddDays(1);
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
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolUpdate.Enabled = main.toolDelete.Enabled = false;

                main.toolCreate.BackColor = Color.Yellow;

            }
            //편집
            else if (check == 2)
            {
                main.toolSelect.Enabled = main.toolUpdate.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolCreate.Enabled = main.toolDelete.Enabled = false;

                main.toolUpdate.BackColor = Color.Yellow;
            }

            //삭제
            //else if (check == 3)
            //{

            //}
        }

        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string reqNo = dgvRequest[0, e.RowIndex].Value.ToString();
            List<RequestVO> reqInfo = (List<RequestVO>)dgvRequest.DataSource;
            RequestVO order = reqInfo.Find((item) => item.Prd_Req_No == reqNo);

            if (order != null)
            {
                txtReqNo.Text = order.Prd_Req_No;
                r_txtItemCode.Text = order.Item_Code;
                r_txtItemName.Text = order.Item_Name;
                txtReqQty.Text = order.Req_Qty.ToString();
                txtCusName.Text = order.Customer_Name;
                txtProjName.Text = order.Project_Nm;
                dtpReqDate.Text = order.Req_Date;
                dtpDeliDate.Text = order.Delivery_Date;
                txtRemark.Text = order.Remark;
            }
        }

        private void OnReset(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            rs = new ReqSearchVO()
            {
                Tag = rdoReqDate.Tag.ToString(),
                FromDate = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"),
                ToDate = DateTime.Now.ToString("yyyy-MM-dd"),
                ItemCode = ""
            };
            LoadSearch(rs);
            dtpFromDate.Value = DateTime.Now.AddDays(-3);
            dtpToDate.Value = DateTime.Now;
            txtItemCode.Text = "";
            txtItemName.Text = "";
        }
              
        /// <summary>
        /// 검색조회
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (rdoReqDate.Checked)
            {
                rs = new ReqSearchVO()
                {
                    Tag = rdoReqDate.Tag.ToString(),
                    FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                    ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                    ItemCode = txtItemCode.Text
                };
                LoadSearch(rs);
            }
            else
            {
                rs = new ReqSearchVO()
                {
                    Tag = rdoDeliDate.Tag.ToString(),
                    FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                    ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                    ItemCode = txtItemCode.Text
                };
                LoadSearch(rs);
            }

            if (dgvRequest.Rows.Count > 0)
            {
                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(0, 0);
                dgvRequest_CellClick(this, args);
            }
         }

        /// <summary>
        /// 조회데이터
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="item"></param>
        private void LoadSearch(ReqSearchVO rs)
        {
            list = reqServ.GetRequestSearch(rs);
            dgvRequest.DataSource = list;
        }

        /// <summary>
        /// 생산요청 편집
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUpdate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (string.IsNullOrWhiteSpace(txtReqNo.Text))
            {
                MessageBox.Show("편집할 생산요청을 선택하여주십시오.");
                return;
            }

            ChangeValue_Check(2); //편집

            r_btnItemSearch.Enabled = true;
            r_btnItemSearch.BackColor = Color.Black;
            txtReqQty.ReadOnly = false;
            txtCusName.ReadOnly = false;
            txtProjName.ReadOnly = false;
            dtpReqDate.Enabled = true;
            dtpDeliDate.Enabled = true;
            txtRemark.ReadOnly = false;

            //if (dgvRequest.CurrentRow != null)
            //    dgvRequest_CellClick(dgvRequest, new DataGridViewCellEventArgs(0, dgvRequest.CurrentRow.Index));
        }

        /// <summary>
        /// 추가 및 편집 취소
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancle(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            dgvRequest.Enabled = true;

            r_btnItemSearch.Enabled = false;
            r_btnItemSearch.BackColor = Color.Gray;
            txtReqQty.ReadOnly = true;
            txtCusName.ReadOnly = true;
            txtProjName.ReadOnly = true;
            dtpReqDate.Enabled = false;
            dtpDeliDate.Enabled = false;
            txtRemark.ReadOnly = true;

            txtReqNo.Text = "";
            r_txtItemCode.Text = "";
            r_txtItemName.Text = "";
            txtReqQty.Text = "";
            txtCusName.Text = "";
            txtProjName.Text = "";
            dtpReqDate.Value = DateTime.Now;
            dtpDeliDate.Value = DateTime.Now.AddDays(1);
            txtRemark.Text = "";

            ChangeValue_Check(0);

            OnSelect(this, e);
        }

        /// <summary>
        /// 생산요청 생성
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(1); //추가
            //if (dgvRequest.CurrentRow != null)
            //    dgvRequest_CellClick(dgvRequest, new DataGridViewCellEventArgs(0, dgvRequest.CurrentRow.Index));

            dgvRequest.Enabled = false;

            txtReqNo.Text = "";
            r_txtItemCode.Text = "";
            r_txtItemName.Text = "";
            txtReqQty.Text = "";
            txtCusName.Text = "";
            txtProjName.Text = "";
            dtpReqDate.Value = DateTime.Now;
            dtpDeliDate.Value = DateTime.Now.AddDays(1);
            txtRemark.Text = "";

            r_btnItemSearch.Enabled = true;
            r_btnItemSearch.BackColor = Color.Black;
            txtReqQty.ReadOnly = false;
            txtCusName.ReadOnly = false;
            txtProjName.ReadOnly = false;
            dtpReqDate.Enabled = true;
            dtpDeliDate.Enabled = true;
            txtRemark.ReadOnly = false;
        }



        /// <summary>
        /// 생산요청 저장(생성, 수정)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSave(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (check == 1)
            {
                TextBox[] textboxes = { r_txtItemName, txtReqQty, txtCusName, txtProjName };
                Label[] labels = { lblItem, lblReqQty, lblCusName, lblProjName };
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

                sb.AppendLine($"{lblReqDate.Text} : {dtpReqDate.Value.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"{lblDeliDate.Text} : {dtpDeliDate.Value.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"{lblRemark.Text} : {txtRemark.Text}");
                sb.AppendLine("위의 정보로 생산요청을 등록하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "생산요청생성", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RequestService reqServ = new RequestService();

                    RequestVO cr = new RequestVO();
                    cr.Item_Code = r_txtItemCode.Text;
                    cr.Req_Qty = Convert.ToInt32(txtReqQty.Text);
                    cr.Customer_Name = txtCusName.Text;
                    cr.Project_Nm = txtProjName.Text;
                    cr.Sale_Prsn_Nm = "테스트홍길동";
                    cr.Delivery_Date = dtpDeliDate.Value.ToString("yyyy-MM-dd");
                    cr.Req_Date = dtpReqDate.Value.ToString("yyyy-MM-dd");
                    cr.Remark = txtRemark.Text;

                    bool reqResult = reqServ.ProductionRequest(cr);
                    if (reqResult) MessageBox.Show("생산요청이 등록되었습니다.");
                    else MessageBox.Show("생산요청에 실패하였습니다.\n다시 확인하여주십시오.");

                    for (int i = 0; i < textboxes.Length; i++)
                    {
                        textboxes[i].Text = "";
                    }
                    dtpReqDate.Text = dtpReqDate.Value.ToString("yyyy-MM-dd");
                    dtpDeliDate.Text = dtpDeliDate.Value.ToString("yyyy-MM-dd");
                    r_txtItemCode.Text = "";
                    txtRemark.Text = "";

                    if (rdoReqDate.Checked)
                    {
                        rs = new ReqSearchVO()
                        {
                            Tag = rdoReqDate.Tag.ToString(),
                            FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                            ItemCode = txtItemCode.Text
                        };
                        LoadSearch(rs);
                    }
                    else
                    {
                        rs = new ReqSearchVO()
                        {
                            Tag = rdoDeliDate.Tag.ToString(),
                            FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                            ItemCode = txtItemCode.Text
                        };
                        LoadSearch(rs);
                    }
                }
                txtReqNo.Text = "";
                r_txtItemCode.Text = "";
                r_txtItemName.Text = "";
                txtReqQty.Text = "";
                txtCusName.Text = "";
                txtProjName.Text = "";
                dtpReqDate.Value = DateTime.Now;
                dtpDeliDate.Value = DateTime.Now.AddDays(1);
                txtRemark.Text = "";
                r_txtItemCode.Focus();
            }
            else if (check == 2)
            {
                if (string.IsNullOrWhiteSpace(txtReqNo.Text))
                {
                    MessageBox.Show("수정할 생산요청을 선택하여주십시오.");
                    return;
                }


                TextBox[] textboxes = { txtReqNo, r_txtItemName, txtReqQty, txtCusName, txtProjName };
                Label[] labels = { lblReqNo, lblItem, lblReqQty, lblCusName, lblProjName };
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

                sb.AppendLine($"{lblReqDate.Text} : {dtpReqDate.Value.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"{lblDeliDate.Text} : {dtpDeliDate.Value.ToString("yyyy-MM-dd")}");
                sb.AppendLine($"{lblRemark.Text} : {txtRemark.Text}");
                sb.AppendLine("위의 정보로 생산요청을 수정하시겠습니까?");

                DialogResult result = MessageBox.Show(sb.ToString(), "생산요청수정", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    RequestService reqServ = new RequestService();

                    RequestVO ur = new RequestVO
                    {
                        Item_Code = r_txtItemCode.Text,
                        Req_Qty = Convert.ToInt32(txtReqQty.Text),
                        Customer_Name = txtCusName.Text,
                        Project_Nm = txtProjName.Text,
                        Req_Date = dtpReqDate.Value.ToString("yyyy-MM-dd"),
                        Delivery_Date = dtpDeliDate.Value.ToString("yyyy-MM-dd"),
                        Sale_Prsn_Nm = "수정수정",
                        Prd_Req_No = txtReqNo.Text,
                        Remark = txtRemark.Text
                    };

                    bool reqResult = reqServ.UpdateRequest(ur); ;
                    if (reqResult) MessageBox.Show("생산요청이 수정되었습니다.");
                    else MessageBox.Show("생산요청 수정에 실패하였습니다.\n생산 요청 상태를 확인하여주십시오.");

                    for (int i = 0; i < textboxes.Length; i++)
                    {
                        textboxes[i].Text = "";
                    }
                    dtpReqDate.Value = DateTime.Now;
                    dtpDeliDate.Value = DateTime.Now.AddDays(1);
                    r_txtItemCode.Text = "";
                    txtRemark.Text = "";

                    if (rdoReqDate.Checked)
                    {
                        rs = new ReqSearchVO()
                        {
                            Tag = rdoReqDate.Tag.ToString(),
                            FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                            ItemCode = txtItemCode.Text
                        };
                        LoadSearch(rs);
                    }
                    else
                    {
                        rs = new ReqSearchVO()
                        {
                            Tag = rdoDeliDate.Tag.ToString(),
                            FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                            ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                            ItemCode = txtItemCode.Text
                        };
                        LoadSearch(rs);
                    }
                }

            }
        }

        /// <summary>
        /// 생산요청 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDelete(object sender, EventArgs e)
        {
            //dgvRequest.EndEdit();

            //MessageBox.Show();
            TextBox[] textboxes = { txtReqNo, r_txtItemName, txtReqQty, txtCusName, txtProjName, r_txtItemCode, txtRemark };

            if (string.IsNullOrWhiteSpace(txtReqNo.Text))
            {
                MessageBox.Show("삭제할 생산요청을 선택하여주십시오.");
                return;
            }

            DialogResult result = MessageBox.Show($"{txtReqNo.Text}의 생산요청을 삭제하시겠습니까?", "생산요청삭제", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool dResult = reqServ.DeleteRequest(txtReqNo.Text);
                if (dResult) MessageBox.Show("생산요청이 삭제되었습니다.");
                else MessageBox.Show("생산요청 삭제에 실패하였습니다.\n생산 진행 상태를 확인하여주십시오.");

                for (int i = 0; i < textboxes.Length; i++)
                {
                    textboxes[i].Text = "";
                }
                dtpReqDate.Value = DateTime.Now;
                dtpDeliDate.Value = DateTime.Now.AddDays(1);
            }

            if (rdoReqDate.Checked)
            {
                rs = new ReqSearchVO()
                {
                    Tag = rdoReqDate.Tag.ToString(),
                    FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                    ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                    ItemCode = txtItemCode.Text
                };
                LoadSearch(rs);
            }
            else
            {
                rs = new ReqSearchVO()
                {
                    Tag = rdoDeliDate.Tag.ToString(),
                    FromDate = dtpFromDate.Value.ToString("yyyy-MM-dd"),
                    ToDate = dtpToDate.Value.ToString("yyyy-MM-dd"),
                    ItemCode = txtItemCode.Text
                };
                LoadSearch(rs);
            }
          
        }

        /// <summary>
        /// 품목검색창
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopupSearch frm = new PopupSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtItemCode.Text = frm.Send.Item_Code;
                txtItemName.Text = frm.Send.Item_Name;
            }
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

        private void txtReqQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
                MessageBox.Show("수량은 숫자로 입력하여주십시오.");
                txtReqQty.Text = "";
            }

            if (e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtReqQty_Leave(object sender, EventArgs e)
        {
            if (txtReqQty.Text.Equals("0"))
            {
                MessageBox.Show("요청수량은 0일 수 없습니다.");
                txtReqQty.Text = "";
                txtReqQty.Focus();
                return;
            }
        }

        private void dtpDeliDate_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvRequest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgvRequest_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dtpReqDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpReqDate.Value > DateTime.Now)
            {
                MessageBox.Show("요청일은 현재일 이후일 수 없습니다.");
                dtpReqDate.Value = DateTime.Now;
                dtpReqDate.Focus();
                return;
            }
        }

        private void dtpDeliDate_Leave(object sender, EventArgs e)
        {
            if (dtpDeliDate.Value <= DateTime.Now)
            {
                MessageBox.Show("납기일은 현재일 이전일 수 없습니다.");
                dtpDeliDate.Value = DateTime.Now.AddDays(1);
                dtpDeliDate.Focus();
                return;
            }
            
        }
    }
}
