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

            if (frm.DialogResult == DialogResult.OK)
            {
                txtItemCode.Text = frm.Send.Item_Code;
                txtItemName.Text = frm.Send.Item_Name;
            }
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

            
            //dgvRequest.Columns["check"].DisplayIndex = 0;
            
            dgvRequest.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            list = reqServ.GetRequestList();
            //dgvRequest.DataSource = new AdvancedList<RequestVO>(list);
            dgvRequest.Columns["Req_Qty"].ReadOnly = false;
            dgvRequest.Columns["Customer_Name"].ReadOnly = false;
            dgvRequest.Columns["Project_Nm"].ReadOnly = false;
            dgvRequest.Columns["Delivery_Date"].ReadOnly = false;
            dgvRequest.DataSource = list;

        }

        //~값은 변경할 수 없습니다. 추가할 것
        /// <summary>
        /// 수정 시 품목컬럼 클릭 -> 품목검생창 열림
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                PopupSearch frm = new PopupSearch();
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    dgvRequest[4, e.RowIndex].Value = frm.Send.Item_Code;
                    dgvRequest[5, e.RowIndex].Value = frm.Send.Item_Name;
                }
            }

        }

        /// <summary>
        /// 수정 시 데이터 변경 값 유효성 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            #region 납기일 유효성 체크
            DateTime ch;
            if (e.ColumnIndex == 10 &&
                DateTime.TryParse(e.FormattedValue.ToString(), out ch) == false)
            {
                MessageBox.Show("납기일은 yyyy-MM-dd 형태로 입력해주십시오.");
                e.Cancel = true;
            }
            else
            {
                if (e.ColumnIndex == 10 && Convert.ToDateTime(e.FormattedValue.ToString()) < DateTime.Now)
                {
                    MessageBox.Show("납기일은 현재일보다 과거일 수 없습니다.");
                    e.Cancel = true;
                }
            }
            #endregion

            #region 요청수량 유효성 체크
            if (e.ColumnIndex == 6 && string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                MessageBox.Show("요청수량 항목은 공란일 수 없습니다.");
                e.Cancel = true;
            }
            else
            {
                int reqNum;
                if (e.ColumnIndex == 6
                    && Int32.TryParse(e.FormattedValue.ToString(), out reqNum)
                    && reqNum < 1)
                {
                    MessageBox.Show("요청수량을 다시 설정하여주십시오.");
                    e.Cancel = true;
                }
            }
            #endregion

            #region 거래처 유효성 체크
            if (e.ColumnIndex == 7 && string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
            {
                MessageBox.Show("거래처 항목은 공란일 수 없습니다.");
                e.Cancel = true;
            }
            #endregion

            #region 프로젝트명 유효성 체크
            if (e.ColumnIndex == 8 && string.IsNullOrEmpty(e.FormattedValue.ToString().Trim()))
            {
                MessageBox.Show("프로젝트명 항목은 공란일 수 없습니다.");
                e.Cancel = true;
            }
            #endregion

        }

        /// <summary>
        /// 수정 시 요청수량 유효성 체크(숫자 여부)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequest_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                MessageBox.Show("요청수량은 숫자로 입력해주십시오.");
            }
        }

        /// <summary>
        /// 데이터 변경 시 행 색깔 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRequest_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dgvRequest.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aquamarine;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvRequest.EndEdit();

            List<string> reqNoList = new List<string>();

            foreach (DataGridViewRow row in dgvRequest.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(chk.Value))
                {
                    reqNoList.Add(row.Cells["Prd_Req_No"].Value.ToString());
                }
            }

            if (reqNoList.Count < 1)
            {
                MessageBox.Show("선택된 생산요청이 없습니다.");
                return;
            }

            DialogResult reqResult = MessageBox.Show("선택된 생산요청을 수정하시겠습니까?", "생산요청 수정", MessageBoxButtons.YesNo);

            if (reqResult == DialogResult.Yes)
            {
                List<RequestVO> reqList = (List<RequestVO>)dgvRequest.DataSource;
                RequestVO sendUr = null;
                bool result = false;

                for (int i = 0; i < reqNoList.Count; i++)
                {
                    string prdID = reqNoList[i];
                    sendUr = reqList.Find((item) => item.Prd_Req_No == prdID);
                    
                    RequestVO ur = new RequestVO
                    {
                        Item_Code = sendUr.Item_Code,
                        Req_Qty = sendUr.Req_Qty,
                        Customer_Name = sendUr.Customer_Name,
                        Project_Nm = sendUr.Project_Nm,
                        Delivery_Date = sendUr.Delivery_Date,
                        Sale_Prsn_Nm = "둘리",  //수정해야함!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        Prd_Req_No = sendUr.Prd_Req_No
                    };

                    result = reqServ.UpdateRequest(ur);
                }

                if (result)
                {
                    MessageBox.Show("수정이 완료되었습니다.");
                    LoadData();
                }
                else MessageBox.Show("수정에 실패하였습니다.\n다시 시도하여주십시오.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvRequest.EndEdit();

            List<string> reqNoList = new List<string>();

            foreach (DataGridViewRow row in dgvRequest.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                if (Convert.ToBoolean(chk.Value))
                {
                    reqNoList.Add(row.Cells["Prd_Req_No"].Value.ToString());
                }
            }

            if (reqNoList.Count < 1)
            {
                MessageBox.Show("선택된 생산요청이 없습니다.");
                return;
            }

            DialogResult reqResult = MessageBox.Show("선택된 생산요청을 삭제하시겠습니까?", "생산요청 삭제", MessageBoxButtons.YesNo);

            if (reqResult == DialogResult.Yes)
            {                
                bool result = false;

                for (int i = 0; i < reqNoList.Count; i++)
                {
                    string id = reqNoList[i];
                    result = reqServ.DeleteRequest(id);
                }

                if (result)
                {
                    MessageBox.Show("삭제가 완료되었습니다.");
                    LoadData();
                }
                else MessageBox.Show("삭제에 실패하였습니다.\n다시 시도하여주십시오.");
            }
        }
    }
}
