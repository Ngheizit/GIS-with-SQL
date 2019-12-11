namespace LogSystem
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.pages = new DevExpress.XtraBars.Navigation.NavigationPane();
            this.page_Inbox = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btn_SetRead = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView_Inbox = new System.Windows.Forms.DataGridView();
            this.page_Outbox = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.comboBox_SendToUsername = new System.Windows.Forms.ComboBox();
            this.btn_SendEmail = new DevExpress.XtraEditors.SimpleButton();
            this.tbx_SendText = new System.Windows.Forms.RichTextBox();
            this.dataGridView_Outbox = new System.Windows.Forms.DataGridView();
            this.btn_ReSignIn = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.btn_Exit = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.tbx_Description = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.pages.SuspendLayout();
            this.page_Inbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Inbox)).BeginInit();
            this.page_Outbox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Outbox)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.pages);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tbx_Description);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(918, 356);
            this.splitContainerControl1.SplitterPosition = 619;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // pages
            // 
            this.pages.Controls.Add(this.page_Inbox);
            this.pages.Controls.Add(this.page_Outbox);
            this.pages.Controls.Add(this.btn_ReSignIn);
            this.pages.Controls.Add(this.btn_Exit);
            this.pages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pages.Location = new System.Drawing.Point(0, 0);
            this.pages.Name = "pages";
            this.pages.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.pages.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.page_Inbox,
            this.page_Outbox,
            this.btn_ReSignIn,
            this.btn_Exit});
            this.pages.RegularSize = new System.Drawing.Size(619, 356);
            this.pages.SelectedPage = this.page_Outbox;
            this.pages.SelectedPageIndex = 1;
            this.pages.Size = new System.Drawing.Size(619, 356);
            this.pages.TabIndex = 0;
            this.pages.Text = "navigationPane1";
            this.pages.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.pages_SelectedPageChanged);
            // 
            // page_Inbox
            // 
            this.page_Inbox.Caption = "收件箱";
            this.page_Inbox.Controls.Add(this.dataGridView_Inbox);
            this.page_Inbox.Controls.Add(this.btn_SetRead);
            this.page_Inbox.Image = global::LogSystem.Properties.Resources.emailtemplate_32x32;
            this.page_Inbox.Name = "page_Inbox";
            this.page_Inbox.Size = new System.Drawing.Size(503, 296);
            // 
            // btn_SetRead
            // 
            this.btn_SetRead.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_SetRead.Image = global::LogSystem.Properties.Resources.reading_16x16;
            this.btn_SetRead.Location = new System.Drawing.Point(0, 0);
            this.btn_SetRead.Name = "btn_SetRead";
            this.btn_SetRead.Size = new System.Drawing.Size(503, 33);
            this.btn_SetRead.TabIndex = 0;
            this.btn_SetRead.Text = "标记为已读";
            this.btn_SetRead.Click += new System.EventHandler(this.btn_SetRead_Click);
            // 
            // dataGridView_Inbox
            // 
            this.dataGridView_Inbox.AllowUserToAddRows = false;
            this.dataGridView_Inbox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Inbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Inbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Inbox.Location = new System.Drawing.Point(0, 33);
            this.dataGridView_Inbox.Name = "dataGridView_Inbox";
            this.dataGridView_Inbox.ReadOnly = true;
            this.dataGridView_Inbox.RowHeadersWidth = 20;
            this.dataGridView_Inbox.RowTemplate.Height = 23;
            this.dataGridView_Inbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Inbox.ShowEditingIcon = false;
            this.dataGridView_Inbox.Size = new System.Drawing.Size(503, 263);
            this.dataGridView_Inbox.TabIndex = 3;
            this.dataGridView_Inbox.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // page_Outbox
            // 
            this.page_Outbox.Caption = "发件箱";
            this.page_Outbox.Controls.Add(this.dataGridView_Outbox);
            this.page_Outbox.Controls.Add(this.groupBox2);
            this.page_Outbox.Image = global::LogSystem.Properties.Resources.send_32x32;
            this.page_Outbox.Name = "page_Outbox";
            this.page_Outbox.Size = new System.Drawing.Size(503, 296);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Controls.Add(this.comboBox_SendToUsername);
            this.groupBox2.Controls.Add(this.btn_SendEmail);
            this.groupBox2.Controls.Add(this.tbx_SendText);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "收 件 人 ：";
            // 
            // comboBox_SendToUsername
            // 
            this.comboBox_SendToUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SendToUsername.FormattingEnabled = true;
            this.comboBox_SendToUsername.Location = new System.Drawing.Point(72, 18);
            this.comboBox_SendToUsername.Name = "comboBox_SendToUsername";
            this.comboBox_SendToUsername.Size = new System.Drawing.Size(311, 22);
            this.comboBox_SendToUsername.TabIndex = 2;
            // 
            // btn_SendEmail
            // 
            this.btn_SendEmail.Image = global::LogSystem.Properties.Resources.send_16x16;
            this.btn_SendEmail.Location = new System.Drawing.Point(389, 17);
            this.btn_SendEmail.Name = "btn_SendEmail";
            this.btn_SendEmail.Size = new System.Drawing.Size(75, 23);
            this.btn_SendEmail.TabIndex = 1;
            this.btn_SendEmail.Text = "发送";
            this.btn_SendEmail.Click += new System.EventHandler(this.btn_SendEmail_Click);
            // 
            // tbx_SendText
            // 
            this.tbx_SendText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbx_SendText.Location = new System.Drawing.Point(3, 46);
            this.tbx_SendText.Name = "tbx_SendText";
            this.tbx_SendText.Size = new System.Drawing.Size(497, 79);
            this.tbx_SendText.TabIndex = 0;
            this.tbx_SendText.Text = "";
            // 
            // dataGridView_Outbox
            // 
            this.dataGridView_Outbox.AllowUserToAddRows = false;
            this.dataGridView_Outbox.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Outbox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Outbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Outbox.Location = new System.Drawing.Point(0, 128);
            this.dataGridView_Outbox.Name = "dataGridView_Outbox";
            this.dataGridView_Outbox.ReadOnly = true;
            this.dataGridView_Outbox.RowHeadersWidth = 20;
            this.dataGridView_Outbox.RowTemplate.Height = 23;
            this.dataGridView_Outbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Outbox.ShowEditingIcon = false;
            this.dataGridView_Outbox.Size = new System.Drawing.Size(503, 168);
            this.dataGridView_Outbox.TabIndex = 0;
            this.dataGridView_Outbox.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            // 
            // btn_ReSignIn
            // 
            this.btn_ReSignIn.Caption = "切换用户";
            this.btn_ReSignIn.Image = global::LogSystem.Properties.Resources.refresh2_32x32;
            this.btn_ReSignIn.Name = "btn_ReSignIn";
            this.btn_ReSignIn.Size = new System.Drawing.Size(503, 296);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "退出";
            this.btn_Exit.Image = global::LogSystem.Properties.Resources.close_32x32;
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(503, 296);
            // 
            // tbx_Description
            // 
            this.tbx_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbx_Description.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbx_Description.Location = new System.Drawing.Point(0, 0);
            this.tbx_Description.Name = "tbx_Description";
            this.tbx_Description.ReadOnly = true;
            this.tbx_Description.Size = new System.Drawing.Size(294, 356);
            this.tbx_Description.TabIndex = 0;
            this.tbx_Description.Text = "";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 356);
            this.Controls.Add(this.splitContainerControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.pages.ResumeLayout(false);
            this.page_Inbox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Inbox)).EndInit();
            this.page_Outbox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Outbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.Navigation.NavigationPane pages;
        private DevExpress.XtraBars.Navigation.NavigationPage page_Inbox;
        private DevExpress.XtraBars.Navigation.NavigationPage page_Outbox;
        private DevExpress.XtraBars.Navigation.NavigationPage btn_ReSignIn;
        private DevExpress.XtraBars.Navigation.NavigationPage btn_Exit;
        private System.Windows.Forms.RichTextBox tbx_Description;
        private System.Windows.Forms.DataGridView dataGridView_Outbox;
        private System.Windows.Forms.DataGridView dataGridView_Inbox;
        private DevExpress.XtraEditors.SimpleButton btn_SetRead;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tbx_SendText;
        private System.Windows.Forms.ComboBox comboBox_SendToUsername;
        private DevExpress.XtraEditors.SimpleButton btn_SendEmail;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

