
namespace Team5_XN
{
    partial class PopupIndPlan
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtItemName = new WinReflectionSettings.PlaceholderTextBox();
            this.btnItemSearch = new System.Windows.Forms.Button();
            this.txtItemCode = new WinReflectionSettings.PlaceholderTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtPlanQty = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpPlanMonth = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnWCSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtWCCode = new WinReflectionSettings.PlaceholderTextBox();
            this.txtWCName = new WinReflectionSettings.PlaceholderTextBox();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtItemName);
            this.groupBox2.Controls.Add(this.btnItemSearch);
            this.groupBox2.Controls.Add(this.txtItemCode);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtRemark);
            this.groupBox2.Controls.Add(this.txtPlanQty);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.dtpPlanMonth);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnWCSearch);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtWCCode);
            this.groupBox2.Controls.Add(this.txtWCName);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(517, 252);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "생산계획정보";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(23, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 29);
            this.label14.TabIndex = 66;
            this.label14.Text = "품목";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtItemName
            // 
            this.txtItemName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemName.Location = new System.Drawing.Point(301, 59);
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.PlaceholderText = "품목 명";
            this.txtItemName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtItemName.ReadOnly = true;
            this.txtItemName.Size = new System.Drawing.Size(202, 25);
            this.txtItemName.TabIndex = 69;
            // 
            // btnItemSearch
            // 
            this.btnItemSearch.BackColor = System.Drawing.Color.Black;
            this.btnItemSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnItemSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnItemSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnItemSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnItemSearch.Location = new System.Drawing.Point(269, 59);
            this.btnItemSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnItemSearch.Name = "btnItemSearch";
            this.btnItemSearch.Size = new System.Drawing.Size(26, 26);
            this.btnItemSearch.TabIndex = 65;
            this.btnItemSearch.UseVisualStyleBackColor = false;
            this.btnItemSearch.Click += new System.EventHandler(this.btnItemSearch_Click);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtItemCode.Location = new System.Drawing.Point(125, 59);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.PlaceholderText = "품목코드";
            this.txtItemCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtItemCode.ReadOnly = true;
            this.txtItemCode.Size = new System.Drawing.Size(138, 25);
            this.txtItemCode.TabIndex = 68;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(4, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 29);
            this.label13.TabIndex = 67;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(125, 156);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(378, 80);
            this.txtRemark.TabIndex = 64;
            // 
            // txtPlanQty
            // 
            this.txtPlanQty.Location = new System.Drawing.Point(125, 92);
            this.txtPlanQty.Name = "txtPlanQty";
            this.txtPlanQty.Size = new System.Drawing.Size(378, 25);
            this.txtPlanQty.TabIndex = 63;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(4, 150);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 29);
            this.label23.TabIndex = 62;
            this.label23.Text = "*";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label24.Location = new System.Drawing.Point(23, 150);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(96, 29);
            this.label24.TabIndex = 61;
            this.label24.Text = "비고";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(4, 91);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 29);
            this.label16.TabIndex = 59;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label17.Location = new System.Drawing.Point(23, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(96, 29);
            this.label17.TabIndex = 58;
            this.label17.Text = "생산계획수량";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPlanMonth
            // 
            this.dtpPlanMonth.CustomFormat = "yyyy-MM";
            this.dtpPlanMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPlanMonth.Location = new System.Drawing.Point(125, 28);
            this.dtpPlanMonth.Name = "dtpPlanMonth";
            this.dtpPlanMonth.Size = new System.Drawing.Size(138, 25);
            this.dtpPlanMonth.TabIndex = 55;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(23, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 29);
            this.label10.TabIndex = 48;
            this.label10.Text = "작업장";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnWCSearch
            // 
            this.btnWCSearch.BackColor = System.Drawing.Color.Black;
            this.btnWCSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnWCSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnWCSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWCSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnWCSearch.Location = new System.Drawing.Point(269, 123);
            this.btnWCSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWCSearch.Name = "btnWCSearch";
            this.btnWCSearch.Size = new System.Drawing.Size(26, 26);
            this.btnWCSearch.TabIndex = 47;
            this.btnWCSearch.UseVisualStyleBackColor = false;
            this.btnWCSearch.Click += new System.EventHandler(this.btnWCSearch_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(4, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 29);
            this.label11.TabIndex = 54;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(4, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 29);
            this.label9.TabIndex = 49;
            this.label9.Text = "*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label12.Location = new System.Drawing.Point(23, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 29);
            this.label12.TabIndex = 53;
            this.label12.Text = "생산계획월";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtWCCode
            // 
            this.txtWCCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWCCode.Location = new System.Drawing.Point(125, 123);
            this.txtWCCode.Name = "txtWCCode";
            this.txtWCCode.PlaceholderText = "작업장 코드";
            this.txtWCCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtWCCode.ReadOnly = true;
            this.txtWCCode.Size = new System.Drawing.Size(138, 25);
            this.txtWCCode.TabIndex = 50;
            // 
            // txtWCName
            // 
            this.txtWCName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWCName.Location = new System.Drawing.Point(301, 123);
            this.txtWCName.Name = "txtWCName";
            this.txtWCName.PlaceholderText = "작업장 명";
            this.txtWCName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.txtWCName.ReadOnly = true;
            this.txtWCName.Size = new System.Drawing.Size(202, 25);
            this.txtWCName.TabIndex = 51;
            // 
            // btnCancle
            // 
            this.btnCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancle.BackColor = System.Drawing.Color.White;
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancle.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancle.Location = new System.Drawing.Point(424, 271);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(105, 41);
            this.btnCancle.TabIndex = 52;
            this.btnCancle.Text = "Cancle";
            this.btnCancle.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(313, 271);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(105, 41);
            this.btnOK.TabIndex = 51;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // PopupIndPlan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(540, 321);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupIndPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "생산계획추가";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtPlanQty;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpPlanMonth;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnWCSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private WinReflectionSettings.PlaceholderTextBox txtWCCode;
        private WinReflectionSettings.PlaceholderTextBox txtWCName;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label14;
        private WinReflectionSettings.PlaceholderTextBox txtItemName;
        private System.Windows.Forms.Button btnItemSearch;
        private WinReflectionSettings.PlaceholderTextBox txtItemCode;
        private System.Windows.Forms.Label label13;
    }
}