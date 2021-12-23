
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolSelect = new System.Windows.Forms.ToolStripButton();
            this.pnlTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.DimGray;
            this.pnlTop.Controls.Add(this.panel3);
            this.pnlTop.Controls.Add(this.toolStrip1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1284, 80);
            this.pnlTop.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DimGray;
            this.panel3.BackgroundImage = global::Team5_XN.Properties.Resources.samhyun_icon;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(230, 80);
            this.panel3.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.DimGray;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(42, 45);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton5,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolSelect});
            this.toolStrip1.Location = new System.Drawing.Point(228, -1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 2, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1056, 83);
            this.toolStrip1.TabIndex = 50;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 80);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 5, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(225, 782);
            this.flowLayoutPanel1.TabIndex = 7;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 45);
            this.button1.TabIndex = 0;
            this.button1.Tag = "0";
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 45);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(225, 45);
            this.button2.TabIndex = 1;
            this.button2.Tag = "1";
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 90);
            this.button3.Margin = new System.Windows.Forms.Padding(0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(225, 45);
            this.button3.TabIndex = 2;
            this.button3.Tag = "2";
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 135);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 625);
            this.panel1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(225, 625);
            this.treeView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(225, 80);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1059, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton5.Image = global::Team5_XN.Properties.Resources.icon_xn_select;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Margin = new System.Windows.Forms.Padding(2, 5, 8, 8);
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripButton5.Size = new System.Drawing.Size(56, 68);
            this.toolStripButton5.Text = "조회";
            this.toolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton4.Image = global::Team5_XN.Properties.Resources.icon_xn_create;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Margin = new System.Windows.Forms.Padding(2, 5, 8, 8);
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripButton4.Size = new System.Drawing.Size(56, 68);
            this.toolStripButton4.Text = "추가";
            this.toolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton3.Image = global::Team5_XN.Properties.Resources.icon_xn_update;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(2, 5, 8, 8);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripButton3.Size = new System.Drawing.Size(56, 68);
            this.toolStripButton3.Text = "편집";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton2.Image = global::Team5_XN.Properties.Resources.icon_xn_delete;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(2, 5, 8, 8);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripButton2.Size = new System.Drawing.Size(56, 68);
            this.toolStripButton2.Text = "삭제";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton1.Image = global::Team5_XN.Properties.Resources.icon_xn_save;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(2, 5, 8, 8);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(56, 68);
            this.toolStripButton1.Text = "저장";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolSelect
            // 
            this.toolSelect.BackColor = System.Drawing.Color.DarkGray;
            this.toolSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolSelect.Image = global::Team5_XN.Properties.Resources.icon_xn_cancle;
            this.toolSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelect.Margin = new System.Windows.Forms.Padding(2, 5, 8, 8);
            this.toolSelect.Name = "toolSelect";
            this.toolSelect.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolSelect.Size = new System.Drawing.Size(56, 68);
            this.toolSelect.Text = "취소";
            this.toolSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 862);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Main";
            this.pnlTop.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSelect;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

