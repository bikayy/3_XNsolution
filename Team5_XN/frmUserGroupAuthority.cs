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
    public partial class frmUserGroupAuthority : Form
    {
        UserVO user;
        List<UserVO> list = null;
        CommonService commonServ;
        UserService userServ = new UserService();
        DataTable dt;
        DataTable dt_DB;
        Main main = null;
        int rowCount;
        DataView searchList;
        int check = 0;
        public frmUserGroupAuthority()
        {
            InitializeComponent();
        }

        private void frmUserGroupAuthority_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;

            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            //LoadData();
            dgvUserAuthority.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserAuthority);

            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "사용자그룹코드", "UserGroup_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "메뉴코드", "Screen_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "메뉴명", "WordKey", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "사용유무", "Use_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "작성일자", "Ins_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "작성자", "Ins_Emp", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "수정일자", "Up_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "수정자", "Up_Emp", colWidth: 100, visibility: false);

            //GetCommonCodeList
            string[] code = { "USE_YN" };

            //cdac = new CommonDAC();
            commonServ = new CommonService();

            DataTable dtSysCode = commonServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy());
        }

        private void OnCancle(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
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

        private void OnSave(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("UserGroup_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Screen_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            userServ = new UserService();
            //저장-편집
            if (check == 2)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {

                        string a = dt_DB.Rows[dt.Rows.IndexOf(dr)][dt.Columns.IndexOf(dc)].ToString();
                        string b = dr[dc].ToString();
                        if (b != a)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["UserGroup_Code"] = dr["UserGroup_Code"];
                            drNew["Screen_Code"] = dr["Screen_Code"];
                            drNew["Use_YN"] = (dr["Use_YN"].ToString() == "예") ? "Y" : "N";
                            drNew["Ins_Date"] = dr["Ins_Date"];
                            drNew["Ins_Emp"] = dr["Ins_Emp"];
                            drNew["Up_Date"] = dr["Up_Date"];
                            drNew["Up_Emp"] = dr["Up_Emp"];

                            dt2.Rows.Add(drNew);
                            break;
                            // dt2.ImportRow(dr);
                        }
                    }
                }
                dt2.AcceptChanges();
                result = userServ.SaveAuthority(dt2, check);
                if (result > 0)
                {
                    MessageBox.Show("저장 완료");
                    ChangeValue_Check(0);
                    OnSelect(this, e);

                }
                else if (result < 0)
                {
                    MessageBox.Show("저장 실패");
                }
                else
                {
                    MessageBox.Show("저장할 데이터가 없습니다.");
                }
            }
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dgvUserAuthority.CurrentRow != null)
                dgvUserAuthority_CellClick(dgvUserAuthority, new DataGridViewCellEventArgs(0, dgvUserAuthority.CurrentRow.Index));
        }

        private void OnSelect(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (check > 0)
            {
                OnCancle(this, e);

                if (this.DialogResult == DialogResult.No)
                    return;
            }

            ChangeValue_Check(0);

            userServ = new UserService();
            dt = userServ.GetUserAuthority();
            dt_DB = dt.Copy();
            dgvUserAuthority.DataSource = dt;
            //dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, 0));
            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtUserCode.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND UserGroup_Code LIKE '%" + txtUserCode.Text + "%'");
            }
            searchList.RowFilter = sb.ToString();
            dgvUserAuthority.DataSource = searchList;
            rowCount = searchList.Count;
            dgvUserAuthority.CurrentCell = null;
        }
        private void ChangeValue_Check(int check)
        {
            this.check = check;

            //기본
            if (check == 0)
            {
                main.toolSelect.Enabled = main.toolUpdate.Enabled =  true;
                main.toolCreate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
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
        }

        private void ControlState()
        {
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvUserAuthority.CurrentRow != null && dgvUserAuthority.CurrentRow.Index >= rowCount) //추가한 행
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
            else if (check == 2) //2:편집
            {
                foreach (Control ctrl in panel1.Controls)
                {
                    if (ctrl is Label) continue;
                    else if (ctrl is TextBox txt)
                        txt.ReadOnly = true;
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
        }

        private void pnlSelect_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopupUserGroup frm = new PopupUserGroup();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtUserCode.Text = frm.Send.UserGroup_Code;
                txtUserName.Text = frm.Send.UserGroup_Name;
            }
        }

        private void dgvUserAuthority_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            //if (check == 1) ControlState();



            txtGroupCode.Text = dgvUserAuthority["UserGroup_Code", dgvUserAuthority.CurrentRow.Index].Value.ToString();
            txtScreenCode.Text = dgvUserAuthority["Screen_Code", dgvUserAuthority.CurrentRow.Index].Value.ToString();
            txtWordKey.Text = dgvUserAuthority["WordKey", dgvUserAuthority.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvUserAuthority["Use_YN", dgvUserAuthority.CurrentRow.Index].Value.ToString();

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (dgvUserAuthority.CurrentCell == null) return;
            if ((check == 1 && dgvUserAuthority.CurrentRow.Index >= rowCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvUserAuthority[ctrl.Tag.ToString(), dgvUserAuthority.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvUserAuthority.Rows[dgvUserAuthority.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }
    }
}
