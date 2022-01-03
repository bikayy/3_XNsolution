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
    public partial class frmWorkCenter : Form
    {
        WorkCenterDAC wdac;
        CommonDAC cdac;
        WorkCenterService wserv;
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

        public frmWorkCenter()
        {
            InitializeComponent();
        }

        private void frmWorkCenter_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Delete += OnDelete;
            main.Cancle += OnCancle;

            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장코드", "Wc_Code", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장명", "Wc_Name", colWidth: 250, align: DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "작업장그룹", "Wc_Group", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정그룹", "Process_Code", colWidth: 150);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "모니터링여부", "Monitoring_YN", colWidth: 80);            
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "팔렛생성유무", "Pallet_YN", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "사용유무", "Use_YN", colWidth: 80);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비고", "Remark", colWidth: 150);
            dataGridView1.ReadOnly = false;


            string[] code = { "USE_YN", "WC_GROUP" };

            cdac = new CommonDAC();
            cserv = new CommonService();

            DataTable dtSysCode = cserv.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUse_YN, "USE_YN", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboSelectUse_YN, "USE_YN", dtSysCode.Copy());
            CommonUtil.ComboBinding(cboMonitoring_YN, "USE_YN", dtSysCode.Copy(), false);
            CommonUtil.ComboBinding(cboPallet_YN, "USE_YN", dtSysCode.Copy(), false);


            DataTable dtUserCode = cserv.GetCommonCodeUser(code);
            CommonUtil.ComboBinding(cboWcGroup, "WC_GROUP", dtUserCode.Copy(), false);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;
        }
        private void OnSelect(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
            ChangeValue_Check(0);

            wdac = new WorkCenterDAC();
            wserv = new WorkCenterService();
            dt = wserv.GetWorkCenter();
            dt_DB = dt.Copy();
            dataGridView1.DataSource = dt;

            dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtSelectWcCode.Text))
            {
                sb.Append(" AND Wc_Code LIKE '%" + txtSelectWcCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectWcName.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Wc_Name LIKE '%" + txtSelectWcName.Text + "%'");
            }
            if (!cboSelectUse_YN.Text.Equals("전체"))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND Use_YN = '" + cboSelectUse_YN.Text + "'");
            }
            /******* --- (!!)if 공정그룹 추가 필요 ! *********/

            dv_SerchList.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv_SerchList;
            rowCount = dv_SerchList.Count;
            dataGridView1.CurrentCell = null;



        }
        private void OnCreate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return; 
            
            ChangeValue_Check(1); //추가
            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = dataGridView1[0, dataGridView1.RowCount - 1];
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
            ChangeValue_Check(2); //편집
        }


        private void OnSave(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

        }

        private void OnDelete(object sender, EventArgs e)
        {
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
                }
                else
                {
                    MessageBox.Show("추가한 행만 삭제가 가능합니다.");
                }
            }
            else //if (check == 3) //3:삭제
            {
                if (MessageBox.Show($"[{txtSelectWcCode.Text}] 데이터를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    wserv = new WorkCenterService();
                    bool result = true;// = wserv.DeleteProcess(txtSelectWcCode.Text);
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
                foreach (Control ctrl in pnlDetail.Controls)
                {
                    if (ctrl is TextBox txt)
                        txt.ReadOnly = true;
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = false;
                }
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
            //삭제
            //else if (check == 3)
            //{

            //}
        }

        //셀편집기능
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {

            DataGridView dgv = (DataGridView)sender;
            //기본, 추가
            if (check <= 1)
            {
                if (e.RowIndex < rowCount)
                    e.Cancel = true;
            }
            //편집
            else if (check == 2)
            {
                if (e.ColumnIndex == 0)
                    e.Cancel = true;
            }
        }

        //상단 dgv에 값 입력시, 하단 입력정보에도 값이 입력됨
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (check < 1) return;
            DataGridView col = ((DataGridView)sender);
            foreach (Control ctrl in pnlDetail.Controls)
            {
                if (ctrl.Tag == col.Columns[e.ColumnIndex].DataPropertyName)
                    ctrl.Text = col[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }

        // 하단 입력정보에 값 입력시, 상단 dgv에도 값이 입력됨
        private void txtBox_TextChanged(object sender, EventArgs e)
        {
            if (check < 1) return;
            //if (dt == null) return;
            Control ctrl = ((Control)sender);
            dataGridView1[ctrl.Tag.ToString(), dataGridView1.CurrentCell.RowIndex].Value = ctrl.Text;
            //dt.Rows[dataGridView1.CurrentCell.RowIndex][ctrl.TabIndex] = ctrl.Text;
        }
    }
}
