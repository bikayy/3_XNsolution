
namespace Team5_XN
{
    partial class frmWorkPlan
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dgvPlan = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.btnWCSearch = new System.Windows.Forms.Button();
            this.btnWCGSearch = new System.Windows.Forms.Button();
            this.p_btnItemSearch = new System.Windows.Forms.Button();
            this.btnDivision = new System.Windows.Forms.Button();
            this.btnEndCancle = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.dtpPlanTo = new System.Windows.Forms.DateTimePicker();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpPlanFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.dgvRequest = new System.Windows.Forms.DataGridView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoReqDate = new System.Windows.Forms.RadioButton();
            this.rdoDeliDate = new System.Windows.Forms.RadioButton();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnCreate = new System.Windows.Forms.Button();
            this.r_btnItemSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.r_txtItemName = new WinReflectionSettings.PlaceholderTextBox();
            this.r_txtItemCode = new WinReflectionSettings.PlaceholderTextBox();
            this.txtWCName = new WinReflectionSettings.PlaceholderTextBox();
            this.txtWCCode = new WinReflectionSettings.PlaceholderTextBox();
            this.txtWCGroup = new WinReflectionSettings.PlaceholderTextBox();
            this.p_txtItemName = new WinReflectionSettings.PlaceholderTextBox();
            this.p_txtItemCode = new WinReflectionSettings.PlaceholderTextBox();
            this.tabPage2.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).BeginInit();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlDgv);
            this.tabPage2.Controls.Add(this.pnlSelect);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1459, 762);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "생산계획";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dgvPlan);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(3, 164);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlDgv.Size = new System.Drawing.Size(1453, 595);
            this.pnlDgv.TabIndex = 12;
            // 
            // dgvPlan
            // 
            this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlan.Location = new System.Drawing.Point(0, 44);
            this.dgvPlan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPlan.Name = "dgvPlan";
            this.dgvPlan.RowHeadersWidth = 51;
            this.dgvPlan.RowTemplate.Height = 23;
            this.dgvPlan.Size = new System.Drawing.Size(1453, 545);
            this.dgvPlan.TabIndex = 1;
            this.dgvPlan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlan_CellClick);
            // 
            // pnlSubject1
            // 
            this.pnlSubject1.BackColor = System.Drawing.Color.White;
            this.pnlSubject1.Controls.Add(this.label9);
            this.pnlSubject1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubject1.Location = new System.Drawing.Point(0, 6);
            this.pnlSubject1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSubject1.Name = "pnlSubject1";
            this.pnlSubject1.Size = new System.Drawing.Size(1453, 38);
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
            this.label9.Text = "생산계획";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.btnWCSearch);
            this.pnlSelect.Controls.Add(this.btnWCGSearch);
            this.pnlSelect.Controls.Add(this.p_btnItemSearch);
            this.pnlSelect.Controls.Add(this.btnDivision);
            this.pnlSelect.Controls.Add(this.btnEndCancle);
            this.pnlSelect.Controls.Add(this.btnEnd);
            this.pnlSelect.Controls.Add(this.dtpPlanTo);
            this.pnlSelect.Controls.Add(this.btnDelete);
            this.pnlSelect.Controls.Add(this.btnUpdate);
            this.pnlSelect.Controls.Add(this.label5);
            this.pnlSelect.Controls.Add(this.txtWCName);
            this.pnlSelect.Controls.Add(this.txtWCCode);
            this.pnlSelect.Controls.Add(this.label6);
            this.pnlSelect.Controls.Add(this.label3);
            this.pnlSelect.Controls.Add(this.txtWCGroup);
            this.pnlSelect.Controls.Add(this.label4);
            this.pnlSelect.Controls.Add(this.btnAdd);
            this.pnlSelect.Controls.Add(this.label8);
            this.pnlSelect.Controls.Add(this.p_txtItemName);
            this.pnlSelect.Controls.Add(this.p_txtItemCode);
            this.pnlSelect.Controls.Add(this.label10);
            this.pnlSelect.Controls.Add(this.label17);
            this.pnlSelect.Controls.Add(this.dtpPlanFrom);
            this.pnlSelect.Controls.Add(this.label2);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(3, 3);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1453, 161);
            this.pnlSelect.TabIndex = 11;
            // 
            // btnWCSearch
            // 
            this.btnWCSearch.BackColor = System.Drawing.Color.Black;
            this.btnWCSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnWCSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWCSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWCSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWCSearch.Location = new System.Drawing.Point(308, 119);
            this.btnWCSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWCSearch.Name = "btnWCSearch";
            this.btnWCSearch.Size = new System.Drawing.Size(24, 25);
            this.btnWCSearch.TabIndex = 89;
            this.btnWCSearch.UseVisualStyleBackColor = false;
            // 
            // btnWCGSearch
            // 
            this.btnWCGSearch.BackColor = System.Drawing.Color.Black;
            this.btnWCGSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnWCGSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWCGSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWCGSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWCGSearch.Location = new System.Drawing.Point(309, 84);
            this.btnWCGSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWCGSearch.Name = "btnWCGSearch";
            this.btnWCGSearch.Size = new System.Drawing.Size(24, 25);
            this.btnWCGSearch.TabIndex = 88;
            this.btnWCGSearch.UseVisualStyleBackColor = false;
            // 
            // p_btnItemSearch
            // 
            this.p_btnItemSearch.BackColor = System.Drawing.Color.Black;
            this.p_btnItemSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.p_btnItemSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.p_btnItemSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p_btnItemSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p_btnItemSearch.Location = new System.Drawing.Point(308, 48);
            this.p_btnItemSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.p_btnItemSearch.Name = "p_btnItemSearch";
            this.p_btnItemSearch.Size = new System.Drawing.Size(24, 25);
            this.p_btnItemSearch.TabIndex = 87;
            this.p_btnItemSearch.UseVisualStyleBackColor = false;
            // 
            // btnDivision
            // 
            this.btnDivision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDivision.BackColor = System.Drawing.Color.White;
            this.btnDivision.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDivision.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDivision.Location = new System.Drawing.Point(963, 71);
            this.btnDivision.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDivision.Name = "btnDivision";
            this.btnDivision.Size = new System.Drawing.Size(155, 44);
            this.btnDivision.TabIndex = 75;
            this.btnDivision.Text = "생산계획 분할";
            this.btnDivision.UseVisualStyleBackColor = false;
            // 
            // btnEndCancle
            // 
            this.btnEndCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEndCancle.BackColor = System.Drawing.Color.White;
            this.btnEndCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEndCancle.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEndCancle.Location = new System.Drawing.Point(1285, 71);
            this.btnEndCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEndCancle.Name = "btnEndCancle";
            this.btnEndCancle.Size = new System.Drawing.Size(155, 44);
            this.btnEndCancle.TabIndex = 71;
            this.btnEndCancle.Text = "생산계획 마감 취소";
            this.btnEndCancle.UseVisualStyleBackColor = false;
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.BackColor = System.Drawing.Color.White;
            this.btnEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnd.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEnd.Location = new System.Drawing.Point(1124, 71);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(155, 44);
            this.btnEnd.TabIndex = 70;
            this.btnEnd.Text = "생산계획 마감";
            this.btnEnd.UseVisualStyleBackColor = false;
            // 
            // dtpPlanTo
            // 
            this.dtpPlanTo.CalendarFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpPlanTo.CustomFormat = "yyyy-MM";
            this.dtpPlanTo.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpPlanTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanTo.Location = new System.Drawing.Point(338, 12);
            this.dtpPlanTo.Name = "dtpPlanTo";
            this.dtpPlanTo.Size = new System.Drawing.Size(139, 25);
            this.dtpPlanTo.TabIndex = 69;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(1285, 19);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 44);
            this.btnDelete.TabIndex = 68;
            this.btnDelete.Text = "생산계획 삭제";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpdate.Location = new System.Drawing.Point(1124, 19);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 44);
            this.btnUpdate.TabIndex = 67;
            this.btnUpdate.Text = "생산계획 수정";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(28, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 29);
            this.label5.TabIndex = 66;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(47, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 29);
            this.label6.TabIndex = 62;
            this.label6.Text = "작업장";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(28, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 29);
            this.label3.TabIndex = 61;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(47, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 29);
            this.label4.TabIndex = 57;
            this.label4.Text = "직업장그룹";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BackColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(963, 19);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(155, 44);
            this.btnAdd.TabIndex = 56;
            this.btnAdd.Text = "생산계획 추가";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(28, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 29);
            this.label8.TabIndex = 53;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(47, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 29);
            this.label10.TabIndex = 48;
            this.label10.Text = "품목";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(308, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 29);
            this.label17.TabIndex = 33;
            this.label17.Text = "~";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpPlanFrom
            // 
            this.dtpPlanFrom.CalendarFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpPlanFrom.CustomFormat = "yyyy-MM";
            this.dtpPlanFrom.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpPlanFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanFrom.Location = new System.Drawing.Point(163, 12);
            this.dtpPlanFrom.Name = "dtpPlanFrom";
            this.dtpPlanFrom.Size = new System.Drawing.Size(139, 25);
            this.dtpPlanFrom.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(28, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 29);
            this.label2.TabIndex = 23;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(47, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "생산계획월";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(22, 159);
            this.panel2.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel7);
            this.tabPage1.Controls.Add(this.panel9);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1459, 762);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "생산요청";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.dgvRequest);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 164);
            this.panel7.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.panel7.Size = new System.Drawing.Size(1453, 595);
            this.panel7.TabIndex = 14;
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
            this.dgvRequest.Size = new System.Drawing.Size(1453, 545);
            this.dgvRequest.TabIndex = 1;
            this.dgvRequest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRequest_CellClick);
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.label20);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 6);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1453, 38);
            this.panel8.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Gainsboro;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(152, 38);
            this.label20.TabIndex = 4;
            this.label20.Text = "생산요청";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.groupBox1);
            this.panel9.Controls.Add(this.btnCreate);
            this.panel9.Controls.Add(this.r_btnItemSearch);
            this.panel9.Controls.Add(this.label11);
            this.panel9.Controls.Add(this.r_txtItemName);
            this.panel9.Controls.Add(this.r_txtItemCode);
            this.panel9.Controls.Add(this.label12);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(3, 3);
            this.panel9.Margin = new System.Windows.Forms.Padding(11, 12, 11, 12);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1453, 161);
            this.panel9.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoReqDate);
            this.groupBox1.Controls.Add(this.rdoDeliDate);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(31, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(537, 61);
            this.groupBox1.TabIndex = 87;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "* 기간검색";
            // 
            // rdoReqDate
            // 
            this.rdoReqDate.AutoSize = true;
            this.rdoReqDate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoReqDate.Location = new System.Drawing.Point(15, 24);
            this.rdoReqDate.Name = "rdoReqDate";
            this.rdoReqDate.Size = new System.Drawing.Size(100, 23);
            this.rdoReqDate.TabIndex = 59;
            this.rdoReqDate.TabStop = true;
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
            this.rdoDeliDate.TabStop = true;
            this.rdoDeliDate.Text = "납기일";
            this.rdoDeliDate.UseVisualStyleBackColor = true;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFrom.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(203, 24);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(139, 25);
            this.dtpFrom.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(345, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 29);
            this.label7.TabIndex = 33;
            this.label7.Text = "~";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpTo.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(374, 24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(139, 25);
            this.dtpTo.TabIndex = 34;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreate.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCreate.Location = new System.Drawing.Point(1261, 13);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(155, 124);
            this.btnCreate.TabIndex = 56;
            this.btnCreate.Text = "생산계획 생성";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // r_btnItemSearch
            // 
            this.r_btnItemSearch.BackColor = System.Drawing.Color.Black;
            this.r_btnItemSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.r_btnItemSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.r_btnItemSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r_btnItemSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_btnItemSearch.Location = new System.Drawing.Point(255, 102);
            this.r_btnItemSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.r_btnItemSearch.Name = "r_btnItemSearch";
            this.r_btnItemSearch.Size = new System.Drawing.Size(24, 25);
            this.r_btnItemSearch.TabIndex = 86;
            this.r_btnItemSearch.UseVisualStyleBackColor = false;
            this.r_btnItemSearch.Click += new System.EventHandler(this.r_btnItemSearch_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(32, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 29);
            this.label11.TabIndex = 85;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(51, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 29);
            this.label12.TabIndex = 82;
            this.label12.Text = "품목";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.DimGray;
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(22, 159);
            this.panel10.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1467, 795);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // r_txtItemName
            // 
            this.r_txtItemName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtItemName.Location = new System.Drawing.Point(285, 102);
            this.r_txtItemName.Name = "r_txtItemName";
            this.r_txtItemName.PlaceholderText = "품목 명";
            this.r_txtItemName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtItemName.ReadOnly = true;
            this.r_txtItemName.Size = new System.Drawing.Size(202, 25);
            this.r_txtItemName.TabIndex = 84;
            // 
            // r_txtItemCode
            // 
            this.r_txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtItemCode.Location = new System.Drawing.Point(110, 102);
            this.r_txtItemCode.Name = "r_txtItemCode";
            this.r_txtItemCode.PlaceholderText = "품목 코드";
            this.r_txtItemCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtItemCode.ReadOnly = true;
            this.r_txtItemCode.Size = new System.Drawing.Size(139, 25);
            this.r_txtItemCode.TabIndex = 83;
            // 
            // txtWCName
            // 
            this.txtWCName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWCName.Location = new System.Drawing.Point(338, 119);
            this.txtWCName.Name = "txtWCName";
            this.txtWCName.PlaceholderText = "작업장 명";
            this.txtWCName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtWCName.Size = new System.Drawing.Size(202, 25);
            this.txtWCName.TabIndex = 65;
            // 
            // txtWCCode
            // 
            this.txtWCCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWCCode.Location = new System.Drawing.Point(163, 120);
            this.txtWCCode.Name = "txtWCCode";
            this.txtWCCode.PlaceholderText = "작업장 코드";
            this.txtWCCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtWCCode.Size = new System.Drawing.Size(139, 25);
            this.txtWCCode.TabIndex = 64;
            // 
            // txtWCGroup
            // 
            this.txtWCGroup.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWCGroup.Location = new System.Drawing.Point(163, 84);
            this.txtWCGroup.Name = "txtWCGroup";
            this.txtWCGroup.PlaceholderText = "장업장그룹 명";
            this.txtWCGroup.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtWCGroup.Size = new System.Drawing.Size(139, 25);
            this.txtWCGroup.TabIndex = 59;
            // 
            // p_txtItemName
            // 
            this.p_txtItemName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p_txtItemName.Location = new System.Drawing.Point(338, 48);
            this.p_txtItemName.Name = "p_txtItemName";
            this.p_txtItemName.PlaceholderText = "품목 명";
            this.p_txtItemName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.p_txtItemName.Size = new System.Drawing.Size(202, 25);
            this.p_txtItemName.TabIndex = 52;
            // 
            // p_txtItemCode
            // 
            this.p_txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p_txtItemCode.Location = new System.Drawing.Point(163, 48);
            this.p_txtItemCode.Name = "p_txtItemCode";
            this.p_txtItemCode.PlaceholderText = "품목 코드";
            this.p_txtItemCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.p_txtItemCode.Size = new System.Drawing.Size(139, 25);
            this.p_txtItemCode.TabIndex = 51;
            // 
            // frmWorkPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1467, 791);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmWorkPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "생산계획 관리";
            this.Load += new System.EventHandler(this.frmWorkPlan_Load);
            this.tabPage2.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequest)).EndInit();
            this.panel8.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvPlan;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.Button btnEndCancle;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.DateTimePicker dtpPlanTo;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private WinReflectionSettings.PlaceholderTextBox txtWCName;
        private WinReflectionSettings.PlaceholderTextBox txtWCCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private WinReflectionSettings.PlaceholderTextBox txtWCGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label8;
        private WinReflectionSettings.PlaceholderTextBox p_txtItemName;
        private WinReflectionSettings.PlaceholderTextBox p_txtItemCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpPlanFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.DataGridView dgvRequest;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button r_btnItemSearch;
        private System.Windows.Forms.Label label11;
        private WinReflectionSettings.PlaceholderTextBox r_txtItemName;
        private WinReflectionSettings.PlaceholderTextBox r_txtItemCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoReqDate;
        private System.Windows.Forms.RadioButton rdoDeliDate;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnDivision;
        private System.Windows.Forms.Button btnWCSearch;
        private System.Windows.Forms.Button btnWCGSearch;
        private System.Windows.Forms.Button p_btnItemSearch;
    }
}