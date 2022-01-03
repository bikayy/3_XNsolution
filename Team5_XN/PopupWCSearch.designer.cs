
namespace Team5_XN
{
    partial class PopupWCSearch
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.bntCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.r_txtPrcName = new WinReflectionSettings.PlaceholderTextBox();
            this.r_txtWcName = new WinReflectionSettings.PlaceholderTextBox();
            this.r_txtWcCode = new WinReflectionSettings.PlaceholderTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Black;
            this.btnRefresh.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(489, 12);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 25);
            this.btnRefresh.TabIndex = 75;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(439, 25);
            this.txtSearch.TabIndex = 74;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Black;
            this.btnSearch.BackgroundImage = global::Team5_XN.Properties.Resources.icon_find;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(457, 12);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 25);
            this.btnSearch.TabIndex = 71;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bntCancle
            // 
            this.bntCancle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bntCancle.BackColor = System.Drawing.Color.White;
            this.bntCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bntCancle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bntCancle.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bntCancle.ForeColor = System.Drawing.Color.Black;
            this.bntCancle.Location = new System.Drawing.Point(428, 393);
            this.bntCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bntCancle.Name = "bntCancle";
            this.bntCancle.Size = new System.Drawing.Size(87, 43);
            this.bntCancle.TabIndex = 70;
            this.bntCancle.Text = "Cancle";
            this.bntCancle.UseVisualStyleBackColor = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.White;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(325, 393);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 43);
            this.btnOK.TabIndex = 69;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvList
            // 
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(12, 43);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersWidth = 51;
            this.dgvList.RowTemplate.Height = 27;
            this.dgvList.Size = new System.Drawing.Size(503, 300);
            this.dgvList.TabIndex = 68;
            this.dgvList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvList_CellClick);
            // 
            // r_txtPrcName
            // 
            this.r_txtPrcName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtPrcName.Location = new System.Drawing.Point(12, 411);
            this.r_txtPrcName.Name = "r_txtPrcName";
            this.r_txtPrcName.PlaceholderText = "공정 명";
            this.r_txtPrcName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtPrcName.ReadOnly = true;
            this.r_txtPrcName.Size = new System.Drawing.Size(295, 25);
            this.r_txtPrcName.TabIndex = 76;
            // 
            // r_txtWcName
            // 
            this.r_txtWcName.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtWcName.Location = new System.Drawing.Point(12, 380);
            this.r_txtWcName.Name = "r_txtWcName";
            this.r_txtWcName.PlaceholderText = "작업장 명";
            this.r_txtWcName.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtWcName.ReadOnly = true;
            this.r_txtWcName.Size = new System.Drawing.Size(295, 25);
            this.r_txtWcName.TabIndex = 73;
            // 
            // r_txtWcCode
            // 
            this.r_txtWcCode.Font = new System.Drawing.Font("맑은 고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.r_txtWcCode.Location = new System.Drawing.Point(12, 349);
            this.r_txtWcCode.Name = "r_txtWcCode";
            this.r_txtWcCode.PlaceholderText = "작업장코드";
            this.r_txtWcCode.PlaceholderTextColor = System.Drawing.SystemColors.ButtonShadow;
            this.r_txtWcCode.ReadOnly = true;
            this.r_txtWcCode.Size = new System.Drawing.Size(295, 25);
            this.r_txtWcCode.TabIndex = 72;
            // 
            // PopupWCSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(527, 448);
            this.Controls.Add(this.r_txtPrcName);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.r_txtWcName);
            this.Controls.Add(this.r_txtWcCode);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.bntCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupWCSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "작업장검색";
            this.Load += new System.EventHandler(this.PopupWCSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtSearch;
        private WinReflectionSettings.PlaceholderTextBox r_txtWcName;
        private WinReflectionSettings.PlaceholderTextBox r_txtWcCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button bntCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvList;
        private WinReflectionSettings.PlaceholderTextBox r_txtPrcName;
    }
}