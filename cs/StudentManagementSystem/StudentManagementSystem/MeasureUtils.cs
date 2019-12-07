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
            public static double GetXmax(List<IPoint> pointList)
            {
                double Xmax = Double.MinValue;
                foreach (IPoint pt in pointList)
                {
                    if (pt.X > Xmax)
                        Xmax = pt.X;
                }
                return Xmax;
            }
            public static double GetXmin(List<IPoint> pointList)
            {
                double Xmin = Double.MaxValue;
                foreach (IPoint pt in pointList)
                {
                    if (pt.X < Xmin)
                        Xmin = pt.X;
                }
                return Xmin;
            }
            public static double GetYmax(List<IPoint> pointList)
            {
                double Ymax = Double.MinValue;
                foreach (IPoint pt in pointList)
                {
                    if (pt.Y > Ymax)
                        Ymax = pt.Y;
                }
                return Ymax;
            }
            public static double GetYmin(List<IPoint> pointList)
            {
                double Ymin = Double.MaxValue;
                foreach (IPoint pt in pointList)
                {
                    if (pt.Y < Ymin)
                        Ymin = pt.Y;
                }
                return Ymin;
            }
            public static double GetXave(List<IPoint> pointList)
            {
                double sum = 0;
                foreach (IPoint pt in pointList)
                {
                    sum += pt.X;
                }
                return sum / pointList.Count;
            }
            public static double GetYave(List<IPoint> pointList)
            {
                double sum = 0;
                foreach (IPoint pt in pointList)
                {
                    sum += pt.Y;
                }
                return sum / pointList.Count;
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
        public static double GetRValue(List<IPoint> pointList, double area) // 邻近指数 R值
        {
            double Xmin = Func.GetXmin(pointList),
                   Xmax = Func.GetXmax(pointList),
                   Ymin = Func.GetYmin(pointList),
                   Ymax = Func.GetYmax(pointList),
                   Xave = Func.GetXave(pointList),
                   Yave = Func.GetYave(pointList);
            int count = pointList.Count;
            double[] minValues = new double[count];
            int index = 0;
            foreach (IPoint pt in pointList)
            {
                double minValue = Double.MaxValue;
                foreach (IPoint otherPt in pointList)
                {
                    if (otherPt != pt)
                    {
                        double distance = GetDistance(pt, otherPt);
                        if (distance < minValue)
                            minValue = distance;
                    }
                }
                minValues[index++] = minValue;
            }
            double aveMinDistance = minValues.Sum() / count;
            double beautifulDistance = 1.0 / (2 * Math.Sqrt(count / area));

            double R = aveMinDistance / beautifulDistance;

            Forms.FormRValue f_RValue = new Forms.FormRValue();
            f_RValue.SetLocationInfoTable(pointList);
            f_RValue.SetMinMaxAveTable(
                new double[] { Xmin, Xmax, Xave },
                new double[] { Ymin, Ymax, Yave }
            );
            f_RValue.SetCenterPointTable(GetCenterPoint(pointList).X, GetCenterPoint(pointList).Y);
            f_RValue.SetAreaTable(area);
            f_RValue.SetPointCountTable(count);
            double[,] distances = new double[count,count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                        distances[i, j] = Double.NaN;
                    else
                        distances[i, j] = GetDistance(pointList[i], pointList[j]);
                }
            }
            f_RValue.SetDistancesTbale(distances);
            f_RValue.SetMinDistanceAve(aveMinDistance);
            f_RValue.SetBeautifulMinDistanceAve(beautifulDistance);
            f_RValue.SetRValue(R);
            f_RValue.Show();

            return R;
        }
    }
}
