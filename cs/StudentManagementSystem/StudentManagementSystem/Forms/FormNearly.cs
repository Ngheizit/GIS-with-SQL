using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;

namespace StudentManagementSystem.Forms
{
    public partial class FormNearly : DevExpress.XtraEditors.XtraForm
    {
        private IFeatureLayer m_pFeatureLayer;
        private List<IPoint> m_pPointList;

        public FormNearly()
        {
            InitializeComponent();
            this.m_pFeatureLayer = AeUtils.GetFeatureLayerByName("Students");
            this.m_pPointList = new List<IPoint>();
            this.TopMost = true;
        }

        private void FormNearly_Load(object sender, EventArgs e)
        {
            IFeatureCursor pFeatureCursor = m_pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                IPoint pPoint = pFeature.Shape as IPoint;
                pPoint.ID = (int)pFeature.get_Value(0);
                pPoint.Project(AeUtils.GetMapSpatialReference());
                m_pPointList.Add(pPoint);
                cbx_TargetStudent.Items.Add(pFeature.get_Value(pFeature.Fields.FindField("SNAME")).ToString());
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        private void btn_Run_Click(object sender, EventArgs e)
        {
            int targetStudentIndex = cbx_TargetStudent.SelectedIndex;
            if (targetStudentIndex == -1)
            {
                MessageBox.Show("未选择目标同学", "无法计算最邻近同学", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            IPoint pPoint = MeasureUtils.GetNearestStudent(m_pPointList, targetStudentIndex);
            if (pPoint != null)
            {
                IFeature pFeature = m_pFeatureLayer.FeatureClass.GetFeature(pPoint.ID);
                tbx_NearlyStudent.Text = pFeature.get_Value(pFeature.Fields.FindField("SNAME")).ToString();

                IPoint pTargetPoint = m_pPointList[targetStudentIndex];
                double distance = MeasureUtils.GetDistance(pPoint, pTargetPoint);
                tbx_NearlyDistance.Text = Math.Round(distance / 1000, 3) + " km";
                ShowResultInMap(pTargetPoint, pPoint);
            }
        }

        private void ShowResultInMap(IPoint targetPoint, IPoint pPoint)
        {
            AeUtils.DrawLine(targetPoint, pPoint);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}