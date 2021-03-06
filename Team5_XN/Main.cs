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
using Team5_XN_DAC;

namespace Team5_XN
{
    public partial class Main : Form
    {
        string userID;
        DataTable dtMenu;
        Button btnInit;
        Button btnSelect;
        Panel panel1;
        TreeView treeView1;
        string frmName;
        //클릭시 발생하는 이벤트
        public event EventHandler Select; //조회버튼
        public event EventHandler Create; //등록(생성)버튼
        public event EventHandler Update; //수정버튼
        public event EventHandler Save;   //저장버튼
        public event EventHandler Delete; //삭제버튼
        public event EventHandler Cancle; //취소버튼
        public event EventHandler Reset; //초기화버튼


        public Main(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }


        private void Main_Load(object sender, EventArgs e)
        {
            MenuDAC db = new MenuDAC();
            dtMenu = db.GetUserMenuList(this.userID);

            //DrawMenuStrip();
            DrawMenuPanel();
            btnInit.PerformClick();
            
            frmDashBoard frm = new frmDashBoard();
            OpenCreateForm("frmDashBoard", "DashBoard");
            //frm.Activate();
        }

        private void DrawMenuPanel()
        {
            DataView dv1 = new DataView(dtMenu);
            dv1.RowFilter = "Parent_Screen_Code is null or Parent_Screen_Code = ''";
            dv1.Sort = "Sort_Index";
            for (int i = 0; i < dv1.Count; i++)
            {
                Button p_menu = new Button();
                p_menu.Name = $"p_btn{i.ToString()}";
                p_menu.Text = dv1[i]["WordKey"].ToString();
                p_menu.Dock = DockStyle.Top;
                p_menu.Location = new Point(0, 0);
                p_menu.Margin = new Padding(0);
                p_menu.Size = new System.Drawing.Size(199, 50);
                p_menu.Tag = dv1[i]["Screen_Code"].ToString();
                p_menu.Click += btnSystem_Click;
                p_menu.Font = new Font("맑은 고딕", 9);
                flowLayoutPanel1.Controls.Add(p_menu);

                if (i == 0)
                {
                    btnInit = p_menu;
                }
            }

            panel1 = new Panel();
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(3, (dv1.Count * 40));
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 300);
            flowLayoutPanel1.Controls.Add(this.panel1);

