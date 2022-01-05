
namespace Team5_XN
{
    partial class frmWorkRequest
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rp_txtRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtProjName = new System.Windows.Forms.TextBox();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtReqQty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblProjName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCusName = new System.Windows.Forms.Label();
            this.dtpDeliDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.lblDeliDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReqQty = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvRequest = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoReqDate = new System.Windows.Forms.RadioButton();
            this.rdoDeliDate = new System.Windows.Forms.RadioButton();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.placeholderTextBox1 = new WinReflectionSettings.PlaceholderTextBox();
            this.placeholderTextBox2 = new WinReflectionSettings.PlaceholderTextBox();
            this.txtItemName = new WinReflectionSettings.PlaceholderTextBox();
            this.txtItemCode = new WinReflectionSettings.PlaceholderTextBox();
            this.pnlBorder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlBorder.Controls.Add(this.panel1);
            this.pnlBorder.Controls.Add(this.pnlDgv);
            this.pnlBorder.Controls.Add(this.pnlSelect);
            this.pnlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBorder.Location = new System.Drawing.Point(0, 0);
            this.pnlBorder.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBorder.Name = "pnlBorder";
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(6);
            this.pnlBorder.Size = new System.Drawing.Size(1467, 791);
            this.pnlBorder.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rp_txtRemark);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.lblRemark);
            this.panel1.Controls.Add(this.txtProjName);
            this.panel1.Controls.Add(this.txtCusName);
            this.panel1.Controls.Add(this.txtReqQty);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.lblProjName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblCusName);
            this.panel1.Controls.Add(this.dtpDeliDate);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lblDeliDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lblReqQty);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.placeholderTextBox1);
            this.panel1.Controls.Add(this.placeholderTextBox2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(7, 630);
            this.panel1.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1455, 160);
            this.panel1.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(783, 52);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 25);
            this.dateTimePicker1.TabIndex = 127;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(662, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 29);
            this.label4.TabIndex = 129;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(681, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 29);
            this.label6.TabIndex = 128;
            this.label6.Text = "납기일자";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rp_txtRemark
            // 
            this.rp_txtRemark.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rp_txtRemark.Location = new System.Drawing.Point(783, 83);
            this.rp_txtRemark.Multiline = true;
            this.rp_txtRemark.Name = "rp_txtRemark";
            this.rp_txtRemark.ReadOnly = true;
            this.rp_txtRemark.Size = new System.Drawing.Size(378, 56);
            this.rp_txtRemark.TabIndex = 126;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(662, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 29);
            this.label14.TabIndex = 125;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRemark
            // 
            this.lblRemark.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark.Location = new System.Drawing.Point(681, 79);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(96, 29);
            this.lblRemark.TabIndex = 124;
            this.lblRemark.Text = "비고";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProjName
            // 
            this.txtProjName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProjName.Location = new System.Drawing.Point(156, 114);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.ReadOnly = true;
            this.txtProjName.Size = new System.Drawing.Size(377, 25);
            this.txtProjName.TabIndex = 102;
            // 
            // txtCusName
            // 
            this.txtCusName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCusName.Location = new System.Drawing.Point(157, 83);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.ReadOnly = true;
            this.txtCusName.Size = new System.Drawing.Size(377, 25);
            this.txtCusName.TabIndex = 101;
            // 
            // txtReqQty
            // 
            this.txtReqQty.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReqQty.Location = new System.Drawing.Point(157, 52);
            this.txtReqQty.Name = "txtReqQty";
            this.txtReqQty.ReadOnly = true;
            this.txtReqQty.Size = new System.Drawing.Size(377, 25);
            this.txtReqQty.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(35, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 29);
            this.label7.TabIndex = 99;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProjName
            // 
            this.lblProjName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProjName.Location = new System.Drawing.Point(54, 110);
            this.lblProjName.Name = "lblProjName";
            this.lblProjName.Size = new System.Drawing.Size(96, 29);
            this.lblProjName.TabIndex = 98;
            this.lblProjName.Text = "프로젝트명";
            this.lblProjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(36, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 97;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCusName
            // 
            this.lblCusName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCusName.Location = new System.Drawing.Point(55, 79);
            this.lblCusName.Name = "lblCusName";
            this.lblCusName.Size = new System.Drawing.Size(96, 29);
            this.lblCusName.TabIndex = 96;
            this.lblCusName.Text = "거래처";
            this.lblCusName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDeliDate
            // 
            this.dtpDeliDate.Enabled = false;
            this.dtpDeliDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpDeliDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDeliDate.Location = new System.Drawing.Point(783, 21);
            this.dtpDeliDate.Name = "dtpDeliDate";
            this.dtpDeliDate.Size = new System.Drawing.Size(138, 25);
            this.dtpDeliDate.TabIndex = 91;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(662, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 29);
            this.label11.TabIndex = 95;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeliDate
            // 
            this.lblDeliDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDeliDate.Location = new System.Drawing.Point(681, 17);
            this.lblDeliDate.Name = "lblDeliDate";
            this.lblDeliDate.Size = new System.Drawing.Size(79, 29);
            this.lblDeliDate.TabIndex = 94;
            this.lblDeliDate.Text = "요청일자";
            this.lblDeliDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(36, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 29);
            this.label5.TabIndex = 93;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReqQty
            // 
            this.lblReqQty.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReqQty.Location = new System.Drawing.Point(55, 48);
            this.lblReqQty.Name = "lblReqQty";
            this.lblReqQty.Size = new System.Drawing.Size(96, 29);
            this.lblReqQty.TabIndex = 92;
            this.lblReqQty.Text = "요청수량";
            this.lblReqQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Black;
            this.button2.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(323, 22);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 24);
            this.button2.TabIndex = 58;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(37, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 29);
            this.label2.TabIndex = 53;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(56, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 29);
            this.label3.TabIndex = 48;
            this.label3.Text = "품목";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dgvRequest);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(6, 137);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlDgv.Size = new System.Drawing.Size(1455, 648);
            this.pnlDgv.TabIndex = 6;
            // 
            // dgvRequest
            // 
            this.dgvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRequest.Location = new System.Drawing.Point(0, 44);
            this.dgvRequest.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRequest.Name = "dgvRequest";
            this.dgvRequest.RowHeadersWidth = 51;
            this.dgvRequest.RowTemplate.Height = 23;
            this.dgvRequest.Size = new System.Drawing.Size(1455, 598);
            this.dgvRequest.TabIndex = 1;
            this.dgvRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequest_CellClick);
            this.dgvRequest.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvRequest_CellValidating);
            this.dgvRequest.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRequest_DataError);
            // 
            // pnlSubject1
            // 
            this.pnlSubject1.BackColor = System.Drawing.Color.White;
            this.pnlSubject1.Controls.Add(this.label9);
            this.pnlSubject1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubject1.Location = new System.Drawing.Point(0, 6);
            this.pnlSubject1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSubject1.Name = "pnlSubject1";
            this.pnlSubject1.Size = new System.Drawing.Size(1455, 38);
            this.pnlSubject1.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gainsboro;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 38);
            this.label9.TabIndex = 4;
            this.label9.Text = "생산요청";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.btnRefresh);
            this.pnlSelect.Controls.Add(this.groupBox1);
            this.pnlSelect.Controls.Add(this.btnSearch);
            this.pnlSelect.Controls.Add(this.label8);
            this.pnlSelect.Controls.Add(this.txtItemName);
            this.pnlSelect.Controls.Add(this.txtItemCode);
            this.pnlSelect.Controls.Add(this.label10);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(6, 6);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1455, 131);
            this.pnlSelect.TabIndex = 1;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(589, 26);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(117, 42);
            this.btnRefresh.TabIndex = 89;
            this.btnRefresh.Text = "검색초기화";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoReqDate);
            this.groupBox1.Controls.Add(this.rdoDeliDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(37, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 61);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "* 기간검색";
            // 
            // rdoReqDate
            // 
            this.rdoReqDate.AutoSize = true;
            this.rdoReqDate.Checked = true;
            this.rdoReqDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoReqDate.Location = new System.Drawing.Point(15, 24);
            this.rdoReqDate.Name = "rdoReqDate";
            this.rdoReqDate.Size = new System.Drawing.Size(100, 23);
            this.rdoReqDate.TabIndex = 59;
            this.rdoReqDate.TabStop = true;
            this.rdoReqDate.Tag = "Req_Date";
            this.rdoReqDate.Text = "생산요청일";
            this.rdoReqDate.UseVisualStyleBackColor = true;
            // 
            // rdoDeliDate
            // 
            this.rdoDeliDate.AutoSize = true;
            this.rdoDeliDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoDeliDate.Location = new System.Drawing.Point(121, 24);
            this.rdoDeliDate.Name = "rdoDeliDate";
            this.rdoDeliDate.Size = new System.Drawing.Size(72, 23);
            this.rdoDeliDate.TabIndex = 60;
            this.rdoDeliDate.Tag = "Delivery_Date";
            this.rdoDeliDate.Text = "납기일";
            this.rdoDeliDate.UseVisualStyleBackColor = true;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(203, 24);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(139, 25);
            this.dtpFromDate.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(345, 21);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 29);
            this.label17.TabIndex = 33;
            this.label17.Text = "~";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(374, 24);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(139, 25);
            this.dtpToDate.TabIndex = 34;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(324, 93);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 24);
            this.btnSearch.TabIndex = 58;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(38, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 29);
            this.label8.TabIndex = 53;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(57, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 29);
            this.label10.TabIndex = 48;
            this.label10.Text = "품목";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 129);
            this.panel2.TabIndex = 0;
            // 
            // placeholderTextBox1
            // 
            this.placeholderTextBox1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.placeholderTextBox1.Location = new System.Drawing.Point(354, 21);
            this.placeholderTextBox1.Name = "placeholderTextBox1";
            this.placeholderTextBox1.PlaceholderText = "품목 명";
            this.placeholderTextBox1.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.placeholderTextBox1.ReadOnly = true;
            this.placeholderTextBox1.Size = new System.Drawing.Size(226, 25);
            this.placeholderTextBox1.TabIndex = 52;
            // 
            // placeholderTextBox2
            // 
            this.placeholderTextBox2.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.placeholderTextBox2.Location = new System.Drawing.Point(156, 21);
            this.placeholderTextBox2.Name = "placeholderTextBox2";
            this.placeholderTextBox2.PlaceholderText = "품목 코드";
            this.placeholderTextBox2.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.placeholderTextBox2.ReadOnly = true;
            this.placeholderTextBox2.Size = new System.Drawing.Size(161, 25);
            this.placeholderTextBox2.TabIndex = 51;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName.Location = new System.Drawing.Point(355, 92);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.PlaceholderText = "품목 명";
            this.txtItemName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(226, 25);
            this.txtItemName.TabIndex = 52;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemCode.Location = new System.Drawing.Point(157, 92);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.PlaceholderText = "품목 코드";
            this.txtItemCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(161, 25);
            this.txtItemCode.TabIndex = 51;
            // 
            // frmWorkRequest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1467, 791);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmWorkRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "생산요청 관리";
            this.Load += new System.EventHandler(this.frmWorkRequest_Load);
            this.pnlBorder.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvRequest;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label8;
        private WinReflectionSettings.PlaceholderTextBox txtItemName;
        private WinReflectionSettings.PlaceholderTextBox txtItemCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoReqDate;
        private System.Windows.Forms.RadioButton rdoDeliDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private WinReflectionSettings.PlaceholderTextBox placeholderTextBox1;
        private WinReflectionSettings.PlaceholderTextBox placeholderTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtReqQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblProjName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.DateTimePicker dtpDeliDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDeliDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReqQty;
        private System.Windows.Forms.TextBox rp_txtRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
    }
}