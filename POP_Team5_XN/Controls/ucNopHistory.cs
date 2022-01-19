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

namespace POP_Team5_XN
{

    public partial class ucNopHistory : UserControl
    {

        NopHistoryVO nopHis = null;

        public event EventHandler Nop_History;
        public NopHistoryVO SendnopList
        {
            get { return nopHis; }
            set
            {
                nopHis = value;
                lblWcName.Text = value.Wc_Name;
                lblNopMa.Text = value.Nop_Ma_Name;
                lblNopMi.Text = value.Nop_Mi_Name;
                lblNopTime.Text = value.Nop_DateTime_Start.ToString("yyyy-MM-dd HH:mm:ss");
                lblNopMinute.Text = value.Nop_Time;
                //(t1, t2) -> t1기준. t2가 더 크면 return -1, 같으면 0, 작으면 1
                //if (DateTime.Compare(value.Nop_DateTime_Start, value.Nop_DateTime_End) < 0)
                //{
                //    TimeSpan diff = value.Nop_DateTime_End - value.Nop_DateTime_Start;
                //    value.Nop_Time = diff.TotalMinutes.ToString("N2");
                //    lblNopMinute.Text = value.Nop_Time;
                //}
            }
        }


        public ucNopHistory()
        {
            InitializeComponent();
        }

        private void ucNopHistory_Click(object sender, EventArgs e)
        {
            if (Nop_History != null)
            {
                Nop_History(this, null);
            }
        }
    }
}
