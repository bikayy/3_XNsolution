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
    public partial class PopupBoxingGrade : Form
    {
        ucGradeList ctrlGrade = null;

        WcService wcServ = new WcService();

        private char mode;
        public char Mode { get { return mode; } set { mode = value; } }

        private string name = string.Empty;
        public string Name { get { return name; } set { name = value; } }

        private string code = string.Empty;
        public string Code { get { return code; } set { code = value; } }

        public PopupBoxingGrade()
        {
            InitializeComponent();
        }

        private void PopupBoxingGrade_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = wcServ.SelectGrade();
            Combo(cboName, dt, blankText: "선택");

            if (mode == 'G')
            {
                GradeList(dt);
                cboName.Enabled = false;
                cboName.Text = "";
            }
        }

        private void GradeList(DataTable dt)
        {
            int idx = 0;
            pnlList.Controls.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (idx > dt.Rows.Count) break;
                ctrlGrade = new ucGradeList();
                ctrlGrade.Location = new Point(0, 0 + (i * 85));
                ctrlGrade.Size = new Size(577, 80);
                ctrlGrade.SendGrade = new GradeVO
                {  
                    DetailCode = dt.Rows[idx]["DetailCode"].ToString(),
                    DetailName = dt.Rows[idx]["DetailName"].ToString()
                };
                ctrlGrade.TabIndex = idx;
                ctrlGrade.eventgradeList += OnCtrlClick;
                pnlList.Controls.Add(ctrlGrade);
                idx++;
            }
        }

        private void OnCtrlClick(object sender, EventArgs e)
        {
            ucGradeList ctrl = (ucGradeList)sender;
            name = ctrl.SendGrade.DetailName;
            code = ctrl.SendGrade.DetailCode;

            ctrl.BackColor = Color.Blue;
            CtrlSelection(pnlList, ctrl.TabIndex);
        }

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

        private void Combo(ComboBox cbo, DataTable dt, bool blankItem = true, string blankText = "")
        {
            if (blankItem)
            {
                GradeVO blank = new GradeVO
                {
                    DetailCode = "",
                    DetailName = blankText
                };
            }

            cbo.DisplayMember = "DetailName";
            cbo.ValueMember = "DetailCode";
            cbo.Text = "DetailName";
            cbo.DataSource = dt;
        }

        private void cboName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = wcServ.SelectGradeDetail(cboName.SelectedValue.ToString());
            GradeList(dt);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (name.Equals("PopupBoxingGrade") || string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("항목을 선택하여주십시오.");
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            
        }
    }
}
