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
    public partial class ucWorkOrderStatusList : UserControl
    {
        public event EventHandler eventOrderList;
        public event EventHandler eventBtnCheck;
        public event EventHandler eventRemark;

        SelectOrderVO orderList = null;
        public SelectOrderVO SendOrderList
        {
            get { return orderList; }
            set
            {
                orderList = value;
                lblStatus.Text = value.Wo_Status;
                lblPlanDate.Text = value.Plan_Date;
                lblPrdDate.Text = value.Prd_Date;
                lblWoNo.Text = value.WorkOrderNo;
                lblProj.Text = value.Project_Nm;
                lblItemK.Text = value.Item_Name;
                lblITemE.Text = value.Item_Name_Eng;
                lblPlanQty.Text = value.Plan_Qty_Box.ToString();
                lblPerQty.Text = value.Prd_Qty.ToString();
                lblPrdStartTime.Text = value.Prd_StartTime;
                lblPrdEndTime.Text = value.Prd_EndTime;
                lblRemark.Text = value.Remark_YN;
            }
        }


        public ucWorkOrderStatusList()
        {
            InitializeComponent();
        }

        private void ucWorkOrderStatusList_Load(object sender, EventArgs e)
        {
            //if (eventOrderList != null)
            //{
            //    eventOrderList(this, null);
            //}

            switch (lblStatus.Text)
            {
                case "생산대기": lblStatus.ForeColor = Color.Orange; break;
                case "생산중": lblStatus.ForeColor = Color.Green; break;
                case "생산중지": lblStatus.ForeColor = Color.Gold; break;
            }

        }

        private void ucOrStatusClick(object sender, EventArgs e)
        {
            if (eventOrderList != null)
            {
                eventOrderList(this, null);
            }

            if (eventBtnCheck != null)
            {
                eventBtnCheck(this, null);
            }

        }


        private void ucRemarkClick(object sender, EventArgs e)
        {
            if (eventOrderList != null)
            {
                eventOrderList(this, null);
            }

            if (eventBtnCheck != null)
            {
                eventBtnCheck(this, null);
            }
            if (eventRemark != null)
            {
                eventRemark(this, null);
            }
        }


    }
}
