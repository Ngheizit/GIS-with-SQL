using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace StudentsManagement.WxzUtils
{
    class Ae
    {
        private static IMapControl2 m_pMapC2;
        private static IMapDocument m_pMapDoc;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        public static void SetMapC2MouseStyle(esriControlsMousePointer mouse)
        {
            m_pMapC2.MousePointer = mouse;
        }
        public static void SetMapDocument(IMapDocument mapDocument)
        {
            m_pMapDoc = mapDocument;
        }
        public static bool LoadMxd(string mxdPath)
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
        public static bool SaveMxd()
        {
            if (!m_pMapDoc.get_IsReadOnly(m_pMapDoc.DocumentFilename))
            {
                m_pMapDoc.Save();
                return true;
            }
            else
                return false;
        }
        public static bool IsAddingStudent = false;

        public static void Pan()
        {
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
        }
        public static void Zoom(double increment)
        {
            m_pMapC2.MapScale *= increment;
            m_pMapC2.Refresh();
        }

        public static void AddStudent(IPoint point, object Id, object SID, object SNAME, object SSEX, object SBIRTH, object SHOME)
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");

            IFeatureClassWrite pWrite = pFeatureLayer.FeatureClass as IFeatureClassWrite;
            IWorkspaceEdit pEdit = (pFeatureLayer.FeatureClass as IDataset).Workspace as IWorkspaceEdit;
            pEdit.StartEditing(true);
            pEdit.StartEditOperation();
            IFeature pFeature = pFeatureLayer.FeatureClass.CreateFeature();
            pFeature.Shape = point;
            pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("Id"), Id);
            pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("SID"), SID);
            pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("SNAME"), SNAME);
            pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("SSEX"), SSEX);
            pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("SBIRTH"), SBIRTH);
            pFeature.set_Value(pFeatureLayer.FeatureClass.Fields.FindField("SHOME"), SHOME);
            pFeature.Store();
            pWrite.WriteFeature(pFeature);
            pEdit.StopEditOperation();
            pEdit.StopEditing(true);

            DeleteAllElements();
        }

        public static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a,
                UseWindowsDithering = true
            };
        }
        public static void DrawPoint(IPoint point)
        {
            IElement pElement = new MarkerElementClass() {
                Geometry = point,
                Symbol = new SimpleMarkerSymbolClass() { 
                    Color = CreateRgbColor(255, 0, 0),
                    Size = 12
                }
            };
            DrawElement(pElement, true);
        }
        private static void DrawElement(IElement element, bool isDeleteBefore = false)
        {
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            if (isDeleteBefore)
                pGC.DeleteAllElements();
            pGC.AddElement(element, 0);
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        public static void DeleteAllElements()
        {
            (m_pMapC2.Map as IGraphicsContainer).DeleteAllElements();
            m_pMapC2.Refresh();
        }

        public static IFeatureLayer GetFeatureLayerByName(string name)
        {
            IMap pMap = m_pMapC2.Map;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                if (pMap.get_Layer(i).Name == name)
                    return pMap.get_Layer(i) as IFeatureLayer;
            }
            return null;
        }

        public static IGeometry GetGeometryByFeatureLayer(IFeatureLayer featureLayer)
        {
            IGeometry pGeometry = null;
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                if (pGeometry == null)
                    pGeometry = pFeature.Shape;
                else
                {
                    ITopologicalOperator pTO = pGeometry as ITopologicalOperator;
                    pGeometry = pTO.Union(pFeature.Shape);
                }
                pFeature = pFeatureCursor.NextFeature();
            }
            return pGeometry;
        }

        public static IPoint PRJtoGCS(IPoint point)
        {
            ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            point.Project(spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCS3Type.esriSRGeoCS_Xian1980));
            return point;
        }

    }
}
