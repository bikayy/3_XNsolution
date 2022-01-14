using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_XN
{
    public partial class frmProcess : Form
    {
        ProcessService pserv;
        CommonService cserv;

        DataTable dt;
        DataTable dt_DB;
        DataView dv_SerchList; //선택한 조회조건별 검색 리스트

        int rowCount; //DB에 저장된 ROW COUNT
        Main main = null;


        /// <summary>
        /// 0:기본, 1:추가, 2:편집, 3:삭제
        /// </summary>
        int check = 0; //추가,편집 구분을 위한 숫자 -- 1:추가, 2:편집, 3:삭제, 


        public frmProcess()
        {
            InitializeComponent();
        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Delete += OnDelete;
            main.Cancle += OnCancle;
            main.Reset += OnReset;


            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정코드", "Process_Code", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정명", "Process_Name", colWidth: 250, align: DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정그룹", "Process_Group", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "사용유무", "Use_YN", colWidth: 80);
            //dataGridView1.ReadOnly = false;

            //GetCommonCodeList
            string[] code = { "USE_YN", "PROC_GROUP" };

            //cdac = new CommonDAC();
            cserv = new CommonService();

            DataTable dtSysCode = cserv.GetCommonCodeSys(code); 
            CommonUtil.ComboBinding(cboUse_YN, "USE_YN", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboSelectUse_YN, "USE_YN", dtSysCode.Copy());

            DataTable dtUserCode = cserv.GetCommonCodeUser(code);
            CommonUtil.ComboBinding(cboProcessGroup, "PROC_GROUP", dtUserCode.Copy(), false);


            //string[] data = { "전체", "Y", "N" };
            //cboSelectUse_YN.Items.AddRange(data);
            //cboSelectUse_YN.SelectedIndex = 0;

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled =  main.toolSave.Enabled = main.toolCancle.Enabled = false;

        }

        private void OnReset(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
            txtSelectProcessCode.Text = txtSelectProcessName.Text = "";
            cboSelectUse_YN.SelectedIndex = 0;
            ControlTextReset();
        }

        //조회 이벤트
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

            //pdac = new ProcessDAC();
            pserv = new ProcessService();
            dt = pserv.GetProcess();
            dt_DB = dt.Copy();
            //dataGridView1.DataSource = dt;

            dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtSelectProcessCode.Text))
            {
                sb.Append(" AND Process_Code LIKE '%" + txtSelectProcessCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectProcessName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Process_Name LIKE '%" + txtSelectProcessName.Text + "%'");
            }
            if (!cboSelectUse_YN.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Use_YN = '" + cboSelectUse_YN.Text + "'");
            }

            dv_SerchList.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv_SerchList.ToTable();
            rowCount = dv_SerchList.Count;
            ControlTextReset();

            if (dataGridView1.Rows.Count > 0)
                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, 0));

        }

        //추가 이벤트
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
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
            dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, dataGridView1.RowCount - 1));
        }

        //편집 이벤트
        private void OnUpdate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dataGridView1.CurrentRow != null)
                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, dataGridView1.CurrentRow.Index));
        }

        //저장 이벤트
        private void OnSave(object sender, EventArgs e) 
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;

            //dataGridView1_CellValueChanged(dataGridView1, new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index));

            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("Process_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Process_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("Process_Group", typeof(string)));
            dt2.Columns.Add(new DataColumn("Remark", typeof(string)));
            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            pserv = new ProcessService();

            //저장-추가
            if (check == 1)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.IndexOf(dr) >= rowCount)
                    {
                        int r = dt.Rows.IndexOf(dr);

                        DataView dv_duple = new DataView(dt_DB);
                        dv_duple.RowFilter = $"Process_Code = '{dataGridView1[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0) 
                        { 
                            MessageBox.Show($"공정코드 값은 중복될 수 없습니다. ({dataGridView1[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dataGridView1.CurrentCell = dataGridView1[0, r];
                            dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, r));
                            return;
                        }


                        for (int c=0; c<5; c++)
                        {                           
                            if (dataGridView1[c,r].Value.ToString().Length < 1)
                            {
                                if (c == 3) continue;
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dataGridView1.Columns[c].HeaderText}) \n → {r+1}행, {c+1}열");
                                dataGridView1.CurrentCell = dataGridView1[c, r];
                                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(c, r));
                                return;
                            }
                        }

                        DataRow drNew = dt2.NewRow();
                        drNew["Process_Code"] = dr["Process_Code"];
                        drNew["Process_Name"] = dr["Process_Name"];
                        drNew["Process_Group"] = dr["Process_Group"];
                        drNew["Remark"] = dr["Remark"];
                        drNew["Use_YN"] = (dr["use_YN"].ToString() == "예") ? "Y" : "N";
                        drNew["Ins_Date"] = dr["Ins_Date"];
                        drNew["Ins_Emp"] = dr["Ins_Emp"];
                        drNew["Up_Date"] = dr["Up_Date"];
                        drNew["Up_Emp"] = dr["Up_Emp"];

                        dt2.Rows.Add(drNew);
                        // dt2.ImportRow(dr);
                    }
                }
                dt2.AcceptChanges();

                result = pserv.SaveProcess(dt2, check);
                //dt.AcceptChanges();

            }
            //저장-편집
            else if (check==2)
            {
                dt = (DataTable)dataGridView1.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {

                        string a = dt_DB.Rows[dt.Rows.IndexOf(dr)][dt.Columns.IndexOf(dc)].ToString();
                        string b = dr[dc].ToString();
                        if (b != a)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["Process_Code"] = dr["Process_Code"];
                            drNew["Process_Name"] = dr["Process_Name"];
                            drNew["Process_Group"] = dr["Process_Group"];
                            drNew["Remark"] = dr["Remark"];
                            drNew["Use_YN"] = (dr["use_YN"].ToString() == "예") ? "Y" : "N";
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
                result = pserv.SaveProcess(dt2, check);
                //dt.AcceptChanges();
            }

            if (result > 0)
            {
                MessageBox.Show("저장 완료");
                dt.AcceptChanges();
                if (check==1)
                    rowCount += result;

                ChangeValue_Check(0);
                dt_DB = dt.Copy();
                //OnSelect(this, e);

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

        //삭제 이벤트
        private void OnDelete(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("삭제할 행을 선택하세요.");
                return;
            } 

            if (check == 1) //1:추가
            {
                if (dataGridView1.CurrentCell.RowIndex >= rowCount)
                {
                    dt.Rows.Remove(dt.Rows[dataGridView1.CurrentCell.RowIndex]);
                    dt.AcceptChanges();
                    dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex));
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtProcessCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes) { 
                    
                    pserv = new ProcessService();
                    bool result = pserv.DeleteProcess(txtProcessCode.Text);
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

        //취소 이벤트
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
                dt= dt_DB.Copy();
                dataGridView1.DataSource = dt;
                //OnSelect(this, e);
                //this.DialogResult = DialogResult.Yes;
            }
            else
            {
                this.DialogResult = DialogResult.No;
            }
        }


        /// <summary>
        /// check의 value를 변경 (1:기본, 1:추가, 2:편집, 3:삭제)
        /// </summary>
        /// <param name="check"></param>
        private void ChangeValue_Check(int check)
        {
            this.check = check;

            //기본
            if (check == 0)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = true;
                main.toolSave.Enabled = main.toolCancle.Enabled = false;
                main.toolCreate.BackColor = main.toolUpdate.BackColor = Color.DarkGray;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
                }
            }
            //추가
            else if (check == 1)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = true;
                main.toolUpdate.Enabled = false;
                main.toolCreate.BackColor = Color.Yellow;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
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



        //셀 클릭시 입력정보 출력
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            if (check == 1) ControlState();

            //if (check <= 1) //0:기본, 1:추가
            //    if (e.RowIndex >= rowCount) //추가한 행
            //    {
            //        foreach (Control ctrl in pnlDetail.Controls)
            //        {
            //            if (ctrl is TextBox txt)
            //                txt.ReadOnly = false;
            //            else if (ctrl is ComboBox cbo)
            //                cbo.Enabled = true;
            //        }
            //    }
            //    else //기존 행
            //    {
            //        foreach (Control ctrl in pnlDetail.Controls)
            //        {
            //            if (ctrl is TextBox txt)
            //                txt.ReadOnly = true;
            //            else if (ctrl is ComboBox cbo)
            //                cbo.Enabled = false;
            //        }
            //    }
            //else if (check == 2) //2:편집
            //{
            //    foreach (Control ctrl in pnlDetail.Controls)
            //    {
            //        if (ctrl.Name == "txtProcessCode") continue;
            //        else if (ctrl is TextBox txt)
            //            txt.ReadOnly = false;
            //        else if (ctrl is ComboBox cbo)
            //            cbo.Enabled = true;
            //    }
            //}

            //dataGridView1.ReadOnly = true;
            //DataView dv1 = new DataView(dt);
            //dv1.RowFilter = "Parent_Screen_Code is null or Parent_Screen_Code = ''";

            //txtProcessCode.Text = dv1[e.RowIndex]["Process_Code"].ToString();
            txtProcessCode.Text = dataGridView1["Process_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            txtProcessName.Text = dataGridView1["Process_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            //dv_SerchList[e.RowIndex]["Process_Name"].ToString();
            cboProcessGroup.Text = dataGridView1["Process_Group", dataGridView1.CurrentRow.Index].Value.ToString();
            //= dv_SerchList[e.RowIndex]["Process_Group"].ToString();
            txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
            //= dv_SerchList[e.RowIndex]["Remark"].ToString();
            cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();
            //= dv_SerchList[e.RowIndex]["Use_YN"].ToString();
        }

        private void ControlState()
        {
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= rowCount) //추가한 행
                {

                    foreach (Control ctrl in pnlDetail.Controls)
                    {
                        if (ctrl is Label) continue;

                        else if (ctrl is TextBox txt)
                            txt.ReadOnly = false;
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = true;
                    }
                }
                else //기존 행
                {
                    foreach (Control ctrl in pnlDetail.Controls)
                    {
                        if (ctrl is Label) continue;
                        else if(ctrl is TextBox txt)
                            txt.ReadOnly = true;
                        else if (ctrl is ComboBox cbo)
                            cbo.Enabled = false;
                    }
                }
            else if (check == 2) //2:편집
            {
                
                foreach (Control ctrl in pnlDetail.Controls)
                {
                    if (ctrl is Label) continue;
                    else if(ctrl is TextBox txt)
                    {
                        if (ctrl.Name.Equals("txtProcessCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                }
            }
        }

        private void ControlTextReset()
        {
            txtProcessCode.Text =
            txtProcessName.Text =
            txtRemark.Text = "";
            cboProcessGroup.SelectedIndex =
            cboUse_YN.SelectedIndex = 0; 
        }

       

        // 하단 입력정보에 값 입력시, 상단 dgv에도 값이 입력됨
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            if ((check == 1 && dataGridView1.CurrentRow.Index >= rowCount) || check == 2)
            {
                //if (dt == null) return;
                Control ctrl = ((Control)sender);
                dataGridView1[ctrl.Tag.ToString(), dataGridView1.CurrentCell.RowIndex].Value = ctrl.Text;
                //dt.Rows[dataGridView1.CurrentCell.RowIndex][ctrl.TabIndex] = ctrl.Text;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.CurrentRow == null) return;
            //if (check == 1) ControlState();
            //txtProcessCode.Text = dataGridView1["Process_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtProcessName.Text = dataGridView1["Process_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            ////dv_SerchList[e.RowIndex]["Process_Name"].ToString();
            //cboProcessGroup.Text = dataGridView1["Process_Group", dataGridView1.CurrentRow.Index].Value.ToString();
            ////= dv_SerchList[e.RowIndex]["Process_Group"].ToString();
            //txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
            ////= dv_SerchList[e.RowIndex]["Remark"].ToString();
            //cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

            //if (check == 1) ControlState();
            //txtProcessCode.Text = dataGridView1["Process_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtProcessName.Text = dataGridView1["Process_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            ////dv_SerchList[e.RowIndex]["Process_Name"].ToString();
            //cboProcessGroup.Text = dataGridView1["Process_Group", dataGridView1.CurrentRow.Index].Value.ToString();
            ////= dv_SerchList[e.RowIndex]["Process_Group"].ToString();
            //txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
            ////= dv_SerchList[e.RowIndex]["Remark"].ToString();
            //cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //if (e.RowIndex < 0) return;
            if (dataGridView1.CurrentRow == null) return;

            if (check == 1) ControlState();
            txtProcessCode.Text = dataGridView1["Process_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            txtProcessName.Text = dataGridView1["Process_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            //dv_SerchList[e.RowIndex]["Process_Name"].ToString();
            cboProcessGroup.Text = dataGridView1["Process_Group", dataGridView1.CurrentRow.Index].Value.ToString();
            //= dv_SerchList[e.RowIndex]["Process_Group"].ToString();
            txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
            //= dv_SerchList[e.RowIndex]["Remark"].ToString();
            cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        /************************************************************************************************************/
        /************************************************************************************************************/


        ////셀편집기능
        //private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{

        //    DataGridView dgv = (DataGridView)sender;
        //    //기본, 추가
        //    if (check <= 1)
        //    {
        //        if (e.RowIndex < rowCount)
        //            e.Cancel = true;
        //    }
        //    //편집
        //    else if (check == 2)
        //    {
        //        if (e.ColumnIndex == 0)
        //            e.Cancel = true;
        //    }
        //}

        ////상단 dgv에 값 입력시, 하단 입력정보에도 값이 입력됨
        //private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (check < 1) return;
        //    DataGridView col = ((DataGridView)sender);
        //    foreach (Control ctrl in pnlDetail.Controls)
        //    {
        //        if (ctrl.Tag == col.Columns[e.ColumnIndex].DataPropertyName)
        //        {
        //            ctrl.Text = col[e.ColumnIndex, e.RowIndex].Value.ToString();
        //            return;
        //        }

        //    }
        //}

        //private void dataGridView1_Leave(object sender, EventArgs e)
        //{

        //}

        //private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    dataGridView1_CellValueChanged(dataGridView1, new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex));
        //}

        //private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    string a = e.KeyChar.ToString();
        //    int b = a.Length;
        //    if (e.KeyChar.ToString().Length > 1 ) return;
        //    txtProcessName.Text = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString() + e.KeyChar;
        //    //dataGridView1_CellValueChanged(dataGridView1, new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex));
        //}

        //private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    dataGridView1.EditingControl.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        //    //dataGridView1.EditingControl.KeyUp += new KeyEventHandler(dataGridView1_KeyDown);
        //}

        //private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    txtProcessName.Text = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value.ToString();
        //}

    }
}
