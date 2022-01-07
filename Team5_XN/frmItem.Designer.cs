
namespace Team5_XN
{
    partial class frmItem
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
            this.cboUse_YN = new System.Windows.Forms.ComboBox();
            this.cboItemType = new System.Windows.Forms.ComboBox();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlDetail2 = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.txtItemNameEng = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtPrdQty_Hour = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCavity = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtItemUnit = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.cboSelectItemType = new System.Windows.Forms.ComboBox();
            this.cboSelectUse_YN = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSelectItemName = new System.Windows.Forms.TextBox();
            this.txtSelectItemCode = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBorder.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlDetail2.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.pnlSubject2.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboUse_YN
            // 
            this.cboUse_YN.BackColor = System.Drawing.Color.White;
            this.cboUse_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUse_YN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboUse_YN.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboUse_YN.FormattingEnabled = true;
            this.cboUse_YN.Location = new System.Drawing.Point(385, 60);
            this.cboUse_YN.Name = "cboUse_YN";
            this.cboUse_YN.Size = new System.Drawing.Size(110, 21);
            this.cboUse_YN.TabIndex = 101;
            this.cboUse_YN.Tag = "Use_YN";
            this.cboUse_YN.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // cboItemType
            // 
            this.cboItemType.BackColor = System.Drawing.Color.White;
            this.cboItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboItemType.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboItemType.FormattingEnabled = true;
            this.cboItemType.Location = new System.Drawing.Point(385, 8);
            this.cboItemType.Name = "cboItemType";
            this.cboItemType.Size = new System.Drawing.Size(110, 21);
            this.cboItemType.TabIndex = 17;
            this.cboItemType.Tag = "Item_Type";
            this.cboItemType.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
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
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dataGridView1);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(5, 74);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1274, 462);
            this.pnlDgv.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 422);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
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
            this.pnlDetail2.Location = new System.Drawing.Point(5, 536);
            this.pnlDetail2.Name = "pnlDetail2";
            this.pnlDetail2.Size = new System.Drawing.Size(1274, 120);
            this.pnlDetail2.TabIndex = 4;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlDetail.Controls.Add(this.txtItemNameEng);
            this.pnlDetail.Controls.Add(this.label27);
            this.pnlDetail.Controls.Add(this.txtPrdQty_Hour);
            this.pnlDetail.Controls.Add(this.label28);
            this.pnlDetail.Controls.Add(this.label21);
            this.pnlDetail.Controls.Add(this.txtCavity);
            this.pnlDetail.Controls.Add(this.label22);
            this.pnlDetail.Controls.Add(this.cboUse_YN);
            this.pnlDetail.Controls.Add(this.cboItemType);
            this.pnlDetail.Controls.Add(this.label39);
            this.pnlDetail.Controls.Add(this.txtRemark);
            this.pnlDetail.Controls.Add(this.label44);
            this.pnlDetail.Controls.Add(this.label43);
            this.pnlDetail.Controls.Add(this.label40);
            this.pnlDetail.Controls.Add(this.label25);
            this.pnlDetail.Controls.Add(this.txtItemUnit);
            this.pnlDetail.Controls.Add(this.label26);
            this.pnlDetail.Controls.Add(this.label23);
            this.pnlDetail.Controls.Add(this.label24);
            this.pnlDetail.Controls.Add(this.label6);
            this.pnlDetail.Controls.Add(this.txtItemCode);
            this.pnlDetail.Controls.Add(this.label2);
            this.pnlDetail.Controls.Add(this.label8);
            this.pnlDetail.Controls.Add(this.label7);
            this.pnlDetail.Controls.Add(this.txtItemName);
            this.pnlDetail.Controls.Add(this.label4);
            this.pnlDetail.Controls.Add(this.label5);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 30);
            this.pnlDetail.Margin = new System.Windows.Forms.Padding(0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1274, 90);
            this.pnlDetail.TabIndex = 12;
            // 
            // txtItemNameEng
            // 
            this.txtItemNameEng.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemNameEng.Location = new System.Drawing.Point(117, 60);
            this.txtItemNameEng.Name = "txtItemNameEng";
            this.txtItemNameEng.Size = new System.Drawing.Size(138, 22);
            this.txtItemNameEng.TabIndex = 109;
            this.txtItemNameEng.Tag = "Item_Name_Eng";
            this.txtItemNameEng.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(523, 8);
            this.label27.Margin = new System.Windows.Forms.Padding(0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 21);
            this.label27.TabIndex = 107;
            this.label27.Text = "*";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrdQty_Hour
            // 
            this.txtPrdQty_Hour.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPrdQty_Hour.Location = new System.Drawing.Point(625, 8);
            this.txtPrdQty_Hour.Name = "txtPrdQty_Hour";
            this.txtPrdQty_Hour.Size = new System.Drawing.Size(110, 22);
            this.txtPrdQty_Hour.TabIndex = 106;
            this.txtPrdQty_Hour.Tag = "PrdQty_Per_Hour";
            this.txtPrdQty_Hour.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtPrdQty_Hour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrdQty_Hour_KeyPress);
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.Location = new System.Drawing.Point(537, 8);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(100, 21);
            this.label28.TabIndex = 105;
            this.label28.Text = "시간당 생산량";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(523, 33);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(17, 21);
            this.label21.TabIndex = 104;
            this.label21.Text = "*";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCavity
            // 
            this.txtCavity.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtCavity.Location = new System.Drawing.Point(625, 34);
            this.txtCavity.Name = "txtCavity";
            this.txtCavity.Size = new System.Drawing.Size(110, 22);
            this.txtCavity.TabIndex = 103;
            this.txtCavity.Tag = "Cavity_qty";
            this.txtCavity.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            this.txtCavity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCavity_KeyPress);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.Location = new System.Drawing.Point(537, 33);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 21);
            this.label22.TabIndex = 102;
            this.label22.Text = "캐비티";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(768, 8);
            this.label39.Margin = new System.Windows.Forms.Padding(0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(17, 21);
            this.label39.TabIndex = 68;
            this.label39.Text = "*";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtRemark.Location = new System.Drawing.Point(870, 8);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(297, 51);
            this.txtRemark.TabIndex = 67;
            this.txtRemark.Tag = "Remark";
            this.txtRemark.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(782, 8);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(125, 21);
            this.label44.TabIndex = 66;
            this.label44.Text = "비고";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label43
            // 
            this.label43.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label43.ForeColor = System.Drawing.Color.Red;
            this.label43.Location = new System.Drawing.Point(283, 60);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(17, 21);
            this.label43.TabIndex = 65;
            this.label43.Text = "*";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label40
            // 
            this.label40.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(297, 60);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(125, 21);
            this.label40.TabIndex = 62;
            this.label40.Text = "사용유무";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(283, 34);
            this.label25.Margin = new System.Windows.Forms.Padding(0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 21);
            this.label25.TabIndex = 43;
            this.label25.Text = "*";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemUnit
            // 
            this.txtItemUnit.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemUnit.Location = new System.Drawing.Point(385, 34);
            this.txtItemUnit.Name = "txtItemUnit";
            this.txtItemUnit.Size = new System.Drawing.Size(110, 22);
            this.txtItemUnit.TabIndex = 42;
            this.txtItemUnit.Tag = "Item_Unit";
            this.txtItemUnit.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label26.Location = new System.Drawing.Point(297, 34);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(100, 21);
            this.label26.TabIndex = 41;
            this.label26.Text = "규격";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(283, 8);
            this.label23.Margin = new System.Windows.Forms.Padding(0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 21);
            this.label23.TabIndex = 34;
            this.label23.Text = "*";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(297, 8);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 21);
            this.label24.TabIndex = 32;
            this.label24.Text = "품목유형";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(10, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 21);
            this.label6.TabIndex = 19;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemCode.Location = new System.Drawing.Point(117, 8);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(138, 22);
            this.txtItemCode.TabIndex = 18;
            this.txtItemCode.Tag = "Item_Code";
            this.txtItemCode.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(24, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 17;
            this.label2.Text = "품목코드";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(10, 59);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 21);
            this.label8.TabIndex = 16;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(10, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 21);
            this.label7.TabIndex = 15;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName.Location = new System.Drawing.Point(117, 34);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(138, 22);
            this.txtItemName.TabIndex = 12;
            this.txtItemName.Tag = "Item_Name";
            this.txtItemName.TextChanged += new System.EventHandler(this.txtBox_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(24, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "품목명";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(24, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "품목영문명";
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
            this.pnlSelect.Controls.Add(this.label49);
            this.pnlSelect.Controls.Add(this.label50);
            this.pnlSelect.Controls.Add(this.label12);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.label47);
            this.pnlSelect.Controls.Add(this.label48);
            this.pnlSelect.Controls.Add(this.cboSelectItemType);
            this.pnlSelect.Controls.Add(this.cboSelectUse_YN);
            this.pnlSelect.Controls.Add(this.label14);
            this.pnlSelect.Controls.Add(this.label13);
            this.pnlSelect.Controls.Add(this.txtSelectItemName);
            this.pnlSelect.Controls.Add(this.txtSelectItemCode);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(5, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1274, 69);
            this.pnlSelect.TabIndex = 1;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label49.ForeColor = System.Drawing.Color.Black;
            this.label49.Location = new System.Drawing.Point(318, 35);
            this.label49.Margin = new System.Windows.Forms.Padding(0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(17, 21);
            this.label49.TabIndex = 47;
            this.label49.Text = "*";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(318, 10);
            this.label50.Margin = new System.Windows.Forms.Padding(0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(17, 21);
            this.label50.TabIndex = 46;
            this.label50.Text = "*";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(39, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 21);
            this.label12.TabIndex = 8;
            this.label12.Text = "품목명";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "품목코드";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(25, 35);
            this.label47.Margin = new System.Windows.Forms.Padding(0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(17, 21);
            this.label47.TabIndex = 45;
            this.label47.Text = "*";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(25, 10);
            this.label48.Margin = new System.Windows.Forms.Padding(0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(17, 21);
            this.label48.TabIndex = 44;
            this.label48.Text = "*";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSelectItemType
            // 
            this.cboSelectItemType.BackColor = System.Drawing.Color.White;
            this.cboSelectItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectItemType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSelectItemType.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSelectItemType.FormattingEnabled = true;
            this.cboSelectItemType.Location = new System.Drawing.Point(419, 10);
            this.cboSelectItemType.Name = "cboSelectItemType";
            this.cboSelectItemType.Size = new System.Drawing.Size(121, 21);
            this.cboSelectItemType.TabIndex = 17;
            // 
            // cboSelectUse_YN
            // 
            this.cboSelectUse_YN.BackColor = System.Drawing.Color.White;
            this.cboSelectUse_YN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectUse_YN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboSelectUse_YN.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboSelectUse_YN.FormattingEnabled = true;
            this.cboSelectUse_YN.Location = new System.Drawing.Point(419, 35);
            this.cboSelectUse_YN.Name = "cboSelectUse_YN";
            this.cboSelectUse_YN.Size = new System.Drawing.Size(121, 21);
            this.cboSelectUse_YN.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(333, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 21);
            this.label14.TabIndex = 13;
            this.label14.Text = "사용유무";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.Location = new System.Drawing.Point(333, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 21);
            this.label13.TabIndex = 11;
            this.label13.Text = "품목유형";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSelectItemName
            // 
            this.txtSelectItemName.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectItemName.Location = new System.Drawing.Point(121, 35);
            this.txtSelectItemName.Name = "txtSelectItemName";
            this.txtSelectItemName.Size = new System.Drawing.Size(122, 22);
            this.txtSelectItemName.TabIndex = 9;
            // 
            // txtSelectItemCode
            // 
            this.txtSelectItemCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectItemCode.Location = new System.Drawing.Point(121, 10);
            this.txtSelectItemCode.Name = "txtSelectItemCode";
            this.txtSelectItemCode.Size = new System.Drawing.Size(122, 22);
            this.txtSelectItemCode.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 67);
            this.panel2.TabIndex = 0;
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmItem";
            this.Text = "frmItem";
            this.Load += new System.EventHandler(this.frmItem_Load);
            this.pnlBorder.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlDetail2.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.pnlDetail.PerformLayout();
            this.pnlSubject2.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUse_YN;
        private System.Windows.Forms.ComboBox cboItemType;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDetail2;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.TextBox txtItemNameEng;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtPrdQty_Hour;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCavity;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtItemUnit;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtItemName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.ComboBox cboSelectItemType;
        private System.Windows.Forms.ComboBox cboSelectUse_YN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSelectItemName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSelectItemCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
    }
}