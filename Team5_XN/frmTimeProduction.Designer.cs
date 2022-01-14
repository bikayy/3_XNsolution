
namespace Team5_XN
{
    partial class frmTimeProduction
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.txtSelectItemName = new System.Windows.Forms.TextBox();
            this.txtSelectItemCode = new System.Windows.Forms.TextBox();
            this.btnSelectItem = new System.Windows.Forms.Button();
            this.txtSelectProcessName = new System.Windows.Forms.TextBox();
            this.txtSelectProcessCode = new System.Windows.Forms.TextBox();
            this.btnSelectProcess = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboWoStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label47 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.pnlBorder.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.pnlSubject2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnlDetail.SuspendLayout();
            this.pnlSubject1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlDgv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 100);
            this.panel2.TabIndex = 0;
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
            this.pnlBorder.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlBorder.Size = new System.Drawing.Size(1284, 661);
            this.pnlBorder.TabIndex = 7;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.txtSelectItemName);
            this.pnlSelect.Controls.Add(this.txtSelectItemCode);
            this.pnlSelect.Controls.Add(this.btnSelectItem);
            this.pnlSelect.Controls.Add(this.txtSelectProcessName);
            this.pnlSelect.Controls.Add(this.txtSelectProcessCode);
            this.pnlSelect.Controls.Add(this.btnSelectProcess);
            this.pnlSelect.Controls.Add(this.label2);
            this.pnlSelect.Controls.Add(this.label13);
            this.pnlSelect.Controls.Add(this.cboWoStatus);
            this.pnlSelect.Controls.Add(this.label4);
            this.pnlSelect.Controls.Add(this.label14);
            this.pnlSelect.Controls.Add(this.label48);
            this.pnlSelect.Controls.Add(this.label49);
            this.pnlSelect.Controls.Add(this.dateTimePicker2);
            this.pnlSelect.Controls.Add(this.label47);
            this.pnlSelect.Controls.Add(this.dateTimePicker1);
            this.pnlSelect.Controls.Add(this.label12);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(4, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1276, 102);
            this.pnlSelect.TabIndex = 1;
            // 
            // txtSelectItemName
            // 
            this.txtSelectItemName.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectItemName.Location = new System.Drawing.Point(213, 66);
            this.txtSelectItemName.Name = "txtSelectItemName";
            this.txtSelectItemName.ReadOnly = true;
            this.txtSelectItemName.Size = new System.Drawing.Size(100, 22);
            this.txtSelectItemName.TabIndex = 160;
            // 
            // txtSelectItemCode
            // 
            this.txtSelectItemCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectItemCode.Location = new System.Drawing.Point(104, 66);
            this.txtSelectItemCode.Name = "txtSelectItemCode";
            this.txtSelectItemCode.ReadOnly = true;
            this.txtSelectItemCode.Size = new System.Drawing.Size(82, 22);
            this.txtSelectItemCode.TabIndex = 159;
            // 
            // btnSelectItem
            // 
            this.btnSelectItem.BackColor = System.Drawing.Color.Black;
            this.btnSelectItem.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnSelectItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectItem.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectItem.Location = new System.Drawing.Point(189, 67);
            this.btnSelectItem.Name = "btnSelectItem";
            this.btnSelectItem.Size = new System.Drawing.Size(21, 21);
            this.btnSelectItem.TabIndex = 158;
            this.btnSelectItem.UseVisualStyleBackColor = false;
            this.btnSelectItem.Click += new System.EventHandler(this.btnSelectItem_Click);
            // 
            // txtSelectProcessName
            // 
            this.txtSelectProcessName.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectProcessName.Location = new System.Drawing.Point(213, 38);
            this.txtSelectProcessName.Name = "txtSelectProcessName";
            this.txtSelectProcessName.ReadOnly = true;
            this.txtSelectProcessName.Size = new System.Drawing.Size(100, 22);
            this.txtSelectProcessName.TabIndex = 157;
            // 
            // txtSelectProcessCode
            // 
            this.txtSelectProcessCode.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSelectProcessCode.Location = new System.Drawing.Point(104, 38);
            this.txtSelectProcessCode.Name = "txtSelectProcessCode";
            this.txtSelectProcessCode.ReadOnly = true;
            this.txtSelectProcessCode.Size = new System.Drawing.Size(82, 22);
            this.txtSelectProcessCode.TabIndex = 156;
            // 
            // btnSelectProcess
            // 
            this.btnSelectProcess.BackColor = System.Drawing.Color.Black;
            this.btnSelectProcess.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnSelectProcess.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectProcess.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectProcess.Location = new System.Drawing.Point(189, 39);
            this.btnSelectProcess.Name = "btnSelectProcess";
            this.btnSelectProcess.Size = new System.Drawing.Size(21, 21);
            this.btnSelectProcess.TabIndex = 155;
            this.btnSelectProcess.UseVisualStyleBackColor = false;
            this.btnSelectProcess.Click += new System.EventHandler(this.btnSelectProcess_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(383, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 23);
            this.label2.TabIndex = 154;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(23, 66);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 23);
            this.label13.TabIndex = 145;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboWoStatus
            // 
            this.cboWoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWoStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cboWoStatus.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cboWoStatus.FormattingEnabled = true;
            this.cboWoStatus.Location = new System.Drawing.Point(479, 10);
            this.cboWoStatus.Name = "cboWoStatus";
            this.cboWoStatus.Size = new System.Drawing.Size(104, 21);
            this.cboWoStatus.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(394, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 25);
            this.label4.TabIndex = 152;
            this.label4.Text = "작업지시상태";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(23, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 23);
            this.label14.TabIndex = 144;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label48.Location = new System.Drawing.Point(33, 66);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(80, 25);
            this.label48.TabIndex = 99;
            this.label48.Text = "품목명";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label49.ForeColor = System.Drawing.Color.Red;
            this.label49.Location = new System.Drawing.Point(23, 10);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(15, 23);
            this.label49.TabIndex = 143;
            this.label49.Text = "*";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(231, 10);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(106, 22);
            this.dateTimePicker2.TabIndex = 19;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.dateTimePicker2.Enter += new System.EventHandler(this.dateTimePicker_Enter);
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label47.Location = new System.Drawing.Point(212, 10);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(19, 22);
            this.label47.TabIndex = 20;
            this.label47.Text = "~";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(104, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 22);
            this.dateTimePicker1.TabIndex = 18;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            this.dateTimePicker1.Enter += new System.EventHandler(this.dateTimePicker_Enter);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(33, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 25);
            this.label12.TabIndex = 8;
            this.label12.Text = "공정";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(33, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "생산일자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlSubject2
            // 
            this.pnlSubject2.BackColor = System.Drawing.Color.White;
            this.pnlSubject2.Controls.Add(this.label3);
            this.pnlSubject2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubject2.Location = new System.Drawing.Point(0, 0);
            this.pnlSubject2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlSubject2.Name = "pnlSubject2";
            this.pnlSubject2.Size = new System.Drawing.Size(1276, 33);
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
            this.label3.Size = new System.Drawing.Size(114, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "시간대별 실적";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.panel1.Size = new System.Drawing.Size(1276, 243);
            this.panel1.TabIndex = 12;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(9, 11);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.DarkCyan};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1256, 219);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Controls.Add(this.panel1);
            this.pnlDetail.Controls.Add(this.pnlSubject2);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(4, 380);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1276, 276);
            this.pnlDetail.TabIndex = 4;
            // 
            // pnlSubject1
            // 
            this.pnlSubject1.BackColor = System.Drawing.Color.White;
            this.pnlSubject1.Controls.Add(this.label9);
            this.pnlSubject1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubject1.Location = new System.Drawing.Point(0, 5);
            this.pnlSubject1.Name = "pnlSubject1";
            this.pnlSubject1.Size = new System.Drawing.Size(1276, 33);
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
            this.label9.Size = new System.Drawing.Size(114, 33);
            this.label9.TabIndex = 4;
            this.label9.Text = "작업지시목록";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 38);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1276, 230);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            // 
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dataGridView1);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(4, 107);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1276, 273);
            this.pnlDgv.TabIndex = 6;
            // 
            // frmTimeProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "frmTimeProduction";
            this.Text = "시간대별 생산현황";
            this.Load += new System.EventHandler(this.frmTimeProduction_Load);
            this.pnlBorder.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.pnlSubject2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnlDetail.ResumeLayout(false);
            this.pnlSubject1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlDgv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlBorder;
        private System.Windows.Forms.Panel pnlSelect;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboWoStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSelectItemName;
        private System.Windows.Forms.TextBox txtSelectItemCode;
        private System.Windows.Forms.Button btnSelectItem;
        private System.Windows.Forms.TextBox txtSelectProcessName;
        private System.Windows.Forms.TextBox txtSelectProcessCode;
        private System.Windows.Forms.Button btnSelectProcess;
        private System.Windows.Forms.Panel pnlDgv;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
    }
}