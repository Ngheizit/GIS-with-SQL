using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace XizheGIS.MyUtils
{
    class AE
    {
        private static IMapControl2 m_pMapC2;
        private static IMapDocument m_pMapDoc;
        private static AxPageLayoutControl m_axPageLayoutCtl;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        public static void SetMapDocument(IMapDocument mapDocument)
        {
            m_pMapDoc = mapDocument;
        }
        public static void SetPageLayout(AxPageLayoutControl axPageLayoutControl)
        {
            m_axPageLayoutCtl = axPageLayoutControl;
        }

        public static class MxdManagement
        {
            public static bool Load(string mxdPath)
            {
                if (m_pMapC2.CheckMxFile(mxdPath))
                {
                    m_pMapDoc.Open(mxdPath);
                    m_pMapC2.Map = m_pMapDoc.ActiveView.FocusMap;
                    return true;
                }
                else
                    return false;
            }
            public static bool Save()
            {
                string mxdPath = "";
                try {
                    mxdPath = m_pMapDoc.DocumentFilename;
                }
                catch {
                    MessageBox.Show("未加载地图文档，无法进行保存");
                    return false;
                }
                if (m_pMapDoc.get_IsReadOnly(mxdPath)) {
                    MessageBox.Show("当前地图文档未仅读文档，无法进行保存");
                    return false;
                }
                else {
                    m_pMapDoc.Save();
                    return true;
                }
            }
            public static bool SaveAs(string newPath)
            {
                try {
                    m_pMapDoc.SaveAs(newPath, true, true);
                }
                catch {
                    MessageBox.Show("未加载地图文档，无法进行另存为");
                    return false;
                }
                Load(newPath);
                return true;
            }
        }

        public static void CopyMapToLayoutView()
        {
            IActiveView pActiveView = m_axPageLayoutCtl.ActiveView.FocusMap as IActiveView;
            pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds = m_pMapC2.Extent;
            pActiveView.Refresh();
            IObjectCopy pObjectCopy = new ObjectCopyClass();
            object copyMap = pObjectCopy.Copy(m_pMapC2.Map);
            object overwriteMap = pActiveView;
            pObjectCopy.Overwrite(copyMap, overwriteMap);
        }

        public static void Pan()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }
        public static void PagePan()
        {
            m_axPageLayoutCtl.MousePointer = esriControlsMousePointer.esriPointerPagePanning;
            m_axPageLayoutCtl.Pan();
            m_axPageLayoutCtl.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }


    }
}
