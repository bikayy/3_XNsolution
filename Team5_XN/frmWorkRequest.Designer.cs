
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
            this.txtItemName = new WinReflectionSettings.PlaceholderTextBox();
            this.txtItemCode = new WinReflectionSettings.PlaceholderTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.txtReqNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblReqNo = new System.Windows.Forms.Label();
            this.dtpReqDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDeliDate = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
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
            this.lblReqDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReqQty = new System.Windows.Forms.Label();
            this.r_btnItemSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.r_txtItemName = new WinReflectionSettings.PlaceholderTextBox();
            this.r_txtItemCode = new WinReflectionSettings.PlaceholderTextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.pnlBorder.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBorder
            // 
            this.pnlBorder.BackColor = System.Drawing.SystemColors.ButtonFace;
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
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.pnlDetail);
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
            this.btnRefresh.Location = new System.Drawing.Point(875, 52);
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
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetail.Controls.Add(this.txtReqNo);
            this.pnlDetail.Controls.Add(this.label3);
            this.pnlDetail.Controls.Add(this.lblReqNo);
            this.pnlDetail.Controls.Add(this.dtpReqDate);
            this.pnlDetail.Controls.Add(this.label4);
            this.pnlDetail.Controls.Add(this.lblDeliDate);
            this.pnlDetail.Controls.Add(this.txtRemark);
            this.pnlDetail.Controls.Add(this.label14);
            this.pnlDetail.Controls.Add(this.lblRemark);
            this.pnlDetail.Controls.Add(this.txtProjName);
            this.pnlDetail.Controls.Add(this.txtCusName);
            this.pnlDetail.Controls.Add(this.txtReqQty);
            this.pnlDetail.Controls.Add(this.label7);
            this.pnlDetail.Controls.Add(this.lblProjName);
            this.pnlDetail.Controls.Add(this.label1);
            this.pnlDetail.Controls.Add(this.lblCusName);
            this.pnlDetail.Controls.Add(this.dtpDeliDate);
            this.pnlDetail.Controls.Add(this.label11);
            this.pnlDetail.Controls.Add(this.lblReqDate);
            this.pnlDetail.Controls.Add(this.label5);
            this.pnlDetail.Controls.Add(this.lblReqQty);
            this.pnlDetail.Controls.Add(this.r_btnItemSearch);
            this.pnlDetail.Controls.Add(this.label2);
            this.pnlDetail.Controls.Add(this.r_txtItemName);
            this.pnlDetail.Controls.Add(this.r_txtItemCode);
            this.pnlDetail.Controls.Add(this.lblItem);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(0, 482);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1455, 160);
            this.pnlDetail.TabIndex = 8;
            // 
            // txtReqNo
            // 
            this.txtReqNo.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReqNo.Location = new System.Drawing.Point(141, 21);
            this.txtReqNo.Name = "txtReqNo";
            this.txtReqNo.ReadOnly = true;
            this.txtReqNo.Size = new System.Drawing.Size(377, 25);
            this.txtReqNo.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(26, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 29);
            this.label3.TabIndex = 131;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReqNo
            // 
            this.lblReqNo.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReqNo.Location = new System.Drawing.Point(45, 17);
            this.lblReqNo.Name = "lblReqNo";
            this.lblReqNo.Size = new System.Drawing.Size(96, 29);
            this.lblReqNo.TabIndex = 130;
            this.lblReqNo.Text = "생산요청번호";
            this.lblReqNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpReqDate
            // 
            this.dtpReqDate.Enabled = false;
            this.dtpReqDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpReqDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReqDate.Location = new System.Drawing.Point(678, 51);
            this.dtpReqDate.Name = "dtpReqDate";
            this.dtpReqDate.Size = new System.Drawing.Size(138, 25);
            this.dtpReqDate.TabIndex = 127;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(557, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 29);
            this.label4.TabIndex = 129;
            this.label4.Text = "*";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeliDate
            // 
            this.lblDeliDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDeliDate.Location = new System.Drawing.Point(576, 79);
            this.lblDeliDate.Name = "lblDeliDate";
            this.lblDeliDate.Size = new System.Drawing.Size(79, 29);
            this.lblDeliDate.TabIndex = 128;
            this.lblDeliDate.Text = "납기일자";
            this.lblDeliDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.Location = new System.Drawing.Point(1165, 20);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(256, 56);
            this.txtRemark.TabIndex = 126;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(1084, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 29);
            this.label14.TabIndex = 125;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRemark
            // 
            this.lblRemark.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRemark.Location = new System.Drawing.Point(1105, 18);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(96, 29);
            this.lblRemark.TabIndex = 124;
            this.lblRemark.Text = "비고";
            this.lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProjName
            // 
            this.txtProjName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProjName.Location = new System.Drawing.Point(678, 20);
            this.txtProjName.Name = "txtProjName";
            this.txtProjName.ReadOnly = true;
            this.txtProjName.Size = new System.Drawing.Size(376, 25);
            this.txtProjName.TabIndex = 102;
            // 
            // txtCusName
            // 
            this.txtCusName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCusName.Location = new System.Drawing.Point(142, 113);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.ReadOnly = true;
            this.txtCusName.Size = new System.Drawing.Size(377, 25);
            this.txtCusName.TabIndex = 101;
            // 
            // txtReqQty
            // 
            this.txtReqQty.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtReqQty.Location = new System.Drawing.Point(142, 82);
            this.txtReqQty.Name = "txtReqQty";
            this.txtReqQty.ReadOnly = true;
            this.txtReqQty.Size = new System.Drawing.Size(377, 25);
            this.txtReqQty.TabIndex = 100;
            this.txtReqQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReqQty_KeyPress);
            this.txtReqQty.Leave += new System.EventHandler(this.txtReqQty_Leave);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(557, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 29);
            this.label7.TabIndex = 99;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblProjName
            // 
            this.lblProjName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProjName.Location = new System.Drawing.Point(576, 17);
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
            this.label1.Location = new System.Drawing.Point(27, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 97;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCusName
            // 
            this.lblCusName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCusName.Location = new System.Drawing.Point(46, 109);
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
            this.dtpDeliDate.Location = new System.Drawing.Point(678, 81);
            this.dtpDeliDate.Name = "dtpDeliDate";
            this.dtpDeliDate.Size = new System.Drawing.Size(138, 25);
            this.dtpDeliDate.TabIndex = 91;
            this.dtpDeliDate.ValueChanged += new System.EventHandler(this.dtpDeliDate_ValueChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(557, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 29);
            this.label11.TabIndex = 95;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReqDate
            // 
            this.lblReqDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReqDate.Location = new System.Drawing.Point(576, 48);
            this.lblReqDate.Name = "lblReqDate";
            this.lblReqDate.Size = new System.Drawing.Size(79, 29);
            this.lblReqDate.TabIndex = 94;
            this.lblReqDate.Text = "요청일자";
            this.lblReqDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(27, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 29);
            this.label5.TabIndex = 93;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblReqQty
            // 
            this.lblReqQty.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReqQty.Location = new System.Drawing.Point(46, 78);
            this.lblReqQty.Name = "lblReqQty";
            this.lblReqQty.Size = new System.Drawing.Size(96, 29);
            this.lblReqQty.TabIndex = 92;
            this.lblReqQty.Text = "요청수량";
            this.lblReqQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // r_btnItemSearch
            // 
            this.r_btnItemSearch.BackColor = System.Drawing.Color.Gray;
            this.r_btnItemSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.r_btnItemSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.r_btnItemSearch.Enabled = false;
            this.r_btnItemSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r_btnItemSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_btnItemSearch.Location = new System.Drawing.Point(308, 52);
            this.r_btnItemSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.r_btnItemSearch.Name = "r_btnItemSearch";
            this.r_btnItemSearch.Size = new System.Drawing.Size(25, 24);
            this.r_btnItemSearch.TabIndex = 58;
            this.r_btnItemSearch.UseVisualStyleBackColor = false;
            this.r_btnItemSearch.Click += new System.EventHandler(this.r_btnItemSearch_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 29);
            this.label2.TabIndex = 53;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // r_txtItemName
            // 
            this.r_txtItemName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtItemName.Location = new System.Drawing.Point(339, 51);
            this.r_txtItemName.Name = "r_txtItemName";
            this.r_txtItemName.PlaceholderText = "품목 명";
            this.r_txtItemName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtItemName.ReadOnly = true;
            this.r_txtItemName.Size = new System.Drawing.Size(179, 25);
            this.r_txtItemName.TabIndex = 52;
            // 
            // r_txtItemCode
            // 
            this.r_txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtItemCode.Location = new System.Drawing.Point(141, 51);
            this.r_txtItemCode.Name = "r_txtItemCode";
            this.r_txtItemCode.PlaceholderText = "품목 코드";
            this.r_txtItemCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtItemCode.ReadOnly = true;
            this.r_txtItemCode.Size = new System.Drawing.Size(161, 25);
            this.r_txtItemCode.TabIndex = 51;
            // 
            // lblItem
            // 
            this.lblItem.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblItem.Location = new System.Drawing.Point(47, 48);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(79, 29);
            this.lblItem.TabIndex = 48;
            this.lblItem.Text = "품목";
            this.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
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
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.TextBox txtReqNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblReqNo;
        private System.Windows.Forms.DateTimePicker dtpReqDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDeliDate;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtProjName;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtReqQty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblProjName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCusName;
        private System.Windows.Forms.DateTimePicker dtpDeliDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblReqDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReqQty;
        private System.Windows.Forms.Button r_btnItemSearch;
        private System.Windows.Forms.Label label2;
        private WinReflectionSettings.PlaceholderTextBox r_txtItemName;
        private WinReflectionSettings.PlaceholderTextBox r_txtItemCode;
        private System.Windows.Forms.Label lblItem;
    }
}