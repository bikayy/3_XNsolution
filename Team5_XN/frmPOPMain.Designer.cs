
namespace Team5_XN
{
    partial class frmPOPMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.작업장선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.작업지시현황ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.비가동등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.작업장선택ToolStripMenuItem,
            this.작업지시현황ToolStripMenuItem,
            this.비가동등록ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1482, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 작업장선택ToolStripMenuItem
            // 
            this.작업장선택ToolStripMenuItem.Name = "작업장선택ToolStripMenuItem";
            this.작업장선택ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.작업장선택ToolStripMenuItem.Text = "작업장 선택";
            this.작업장선택ToolStripMenuItem.Click += new System.EventHandler(this.작업장선택ToolStripMenuItem_Click);
            // 
            // 작업지시현황ToolStripMenuItem
            // 
            this.작업지시현황ToolStripMenuItem.Name = "작업지시현황ToolStripMenuItem";
            this.작업지시현황ToolStripMenuItem.Size = new System.Drawing.Size(113, 24);
            this.작업지시현황ToolStripMenuItem.Text = "작업지시현황";
            this.작업지시현황ToolStripMenuItem.Click += new System.EventHandler(this.작업지시현황ToolStripMenuItem_Click);
            // 
            // 비가동등록ToolStripMenuItem
            // 
            this.비가동등록ToolStripMenuItem.Name = "비가동등록ToolStripMenuItem";
            this.비가동등록ToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.비가동등록ToolStripMenuItem.Text = "비가동 등록";
            this.비가동등록ToolStripMenuItem.Click += new System.EventHandler(this.비가동등록ToolStripMenuItem_Click);
            // 
            // frmPOPMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 953);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPOPMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POP";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 작업장선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 작업지시현황ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 비가동등록ToolStripMenuItem;
    }
}