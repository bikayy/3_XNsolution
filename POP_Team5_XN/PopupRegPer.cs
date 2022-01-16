using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN;
using Team5_XN_VO;

namespace POP_Team5_XN
{
    public partial class PopupRegPer : Form
    {
        WcService wcServ = new WcService();
        RegSiyuVO regPerSiyu = new RegSiyuVO();

        ucRegPerList ctrlRegPer = null;

        private WoInfoVO woInfo = new WoInfoVO();
        public WoInfoVO GetWoInfo { get { return woInfo; } set { woInfo = value; } }


        public PopupRegPer()
        {
            InitializeComponent();
        }

        private void PopupRegPer_Load(object sender, EventArgs e)
        {
            lblWoNo.Text = woInfo.WorkOrderNo;
            lblItemName.Text = woInfo.Item_Name;
            lblWcName.Text = woInfo.Wc_Name;
            lblPlanDate.Text = woInfo.Plan_Date;
            lblPlanQty.Text = woInfo.Plan_Qty_Box.ToString();
            SiyuPerList();
        }

        private void SiyuPerList()
        {
            pnlList.Controls.Clear();

            DataTable dt = new DataTable();
            dt = wcServ.SelectPerSiyu(lblWoNo.Text, woInfo.Wc_Code);
            int idx = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idx > dt.Rows.Count) break;
                ctrlRegPer = new ucRegPerList();
                ctrlRegPer.Location = new Point(0, i * 60);
                ctrlRegPer.Size = new Size(1044, 60);
                ctrlRegPer.SendPerSiyu = new SelectPerSiyuVO
                {
                    Reg_Datetime = (DateTime)dt.Rows[idx]["Reg_Datetime"],
                    Prd_Qty = Convert.ToInt32(dt.Rows[idx]["Prd_Qty"])
                };
                ctrlRegPer.eventDelete += OnDeleteClick;
                lblPrdQty.Text = dt.Rows[idx]["Prd_Qty_Sum"].ToString();
                ctrlRegPer.Tag = idx;
                pnlList.Controls.Add(ctrlRegPer);
                idx++;
            }
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {  //WorkOrderNo, Prd_Qty, Reg_DateTime, Del_Emp
            ucRegPerList ctrl = (ucRegPerList)sender;

            Label[] labels = { lblWoNo, lblItemName };
            Label[] labelsTitle = { lblTWoNo, lblTItemName};
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                sb.AppendLine($"{labelsTitle[i].Text} : {labels[i].Text}");
            }

            sb.AppendLine($"실적수량 : {ctrl.SendPerSiyu.Prd_Qty}");
            sb.AppendLine("해당 실적정보를 삭제하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "실적정보삭제", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                DeletePerSiyuVO deletePerSiyu = new DeletePerSiyuVO
                {
                    WorkOrderNo = lblWoNo.Text,
                    Prd_Qty = ctrl.SendPerSiyu.Prd_Qty,
                    Reg_DateTime = ctrl.SendPerSiyu.Reg_Datetime,
                    Del_Emp = "홍길동"
                };

                bool deResult = wcServ.DeletePerSiyu(deletePerSiyu);

                if (deResult)
                {
                    MessageBox.Show("실적정보가 삭제되었습니다.");
                    SiyuPerList();
                }
                else MessageBox.Show("실적정보 삭제에 실패하였습니다.\n다시 확인하여주십시오.");
            }

        }

        private void btnKeyBoard_Click(object sender, EventArgs e)
        {
            PopupKeyboard frm = new PopupKeyboard();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtPrdQty.Text = frm.SendQty.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrdQty.Text))
            {
                MessageBox.Show("실적수량을 입력하여주십시오.");
                return;
            }

            Label[] labels = { lblWoNo, lblItemName, lblWcName, lblPlanDate };
            Label[] labelsTitles = { lblTWoNo, lblTItemName, lblTWcName, lblTPlanDate };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                sb.AppendLine($"{labelsTitles[i].Text} : {labels[i].Text}");
            }

            sb.AppendLine($"생산일자 : {DateTime.Now.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"{lblIPrdQty.Text} : {txtPrdQty.Text}");
            sb.AppendLine("위의 정보로 실적을 등록하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "실적등록", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                regPerSiyu = new RegSiyuVO
                {
                    WorkOrderNo = lblWoNo.Text,
                    Start_Hour = Convert.ToInt32(DateTime.Now.ToString("HH")),
                    Prd_Qty = Convert.ToInt32(txtPrdQty.Text),
                    Unit = "PCS",
                    Ins_Emp = "홍길동",
                    Wc_Code = woInfo.Wc_Code
                };

                bool crResult = wcServ.RegPerSiyu(regPerSiyu);

                if (crResult)
                {
                    MessageBox.Show("실적이 등록되었습니다.");
                    SiyuPerList();
                }
                else MessageBox.Show("실적 등록에 실패하였습니다.\n다시 확인하여주십시오.");
            }
        }
    }
}
