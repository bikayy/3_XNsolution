
namespace Team5_XN
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSelect = new System.Windows.Forms.ToolStripButton();
            this.toolCreate = new System.Windows.Forms.ToolStripButton();
            this.toolUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancle = new System.Windows.Forms.ToolStripButton();
            this.toolReset = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabControl1 = new Team5_XN.ucTabControl();
            this.pnlTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DimGray;
            this.pnlTop.Controls.Add(this.panel3);
            this.pnlTop.Controls.Add(this.toolStrip1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1284, 99);
            this.pnlTop.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.BackgroundImage = global::Team5_XN.Properties.Resources.samhyun_icon;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(208, 99);
            this.panel3.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(42, 45);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelect,
            this.toolCreate,
            this.toolUpdate,
            this.toolDelete,
            this.toolSave,
            this.toolCancle,
            this.toolReset});
            this.toolStrip1.Location = new System.Drawing.Point(206, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1087, 101);
            this.toolStrip1.TabIndex = 50;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolSelect
            // 
            this.toolSelect.BackColor = System.Drawing.Color.DarkGray;
            this.toolSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolSelect.Image = global::Team5_XN.Properties.Resources.icon_xn_select;
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolSelect.Size = new System.Drawing.Size(60, 77);
            this.toolSelect.Text = "조회";
            this.toolSelect.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolSelect.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolCreate
            // 
            this.toolCreate.BackColor = System.Drawing.Color.DarkGray;
            this.toolCreate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolCreate.Image = global::Team5_XN.Properties.Resources.icon_xn_create;
            this.toolCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCreate.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolCreate.Name = "toolCreate";
            this.toolCreate.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolCreate.Size = new System.Drawing.Size(60, 77);
            this.toolCreate.Text = "추가";
            this.toolCreate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolCreate.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolUpdate
            // 
            this.toolUpdate.BackColor = System.Drawing.Color.DarkGray;
            this.toolUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolUpdate.Image = global::Team5_XN.Properties.Resources.icon_xn_update;
            this.toolUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolUpdate.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolUpdate.Name = "toolUpdate";
            this.toolUpdate.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolUpdate.Size = new System.Drawing.Size(60, 77);
            this.toolUpdate.Text = "편집";
            this.toolUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolUpdate.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolDelete
            // 
            this.toolDelete.BackColor = System.Drawing.Color.DarkGray;
            this.toolDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolDelete.Image = global::Team5_XN.Properties.Resources.icon_xn_delete;
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolDelete.Size = new System.Drawing.Size(60, 77);
            this.toolDelete.Text = "삭제";
            this.toolDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolDelete.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolSave
            // 
            this.toolSave.BackColor = System.Drawing.Color.DarkGray;
            this.toolSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolSave.Image = global::Team5_XN.Properties.Resources.icon_xn_save;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolSave.Name = "toolSave";
            this.toolSave.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolSave.Size = new System.Drawing.Size(60, 77);
            this.toolSave.Text = "저장";
            this.toolSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolSave.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolCancle
            // 
            this.toolCancle.BackColor = System.Drawing.Color.DarkGray;
            this.toolCancle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolCancle.Image = global::Team5_XN.Properties.Resources.icon_xn_cancle;
            this.toolCancle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancle.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolCancle.Name = "toolCancle";
            this.toolCancle.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.toolCancle.Size = new System.Drawing.Size(60, 77);
            this.toolCancle.Text = "취소";
            this.toolCancle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolCancle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolCancle.Click += new System.EventHandler(this.toolCancle_Click);
            // 
            // toolReset
            // 
            this.toolReset.BackColor = System.Drawing.Color.DarkGray;
            this.toolReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolReset.Image = global::Team5_XN.Properties.Resources.icon_xn_refresh_green2;
            this.toolReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReset.Margin = new System.Windows.Forms.Padding(10, 8, 2, 14);
            this.toolReset.Name = "toolReset";
            this.toolReset.Padding = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.toolReset.Size = new System.Drawing.Size(61, 77);
            this.toolReset.Text = "새로고침";
            this.toolReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolReset.Click += new System.EventHandler(this.toolReset_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 99);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 3, 4, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 762);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "41-414803_blue-menu-icon-icon.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1101, 21);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            this.menuStrip1.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip1_ItemAdded);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("Consolas", 9F);
            this.tabControl1.Location = new System.Drawing.Point(200, 99);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 29);
            this.tabControl1.TabIndex = 120;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 861);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.MdiChildActivate += new System.EventHandler(this.Main_MdiChildActivate);
            this.pnlTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private ucTabControl tabControl1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripButton toolCancle;
        public System.Windows.Forms.ToolStripButton toolUpdate;
        public System.Windows.Forms.ToolStripButton toolDelete;
        public System.Windows.Forms.ToolStripButton toolSave;
        public System.Windows.Forms.ToolStripButton toolSelect;
        public System.Windows.Forms.ToolStripButton toolCreate;
        private System.Windows.Forms.ToolStripButton toolReset;
    }
}

