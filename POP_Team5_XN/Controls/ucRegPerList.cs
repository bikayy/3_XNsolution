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
    public partial class ucRegPerList : UserControl
    {
        public event EventHandler eventDelete;

        private SelectPerSiyuVO perSiyu = null;
        public SelectPerSiyuVO SendPerSiyu 
        { 
            get { return perSiyu; } 
            set 
            { 
                perSiyu = value;
                lblRegDate.Text = value.Reg_Datetime.ToString("yyyy-MM-dd HH:mm:ss:fff");
                lblPrdQty.Text = value.Prd_Qty.ToString();
            } 
        }

        public ucRegPerList()
        {
            InitializeComponent();
        }

        private void ucRegPerList_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.Tag) != 0 && Convert.ToInt32(this.Tag) % 2 != 0)
            {
                pnl1.BackColor = pnl2.BackColor = Color.FromArgb(210, 221, 234);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (eventDelete != null)
            {
                eventDelete(this, null);
            }
        }
    }
}
