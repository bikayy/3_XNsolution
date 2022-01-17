using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Team5_XN_VO;

namespace Team5_XN
{
    public partial class frmUserGroupAuthority : Form
    {
        UserVO user;
        List<UserVO> list = null;
        CommonService commonServ;
        UserService userServ = new UserService();
        DataTable dt;
        DataTable dt_DB;
        Main main = null;
        int rowCount;
        DataView searchList;
        int check = 0;
        public frmUserGroupAuthority()
        {
            InitializeComponent();
        }

        private void frmUserGroupAuthority_Load(object sender, EventArgs e)
        {
            main = (Main)this.MdiParent;
            main.Select += OnSelect;

            main.Update += OnUpdate;
            main.Save += OnSave;
            main.Cancle += OnCancle;
            //LoadData();
            dgvUserAuthority.Columns.Clear();

            DataGridViewUtil.SetInitGridView(dgvUserAuthority);

            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "사용자그룹코드", "UserGroup_Code", colWidth: 150, visibility:false);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "메뉴코드", "Screen_Code", colWidth: 150);
            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "메뉴명", "WordKey", colWidth: 180);
            var chkSelect = new DataGridViewCheckBoxColumn
            {
                Name = "chkSel",
                HeaderText = "조회권한",

            };
            dgvUserAuthority.Columns.Add(chkSelect);
            var chkCreate = new DataGridViewCheckBoxColumn
            {
                Name = "chkCre",
                HeaderText = "추가권한"
            };
            dgvUserAuthority.Columns.Add(chkCreate);
            var chkUpdate = new DataGridViewCheckBoxColumn
            {
                Name = "chkUpd",
                HeaderText = "수정권한"
            };
            dgvUserAuthority.Columns.Add(chkUpdate);
            var chkDelete = new DataGridViewCheckBoxColumn
            {
                Name = "chkDel",
                HeaderText = "삭제권한"
            };
            dgvUserAuthority.Columns.Add(chkDelete);

            DataGridViewUtil.AddGridTextColumn(dgvUserAuthority, "권한문자열", "Pre_Type", colWidth: 100);
        }

        private void OnCancle(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnSave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

            userServ = new UserService();
            dt = userServ.GetUserAuthority();
            dt_DB = dt.Copy();
            dgvUserAuthority.DataSource = dt;
            //dgvUserInfo_CellClick(dgvUserInfo, new DataGridViewCellEventArgs(0, 0));
            searchList = new DataView(dt);

            StringBuilder sb = new StringBuilder();
            sb.Append(" 1 = 1 ");

            if (!string.IsNullOrWhiteSpace(txtUserCode.Text))
            {
                //if (sb.Length > 0) sb.Append(" AND ");
                sb.Append(" AND UserGroup_Code LIKE '%" + txtUserCode.Text + "%'");
            }
            searchList.RowFilter = sb.ToString();
            dgvUserAuthority.DataSource = searchList;
            rowCount = searchList.Count;
            dgvUserAuthority.CurrentCell = null;
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
        }
        private void pnlSelect_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
