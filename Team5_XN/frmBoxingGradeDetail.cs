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
        Main main = null;
        int rowCount;
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

            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            dgvBoxMaster.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvBoxMaster);

            DataGridViewUtil.AddGridTextColumn(dgvBoxMaster, "포장등급 코드", "Boxing_Grade_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvBoxMaster, "포장등급 명", "Boxing_Grade_Name", colWidth: 200);
            dt = boxServ.GetBoxingGradeMaster();
            dt_DB = dt.Copy();
            dgvBoxMaster.DataSource = dt;

            dgvBoxDetail.Columns.Clear();
            DataGridViewUtil.SetInitGridView(dgvBoxDetail);

            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "포장등급 상세코드", "Grade_Detail_Code", colWidth: 180);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "포장등급 상세명", "Grade_Detail_Name", colWidth: 170);
            DataGridViewUtil.AddGridTextColumn(dgvBoxDetail, "사용유무", "Use_YN", colWidth: 100);

            main.toolCreate.Enabled = main.toolUpdate.Enabled = main.toolDelete.Enabled = main.toolSave.Enabled = main.toolCancle.Enabled = false;

            //GetCommonCodeList
            string[] code = { "USE_YN" };

            //cdac = new CommonDAC();
            commServ = new CommonService();

            DataTable dtSysCode = commServ.GetCommonCodeSys(code);
            CommonUtil.ComboBinding(cboUseYN, "USE_YN", dtSysCode.Copy(), false);
            //LoadData();
        }

        private void OnSelect(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCreate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnCancle(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ControlState()
        {
            if (check <= 1) //0:기본, 1:추가
                if (check == 1 && dgvBoxDetail.CurrentRow != null && dgvBoxDetail.CurrentRow.Index >= rowCount) //추가한 행
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
                        if (ctrl.Name.Equals("txtBoxGradeCode")) continue;
                        txt.ReadOnly = false;
                    }
                    else if (ctrl is ComboBox cbo)
                        cbo.Enabled = true;
                    else if (ctrl is Button btn)
                        btn.Enabled = true;
                }
            }
        }
        private void dgvBoxMaster_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string code = Convert.ToString(dgvBoxMaster.Rows[e.RowIndex].Cells[0].Value);
            list = boxServ.GetBoxingGradeDetail(code);
            dgvBoxDetail.DataSource = list;

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
    }
}
