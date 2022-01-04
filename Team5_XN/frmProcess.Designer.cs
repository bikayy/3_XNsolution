
namespace Team5_XN
{
    partial class frmProcess
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
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDetail2 = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.cboProcessGroup = new System.Windows.Forms.ComboBox();
            this.cboUse_YN = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProcessCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboSelectUse_YN = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSelectProcessName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSelectProcessCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlDetail2.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlSubject2.SuspendLayout();
            this.pnlBorder.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dataGridView1);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(5, 55);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1274, 478);
            this.pnlDgv.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 438);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            this.dataGridView1.Leave += new System.EventHandler(this.dataGridView1_Leave);
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
            // pnlDetail2
            // 
            this.pnlDetail2.BackColor = System.Drawing.Color.White;
            this.pnlDetail2.Controls.Add(this.pnlDetail);
            this.pnlDetail2.Controls.Add(this.pnlSubject2);
            this.pnlDetail2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail2.Location = new System.Drawing.Point(5, 533);
            this.pnlDetail2.Name = "pnlDetail2";
            this.pnlDetail2.Size = new System.Drawing.Size(1274, 123);
            this.pnlDetail2.TabIndex = 4;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.label8);
            this.pnlDetail.Controls.Add(this.cboProcessGroup);
            this.pnlDetail.Controls.Add(this.cboUse_YN);
            this.pnlDetail.Controls.Add(this.label39);
            this.pnlDetail.Controls.Add(this.txtRemark);
            this.pnlDetail.Controls.Add(this.label44);
            this.pnlDetail.Controls.Add(this.label43);
            this.pnlDetail.Controls.Add(this.label40);
            this.pnlDetail.Controls.Add(this.label6);
            this.pnlDetail.Controls.Add(this.txtProcessCode);
            this.pnlDetail.Controls.Add(this.label2);
            this.pnlDetail.Controls.Add(this.label7);
            this.pnlDetail.Controls.Add(this.txtProcessName);
            this.pnlDetail.Controls.Add(this.label4);
            this.pnlDetail.Controls.Add(this.label5);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 30);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1274, 93);
            this.pnlDetail.TabIndex = 12;
            // 
            // cboProcessGroup
            // 
            this.cboProcessGroup.BackColor = System.Drawing.Color.White;
            this.cboProcessGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcessGroup.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboProcessGroup.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboProcessGroup.FormattingEnabled = true;
            this.cboProcessGroup.Location = new System.Drawing.Point(110, 61);
            this.cboProcessGroup.Name = "cboProcessGroup";
            this.cboProcessGroup.Size = new System.Drawing.Size(121, 21);
            this.cboProcessGroup.TabIndex = 69;
            this.cboProcessGroup.Tag = "Process_Group";
            this.cboProcessGroup.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.cboProcessGroup.Leave += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // cboUse_YN
            // 
            this.cboUse_YN.BackColor = System.Drawing.Color.White;
            this.cboUse_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse_YN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboUse_YN.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUse_YN.FormattingEnabled = true;
            this.cboUse_YN.Location = new System.Drawing.Point(484, 7);
            this.cboUse_YN.Name = "cboUse_YN";
            this.cboUse_YN.Size = new System.Drawing.Size(121, 21);
            this.cboUse_YN.TabIndex = 4;
            this.cboUse_YN.Tag = "Use_YN";
            this.cboUse_YN.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.cboUse_YN.Leave += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(339, 36);
            this.label39.Margin = new System.Windows.Forms.Padding(0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(17, 23);
            this.label39.TabIndex = 68;
            this.label39.Text = "*";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.Location = new System.Drawing.Point(484, 34);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(290, 47);
            this.txtRemark.TabIndex = 3;
            this.txtRemark.Tag = "Remark";
            this.txtRemark.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtRemark.Leave += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(353, 36);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(125, 23);
            this.label44.TabIndex = 66;
            this.label44.Text = "비고";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label43.ForeColor = System.Drawing.Color.Red;
            this.label43.Location = new System.Drawing.Point(336, 10);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(20, 23);
            this.label43.TabIndex = 65;
            this.label43.Text = "*";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(353, 10);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(125, 23);
            this.label40.TabIndex = 62;
            this.label40.Text = "사용유무";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(7, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProcessCode.Location = new System.Drawing.Point(110, 8);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(151, 22);
            this.txtProcessCode.TabIndex = 0;
            this.txtProcessCode.Tag = "Process_Code";
            this.txtProcessCode.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtProcessCode.Leave += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(24, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "공정코드";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(7, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProcessName.Location = new System.Drawing.Point(110, 34);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(151, 22);
            this.txtProcessName.TabIndex = 1;
            this.txtProcessName.Tag = "Process_Name";
            this.txtProcessName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtProcessName.Leave += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(24, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "공정명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(24, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "공정그룹";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlBorder.Controls.Add(this.pnlDgv);
            this.pnlBorder.Controls.Add(this.pnlDetail2);
            this.pnlBorder.Controls.Add(this.pnlSelect);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(5);
            this.pnlBorder.Size = new System.Drawing.Size(1284, 661);
            this.pnlBorder.TabIndex = 6;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.button1);
            this.pnlSelect.Controls.Add(this.label13);
            this.pnlSelect.Controls.Add(this.label11);
            this.pnlSelect.Controls.Add(this.label10);
            this.pnlSelect.Controls.Add(this.cboSelectUse_YN);
            this.pnlSelect.Controls.Add(this.label14);
            this.pnlSelect.Controls.Add(this.txtSelectProcessName);
            this.pnlSelect.Controls.Add(this.label12);
            this.pnlSelect.Controls.Add(this.txtSelectProcessCode);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(5, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1274, 50);
            this.pnlSelect.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1171, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 105;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(572, 13);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 23);
            this.label13.TabIndex = 104;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(289, 14);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 23);
            this.label11.TabIndex = 103;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(23, 15);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 23);
            this.label10.TabIndex = 102;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSelectUse_YN
            // 
            this.cboSelectUse_YN.BackColor = System.Drawing.Color.White;
            this.cboSelectUse_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectUse_YN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSelectUse_YN.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSelectUse_YN.FormattingEnabled = true;
            this.cboSelectUse_YN.Location = new System.Drawing.Point(672, 13);
            this.cboSelectUse_YN.Name = "cboSelectUse_YN";
            this.cboSelectUse_YN.Size = new System.Drawing.Size(121, 21);
            this.cboSelectUse_YN.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(590, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 23);
            this.label14.TabIndex = 13;
            this.label14.Text = "사용유무";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSelectProcessName
            // 
            this.txtSelectProcessName.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectProcessName.Location = new System.Drawing.Point(389, 13);
            this.txtSelectProcessName.Name = "txtSelectProcessName";
            this.txtSelectProcessName.Size = new System.Drawing.Size(122, 22);
            this.txtSelectProcessName.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(307, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 8;
            this.label12.Text = "공정명";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSelectProcessCode
            // 
            this.txtSelectProcessCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectProcessCode.Location = new System.Drawing.Point(121, 14);
            this.txtSelectProcessCode.Name = "txtSelectProcessCode";
            this.txtSelectProcessCode.Size = new System.Drawing.Size(122, 22);
            this.txtSelectProcessCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "공정코드";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 48);
            this.panel2.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(7, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 23);
            this.label8.TabIndex = 70;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmProcess";
            this.Text = "공정관리";
            this.Load += new System.EventHandler(this.frmProcess_Load);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlDetail2.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlSubject2.ResumeLayout(false);
            this.pnlBorder.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDetail2;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.ComboBox cboSelectUse_YN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSelectProcessName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSelectProcessCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.ComboBox cboProcessGroup;
        private System.Windows.Forms.ComboBox cboUse_YN;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
    }
}