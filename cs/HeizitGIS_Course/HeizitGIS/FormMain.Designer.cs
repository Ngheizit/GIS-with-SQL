namespace HeizitGIS
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_UpdatePassword = new System.Windows.Forms.Button();
            this.tbx_info_Username = new System.Windows.Forms.TextBox();
            this.tbx_info_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开地图文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存地图文档ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户通信平台ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.制作者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.btn_UpdatePassword);
            this.groupBox1.Controls.Add(this.tbx_info_Username);
            this.groupBox1.Controls.Add(this.tbx_info_ID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人信息";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(111, 72);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "退出登录";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.Button_Info_Click);
            // 
            // btn_UpdatePassword
            // 
            this.btn_UpdatePassword.Location = new System.Drawing.Point(19, 72);
            this.btn_UpdatePassword.Name = "btn_UpdatePassword";
            this.btn_UpdatePassword.Size = new System.Drawing.Size(75, 23);
            this.btn_UpdatePassword.TabIndex = 2;
            this.btn_UpdatePassword.Text = "修改密码";
            this.btn_UpdatePassword.UseVisualStyleBackColor = true;
            this.btn_UpdatePassword.Click += new System.EventHandler(this.Button_Info_Click);
            // 
            // tbx_info_Username
            // 
            this.tbx_info_Username.Location = new System.Drawing.Point(66, 45);
            this.tbx_info_Username.Name = "tbx_info_Username";
            this.tbx_info_Username.ReadOnly = true;
            this.tbx_info_Username.Size = new System.Drawing.Size(132, 21);
            this.tbx_info_Username.TabIndex = 1;
            // 
            // tbx_info_ID
            // 
            this.tbx_info_ID.Location = new System.Drawing.Point(66, 18);
            this.tbx_info_ID.Name = "tbx_info_ID";
            this.tbx_info_ID.ReadOnly = true;
            this.tbx_info_ID.Size = new System.Drawing.Size(132, 21);
            this.tbx_info_ID.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "用户名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID：";
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(346, 384);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(1014, 25);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开地图文档ToolStripMenuItem,
            this.保存地图文档ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 打开地图文档ToolStripMenuItem
            // 
            this.打开地图文档ToolStripMenuItem.Name = "打开地图文档ToolStripMenuItem";
            this.打开地图文档ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开地图文档ToolStripMenuItem.Text = "打开地图文档";
            this.打开地图文档ToolStripMenuItem.Click += new System.EventHandler(this.打开地图文档ToolStripMenuItem_Click);
            // 
            // 保存地图文档ToolStripMenuItem
            // 
            this.保存地图文档ToolStripMenuItem.Name = "保存地图文档ToolStripMenuItem";
            this.保存地图文档ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.保存地图文档ToolStripMenuItem.Text = "保存地图文档";
            this.保存地图文档ToolStripMenuItem.Click += new System.EventHandler(this.保存地图文档ToolStripMenuItem_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户通信平台ToolStripMenuItem,
            this.制作者信息ToolStripMenuItem});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.其他ToolStripMenuItem.Text = "其他";
            this.其他ToolStripMenuItem.Click += new System.EventHandler(this.其他ToolStripMenuItem_Click);
            // 
            // 用户通信平台ToolStripMenuItem
            // 
            this.用户通信平台ToolStripMenuItem.Name = "用户通信平台ToolStripMenuItem";
            this.用户通信平台ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.用户通信平台ToolStripMenuItem.Text = "用户通信平台";
            this.用户通信平台ToolStripMenuItem.Click += new System.EventHandler(this.用户通信平台ToolStripMenuItem_Click);
            // 
            // 制作者信息ToolStripMenuItem
            // 
            this.制作者信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gitHubToolStripMenuItem,
            this.websiteToolStripMenuItem});
            this.制作者信息ToolStripMenuItem.Name = "制作者信息ToolStripMenuItem";
            this.制作者信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.制作者信息ToolStripMenuItem.Text = "制作者信息";
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.gitHubToolStripMenuItem.Text = "GitHub";
            this.gitHubToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.gitHubToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 653);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_info_Username;
        private System.Windows.Forms.TextBox tbx_info_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_UpdatePassword;
        private System.Windows.Forms.Button btn_exit;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开地图文档ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户通信平台ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 制作者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存地图文档ToolStripMenuItem;
    }
}

