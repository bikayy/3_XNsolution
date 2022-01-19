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
    public partial class ucGradeList : UserControl
    {
        public event EventHandler eventgradeList;

        private GradeVO grade = null;
        public GradeVO SendGrade 
        {
            get { return grade; }
            set 
            { 
                grade = value;
                lblCode.Text = value.DetailCode;
                lblName.Text = value.DetailName;
            }
        }

        public ucGradeList()
        {
            InitializeComponent();
        }

        private void gradeClick(object sender, EventArgs e)
        {
            if (eventgradeList != null)
            {
                eventgradeList(this, null);
            }
        }
    }
}
