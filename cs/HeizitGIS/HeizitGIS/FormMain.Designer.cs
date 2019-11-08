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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_UpdatePassword = new System.Windows.Forms.Button();
            this.tbx_info_Username = new System.Windows.Forms.TextBox();
            this.tbx_info_ID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(9, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人信息";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(86, 72);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "退出登录";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.Button_Info_Click);
            // 
            // btn_UpdatePassword
            // 
            this.btn_UpdatePassword.Location = new System.Drawing.Point(9, 72);
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
            this.tbx_info_Username.Size = new System.Drawing.Size(88, 21);
            this.tbx_info_Username.TabIndex = 1;
            // 
            // tbx_info_ID
            // 
            this.tbx_info_ID.Location = new System.Drawing.Point(66, 18);
            this.tbx_info_ID.Name = "tbx_info_ID";
            this.tbx_info_ID.ReadOnly = true;
            this.tbx_info_ID.Size = new System.Drawing.Size(88, 21);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 417);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "主窗体";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbx_info_Username;
        private System.Windows.Forms.TextBox tbx_info_ID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_UpdatePassword;
        private System.Windows.Forms.Button btn_exit;
    }
}

