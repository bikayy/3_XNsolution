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
    public partial class frmNopHistory : Form
    {
        Main main = null;

        NopService nserv;
        CommonService cserv;
        
        DataTable dt;
        DataTable dt_DB;
        DataView dv_SerchList; //선택한 조회조건별 검색 리스트
        DataTable dtMiCode;
        int rowCount; //DB에 저장된 ROW COUNT

        /// <summary>
        /// 0:기본, 1:추가, 2:편집, 3:삭제
        /// </summary>
        int check = 0; //추가,편집 구분을 위한 숫자 -- 1:추가, 2:편집, 3:삭제, 
        bool input = false;
        public frmNopHistory()
        {
            InitializeComponent();
        }

        private void frmNopHistory2_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            //main.Create += OnCreate;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Delete += OnDelete;
            main.Cancle += OnCancle;
            main.Reset += OnReset;

            DataGridViewUtil.SetInitGridView(dataGridView1);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "Seq", "Nop_Seq", colWidth: 100, visibility: false);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장코드", "Wc_Code", colWidth: 100); 
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장명", "Wc_Name", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동시작시간", "Nop_HappenTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동종료시간", "Nop_CancelTime", colWidth: 130);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동시간(분)", "Nop_Time", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동대분류코드", "Nop_Ma_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동대분류명", "Nop_Ma_Name", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동상세분류코드", "Nop_Mi_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비가동상세분류명", "Nop_Mi_Name", colWidth: 150);

            dataGridView1.Columns["Nop_HappenTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
            dataGridView1.Columns["Nop_CancelTime"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

        }
        
        private void OnReset(object sender, EventArgs e)
        {
            if (this.MdiParent == null) return;
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
            dateTimePicker1.Text = dateTimePicker2.Text = "";
            txtSelectWcCode.Text = txtSelectWcName.Text = "";
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

            //wdac = new WorkCenterDAC();
            nserv = new NopService();
            dt = nserv.GetNopHistoryAll(dateTimePicker1.Value, dateTimePicker2.Value.AddDays(1));
            dt_DB = dt.Copy();
            //dataGridView1.DataSource = dt;

            dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtSelectWcCode.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Wc_Code = '" + txtSelectWcCode.Text + "'");
            }

            dv_SerchList.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv_SerchList.ToTable();
            rowCount = dv_SerchList.Count;
            ControlTextReset();

            if (dataGridView1.Rows.Count > 0)
                dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, 0));


        }
        //private void OnCreate(object sender, EventArgs e)
        //{
        //    if (this.MdiParent == null) return;
        //    if (((Main)this.MdiParent).ActiveMdiChild != this) return;

        //    ChangeValue_Check(1); //추가

        //    //dataGridView1.AllowUserToAddRows = true;
        //    DataRow dr = dt.NewRow();
        //    dt.Rows.Add(dr);
        //    dt.AcceptChanges();
        //    dataGridView1.DataSource = dt;
        //    dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
        //    dataGridView1_CellClick(dataGridView1, new DataGridViewCellEventArgs(0, dataGridView1.RowCount - 1));


        //}

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
            dt2.Columns.Add(new DataColumn("Nop_Seq", typeof(int)));
            dt2.Columns.Add(new DataColumn("Nop_HappenTime", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Nop_CancelTime", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Nop_Time", typeof(decimal)));

            dt2.Columns.Add(new DataColumn("Nop_Ma_Code", typeof(string)));
            dt2.Columns.Add(new DataColumn("Nop_Mi_Code", typeof(string)));

            dt2.Columns.Add(new DataColumn("Wc_Code", typeof(string)));

            dt2.Columns.Add(new DataColumn("Ins_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Ins_Emp", typeof(string)));
            dt2.Columns.Add(new DataColumn("Up_Date", typeof(DateTime)));
            dt2.Columns.Add(new DataColumn("Up_Emp", typeof(string)));

            nserv = new NopService();

            
            //저장-편집
            if (check == 2)
            {
                dt = (DataTable)dataGridView1.DataSource;
                foreach (DataRow dr in dt.Rows)
                {
                    int r = dt.Rows.IndexOf(dr);

                    if (dr["Nop_Ma_Code"].ToString() == "")
                    {
                        MessageBox.Show($"비가동대분류 값은 필수 항목입니다. ({dataGridView1[0, r].Value.ToString()}) \n → {r + 1}행, 6열");
                        dataGridView1.CurrentCell = dataGridView1[1, r];
                        dataGridView1_SelectionChanged(dataGridView1, new DataGridViewCellEventArgs(0, r));
                        return;
                    }

                    if (dr["Nop_Mi_Code"].ToString() == "")
                    {
                        MessageBox.Show($"비가동상세분류 값은 필수 항목입니다. ({dataGridView1[0, r].Value.ToString()}) \n → {r + 1}행, 8열");
                        dataGridView1.CurrentCell = dataGridView1[1, r];
                        dataGridView1_SelectionChanged(dataGridView1, new DataGridViewCellEventArgs(0, r));
                        return;
                    }

                    

                    foreach (DataColumn dc in dt.Columns)
                    {
                        
                        string dataDB = dt_DB.Rows[dt.Rows.IndexOf(dr)][dt.Columns.IndexOf(dc)].ToString();
                        string dataNow = dr[dc].ToString();
                        if (dataNow != dataDB)
                        {
                            DataRow drNew = dt2.NewRow();
                            drNew["Nop_Seq"] = dr["Nop_Seq"];
                            drNew["Nop_HappenTime"] = dr["Nop_HappenTime"];
                            drNew["Nop_CancelTime"] = dr["Nop_CancelTime"];
                            drNew["Nop_Time"] = dr["Nop_Time"];

                            drNew["Nop_Ma_Code"] = dr["Nop_Ma_Code"];
                            drNew["Nop_Mi_Code"] = dr["Nop_Mi_Code"];
                            drNew["Wc_Code"] = dr["Wc_Code"];

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
                result = nserv.NopRegistAll_Update(dt2);

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

           
            if (MessageBox.Show($"선택한 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                nserv = new NopService();
                int seq = Convert.ToInt32(dataGridView1["Nop_Seq", dataGridView1.CurrentRow.Index].Value);
                bool result = nserv.NopRegistAll_Delete(seq);
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
                main.toolSelect.Enabled =  main.toolUpdate.Enabled = main.toolDelete.Enabled = true;
                main.toolSave.Enabled = main.toolCreate.Enabled = main.toolCancle.Enabled = false;
                main.toolCreate.BackColor = main.toolUpdate.BackColor = Color.DarkGray;

                foreach (DataGridViewColumn col in dataGridView1.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.Automatic;
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




        private void ControlState()
        {
            if (check == 0)
            { //0:조회

                cboNopMaName.Enabled = false;
                cboNopMiName.Enabled = false;
            }
            else if (check == 2) //2:편집
            {
                cboNopMaName.Enabled = true;
                cboNopMiName.Enabled = true;

                //foreach (Control ctrl in pnlDetail.Controls)
                //{
                //    if (ctrl is Label) continue;
                //    else if (ctrl is TextBox txt)
                //    {
                //        if (ctrl.Name.Contains("txtProcess") || ctrl.Name.Equals("txtWcCode")) continue;
                //        txt.ReadOnly = false;
                //    }
                //    else if (ctrl is ComboBox cbo)
                //        cbo.Enabled = true;
                //    else if (ctrl is Button btn)
                //        btn.Enabled = true;
                //}
            }
        }

        private void btnSelectWc_Click(object sender, EventArgs e)
        {
            string btnName = ((Button)sender).Name;
            PopupWCSearch sp = new PopupWCSearch();

            if (sp.ShowDialog() == DialogResult.OK)
            {
                if (btnName.Contains("Select"))
                {
                    txtSelectWcCode.Text = sp.Send.Wc_Code;
                    txtSelectWcName.Text = sp.Send.Wc_Name;
                }
                else
                {
                    txtWcCode.Text = sp.Send.Wc_Code;
                    txtWcName.Text = sp.Send.Wc_Name;
                }
            }
        }

        private void ControlTextReset()
        {
            dtpNopStart.Text =
            dtpNopEnd.Text =
            txtNopTime.Text =
            txtNopMaCode.Text =
            txtNopMiCode.Text =
            txtWcCode.Text =
            txtWcName.Text = "";
            //txtSelectWcCode.Text = txtSelectWcName.Text = dateTimePicker1.Text = dateTimePicker2.Text = "";
            //dataGridView1.CurrentCell = null;
        }
        // 하단 입력정보에 값 입력시, 상단 dgv에도 값이 입력됨
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentCell == null) return;
            //if (check == 2)
            //{
            //    //if (dt == null) return;
            //    Control ctrl = ((Control)sender);
            //    dataGridView1[ctrl.Tag.ToString(), dataGridView1.CurrentCell.RowIndex].Value = ctrl.Text;
            //    //dt.Rows[dataGridView1.CurrentCell.RowIndex][ctrl.TabIndex] = ctrl.Text;
            //}
        }

        //셀 클릭시 입력정보 출력
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (check == 2) return;

            input = false;

            cserv = new CommonService();
            //string[] code = { "USE_YN", "PROC_GROUP" };

            txtWcCode.Text = dataGridView1["Wc_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            txtWcName.Text = dataGridView1["Wc_Name", dataGridView1.CurrentRow.Index].Value.ToString();

            dtpNopStart.Value = Convert.ToDateTime(dataGridView1["Nop_HappenTime", dataGridView1.CurrentRow.Index].Value);

            if (dataGridView1["Nop_CancelTime", dataGridView1.CurrentRow.Index].Value == DBNull.Value)
                dtpNopEnd.Text = "1900-01-01 00:00:00";
            else
                dtpNopEnd.Value = Convert.ToDateTime(dataGridView1["Nop_CancelTime", dataGridView1.CurrentRow.Index].Value);


            if (dataGridView1["Nop_Time", dataGridView1.CurrentRow.Index].Value == DBNull.Value)
                txtNopTime.Text = "";
            else
                txtNopTime.Text = dataGridView1["Nop_Time", dataGridView1.CurrentRow.Index].Value.ToString();

            cboNopMaName.Text = dataGridView1["Nop_Ma_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            txtNopMaCode.Text = dataGridView1["Nop_Ma_Code", dataGridView1.CurrentRow.Index].Value.ToString();

            cboNopMiName.Text = dataGridView1["Nop_Mi_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            txtNopMiCode.Text = dataGridView1["Nop_Mi_Code", dataGridView1.CurrentRow.Index].Value.ToString();

            input = true;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null) return;

            input = false;
            txtWcCode.Text = dataGridView1["Wc_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            txtWcName.Text = dataGridView1["Wc_Name", dataGridView1.CurrentRow.Index].Value.ToString();

            DataTable dtMaCode = nserv.GetNopRegist_Ma(txtWcCode.Text);
            CommonUtil.ComboBinding_MaCode(cboNopMaName, dtMaCode.Copy());

            cboNopMaName.Text = dataGridView1["Nop_Ma_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            txtNopMaCode.Text = dataGridView1["Nop_Ma_Code", dataGridView1.CurrentRow.Index].Value.ToString();

            dtpNopStart.Value = Convert.ToDateTime(dataGridView1["Nop_HappenTime", dataGridView1.CurrentRow.Index].Value);
            
            if (dataGridView1["Nop_CancelTime", dataGridView1.CurrentRow.Index].Value == DBNull.Value)
                dtpNopEnd.Text = "1900-01-01 00:00:00";
            else
                dtpNopEnd.Value = Convert.ToDateTime(dataGridView1["Nop_CancelTime", dataGridView1.CurrentRow.Index].Value);


            if (dataGridView1["Nop_Time", dataGridView1.CurrentRow.Index].Value == DBNull.Value)
                txtNopTime.Text = "";
            else
                txtNopTime.Text = dataGridView1["Nop_Time", dataGridView1.CurrentRow.Index].Value.ToString();
            cboNopMaName.Text = dataGridView1["Nop_Ma_Name", dataGridView1.CurrentRow.Index].Value.ToString();

            txtNopMaCode.Text = dataGridView1["Nop_Ma_Code", dataGridView1.CurrentRow.Index].Value.ToString();

            dtMiCode = nserv.GetNopRegist_Mi(txtNopMaCode.Text);
            CommonUtil.ComboBinding_MiCode(cboNopMiName, dtMiCode);

            cboNopMiName.Text = dataGridView1["Nop_Mi_Name", dataGridView1.CurrentRow.Index].Value.ToString();
            txtNopMiCode.Text = dataGridView1["Nop_Mi_Code", dataGridView1.CurrentRow.Index].Value.ToString();
            input = true;
        }

        private void cboNopMa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (dt == null || dtMiCode == null || check != 2) return;
            

            if (input)
            {
                
                txtNopMaCode.Text = cboNopMaName.SelectedValue.ToString();
                cboNopMaName.Text = cboNopMaName.Text.ToString();

                dataGridView1["Nop_Ma_Name", dataGridView1.CurrentRow.Index].Value = cboNopMaName.Text;
                dataGridView1["Nop_Ma_Code", dataGridView1.CurrentRow.Index].Value = txtNopMaCode.Text;

                dtMiCode = nserv.GetNopRegist_Mi(txtNopMaCode.Text);
                CommonUtil.ComboBinding_MiCode(cboNopMiName, dtMiCode);
                if (dtMiCode.Rows.Count < 1)
                {
                    txtNopMiCode.Text = "";
                    cboNopMiName.Text = "";

                    dataGridView1["Nop_Mi_Name", dataGridView1.CurrentRow.Index].Value = cboNopMiName.Text;
                    dataGridView1["Nop_Mi_Code", dataGridView1.CurrentRow.Index].Value = txtNopMiCode.Text;
                }
            }

            //dataGridView1["Nop_Ma_Name", dataGridView1.CurrentRow.Index].Value = cboNopMaName.Text;
            //dataGridView1["Nop_Ma_Code", dataGridView1.CurrentRow.Index].Value = txtNopMaCode.Text;

        }

        private void cboNopMiName_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (dt == null || check != 2) return;
            //if (cboNopMiName.SelectedValue == null) return;

            if (input) 
            {
                txtNopMiCode.Text = cboNopMiName.SelectedValue.ToString();
                cboNopMiName.Text = cboNopMiName.Text.ToString();

                dataGridView1["Nop_Mi_Name", dataGridView1.CurrentRow.Index].Value = cboNopMiName.Text;
                dataGridView1["Nop_Mi_Code", dataGridView1.CurrentRow.Index].Value = txtNopMiCode.Text;
            }
        }
    }
}
