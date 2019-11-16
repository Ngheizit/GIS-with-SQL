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
            return new RgbColorClass()
            {
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

    }
}
