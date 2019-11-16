using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace HeizitGIS.AeCmd
{
    class ZoomToLayer : BaseCommand
    {
        private IMapControl2 m_pMapC2;

        public ZoomToLayer()
        {
            m_caption = "缩放至图层";
        }

        public override void OnCreate(object hook)
        {
            m_pMapC2 = hook as IMapControl2;
        }

        public override void OnClick()
        {
            m_pMapC2.Extent = ((m_pMapC2 as IMapControl4).CustomProperty as ILayer).AreaOfInterest;
        }
    }
}
