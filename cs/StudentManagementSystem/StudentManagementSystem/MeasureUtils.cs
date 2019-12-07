using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.Geometry;

namespace StudentManagementSystem
{
    class MeasureUtils
    {
        private static class Func
        {
            public static double GetDistance(double x1, double y1, double x2, double y2)
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }
        }

        public static IPoint GetNearestStudent(List<IPoint> students, int targetStudentIndex)
        {
            int len = students.Count;
            if (targetStudentIndex < 0 || targetStudentIndex >= len)
                return null;
            double minValue = Double.MaxValue;
            int minIndex = int.MaxValue;
            IPoint pTargetPoint = students[targetStudentIndex];

            int i = 0;
            for (; i < len; i++)
            {
                if (i != targetStudentIndex)
                {
                    double distance = Func.GetDistance(pTargetPoint.X, pTargetPoint.Y, students[i].X, students[i].Y);
                    if (distance < minValue)
                    {
                        minValue = distance;
                        minIndex = i;
                    }
                }
            }
            if (minIndex != int.MaxValue)
                return students[minIndex];
            else
                return null;
            
        }
        public static double GetDistance(IPoint point1, IPoint point2)
        {
            return Func.GetDistance(point1.X, point1.Y, point2.X, point2.Y);
        }
        public static IPoint GetCenterPoint(List<IPoint> pointList)
        {
            double sumX = 0, sumY = 0;
            foreach (IPoint pt in pointList)
            {
                sumX += pt.X;
                sumY += pt.Y;
            }
            int len = pointList.Count;
            return new PointClass() { 
                X = sumX / len, Y = sumY / len,
                SpatialReference = pointList[0].SpatialReference
            };
        }
    }
}
