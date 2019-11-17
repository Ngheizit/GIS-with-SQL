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
    class Label : BaseCommand
    {
        private IMapControl2 m_pMapC2;

        public Label()
        {
            m_caption = "注记";
        }

        public override void OnCreate(object hook)
        {
            m_pMapC2 = hook as IMapControl2;
        }

        public override void OnClick()
        {
            new AeForm.FormLabel((m_pMapC2 as IMapControl4).CustomProperty as IFeatureLayer).Show();
        }

    }
}
