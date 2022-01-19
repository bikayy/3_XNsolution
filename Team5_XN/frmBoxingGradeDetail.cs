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
    public partial class frmBoxingGradeDetail : Form
    {
        DataTable list;
        CommonService commServ = new CommonService();
        BoxingGradeService boxServ = new BoxingGradeService();
        DataTable dt;
        DataTable dt2;
        DataTable dt_DB;
        DataTable dtDetailOrigin;
        Main main = null;
        int rowCount;
        int detailCount;
        DataView searchList;
        int check = 0;

        public frmBoxingGradeDetail()
        {
            InitializeComponent();
        }

        private void frmBoxingGradeDetail_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Delete += OnDelete;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            dgvBoxMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvBoxMaster);

            DataGridViewUtil.AddGridTextColumn(dgvBoxMaster, "포장등급 코드", "Boxing_Grade_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvBoxMaster, "포장등급 명", "Boxing_Grade_Name", colWidth: 200);
            //dt = boxServ.GetBoxingGradeMaster();
            //dt_DB = dt.Copy();
            //dgvBoxMaster.DataSource = dt;

            dgvBoxDetail.Columns.Clear();
            DataGridViewUtil.SetInitGridView(dgvBoxDetail);

            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "포장등급 상세코드", "Grade_Detail_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "포장등급 상세명", "Grade_Detail_Name", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "포장등급 코드", "Boxing_Grade_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "사용유무", "Use_YN", colWidth: 100);

            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "작성일자", "Ins_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "작성자", "Ins_Emp", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "수정일자", "Up_Date", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "수정자", "Up_Emp", colWidth: 100, visibility: false);


            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN" , "Box_Grade"};

            //cdac = new CommonDAC();
            commServ = new CommonService();

            DataTable dtSysCode = commServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy(), false);
            //LoadData();

            commServ = new CommonService();
            dt = boxServ.GetBoxingGradeMaster();
            dt_DB = dt.Copy();
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

            if (!string.IsNullOrWhiteSpace(txtBoxingCode.Text))
            {
                sb.Append(" AND boxing_grade_code LIKE '%" + txtBoxingCode.Text + "%'");
            }
            searchList.RowFilter = sb.ToString();
            dgvBoxMaster.DataSource = searchList;
            rowCount = searchList.Count;

            ControlTextReset();
            dgvBoxMaster_CellClick(dgvBoxMaster, new DataGridViewCellEventArgs(0, 0));
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = list.NewRow();
            dr["Boxing_Grade_Code"] = txtBoxGradeMaCode.Text;
            list.Rows.Add(dr);
            list.AcceptChanges();
            dgvBoxDetail.DataSource = list;
            dgvBoxDetail.CurrentCell = dgvBoxDetail[0, dgvBoxDetail.RowCount - 1];
            //dgvBoxDetail_CellClick(dgvBoxMaster, new DataGridViewCellEventArgs(0, dgvBoxDetail.RowCount - 1));

            ChangeValue_Check(1); //추가
            dgvBoxDetail.Enabled = false;
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dgvBoxDetail.CurrentRow != null)
                dgvBoxDetail_CellClick(dgvBoxDetail, new DataGridViewCellEventArgs(0, dgvBoxDetail.CurrentRow.Index));
        }

        private void OnSave(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;


            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("Grade_Detail_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Grade_Detail_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("Boxing_Grade_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            boxServ = new BoxingGradeService();

            //저장-추가
            if (check == 1)
            {

                foreach (DataRow dr in list.Rows)
                {
                    if (list.Rows.IndexOf(dr) >= detailCount)
                    {
                        int r = list.Rows.IndexOf(dr);

                        DataView dv_duple = new DataView(list);
                        dv_duple.RowFilter = $"Grade_Detail_Code = '{dgvBoxDetail[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"코드는 중복 될 수 없습니다. ({dgvBoxDetail[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dgvBoxDetail.CurrentCell = dgvBoxDetail[0, r];
                            dgvBoxDetail_CellClick(dgvBoxDetail, new DataGridViewCellEventArgs(0, r));
                            return;
                        }

                        for (int c = 0; c < 2; c++)
                        {
                            if (dgvBoxDetail[c, r].Value.ToString().Length < 1)
                            {
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dgvBoxDetail.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dgvBoxDetail.CurrentCell = dgvBoxDetail[c, r];
                                dgvBoxDetail_CellClick(dgvBoxDetail, new DataGridViewCellEventArgs(c, r));
                                return;
                            }
                        }

                        DataView dMaster = new DataView(list);
                        dMaster.RowFilter = $"Boxing_Grade_Code = '{dgvBoxDetail[2, dgvBoxDetail.CurrentRow.Index].Value.ToString()}'";

                        DataRow drNew = dt2.NewRow();
                        drNew["Grade_Detail_Code"] = dr["Grade_Detail_Code"];
                        drNew["Grade_Detail_Name"] = dr["Grade_Detail_Name"];
                        drNew["Boxing_Grade_Code"] = dMaster[2].Row["Boxing_Grade_Code"].ToString();
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

                result = boxServ.SaveBoxing(dt2, check);

            }
            //저장-편집
            else if (check == 2)
            {
                foreach (DataRow dr in list.Rows)
                {
                    foreach (DataColumn dc in list.Columns)
                    {

                        string a = dtDetailOrigin.Rows[list.Rows.IndexOf(dr)][list.Columns.IndexOf(dc)].ToString();
                        string b = list.Rows[list.Rows.IndexOf(dr)][list.Columns.IndexOf(dc)].ToString();
                        if (b != a)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["Grade_Detail_Code"] = dr["Grade_Detail_Code"];
                            drNew["Grade_Detail_Name"] = dr["Grade_Detail_Name"];
                            drNew["Boxing_Grade_Code"] = dr["Boxing_Grade_Code"];
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
                result = boxServ.SaveBoxing(dt2, check);

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
        private void OnDelete(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dgvBoxDetail.CurrentCell == null)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            }

            if (check == 1) //1:추가
            {
                if (dgvBoxDetail.CurrentRow.Index >= detailCount)
                {
                    dt.Rows.Remove(dt.Rows[dgvBoxDetail.CurrentCell.RowIndex]);
                    dt.AcceptChanges();

                    //if (dataGridView1.RowCount == rowCount)
                    //    dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.RowCount-1];
                    dgvBoxDetail_CellClick(dgvBoxDetail, new DataGridViewCellEventArgs(dgvBoxDetail.CurrentCell.ColumnIndex, dgvBoxDetail.CurrentCell.RowIndex));
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtBoxGradeCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    boxServ = new BoxingGradeService();
                    bool result = boxServ.DeleteBoxDetail(txtBoxGradeCode.Text);
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
        private void ControlTextReset()
        {
            txtBoxGradeMaCode.Text =
            txtBoxGradeMaName.Text =

            txtBoxGradeCode.Text =
            txtBoxGradeName.Text =

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
                if (check == 1 && dgvBoxMaster.CurrentRow != null && dgvBoxMaster.CurrentRow.Index >= rowCount) //추가한 행
                {

                    foreach (Control ctrl in panel4.Controls)
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
                        if (ctrl.Name.Equals("txtBoxGradeCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvBoxDetail.CurrentRow != null && dgvBoxDetail.CurrentRow.Index >= detailCount) //추가한 행
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
        private void dgvBoxMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string code = Convert.ToString(dgvBoxMaster.Rows[e.RowIndex].Cells[0].Value);
            list = boxServ.GetBoxingGradeDetail(code);
            dgvBoxDetail.DataSource = list;
            dtDetailOrigin = list.Copy();
            detailCount = list.Rows.Count;

            txtBoxGradeMaCode.Text = dgvBoxMaster["Boxing_Grade_Code", dgvBoxMaster.CurrentRow.Index].Value.ToString();
            txtBoxGradeMaName.Text = dgvBoxMaster["Boxing_Grade_Name", dgvBoxMaster.CurrentRow.Index].Value.ToString();
            dgvBoxDetail_CellClick(sender, e);
        }

        private void dgvBoxDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtBoxGradeCode.Text = dgvBoxDetail["Grade_Detail_Code", dgvBoxDetail.CurrentRow.Index].Value.ToString();
            txtBoxGradeName.Text = dgvBoxDetail["Grade_Detail_Name", dgvBoxDetail.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvBoxDetail["Use_YN", dgvBoxDetail.CurrentRow.Index].Value.ToString();
        }

        private void txtBoxGrade_TextChanged(object sender, EventArgs e)
        {
            if (dgvBoxDetail.CurrentCell == null) return;
            if ((check == 1 && dgvBoxDetail.CurrentRow.Index >= detailCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Text.Length > 0)
                {
                    dgvBoxDetail[ctrl.Tag.ToString(), dgvBoxDetail.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dgvBoxDetail.Rows[dgvBoxDetail.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
        }

        private void dgvBoxDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtBoxGradeCode.Text = dgvBoxDetail["Grade_Detail_Code", dgvBoxDetail.CurrentRow.Index].Value.ToString();
            txtBoxGradeName.Text = dgvBoxDetail["Grade_Detail_Name", dgvBoxDetail.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvBoxDetail["Use_YN", dgvBoxDetail.CurrentRow.Index].Value.ToString();
        }
    }
}
