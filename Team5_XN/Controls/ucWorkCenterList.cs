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
    public partial class ucWorkCenterList : UserControl
    {
        public event EventHandler eventWcList;

        string wcCode = string.Empty;
        SelectWcVO wcList = null;
        public SelectWcVO SendWcList 
        {
            get { return wcList; }
            set
            {
                wcList = value;
                lblStatus.Text = value.Wo_Status;
                lblWcName.Text = value.Wc_Name;
                lblWcGroup.Text = value.Wc_Group;
                wcCode = value.Wc_Code;
            }
        }

        public ucWorkCenterList()
        {
            InitializeComponent();
        }

        private void ucWorkCenterList_Load(object sender, EventArgs e)
        {
            if (lblStatus.Text == "비가동")
            {
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void WcClick(object sender, EventArgs e)
        {
            if (eventWcList != null)
            {
                eventWcList(this, null);
            }
        }
    }
}
