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
            main.Create += OnCreate;
            main.Update += OnUpdate;
            main.Delete += OnDelete;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            main.Reset += OnReset;

            dgvUserGroup.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserGroup);

            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹코드", "UserGroup_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용자그룹명", "UserGroup_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "사용유무", "Use_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "Admin 여부", "Admin", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "작성일자", "Ins_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "작성자", "Ins_Emp", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "수정일자", "Up_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserGroup, "수정자", "Up_Emp", colWidth: 100, visibility: false);
            //GetCommonCodeList
            string[] code = { "USE_YN", "Admin_YN" };

            //cdac = new CommonDAC();
            commonServ = new CommonService();

            DataTable dtSysCode = commonServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUse, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboAdmin, "Admin_YN", dtSysCode.Copy());
            //userServ = new UserService();
            //dt = userServ.GetUserGroupMaster();
            //dt_DB = dt.Copy();
            //dt = userServ.GetUserGroupMaster();
            //dgvUserGroup.DataSource = dt;
            //LoadData();
            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false; 
        }

        private void OnReset(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
            txtUserGroupCode.Text = txtUserGroupName.Text = "";
            cboUse.SelectedIndex = 0;
            dgvUserGroup.CurrentCell = null;
            ControlTextReset();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dgvUserGroup.CurrentCell == null)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            }

            if (check == 1) //1:추가
            {
                if (dgvUserGroup.CurrentCell.RowIndex >= rowCount)
                {
                    dt.Rows.Remove(dt.Rows[dgvUserGroup.CurrentCell.RowIndex]);
                    dt.AcceptChanges();

                    //if (dataGridView1.RowCount == rowCount)
                    //    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.RowCount-1];
                    dgvUserGroup_CellClick(dgvUserGroup, new DataGridViewCellEventArgs(dgvUserGroup.CurrentCell.ColumnIndex, dgvUserGroup.CurrentCell.RowIndex));
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtGroupCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    userServ = new UserService();
                    bool result = userServ.DeleteUserGroup(txtGroupCode.Text);
                    if (result)
                    {
                        MessageBox.Show("삭제 완료");
                        //LoadData();
                        OnSelect(this, e);
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패");
                    }
                }
            }
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("UserGroup_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("UserGroup_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("Admin", typeof(char)));
            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            userServ = new UserService();

            //저장-추가
            if (check == 1)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.IndexOf(dr) >= rowCount)
                    {
                        int r = dt.Rows.IndexOf(dr);

                        DataView dv_duple = new DataView(dt_DB);
                        dv_duple.RowFilter = $"UserGroup_Code = '{dgvUserGroup[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"그룹코드는 중복 될 수 없습니다. ({dgvUserGroup[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvUserGroup.CurrentCell = dgvUserGroup[0, r];
                            dgvUserGroup_CellClick(dgvUserGroup, new DataGridViewCellEventArgs(0, r));
                            return;
                        }


                        for (int c = 0; c < 4; c++)
                        {
                            if (dgvUserGroup[c, r].Value.ToString().Length < 1)
                            {
                                if (c == 3) continue;
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dgvUserGroup.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dgvUserGroup.CurrentCell = dgvUserGroup[c, r];
                                dgvUserGroup_CellClick(dgvUserGroup, new DataGridViewCellEventArgs(c, r));
                                return;
                            }
                        }

                        DataRow drNew = dt2.NewRow();
                        drNew["UserGroup_Code"] = dr["UserGroup_Code"];
                        drNew["UserGroup_Name"] = dr["UserGroup_Name"];
                        drNew["Admin"] = (dr["Admin"].ToString() == "예") ? "A" : "D";
                        drNew["Use_YN"] = (dr["Use_YN"].ToString() == "예") ? "Y" : "N";
                        drNew["Ins_Date"] = dr["Ins_Date"];
                        drNew["Ins_Emp"] = dr["Ins_Emp"];
                        drNew["Up_Date"] = dr["Up_Date"];
                        drNew["Up_Emp"] = dr["Up_Emp"];

                        dt2.Rows.Add(drNew);
                        // dt2.ImportRow(dr);
                    }
                }
                dt2.AcceptChanges();

                result = userServ.SaveUserGroup(dt2, check);

            }
            //저장-편집
            else if (check == 2)
            {
                //dt = (DataTable)dgvUserGroup.DataSource;
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
                            drNew["UserGroup_Name"] = dr["UserGroup_Name"];
                            drNew["Admin"] = (dr["Admin"].ToString() == "예") ? "A" : "D";
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
                if (dt2.Rows.Count < 1)
                {
                    MessageBox.Show("저장할 데이터가 없습니다.");
                    return;
                }
                result = userServ.SaveUserGroup(dt2, check);

            }

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
            //else
            //{
            //    MessageBox.Show("저장할 데이터가 없습니다.");
            //}
        }

        

        private void OnCreate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dt == null) return;
            ChangeValue_Check(1); //추가
            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = dt.NewRow();

            dt.Rows.Add(dr);

            dt.AcceptChanges();
            dgvUserGroup.DataSource = dt;
            dgvUserGroup.CurrentCell = dgvUserGroup[0, dgvUserGroup.RowCount - 1];
            dgvUserGroup_CellClick(dgvUserGroup, new DataGridViewCellEventArgs(0, dgvUserGroup.RowCount - 1));
        }
        private void OnUpdate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dgvUserGroup.CurrentRow != null)
                dgvUserGroup_CellClick(dgvUserGroup, new DataGridViewCellEventArgs(0, dgvUserGroup.CurrentRow.Index));
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
            dt = userServ.GetUserGroupMaster();
            dt_DB = dt.Copy();

            //dgvUserGroup.DataSource = dt;

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
            //dgvUserGroup.CurrentCell = null;
            ControlTextReset();
            if (dgvUserGroup.Rows.Count > 0)
                dgvUserGroup_CellClick(dgvUserGroup, new DataGridViewCellEventArgs(0, 0));
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
                dt = dt_DB.Copy();
                dgvUserGroup.DataSource = dt;
                //OnSelect(this, e);
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
            dt = userServ.GetUserGroupMaster();
            dgvUserGroup.DataSource = dt;
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
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (dgvUserGroup.CurrentCell == null) return;
            if ((check == 1 && dgvUserGroup.CurrentRow.Index >= rowCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvUserGroup[ctrl.Tag.ToString(), dgvUserGroup.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvUserGroup.Rows[dgvUserGroup.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }

        private void dgvUserGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
