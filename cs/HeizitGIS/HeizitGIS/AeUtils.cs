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

namespace HeizitGIS
{
    class AeUtils
    {
        private static IMapControl2 m_pMapC2;
        public static void SetMapControl(IMapControl2 mapControl)
        {
            m_pMapC2 = mapControl;
        }
        private static AxTOCControl m_tocControl;
        public static void SetTOCControl(AxTOCControl tocControl)
        {
            m_tocControl = tocControl;
        }
        public static void UpdateTOCControl()
        {
            m_tocControl.Update();
        }


        /// <summary>
        /// 创建颜色对象（IRgbColor）
        /// </summary>
        /// <param name="r">红色度 [0, 255]</param>
        /// <param name="g">绿色度 [0, 255]</param>
        /// <param name="b">蓝色度 [0, 255]</param>
        /// <param name="a">透明度 [0, 255] 默认值为255</param>
        /// <returns>返回 IRgbColor 对象</returns>
        public static IRgbColor CreateRgbColor(byte r, byte g, byte b, byte a = 255)
        {
            return new RgbColorClass() { 
                Red = r, Green = g, Blue = b, Transparency = a,
                UseWindowsDithering = true
            };
        }
        /// <summary>
        /// 创建颜色对象（透明）
        /// </summary>
        /// <returns>返回 IRgbColor 对象</returns>
        public static IRgbColor CreateRgbColor()
        {
            return new RgbColorClass() {
                Transparency = 0,
                UseWindowsDithering = true
            };
        }

        /// <summary>
        /// 创建简单填充符号对象
        /// </summary>
        /// <param name="fillColor">填充颜色</param>
        /// <param name="borderColor">边框颜色</param>
        /// <param name="borderWidth">边框大小</param>
        /// <returns>返回 ISimpleFillSymbol 对象</returns>
        public static ISimpleFillSymbol CreateSimpleFillSymbol(IRgbColor fillColor, IRgbColor borderColor, int borderWidth)
        {
            return new SimpleFillSymbolClass() {
                Color = fillColor,
                Outline = new SimpleLineSymbolClass() { 
                    Color = borderColor,
                    Width = borderWidth
                }
            };
        }

        /// <summary>
        /// 创建字体对象
        /// </summary>
        /// <param name="size">字体大小 默认为16</param>
        /// <param name="bold">是否为加粗字体 默认为不加粗</param>
        /// <returns>返回 IFontDisp 对象</returns>
        public static stdole.IFontDisp CreateFontDisp(int size = 16, bool bold = false)
        {
            stdole.IFontDisp fontDisp = new stdole.StdFontClass() as stdole.IFontDisp;
            fontDisp.Bold = bold;
            fontDisp.Name = "Arial";
            fontDisp.Italic = false;
            fontDisp.Underline = false;
            fontDisp.Size = size;
            return fontDisp;
        }

        /// <summary>
        /// 显示注记
        /// </summary>
        /// <param name="featureLayer">需要显示注记的图层</param>
        /// <param name="fieldIndex">注记字段索引</param>
        public static void ShowLabel(IFeatureLayer featureLayer, int fieldIndex)
        {
            IGraphicsContainer pGC = m_pMapC2.Map as IGraphicsContainer;
            pGC.DeleteAllElements();
            if (fieldIndex == -1)
            {
                m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics, null, null); 
                return;
            }

            // 逐一对每一要素添加Label
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                // 注记摆放位置
                IEnvelope pEnv = pFeature.Extent;
                IPoint pPoint = new PointClass() {
                    X = (pEnv.XMax + pEnv.XMin) / 2,
                    Y = (pEnv.YMax + pEnv.YMin) / 2
                };
                // 文本符号
                ITextSymbol pTextSymbol = new TextSymbolClass() { 
                    Color = CreateRgbColor(0, 0, 0),
                    Font = CreateFontDisp(8)
                };
                // 文本对象
                IElement pTextElement = new TextElementClass() {
                    Text = pFeature.get_Value(fieldIndex).ToString(),
                    Symbol = pTextSymbol,
                    Geometry = pPoint,
                    ScaleText = true
                };
                pGC.AddElement(pTextElement, 0);
                pFeature = pFeatureCursor.NextFeature();
            }
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }


        /// <summary>
        /// 根据标识符选择要素
        /// </summary>
        /// <param name="featureLayer">选择要素的图层</param>
        /// <param name="fids">标识符集</param>
        public static void SelectFeaturesFromFIDs(IFeatureLayer featureLayer, params int[] fids)
        {
            m_pMapC2.Map.ClearSelection();
            m_pMapC2.Refresh();
            IFeatureCursor pFeatureCursor = featureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            int i = 0;
            while (pFeature != null)
            {
                if(fids.Contains(i))
                {
                    m_pMapC2.Map.SelectFeature(featureLayer, pFeature);
                }
                pFeature = pFeatureCursor.NextFeature();
                i++;
            }
            m_pMapC2.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        /// <summary>
        /// 缩放至选择集
        /// </summary>
        /// <param name="featureLayer"></param>
        public static void ZoomToSelect(IFeatureLayer featureLayer)
        {
            IEnumFeature pEnumFeature = m_pMapC2.Map.FeatureSelection as IEnumFeature;
            IFeature pFeature = pEnumFeature.Next();
            IEnvelope pEnv = pFeature.Extent;
            while (pFeature != null)
            {
                pEnv.Union(pFeature.Extent);
                pFeature = pEnumFeature.Next();
            }
            if (pEnv.XMin == pEnv.XMax && pEnv.YMin == pEnv.YMax)
            {
                pEnv.XMin -= 0.0005;
                pEnv.XMax += 0.0005;
                pEnv.YMin -= 0.0005;
                pEnv.YMax += 0.0005;
            }
            m_pMapC2.Extent = pEnv;
        }

        /// <summary>
        /// 通过符号选择器选择符号样式
        /// </summary>
        /// <param name="geometryType">要素类型</param>
        /// <returns>返回 ISymbol 对象</returns>
        public static ISymbol GetSymbolBySymbolSelector(esriGeometryType geometryType)
        {
            ISymbol symbol = null;
            switch (geometryType)
            { 
                case esriGeometryType.esriGeometryPoint:
                    symbol = new SimpleMarkerSymbolClass();
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    symbol = new SimpleLineSymbolClass();
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    symbol = new SimpleFillSymbolClass();
                    break;
            }
            ESRI.ArcGIS.DisplayUI.ISymbolSelector pSymbolSelector = new ESRI.ArcGIS.DisplayUI.SymbolSelectorClass();
            pSymbolSelector.AddSymbol(symbol);
            bool response = pSymbolSelector.SelectSymbol(0);
            if (response)
            {
                symbol = pSymbolSelector.GetSymbolAt(0);
                return symbol;
            }
            return null;
        }

    }
}
