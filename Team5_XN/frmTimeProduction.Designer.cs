
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
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pnlSubject1 = new System.Windows.Forms.Panel();
            this.pnlDgv = new System.Windows.Forms.Panel();
            this.pnlBorder = new System.Windows.Forms.Panel();
            this.pnlDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSubject2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label47 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.pnlSubject1.SuspendLayout();
            this.pnlDgv.SuspendLayout();
            this.pnlBorder.SuspendLayout();
            this.pnlDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSubject2.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(19, 92);
            this.panel2.TabIndex = 0;
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
            this.label9.Text = "작업지시목록";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 312);
            this.dataGridView1.TabIndex = 1;
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
            // pnlDgv
            // 
            this.pnlDgv.BackColor = System.Drawing.Color.White;
            this.pnlDgv.Controls.Add(this.dataGridView1);
            this.pnlDgv.Controls.Add(this.pnlSubject1);
            this.pnlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDgv.Location = new System.Drawing.Point(5, 99);
            this.pnlDgv.Margin = new System.Windows.Forms.Padding(10);
            this.pnlDgv.Name = "pnlDgv";
            this.pnlDgv.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.pnlDgv.Size = new System.Drawing.Size(1274, 352);
            this.pnlDgv.TabIndex = 6;
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
            this.pnlBorder.TabIndex = 7;
            // 
            // pnlDetail
            // 
            this.pnlDetail.BackColor = System.Drawing.Color.White;
            this.pnlDetail.Controls.Add(this.panel1);
            this.pnlDetail.Controls.Add(this.pnlSubject2);
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDetail.Location = new System.Drawing.Point(5, 451);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(1274, 205);
            this.pnlDetail.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 175);
            this.panel1.TabIndex = 12;
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
            this.label3.Text = "시간대별 실적";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSelect
            // 
            this.pnlSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pnlSelect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelect.Controls.Add(this.label2);
            this.pnlSelect.Controls.Add(this.label13);
            this.pnlSelect.Controls.Add(this.comboBox1);
            this.pnlSelect.Controls.Add(this.label4);
            this.pnlSelect.Controls.Add(this.label14);
            this.pnlSelect.Controls.Add(this.label48);
            this.pnlSelect.Controls.Add(this.label49);
            this.pnlSelect.Controls.Add(this.textBox29);
            this.pnlSelect.Controls.Add(this.textBox30);
            this.pnlSelect.Controls.Add(this.button7);
            this.pnlSelect.Controls.Add(this.textBox31);
            this.pnlSelect.Controls.Add(this.textBox32);
            this.pnlSelect.Controls.Add(this.button8);
            this.pnlSelect.Controls.Add(this.dateTimePicker2);
            this.pnlSelect.Controls.Add(this.label47);
            this.pnlSelect.Controls.Add(this.dateTimePicker1);
            this.pnlSelect.Controls.Add(this.label12);
            this.pnlSelect.Controls.Add(this.label1);
            this.pnlSelect.Controls.Add(this.panel2);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(5, 5);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(1274, 94);
            this.pnlSelect.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(351, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 21);
            this.label2.TabIndex = 154;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(27, 62);
            this.label13.Margin = new System.Windows.Forms.Padding(0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 21);
            this.label13.TabIndex = 145;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(445, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(363, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 152;
            this.label4.Text = "작업지시상태";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(27, 37);
            this.label14.Margin = new System.Windows.Forms.Padding(0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 21);
            this.label14.TabIndex = 144;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label48.Location = new System.Drawing.Point(39, 60);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(80, 23);
            this.label48.TabIndex = 99;
            this.label48.Text = "품목명";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label49.ForeColor = System.Drawing.Color.Red;
            this.label49.Location = new System.Drawing.Point(27, 12);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(17, 21);
            this.label49.TabIndex = 143;
            this.label49.Text = "*";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox29
            // 
            this.textBox29.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox29.Location = new System.Drawing.Point(225, 60);
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(77, 22);
            this.textBox29.TabIndex = 98;
            // 
            // textBox30
            // 
            this.textBox30.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox30.Location = new System.Drawing.Point(121, 60);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(77, 22);
            this.textBox30.TabIndex = 97;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Black;
            this.button7.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button7.Location = new System.Drawing.Point(201, 60);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(22, 22);
            this.button7.TabIndex = 96;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // textBox31
            // 
            this.textBox31.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox31.Location = new System.Drawing.Point(225, 35);
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(77, 22);
            this.textBox31.TabIndex = 95;
            // 
            // textBox32
            // 
            this.textBox32.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox32.Location = new System.Drawing.Point(121, 35);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(77, 22);
            this.textBox32.TabIndex = 94;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Black;
            this.button8.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button8.Location = new System.Drawing.Point(201, 35);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(22, 22);
            this.button8.TabIndex = 93;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(215, 9);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(78, 22);
            this.dateTimePicker2.TabIndex = 19;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label47.Location = new System.Drawing.Point(200, 9);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(17, 23);
            this.label47.TabIndex = 20;
            this.label47.Text = "~";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(121, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(78, 22);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(39, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 23);
            this.label12.TabIndex = 8;
            this.label12.Text = "공정";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(39, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "생산일자";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(7, 8);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1259, 160);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // frmTimeProduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 661);
            this.Controls.Add(this.pnlBorder);
            this.Name = "frmTimeProduction";
            this.Text = "frmTimeProduction";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.pnlSubject1.ResumeLayout(false);
            this.pnlDgv.ResumeLayout(false);
            this.pnlBorder.ResumeLayout(false);
            this.pnlDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlSubject2.ResumeLayout(false);
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel pnlSubject1;
        private System.Windows.Forms.Panel pnlDgv;
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
        private System.Windows.Forms.TextBox textBox29;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox31;
        private System.Windows.Forms.TextBox textBox32;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel pnlDetail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlSubject2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}