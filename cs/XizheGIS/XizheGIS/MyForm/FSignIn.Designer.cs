namespace XizheGIS.MyForm
{
    partial class FSignIn
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_SignIn = new DevExpress.XtraEditors.SimpleButton();
            this.tbx_Username = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_Password = new DevExpress.XtraEditors.TextEdit();
            this.btn_SignUp = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ResetPassword = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Password.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "用户名：";
            // 
            // btn_SignIn
            // 
            this.btn_SignIn.Location = new System.Drawing.Point(44, 68);
            this.btn_SignIn.Name = "btn_SignIn";
            this.btn_SignIn.Size = new System.Drawing.Size(75, 23);
            this.btn_SignIn.TabIndex = 2;
            this.btn_SignIn.Text = "登录";
            this.btn_SignIn.Click += new System.EventHandler(this.btn_SignIn_Click);
            // 
            // tbx_Username
            // 
            this.tbx_Username.Location = new System.Drawing.Point(101, 16);
            this.tbx_Username.Name = "tbx_Username";
            this.tbx_Username.Size = new System.Drawing.Size(150, 20);
            this.tbx_Username.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(59, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "密码：";
            // 
            // tbx_Password
            // 
            this.tbx_Password.Location = new System.Drawing.Point(101, 42);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.Size = new System.Drawing.Size(150, 20);
            this.tbx_Password.TabIndex = 1;
            // 
            // btn_SignUp
            // 
            this.btn_SignUp.Location = new System.Drawing.Point(150, 68);
            this.btn_SignUp.Name = "btn_SignUp";
            this.btn_SignUp.Size = new System.Drawing.Size(75, 23);
            this.btn_SignUp.TabIndex = 3;
            this.btn_SignUp.Text = "注册";
            this.btn_SignUp.Click += new System.EventHandler(this.btn_SignUp_Click);
            // 
            // btn_ResetPassword
            // 
            this.btn_ResetPassword.Location = new System.Drawing.Point(44, 97);
            this.btn_ResetPassword.Name = "btn_ResetPassword";
            this.btn_ResetPassword.Size = new System.Drawing.Size(75, 23);
            this.btn_ResetPassword.TabIndex = 4;
            this.btn_ResetPassword.Text = "重置密码";
            this.btn_ResetPassword.Click += new System.EventHandler(this.btn_ResetPassword_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Exit.Location = new System.Drawing.Point(150, 97);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 23);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // FSignIn
            // 
            this.AcceptButton = this.btn_SignIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Exit;
            this.ClientSize = new System.Drawing.Size(280, 135);
            this.Controls.Add(this.tbx_Password);
            this.Controls.Add(this.tbx_Username);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_ResetPassword);
            this.Controls.Add(this.btn_SignUp);
            this.Controls.Add(this.btn_SignIn);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSignIn";
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbx_Password.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_SignIn;
        private DevExpress.XtraEditors.TextEdit tbx_Username;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tbx_Password;
        private DevExpress.XtraEditors.SimpleButton btn_SignUp;
        private DevExpress.XtraEditors.SimpleButton btn_ResetPassword;
        private DevExpress.XtraEditors.SimpleButton btn_Exit;
    }
}