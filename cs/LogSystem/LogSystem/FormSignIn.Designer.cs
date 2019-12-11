namespace LogSystem
{
    partial class FormSignIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSignIn));
            this.Pages = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.Page_SignIn = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btn_SignIn_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SignIn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.tbx_SignIn_Password = new System.Windows.Forms.TextBox();
            this.tbx_SignIn_Username = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Page_SignOut = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btn_Exit = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btn_SignOut_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.btn_SignOut_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.tbx_SignOut_Password = new System.Windows.Forms.TextBox();
            this.tbx_SignOut_Username = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_SignOut_RePassword = new System.Windows.Forms.TextBox();
            this.Pages.SuspendLayout();
            this.Page_SignIn.SuspendLayout();
            this.Page_SignOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pages
            // 
            this.Pages.Controls.Add(this.Page_SignIn);
            this.Pages.Controls.Add(this.Page_SignOut);
            this.Pages.Controls.Add(this.btn_Exit);
            this.Pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pages.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pages.Location = new System.Drawing.Point(0, 0);
            this.Pages.Name = "Pages";
            this.Pages.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.Pages.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.Page_SignIn,
            this.Page_SignOut,
            this.btn_Exit});
            this.Pages.RegularSize = new System.Drawing.Size(403, 244);
            this.Pages.SelectedPage = this.Page_SignIn;
            this.Pages.SelectedPageIndex = 0;
            this.Pages.Size = new System.Drawing.Size(403, 244);
            this.Pages.TabIndex = 0;
            this.Pages.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.Pages_SelectedPageChanged);
            // 
            // Page_SignIn
            // 
            this.Page_SignIn.Caption = "登录";
            this.Page_SignIn.Controls.Add(this.btn_SignIn_Clear);
            this.Page_SignIn.Controls.Add(this.btn_SignIn_Ok);
            this.Page_SignIn.Controls.Add(this.tbx_SignIn_Password);
            this.Page_SignIn.Controls.Add(this.tbx_SignIn_Username);
            this.Page_SignIn.Controls.Add(this.labelControl2);
            this.Page_SignIn.Controls.Add(this.labelControl1);
            this.Page_SignIn.Image = global::LogSystem.Properties.Resources.assignto_32x32;
            this.Page_SignIn.Name = "Page_SignIn";
            this.Page_SignIn.Size = new System.Drawing.Size(311, 184);
            // 
            // btn_SignIn_Clear
            // 
            this.btn_SignIn_Clear.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SignIn_Clear.Appearance.Options.UseFont = true;
            this.btn_SignIn_Clear.Image = global::LogSystem.Properties.Resources.cancel_16x16;
            this.btn_SignIn_Clear.Location = new System.Drawing.Point(211, 131);
            this.btn_SignIn_Clear.Name = "btn_SignIn_Clear";
            this.btn_SignIn_Clear.Size = new System.Drawing.Size(97, 30);
            this.btn_SignIn_Clear.TabIndex = 3;
            this.btn_SignIn_Clear.Text = "清空";
            // 
            // btn_SignIn_Ok
            // 
            this.btn_SignIn_Ok.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SignIn_Ok.Appearance.Options.UseFont = true;
            this.btn_SignIn_Ok.Image = global::LogSystem.Properties.Resources.apply_16x16;
            this.btn_SignIn_Ok.Location = new System.Drawing.Point(51, 131);
            this.btn_SignIn_Ok.Name = "btn_SignIn_Ok";
            this.btn_SignIn_Ok.Size = new System.Drawing.Size(97, 30);
            this.btn_SignIn_Ok.TabIndex = 3;
            this.btn_SignIn_Ok.Text = "登录";
            this.btn_SignIn_Ok.Click += new System.EventHandler(this.btn_SignIn_Ok_Click);
            // 
            // tbx_SignIn_Password
            // 
            this.tbx_SignIn_Password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_SignIn_Password.Location = new System.Drawing.Point(145, 80);
            this.tbx_SignIn_Password.Name = "tbx_SignIn_Password";
            this.tbx_SignIn_Password.PasswordChar = '*';
            this.tbx_SignIn_Password.Size = new System.Drawing.Size(130, 26);
            this.tbx_SignIn_Password.TabIndex = 2;
            // 
            // tbx_SignIn_Username
            // 
            this.tbx_SignIn_Username.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_SignIn_Username.Location = new System.Drawing.Point(145, 26);
            this.tbx_SignIn_Username.Name = "tbx_SignIn_Username";
            this.tbx_SignIn_Username.Size = new System.Drawing.Size(130, 26);
            this.tbx_SignIn_Username.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl2.Location = new System.Drawing.Point(60, 83);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "密 码 ：";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Location = new System.Drawing.Point(51, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "用 户 名 ：";
            // 
            // Page_SignOut
            // 
            this.Page_SignOut.Caption = "注册";
            this.Page_SignOut.Controls.Add(this.btn_SignOut_Clear);
            this.Page_SignOut.Controls.Add(this.btn_SignOut_Ok);
            this.Page_SignOut.Controls.Add(this.tbx_SignOut_RePassword);
            this.Page_SignOut.Controls.Add(this.tbx_SignOut_Password);
            this.Page_SignOut.Controls.Add(this.labelControl5);
            this.Page_SignOut.Controls.Add(this.tbx_SignOut_Username);
            this.Page_SignOut.Controls.Add(this.labelControl3);
            this.Page_SignOut.Controls.Add(this.labelControl4);
            this.Page_SignOut.Image = global::LogSystem.Properties.Resources.role_32x32;
            this.Page_SignOut.Name = "Page_SignOut";
            this.Page_SignOut.Size = new System.Drawing.Size(311, 184);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "退出";
            this.btn_Exit.Image = global::LogSystem.Properties.Resources.close_32x32;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(311, 184);
            // 
            // btn_SignOut_Clear
            // 
            this.btn_SignOut_Clear.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SignOut_Clear.Appearance.Options.UseFont = true;
            this.btn_SignOut_Clear.Image = global::LogSystem.Properties.Resources.cancel_16x16;
            this.btn_SignOut_Clear.Location = new System.Drawing.Point(206, 132);
            this.btn_SignOut_Clear.Name = "btn_SignOut_Clear";
            this.btn_SignOut_Clear.Size = new System.Drawing.Size(97, 30);
            this.btn_SignOut_Clear.TabIndex = 8;
            this.btn_SignOut_Clear.Text = "清空";
            // 
            // btn_SignOut_Ok
            // 
            this.btn_SignOut_Ok.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_SignOut_Ok.Appearance.Options.UseFont = true;
            this.btn_SignOut_Ok.Image = global::LogSystem.Properties.Resources.apply_16x16;
            this.btn_SignOut_Ok.Location = new System.Drawing.Point(46, 132);
            this.btn_SignOut_Ok.Name = "btn_SignOut_Ok";
            this.btn_SignOut_Ok.Size = new System.Drawing.Size(97, 30);
            this.btn_SignOut_Ok.TabIndex = 9;
            this.btn_SignOut_Ok.Text = "注册";
            this.btn_SignOut_Ok.Click += new System.EventHandler(this.btn_SignOut_Ok_Click);
            // 
            // tbx_SignOut_Password
            // 
            this.tbx_SignOut_Password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_SignOut_Password.Location = new System.Drawing.Point(159, 53);
            this.tbx_SignOut_Password.Name = "tbx_SignOut_Password";
            this.tbx_SignOut_Password.PasswordChar = '*';
            this.tbx_SignOut_Password.Size = new System.Drawing.Size(130, 26);
            this.tbx_SignOut_Password.TabIndex = 6;
            // 
            // tbx_SignOut_Username
            // 
            this.tbx_SignOut_Username.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_SignOut_Username.Location = new System.Drawing.Point(159, 15);
            this.tbx_SignOut_Username.Name = "tbx_SignOut_Username";
            this.tbx_SignOut_Username.Size = new System.Drawing.Size(130, 26);
            this.tbx_SignOut_Username.TabIndex = 7;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl3.Location = new System.Drawing.Point(74, 56);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "密 码 ：";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl4.Location = new System.Drawing.Point(65, 18);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(88, 16);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "用 户 名 ：";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl5.Location = new System.Drawing.Point(41, 94);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(112, 16);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "确 认 密 码 ：";
            // 
            // tbx_SignOut_RePassword
            // 
            this.tbx_SignOut_RePassword.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_SignOut_RePassword.Location = new System.Drawing.Point(159, 91);
            this.tbx_SignOut_RePassword.Name = "tbx_SignOut_RePassword";
            this.tbx_SignOut_RePassword.PasswordChar = '*';
            this.tbx_SignOut_RePassword.Size = new System.Drawing.Size(130, 26);
            this.tbx_SignOut_RePassword.TabIndex = 6;
            // 
            // FormSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 244);
            this.Controls.Add(this.Pages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSignIn";
            this.Text = "登录界面";
            this.Pages.ResumeLayout(false);
            this.Page_SignIn.ResumeLayout(false);
            this.Page_SignIn.PerformLayout();
            this.Page_SignOut.ResumeLayout(false);
            this.Page_SignOut.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.NavigationPane Pages;
        private DevExpress.XtraBars.Navigation.NavigationPage Page_SignIn;
        private DevExpress.XtraBars.Navigation.NavigationPage Page_SignOut;
        private DevExpress.XtraBars.Navigation.NavigationPage btn_Exit;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox tbx_SignIn_Password;
        private System.Windows.Forms.TextBox tbx_SignIn_Username;
        private DevExpress.XtraEditors.SimpleButton btn_SignIn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_SignIn_Clear;
        private DevExpress.XtraEditors.SimpleButton btn_SignOut_Clear;
        private DevExpress.XtraEditors.SimpleButton btn_SignOut_Ok;
        private System.Windows.Forms.TextBox tbx_SignOut_RePassword;
        private System.Windows.Forms.TextBox tbx_SignOut_Password;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox tbx_SignOut_Username;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;

    }
}