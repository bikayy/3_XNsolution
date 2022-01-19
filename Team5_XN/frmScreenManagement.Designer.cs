
namespace Team5_XN
{
    partial class frmScreenManagement
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
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvScreen = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtWordKey = new System.Windows.Forms.TextBox();
            this.cboUseYN = new System.Windows.Forms.ComboBox();
            this.cboMonitor = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtScreenPath = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtScreenCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSearchScreen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlBorder.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScreen)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSubject2.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dgvScreen);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(5, 59);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1274, 435);
            this.pnlDgv.TabIndex = 6;
            // 
            // dgvScreen
            // 
            this.dgvScreen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScreen.Location = new System.Drawing.Point(0, 35);
            this.dgvScreen.Name = "dgvScreen";
            this.dgvScreen.RowTemplate.Height = 23;
            this.dgvScreen.Size = new System.Drawing.Size(1274, 395);
            this.dgvScreen.TabIndex = 1;
            this.dgvScreen.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvScreen_CellClick);
            // 
            // pnlSubject1
            // 
            this.pnlSubject1.BackColor = System.Drawing.Color.White;
            this.pnlSubject1.Controls.Add(this.label9);
            this.pnlSubject1.Dock = System.Windows.Forms.DockStyle.Top;
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
            this.pnlDetail.Controls.Add(this.panel1);
            this.pnlDetail.Controls.Add(this.pnlSubject2);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(5, 494);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1274, 162);
            this.pnlDetail.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtWordKey);
            this.panel1.Controls.Add(this.cboUseYN);
            this.panel1.Controls.Add(this.cboMonitor);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtScreenPath);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtScreenCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtSearchScreen);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 132);
            this.panel1.TabIndex = 12;
            // 
            // txtWordKey
            // 
            this.txtWordKey.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtWordKey.Location = new System.Drawing.Point(315, 54);
            this.txtWordKey.Name = "txtWordKey";
            this.txtWordKey.Size = new System.Drawing.Size(204, 22);
            this.txtWordKey.TabIndex = 81;
            // 
            // cboUseYN
            // 
            this.cboUseYN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseYN.FormattingEnabled = true;
            this.cboUseYN.Location = new System.Drawing.Point(710, 26);
            this.cboUseYN.Name = "cboUseYN";
            this.cboUseYN.Size = new System.Drawing.Size(77, 20);
            this.cboUseYN.TabIndex = 79;
            // 
            // cboMonitor
            // 
            this.cboMonitor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonitor.FormattingEnabled = true;
            this.cboMonitor.Location = new System.Drawing.Point(710, 53);
            this.cboMonitor.Name = "cboMonitor";
            this.cboMonitor.Size = new System.Drawing.Size(77, 20);
            this.cboMonitor.TabIndex = 78;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(592, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 77;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label11.Location = new System.Drawing.Point(609, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 23);
            this.label11.TabIndex = 76;
            this.label11.Text = "모니터링 유무";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(592, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(20, 23);
            this.label19.TabIndex = 73;
            this.label19.Text = "*";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label20.Location = new System.Drawing.Point(609, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 23);
            this.label20.TabIndex = 72;
            this.label20.Text = "사용유무";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(286, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 70;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(42, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 23);
            this.label5.TabIndex = 22;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScreenPath
            // 
            this.txtScreenPath.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtScreenPath.Location = new System.Drawing.Point(133, 82);
            this.txtScreenPath.Name = "txtScreenPath";
            this.txtScreenPath.Size = new System.Drawing.Size(231, 22);
            this.txtScreenPath.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label8.Location = new System.Drawing.Point(59, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "화면경로";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(42, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScreenCode
            // 
            this.txtScreenCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtScreenCode.Location = new System.Drawing.Point(133, 25);
            this.txtScreenCode.Name = "txtScreenCode";
            this.txtScreenCode.Size = new System.Drawing.Size(147, 22);
            this.txtScreenCode.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label2.Location = new System.Drawing.Point(59, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "화면코드";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(42, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearchScreen
            // 
            this.txtSearchScreen.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtSearchScreen.Location = new System.Drawing.Point(133, 54);
            this.txtSearchScreen.Name = "txtSearchScreen";
            this.txtSearchScreen.Size = new System.Drawing.Size(147, 22);
            this.txtSearchScreen.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label4.Location = new System.Drawing.Point(59, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "화면명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSubject2
            // 
            this.pnlSubject2.BackColor = System.Drawing.Color.White;
            this.pnlSubject2.Controls.Add(this.label3);
            this.pnlSubject2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubject2.Location = new System.Drawing.Point(0, 0);
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
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.txtCode);
            this.pnlSelect.Controls.Add(this.txtName);
            this.pnlSelect.Controls.Add(this.cboUse);
            this.pnlSelect.Controls.Add(this.label15);
            this.pnlSelect.Controls.Add(this.label16);
            this.pnlSelect.Controls.Add(this.label13);
            this.pnlSelect.Controls.Add(this.label14);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Controls.Add(this.label12);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(5, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1274, 54);
            this.pnlSelect.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtCode.Location = new System.Drawing.Point(112, 14);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(133, 22);
            this.txtCode.TabIndex = 82;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.txtName.Location = new System.Drawing.Point(418, 15);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 22);
            this.txtName.TabIndex = 83;
            // 
            // cboUse
            // 
            this.cboUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(710, 16);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(97, 20);
            this.cboUse.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(634, 16);
            this.label15.Margin = new System.Windows.Forms.Padding(0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(17, 23);
            this.label15.TabIndex = 30;
            this.label15.Text = "*";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label16.Location = new System.Drawing.Point(648, 14);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(66, 23);
            this.label16.TabIndex = 29;
            this.label16.Text = "사용유무";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(347, 17);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 23);
            this.label13.TabIndex = 27;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label14.Location = new System.Drawing.Point(361, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 23);
            this.label14.TabIndex = 26;
            this.label14.Text = "화면명";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8.25F);
            this.label12.Location = new System.Drawing.Point(42, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 23);
            this.label12.TabIndex = 23;
            this.label12.Text = "화면코드";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmScreenManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmScreenManagement";
            this.Text = "화면관리";
            this.Load += new System.EventHandler(this.frmScreenManagement_Load);
            this.pnlBorder.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScreen)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSubject2.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvScreen;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtScreenCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearchScreen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtScreenPath;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboUseYN;
        private System.Windows.Forms.ComboBox cboMonitor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtWordKey;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
    }
}