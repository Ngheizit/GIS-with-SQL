using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace HeizitGIS.AeForm
{
    public partial class FormLabel : Form
    {
        private IFeatureLayer m_pFeatureLayer;

        public FormLabel(IFeatureLayer featureLayer)
        {
            InitializeComponent();
            this.m_pFeatureLayer = featureLayer;
        }

        private void FormLabel_Load(object sender, EventArgs e)
        {
            IFields pFields = m_pFeatureLayer.FeatureClass.Fields;
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                string fieldname = pFields.get_Field(i).Name;
                comboBox_field.Items.Add(fieldname);
            }
        }

        private void ShowLabel()
        {
            int index = comboBox_field.SelectedIndex;
            if (!checkBox_OpenClose.Checked)
                index = -1;
            AeUtils.ShowLabel(m_pFeatureLayer, index);
        }

        // 应用
        private void btn_apply_Click(object sender, EventArgs e)
        {
            ShowLabel();
        }

        // 确认
        private void btn_ok_Click(object sender, EventArgs e)
        {
            ShowLabel();
            this.Close();
        }

        // 关闭
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
