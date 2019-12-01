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
            esriControlsMousePointer mousePointer = m_pMapC2.MousePointer;
            m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
            m_pMapC2.Pan();
            m_pMapC2.MousePointer = mousePointer;
        }
        public static void Zoom(double increment)
        {
            m_pMapC2.MapScale *= increment;
            m_pMapC2.Refresh();
        }

        public static void AddStudent(IPoint point, object Id, object SID, object SNAME, object SSEX, object SBIRTH, object SHOME)
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");

            IFeature pFeature = pFeatureLayer.FeatureClass.CreateFeature();
            pFeature.Shape = point;
            SetStudentInfo(pFeatureLayer, pFeature, Id, SID, SNAME, SSEX, SBIRTH, SHOME);

            DeleteAllElements();
        }
        private static void SetStudentInfo(IFeatureLayer featureLayer, IFeature feature, object Id, object SID, object SNAME, object SSEX, object SBIRTH, object SHOME)
        {
            IFeatureClassWrite pWrite = featureLayer.FeatureClass as IFeatureClassWrite;
            IWorkspaceEdit pEdit = (featureLayer.FeatureClass as IDataset).Workspace as IWorkspaceEdit;
            pEdit.StartEditing(true);
            pEdit.StartEditOperation();
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("Id"), Id);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SID"), SID);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SNAME"), SNAME);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SSEX"), SSEX);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SBIRTH"), SBIRTH);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SHOME"), SHOME);
            feature.Store();
            pWrite.WriteFeature(feature);
            pEdit.StopEditOperation();
            pEdit.StopEditing(true);
        }
        public static void ModifyStudent(IPoint point, object Id, object SID, object SNAME, object SSEX, object SBIRTH, object SHOME)
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");

            
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                if (pFeature.get_Value(pFeature.Fields.FindField("Id")).ToString() == Id.ToString())
                {
                    pFeature.Shape = point;
                    SetStudentInfo(pFeatureLayer, pFeature, Id, SID, SNAME, SSEX, SBIRTH, SHOME);
                    DeleteAllElements();
                    return;
                }
                pFeature = pFeatureCursor.NextFeature();
            }
        }
        public static void DeleteStudent(object Id)
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");
            IFeatureCursor pFeatureCursor = pFeatureLayer.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                if (pFeature.get_Value(pFeature.Fields.FindField("Id")).ToString() == Id.ToString())
                {
                    pFeature.Delete();
                    return;
                }
                pFeature = pFeatureCursor.NextFeature();
            }
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
            m_pMapC2.Refresh();
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

        private static void SelectByField(IFeatureLayer featureLayer, string fieldname, string value)
        {
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                if (pFeature.get_Value(pFeature.Fields.FindField(fieldname)).ToString() == value)
                    m_pMapC2.Map.SelectFeature(featureLayer, pFeature);
                pFeature = pFeatureCursor.NextFeature();
            }
            m_pMapC2.Refresh();
        }
        private static void SelectByPoint(IFeatureLayer featureLayer, IPoint point, bool justOne = true)
        {
            IEnvelope pEnv = point.Envelope;
            double scale = m_pMapC2.MapScale / 1000;
            pEnv.XMin -= scale;
            pEnv.YMin -= scale;
            pEnv.XMax += scale;
            pEnv.YMax += scale;
            
            ISpatialFilter pSpatialFilter = new SpatialFilterClass() { 
                Geometry = pEnv,
                SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            };
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(pSpatialFilter as IQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            
            if (justOne && pFeature != null)
            {
                m_pMapC2.Map.SelectFeature(featureLayer, pFeature);
            }
            else 
            {
                while (pFeature != null)
                {
                    m_pMapC2.Map.SelectFeature(featureLayer, pFeature);
                    pFeature = pFeatureCursor.NextFeature();
                }
            }
            m_pMapC2.Refresh();
        }
        public static void SelectStudentById(string id)
        {
            m_pMapC2.Map.ClearSelection();
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");
            SelectByField(pFeatureLayer, "Id", id);
        }
        public static void SelectStudentByPoint(IPoint point)
        {
            m_pMapC2.Map.ClearSelection();
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");
            SelectByPoint(pFeatureLayer, point);
        }
        public static string GetSelectStudentId()
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");
            IFeature pFeature = GetSelectFeature(pFeatureLayer);
            if (pFeature != null)
            {
                return pFeature.get_Value(pFeature.Fields.FindField("Id")).ToString();
            }
            return "";
        }
        private static IFeature GetSelectFeature(IFeatureLayer featureLayer)
        {
            IEnumFeature pEnumFeature = m_pMapC2.Map.FeatureSelection as IEnumFeature;
            IFeature pSelectedFeat = pEnumFeature.Next();
            if (pSelectedFeat == null)
                return null;
            string fid = pSelectedFeat.get_Value(0).ToString();
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                if (pFeature.get_Value(0).ToString() == fid)
                    break;
                pFeature = pFeatureCursor.NextFeature();
            }
            return pFeature;
        }
        public static void ZoomToSelectedStudent()
        {
            IFeatureLayer pFeatureLayer = GetFeatureLayerByName("Students");
            IEnvelope pEnv = GetSelectFeature(pFeatureLayer).Extent;
            pEnv.Expand(5, 5, false);
            m_pMapC2.Extent = pEnv;
            m_pMapC2.Refresh();
        }
    }
}
