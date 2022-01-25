
namespace Team5_XN
{
    partial class frmUserInfo
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
            this.dgvUserInfo = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboUseYN = new System.Windows.Forms.ComboBox();
            this.cboIPSecurity = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtProcessName = new System.Windows.Forms.TextBox();
            this.txtUserGroupName = new System.Windows.Forms.TextBox();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnUserGroup = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProcessCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtUserGroupCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboUse = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnPwChange = new System.Windows.Forms.Button();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBorder.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).BeginInit();
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
            this.pnlDgv.Controls.Add(this.dgvUserInfo);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(5, 59);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1274, 435);
            this.pnlDgv.TabIndex = 6;
            // 
            // dgvUserInfo
            // 
            this.dgvUserInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUserInfo.Location = new System.Drawing.Point(0, 35);
            this.dgvUserInfo.Name = "dgvUserInfo";
            this.dgvUserInfo.RowTemplate.Height = 23;
            this.dgvUserInfo.Size = new System.Drawing.Size(1274, 395);
            this.dgvUserInfo.TabIndex = 1;
            this.dgvUserInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserInfo_CellClick);
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
            this.panel1.Controls.Add(this.cboUseYN);
            this.panel1.Controls.Add(this.cboIPSecurity);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtProcessName);
            this.panel1.Controls.Add(this.txtUserGroupName);
            this.panel1.Controls.Add(this.btnProcess);
            this.panel1.Controls.Add(this.btnUserGroup);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtProcessCode);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.txtUserGroupCode);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 132);
            this.panel1.TabIndex = 12;
            // 
            // cboUseYN
            // 
            this.cboUseYN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUseYN.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.cboUseYN.FormattingEnabled = true;
            this.cboUseYN.Location = new System.Drawing.Point(713, 41);
            this.cboUseYN.Name = "cboUseYN";
            this.cboUseYN.Size = new System.Drawing.Size(89, 20);
            this.cboUseYN.TabIndex = 36;
            this.cboUseYN.Tag = "Use_YN";
            this.cboUseYN.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // cboIPSecurity
            // 
            this.cboIPSecurity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIPSecurity.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.cboIPSecurity.FormattingEnabled = true;
            this.cboIPSecurity.Location = new System.Drawing.Point(713, 13);
            this.cboIPSecurity.Name = "cboIPSecurity";
            this.cboIPSecurity.Size = new System.Drawing.Size(89, 20);
            this.cboIPSecurity.TabIndex = 35;
            this.cboIPSecurity.Tag = "IP_Security_YN";
            this.cboIPSecurity.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(573, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 23);
            this.label14.TabIndex = 31;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label15.Location = new System.Drawing.Point(590, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 23);
            this.label15.TabIndex = 30;
            this.label15.Text = "IP 보안 적용여부";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(573, 39);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 23);
            this.label17.TabIndex = 28;
            this.label17.Text = "*";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label18.Location = new System.Drawing.Point(590, 39);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 23);
            this.label18.TabIndex = 26;
            this.label18.Text = "사용유무";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProcessName
            // 
            this.txtProcessName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtProcessName.Location = new System.Drawing.Point(313, 98);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(150, 21);
            this.txtProcessName.TabIndex = 25;
            this.txtProcessName.Tag = "Process_Name";
            this.txtProcessName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtUserGroupName
            // 
            this.txtUserGroupName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtUserGroupName.Location = new System.Drawing.Point(313, 69);
            this.txtUserGroupName.Name = "txtUserGroupName";
            this.txtUserGroupName.Size = new System.Drawing.Size(150, 21);
            this.txtUserGroupName.TabIndex = 24;
            this.txtUserGroupName.Tag = "UserGroup_Name";
            this.txtUserGroupName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // btnProcess
            // 
            this.btnProcess.BackColor = System.Drawing.Color.Black;
            this.btnProcess.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.btnProcess.Location = new System.Drawing.Point(284, 98);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(23, 23);
            this.btnProcess.TabIndex = 23;
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnUserGroup
            // 
            this.btnUserGroup.BackColor = System.Drawing.Color.Black;
            this.btnUserGroup.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnUserGroup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUserGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserGroup.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.btnUserGroup.Location = new System.Drawing.Point(284, 69);
            this.btnUserGroup.Name = "btnUserGroup";
            this.btnUserGroup.Size = new System.Drawing.Size(23, 23);
            this.btnUserGroup.TabIndex = 8;
            this.btnUserGroup.UseVisualStyleBackColor = false;
            this.btnUserGroup.Click += new System.EventHandler(this.btnUserGroup_Click);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(49, 98);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProcessCode
            // 
            this.txtProcessCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtProcessCode.Location = new System.Drawing.Point(156, 98);
            this.txtProcessCode.Name = "txtProcessCode";
            this.txtProcessCode.Size = new System.Drawing.Size(122, 21);
            this.txtProcessCode.TabIndex = 21;
            this.txtProcessCode.Tag = "Default_Major_Process_Code";
            this.txtProcessCode.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label11.Location = new System.Drawing.Point(63, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 23);
            this.label11.TabIndex = 20;
            this.label11.Text = "기본공정";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(46, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 23);
            this.label6.TabIndex = 19;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtID.Location = new System.Drawing.Point(156, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(122, 21);
            this.txtID.TabIndex = 18;
            this.txtID.Tag = "User_ID";
            this.txtID.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label2.Location = new System.Drawing.Point(63, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 23);
            this.label2.TabIndex = 17;
            this.label2.Text = "ID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(49, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 23);
            this.label8.TabIndex = 16;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(46, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 23);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtName.Location = new System.Drawing.Point(156, 41);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(122, 21);
            this.txtName.TabIndex = 12;
            this.txtName.Tag = "User_Name";
            this.txtName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // txtUserGroupCode
            // 
            this.txtUserGroupCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtUserGroupCode.Location = new System.Drawing.Point(156, 70);
            this.txtUserGroupCode.Name = "txtUserGroupCode";
            this.txtUserGroupCode.Size = new System.Drawing.Size(122, 21);
            this.txtUserGroupCode.TabIndex = 14;
            this.txtUserGroupCode.Tag = "UserGroup_Code";
            this.txtUserGroupCode.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label4.Location = new System.Drawing.Point(63, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "이름";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label5.Location = new System.Drawing.Point(63, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "사용자그룹";
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
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.txtGroupCode);
            this.pnlSelect.Controls.Add(this.label23);
            this.pnlSelect.Controls.Add(this.txtGroupName);
            this.pnlSelect.Controls.Add(this.label24);
            this.pnlSelect.Controls.Add(this.btnSearch);
            this.pnlSelect.Controls.Add(this.cboUse);
            this.pnlSelect.Controls.Add(this.label21);
            this.pnlSelect.Controls.Add(this.label22);
            this.pnlSelect.Controls.Add(this.txtUserName);
            this.pnlSelect.Controls.Add(this.label19);
            this.pnlSelect.Controls.Add(this.label20);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.label16);
            this.pnlSelect.Controls.Add(this.btnPwChange);
            this.pnlSelect.Controls.Add(this.txtUserID);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(5, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1274, 54);
            this.pnlSelect.TabIndex = 1;
            //this.pnlSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSelect_Paint);
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtGroupCode.Location = new System.Drawing.Point(371, 28);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(101, 21);
            this.txtGroupCode.TabIndex = 30;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(261, 27);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 23);
            this.label23.TabIndex = 33;
            this.label23.Text = "*";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtGroupName.Location = new System.Drawing.Point(506, 28);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(122, 21);
            this.txtGroupName.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label24.Location = new System.Drawing.Point(279, 26);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 23);
            this.label24.TabIndex = 32;
            this.label24.Text = "사용자그룹";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(478, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(23, 23);
            this.btnSearch.TabIndex = 29;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // cboUse
            // 
            this.cboUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse.FormattingEnabled = true;
            this.cboUse.Location = new System.Drawing.Point(120, 29);
            this.cboUse.Name = "cboUse";
            this.cboUse.Size = new System.Drawing.Size(121, 20);
            this.cboUse.TabIndex = 25;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(261, 4);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 23);
            this.label21.TabIndex = 24;
            this.label21.Text = "*";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label22.Location = new System.Drawing.Point(279, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(80, 23);
            this.label22.TabIndex = 23;
            this.label22.Text = "사원명";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtUserName.Location = new System.Drawing.Point(371, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(122, 21);
            this.txtUserName.TabIndex = 22;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(33, 28);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 23);
            this.label19.TabIndex = 21;
            this.label19.Text = "*";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label20.Location = new System.Drawing.Point(47, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 23);
            this.label20.TabIndex = 20;
            this.label20.Text = "사용유무";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.label16.Location = new System.Drawing.Point(47, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 23);
            this.label16.TabIndex = 17;
            this.label16.Text = "사용자 ID";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPwChange
            // 
            this.btnPwChange.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPwChange.BackColor = System.Drawing.Color.White;
            this.btnPwChange.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPwChange.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.btnPwChange.Location = new System.Drawing.Point(1154, 6);
            this.btnPwChange.Name = "btnPwChange";
            this.btnPwChange.Size = new System.Drawing.Size(112, 40);
            this.btnPwChange.TabIndex = 6;
            this.btnPwChange.Text = "비밀번호 변경";
            this.btnPwChange.UseVisualStyleBackColor = false;
            this.btnPwChange.Click += new System.EventHandler(this.btnPwChange_Click);
            // 
            // txtUserID
            // 
            this.txtUserID.Font = new System.Drawing.Font("맑은 고딕", 7.8F);
            this.txtUserID.Location = new System.Drawing.Point(120, 3);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(121, 21);
            this.txtUserID.TabIndex = 3;
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
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmUserInfo";
            this.Text = "사용자관리";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            this.pnlBorder.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserInfo)).EndInit();
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
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProcessCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtUserGroupCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboUseYN;
        private System.Windows.Forms.ComboBox cboIPSecurity;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.TextBox txtUserGroupName;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnUserGroup;
        private System.Windows.Forms.Button btnPwChange;
        private System.Windows.Forms.ComboBox cboUse;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dgvUserInfo;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnSearch;
    }
}