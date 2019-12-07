namespace StudentManagementSystem.Forms
{
    partial class FormHawkEye
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHawkEye));
            this.axMapControl_HawkEye = new ESRI.ArcGIS.Controls.AxMapControl();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_HawkEye)).BeginInit();
            this.SuspendLayout();
            // 
            // axMapControl_HawkEye
            // 
            this.axMapControl_HawkEye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl_HawkEye.Location = new System.Drawing.Point(0, 0);
            this.axMapControl_HawkEye.Name = "axMapControl_HawkEye";
            this.axMapControl_HawkEye.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl_HawkEye.OcxState")));
            this.axMapControl_HawkEye.Size = new System.Drawing.Size(382, 190);
            this.axMapControl_HawkEye.TabIndex = 0;
            this.axMapControl_HawkEye.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl_HawkEye_OnMouseDown);
            this.axMapControl_HawkEye.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl_HawkEye_OnMouseMove);
            // 
            // FormHawkEye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 190);
            this.Controls.Add(this.axMapControl_HawkEye);
            this.Name = "FormHawkEye";
            this.Text = "鹰眼视图";
            this.Load += new System.EventHandler(this.FormHawkEye_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl_HawkEye)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxMapControl axMapControl_HawkEye;
    }
}