
namespace Team5_XN
{
    partial class frmUserGroup
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
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvUserGroup = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboAdmin = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUseYN = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.txtUserGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.txtUserGroupCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBorder.SuspendLayout();
            this.pnlSubject2.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserGroup)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlBorder.Controls.Add(this.panel1);
            this.pnlBorder.Controls.Add(this.pnlSubject2);
            this.pnlBorder.Controls.Add(this.pnlDgv);
            this.pnlBorder.Controls.Add(this.pnlDetail);
            this.pnlBorder.Controls.Add(this.pnlSelect);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBorder.Size = new System.Drawing.Size(1284, 661);
            this.pnlBorder.TabIndex = 5;
            // 
            // pnlSubject2
            // 
            this.pnlSubject2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSubject2.BackColor = System.Drawing.Color.White;
            this.pnlSubject2.Controls.Add(this.label3);
            this.pnlSubject2.Location = new System.Drawing.Point(5, 546);
            this.pnlSubject2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSubject2.Name = "pnlSubject2";
            this.pnlSubject2.Size = new System.Drawing.Size(1274, 30);
            this.pnlSubject2.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gainsboro;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "입력정보";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDgv
            // 
            this.pnlDgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dgvUserGroup);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Location = new System.Drawing.Point(5, 59);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1274, 488);
            this.pnlDgv.TabIndex = 6;
            // 
            // dgvUserGroup
            // 
            this.dgvUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUserGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserGroup.Location = new System.Drawing.Point(0, 35);
            this.dgvUserGroup.Name = "dgvUserGroup";
            this.dgvUserGroup.RowTemplate.Height = 23;
            this.dgvUserGroup.Size = new System.Drawing.Size(1274, 448);
            this.dgvUserGroup.TabIndex = 1;
            this.dgvUserGroup.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserGroup_CellClick);
            this.dgvUserGroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserGroup_CellContentClick);
            // 
            // pnlSubject1
            // 
            this.pnlSubject1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSubject1.BackColor = System.Drawing.Color.White;
            this.pnlSubject1.Controls.Add(this.label9);
            this.pnlSubject1.Location = new System.Drawing.Point(0, 5);
            this.pnlSubject1.Name = "pnlSubject1";
            this.pnlSubject1.Size = new System.Drawing.Size(1274, 30);
            this.pnlSubject1.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gainsboro;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 30);
            this.label9.TabIndex = 4;
            this.label9.Text = "조회내역";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Location = new System.Drawing.Point(5, 575);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1274, 81);
            this.pnlDetail.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cboAdmin);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtGroupName);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtGroupCode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cboUseYN);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Location = new System.Drawing.Point(5, 575);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 81);
            this.panel1.TabIndex = 12;
            // 
            // cboAdmin
            // 
            this.cboAdmin.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.cboAdmin.FormattingEnabled = true;
            this.cboAdmin.Location = new System.Drawing.Point(463, 44);
            this.cboAdmin.Name = "cboAdmin";
            this.cboAdmin.Size = new System.Drawing.Size(101, 20);
            this.cboAdmin.TabIndex = 37;
            this.cboAdmin.Tag = "Admin";
            this.cboAdmin.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(348, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 36;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label11.Location = new System.Drawing.Point(365, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 23);
            this.label11.TabIndex = 35;
            this.label11.Text = "Admin 여부";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtGroupName.Location = new System.Drawing.Point(463, 13);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(146, 21);
            this.txtGroupName.TabIndex = 34;
            this.txtGroupName.Tag = "UserGroup_Name";
            this.txtGroupName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(348, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 23);
            this.label7.TabIndex = 33;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label8.Location = new System.Drawing.Point(365, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "사용자그룹명";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtGroupCode.Location = new System.Drawing.Point(168, 13);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(131, 21);
            this.txtGroupCode.TabIndex = 31;
            this.txtGroupCode.Tag = "UserGroup_Code";
            this.txtGroupCode.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(43, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label6.Location = new System.Drawing.Point(60, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 23);
            this.label6.TabIndex = 29;
            this.label6.Text = "사용자그룹코드";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboUseYN
            // 
            this.cboUseYN.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.cboUseYN.FormattingEnabled = true;
            this.cboUseYN.Location = new System.Drawing.Point(168, 44);
            this.cboUseYN.Name = "cboUseYN";
            this.cboUseYN.Size = new System.Drawing.Size(101, 20);
            this.cboUseYN.TabIndex = 28;
            this.cboUseYN.Tag = "Use_YN";
            this.cboUseYN.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(43, 41);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 23);
            this.label16.TabIndex = 27;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label17.Location = new System.Drawing.Point(60, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 23);
            this.label17.TabIndex = 26;
            this.label17.Text = "사용여부";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSelect
            // 
            this.pnlSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.txtUserGroupName);
            this.pnlSelect.Controls.Add(this.label2);
            this.pnlSelect.Controls.Add(this.label4);
            this.pnlSelect.Controls.Add(this.cboUse);
            this.pnlSelect.Controls.Add(this.txtUserGroupCode);
            this.pnlSelect.Controls.Add(this.label15);
            this.pnlSelect.Controls.Add(this.label14);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.label13);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Location = new System.Drawing.Point(5, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1274, 54);
            this.pnlSelect.TabIndex = 1;
            // 
            // txtUserGroupName
            // 
            this.txtUserGroupName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtUserGroupName.Location = new System.Drawing.Point(363, 15);
            this.txtUserGroupName.Name = "txtUserGroupName";
            this.txtUserGroupName.Size = new System.Drawing.Size(122, 21);
            this.txtUserGroupName.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(259, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label4.Location = new System.Drawing.Point(271, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 35;
            this.label4.Text = "사용자그룹명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboUse
            // 
            this.cboUse.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(570, 16);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(101, 20);
            this.cboUse.TabIndex = 34;
            // 
            // txtUserGroupCode
            // 
            this.txtUserGroupCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtUserGroupCode.Location = new System.Drawing.Point(155, 15);
            this.txtUserGroupCode.Name = "txtUserGroupCode";
            this.txtUserGroupCode.Size = new System.Drawing.Size(96, 21);
            this.txtUserGroupCode.TabIndex = 28;
            this.txtUserGroupCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(491, 16);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 23);
            this.label15.TabIndex = 32;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(41, 17);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 23);
            this.label14.TabIndex = 31;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label1.Location = new System.Drawing.Point(53, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "사용자그룹코드";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label13.Location = new System.Drawing.Point(505, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 23);
            this.label13.TabIndex = 29;
            this.label13.Text = "사용여부";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 52);
            this.panel2.TabIndex = 0;
            // 
            // frmUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmUserGroup";
            this.Text = "사용자그룹관리";
            this.Load += new System.EventHandler(this.frmUserGroup_Load);
            this.pnlBorder.ResumeLayout(false);
            this.pnlSubject2.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserGroup)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvUserGroup;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.TextBox txtUserGroupCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserGroupName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboUseYN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboAdmin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGroupCode;
    }
}