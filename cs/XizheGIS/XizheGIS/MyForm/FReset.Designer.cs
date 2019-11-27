namespace XizheGIS.MyForm
{
    partial class FReset
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
            this.tbx_NewPassword = new DevExpress.XtraEditors.TextEdit();
            this.tbx_OldPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_Username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_OK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_ReNewPassword = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_NewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_OldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_ReNewPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tbx_NewPassword
            // 
            this.tbx_NewPassword.Location = new System.Drawing.Point(95, 69);
            this.tbx_NewPassword.Name = "tbx_NewPassword";
            this.tbx_NewPassword.Size = new System.Drawing.Size(150, 20);
            this.tbx_NewPassword.TabIndex = 2;
            // 
            // tbx_OldPassword
            // 
            this.tbx_OldPassword.Location = new System.Drawing.Point(95, 43);
            this.tbx_OldPassword.Name = "tbx_OldPassword";
            this.tbx_OldPassword.Size = new System.Drawing.Size(150, 20);
            this.tbx_OldPassword.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(41, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 14);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "新密码：";
            // 
            // tbx_Username
            // 
            this.tbx_Username.Location = new System.Drawing.Point(95, 17);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(150, 20);
            this.tbx_Username.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(41, 46);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "旧密码：";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(154, 126);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(53, 126);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "提交";
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(41, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "用户名：";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(29, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "确定密码：";
            // 
            // tbx_ReNewPassword
            // 
            this.tbx_ReNewPassword.Location = new System.Drawing.Point(95, 95);
            this.tbx_ReNewPassword.Name = "tbx_ReNewPassword";
            this.tbx_ReNewPassword.Size = new System.Drawing.Size(150, 20);
            this.tbx_ReNewPassword.TabIndex = 3;
            // 
            // FReset
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(284, 163);
            this.Controls.Add(this.tbx_ReNewPassword);
            this.Controls.Add(this.tbx_NewPassword);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.tbx_OldPassword);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FReset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FReset";
            ((System.ComponentModel.ISupportInitialize)(this.tbx_NewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_OldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_ReNewPassword.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit tbx_NewPassword;
        private DevExpress.XtraEditors.TextEdit tbx_OldPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tbx_Username;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_OK;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit tbx_ReNewPassword;
    }
}