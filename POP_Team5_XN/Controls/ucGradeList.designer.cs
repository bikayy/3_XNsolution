
namespace POP_Team5_XN
{
    partial class ucGradeList
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.41463F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.58537F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 320F));
            this.tableLayoutPanel3.Controls.Add(this.panel13, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel12, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.panel6, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(573, 96);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.lblName);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(255, 3);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(315, 90);
            this.panel13.TabIndex = 3;
            this.panel13.Click += new System.EventHandler(this.gradeClick);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(20, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 25);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "하품";
            this.lblName.Click += new System.EventHandler(this.gradeClick);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.White;
            this.panel12.Controls.Add(this.lblCode);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(36, 3);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(213, 90);
            this.panel12.TabIndex = 2;
            this.panel12.Click += new System.EventHandler(this.gradeClick);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.BackColor = System.Drawing.Color.Transparent;
            this.lblCode.Font = new System.Drawing.Font("맑은 고딕", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(70, 33);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(68, 25);
            this.lblCode.TabIndex = 4;
            this.lblCode.Text = "C2000";
            this.lblCode.Click += new System.EventHandler(this.gradeClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(27, 90);
            this.panel6.TabIndex = 1;
            // 
            // ucGradeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "ucGradeList";
            this.Size = new System.Drawing.Size(577, 101);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Panel panel6;
    }
}
