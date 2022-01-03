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
    public partial class PopupRequest : Form
    {
        public PopupRequest()
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

            //grbItemSearch.Visible = true;
            //grbItemSearch.Location = new Point(12, 5);
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            txtItemCode.Text = "";
            txtItemName.Text = "";
            txtReqQty.Text = "";
            txtCusName.Text = "";
            txtProjName.Text = "";
            dtpDeliDate.Value = DateTime.Now;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TextBox[] textboxes = {txtItemCode, txtItemName, txtReqQty,
            txtCusName, txtProjName};
            Label[] labels = { lblItem, lblReqQty, lblCusName, lblProjName };
            StringBuilder sb = new StringBuilder();
            int j = 0;

            for (int i = 0; i < textboxes.Length; i++)
            {
                bool isChecked = string.IsNullOrWhiteSpace(textboxes[i].Text.Trim());
                if (isChecked)
                {
                    MessageBox.Show("모든 항목을 입력해주세요.");
                    return;
                }
                else
                {
                    if (i == 1) continue;
                    
                    sb.AppendLine($"{labels[j].Text} : {textboxes[i].Text}");
                    j++;
                }
            }

            if (dtpDeliDate.Value < DateTime.Now)
            {
                MessageBox.Show("납기일을 확인해주세요.");
                return;
            }

            sb.AppendLine($"{lblDeliDate.Text} : {dtpDeliDate.Value.ToString("yyyy-MM-dd")}");
            sb.AppendLine("위의 정보로 생산요청하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "생산요청", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {  //Item_Code / Req_Qty / Customer_Name / Project_Nm / Sale_Prsn_Nm / Delivery_Date
                RequestService reqServ = new RequestService();

                RequestVO cr = new RequestVO();
                cr.Item_Code = txtItemCode.Text;
                cr.Req_Qty = Convert.ToInt32(txtReqQty.Text);
                cr.Customer_Name = txtCusName.Text;
                cr.Project_Nm = txtProjName.Text;
                cr.Sale_Prsn_Nm = "테스트홍길동";
                cr.Delivery_Date = dtpDeliDate.Value.ToString("yyyy-MM-dd");

                bool reqResult = reqServ.ProductionRequest(cr);
                if (reqResult) MessageBox.Show("생산요청이 등록되었습니다.");
                else MessageBox.Show("생산요청에 실패하였습니다.\n다시 확인하여주십시오.");

                for (int i = 0; i < textboxes.Length; i++)
                {
                    textboxes[i].Text = "";
                }
                dtpDeliDate.Value = DateTime.Now;
            }



        }

        private void PopupRequest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void txtReqQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("수량은 숫자로 입력해주세요.");
            }
        }

    }
}
