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
        private string wcStatus = string.Empty;
        private string wcGroup = string.Empty;

        bool backCheck = false;

        public POPWorkCenter()
        {
            InitializeComponent();
        }

        private void POPWorkCenter_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = new DataTable();
            dt = wcServ.SelectWc();
            int idx = 0;

            //작업장 리스트 동적 생성
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
                ctrlWcList.TabIndex = idx;
                ctrlWcList.eventWcList += OnCtrlClick;
                pnlWcList.Controls.Add(ctrlWcList);

                idx++;
            }
        }


        /// <summary>
        /// 작업장 이동
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            pop.WcStatus = wcStatus;
            pop.WcGroup = wcGroup;
            pop.ShowDialog();
            //this.Hide();
        }


        /// <summary>
        /// 작업장 리스트 클릭 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCtrlClick(object sender, EventArgs e)
        {
            ucWorkCenterList ctrl = (ucWorkCenterList)sender;

            txtWCName.Text = ctrl.SendWcList.Wc_Name;
            wcCode = ctrl.SendWcList.Wc_Code;
            wcName = ctrl.SendWcList.Wc_Name;
            wcStatus = ctrl.SendWcList.Wo_Status;
            wcGroup = ctrl.SendWcList.Wc_Group;

            ctrl.BackColor = Color.Red;
            CtrlSelection(pnlWcList, ctrl.TabIndex);
        }


        /// <summary>
        /// 선택된 목록 외 배경색 리셋
        /// </summary>
        /// <param name="pnl"></param>
        /// <param name="tabIdx"></param>
        private void CtrlSelection(Panel pnl, int tabIdx)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl.TabIndex.Equals(tabIdx)) continue;
                if (ctrl is UserControl)
                {
                    ctrl.BackColor = Color.White;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
