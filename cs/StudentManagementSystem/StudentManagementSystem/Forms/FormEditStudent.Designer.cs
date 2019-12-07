namespace StudentManagementSystem.Forms
{
    partial class FormEditStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditStudent));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_Location = new System.Windows.Forms.TextBox();
            this.btn_GetLocation = new DevExpress.XtraEditors.SimpleButton();
            this.label_SId = new DevExpress.XtraEditors.LabelControl();
            this.tbx_SId = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_SName = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbx_SSex = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.dtime_SBirth = new System.Windows.Forms.DateTimePicker();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_Home = new System.Windows.Forms.TextBox();
            this.btn_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "位置：";
            // 
            // tbx_Location
            // 
            this.tbx_Location.Location = new System.Drawing.Point(24, 32);
            this.tbx_Location.Name = "tbx_Location";
            this.tbx_Location.ReadOnly = true;
            this.tbx_Location.Size = new System.Drawing.Size(146, 22);
            this.tbx_Location.TabIndex = 1;
            // 
            // btn_GetLocation
            // 
            this.btn_GetLocation.Image = ((System.Drawing.Image)(resources.GetObject("btn_GetLocation.Image")));
            this.btn_GetLocation.Location = new System.Drawing.Point(176, 32);
            this.btn_GetLocation.Name = "btn_GetLocation";
            this.btn_GetLocation.Size = new System.Drawing.Size(61, 22);
            this.btn_GetLocation.TabIndex = 2;
            this.btn_GetLocation.Text = "获取";
            this.btn_GetLocation.Click += new System.EventHandler(this.btn_GetLocation_Click);
            // 
            // label_SId
            // 
            this.label_SId.Location = new System.Drawing.Point(24, 60);
            this.label_SId.Name = "label_SId";
            this.label_SId.Size = new System.Drawing.Size(36, 14);
            this.label_SId.TabIndex = 0;
            this.label_SId.Text = "学号：";
            // 
            // tbx_SId
            // 
            this.tbx_SId.Location = new System.Drawing.Point(24, 80);
            this.tbx_SId.Name = "tbx_SId";
            this.tbx_SId.Size = new System.Drawing.Size(213, 22);
            this.tbx_SId.TabIndex = 1;
            this.tbx_SId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_SId_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(24, 108);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "姓名：";
            // 
            // tbx_SName
            // 
            this.tbx_SName.Location = new System.Drawing.Point(24, 128);
            this.tbx_SName.Name = "tbx_SName";
            this.tbx_SName.Size = new System.Drawing.Size(96, 22);
            this.tbx_SName.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(141, 108);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 14);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "性别：";
            // 
            // cbx_SSex
            // 
            this.cbx_SSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_SSex.FormattingEnabled = true;
            this.cbx_SSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbx_SSex.Location = new System.Drawing.Point(141, 128);
            this.cbx_SSex.Name = "cbx_SSex";
            this.cbx_SSex.Size = new System.Drawing.Size(96, 22);
            this.cbx_SSex.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(24, 156);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 14);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "出生年月日：";
            // 
            // dtime_SBirth
            // 
            this.dtime_SBirth.Location = new System.Drawing.Point(24, 176);
            this.dtime_SBirth.Name = "dtime_SBirth";
            this.dtime_SBirth.Size = new System.Drawing.Size(213, 22);
            this.dtime_SBirth.TabIndex = 4;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(24, 204);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(36, 14);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "家乡：";
            // 
            // tbx_Home
            // 
            this.tbx_Home.Location = new System.Drawing.Point(24, 224);
            this.tbx_Home.Name = "tbx_Home";
            this.tbx_Home.Size = new System.Drawing.Size(213, 22);
            this.tbx_Home.TabIndex = 1;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.Location = new System.Drawing.Point(24, 257);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(61, 23);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Clear
            // 
            this.btn_Clear.Image = ((System.Drawing.Image)(resources.GetObject("btn_Clear.Image")));
            this.btn_Clear.Location = new System.Drawing.Point(100, 257);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(61, 23);
            this.btn_Clear.TabIndex = 5;
            this.btn_Clear.Text = "清空";
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(176, 257);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(61, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FormEditStudent
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 293);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.dtime_SBirth);
            this.Controls.Add(this.cbx_SSex);
            this.Controls.Add(this.btn_GetLocation);
            this.Controls.Add(this.tbx_SName);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.tbx_Home);
            this.Controls.Add(this.tbx_SId);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.label_SId);
            this.Controls.Add(this.tbx_Location);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditStudent";
            this.Text = "学生信息编辑";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormEditStudent_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox tbx_Location;
        private DevExpress.XtraEditors.SimpleButton btn_GetLocation;
        private DevExpress.XtraEditors.LabelControl label_SId;
        private System.Windows.Forms.TextBox tbx_SId;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox tbx_SName;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cbx_SSex;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.DateTimePicker dtime_SBirth;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.TextBox tbx_Home;
        private DevExpress.XtraEditors.SimpleButton btn_Ok;
        private DevExpress.XtraEditors.SimpleButton btn_Clear;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
    }
}