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
        ProcessDAC pdac;
        DataTable dt;
        public frmProcess()
        {
            InitializeComponent();
        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            Main main = (Main)this.MdiParent;
            main.Select += OnSelect;
            main.Create += OnCreate;
            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Delete += OnDelete;
            

            DataGridViewUtil.SetInitGridView(dataGridView1);

            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정코드", "Process_Code", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정명", "Process_Name", colWidth: 250, align: DataGridViewContentAlignment.MiddleLeft);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정그룹", "Process_Group", colWidth: 200);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비고", "Remark", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "사용유무", "Use_YN", colWidth: 80);

            pdac = new ProcessDAC();

            
            dt = pdac.GetProcess();
            dataGridView1.DataSource = dt;

            string[] data = { "전체", "Y", "N" };
            cboSelectUse_YN.Items.AddRange(data);
            cboSelectUse_YN.SelectedIndex = 0;
        }

        private void OnSelect(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            //MessageBox.Show("조회");
            DataView dv1 = new DataView(dt);

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(txtSelectProcessCode.Text))
            {
                sb.Append("Process_Code LIKE '%" + txtSelectProcessCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectProcessName.Text))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Process_Name LIKE '%" + txtSelectProcessName.Text + "%'");
            }
            if (!cboSelectUse_YN.Text.Equals("전체"))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Use_YN = '" + cboSelectUse_YN.Text + "'");
            }

            dv1.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv1;
        }

        private void OnCreate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;
        }


        private void OnUpdate(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

        }

        private void OnSave(object sender, EventArgs e) 
        { 
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

            MessageBox.Show("저장");
        }

        private void OnDelete(object sender, EventArgs e)
        {
            if (((Main)this.MdiParent).ActiveMdiChild != this) return;

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataView dv1 = new DataView(dt);
            //dv1.RowFilter = "Parent_Screen_Code is null or Parent_Screen_Code = ''";

            //txtProcessCode.Text = dv1[e.RowIndex]["Process_Code"].ToString();
            txtProcessCode.Text=dv1[e.RowIndex].Row["Process_Code"].ToString();
            txtProcessName.Text = dv1[e.RowIndex]["Process_Name"].ToString();
            cboProcessGroup.Text = dv1[e.RowIndex]["Process_Group"].ToString();
            txtRemark.Text = dv1[e.RowIndex]["Remark"].ToString();
            cboUse_YN.Text = dv1[e.RowIndex]["Use_YN"].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView dv1 = new DataView(dt);

            //dv1.RowFilter = "Process_Code LIKE '%" + txtSelectProcessCode.Text + "%' AND Process_Name LIKE '%" + txtSelectProcessName.Text + "%' AND Use_YN = '" + cboSelectUse_YN.Text + "'";

            //if (!string.IsNullOrWhiteSpace(txtSelectProcessCode.Text))
            //{
            //    dv1.RowFilter = "Process_Code LIKE '%" + txtSelectProcessCode.Text + "%'";
            //}
            //if (!string.IsNullOrWhiteSpace(txtSelectProcessName.Text))
            //{
            //    dv1.RowFilter = "Process_Name LIKE '%" + txtSelectProcessName.Text + "%'";
            //}
            //if (!cboSelectUse_YN.Text.Equals("전체"))
            //{
            //    dv1.RowFilter = "Use_YN = '" + cboSelectUse_YN.Text + "'";
            //}


            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(txtSelectProcessCode.Text))
            {
                sb.Append("Process_Code LIKE '%" + txtSelectProcessCode.Text + "%'");
            }
            if (!string.IsNullOrWhiteSpace(txtSelectProcessName.Text))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Process_Name LIKE '%" + txtSelectProcessName.Text + "%'");
            }
            if (!cboSelectUse_YN.Text.Equals("전체"))
            {
                if (sb.Length > 0) sb.Append(" AND ");
                sb.Append("Use_YN = '" + cboSelectUse_YN.Text + "'");
            }
            //DataRow[] rows=null;

            //if (!string.IsNullOrWhiteSpace(txtSelectProcessCode.Text))
            //{
            //    rows = dt.Select("Process_Code LIKE '%" + txtSelectProcessCode.Text + "%'");
            //}
            //if (!string.IsNullOrWhiteSpace(txtSelectProcessName.Text))
            //{
            //    rows = dt.Select("Process_Name LIKE '%" + txtSelectProcessName.Text + "%'");
            //}
            //if (!cboSelectUse_YN.Text.Equals("전체"))
            //{
            //    rows = dt.Select("Use_YN = '" + cboSelectUse_YN.Text + "'");
            //}

            dv1.RowFilter = sb.ToString();
            dataGridView1.DataSource = dv1;
            //DataTable dt2 = rows.CopyToDataTable();
            //dataGridView1.DataSource = dt2;

        }
    }
}
