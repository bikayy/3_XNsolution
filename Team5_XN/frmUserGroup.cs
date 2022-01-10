using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN.Service;

namespace Team5_XN
{
    public partial class frmUserGroup : Form
    {
        CommonService commonServ;
        UserService userServ = new UserService();
        DataTable dt;
        DataTable dt_DB;
        Main main = null;
        int rowCount;
        DataView searchList;
        int check = 0;

        public frmUserGroup()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void frmUserGroup_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Cancle += OnCancle;

            dgvUserGroup.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserGroup);

            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹코드", "UserGroup_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹명", "UserGroup_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용여부", "Use_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "Admin 여부", "Admin", colWidth: 100);
            //dt = userServ.GetUserGroupMaster();
            //dgvUserGroup.DataSource = dt;
            //LoadData();
        }
        private void OnSelect(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (check > 0)
            {
                OnCancle(this, e);

                if (this.DialogResult == DialogResult.No)
                    return;
            }

            ChangeValue_Check(0);

            //GetCommonCodeList
            string[] code = { "USE_YN", "Admin_YN" };

            //cdac = new CommonDAC();
            commonServ = new CommonService();

            DataTable dtSysCode = commonServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUse, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboAdmin, "Admin_YN", dtSysCode.Copy());
            userServ = new UserService();
            dt = userServ.GetUserGroupMaster();
            dt_DB = dt.Copy();
            dgvUserGroup.DataSource = dt;

            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtUserGroupCode.Text))
            {
                sb.Append(" AND UserGroup_Code LIKE '%" + txtUserGroupCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtUserGroupName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND UserGroup_Name LIKE '%" + txtUserGroupName.Text + "%'");
            }
            if (!cboUse.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Use_YN = '" + cboUse.Text + "'");
            }
            searchList.RowFilter = sb.ToString();
            dgvUserGroup.DataSource = searchList;
            rowCount = searchList.Count;
            dgvUserGroup.CurrentCell = null;
            ControlTextReset();


        }
        private void OnCancle(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            string menu;
            if (main.toolCreate.BackColor == Color.Yellow)
                menu = "추가";
            else
                menu = "편집";

            if (MessageBox.Show($"{menu}한 데이터를 저장하지 않고 기능을 취소하시겠습니까?.", "취소확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ChangeValue_Check(0);

                OnSelect(this, e);
                //this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }
        private void ControlTextReset()
        {
            txtGroupCode.Text =
            txtGroupName.Text =

            cboUseYN.Text =
            cboAdmin.Text = "";
        }

        private void ChangeValue_Check(int check)
        {
            this.check = check;

            //기본
            if (check == 0)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = true;
                main.toolSave.Enabled = main.toolCancle.Enabled = false;
                main.toolCreate.BackColor = main.toolUpdate.BackColor = Color.DarkGray;

            }
            //추가
            else if (check == 1)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolUpdate.Enabled = false;

                main.toolCreate.BackColor = Color.Yellow;

            }
            //편집
            else if (check == 2)
            {
                main.toolSelect.Enabled = main.toolUpdate.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolCreate.Enabled = main.toolDelete.Enabled = false;

                main.toolUpdate.BackColor = Color.Yellow;
            }

            ControlState();
            //삭제
            //else if (check == 3)
            //{

            //}
        }

        private void ControlState()
        {
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvUserGroup.CurrentRow != null && dgvUserGroup.CurrentRow.Index >= rowCount) //추가한 행
                {

                    foreach (Control ctrl in pnlDetail.Controls)
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
                    foreach (Control ctrl in pnlDetail.Controls)
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
            else if (check == 2) //2:편집
            {
                foreach (Control ctrl in pnlDetail.Controls)
                {
                    if (ctrl is Label) continue;
                    else if (ctrl is TextBox txt)
                    {
                        if (ctrl.Name.Equals("txtGroupCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
        }
        private void LoadData()
        {
            dgvUserGroup.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserGroup);

            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹코드", "UserGroup_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹명", "UserGroup_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용여부", "Use_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "Admin 여부", "Admin", colWidth: 100);
            //list = UserServ.GetUserGroupMaster();
            //dgvUserGroup.DataSource = list;
        }

        private void dgvUserGroup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtGroupCode.Text = dgvUserGroup["UserGroup_Code", dgvUserGroup.CurrentRow.Index].Value.ToString();
            txtGroupName.Text = dgvUserGroup["UserGroup_Name", dgvUserGroup.CurrentRow.Index].Value.ToString();

            cboAdmin.Text = dgvUserGroup["Admin", dgvUserGroup.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvUserGroup["Use_YN", dgvUserGroup.CurrentRow.Index].Value.ToString();

        }
    }
}
