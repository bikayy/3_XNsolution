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
    public partial class PopupSearchProcess : Form
    {
        ProcessService pserv = null;
        DataTable dt = null;

        string sqlWhere = "";
        string Use_YN = "Use_YN = 'Y'";
        ProcessVO sendInfo = new ProcessVO();
        public ProcessVO Send
        {
            get { return sendInfo; }
            set { sendInfo = value; }
        }

        /// <summary>
        /// 공정 검색 팝업창... ▶ 기본조건 Use_YN = 'Y'
        /// </summary>
        public PopupSearchProcess()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 공정 검색 팝업창...
        /// ▶ 가능조건: Process_Code, Process_Name, Process_Group, Remark   
        /// ▶ Use_YN: null => 사용유무와 무관하게 모두 출력할 경우
        /// </summary>
        /// <param name="sqlWhere"> 걸고싶은 조건을 그대로 적으세요... Ex) Process_Group='포장' OR Process_Name='PACK'  </param>
        /// <param name="Use_YN"> Use_YN: null => 사용유무와 무관하게 모두 출력할 경우</param>
        public PopupSearchProcess(string sqlWhere, string Use_YN= "Use_YN = 'Y'")
        {
            if (sqlWhere != null) this.sqlWhere = sqlWhere;
            if (Use_YN != null) this.Use_YN = Use_YN;
            else this.Use_YN = "";
            InitializeComponent();
        }

        

        private void PopupSearchProcess_Load(object sender, EventArgs e)
        {
            
            DataGridViewUtil.SetInitGridView(dataGridView1);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정코드", "Process_Code", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정명", "Process_Name",  colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "공정그룹", "Process_Group", colWidth: 120);
            DataGridViewUtil.AddGridTextColumn(dataGridView1, "비고", "Remark", colWidth: 140);
            if (this.Use_YN==null || this.Use_YN.Length < 1)
                DataGridViewUtil.AddGridTextColumn(dataGridView1, "사용유무", "Use_YN", colWidth: 70);//, visibility: false);

            pserv = new ProcessService();
            LoadData();
            dataGridView1.CurrentCell = null;
        }
        
        private void LoadData()
        {
            dt = pserv.SearchProcess();
            DataView dv_SerchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            
            if (sqlWhere.Trim().Length > 0)
            {
                sb.Append(" AND ");
                sb.Append(sqlWhere);
            }
            if (Use_YN.Trim().Length > 0)
            {
                sb.Append(" AND ");
                sb.Append(Use_YN);
            }
            dv_SerchList.RowFilter = sb.ToString();
            dt = dv_SerchList.ToTable();
            dataGridView1.DataSource = dt;
            dataGridView1.CurrentCell = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtProcessCode.Text = dataGridView1["Process_Code", e.RowIndex].Value.ToString();
            txtProcessName.Text = dataGridView1["Process_Name", e.RowIndex].Value.ToString();


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text.Trim()))
            {
                MessageBox.Show("검색어를 입력해주세요.");
                return;
            }

            string search = txtSearch.Text.ToUpper().Trim();

            var result = from row in dt.AsEnumerable()
                         where row.Field<string>("Process_Code").Contains(search) || row.Field<string>("Process_Name").Contains(search)
                         select row;

            //DataTable dt_search = result.CopyToDataTable();
            if (result.Count() > 0)
                dataGridView1.DataSource = result.CopyToDataTable();
            else
                dataGridView1.DataSource = null;
            dataGridView1.CurrentCell = null;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = txtProcessCode.Text = txtProcessName.Text = "";
            LoadData();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            sendInfo.Process_Code = txtProcessCode.Text;
            sendInfo.Process_Name = txtProcessName.Text;
            sendInfo.Process_Group = dataGridView1["Process_Group", dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void bntCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
