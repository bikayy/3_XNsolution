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
    public partial class Main : Form
    {
        string userID;
        DataTable dtMenu;
        Button btnInit;
        public Main(string userID)
        {
            InitializeComponent();
            this.userID = userID;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void Main_Load(object sender, EventArgs e)
        {
            MenuDAC db = new MenuDAC();
            dtMenu = db.GetUserMenuList(this.userID);

            DrawMenuStrip();
            DrawMenuPanel();
            btnInit.PerformClick();
        }

        private void DrawMenuPanel()
        {
            DataView dv1 = new DataView(dtMenu);
            dv1.RowFilter = "isnull(Parent_Screen_Code,' ')= ' '";
            dv1.Sort = "Sort_Index";
            for (int i = 0; i < dv1.Count; i++)
            {
                Button p_menu = new Button();
                p_menu.Name = $"p_btn{dv1[i]["Seq"].ToString()}";
                p_menu.Text = dv1[i]["WordKey"].ToString();
                p_menu.Dock = DockStyle.Top;
                p_menu.Location = new Point(0, 0);
                p_menu.Margin = new Padding(0);
                p_menu.Size = new System.Drawing.Size(196, 36);
                p_menu.Tag = i.ToString();
                p_menu.Click += btnSystem_Click;

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
            panel1.Size = new Size(193, 300);
            flowLayoutPanel1.Controls.Add(this.panel1);

            treeView1 = new TreeView();
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new System.Drawing.Size(193, 300);
            treeView1.AfterSelect += treeView1_AfterSelect;
            panel1.Controls.Add(this.treeView1);
        }

        private void DrawMenuStrip()
        {

            DataView dv1 = new DataView(dtMenu);
            dv1.RowFilter = "isnull(Parent_Screen_Code,' ')= ' '";
            dv1.Sort = "Sort_Index";
            for(int i = 0; i<dv1.Count;i++)
            {
                ToolStripMenuItem p_menu = new ToolStripMenuItem();
                p_menu.Name = $"p_menu{dv1[i]["Seq"].ToString()}";
                p_menu.Text = dv1[i]["WordKey"].ToString();
                p_menu.Size = new Size(180, 22);

                DataView dv2 = new DataView(dtMenu);
                dv2.RowFilter = "Parent_Screen_Code = " + dv1[i]["Parent_Screen_Code"].ToString() == null ? "" : dv1[i]["Parent_Screen_Code"].ToString();
                dv2.Sort = "Sort_Index";
                for (int k = 0; k < dv2.Count; k++)
                {
                    ToolStripMenuItem c_menu = new ToolStripMenuItem();
                    c_menu.Name = $"p_menu{dv2[k]["Seq"].ToString()}";
                    c_menu.Text = dv2[k]["WordKey"].ToString();
                    c_menu.Tag = dv2[k]["Screen_Path"].ToString();
                    c_menu.Size = new Size(180, 22);
                    c_menu.Click += Menu_Click;
                    p_menu.DropDownItems.Add(c_menu);
                }
                this.menuStrip1.Items.Add(p_menu);
            }
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            //MessageBox.Show(menu.Tag.ToString());
            OpenCreateForm(menu.Tag.ToString(), menu.Text);
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            flowLayoutPanel1.Controls.SetChildIndex(panel1, Convert.ToInt32(btn.Tag) + 1);
            flowLayoutPanel1.Invalidate();
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
                    return;
                }
            }

            try
            {
                Form frm = (Form)Activator.CreateInstance(frmType);
                frm.MdiParent = this;
                frm.WindowState = FormWindowState.Maximized;
                frm.Text = formText;
                frm.Show();
            }
            catch
            {
                MessageBox.Show("등록된 프로그램이 존재하지 않습니다.");
            }
        }
    }
}
