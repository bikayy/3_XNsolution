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
    public partial class frmSystemCode : Form
    {
        DataTable dt3;
        DataTable dtDetailOrigin;

        CommonService commServ = new CommonService();
        DataTable dt;
        DataTable dt_DB;
        Main main = null;
        int rowCount;
        DataView searchList;
        int check = 0;
        int detailCount;
        public frmSystemCode()
        {
            InitializeComponent();
        }

        private void pnlSelect_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmSystemCode_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Delete += OnDelete;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            dgvSysMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysMaster);

            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류코드", "Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류명", "Name", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류명", "CodeNum", colWidth: 200, visibility:false);

            dgvSysDetail.Columns.Clear();
            DataGridViewUtil.SetInitGridView(dgvSysDetail);

            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류코드", "DetailCode", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류명", "DetailName", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "정렬순서", "Sort_Index", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "사용유무", "UseYN", colWidth: 100);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN" };

            //cdac = new CommonDAC();
            commServ = new CommonService();

            DataTable dtSysCode = commServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy(), false);
            button4.Visible = false;
            //LoadData();
            commServ = new CommonService();
            dt = commServ.GetSystemCodeMaster();
            dt_DB = dt.Copy();
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dgvSysDetail.CurrentCell == null)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            }

            if (check == 1) //1:추가
            {
                if (dgvSysDetail.CurrentRow.Index >= detailCount)
                {
                    dt.Rows.Remove(dt.Rows[dgvSysDetail.CurrentCell.RowIndex]);
                    dt.AcceptChanges();

                    //if (dataGridView1.RowCount == rowCount)
                    //    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.RowCount-1];
                    dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(dgvSysDetail.CurrentCell.ColumnIndex, dgvSysDetail.CurrentCell.RowIndex));
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtSysMiCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    commServ = new CommonService();
                    bool result = commServ.DeleteDetailCode(txtSysMiCode.Text);
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
            int result2 = 0;

            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("CodeNum", typeof(int)));
            dt2.Columns.Add(new DataColumn("Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("DetailCode", typeof(string)));
            dt2.Columns.Add(new DataColumn("DetailName", typeof(string)));
            dt2.Columns.Add(new DataColumn("Sort_Index", typeof(int)));
            dt2.Columns.Add(new DataColumn("Remark", typeof(string)));
            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));

            commServ = new CommonService();

            //저장-추가
            if (check == 9) //마스터의 저장
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.IndexOf(dr) >= rowCount)
                    {
                        int r = dt.Rows.IndexOf(dr);

                        DataView dv_duple = new DataView(dt_DB);
                        dv_duple.RowFilter = $"Code = '{dgvSysMaster[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"코드는 중복 될 수 없습니다. ({dgvSysMaster[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvSysMaster.CurrentCell = dgvSysMaster[0, r];
                            dgvSysMaster_CellClick(dgvSysMaster, new DataGridViewCellEventArgs(0, r));
                            return;
                        }
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"코드는 중복 될 수 없습니다. ({dgvSysDetail[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvSysDetail.CurrentCell = dgvSysDetail[0, r];
                            dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(0, r));
                            return;
                        }

                        for (int c = 0; c < 2; c++)
                        {
                            if (dgvSysMaster[c, r].Value.ToString().Length < 1)
                            {
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dgvSysMaster.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dgvSysMaster.CurrentCell = dgvSysMaster[c, r];
                                dgvSysMaster_CellClick(dgvSysMaster, new DataGridViewCellEventArgs(c, r));
                                return;
                            }

                        }                       

                        DataRow drNew = dt2.NewRow();
                        drNew["CodeNum"] = rowCount + 1;
                        drNew["Code"] = dr["Code"];
                        drNew["Name"] = dr["Name"];

                        dt2.Rows.Add(drNew);
                        // dt2.ImportRow(dr);
                    }

                    dt2.AcceptChanges(); ;
                    result = commServ.SaveMasterCode(dt2, check);
                }
            }
            else if (check == 1) //디테일의 저장
            { 
                foreach (DataRow dr2 in dt3.Rows)
                {
                    if (dt3.Rows.IndexOf(dr2) >= detailCount)
                    {
                        int r = dt3.Rows.IndexOf(dr2);

                        DataView dv_duple = new DataView(dt3);
                        dv_duple.RowFilter = $"DetailCode = '{dgvSysDetail[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"코드는 중복 될 수 없습니다. ({dgvSysDetail[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvSysDetail.CurrentCell = dgvSysDetail[0, r];
                            dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(0, r));
                            return;
                        }
                        for (int c = 0; c < 4; c++)
                        {
                            if (dgvSysDetail[c, r].Value.ToString().Length < 1)
                            {
                                //if (c == 5) continue;
                                string propertyName = dgvSysDetail.Columns[c].DataPropertyName;
                                if (propertyName == "Remark") continue;
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dgvSysDetail.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dgvSysDetail.CurrentCell = dgvSysDetail[c, r];
                                dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(c, r));
                                return;
                            }

                        }

                        DataView dMaster = new DataView(dt_DB);
                        dMaster.RowFilter = $"Code = '{dgvSysMaster[0, dgvSysMaster.CurrentRow.Index].Value.ToString()}'";

                        DataRow drNew2 = dt2.NewRow();
                        drNew2["CodeNum"] = 0;
                        drNew2["Code"] = dMaster[0]["Code"].ToString();
                        drNew2["Name"] = dMaster[0]["Name"].ToString();
                        drNew2["DetailCode"] = dr2["DetailCode"];
                        drNew2["DetailName"] = dr2["DetailName"];
                        drNew2["Sort_Index"] = dr2["Sort_Index"];
                        drNew2["Remark"] = dr2["Remark"];
                        drNew2["Use_YN"] = (dr2["UseYN"].ToString() == "예") ? "Y" : "N";
                        dt2.Rows.Add(drNew2);
                        // dt2.ImportRow(dr);
                    }
                }

                dt2.AcceptChanges(); ;
                result2 = commServ.SaveCode(dt2, check);
            }
            //저장-편집
            else if (check == 2)
            {
                foreach (DataRow dr in dt3.Rows)
                {
                    foreach (DataColumn dc in dt3.Columns)
                    {
                        DataView dMaster = new DataView(dt_DB);
                        dMaster.RowFilter = $"Code = '{dgvSysMaster[0, dgvSysMaster.CurrentRow.Index].Value.ToString()}'";
                        
                        string a = dtDetailOrigin.Rows[dt3.Rows.IndexOf(dr)][dt3.Columns.IndexOf(dc)].ToString();
                        string b = dt3.Rows[dt3.Rows.IndexOf(dr)][dt3.Columns.IndexOf(dc)].ToString();
                        if (b != a)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["CodeNum"] = Convert.ToInt32(dr["CodeNum"]);
                            drNew["Code"] = dMaster[0]["Code"].ToString();
                            drNew["Name"] = dMaster[0]["Name"].ToString();
                            drNew["DetailCode"] = dr["DetailCode"];
                            drNew["DetailName"] = dr["DetailName"];
                            drNew["Sort_Index"] = dr["Sort_Index"];
                            drNew["Remark"] = dr["Remark"];
                            drNew["Use_YN"] = (dr["UseYN"].ToString() == "예") ? "Y" : "N";

                            dt2.Rows.Add(drNew);
                            break;
                            // dt2.ImportRow(dr);
                        }
                    }
                }
                dt2.AcceptChanges();
                result = commServ.SaveCode(dt2, check);

            }

            if (result > 0 || result2 > 0)
            {
                MessageBox.Show("저장 완료");
                ChangeValue_Check(0);
                OnSelect(this, e);

            }
            else if (result < 0 || result2 < 0)
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
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dgvSysDetail.CurrentRow != null)
                dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(0, dgvSysDetail.CurrentRow.Index));
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.AcceptChanges();

            dgvSysMaster.DataSource = dt;
            dgvSysMaster.CurrentCell = dgvSysMaster[0, dgvSysMaster.RowCount - 1];

            ChangeValue_Check(9); //추가
            //dataGridView1.AllowUserToAddRows = true;

            ControlTextReset();
            dgvSysMaster_CellClick(dgvSysMaster, new DataGridViewCellEventArgs(0, dgvSysMaster.RowCount - 1));

            
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
            
            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtSysCode.Text))
            {
                sb.Append(" AND Code LIKE '%" + txtSysCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSysName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Name LIKE '%" + txtSysName.Text + "%'");
            }
            searchList.RowFilter = sb.ToString();
            dgvSysMaster.DataSource = searchList;
            rowCount = searchList.Count;

            button4.Visible = true;
            ControlTextReset();
            dgvSysMaster_CellClick(dgvSysMaster, new DataGridViewCellEventArgs(0, 0));
            dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(0, 0));

        }

        private void ControlTextReset()
        {
            txtSysMiCode.Text =
            txtSysMiName.Text =

            txtSort.Text =
            txtRemark.Text =

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
            else if (check == 9) //Master의 추가
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolUpdate.Enabled = false;

                main.toolCreate.BackColor = Color.Yellow;

            }
            ControlState();
        }

        private void ControlState()
        {
            if (check <= 1 || check == 9) //0:기본, 1:추가
                if (check == 1 && dgvSysMaster.CurrentRow != null && dgvSysMaster.CurrentRow.Index >= rowCount) //추가한 행
                {

                    foreach (Control ctrl in panel4.Controls)
                    {
                        if (ctrl is Label) continue;

                        else if (ctrl is TextBox txt)
                            txt.ReadOnly = false;
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = true;
                        else if (ctrl is Button btn)
                            btn.Enabled = true;                        
                    }
                    txtSysMaCode.ReadOnly = true;
                    txtSysMaName.ReadOnly = true;
                }
                else if (check == 9 && dgvSysMaster.CurrentRow != null && dgvSysMaster.CurrentRow.Index >= rowCount) //추가한 행
                {
                    txtSysMaCode.ReadOnly = false;
                    txtSysMaName.ReadOnly = false;
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
                        if (ctrl.Name.Equals("txtSysMaCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvSysDetail.CurrentRow != null && dgvSysDetail.CurrentRow.Index >= detailCount) //추가한 행
                {

                    foreach (Control ctrl in panel4.Controls)
                    {
                        if (ctrl is Label) continue;

                        else if (ctrl is TextBox txt)
                            txt.ReadOnly = false;
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = true;
                        else if (ctrl is Button btn)
                            btn.Enabled = true;
                    }
                    txtSysMaCode.ReadOnly = true;
                    txtSysMaName.ReadOnly = true;
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
        private void LoadData()
        {
            dgvSysMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysMaster);

            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류코드", "Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류명", "Name", colWidth: 200);
            dt3 = commServ.GetSystemCodeMaster();
            dgvSysMaster.DataSource = dt3;
            dgvSysDetail.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysDetail);

            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류코드", "DetailCode", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류명", "DetailName", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "사용여부", "UseYN", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "사용여부", "CodeNum", colWidth: 100, visibility:false);
        }

        private void dgvSysMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = Convert.ToString(dgvSysMaster.Rows[e.RowIndex].Cells[1].Value);
            dt3 = commServ.GetSystemCodeDetail(name);
            dtDetailOrigin = dt3.Copy();
            dgvSysDetail.DataSource = dt3;
            detailCount = dt3.Rows.Count;

            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtSysMaCode.Text = dgvSysMaster["Code", dgvSysMaster.CurrentRow.Index].Value.ToString();
            txtSysMaName.Text = dgvSysMaster["Name", dgvSysMaster.CurrentRow.Index].Value.ToString();
        }


        private void dgvSysDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //string name = Convert.ToString(dgvSysMaster.Rows[e.RowIndex].Cells[1].Value);
            //dt2 = commServ.GetSystemCodeDetail(name);
            //dgvSysDetail.DataSource = dt2;

            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtSysMiCode.Text = dgvSysDetail["DetailCode", dgvSysDetail.CurrentRow.Index].Value.ToString();
            txtSysMiName.Text = dgvSysDetail["DetailName", dgvSysDetail.CurrentRow.Index].Value.ToString();

            txtSort.Text = dgvSysDetail["Sort_Index", dgvSysDetail.CurrentRow.Index].Value.ToString();
            txtRemark.Text = dgvSysDetail["Remark", dgvSysDetail.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvSysDetail["UseYN", dgvSysDetail.CurrentRow.Index].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
           
            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr2 = dt3.NewRow();
            dt3.Rows.Add(dr2);
            dt3.AcceptChanges();

            dgvSysDetail.DataSource = dt3;
            dgvSysDetail.CurrentCell = dgvSysDetail[0, dgvSysDetail.RowCount - 1];

            //dgvSysDetail.Enabled = false;
            //ControlTextReset();
            ControlTextReset();
            ChangeValue_Check(1); //추가
            //dgvSysDetail_CellClick(dgvSysDetail, new DataGridViewCellEventArgs(0, dgvSysDetail.RowCount - 1));
        }

        private void dgvSysDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0) return;

            //if (check == 1) ControlState();

            //txtSysMiCode.Text = dgvSysDetail["DetailCode", dgvSysDetail.CurrentRow.Index].Value.ToString();
            //txtSysMiName.Text = dgvSysDetail["DetailName", dgvSysDetail.CurrentRow.Index].Value.ToString();

            //txtSort.Text = dgvSysDetail["Sort_Index", dgvSysDetail.CurrentRow.Index].Value.ToString();
            //txtRemark.Text = dgvSysDetail["Remark", dgvSysDetail.CurrentRow.Index].Value.ToString();
            //cboUseYN.Text = dgvSysDetail["UseYN", dgvSysDetail.CurrentRow.Index].Value.ToString();
        }

        private void txtMaBox_TextChanged(object sender, EventArgs e)
        {
            if (dgvSysMaster.CurrentCell == null) return;
            if (((check == 1 || check == 9) && dgvSysMaster.CurrentRow.Index >= rowCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvSysMaster[ctrl.Tag.ToString(), dgvSysMaster.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvSysMaster.Rows[dgvSysMaster.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }

        private void txtMiBox_TextChanged(object sender, EventArgs e)
        {
            if (dgvSysDetail.CurrentCell == null) return;
            if ((check == 1 && dgvSysDetail.CurrentRow.Index >= detailCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvSysDetail[ctrl.Tag.ToString(), dgvSysDetail.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvSysDetail.Rows[dgvSysDetail.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }
    }
}
