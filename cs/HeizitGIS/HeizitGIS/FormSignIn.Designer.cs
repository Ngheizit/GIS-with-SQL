namespace HeizitGIS
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
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_signUp = new System.Windows.Forms.Button();
            this.btn_signIn = new System.Windows.Forms.Button();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.tbx_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.Color.White;
            this.btn_exit.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_exit.Location = new System.Drawing.Point(180, 285);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(80, 28);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "退出";
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.Buttons_Click);
            this.btn_exit.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.btn_exit.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // btn_signUp
            // 
            this.btn_signUp.BackColor = System.Drawing.Color.White;
            this.btn_signUp.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_signUp.Location = new System.Drawing.Point(180, 229);
            this.btn_signUp.Name = "btn_signUp";
            this.btn_signUp.Size = new System.Drawing.Size(80, 28);
            this.btn_signUp.TabIndex = 3;
            this.btn_signUp.Text = "注册";
            this.btn_signUp.UseVisualStyleBackColor = false;
            this.btn_signUp.Click += new System.EventHandler(this.Buttons_Click);
            this.btn_signUp.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.btn_signUp.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // btn_signIn
            // 
            this.btn_signIn.BackColor = System.Drawing.Color.White;
            this.btn_signIn.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_signIn.Location = new System.Drawing.Point(58, 229);
            this.btn_signIn.Name = "btn_signIn";
            this.btn_signIn.Size = new System.Drawing.Size(80, 28);
            this.btn_signIn.TabIndex = 2;
            this.btn_signIn.Text = "登录";
            this.btn_signIn.UseVisualStyleBackColor = false;
            this.btn_signIn.Click += new System.EventHandler(this.Buttons_Click);
            this.btn_signIn.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.btn_signIn.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // tbx_password
            // 
            this.tbx_password.Font = new System.Drawing.Font("宋体", 12F);
            this.tbx_password.Location = new System.Drawing.Point(102, 178);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = 'ఠ';
            this.tbx_password.Size = new System.Drawing.Size(158, 26);
            this.tbx_password.TabIndex = 1;
            // 
            // tbx_username
            // 
            this.tbx_username.Font = new System.Drawing.Font("宋体", 12F);
            this.tbx_username.Location = new System.Drawing.Point(102, 111);
            this.tbx_username.Name = "tbx_username";
            this.tbx_username.Size = new System.Drawing.Size(158, 26);
            this.tbx_username.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(39, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(39, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名：";
            // 
            // btn_reset
            // 
            this.btn_reset.BackColor = System.Drawing.Color.White;
            this.btn_reset.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_reset.Location = new System.Drawing.Point(58, 285);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(80, 28);
            this.btn_reset.TabIndex = 4;
            this.btn_reset.Text = "重置密码";
            this.btn_reset.UseVisualStyleBackColor = false;
            this.btn_reset.Click += new System.EventHandler(this.Buttons_Click);
            this.btn_reset.MouseEnter += new System.EventHandler(this.Buttons_MouseEnter);
            this.btn_reset.MouseLeave += new System.EventHandler(this.Buttons_MouseLeave);
            // 
            // FormSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HeizitGIS.Properties.Resources.rabbit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(320, 356);
            this.Controls.Add(this.btn_reset);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_signUp);
            this.Controls.Add(this.btn_signIn);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.tbx_username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLoad";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_signUp;
        private System.Windows.Forms.Button btn_signIn;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.TextBox tbx_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_reset;

    }
}