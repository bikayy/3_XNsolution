using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public partial class frmDownTimeCode : Form
    {
        DataTable dtDetail;
        DataTable dtDetailOrigin;
        NopService nopServ = new NopService();
        CommonService commServ = new CommonService();
        DataTable dt;
        DataTable dt_DB;
        Main main = null;
        int rowCount;
        DataView searchList;
        int check = 0;
        int detailCount;
        DataTable dtSysUser;
        DataTable dtSysCode;

        public frmDownTimeCode()
        {
            InitializeComponent();
        }

        private void frmDownTimeCode_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Delete += OnDelete;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            dgvNopMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvNopMaster);

            DataGridViewUtil.AddGridTextColumn(dgvNopMaster, "비가동 대분류 코드", "Nop_Ma_Code", colWidth: 160);
            DataGridViewUtil.AddGridTextColumn(dgvNopMaster, "비가동 대분류 명", "Nop_Ma_Name", colWidth: 140);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "사용유무", "Use_YN", colWidth: 100);

            dgvNopDetail.Columns.Clear();
            DataGridViewUtil.SetInitGridView(dgvNopDetail);

            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "비가동 상세분류 코드", "Nop_Mi_Code", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "비가동 상세분류 명", "Nop_Mi_Name", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "비가동 대분류 코드", "Nop_Ma_Code", colWidth: 160, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "사용유무", "Use_YN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "공정그룹", "Process_Group", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "비고", "Remark", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "비가동유형", "Nop_type", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "비가동구분", "Regular_Type", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "작성일자", "Ins_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "작성자", "Ins_Emp", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "수정일자", "Up_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvNopDetail, "수정자", "Up_Emp", colWidth: 100, visibility: false);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN", "PROC_GROUP", "NOP_CODE_TYPE", "REGULAR_TYPE" };

            //cdac = new CommonDAC();
            commServ = new CommonService();

            dtSysCode = commServ.GetCommonCodeSys(code);
            dtSysUser = commServ.GetCommonCodeUser(code);
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboUse, "USE_YN", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboProcess, "PROC_GROUP", dtSysUser.Copy());
            CommonUtil.ComboBinding(cboNopType, "NOP_CODE_TYPE", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboRegularType, "REGULAR_TYPE", dtSysCode.Copy());
            nopServ = new NopService();
            dt = nopServ.GetNopMaster();
            dt_DB = dt.Copy();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dgvNopDetail.CurrentCell == null)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            }

            if (check == 1) //1:추가
            {
                if (dgvNopDetail.CurrentRow.Index >= detailCount)
                {
                    dt.Rows.Remove(dt.Rows[dgvNopDetail.CurrentCell.RowIndex]);
                    dt.AcceptChanges();

                    //if (dataGridView1.RowCount == rowCount)
                    //    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.RowCount-1];
                    dgvNopDetail_CellClick(dgvNopDetail, new DataGridViewCellEventArgs(dgvNopDetail.CurrentCell.ColumnIndex, dgvNopDetail.CurrentCell.RowIndex));
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtNopMiCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    nopServ = new NopService();
                    bool result = nopServ.DeleteNopDetail(txtNopMiCode.Text);
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

            
            dgvNopMaster.DataSource = dt;
            
            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtNopCode.Text))
            {
                sb.Append(" AND Nop_Ma_Code LIKE '%" + txtNopCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(cboUse.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Use_YN LIKE '%" + cboUse.Text + "%'");
            }
            searchList.RowFilter = sb.ToString();
            dgvNopMaster.DataSource = searchList;
            rowCount = searchList.Count;
            //dgvNopMaster.CurrentCell = null;

            ControlTextReset();
            dgvNopMaster_CellClick(dgvNopMaster, new DataGridViewCellEventArgs(0, 0));
            dgvNopDetail_CellClick(dgvNopDetail, new DataGridViewCellEventArgs(0, 0));
        }

        private void ControlTextReset()
        {
            txtNopMaCode.Text =
            txtNopMaName.Text =

            txtNopMiCode.Text =
            txtNopMiName.Text =

            cboProcess.Text =
            txtRemark.Text =

            cboNopType.Text =
            cboRegularType.Text =
            cboUseYN.Text = "";
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = dtDetail.NewRow();
            dr["Nop_Ma_Code"] = txtNopMaCode.Text;
            dtDetail.Rows.Add(dr);
            dtDetail.AcceptChanges();
            dgvNopDetail.DataSource = dtDetail;
            dgvNopDetail.CurrentCell = dgvNopDetail[0, dgvNopDetail.RowCount - 1];
            dgvNopDetail_CellClick(dgvNopDetail, new DataGridViewCellEventArgs(0, dgvNopDetail.RowCount - 1));

            ChangeValue_Check(1); //추가
            //dgvNopDetail.Enabled = false;
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dgvNopDetail.CurrentRow != null)
                dgvNopDetail_CellClick(dgvNopDetail, new DataGridViewCellEventArgs(0, dgvNopDetail.CurrentRow.Index));
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("Nop_Mi_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Nop_Mi_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("Nop_Ma_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Nop_type", typeof(string)));
            dt2.Columns.Add(new DataColumn("Regular_Type", typeof(string)));
            dt2.Columns.Add(new DataColumn("Process_Group", typeof(string)));
            dt2.Columns.Add(new DataColumn("Remark", typeof(string)));
            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            nopServ = new NopService();

            //저장-추가
            if (check == 1)
            {

                foreach (DataRow dr in dtDetail.Rows)
                {
                    if (dtDetail.Rows.IndexOf(dr) >= detailCount)
                    {
                        int r = dtDetail.Rows.IndexOf(dr);

                        DataView dv_duple = new DataView(dtDetail);
                        dv_duple.RowFilter = $"Nop_Mi_Code = '{dgvNopDetail[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"코드는 중복 될 수 없습니다. ({dgvNopDetail[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvNopDetail.CurrentCell = dgvNopDetail[0, r];
                            dgvNopDetail_CellClick(dgvNopDetail, new DataGridViewCellEventArgs(0, r));
                            return;
                        }

                        for (int c = 0; c < 2; c++)
                        {
                            if (dgvNopDetail[c, r].Value.ToString().Length < 1)
                            {
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dgvNopDetail.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dgvNopDetail.CurrentCell = dgvNopDetail[c, r];
                                dgvNopDetail_CellClick(dgvNopDetail, new DataGridViewCellEventArgs(c, r));
                                return;
                            }
                        }

                        DataView dMaster = new DataView(dtDetail);
                        dMaster.RowFilter = $"Nop_Ma_Code = '{dgvNopDetail[2, dgvNopDetail.CurrentRow.Index].Value.ToString()}'";

                        DataView dvCode = new DataView(dtSysUser);
                        dvCode.RowFilter = $"Code='PROC_GROUP' and DetailName='{dr["Process_Group"]}'";

                        DataView dvSys = new DataView(dtSysCode);
                        dvSys.RowFilter = $"Code='REGULAR_TYPE' and DetailName='{dr["Regular_Type"]}'";
                        DataView dvSys2 = new DataView(dtSysCode);
                        dvSys2.RowFilter = $"Code='NOP_CODE_TYPE' and DetailName='{dr["Nop_type"]}'";
                        DataRow drNew = dt2.NewRow();
                        drNew["Nop_Mi_Code"] = dr["Nop_Mi_Code"];
                        drNew["Nop_Mi_Name"] = dr["Nop_Mi_Name"];
                        drNew["Nop_Ma_Code"] = dMaster[2].Row["Nop_Ma_Code"].ToString();
                        drNew["Regular_Type"] = dvSys[0]["DetailCode"];
                        drNew["Nop_type"] = dvSys2[0]["DetailCode"];
                        drNew["Process_Group"] = dvCode[0]["DetailCode"];
                        drNew["Remark"] = dr["Remark"];
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

                result = nopServ.SaveNopCode(dt2, check);

            }
            //저장-편집
            else if (check == 2)
            {
                foreach (DataRow dr in dtDetail.Rows)
                {
                    foreach (DataColumn dc in dtDetail.Columns)
                    {
                        DataView dMaster = new DataView(dtDetail);
                        dMaster.RowFilter = $"Nop_Ma_Code = '{dgvNopDetail[2, dgvNopDetail.CurrentRow.Index].Value.ToString()}'";
                        DataView dvCode = new DataView(dtSysUser);
                        dvCode.RowFilter = $"Code='PROC_GROUP' and DetailName='{dr["Process_Group"]}'";

                        DataView dvSys = new DataView(dtSysCode);
                        dvSys.RowFilter = $"Code='REGULAR_TYPE' and DetailName='{dr["Regular_Type"]}'";
                        DataView dvSys2 = new DataView(dtSysCode);
                        dvSys2.RowFilter = $"Code='NOP_CODE_TYPE' and DetailName='{dr["Nop_type"]}'";
                        string a = dtDetailOrigin.Rows[dtDetail.Rows.IndexOf(dr)][dtDetail.Columns.IndexOf(dc)].ToString();
                        string b = dtDetail.Rows[dtDetail.Rows.IndexOf(dr)][dtDetail.Columns.IndexOf(dc)].ToString();
                        if (b != a)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["Nop_Mi_Code"] = dr["Nop_Mi_Code"];
                            drNew["Nop_Mi_Name"] = dr["Nop_Mi_Name"];
                            drNew["Nop_Ma_Code"] = dMaster[2].Row["Nop_Ma_Code"].ToString();
                            drNew["Regular_Type"] = dvSys[0]["DetailCode"];
                            drNew["Nop_type"] = dvSys2[0]["DetailCode"];
                            drNew["Process_Group"] = dvCode[0]["DetailCode"];
                            drNew["Remark"] = dr["Remark"];
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
                result = nopServ.SaveNopCode(dt2, check);

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
                if (check == 1 && dgvNopMaster.CurrentRow != null && dgvNopMaster.CurrentRow.Index >= rowCount) //추가한 행
                {

                    foreach (Control ctrl in panel4.Controls)
                    {
                        if (ctrl is Label) continue;

                        else if (ctrl is TextBox txt)
                        {
                            if (ctrl.Name.Equals("txtNopMaCode")) continue;
                            if (ctrl.Name.Equals("txtNopMaName")) continue;
                            txt.ReadOnly = false;
                        }   
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = true;
                        else if (ctrl is Button btn)
                            btn.Enabled = true;
                    }
                }
                else //기존 행
                {
                    foreach (Control ctrl in panel4.Controls)
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
                foreach (Control ctrl in panel4.Controls)
                {
                    if (ctrl is Label) continue;
                    else if (ctrl is TextBox txt)
                    {
                        if (ctrl.Name.Equals("txtNopMaCode")) continue;
                        if (ctrl.Name.Equals("txtNopMaName")) continue;
                        if (ctrl.Name.Equals("txtNopMiCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvNopDetail.CurrentRow != null && dgvNopDetail.CurrentRow.Index >= detailCount) //추가한 행
                {

                    foreach (Control ctrl in panel4.Controls)
                    {
                        if (ctrl is Label) continue;

                        else if (ctrl is TextBox txt)
                        {
                            if (ctrl.Name.Equals("txtNopMaCode")) continue;
                            if (ctrl.Name.Equals("txtNopMaName")) continue;
                            txt.ReadOnly = false;
                        }
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = true;
                        else if (ctrl is Button btn)
                            btn.Enabled = true;
                    }
                }
                else //기존 행
                {
                    foreach (Control ctrl in panel4.Controls)
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

        private void dgvNopMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string code = Convert.ToString(dgvNopMaster.Rows[e.RowIndex].Cells[0].Value);
            dtDetail = nopServ.GetNopDetail(code);
            dgvNopDetail.DataSource = dtDetail;
            dtDetailOrigin = dtDetail.Copy();
            detailCount = dtDetail.Rows.Count;
            txtNopMaCode.Text = dgvNopMaster["Nop_Ma_Code", dgvNopMaster.CurrentRow.Index].Value.ToString();
            txtNopMaName.Text = dgvNopMaster["Nop_Ma_Name", dgvNopMaster.CurrentRow.Index].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopupNopSearch frm = new PopupNopSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtNopCode.Text = frm.Send.Nop_Ma_Code;
                txtNopName.Text = frm.Send.Nop_Ma_Name;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PopupNopSearch frm = new PopupNopSearch();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                txtNopMaCode.Text = frm.Send.Nop_Ma_Code;
                txtNopMaName.Text = frm.Send.Nop_Ma_Name;
            }
        }

        private void dgvNopDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtNopMiCode.Text = dgvNopDetail["Nop_Mi_Code", dgvNopDetail.CurrentRow.Index].Value.ToString();
            txtNopMiName.Text = dgvNopDetail["Nop_Mi_Name", dgvNopDetail.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvNopDetail["Use_YN", dgvNopDetail.CurrentRow.Index].Value.ToString();
            cboProcess.Text = dgvNopDetail["Process_Group", dgvNopDetail.CurrentRow.Index].Value.ToString();
            txtRemark.Text = dgvNopDetail["Remark", dgvNopDetail.CurrentRow.Index].Value.ToString();
            cboNopType.Text = dgvNopDetail["Nop_type", dgvNopDetail.CurrentRow.Index].Value.ToString();
            cboRegularType.Text = dgvNopDetail["Regular_Type", dgvNopDetail.CurrentRow.Index].Value.ToString();

        }

        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (dgvNopDetail.CurrentCell == null) return;
            if ((check == 1 && dgvNopDetail.CurrentRow.Index >= detailCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvNopDetail[ctrl.Tag.ToString(), dgvNopDetail.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvNopDetail.Rows[dgvNopDetail.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }
    }
}
