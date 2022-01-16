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
    public partial class ucPaletteList : UserControl
    {
        PaletteListVO pList = null;
        public PaletteListVO SendPList 
        {
            get { return pList; }
            set
            {
                pList = value;
                lblPaletteNo.Text = value.Pallet_No;
                lblGrade.Text = value.Grade;
                lblGradeDetail.Text = value.Grade_Detail_Name;
                lblQty.Text = value.In_Qty.ToString();
            }
        }


        public ucPaletteList()
        {
            InitializeComponent();
        }

        private void ucPaletteList_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.Tag) == 0)
            {
                lblPaletteNo.ForeColor = lblGrade.ForeColor = lblGradeDetail.ForeColor = lblQty.ForeColor = Color.White;
            }
            else if (Convert.ToInt32(this.Tag) % 2 == 0 )
            {
                pnl1.BackColor = pnl2.BackColor = pnl3.BackColor = pnl4.BackColor = Color.LightGray;
            }
            else
            {
                pnl1.BackColor = pnl2.BackColor = pnl3.BackColor = pnl4.BackColor = Color.Snow;
            }
        }
    }
}
