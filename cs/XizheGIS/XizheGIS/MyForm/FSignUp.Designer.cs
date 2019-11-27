namespace XizheGIS.MyForm
{
    partial class FSignUp
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
            this.tbx_Password = new DevExpress.XtraEditors.TextEdit();
            this.tbx_Username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_RePassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_RePassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_Password
            // 
            this.tbx_Password.Location = new System.Drawing.Point(92, 38);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(150, 20);
            this.tbx_Password.TabIndex = 1;
            // 
            // tbx_Username
            // 
            this.tbx_Username.Location = new System.Drawing.Point(92, 12);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(150, 20);
            this.tbx_Username.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(50, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "密码：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(151, 92);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 4;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(50, 92);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "注册";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(38, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "用户名：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 67);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "确定密码：";
            // 
            // tbx_RePassword
            // 
            this.tbx_RePassword.Location = new System.Drawing.Point(92, 64);
            this.tbx_RePassword.Name = "tbx_RePassword";
            this.tbx_RePassword.Size = new System.Drawing.Size(150, 20);
            this.tbx_RePassword.TabIndex = 2;
            // 
            // FSignUp
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(278, 131);
            this.Controls.Add(this.tbx_RePassword);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FSignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSignUp";
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_RePassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbx_Password;
        private DevExpress.XtraEditors.TextEdit tbx_Username;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbx_RePassword;
    }
}