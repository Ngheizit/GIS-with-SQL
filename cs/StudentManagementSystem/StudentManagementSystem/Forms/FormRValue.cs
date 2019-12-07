using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using ESRI.ArcGIS.Geometry;

namespace StudentManagementSystem.Forms
{
    public partial class FormRValue : DevExpress.XtraEditors.XtraForm
    {
        public FormRValue()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        private void AddHeader(ListView listView, string name, int width = 100)
        {
            ColumnHeader colhdr = new ColumnHeader() { 
                Text = name,
                Width = width
            };
            listView.Columns.Add(colhdr);
        }

        public void SetLocationInfoTable(List<IPoint> pointList)
        {
            int colCount = pointList.Count + 1;
            for (int i = 0; i < colCount; i++)
            {
                if (i == 0)
                {
                    AddHeader(table_LocationInfo, "地点");
                }
                else
                {
                    AddHeader(table_LocationInfo, i.ToString());
                }
            }
            string[] Xvalues = new string[colCount];
            Xvalues[0] = "X";
            for (int i = 0; i < pointList.Count; i++)
			{
                Xvalues[i + 1] = pointList[i].X.ToString();
			}
            string[] Yvalues = new string[colCount];
            Yvalues[0] = "Y";
            for (int i = 0; i < pointList.Count; i++)
            {
                Yvalues[i + 1] = pointList[i].Y.ToString();
            }
            ListViewItem Xitem = new ListViewItem(Xvalues);
            ListViewItem Yitem = new ListViewItem(Yvalues);
            table_LocationInfo.Items.Add(Xitem);
            table_LocationInfo.Items.Add(Yitem);
        }
        public void SetMinMaxAveTable(double[] xInfo, double[] yInfo)
        {
            AddHeader(table_MinMaxAve, "");
            AddHeader(table_MinMaxAve, "最大值");
            AddHeader(table_MinMaxAve, "最小值");
            AddHeader(table_MinMaxAve, "均值");
            string[] Xvalues = new string[4]{
                "X", xInfo[0].ToString(), xInfo[1].ToString(), xInfo[2].ToString()
            };
            string[] Yvalues = new string[4]{
                "Y", yInfo[0].ToString(), yInfo[1].ToString(), yInfo[2].ToString()
            };
            ListViewItem Xitem = new ListViewItem(Xvalues);
            ListViewItem Yitem = new ListViewItem(Yvalues);
            table_MinMaxAve.Items.Add(Xitem);
            table_MinMaxAve.Items.Add(Yitem);
        }
        public void SetCenterPointTable(double x, double y)
        {
            AddHeader(table_Center, "平均中心");
            AddHeader(table_Center, "");
            string[] Xvalues = new string[2]{
                "X", x.ToString()
            };
            string[] Yvalues = new string[2]{
                "Y", y.ToString()
            };
            ListViewItem Xitem = new ListViewItem(Xvalues);
            ListViewItem Yitem = new ListViewItem(Yvalues);
            table_Center.Items.Add(Xitem);
            table_Center.Items.Add(Yitem);
        }
        public void SetPointCountTable(int count)
        {
            AddHeader(table_Count, "样品数量");
            ListViewItem Xitem = new ListViewItem(count.ToString());
            table_Count.Items.Add(Xitem);
        }
        public void SetAreaTable(double area)
        {
            AddHeader(table_Area, "研究区面积");
            ListViewItem Xitem = new ListViewItem(area.ToString());
            table_Area.Items.Add(Xitem);
        }
        public void SetDistancesTbale(double[,] distances)
        {
            int colCount = distances.GetLength(0) + 1;
            for (int i = 0; i < colCount; i++)
            {
                if (i == 0)
                {
                    AddHeader(table_DistanceInfo, "相互距离");
                }
                else
                {
                    AddHeader(table_DistanceInfo, i.ToString());
                }
            }
            string[] mins = new string[colCount];
            mins[0] = "最小值";
            for (int i = 0; i < colCount - 1; i++)
            {
                double min = Double.MaxValue;
                string[] values = new string[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    if (j == 0)
                    {
                        values[0] = (i + 1).ToString();
                    }
                    else
                    {
                        values[j] = distances[i, j - 1].ToString();
                        if (distances[i, j - 1] < min)
                            min = distances[i, j - 1];
                    }
                }
                mins[i + 1] = min.ToString();
                ListViewItem item = new ListViewItem(values);
                table_DistanceInfo.Items.Add(item);
            }
            table_DistanceInfo.Items.Add(new ListViewItem(mins));
        }
        public void SetMinDistanceAve(double value)
        {
            tbx_MinDistanceAve.Text = value.ToString();
        }
        public void SetBeautifulMinDistanceAve(double value)
        {
            tbx_BeautifulMinDistanceAve.Text = value.ToString();
        }
        public void SetRValue(double value)
        {
            tbx_RValue.Text = value.ToString();
            if (value == 1)
            {
                tbx_Result.Text = "随机性分布";
            }
            else if (value > 1)
            {
                tbx_Result.Text = "趋向于离散型的均匀分布";
            }
            else if (value < 1)
            {
                tbx_Result.Text = "趋向于凝集型分布";
            }
        }
    }
}