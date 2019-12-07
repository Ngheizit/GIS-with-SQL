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
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;

namespace StudentManagementSystem.Forms
{
    public partial class FormHawkEye : DevExpress.XtraEditors.XtraForm
    {
        private IMapControl2 m_pMapC2_Main;
        private IMapControl2 m_pMapC2_HawkEye;

        public FormHawkEye(IHookHelper hookHelper)
        {
            InitializeComponent();
            this.m_pMapC2_Main = hookHelper.Hook as IMapControl2;
            this.m_pMapC2_HawkEye = axMapControl_HawkEye.Object as IMapControl2;
        }

        #region → 自定义事件
        private void CopyMainLayersToHawkEye()
        {
            for (int i = m_pMapC2_Main.LayerCount - 1; i >= 0; i--)
            {
                m_pMapC2_HawkEye.AddLayer(m_pMapC2_Main.get_Layer(i));
            }
        }
        public void DrawExtent()
        {
            AeUtils.DrawRectangle(m_pMapC2_HawkEye, m_pMapC2_Main.Extent);
        }
        #endregion

        private void FormHawkEye_Load(object sender, EventArgs e)
        {
            axMapControl_HawkEye.AutoKeyboardScrolling = false;
            axMapControl_HawkEye.AutoMouseWheel = false;
            this.TopMost = true;

            CopyMainLayersToHawkEye();
            AeUtils.DrawRectangle(m_pMapC2_HawkEye, m_pMapC2_Main.Extent);
        }

        private void axMapControl_HawkEye_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2_Main.CenterAt(new PointClass() { 
                    X = e.mapX, Y = e.mapY
                });
            }
        }

        private void axMapControl_HawkEye_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            if (e.button == 1)
            {
                m_pMapC2_Main.CenterAt(new PointClass() {
                    X = e.mapX,
                    Y = e.mapY
                });
            }
            else if (e.button == 2)
            {
                IEnvelope pEnvelope = m_pMapC2_HawkEye.TrackRectangle();
                m_pMapC2_Main.Extent = pEnvelope;
            }
        }



    }
}