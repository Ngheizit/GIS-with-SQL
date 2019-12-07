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
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geoprocessor;
using ESRI.ArcGIS.Geoprocessing;

namespace StudentManagementSystem
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        private static IMapDocument m_pMapDoc;
        public static event CloseWaitForm CloseWaitForm;

        private static class Func
        {
            public static bool LoadMxd(string mxd)
            {
                if (m_pMapC2.CheckMxFile(mxd))
                {
                    m_pMapDoc.Open(mxd);
                    m_pMapC2.Map = m_pMapDoc.ActiveView.FocusMap;
                    return true;
                }
                else
                    return false;
            }
            public static void Pan()
            {
                esriControlsMousePointer oldMousePointer = m_pMapC2.MousePointer;
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerPanning;
                m_pMapC2.Pan();
                m_pMapC2.MousePointer = oldMousePointer;
            }
            public static void PanTool()
            {
                ICommand pCommand = new ControlsMapPanToolClass();
                pCommand.OnCreate(m_pMapC2);
                m_pMapC2.CurrentTool = pCommand as ITool;
            }
            public static void ZoomInTool()
            {
                ICommand pCom = new ControlsMapZoomInToolClass();
                pCom.OnCreate(m_pMapC2);
                m_pMapC2.CurrentTool = pCom as ITool;
            }
            public static void ZoomOutTool()
            {
                ICommand pCom = new ControlsMapZoomOutToolClass();
                pCom.OnCreate(m_pMapC2);
                m_pMapC2.CurrentTool = pCom as ITool;
            }
            public static void ZoomInFiexd()
            {
                ICommand pCom = new ControlsMapZoomInFixedCommandClass();
                pCom.OnCreate(m_pMapC2);
                pCom.OnClick();
            }
            public static void ZoomOutFiexd()
            {
                ICommand pCom = new ControlsMapZoomOutFixedCommandClass();
                pCom.OnCreate(m_pMapC2);
                pCom.OnClick();
            }
            public static string GetLocationInfo(IPoint point, string unit)
            {
                return String.Format("{0} {1} {2}", point.X.ToString(".###"), point.Y.ToString(".###"), unit);
            }
            public static IPoint PRJtoGCS(IPoint point)
            {
                ISpatialReferenceFactory spatialReferenceFactory = new SpatialReferenceEnvironmentClass();
                point.Project(spatialReferenceFactory.CreateGeographicCoordinateSystem((int)esriSRGeoCS3Type.esriSRGeoCS_Xian1980));
                return point;
            }
            public static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
            {
                return new RgbColorClass() {
                    Red = r, Green = g, Blue = b, Transparency = a,
                    UseWindowsDithering = true
                };
            }
            public static ISimpleFillSymbol CreateSimpleFillSymbol(IRgbColor fillColor, IRgbColor outColor, int outWidth)
            {
                return new SimpleFillSymbolClass() {
                    Color = fillColor,
                    Outline = new SimpleLineSymbolClass() { 
                        Color = outColor,
                        Width = outWidth
                    }
                };
            }
            public static void DrawRectangle(IMapControl2 mapControl, IEnvelope envelope, IRgbColor fillColor, IRgbColor outColor, int outWidth)
            {
                IElement pElement = new RectangleElementClass() {
                    Symbol = CreateSimpleFillSymbol(fillColor, outColor, outWidth),
                    Geometry = envelope
                };
                IGraphicsContainer pGC = mapControl.Map as IGraphicsContainer;
                pGC.DeleteAllElements();
                pGC.AddElement(pElement, 0);
                mapControl.Refresh(esriViewDrawPhase.esriViewGraphics);
            }
            public static void DeleteAllMapElement()
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
            public static IGeometry GetShapeFromFieldValue(IFeatureLayer featureLayer, string fieldName, string fieldValue)
            {
                IQueryFilter pQueryFilter = new QueryFilterClass() { 
                    WhereClause = String.Format("\"{0}\" = {1}", fieldName, fieldValue)
                };
                IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(pQueryFilter, false);
                IFeature pFeature = pFeatureCursor.NextFeature();
                if (pFeature != null)
                    return pFeature.Shape;
                else
                    return null;
            }
            public static IFeature GetSelectFeature(IFeatureLayer featureLayer)
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
                return pSelectedFeat;
            }
        }


        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        public static void SetMapDocument(IMapDocument mapDocument)
        {
            m_pMapDoc = mapDocument;
        }
        public static void LoadMxd(string mxd)
        {
            if (Func.LoadMxd(mxd))
            { 
                
            }
        }
        public static void Pan()
        {
            Func.Pan();
        }
        public static void FullExtent()
        {
            m_pMapC2.Extent = m_pMapC2.FullExtent;
        }
        public static void PanTool()
        {
            Func.PanTool();
        }
        public static void DefaultTool()
        {
            m_pMapC2.CurrentTool = null;
        }
        public static void ZoomInTool()
        {
            Func.ZoomInTool();
        }
        public static void ZoomOutTool()
        {
            Func.ZoomOutTool();
        }
        public static void ZoomInFiexd()
        {
            Func.ZoomInFiexd();
        }
        public static void ZoomOutFiexd()
        {
            Func.ZoomOutFiexd();
        }
        public static string GetLocationInfo(IPoint point, string unit)
        {
            return Func.GetLocationInfo(point, unit);
        }
        public static string GetLocationInfo(IPoint point)
        {
            IPoint pPoint = Func.PRJtoGCS(point);
            return Func.GetLocationInfo(point, "Decimal Degree");
        }
        public static void SaveMxd()
        {
            m_pMapDoc.Save();
        }
        public static void DrawRectangle(IMapControl2 mapControl, IEnvelope envelope) // 主要用作于鹰眼视图范围示意矩形框
        {
            IRgbColor pFillColor =  Func.CreateRgbColor(0, 0, 0, 0),
                      pOutColor = Func.CreateRgbColor(255, 0, 0);
            Func.DrawRectangle(mapControl, envelope, pFillColor, pOutColor, 2);
        }
        public static void SetMousePointer(esriControlsMousePointer mousePointer)
        {
            m_pMapC2.MousePointer = mousePointer;
        }
        public static void DrawPoint(IPoint point) // 主要用于示意学生位置
        {
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            pGC.AddElement(new MarkerElementClass() {
                Geometry = point,
                SpatialReference = point.SpatialReference,
                Symbol = new SimpleMarkerSymbolClass() { 
                    Color = Func.CreateRgbColor(0, 0, 0),
                    Size = 8
                }
            }, 0);
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics);
        }
        public static void DeleteAllMapElement()
        {
            Func.DeleteAllMapElement();
        }
        public static string GetClickHome(IPoint pPoint) // 获取点击位置的省份
        {
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("BOUA_PJ");
            ISpatialFilter pSpatialFilter = new SpatialFilterClass() { 
                Geometry = pPoint,
                SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            };
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(pSpatialFilter as IQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature != null)
                return pFeature.get_Value(pFeature.Fields.FindField("NAME")).ToString();
            else
                return "海外";
        }
        public static void AddStudent(IPoint point, object Id, object SID, object SNAME, object SSEX, object SBIRTH, object SHOME)
        {
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("Students");
            IFeature pFeature = pFeatureLayer.FeatureClass.CreateFeature();
            pFeature.Shape = point;
            SetStudentInfo(pFeatureLayer, pFeature, Id, SID, SNAME, SSEX, SBIRTH, SHOME);
            DeleteAllMapElement();
        } // 添加学生要素
        private static void SetStudentInfo(IFeatureLayer featureLayer, IFeature feature, object id, object sid, object sname, object ssex, object sbrith, object shome)
        {
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("Id"), id);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SID"), sid);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SNAME"), sname);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SSEX"), ssex);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SBIRTH"), sbrith);
            feature.set_Value(featureLayer.FeatureClass.Fields.FindField("SHOME"), shome);
            feature.Store();
        }
        public static IPoint GetPointFromId(string id)
        {
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("Students");
            return Func.GetShapeFromFieldValue(pFeatureLayer, "Id", id) as IPoint;
        }
        public static void EditStudent(IPoint point, object Id, object SID, object SNAME, object SSEX, object SBIRTH, object SHOME)
        {
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("Students");
            IQueryFilter pQueryFilter = new QueryFilterClass()
            {
                WhereClause = String.Format("\"{0}\" = {1}", "Id", Id)
            };
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(pQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature != null)
            {
                pFeature.Shape = point;
                SetStudentInfo(pFeatureLayer, pFeature, Id, SID, SNAME, SSEX, SBIRTH, SHOME);
            }
            else
                return;
        }
        public static void DeleteStudent(object Id)
        { 
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("Students");
            IQueryFilter pQueryFilter = new QueryFilterClass()
            {
                WhereClause = String.Format("\"{0}\" = {1}", "Id", Id)
            };
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(pQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature != null)
            {
                pFeature.Delete();
                m_pMapC2.Refresh();
            }
            else
                return;
        }
        public static IFeature SelectStudentFeatureByPoint(IPoint point)
        {
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("Students");
            IEnvelope pEnv = point.Envelope;
            double scale = m_pMapC2.MapScale / 1000;
            pEnv.XMin -= scale;
            pEnv.YMin -= scale;
            pEnv.XMax += scale;
            pEnv.YMax += scale;

            ISpatialFilter pSpatialFilter = new SpatialFilterClass()
            {
                Geometry = pEnv,
                SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            };
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(pSpatialFilter as IQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            m_pMapC2.Map.ClearSelection();
            m_pMapC2.Map.SelectFeature(pFeatureLayer, pFeature);
            m_pMapC2.Refresh();
            return pFeature;
        }
        public static void ZoomToSelectStudent()
        {
            IFeatureLayer pFeatureLayer = Func.GetFeatureLayerByName("Students");
            try
            {
                IEnvelope pEnv = Func.GetSelectFeature(pFeatureLayer).Extent;
                pEnv.Expand(5, 5, false);
                m_pMapC2.Extent = pEnv;
                m_pMapC2.Refresh();
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("未选择学生信息");
            }
        }
        public static void ClearSelection()
        {
            m_pMapC2.Map.ClearSelection();
            m_pMapC2.Refresh();
        }
        public static IFeatureLayer GetFeatureLayerByName(string layerName)
        {
            return Func.GetFeatureLayerByName(layerName);
        }
        public static ISpatialReference GetMapSpatialReference()
        {
            return m_pMapC2.SpatialReference;
        }
        public static void DrawLine(IPoint fromPoint, IPoint toPoint)
        {
            IPolyline pPolyline = new PolylineClass() { 
                FromPoint = fromPoint,
                ToPoint = toPoint
            };
            IRgbColor pColor = Func.CreateRgbColor(0, 0, 0);
            ICartographicLineSymbol pCartoLineSymbol = new CartographicLineSymbolClass() { 
                Cap = esriLineCapStyle.esriLCSRound,
                Color = pColor,
                Width = 1
            };
            ILineProperties pLineProp = pCartoLineSymbol as ILineProperties;
            pLineProp.DecorationOnTop = true;
            ILineDecoration pLineDecoration = new LineDecorationClass();
            ISimpleLineDecorationElement pSimpleLineDecoElem = new SimpleLineDecorationElementClass() { 
                MarkerSymbol = new ArrowMarkerSymbolClass() { 
                   Size = 16,
                   Color = pColor
                }
            };
            pSimpleLineDecoElem.AddPosition(1);
            pLineDecoration.AddElement(pSimpleLineDecoElem as ILineDecorationElement);
            pLineProp.LineDecoration = pLineDecoration;
            ILineSymbol pLineSymbol = pCartoLineSymbol as ILineSymbol;
            IElement pElement = new LineElementClass() {
                Symbol = pLineSymbol,
                Geometry = pPolyline
            };
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            pGC.AddElement(pElement, 0);
            IEnvelope pEnvelope = pPolyline.Envelope;
            pEnvelope.Expand(5, 5, true);
            m_pMapC2.Extent = pEnvelope;
            m_pMapC2.Refresh();
        }
        public static void DrawCenterPoint(IPoint point) // 绘制平均中心
        {
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            pGC.AddElement(new MarkerElementClass() {
                Geometry = point,
                SpatialReference = point.SpatialReference,
                Symbol = new SimpleMarkerSymbolClass() {
                    Color = Func.CreateRgbColor(0, 0, 0),
                    Size = 120,
                    Style = esriSimpleMarkerStyle.esriSMSCross
                }
            }, 0);
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics);
        }
        public static List<IPoint> GetStudentList()
        {
            List<IPoint> pointList = new List<IPoint>();
            IFeatureLayer pFeatureLayer = AeUtils.GetFeatureLayerByName("Students");
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                IPoint pPoint = pFeature.Shape as IPoint;
                pPoint.Project(m_pMapC2.SpatialReference);
                pointList.Add(pPoint);
                pFeature = pFeatureCursor.NextFeature();
            }
            return pointList;
        }
        public static IPoint PRJtoGCS(IPoint point)
        {
            return Func.PRJtoGCS(point);
        }
        public static void GetTysonPolygon()
        {
            IFeatureLayer pStudentLayer = Func.GetFeatureLayerByName("Students");
            IFeatureLayer pChinaLayer = Func.GetFeatureLayerByName("BOUA_PJ");
            string strOutput = Application.StartupPath + @"\Data\TysonAll.shp";

            Geoprocessor gp = new Geoprocessor() { 
                OverwriteOutput = true
            };
            ESRI.ArcGIS.AnalysisTools.CreateThiessenPolygons pCreateThiessenPolygons = new ESRI.ArcGIS.AnalysisTools.CreateThiessenPolygons() { 
                in_features = pStudentLayer,
                out_feature_class = strOutput,
                fields_to_copy = "ONLY_FID"
            };
            IGeoProcessorResult pResult = gp.ExecuteAsync(pCreateThiessenPolygons);
            
            new Timer() {
                Enabled = true,
                Interval = 500
            }.Tick += (sender, e) => {
                if (pResult.Status == esriJobStatus.esriJobSucceeded)
                {
                    ESRI.ArcGIS.AnalysisTools.Clip pClip = new ESRI.ArcGIS.AnalysisTools.Clip()
                    {
                        in_features = strOutput,
                        clip_features = pChinaLayer,
                        out_feature_class = Application.StartupPath + @"\Data\tyson.shp"
                    };
                    pResult = gp.ExecuteAsync(pClip);
                    new Timer() {
                        Enabled = true,
                        Interval = 500
                    }.Tick += (sender2, e2) => {
                        if (pResult.Status == esriJobStatus.esriJobSucceeded)
                        {
                            m_pMapC2.AddShapeFile(Application.StartupPath + @"\Data", "tyson.shp");
                            SetTysonSymbol();
                            (sender2 as Timer).Enabled = false;
                            CloseWaitForm();
                        }
                    };
                    (sender as Timer).Enabled = false;
                }
            };
        }
        private static void SetTysonSymbol()
        {
            IFeatureLayer pTysonLayer = Func.GetFeatureLayerByName("tyson");
            IFeatureRenderer pRenderer = new SimpleRendererClass() { 
                Symbol = Func.CreateSimpleFillSymbol(
                    Func.CreateRgbColor(0, 0, 0, 0),
                    Func.CreateRgbColor(0, 0, 0),
                    2
                ) as ISymbol,
            };
            (pTysonLayer as IGeoFeatureLayer).Renderer = pRenderer;
        }
    }
}
