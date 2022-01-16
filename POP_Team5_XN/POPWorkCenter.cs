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
using Team5_XN;

namespace POP_Team5_XN
{
    public partial class POPWorkCenter : Form
    {
        WcService wcServ = new WcService();
        ucWorkCenterList ctrlWcList = null;

        private string wcCode;
        private string wcName;

        public POPWorkCenter()
        {
            InitializeComponent();
        }

        private void POPWorkCenter_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = wcServ.SelectWc();
            int idx = 0;


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idx > dt.Rows.Count) break;

                ctrlWcList = new ucWorkCenterList();
                ctrlWcList.Location = new Point(1, 80 + (i * 85));
                ctrlWcList.Size = new Size(882, 86);
                ctrlWcList.SendWcList = new SelectWcVO
                { //Wc_Name, Wc_Group, Wo_Status
                    Wc_Name = dt.Rows[idx]["Wc_Name"].ToString(),
                    Wc_Group = dt.Rows[idx]["Wc_Group"].ToString(),
                    Wo_Status = dt.Rows[idx]["Wo_Status"].ToString(),
                    Wc_Code = dt.Rows[idx]["Wc_Code"].ToString()
                };
                ctrlWcList.eventWcList += OnCtrlClick;
                pnlWcList.Controls.Add(ctrlWcList);

                //MessageBox.Show(ctrlWcList.SendWcList.Wc_Code);
                idx++;
            }
        }


        private void btnMove_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWCName.Text))
            {
                MessageBox.Show("이동할 작업장을 먼저 선택하여주십시오.");
                return;
            }

            POPWorkOrderStatus pop = new POPWorkOrderStatus();
            //pop.WcCode = wcCode;
            pop.WoInfo.Wc_Code = wcCode;
            pop.WoInfo.Wc_Name = wcName;
            pop.ShowDialog();
            //this.Hide();
        }

        private void OnCtrlClick(object sender, EventArgs e)
        {
            ucWorkCenterList ctrl = (ucWorkCenterList)sender;

            //if (ctrl.SendWcList.Wo_Status.Equals("비가동"))
            //{
            //    MessageBox.Show("비가동 중인 작업장은 선택할 수 없습니다.");
            //    txtWCName.Text = "";
            //    return;
            //}

            txtWCName.Text = ctrl.SendWcList.Wc_Name;
            wcCode = ctrl.SendWcList.Wc_Code;
            wcName = ctrl.SendWcList.Wc_Name;
            ctrl.BackColor = Color.Red;
            //MessageBox.Show(wcCode);
        }

    }
}
