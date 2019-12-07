namespace StudentManagementSystem.Forms
{
    partial class FormNearly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNearly));
            this.cbx_TargetStudent = new System.Windows.Forms.ComboBox();
            this.tbx_NearlyStudent = new System.Windows.Forms.TextBox();
            this.btn_Run = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_NearlyDistance = new System.Windows.Forms.TextBox();
            this.btn_Close = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // cbx_TargetStudent
            // 
            this.cbx_TargetStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TargetStudent.FormattingEnabled = true;
            this.cbx_TargetStudent.Location = new System.Drawing.Point(78, 11);
            this.cbx_TargetStudent.Name = "cbx_TargetStudent";
            this.cbx_TargetStudent.Size = new System.Drawing.Size(114, 22);
            this.cbx_TargetStudent.TabIndex = 0;
            // 
            // tbx_NearlyStudent
            // 
            this.tbx_NearlyStudent.Location = new System.Drawing.Point(126, 39);
            this.tbx_NearlyStudent.Name = "tbx_NearlyStudent";
            this.tbx_NearlyStudent.ReadOnly = true;
            this.tbx_NearlyStudent.Size = new System.Drawing.Size(66, 22);
            this.tbx_NearlyStudent.TabIndex = 1;
            // 
            // btn_Run
            // 
            this.btn_Run.Image = ((System.Drawing.Image)(resources.GetObject("btn_Run.Image")));
            this.btn_Run.Location = new System.Drawing.Point(22, 95);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(59, 23);
            this.btn_Run.TabIndex = 2;
            this.btn_Run.Text = "计算";
            this.btn_Run.Click += new System.EventHandler(this.btn_Run_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "目标学生：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 42);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(108, 14);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "与其最近邻的学生：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 70);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "相距：";
            // 
            // tbx_NearlyDistance
            // 
            this.tbx_NearlyDistance.Location = new System.Drawing.Point(54, 67);
            this.tbx_NearlyDistance.Name = "tbx_NearlyDistance";
            this.tbx_NearlyDistance.ReadOnly = true;
            this.tbx_NearlyDistance.Size = new System.Drawing.Size(138, 22);
            this.tbx_NearlyDistance.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Image = global::StudentManagementSystem.Properties.Resources.close_16x16;
            this.btn_Close.Location = new System.Drawing.Point(114, 95);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(60, 23);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "关闭";
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // FormNearly
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 127);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.tbx_NearlyDistance);
            this.Controls.Add(this.tbx_NearlyStudent);
            this.Controls.Add(this.cbx_TargetStudent);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormNearly";
            this.Text = "最邻近学生分析";
            this.Load += new System.EventHandler(this.FormNearly_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_TargetStudent;
        private System.Windows.Forms.TextBox tbx_NearlyStudent;
        private DevExpress.XtraEditors.SimpleButton btn_Run;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox tbx_NearlyDistance;
        private DevExpress.XtraEditors.SimpleButton btn_Close;
    }
}