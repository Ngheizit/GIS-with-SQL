namespace StudentManagementSystem.Forms
{
    partial class FormRValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRValue));
            this.table_LocationInfo = new System.Windows.Forms.ListView();
            this.table_MinMaxAve = new System.Windows.Forms.ListView();
            this.table_Center = new System.Windows.Forms.ListView();
            this.table_Count = new System.Windows.Forms.ListView();
            this.table_Area = new System.Windows.Forms.ListView();
            this.table_DistanceInfo = new System.Windows.Forms.ListView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_MinDistanceAve = new System.Windows.Forms.TextBox();
            this.tbx_BeautifulMinDistanceAve = new System.Windows.Forms.TextBox();
            this.tbx_RValue = new System.Windows.Forms.TextBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tbx_Result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // table_LocationInfo
            // 
            this.table_LocationInfo.Location = new System.Drawing.Point(12, 12);
            this.table_LocationInfo.Name = "table_LocationInfo";
            this.table_LocationInfo.Size = new System.Drawing.Size(858, 71);
            this.table_LocationInfo.TabIndex = 0;
            this.table_LocationInfo.UseCompatibleStateImageBehavior = false;
            this.table_LocationInfo.View = System.Windows.Forms.View.Details;
            // 
            // table_MinMaxAve
            // 
            this.table_MinMaxAve.Location = new System.Drawing.Point(12, 89);
            this.table_MinMaxAve.Name = "table_MinMaxAve";
            this.table_MinMaxAve.Size = new System.Drawing.Size(410, 90);
            this.table_MinMaxAve.TabIndex = 0;
            this.table_MinMaxAve.UseCompatibleStateImageBehavior = false;
            this.table_MinMaxAve.View = System.Windows.Forms.View.Details;
            // 
            // table_Center
            // 
            this.table_Center.Location = new System.Drawing.Point(428, 89);
            this.table_Center.Name = "table_Center";
            this.table_Center.Size = new System.Drawing.Size(298, 90);
            this.table_Center.TabIndex = 0;
            this.table_Center.UseCompatibleStateImageBehavior = false;
            this.table_Center.View = System.Windows.Forms.View.Details;
            // 
            // table_Count
            // 
            this.table_Count.Location = new System.Drawing.Point(732, 89);
            this.table_Count.Name = "table_Count";
            this.table_Count.Size = new System.Drawing.Size(138, 47);
            this.table_Count.TabIndex = 0;
            this.table_Count.UseCompatibleStateImageBehavior = false;
            this.table_Count.View = System.Windows.Forms.View.Details;
            // 
            // table_Area
            // 
            this.table_Area.Location = new System.Drawing.Point(732, 142);
            this.table_Area.Name = "table_Area";
            this.table_Area.Size = new System.Drawing.Size(138, 47);
            this.table_Area.TabIndex = 0;
            this.table_Area.UseCompatibleStateImageBehavior = false;
            this.table_Area.View = System.Windows.Forms.View.Details;
            // 
            // table_DistanceInfo
            // 
            this.table_DistanceInfo.Location = new System.Drawing.Point(12, 195);
            this.table_DistanceInfo.Name = "table_DistanceInfo";
            this.table_DistanceInfo.Size = new System.Drawing.Size(858, 229);
            this.table_DistanceInfo.TabIndex = 0;
            this.table_DistanceInfo.UseCompatibleStateImageBehavior = false;
            this.table_DistanceInfo.View = System.Windows.Forms.View.Details;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 442);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "最邻近平均距离：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 474);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(276, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "理想的随机性（普阿松分布型）的最近邻平均距离：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 510);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 14);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "最近邻指数R：";
            // 
            // tbx_MinDistanceAve
            // 
            this.tbx_MinDistanceAve.Location = new System.Drawing.Point(114, 439);
            this.tbx_MinDistanceAve.Name = "tbx_MinDistanceAve";
            this.tbx_MinDistanceAve.ReadOnly = true;
            this.tbx_MinDistanceAve.Size = new System.Drawing.Size(756, 22);
            this.tbx_MinDistanceAve.TabIndex = 2;
            // 
            // tbx_BeautifulMinDistanceAve
            // 
            this.tbx_BeautifulMinDistanceAve.Location = new System.Drawing.Point(293, 471);
            this.tbx_BeautifulMinDistanceAve.Name = "tbx_BeautifulMinDistanceAve";
            this.tbx_BeautifulMinDistanceAve.ReadOnly = true;
            this.tbx_BeautifulMinDistanceAve.Size = new System.Drawing.Size(577, 22);
            this.tbx_BeautifulMinDistanceAve.TabIndex = 2;
            // 
            // tbx_RValue
            // 
            this.tbx_RValue.Location = new System.Drawing.Point(96, 507);
            this.tbx_RValue.Name = "tbx_RValue";
            this.tbx_RValue.ReadOnly = true;
            this.tbx_RValue.Size = new System.Drawing.Size(521, 22);
            this.tbx_RValue.TabIndex = 2;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(623, 510);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 14);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "分布型：";
            // 
            // tbx_Result
            // 
            this.tbx_Result.Location = new System.Drawing.Point(677, 507);
            this.tbx_Result.Name = "tbx_Result";
            this.tbx_Result.ReadOnly = true;
            this.tbx_Result.Size = new System.Drawing.Size(193, 22);
            this.tbx_Result.TabIndex = 2;
            // 
            // FormRValue
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 538);
            this.Controls.Add(this.tbx_Result);
            this.Controls.Add(this.tbx_RValue);
            this.Controls.Add(this.tbx_BeautifulMinDistanceAve);
            this.Controls.Add(this.tbx_MinDistanceAve);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.table_Area);
            this.Controls.Add(this.table_Count);
            this.Controls.Add(this.table_Center);
            this.Controls.Add(this.table_DistanceInfo);
            this.Controls.Add(this.table_MinMaxAve);
            this.Controls.Add(this.table_LocationInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRValue";
            this.Text = "分布型分析结果";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView table_LocationInfo;
        private System.Windows.Forms.ListView table_MinMaxAve;
        private System.Windows.Forms.ListView table_Center;
        private System.Windows.Forms.ListView table_Count;
        private System.Windows.Forms.ListView table_Area;
        private System.Windows.Forms.ListView table_DistanceInfo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox tbx_MinDistanceAve;
        private System.Windows.Forms.TextBox tbx_BeautifulMinDistanceAve;
        private System.Windows.Forms.TextBox tbx_RValue;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.TextBox tbx_Result;
    }
}