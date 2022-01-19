
namespace POP_Team5_XN
{
    partial class ucNopHistory
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNopMinute = new System.Windows.Forms.Label();
            this.lblNopMi = new System.Windows.Forms.Label();
            this.lblNopMa = new System.Windows.Forms.Label();
            this.lblWcName = new System.Windows.Forms.Label();
            this.lblNopTime = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblNopMinute, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNopMi, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNopMa, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWcName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNopTime, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(644, 100);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblNopMinute
            // 
            this.lblNopMinute.AutoSize = true;
            this.lblNopMinute.BackColor = System.Drawing.Color.Transparent;
            this.lblNopMinute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNopMinute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNopMinute.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNopMinute.ForeColor = System.Drawing.Color.Black;
            this.lblNopMinute.Location = new System.Drawing.Point(512, 0);
            this.lblNopMinute.Margin = new System.Windows.Forms.Padding(0);
            this.lblNopMinute.Name = "lblNopMinute";
            this.lblNopMinute.Size = new System.Drawing.Size(132, 100);
            this.lblNopMinute.TabIndex = 4;
            this.lblNopMinute.Text = "비가동\r\n시간(분)";
            this.lblNopMinute.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNopMinute.Click += new System.EventHandler(this.ucNopHistory_Click);
            // 
            // lblNopMi
            // 
            this.lblNopMi.AutoSize = true;
            this.lblNopMi.BackColor = System.Drawing.Color.Transparent;
            this.lblNopMi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNopMi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNopMi.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNopMi.ForeColor = System.Drawing.Color.Black;
            this.lblNopMi.Location = new System.Drawing.Point(256, 0);
            this.lblNopMi.Margin = new System.Windows.Forms.Padding(0);
            this.lblNopMi.Name = "lblNopMi";
            this.lblNopMi.Size = new System.Drawing.Size(128, 100);
            this.lblNopMi.TabIndex = 2;
            this.lblNopMi.Text = "비가동\r\n상세분류";
            this.lblNopMi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNopMi.Click += new System.EventHandler(this.ucNopHistory_Click);
            // 
            // lblNopMa
            // 
            this.lblNopMa.AutoSize = true;
            this.lblNopMa.BackColor = System.Drawing.Color.Transparent;
            this.lblNopMa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNopMa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNopMa.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNopMa.ForeColor = System.Drawing.Color.Black;
            this.lblNopMa.Location = new System.Drawing.Point(128, 0);
            this.lblNopMa.Margin = new System.Windows.Forms.Padding(0);
            this.lblNopMa.Name = "lblNopMa";
            this.lblNopMa.Size = new System.Drawing.Size(128, 100);
            this.lblNopMa.TabIndex = 1;
            this.lblNopMa.Text = "비가동\r\n대분류";
            this.lblNopMa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNopMa.Click += new System.EventHandler(this.ucNopHistory_Click);
            // 
            // lblWcName
            // 
            this.lblWcName.AutoSize = true;
            this.lblWcName.BackColor = System.Drawing.Color.Transparent;
            this.lblWcName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblWcName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWcName.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWcName.ForeColor = System.Drawing.Color.Black;
            this.lblWcName.Location = new System.Drawing.Point(0, 0);
            this.lblWcName.Margin = new System.Windows.Forms.Padding(0);
            this.lblWcName.Name = "lblWcName";
            this.lblWcName.Size = new System.Drawing.Size(128, 100);
            this.lblWcName.TabIndex = 0;
            this.lblWcName.Text = "작업장";
            this.lblWcName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWcName.Click += new System.EventHandler(this.ucNopHistory_Click);
            // 
            // lblNopTime
            // 
            this.lblNopTime.AutoSize = true;
            this.lblNopTime.BackColor = System.Drawing.Color.Transparent;
            this.lblNopTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNopTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNopTime.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNopTime.ForeColor = System.Drawing.Color.Black;
            this.lblNopTime.Location = new System.Drawing.Point(384, 0);
            this.lblNopTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblNopTime.Name = "lblNopTime";
            this.lblNopTime.Size = new System.Drawing.Size(128, 100);
            this.lblNopTime.TabIndex = 3;
            this.lblNopTime.Text = "발생시";
            this.lblNopTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNopTime.Click += new System.EventHandler(this.ucNopHistory_Click);
            // 
            // ucNopHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucNopHistory";
            this.Size = new System.Drawing.Size(644, 101);
            this.Click += new System.EventHandler(this.ucNopHistory_Click);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNopMinute;
        private System.Windows.Forms.Label lblNopMi;
        private System.Windows.Forms.Label lblNopMa;
        private System.Windows.Forms.Label lblWcName;
        private System.Windows.Forms.Label lblNopTime;
    }
}
