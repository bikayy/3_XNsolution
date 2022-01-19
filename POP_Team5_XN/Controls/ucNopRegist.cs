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
    

    public partial class ucNopRegist : UserControl
    {
        public event EventHandler Nop_Mi_Insert;
        public event EventHandler Nop_Mi_Color;

        NopVO nopList = null;
        public NopVO SendnopList
        {
            get { return nopList; }
            set
            {
                nopList = value;
                label1.Text = value.Nop_Name;
                label1.Tag = value.Nop_Code;
            }
        }
        public ucNopRegist()
        {
            InitializeComponent();
        }

      

        private void ucNopRegist_1_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if(((Label)sender).Tag.ToString().ToUpper().Contains("MA"))
            {
                if (Nop_Mi_Insert != null)
                {
                    Nop_Mi_Insert(this, null);
                }
            }
            else if (((Label)sender).Tag.ToString().ToUpper().Contains("MI"))
            {
                if (Nop_Mi_Color != null)
                {
                    Nop_Mi_Color(this, null);
                }
            }
        }
    }
}
