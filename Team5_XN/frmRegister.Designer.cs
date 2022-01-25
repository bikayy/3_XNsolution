
namespace Team5_XN
{
    partial class frmRegister
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
            this.panel21 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreateID = new System.Windows.Forms.Button();
            this.btnIDCheck = new System.Windows.Forms.Button();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel21.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel21
            // 
            this.panel21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.panel21.Controls.Add(this.label25);
            this.panel21.Controls.Add(this.label4);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel21.Location = new System.Drawing.Point(0, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(417, 43);
            this.panel21.TabIndex = 174;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.SteelBlue;
            this.label25.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(15, 13);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(5, 18);
            this.label25.TabIndex = 10;
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(25, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "사원등록";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Controls.Add(this.btnCreateID);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 253);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(417, 40);
            this.panel5.TabIndex = 175;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(140)))), ((int)(((byte)(135)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(241, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 27);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreateID
            // 
            this.btnCreateID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(103)))), ((int)(((byte)(89)))));
            this.btnCreateID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateID.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateID.ForeColor = System.Drawing.Color.White;
            this.btnCreateID.Location = new System.Drawing.Point(330, 7);
            this.btnCreateID.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateID.Name = "btnCreateID";
            this.btnCreateID.Size = new System.Drawing.Size(79, 27);
            this.btnCreateID.TabIndex = 19;
            this.btnCreateID.Text = "등록";
            this.btnCreateID.UseVisualStyleBackColor = false;
            this.btnCreateID.Click += new System.EventHandler(this.btnCreateID_Click);
            // 
            // btnIDCheck
            // 
            this.btnIDCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(140)))), ((int)(((byte)(135)))));
            this.btnIDCheck.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnIDCheck.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIDCheck.ForeColor = System.Drawing.Color.White;
            this.btnIDCheck.Location = new System.Drawing.Point(303, 71);
            this.btnIDCheck.Name = "btnIDCheck";
            this.btnIDCheck.Size = new System.Drawing.Size(70, 26);
            this.btnIDCheck.TabIndex = 189;
            this.btnIDCheck.Text = "중복확인";
            this.btnIDCheck.UseVisualStyleBackColor = false;
            this.btnIDCheck.Click += new System.EventHandler(this.btnIDCheck_Click);
            // 
            // txtPassword2
            // 
            this.txtPassword2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword2.Location = new System.Drawing.Point(129, 151);
            this.txtPassword2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(168, 26);
            this.txtPassword2.TabIndex = 188;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label17.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(41, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 21);
            this.label17.TabIndex = 187;
            this.label17.Text = "PW확인";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(129, 193);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(168, 26);
            this.txtName.TabIndex = 181;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(41, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 180;
            this.label3.Text = "이 름";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword1
            // 
            this.txtPassword1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword1.Location = new System.Drawing.Point(129, 110);
            this.txtPassword1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword1.Name = "txtPassword1";
            this.txtPassword1.PasswordChar = '*';
            this.txtPassword1.Size = new System.Drawing.Size(168, 26);
            this.txtPassword1.TabIndex = 179;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(41, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 178;
            this.label2.Text = "PW";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(129, 71);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(168, 26);
            this.txtID.TabIndex = 177;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label18.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(41, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 21);
            this.label18.TabIndex = 176;
            this.label18.Text = "ID";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(417, 293);
            this.Controls.Add(this.btnIDCheck);
            this.Controls.Add(this.txtPassword2);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel21);
            this.Name = "frmRegister";
            this.Text = "사원등록";
            this.panel21.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnCreateID;
        protected System.Windows.Forms.Button btnIDCheck;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label18;
    }
}