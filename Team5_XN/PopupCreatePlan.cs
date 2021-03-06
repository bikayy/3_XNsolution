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
    public partial class PopupCreatePlan : Form
    {
        private RequestVO getInfo = new RequestVO();
        public RequestVO Get { get { return getInfo; } set { getInfo = value; } }

        public PopupCreatePlan()
        {
            InitializeComponent();
        }

        private void PopupCreatePlan_Load(object sender, EventArgs e)
        {
            txtReqNo.Text = getInfo.Prd_Req_No;
            txtReqDate.Text = getInfo.Req_Date;
            txtReqSeq.Text = getInfo.Req_Seq;
            txtItemCode.Text = getInfo.Item_Code;
            txtItemName.Text = getInfo.Item_Name;
            txtReqQty.Text = getInfo.Req_Qty.ToString();
            txtCustomerName.Text = getInfo.Customer_Name;
            txtDeliDate.Text = getInfo.Delivery_Date;
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

        private void btnOK_Click(object sender, EventArgs e)
        {  //Prd_Req_No, Plan_Month, Item_Code, Plan_Qty, Wc_Code, Remark, Ins_Emp
            PlanService planServ = new PlanService();
            //MessageBox.Show(dtpPlanMonth.Value.ToString("yyyy-MM"));
            PlanVO pr = new PlanVO()
            {
                Prd_Req_No = txtReqNo.Text,
                Plan_Month = dtpPlanMonth.Value.ToString(),
                Item_Code = txtItemCode.Text,
                Plan_Qty = Convert.ToInt32(txtPlanQty.Text),
                Wc_Code = txtWCCode.Text,
                Remark = txtRemark.Text,
                Ins_Emp = "스벅"
            };

            bool result = planServ.CreatePlan(pr);
            if (result) MessageBox.Show("성공");
            else MessageBox.Show("실패");
        }
    }
}
