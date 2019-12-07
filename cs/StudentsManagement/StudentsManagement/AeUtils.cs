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
using ESRI.ArcGIS.Output;

namespace StudentsManagement
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        private static IMapDocument m_pMapDoc;
        private static void SetMapControl(IMapControl2 mapControl)
        {
            
        }
        private static void SetMapDocument(IMapDocument mapDocument) {
            m_pMapDoc = mapDocument;
        }
    }
}
