﻿using System;
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
        Panel panel1;
        TreeView treeView1;

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

            //DrawMenuStrip();
            DrawMenuPanel();
            btnInit.PerformClick();
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
                p_menu.Size = new System.Drawing.Size(197, 50);
                p_menu.Tag = dv1[i]["Screen_Code"].ToString();
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
            treeView1.ItemHeight = 20;
            treeView1.ImageList = imageList1;
            treeView1.Size = new System.Drawing.Size(193, 300);
            treeView1.AfterSelect += treeView1_AfterSelect;
            panel1.Controls.Add(this.treeView1);
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
                    this.ActiveMdiChild.Close();
                    break;
                }
            }
        }

        private void Main_MdiChildActivate(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild == null)
            {
                tabControl1.Visible = false;
            }
            else
            {
                this.ActiveMdiChild.StartPosition = FormStartPosition.Manual;
                this.ActiveMdiChild.Location = new Point(0, 0);
                this.ActiveMdiChild.WindowState = FormWindowState.Maximized;

                if (this.ActiveMdiChild.Tag == null)
                {
                    StringBuilder sb = new StringBuilder(this.ActiveMdiChild.Text);
                    for (int i = 0; i < sb.Length; i++)
                    {
                        if (sb.Length < 9)
                            sb.Append("　");

                    }
                    //탭페이지를 추가해서 탭컨트롤에 추가

                    TabPage tp = new TabPage(sb.ToString());
                    tp.Width = 400;
                    tp.Parent = tabControl1;
                    tp.Tag = this.ActiveMdiChild;
                    tp.Name = this.ActiveMdiChild.Text;
                    tp.Font = new Font("Consolas", 11, FontStyle.Regular);

                    tabControl1.SelectedTab = tp;

                    this.ActiveMdiChild.FormClosed += ActiveMdiChild_FormClosed;

                    this.ActiveMdiChild.Tag = tp;
                }

                if (!tabControl1.Visible)
                    tabControl1.Visible = true;

            }
        }
        private void ActiveMdiChild_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form frm = (Form)sender;
            ((TabPage)frm.Tag).Dispose();
        }
    }
}
