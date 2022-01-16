
namespace Team5_XN
{
    partial class ucWorkCenterList
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tpnlWc = new System.Windows.Forms.TableLayoutPanel();
            this.pnlWcGroup = new System.Windows.Forms.Panel();
            this.lblWcGroup = new System.Windows.Forms.Label();
            this.pnlWcName = new System.Windows.Forms.Panel();
            this.lblWcName = new System.Windows.Forms.Label();
            this.pnlWcStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tpnlWc.SuspendLayout();
            this.pnlWcGroup.SuspendLayout();
            this.pnlWcName.SuspendLayout();
            this.pnlWcStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpnlWc
            // 
            this.tpnlWc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpnlWc.ColumnCount = 3;
            this.tpnlWc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.62857F));
            this.tpnlWc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.85714F));
            this.tpnlWc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.62857F));
            this.tpnlWc.Controls.Add(this.pnlWcGroup, 2, 0);
            this.tpnlWc.Controls.Add(this.pnlWcName, 1, 0);
            this.tpnlWc.Controls.Add(this.pnlWcStatus, 0, 0);
            this.tpnlWc.Location = new System.Drawing.Point(3, 4);
            this.tpnlWc.Name = "tpnlWc";
            this.tpnlWc.RowCount = 1;
            this.tpnlWc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlWc.Size = new System.Drawing.Size(875, 78);
            this.tpnlWc.TabIndex = 1;
            // 
            // pnlWcGroup
            // 
            this.pnlWcGroup.BackColor = System.Drawing.Color.White;
            this.pnlWcGroup.Controls.Add(this.lblWcGroup);
            this.pnlWcGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWcGroup.ForeColor = System.Drawing.Color.Black;
            this.pnlWcGroup.Location = new System.Drawing.Point(679, 3);
            this.pnlWcGroup.Name = "pnlWcGroup";
            this.pnlWcGroup.Size = new System.Drawing.Size(193, 72);
            this.pnlWcGroup.TabIndex = 2;
            this.pnlWcGroup.Click += new System.EventHandler(this.WcClick);
            // 
            // lblWcGroup
            // 
            this.lblWcGroup.AutoSize = true;
            this.lblWcGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblWcGroup.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWcGroup.ForeColor = System.Drawing.Color.Black;
            this.lblWcGroup.Location = new System.Drawing.Point(72, 20);
            this.lblWcGroup.Name = "lblWcGroup";
            this.lblWcGroup.Size = new System.Drawing.Size(53, 32);
            this.lblWcGroup.TabIndex = 5;
            this.lblWcGroup.Text = "W1";
            this.lblWcGroup.Click += new System.EventHandler(this.WcClick);
            // 
            // pnlWcName
            // 
            this.pnlWcName.BackColor = System.Drawing.Color.White;
            this.pnlWcName.Controls.Add(this.lblWcName);
            this.pnlWcName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWcName.ForeColor = System.Drawing.Color.White;
            this.pnlWcName.Location = new System.Drawing.Point(165, 3);
            this.pnlWcName.Name = "pnlWcName";
            this.pnlWcName.Size = new System.Drawing.Size(508, 72);
            this.pnlWcName.TabIndex = 1;
            this.pnlWcName.Click += new System.EventHandler(this.WcClick);
            // 
            // lblWcName
            // 
            this.lblWcName.AutoSize = true;
            this.lblWcName.BackColor = System.Drawing.Color.Transparent;
            this.lblWcName.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWcName.ForeColor = System.Drawing.Color.Black;
            this.lblWcName.Location = new System.Drawing.Point(162, 20);
            this.lblWcName.Name = "lblWcName";
            this.lblWcName.Size = new System.Drawing.Size(189, 32);
            this.lblWcName.TabIndex = 4;
            this.lblWcName.Text = "시유 1라인(W1)";
            this.lblWcName.Click += new System.EventHandler(this.WcClick);
            // 
            // pnlWcStatus
            // 
            this.pnlWcStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.pnlWcStatus.Controls.Add(this.lblStatus);
            this.pnlWcStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWcStatus.ForeColor = System.Drawing.Color.White;
            this.pnlWcStatus.Location = new System.Drawing.Point(3, 3);
            this.pnlWcStatus.Name = "pnlWcStatus";
            this.pnlWcStatus.Size = new System.Drawing.Size(156, 72);
            this.pnlWcStatus.TabIndex = 0;
            this.pnlWcStatus.Click += new System.EventHandler(this.WcClick);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(46, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 32);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "가동";
            this.lblStatus.Click += new System.EventHandler(this.WcClick);
            // 
            // ucWorkCenterList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tpnlWc);
            this.Name = "ucWorkCenterList";
            this.Size = new System.Drawing.Size(882, 86);
            this.Load += new System.EventHandler(this.ucWorkCenterList_Load);
            this.tpnlWc.ResumeLayout(false);
            this.pnlWcGroup.ResumeLayout(false);
            this.pnlWcGroup.PerformLayout();
            this.pnlWcName.ResumeLayout(false);
            this.pnlWcName.PerformLayout();
            this.pnlWcStatus.ResumeLayout(false);
            this.pnlWcStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnlWc;
        private System.Windows.Forms.Panel pnlWcGroup;
        private System.Windows.Forms.Label lblWcGroup;
        private System.Windows.Forms.Panel pnlWcName;
        private System.Windows.Forms.Label lblWcName;
        private System.Windows.Forms.Panel pnlWcStatus;
        private System.Windows.Forms.Label lblStatus;
    }
}
