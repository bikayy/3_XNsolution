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

    public partial class frmUserInfo : Form
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

        public frmUserInfo()
        {
            InitializeComponent();
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;

            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Delete += OnDelete;
            main.Cancle += OnCancle;
            //LoadData();
            dgvUserInfo.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserInfo);

            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용자 ID", "User_ID", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용자 이름", "User_Name", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "권한그룹 코드", "UserGroup_Code", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "권한그룹 명", "UserGroup_Name", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "기본 공정 코드", "Default_Major_Process_Code", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "기본 공정 명", "Process_Name", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "IP 보안 적용여부", "IP_Security_YN", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "패스워드 초기화 횟수", "PW_Reset_Count", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용여부", "Use_YN", DataGridViewContentAlignment.MiddleCenter, colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "작성일자", "Ins_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "작성자", "Ins_Emp", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "수정일자", "Up_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "수정자", "Up_Emp", colWidth: 100, visibility: false);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN", "IP_Security_YN" };

            //cdac = new CommonDAC();
            commonServ = new CommonService();

            DataTable dtSysCode = commonServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUse, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboIPSecurity, "IP_Security_YN", dtSysCode.Copy());

        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dgvUserInfo.CurrentCell == null)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            }

            if (check == 1) //1:추가
            {
                if (dgvUserInfo.CurrentCell.RowIndex >= rowCount)
                {
                    dt.Rows.Remove(dt.Rows[dgvUserInfo.CurrentCell.RowIndex]);
                    dt.AcceptChanges();

                    //if (dataGridView1.RowCount == rowCount)
                    //    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.RowCount-1];
                    dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(dgvUserInfo.CurrentCell.ColumnIndex, dgvUserInfo.CurrentCell.RowIndex));
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtID.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    userServ = new UserService();
                    bool result = userServ.DeleteUser(txtID.Text);
                    if (result)
                    {
                        MessageBox.Show("삭제 완료");
                        OnSelect(this, e);
                    }
                    else
                    {
                        MessageBox.Show("삭제 실패");
                    }
                }
            }
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(1); //추가
            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = dt.NewRow();

            dt.Rows.Add(dr);

            dt.AcceptChanges();
            dgvUserInfo.DataSource = dt;
            dgvUserInfo.CurrentCell = dgvUserInfo[0, dgvUserInfo.RowCount - 1];
            dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, dgvUserInfo.RowCount - 1));
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("User_ID", typeof(string)));
            dt2.Columns.Add(new DataColumn("User_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("User_PW", typeof(string)));
            dt2.Columns.Add(new DataColumn("UserGroup_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("IP_Security_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("Default_Major_Process_Code", typeof(string)));
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
                        dv_duple.RowFilter = $"User_ID = '{dgvUserInfo[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"아이디는 중복 될 수 없습니다. ({dgvUserInfo[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvUserInfo.CurrentCell = dgvUserInfo[0, r];
                            dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, r));
                            return;
                        }


                        for (int c = 0; c < 5; c++)
                        {
                            if (dgvUserInfo[c, r].Value.ToString().Length < 1)
                            {
                                if (c == 4) continue;
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dgvUserInfo.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dgvUserInfo.CurrentCell = dgvUserInfo[c, r];
                                dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(c, r));
                                return;
                            }
                        }

                        DataRow drNew = dt2.NewRow();
                        drNew["User_ID"] = dr["User_ID"];
                        drNew["User_Name"] = dr["User_Name"];
                        drNew["User_PW"] = dr["User_ID"];
                        drNew["UserGroup_Code"] = dr["UserGroup_Code"];
                        drNew["IP_Security_YN"] = (dr["IP_Security_YN"].ToString() == "허용") ? "A" : "D";
                        drNew["Default_Major_Process_Code"] = dr["Default_Major_Process_Code"];
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

                result = userServ.SaveUser(dt2, check);

            }
            //저장-편집
            else if (check == 2)
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
                            drNew["User_ID"] = dr["User_ID"];
                            drNew["User_Name"] = dr["User_Name"];
                            drNew["UserGroup_Code"] = dr["UserGroup_Code"];
                            drNew["IP_Security_YN"] = (dr["IP_Security_YN"].ToString() == "허용") ? "A" : "D";
                            drNew["Default_Major_Process_Code"] = dr["Default_Major_Process_Code"];
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
                result = userServ.SaveUser(dt2, check);

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
            else
            {
                MessageBox.Show("저장할 데이터가 없습니다.");
            }


        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dgvUserInfo.CurrentRow != null)
                dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, dgvUserInfo.CurrentRow.Index));
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
            dt = userServ.GetUserInfo();
            dt_DB = dt.Copy();
            dgvUserInfo.DataSource = dt;
            //dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, 0));
            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtUserID.Text))
            {
                sb.Append(" AND User_ID LIKE '%" + txtUserID.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND User_Name LIKE '%" + txtUserName.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtGroupCode.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND UserGroup_Code LIKE '%" + txtGroupCode.Text + "%'");
            }
            if (!cboUse.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Use_YN = '" + cboUse.Text + "'");
            }
            searchList.RowFilter = sb.ToString();
            dgvUserInfo.DataSource = searchList;
            rowCount = searchList.Count;
            dgvUserInfo.CurrentCell = null;
            ControlTextReset();
        }

        private void ControlTextReset()
        {
            txtID.Text =
            txtName.Text =

            txtUserGroupCode.Text =
            txtUserGroupName.Text =

            txtProcessCode.Text =
            txtProcessName.Text =

            cboIPSecurity.Text =
            cboUseYN.Text = "";
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
        }

        private void ControlState()
        {
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvUserInfo.CurrentRow != null && dgvUserInfo.CurrentRow.Index >= rowCount) //추가한 행
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
                        if (ctrl.Name.Equals("txtID")) continue;
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
            dgvUserInfo.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserInfo);

            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용자 ID", "User_ID", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용자 이름", "User_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "권한그룹 코드", "UserGroup_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "권한그룹 명", "UserGroup_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "기본 공정 코드", "Default_Major_Process_Code", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "기본 공정 명", "Process_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "IP 보안 적용여부", "IP_Security_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "패스워드 초기화 횟수", "PW_Reset_Count", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvUserInfo, "사용여부", "Use_YN", colWidth: 100);
            dt = userServ.GetUserInfo();
            dgvUserInfo.DataSource = list;
        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            try
            {
                UserVO userPwd = new UserVO
                {
                    User_ID = txtID.Text,
                    User_PW = txtID.Text
                };

                bool result = userServ.UpdateID(userPwd);

                if (result) MessageBox.Show("수정되었습니다.");
                else MessageBox.Show("오류가 발생하였습니다.\n다시 시도하여주십시오.");

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void pnlSelect_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtID.Text = dgvUserInfo["User_ID", dgvUserInfo.CurrentRow.Index].Value.ToString();
            txtName.Text = dgvUserInfo["User_Name", dgvUserInfo.CurrentRow.Index].Value.ToString();

            txtUserGroupCode.Text = dgvUserInfo["UserGroup_Code", dgvUserInfo.CurrentRow.Index].Value.ToString();
            txtUserGroupName.Text = dgvUserInfo["UserGroup_Name", dgvUserInfo.CurrentRow.Index].Value.ToString();

            txtProcessCode.Text = dgvUserInfo["Default_Major_Process_Code", dgvUserInfo.CurrentRow.Index].Value.ToString();
            txtProcessName.Text = dgvUserInfo["Process_Name", dgvUserInfo.CurrentRow.Index].Value.ToString();

            cboIPSecurity.Text = dgvUserInfo["IP_Security_YN", dgvUserInfo.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvUserInfo["Use_YN", dgvUserInfo.CurrentRow.Index].Value.ToString();

        }
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (dgvUserInfo.CurrentCell == null) return;
            if ((check == 1 && dgvUserInfo.CurrentRow.Index >= rowCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvUserInfo[ctrl.Tag.ToString(), dgvUserInfo.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvUserInfo.Rows[dgvUserInfo.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopupUserGroup frm = new PopupUserGroup();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtGroupCode.Text = frm.Send.UserGroup_Code;
                txtGroupName.Text = frm.Send.UserGroup_Name;
            }
        }

        private void btnUserGroup_Click(object sender, EventArgs e)
        {
            PopupUserGroup frm = new PopupUserGroup();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtUserGroupCode.Text = frm.Send.UserGroup_Code;
                txtUserGroupName.Text = frm.Send.UserGroup_Name;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            PopupSearchProcess sp = new PopupSearchProcess();
            sp.ShowDialog();
            if (sp.DialogResult == DialogResult.OK)
            {
                txtProcessCode.Text = sp.Send.Process_Code;
                txtProcessName.Text = sp.Send.Process_Name;
            }
        }
    }
}
