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
    public partial class POPWorkOrderStatus : Form
    {
        ucWorkOrderStatusList ctrlOrList = null;

        WcService wcServ = new WcService();

        private WoInfoVO woInfo = new WoInfoVO();
        public WoInfoVO WoInfo { get { return woInfo; } set { woInfo = value; } }

        private string wcStatus = string.Empty;
        public string WcStatus { get { return wcStatus; } set { wcStatus = value; } }

        string woNo = string.Empty;

        int ctrlIdx = 0;

        string[] remarks = new string[100];

        public POPWorkOrderStatus()
        {
            InitializeComponent();
        }

        private void POPWorkOrderStatus_Load(object sender, EventArgs e)
        {
            if (wcStatus.Equals("비가동"))
            {
                btnStart.Enabled = btnEnd.Enabled = btnPalette.Enabled = btnClosing.Enabled = btnPfm.Enabled = false;
                btnStart.BackColor = btnEnd.BackColor = btnPalette.BackColor = btnClosing.BackColor = btnPfm.BackColor = Color.Gray;
            }

            lblTitle.Text = woInfo.Wc_Name;
            LoadData();
        }

        private void LoadData()
        {
            pnlOrList.Controls.Clear();

            DataTable dt = new DataTable();
            dt = wcServ.SelectOr(woInfo.Wc_Code);
            int idx = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idx > dt.Rows.Count) break;

                ctrlOrList = new ucWorkOrderStatusList();
                ctrlOrList.Location = new Point(0, 0 + (i * 99));
                ctrlOrList.Size = new Size(1081, 99);
                ctrlOrList.SendOrderList = new SelectOrderVO
                { //Wo_Status, Plan_Date, Prd_Date, WorkOrderNo, Project_Nm, Item_Name, Item_Name_Eng,
                  //Plan_Qty_Box, Prd_Qty, Prd_StartTime, Prd_EndTime, w.Remark
                    Wo_Status = dt.Rows[idx]["Wo_Status"].ToString(),
                    Plan_Date = dt.Rows[idx]["Plan_Date"].ToString(),
                    Prd_Date = dt.Rows[idx]["Prd_Date"].ToString(),
                    WorkOrderNo = dt.Rows[idx]["WorkOrderNo"].ToString(),
                    Project_Nm = dt.Rows[idx]["Project_Nm"].ToString(),
                    Item_Name = dt.Rows[idx]["Item_Name"].ToString(),
                    Item_Name_Eng = dt.Rows[idx]["Item_Name_Eng"].ToString(),
                    Plan_Qty_Box = Convert.ToInt32(dt.Rows[idx]["Plan_Qty_Box"]),
                    Prd_Qty = Convert.ToInt32(dt.Rows[idx]["Prd_Qty"]),
                    Prd_StartTime = dt.Rows[idx]["Prd_StartTime"].ToString(),
                    Prd_EndTime = dt.Rows[idx]["Prd_EndTime"].ToString(),
                    Remark_YN = dt.Rows[idx]["Remark_YN"].ToString()
                };
                remarks[i] = dt.Rows[idx]["Remark"].ToString();
                ctrlOrList.TabIndex = idx;
                ctrlOrList.eventRemark += OnRemark;
                ctrlOrList.eventBtnCheck += OnBtn;
                ctrlOrList.eventOrderList += OnClick;
                
                pnlOrList.Controls.Add(ctrlOrList);
                //MessageBox.Show(remarks[i]);
                idx++;
            }
        }


        /// <summary>
        /// 버튼 활성화 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtn(object sender, EventArgs e)
        {
            ucWorkOrderStatusList ctrl = (ucWorkOrderStatusList)sender;
            //MessageBox.Show(ctrl.SendOrderList.Wo_Status);

            if (ctrl.SendOrderList.Wo_Status.Equals("생산중"))
            {
                btnStart.Enabled = false;
                btnStart.BackColor = Color.Gray;
                btnEnd.Enabled = true;

                btnStart.Enabled = false;
                btnEnd.Enabled = true;
                btnEnd.BackColor = Color.FromArgb(241, 248, 255);

                btnPfm.Enabled = true;
                btnPfm.BackColor = Color.FromArgb(241, 248, 255);
            }
            else
            {
                if (ctrl.SendOrderList.Wo_Status.Equals("생산대기"))
                {
                    btnPfm.Enabled = false;
                    btnPfm.BackColor = Color.Gray;
                }

                btnStart.Enabled = true;
                btnStart.BackColor = Color.FromArgb(241, 248, 255);
                btnEnd.Enabled = false;

                btnStart.Enabled = true;
                btnEnd.Enabled = false;
                btnEnd.BackColor = Color.Gray;
            }

            //btnCheck = ctrl.Check;
            //btnEnableTF(btnCheck);
        }


        /// <summary>
        /// 작업지시목록 클릭 시 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClick(object sender, EventArgs e)
        {
            ucWorkOrderStatusList ctrl = (ucWorkOrderStatusList)sender;
            woNo = ctrl.SendOrderList.WorkOrderNo;
            ctrlIdx = ctrl.TabIndex;
            ctrl.BackColor = Color.Blue;
            CtrlSelection(pnlOrList, ctrl.TabIndex);
            
            woInfo = new WoInfoVO
            {  //Item_Name, Plan_Date, Prd_Qty, WorkOrderNo, Wc_Name
                WorkOrderNo = ctrl.SendOrderList.WorkOrderNo,
                Item_Name = ctrl.SendOrderList.Item_Name,
                Plan_Date = ctrl.SendOrderList.Plan_Date,
                Plan_Qty_Box = ctrl.SendOrderList.Plan_Qty_Box,
                Prd_Qty = ctrl.SendOrderList.Prd_Qty,
                Wc_Name = woInfo.Wc_Name,
                Wc_Code = woInfo.Wc_Code
            };
        }

        private void OnRemark(object sender, EventArgs e)
        {
            ucWorkOrderStatusList ctrl = (ucWorkOrderStatusList)sender;
    
            PopupRemark frm = new PopupRemark();
            frm.GetMsg = remarks[ctrl.TabIndex];
            frm.ShowDialog();
            //MessageBox.Show(remarks[ctrl.TabIndex]);
        }


        /// <summary>
        /// 선택된 목록 외 배경색 리셋
        /// </summary>
        /// <param name="pnl"></param>
        /// <param name="tabIdx"></param>
        private void CtrlSelection(Panel pnl, int tabIdx)
        {
            foreach(Control ctrl in pnl.Controls)
            {
                if (ctrl.TabIndex.Equals(tabIdx)) continue;
                if (ctrl is UserControl)
                {
                    ctrl.BackColor = Color.White;
                }
            }
        }


        private void CtrlRemove(Panel pnl, int tabIdx)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is UserControl && ctrl.TabIndex.Equals(tabIdx))
                {
                    pnl.Controls.Remove(ctrl);
                }
            }
        }


        //팔레트 생성 버튼
        private void btnPalette_Click(object sender, EventArgs e)
        {  //Item_Name, Plan_Date, Prd_Qty, WorkOrderNo, Wc_Name
            POPPalette pop = new POPPalette();
            pop.WoInfo_p.WorkOrderNo = woInfo.WorkOrderNo;
            pop.WoInfo_p.Item_Name = woInfo.Item_Name;
            pop.WoInfo_p.Plan_Date = woInfo.Plan_Date;
            pop.WoInfo_p.Prd_Qty = woInfo.Prd_Qty;
            pop.WoInfo_p.Wc_Name = woInfo.Wc_Name;
            pop.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Label[] labels = { lblWoNo, lblItemName };
            string[] infos = { woInfo.WorkOrderNo, woInfo.Item_Name };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                sb.AppendLine($"{labels[i].Text} : {infos[i]}");
            }

            sb.AppendLine("해당 작업을 시작하시겠습니까?");

            DialogResult sResult = MessageBox.Show(sb.ToString(), "작업시작", MessageBoxButtons.YesNo);
            if (sResult == DialogResult.Yes)
            {
                bool result = wcServ.Start(woNo);

                if (result)
                {
                    MessageBox.Show("작업이 시작되었습니다.");
                    LoadData();
                }
                else MessageBox.Show("작업 시작에 실패하였습니다.\n다시 확인하여주십시오.");
            }
        }

        //private void Test(object sender, EventArgs e)
        //{
        //    ucWorkOrderStatusList ctrl = (ucWorkOrderStatusList)sender;
        //    ctrl.SendOrderList = new SelectOrderVO
        //    {
        //        Wo_Status = "ddd"
        //    };
        //}

        //private void Test(Panel pnl)
        //{
        //    foreach (ucWorkOrderStatusList ctrl in pnl.Controls)
        //    {
        //        int idx = 2;
        //        ctrl.Tag = idx;
        //        ctrl.SendOrderList.Wo_Status = "gg";
        //    }
        //}

        private void btnClosing_Click(object sender, EventArgs e)
        {
            Label[] labels = { lblWoNo, lblItemName };
            string[] infos = { woInfo.WorkOrderNo, woInfo.Item_Name };
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < labels.Length; i++)
            {
                sb.AppendLine($"{labels[i].Text} : {infos[i]}");
            }

            sb.AppendLine("해당 작업을 현장마감하시겠습니까?");

            DialogResult result = MessageBox.Show(sb.ToString(), "현장마감", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                bool clResult = wcServ.POPClosing(woNo);
                if (clResult)
                {
                    MessageBox.Show("현장마감되었습니다.");
                    CtrlRemove(pnlOrList, ctrlIdx);
                    foreach (UserControl ctrl in pnlOrList.Controls)
                    {
                        for (int i = 0; i < ctrl.TabIndex; i++)
                        {
                            ctrl.Location = new Point(0, 0 + (i * 99));
                        }
                    }
                        //ctrlOrList.Location
                }
                else MessageBox.Show("현장마감에 실패하였습니다.\n다시 확인하여주십시오.");
            }

        }

        //end 버튼
        private void btnEnd_Click(object sender, EventArgs e)
        {
            DialogResult sResult = MessageBox.Show($"{woNo}의 작업을 중지하시겠습니까?", "작업중지", MessageBoxButtons.YesNo);
            if (sResult == DialogResult.Yes)
            {
                bool result = wcServ.End(woNo);
                if (result)
                {
                    MessageBox.Show("작업이 중지되었습니다.");
                    LoadData();
                }
                else MessageBox.Show("작업 중지에 실패하였습니다.");
            }
                
        }

        //비가동 등록 버튼
        private void btnNopReg_Click(object sender, EventArgs e)
        {
            POPNopRegister frm = new POPNopRegister();
            frm.WoInfo = this.WoInfo;
            frm.ShowDialog();
            //작업장코드 woInfo에 있습니다~
        }

        //실적 등록 버튼
        private void btnPfm_Click(object sender, EventArgs e)
        {
            PopupRegPer frm = new PopupRegPer();
            frm.GetWoInfo.WorkOrderNo = woInfo.WorkOrderNo;
            frm.GetWoInfo.Item_Name = woInfo.Item_Name;
            frm.GetWoInfo.Wc_Name = woInfo.Wc_Name;
            frm.GetWoInfo.Plan_Date = woInfo.Plan_Date;
            frm.GetWoInfo.Plan_Qty_Box = woInfo.Plan_Qty_Box;
            frm.GetWoInfo.Prd_Qty = woInfo.Prd_Qty;
            frm.GetWoInfo.Wc_Code = woInfo.Wc_Code;

            frm.ShowDialog();
        }
    }
}
