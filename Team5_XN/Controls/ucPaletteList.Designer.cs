
namespace Team5_XN
{
    partial class ucPaletteList
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.lblQty = new System.Windows.Forms.Label();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.lblGradeDetail = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.lblGrade = new System.Windows.Forms.Label();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.lblPaletteNo = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.LightGray;
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel2.Controls.Add(this.pnl4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnl3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnl2, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.pnl1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(-1, -1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(714, 63);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // pnl4
            // 
            this.pnl4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(154)))));
            this.pnl4.Controls.Add(this.lblQty);
            this.pnl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl4.Location = new System.Drawing.Point(594, 3);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(117, 57);
            this.pnl4.TabIndex = 3;
            // 
            // lblQty
            // 
            this.lblQty.BackColor = System.Drawing.Color.Transparent;
            this.lblQty.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQty.ForeColor = System.Drawing.Color.Black;
            this.lblQty.Location = new System.Drawing.Point(20, 12);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(80, 32);
            this.lblQty.TabIndex = 6;
            this.lblQty.Text = "수량";
            this.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl3
            // 
            this.pnl3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(154)))));
            this.pnl3.Controls.Add(this.lblGradeDetail);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl3.Location = new System.Drawing.Point(323, 3);
            this.pnl3.Name = "pnl3";
            this.pnl3.Size = new System.Drawing.Size(265, 57);
            this.pnl3.TabIndex = 2;
            // 
            // lblGradeDetail
            // 
            this.lblGradeDetail.BackColor = System.Drawing.Color.Transparent;
            this.lblGradeDetail.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGradeDetail.ForeColor = System.Drawing.Color.Black;
            this.lblGradeDetail.Location = new System.Drawing.Point(72, 12);
            this.lblGradeDetail.Name = "lblGradeDetail";
            this.lblGradeDetail.Size = new System.Drawing.Size(118, 32);
            this.lblGradeDetail.TabIndex = 5;
            this.lblGradeDetail.Text = "등급상세";
            this.lblGradeDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(154)))));
            this.pnl2.Controls.Add(this.lblGrade);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl2.Location = new System.Drawing.Point(202, 3);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(115, 57);
            this.pnl2.TabIndex = 1;
            // 
            // lblGrade
            // 
            this.lblGrade.BackColor = System.Drawing.Color.Transparent;
            this.lblGrade.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGrade.ForeColor = System.Drawing.Color.Black;
            this.lblGrade.Location = new System.Drawing.Point(18, 12);
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new System.Drawing.Size(80, 32);
            this.lblGrade.TabIndex = 5;
            this.lblGrade.Text = "등급";
            this.lblGrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl1
            // 
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(80)))), ((int)(((byte)(154)))));
            this.pnl1.Controls.Add(this.lblPaletteNo);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Location = new System.Drawing.Point(3, 3);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(193, 57);
            this.pnl1.TabIndex = 0;
            // 
            // lblPaletteNo
            // 
            this.lblPaletteNo.BackColor = System.Drawing.Color.Transparent;
            this.lblPaletteNo.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPaletteNo.ForeColor = System.Drawing.Color.Black;
            this.lblPaletteNo.Location = new System.Drawing.Point(39, 12);
            this.lblPaletteNo.Name = "lblPaletteNo";
            this.lblPaletteNo.Size = new System.Drawing.Size(118, 32);
            this.lblPaletteNo.TabIndex = 4;
            this.lblPaletteNo.Text = "팔렛번호";
            this.lblPaletteNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPaletteList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ucPaletteList";
            this.Size = new System.Drawing.Size(713, 61);
            this.Load += new System.EventHandler(this.ucPaletteList_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.pnl4.ResumeLayout(false);
            this.pnl3.ResumeLayout(false);
            this.pnl2.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.Panel pnl4;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Label lblPaletteNo;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label lblGradeDetail;
        private System.Windows.Forms.Label lblGrade;
    }
}
