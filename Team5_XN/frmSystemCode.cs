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
        DataTable list;
        CommonService commServ = new CommonService();
        DataTable dt;
        DataTable dt2;
        DataTable dt_DB;
        Main main = null;
        int rowCount;
        DataView searchList;
        int check = 0;
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

            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            dgvSysMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysMaster);

            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류코드", "Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류명", "Name", colWidth: 200);

            dgvSysDetail.Columns.Clear();
            DataGridViewUtil.SetInitGridView(dgvSysDetail);

            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류코드", "DetailCode", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류명", "DetailName", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "정렬순서", "Sort_Index", colWidth: 100);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "사용여부", "UseYN", colWidth: 100);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN" };

            //cdac = new CommonDAC();
            commServ = new CommonService();

            DataTable dtSysCode = commServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy(), false);
            //LoadData();
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

        private void OnSave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            ChangeValue_Check(1); //추가
            //dataGridView1.AllowUserToAddRows = true;
            DataRow dr = dt.NewRow();

            dt.Rows.Add(dr);

            dt.AcceptChanges();
            dgvSysMaster.DataSource = dt;
            dgvSysMaster.CurrentCell = dgvSysMaster[0, dgvSysMaster.RowCount - 1];
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

            commServ = new CommonService();
            dt = commServ.GetSystemCodeMaster(); 
            dt_DB = dt.Copy();
            dgvSysMaster.DataSource = dt;
            dgvSysMaster_CellClick(dgvSysMaster, new DataGridViewCellEventArgs(0, 0));
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
            dgvSysMaster.CurrentCell = null;

            //ControlTextReset();

        }
        private void ChangeValue_Check(int check)
        {
            this.check = check;

            //기본
            if (check == 0)
            {
                main.toolSelect.Enabled = main.toolCreate.Enabled = main.toolUpdate.Enabled = true;
                main.toolSave.Enabled = main.toolCancle.Enabled = main.toolDelete.Enabled = false;
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
                        if (ctrl.Name.Equals("txtSysMiCode")) continue;
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
            dgvSysMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysMaster);

            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류코드", "Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysMaster, "시스템정의 대분류명", "Name", colWidth: 200);
            list = commServ.GetSystemCodeMaster();
            dgvSysMaster.DataSource = list;
            dgvSysDetail.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvSysDetail);

            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류코드", "DetailCode", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "시스템정의 상세분류명", "DetailName", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvSysDetail, "사용여부", "UseYN", colWidth: 100);
        }

        private void dgvSysMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = Convert.ToString(dgvSysMaster.Rows[e.RowIndex].Cells[1].Value);
            list = commServ.GetSystemCodeDetail(name);
            dgvSysDetail.DataSource = list;

            dgvSysDetail_CellClick(sender, e);
        }


        private void dgvSysDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (check == 1) ControlState();

            txtSysMiCode.Text = dgvSysDetail["DetailCode", dgvSysDetail.CurrentRow.Index].Value.ToString();
            txtSysMiName.Text = dgvSysDetail["DetailName", dgvSysDetail.CurrentRow.Index].Value.ToString();

            txtSort.Text = dgvSysDetail["Sort_Index", dgvSysDetail.CurrentRow.Index].Value.ToString();
            txtRemark.Text = dgvSysDetail["Remark", dgvSysDetail.CurrentRow.Index].Value.ToString();
            cboUseYN.Text = dgvSysDetail["UseYN", dgvSysDetail.CurrentRow.Index].Value.ToString();
        }
    }
}
