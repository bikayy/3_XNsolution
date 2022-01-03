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
    public partial class PopupIndPlan : Form
    {
        public PopupIndPlan()
        {
            InitializeComponent();
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

        private void btnOK_Click(object sender, EventArgs e)
        {  ////Plan_Month, Item_Code, Plan_Qty, Wc_Code, Remark, Ins_Emp
            PlanService planServ = new PlanService();
            PlanVO ap = new PlanVO()
            {
                Plan_Month = dtpPlanMonth.Value.ToString("yyyy-MM"),
                Item_Code = txtItemCode.Text,
                Plan_Qty = Convert.ToInt32(txtPlanQty.Text),
                Wc_Code = txtWCCode.Text,
                Remark = txtRemark.Text,
                Ins_Emp = "추가테"
            };

            bool result = planServ.AddPlan(ap);
            if (result) MessageBox.Show("성공");
            else MessageBox.Show("실패");
        }
    }
}
