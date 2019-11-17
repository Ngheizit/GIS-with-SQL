namespace HeizitGIS.AeForm
{
    partial class FormLabel
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
            this.checkBox_OpenClose = new System.Windows.Forms.CheckBox();
            this.comboBox_field = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_apply = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_OpenClose
            // 
            this.checkBox_OpenClose.AutoSize = true;
            this.checkBox_OpenClose.Location = new System.Drawing.Point(22, 12);
            this.checkBox_OpenClose.Name = "checkBox_OpenClose";
            this.checkBox_OpenClose.Size = new System.Drawing.Size(72, 16);
            this.checkBox_OpenClose.TabIndex = 0;
            this.checkBox_OpenClose.Text = "注记显示";
            this.checkBox_OpenClose.UseVisualStyleBackColor = true;
            // 
            // comboBox_field
            // 
            this.comboBox_field.FormattingEnabled = true;
            this.comboBox_field.Location = new System.Drawing.Point(93, 37);
            this.comboBox_field.Name = "comboBox_field";
            this.comboBox_field.Size = new System.Drawing.Size(166, 20);
            this.comboBox_field.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "字段选择：";
            // 
            // btn_apply
            // 
            this.btn_apply.Location = new System.Drawing.Point(22, 63);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 27);
            this.btn_apply.TabIndex = 3;
            this.btn_apply.Text = "应用";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(103, 63);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 27);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确认";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(184, 63);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "关闭";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FormLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 99);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_field);
            this.Controls.Add(this.checkBox_OpenClose);
            this.Name = "FormLabel";
            this.Text = "FormLabel";
            this.Load += new System.EventHandler(this.FormLabel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_OpenClose;
        private System.Windows.Forms.ComboBox comboBox_field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}