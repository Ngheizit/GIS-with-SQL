using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.ADF.BaseClasses;

namespace HeizitGIS.AeCmd
{
    class SingleSymbology : BaseCommand
    {
        private IMapControl2 m_pMapC2;

        public SingleSymbology()
        {
            m_caption = "简单符号化";
        }

        public override void OnCreate(object hook)
        {
            m_pMapC2 = hook as IMapControl2;
        }

        public override void OnClick()
        {
            IFeatureLayer pFeatureLayer = (m_pMapC2 as IMapControl4).CustomProperty as IFeatureLayer;
            ISimpleRenderer pRenderer = new SimpleRendererClass() { 
                Symbol = AeUtils.GetSymbolBySymbolSelector(pFeatureLayer.FeatureClass.ShapeType)
            };
            (pFeatureLayer as IGeoFeatureLayer).Renderer = pRenderer as IFeatureRenderer;
            m_pMapC2.Refresh();
            AeUtils.UpdateTOCControl();
        }
    }
}
