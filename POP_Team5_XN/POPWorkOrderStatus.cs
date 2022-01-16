﻿using System;
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

        int btnCheck = 0;

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

            DataTable dt = new DataTable();
            dt = wcServ.SelectOr(woInfo.Wc_Code);
            int idx = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idx > dt.Rows.Count) break;
                //MessageBox.Show("ss");
                ctrlOrList = new ucWorkOrderStatusList();
                ctrlOrList.Location = new Point(0, 112 + (i * 99)); 
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
                ctrlOrList.Tag = idx.ToString();
                ctrlOrList.eventBtnCheck += OnBtn;
                ctrlOrList.eventOrderList += OnClick;
                ctrlOrList.eventWoStatus += btnStart_Click;
                pnlOrList.Controls.Add(ctrlOrList);
                idx++;
            }
        }

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

        private void OnClick(object sender, EventArgs e)
        {
            ucWorkOrderStatusList ctrl = (ucWorkOrderStatusList)sender;
            woNo = ctrl.SendOrderList.WorkOrderNo;
            ctrl.BackColor = Color.Blue;

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

            //MessageBox.Show(ctrl.SendOrderList.WorkOrderNo);
            //MessageBox.Show(ctrl.Tag.ToString());
        }

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
            //string idx = "2";
            //if (ctrlOrList.Tag.ToString() == idx)
            //{
            //    ctrlOrList.SendOrderList.Wo_Status = "dd";
            //}

            //DialogResult sResult = MessageBox.Show($"{woNo}의 작업을 시작하시겠습니까?", "작업시작", MessageBoxButtons.YesNo);
            //if (sResult == DialogResult.Yes)
            //{
            //    bool result = wcServ.Start(woNo);

            //    if (result) MessageBox.Show("작업이 시작되었습니다.");
            //    else MessageBox.Show("작업 시작에 실패하였습니다.");
            //}
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

        }


        private void btnEnd_Click(object sender, EventArgs e)
        {
            DialogResult sResult = MessageBox.Show($"{woNo}의 작업을 중지하시겠습니까?", "작업중지", MessageBoxButtons.YesNo);
            if (sResult == DialogResult.Yes)
            {
                bool result = wcServ.End(woNo);
                if (result) MessageBox.Show("작업이 중지되었습니다.");
                else MessageBox.Show("작업 중지에 실패하였습니다.");
            }
                
        }

        private void btnNopReg_Click(object sender, EventArgs e)
        {
            POPNopRegister frm = new POPNopRegister();
            frm.ShowDialog();
            //작업장코드 woInfo에 있습니다~
        }

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
