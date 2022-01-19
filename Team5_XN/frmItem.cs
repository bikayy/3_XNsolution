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
    public partial class frmItem : Form
    {
        ItemService iserv;
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

        public frmItem()
        {
            InitializeComponent();
        }

        private void frmItem_Load(object sender, EventArgs e)
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

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "품목코드",   "Item_Code", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "품목명",     "Item_Name", colWidth: 250, align: DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "품목영문명", "Item_Name_Eng", colWidth: 150);
            
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "품목유형",   "Item_Type", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "규격",       "Item_Unit", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "사용유무",   "Use_YN", colWidth: 80);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "시간당생산량","PrdQty_Per_Hour", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "캐비티",     "Cavity_qty", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비고",       "Remark", colWidth: 150);

            //dataGridView1.Columns["PrdQty_Per_Hour"].ValueType = typeof(string);
            //dataGridView1.Columns["Cavity_qty"].ValueType = typeof(string);

            //dataGridView1.Columns[0].CellType = 
            string[] code = { "USE_YN", "ITEM_TYPE" };

            //cdac = new CommonDAC();
            cserv = new CommonService();

            DataTable dtSysCode = cserv.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboSelectUse_YN, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboSelectItemType, "ITEM_TYPE", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboItemType, "ITEM_TYPE", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboUse_YN, "USE_YN", dtSysCode.Copy(), false);


            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
        }

        private void OnReset(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
            txtSelectItemCode.Text = txtSelectItemName.Text =  "";
            cboSelectUse_YN.SelectedIndex = cboSelectItemType.SelectedIndex = 0;
            dataGridView1.CurrentCell = null;
            ControlTextReset();
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

            iserv = new ItemService();
            dt = iserv.GetItem();
            dt_DB = dt.Copy();
            //dataGridView1.DataSource = dt;

            dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtSelectItemCode.Text))
            {
                sb.Append(" AND Item_Code LIKE '%" + txtSelectItemCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectItemName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Item_Name LIKE '%" + txtSelectItemName.Text + "%'");
            }
            if (!cboSelectItemType.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Item_Type = '" + cboSelectItemType.Text + "'");
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
        private void OnCreate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(1); //추가
            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = dt.NewRow();

            dt.Rows.Add(dr);

            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
            dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, dataGridView1.RowCount - 1));

            
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(2); //편집
            if (dataGridView1.CurrentRow != null)
                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, dataGridView1.CurrentRow.Index));
        }


        private void OnSave(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            int result = 0;

            //dataGridView1_CellValueChanged(dataGridView1, new DataGridViewCellEventArgs(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentRow.Index));

            DataTable dt2 = new DataTable();
            dt2.Columns.Add(new DataColumn("Item_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Item_Name", typeof(string)));
            dt2.Columns.Add(new DataColumn("Item_Name_Eng", typeof(string)));
            dt2.Columns.Add(new DataColumn("Item_Type", typeof(string)));
            dt2.Columns.Add(new DataColumn("Item_Unit", typeof(string)));
            dt2.Columns.Add(new DataColumn("Remark", typeof(string)));

            dt2.Columns.Add(new DataColumn("Use_YN", typeof(char)));
            dt2.Columns.Add(new DataColumn("PrdQty_Per_Hour", typeof(decimal)));
            dt2.Columns.Add(new DataColumn("Cavity_qty", typeof(int)));

            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            iserv = new ItemService();

            //저장-추가
            if (check == 1)
            {

                foreach (DataRow dr in dt.Rows)
                {
                    if (dt.Rows.IndexOf(dr) >= rowCount)
                    {
                        int r = dt.Rows.IndexOf(dr);

                        DataView dv_duple = new DataView(dt_DB);
                        dv_duple.RowFilter = $"Item_Code = '{dataGridView1[0, r].Value.ToString()}'";
                        if (dv_duple.Count > 0)
                        {
                            MessageBox.Show($"품목코드 값은 중복될 수 없습니다. ({dataGridView1[0, r].Value.ToString()}) \n → {r + 1}행, 1열");
                            dataGridView1.CurrentCell = dataGridView1[0, r];
                            dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, r));
                            return;
                        }


                        for (int c = 0; c < 9; c++)
                        {
                            if (dataGridView1[c, r].Value.ToString().Length < 1)
                            {
                                string propertyName = dataGridView1.Columns[c].DataPropertyName;
                                if (propertyName == "Remark" || propertyName == "Item_Name_Eng" || propertyName == "Item_Unit" || propertyName == "PrdQty_Per_Hour" || propertyName == "Cavity_qty") continue;
                                MessageBox.Show($"입력하지 않은 항목이 있습니다. ({dataGridView1.Columns[c].HeaderText}) \n → {r + 1}행, {c + 1}열");
                                dataGridView1.CurrentCell = dataGridView1[c, r];
                                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(c, r));
                                return;
                            }
                        }

                        DataRow drNew = dt2.NewRow();
                        drNew["Item_Code"] = dr["Item_Code"];
                        drNew["Item_Name"] = dr["Item_Name"];
                        drNew["Item_Name_Eng"] = dr["Item_Name_Eng"];
                        drNew["Item_Type"] = dr["Item_Type"];
                        drNew["Item_Unit"] = dr["Item_Unit"];
                        drNew["Remark"] = dr["Remark"];

                        drNew["Use_YN"] = (dr["use_YN"].ToString() == "예") ? "Y" : "N";

                        //if (dr["PrdQty_Per_Hour"].ToString().Length > 0)
                            drNew["PrdQty_Per_Hour"] = dr["PrdQty_Per_Hour"];
                        //else
                            //drNew["PrdQty_Per_Hour"] = DBNull.Value;

                        //if (dr["Cavity_qty"].ToString().Length > 0)
                            drNew["Cavity_qty"] = dr["Cavity_qty"];
                        //else
                            //drNew["Cavity_qty"] = DBNull.Value;

                        drNew["Ins_Date"] = dr["Ins_Date"];
                        drNew["Ins_Emp"] = dr["Ins_Emp"];
                        drNew["Up_Date"] = dr["Up_Date"];
                        drNew["Up_Emp"] = dr["Up_Emp"];

                        dt2.Rows.Add(drNew);
                    }
                }
                dt2.AcceptChanges();

                result = iserv.SaveItem(dt2, check);

            }
            //저장-편집
            else if (check == 2)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {

                        string dataDB = dt_DB.Rows[dt.Rows.IndexOf(dr)][dt.Columns.IndexOf(dc)].ToString();
                        string dataNow = dr[dc].ToString();
                        if (dataNow != dataDB)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["Item_Code"] = dr["Item_Code"];
                            drNew["Item_Name"] = dr["Item_Name"];
                            drNew["Item_Name_Eng"] = dr["Item_Name_Eng"];
                            drNew["Item_Type"] = dr["Item_Type"];
                            drNew["Item_Unit"] = dr["Item_Unit"];
                            drNew["Remark"] = dr["Remark"];

                            drNew["Use_YN"] = (dr["use_YN"].ToString() == "예") ? "Y" : "N";
                            drNew["PrdQty_Per_Hour"] = dr["PrdQty_Per_Hour"];
                            drNew["Cavity_qty"] = dr["Cavity_qty"];


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

                result = iserv.SaveItem(dt2, check);

            }

            if (result > 0)
            {
                MessageBox.Show("저장 완료");
                dt.AcceptChanges();
                if (check == 1)
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
                if (MessageBox.Show($"[{txtItemCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    iserv = new ItemService();
                    bool result = iserv.DeleteItem(txtItemCode.Text);
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
                dt = dt_DB.Copy();
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


        // 하단 입력정보에 값 입력시, 상단 dgv에도 값이 입력됨
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            
            if (dataGridView1.CurrentCell == null) return;
            if ((check == 1 && dataGridView1.CurrentRow.Index >= rowCount) || check == 2)
            {
                //txtCavity txtPrdQty_Hour


                //if (dt == null) return;
                Control ctrl = ((Control)sender);

                if (ctrl.Name == "txtPrdQty_Hour" && ctrl.Text != "" && !decimal.TryParse(ctrl.Text, out decimal num2))
                {
                    MessageBox.Show("[시간당 생산량] 항목은 실수만 입력 가능합니다.");
                    txtPrdQty_Hour.Text = "";
                }

                if (ctrl.Name == "txtCavity" && ctrl.Text != "" && !int.TryParse(ctrl.Text, out int num1))
                {
                    MessageBox.Show("[캐비티] 항목은 양수만 입력 가능합니다.");
                    txtCavity.Text = "";
                }


                if (ctrl.Text.Length > 0) 
                { 
                    dataGridView1[ctrl.Tag.ToString(), dataGridView1.CurrentCell.RowIndex].Value = ctrl.Text;
                }
                else
                    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[ctrl.Tag.ToString()].Value = DBNull.Value;
            }
           
        }

        //셀 클릭시 입력정보 출력
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;


            if (check == 1) ControlState();

            //dataGridView1.ReadOnly = true;
            //DataView dv1 = new DataView(dt);
            //dv1.RowFilter = "Parent_Screen_Code is null or Parent_Screen_Code = ''";

            //txtProcessCode.Text = dv1[e.RowIndex]["Process_Code"].ToString();

            //txtPrdQty_Hour.Text = "";
            //txtCavity.Text = "";

            txtItemCode.Text = dataGridView1["Item_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            txtItemName.Text = dataGridView1["Item_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            txtItemNameEng.Text = dataGridView1["Item_Name_Eng", dataGridView1.CurrentRow.Index].Value.ToString();
            
            cboItemType.Text = dataGridView1["Item_Type", dataGridView1.CurrentRow.Index].Value.ToString();
            txtItemUnit.Text = dataGridView1["Item_Unit", dataGridView1.CurrentRow.Index].Value.ToString();
            cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();

            //txtPrdQty_Hour.Clear();
            //if (dataGridView1["PrdQty_Per_Hour", dataGridView1.CurrentRow.Index].Value != DBNull.Value)
            txtPrdQty_Hour.Text = dataGridView1["PrdQty_Per_Hour", dataGridView1.CurrentRow.Index].Value.ToString();

            //if (dataGridView1["Cavity_qty", dataGridView1.CurrentRow.Index].Value != DBNull.Value)
            txtCavity.Text = dataGridView1["Cavity_qty", dataGridView1.CurrentRow.Index].Value.ToString();

            txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
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
                        if (ctrl.Name.Equals("txtItemCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
        }


        private void ControlTextReset()
        {
            txtItemCode.Text =
            txtItemName.Text =
            txtItemNameEng.Text =           
            txtItemUnit.Text =
            txtPrdQty_Hour.Text =
            txtCavity.Text = 
            txtRemark.Text = "";

            cboItemType.SelectedIndex =
            cboUse_YN.SelectedIndex = 0;

            //dataGridView1.CurrentCell = null;
        }

        private void txtPrdQty_Hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.') // '\b'               
                e.Handled = true;
            
        }

        private void txtCavity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8) // '\b'               
                e.Handled = true;
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (check == 1) ControlState();


            //txtItemCode.Text = dataGridView1["Item_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtItemName.Text = dataGridView1["Item_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtItemNameEng.Text = dataGridView1["Item_Name_Eng", dataGridView1.CurrentRow.Index].Value.ToString();

            //cboItemType.Text = dataGridView1["Item_Type", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtItemUnit.Text = dataGridView1["Item_Unit", dataGridView1.CurrentRow.Index].Value.ToString();
            //cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();


            //txtPrdQty_Hour.Text = dataGridView1["PrdQty_Per_Hour", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtCavity.Text = dataGridView1["Cavity_qty", dataGridView1.CurrentRow.Index].Value.ToString();
            //txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow == null) return;

            if (check == 1) ControlState();

            txtItemCode.Text = dataGridView1["Item_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            txtItemName.Text = dataGridView1["Item_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            txtItemNameEng.Text = dataGridView1["Item_Name_Eng", dataGridView1.CurrentRow.Index].Value.ToString();

            cboItemType.Text = dataGridView1["Item_Type", dataGridView1.CurrentRow.Index].Value.ToString();
            txtItemUnit.Text = dataGridView1["Item_Unit", dataGridView1.CurrentRow.Index].Value.ToString();
            cboUse_YN.Text = dataGridView1["Use_YN", dataGridView1.CurrentRow.Index].Value.ToString();

            //txtPrdQty_Hour.Clear();
            //if (dataGridView1["PrdQty_Per_Hour", dataGridView1.CurrentRow.Index].Value != DBNull.Value)
            txtPrdQty_Hour.Text = dataGridView1["PrdQty_Per_Hour", dataGridView1.CurrentRow.Index].Value.ToString();

            //if (dataGridView1["Cavity_qty", dataGridView1.CurrentRow.Index].Value != DBNull.Value)
            txtCavity.Text = dataGridView1["Cavity_qty", dataGridView1.CurrentRow.Index].Value.ToString();

            txtRemark.Text = dataGridView1["Remark", dataGridView1.CurrentRow.Index].Value.ToString();
        }


        //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    dataGridView1.Columns["PrdQty_Per_Hour"].ValueType = typeof(decimal);
        //    dataGridView1.Columns["Cavity_qty"].ValueType = typeof(int);

        //}
    }
}
