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
    public partial class frmScreenManagement : Form
    {
        UserService userServ = new UserService();
        CommonService commonServ;
        DataTable dt;
        Main main = null;
        DataView searchList;
        int rowCount;
        int check = 0;
        public frmScreenManagement()
        {
            InitializeComponent();
        }

        private void frmScreenManagement_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;

            dgvScreen.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvScreen);

            DataGridViewUtil.AddGridTextColumn(dgvScreen, "화면코드", "Screen_Code", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvScreen, "화면명", "WordKey", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvScreen, "화면경로", "Screen_Path", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvScreen, "모니터링 유무", "Monitoring_YN", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvScreen, "사용유무", "Use_YN", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN", "Monitoring_YN" };

            //cdac = new CommonDAC();
            commonServ = new CommonService();

            DataTable dtSysCode = commonServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUse, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboMonitor, "Monitoring_YN", dtSysCode.Copy());
        }

        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(0);
            userServ = new UserService();
            dt = userServ.GetScreenList();
            dgvScreen.DataSource = dt;
            //dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, 0));
            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtCode.Text))
            {
                sb.Append(" AND Screen_Code LIKE '%" + txtCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND WordKey LIKE '%" + txtName.Text + "%'");
            }
            if (!cboUse.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Use_YN = '" + cboUse.Text + "'");
            }
            searchList.RowFilter = sb.ToString();
            dgvScreen.DataSource = searchList;
            rowCount = searchList.Count;
            dgvScreen.CurrentCell = null;
        }
        private void ChangeValue_Check(int check)
        {
            this.check = check;

            //기본
            if (check == 0)
            {
                main.toolSelect.Enabled = true;
                main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
                main.toolCreate.BackColor = main.toolUpdate.BackColor = Color.DarkGray;

            }
            //추가
            else if (check == 1)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolUpdate.Enabled = false;

                main.toolCreate.BackColor = Color.Yellow;

            }

            ControlState();
        }

        private void ControlState()
        {
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvScreen.CurrentRow != null && dgvScreen.CurrentRow.Index >= rowCount) //추가한 행
                {

                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is Label) continue;

                        else if (ctrl is TextBox txt)
                            txt.ReadOnly = false;
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = true;
                        else if (ctrl is Button btn)
                            btn.Enabled = true;
                    }
                }
                else //기존 행
                {
                    foreach (Control ctrl in panel1.Controls)
                    {
                        if (ctrl is Label) continue;
                        else if (ctrl is TextBox txt)
                            txt.ReadOnly = true;
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = false;
                        else if (ctrl is Button btn)
                            btn.Enabled = false;
                    }
                }
        }

        private void dgvScreen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtScreenCode.Text = dgvScreen["Screen_Code", dgvScreen.CurrentRow.Index].Value.ToString();
            txtSearchScreen.Text = dgvScreen["Screen_Path", dgvScreen.CurrentRow.Index].Value.ToString();

            txtWordKey.Text = dgvScreen["WordKey", dgvScreen.CurrentRow.Index].Value.ToString();
            txtScreenPath.Text = dgvScreen["Screen_Path", dgvScreen.CurrentRow.Index].Value.ToString();

            cboUseYN.Text = dgvScreen["Use_YN", dgvScreen.CurrentRow.Index].Value.ToString();
            cboMonitor.Text = dgvScreen["Monitoring_YN", dgvScreen.CurrentRow.Index].Value.ToString();
        }
    }
}