            treeView1 = new TreeView();
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.ItemHeight = 20;
            treeView1.ImageList = imageList1;
            treeView1.Size = new System.Drawing.Size(193, 300);
            //treeView1.AfterSelect += treeView1_AfterSelect;
            treeView1.NodeMouseClick += TreeView1_NodeMouseClick;
            panel1.Controls.Add(this.treeView1);
        }

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenCreateForm(e.Node.Tag.ToString(), e.Node.Text);
        }

        //private void DrawMenuStrip()
        //{

        //    DataView dv1 = new DataView(dtMenu);
        //    dv1.RowFilter = "isnull(Parent_Screen_Code,' ')= ' '";
        //    dv1.Sort = "Sort_Index";
        //    for (int i = 0; i < dv1.Count; i++)
        //    {
        //        ToolStripMenuItem p_menu = new ToolStripMenuItem();
        //        p_menu.Name = $"p_menu{dv1[i]["Seq"].ToString()}";
        //        p_menu.Text = dv1[i]["WordKey"].ToString();
        //        p_menu.Size = new Size(180, 22);

        //        DataView dv2 = new DataView(dtMenu);
        //        dv2.RowFilter = "Parent_Screen_Code = " + dv1[i]["Parent_Screen_Code"].ToString() == null ? "" : dv1[i]["Parent_Screen_Code"].ToString();
        //        dv2.Sort = "Sort_Index";
        //        for (int k = 0; k < dv2.Count; k++)
        //        {
        //            ToolStripMenuItem c_menu = new ToolStripMenuItem();
        //            c_menu.Name = $"p_menu{dv2[k]["Seq"].ToString()}";
        //            c_menu.Text = dv2[k]["WordKey"].ToString();
        //            c_menu.Tag = dv2[k]["Screen_Path"].ToString();
        //            c_menu.Size = new Size(180, 22);
        //            c_menu.Click += Menu_Click;
        //            p_menu.DropDownItems.Add(c_menu);
        //        }
        //        this.menuStrip1.Items.Add(p_menu);
        //    }
        //}

        //private void Menu_Click(object sender, EventArgs e)
        //{
        //    ToolStripMenuItem menu = (ToolStripMenuItem)sender;
        //    //MessageBox.Show(menu.Tag.ToString());
        //    OpenCreateForm(menu.Tag.ToString(), menu.Text);
        //}

        private void btnSystem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btnSelect = btn;
            flowLayoutPanel1.Controls.SetChildIndex(panel1, Convert.ToInt32(btn.Name.Replace("p_btn", "")) + 1);
            flowLayoutPanel1.Invalidate();

            treeView1.Nodes.Clear();

            DataView dv2 = new DataView(dtMenu);
            dv2.RowFilter = "Parent_Screen_Code = '" + btn.Tag.ToString() + "'";
            dv2.Sort = "Sort_Index";
            for (int k = 0; k < dv2.Count; k++)
            {
                TreeNode c_node = new TreeNode(dv2[k]["WordKey"].ToString());
                c_node.Tag = dv2[k]["Screen_Path"].ToString();
                c_node.ImageIndex = 0;
                treeView1.Nodes.Add(c_node);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OpenCreateForm(e.Node.Tag.ToString(), e.Node.Text);
        }

        private void OpenCreateForm(string pgmName, string formText)
        {
            string appName = Assembly.GetEntryAssembly().GetName().Name;
            Type frmType = Type.GetType($"{appName}.{pgmName}");


            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == frmType)
                {
                    frm.Activate();
                    frm.BringToFront();
                    tabControl1.SelectedTab = tabControl1.TabPages[frm.Text];
                    toolSetting(frmName);
                    return;
                }
             }

            try
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.Text = formText;
                frm.MdiParent = this;                           
                frm.Show();
                frm.WindowState = FormWindowState.Maximized;
            }
            catch
            {
                MessageBox.Show("등록된 프로그램이 존재하지 않습니다.");
            }
        }
        //조회
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Select != null)
            {
                Select(this, null);
           }
        }
        //추가
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (Create != null)
            {
                Create(this, null);
            }
        }
        //편집
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (Update != null)
            {
                Update(this, null);
            }
        }
        //삭제
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, null);
            }
        }

        //저장
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Save != null)
            {
                Save(this, null);
            }
        }

        private void toolCancle_Click(object sender, EventArgs e)
        {
            if (Cancle != null)
            {
                Cancle(this, null);
            }
        }
        //초기화
        private void toolReset_Click(object sender, EventArgs e)
        {
            if (Reset != null)
            {
                Reset(this, null);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != null)
            {
                Form frm = (Form)tabControl1.SelectedTab.Tag;
                frm.Select();
            }
        }
        private void tabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                var r = tabControl1.GetTabRect(i);
                var closeImage = Properties.Resources.icon_close_black;
                var closeRect = new Rectangle((r.Right - closeImage.Width), r.Top + (r.Height - closeImage.Height) / 2,
                    closeImage.Width, closeImage.Height);
                
                if (closeRect.Contains(e.Location))
                {
                    if(this.ActiveMdiChild.Name != "frmDashBoard")
                    this.ActiveMdiChild.Close();
                    if (btnSelect != null) btnSelect.Focus();
                    
                    break;
                }
                

            }
            toolSetting(frmName);
        }

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                tabControl1.Visible = false;
            }
            else
            {
                Form frm = sender as Form;
                frmName = frm.ActiveMdiChild.Text;
                

                //this.ActiveMdiChild.StartPosition = FormStartPosition.Manual;
                this.ActiveMdiChild.Location = new Point(0, 0);
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null)
                {
                    StringBuilder sb = new StringBuilder(this.ActiveMdiChild.Text);
                    for (int i = 0; i < 20; i++)
                    {
                        if (sb.Length > 20)
                            break;
                        sb.Append(" ");

                    }
                    //탭페이지를 추가해서 탭컨트롤에 추가

                    TabPage tp = new TabPage(sb.ToString());
                    //tp.Width = 600;
                    //tp.Height = 35;
                    tp.Parent = tabControl1;
                    tp.Tag = this.ActiveMdiChild;
                    tp.Name = this.ActiveMdiChild.Text;
                    //tp.Font = new Font("Consolas", 11, FontStyle.Regular);

                    tabControl1.SelectedTab = tp;

                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;

                    this.ActiveMdiChild.Tag = tp;
                }

                if (!tabControl1.Visible) 
                { 
                    tabControl1.Visible = true;
                    
                }

            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            ((TabPage)frm.Tag).Dispose();
        }

        private void menuStrip1_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            if (e.Item.Text == "" || e.Item.Text == "최소화(&N)" || e.Item.Text == "이전 크기로(&R)" || e.Item.Text == "닫기(&C)") //최소화(&N) 이전 크기로(&R) 닫기(&C)
                e.Item.Visible = false;
        }

        /// <summary>
        /// 혹시나해서 가라로 넣은 툴버튼 세팅 메서드
        /// </summary>
        /// <param name="formName"></param>
        private void toolSetting(string formName)
        {
            toolSelect.BackColor = toolCreate.BackColor = toolUpdate.BackColor = toolDelete.BackColor = toolReset.BackColor =
                toolSave.BackColor = toolCancle.BackColor = Color.DarkGray;

            if (formName == "사용자관리" || formName == "사용자그룹관리" || formName == "시스템코드분류" || formName == "공정정보" || formName == "작업장정보" || formName == "품목정보" || formName == "비가동분류" || formName == "포장등급 상세정의" || formName == "생산요청관리")
            {
                //조회 추가 편집 삭제 새로고침
                toolSelect.Enabled = toolCreate.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolReset.Enabled = true;
                toolSave.Enabled = toolCancle.Enabled = false;

            }
            else if (formName == "사용자권한설정")
            {
                //조회 편집 새로고침
                toolSelect.Enabled = toolUpdate.Enabled = toolReset.Enabled = true;
                toolCreate.Enabled = toolSave.Enabled = toolCancle.Enabled = toolDelete.Enabled = false;
            }
            else if (formName == "비가동이력" )
            {
                //조회 편집 삭제 새로고침
                toolSelect.Enabled = toolUpdate.Enabled = toolReset.Enabled = toolDelete.Enabled = true;
                toolCreate.Enabled = toolSave.Enabled = toolCancle.Enabled = false;
            }
            else if (formName == "화면관리" || formName == "시간대별 실적조회" || formName == "일별 생산현황" || formName == "일별 불량률" || formName == "생산계획관리")
            {
                //조회 새로고침
                toolSelect.Enabled = toolReset.Enabled = true;
                toolCreate.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolSave.Enabled = toolCancle.Enabled = false;
            }
            else
            {
                //노버튼
                //작업지시 생성 및 마감
                //시유 작업지시 생성
                //완제품 입고리스트
                toolSelect.Enabled = toolReset.Enabled =
                toolCreate.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolSave.Enabled = toolCancle.Enabled = false;
            }

        }
    }
}
