using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using System.Data;
using ESRI.ArcGIS.Geodatabase;

namespace StudentsManagement
{
    public delegate void Update();

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        private AxMapControl axMapControl_Main;
        private IMapControl2 m_pMapC2;
        private IMapDocument m_pMapDoc;
        private WxzForms.FAddStudent f_AddStudent;

        public MainWindow()
        {
            InitializeComponent();
            this.axMapControl_Main = new AxMapControl();
            mapHost.Child = axMapControl_Main;
        }

        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.m_pMapC2 = axMapControl_Main.GetOcx() as IMapControl2;
            this.m_pMapDoc = new MapDocumentClass();
            this.axMapControl_Main.OnMouseDown += axMapControl_Main_OnMouseDown;
            this.axMapControl_Main.OnMouseMove += axMapControl_Main_OnMouseMove;
            this.axMapControl_Main.OnExtentUpdated += axMapControl_Main_OnExtentUpdated;
            this.f_AddStudent = new WxzForms.FAddStudent() { 
                
            };
            f_AddStudent.updateDatGrid += new Update(UpdateDataTable);

            UpdateDataTable();

            WxzUtils.Ae.SetMapControl(m_pMapC2);
            WxzUtils.Ae.SetMapDocument(m_pMapDoc);
            WxzUtils.Ae.LoadMxd("Map.mxd");
        }
        #region → 地图基本操作
        void axMapControl_Main_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (e.button == 4)
            {
                WxzUtils.Ae.Pan();
            }
            else if (e.button == 1 && WxzUtils.Ae.IsAddingStudent)
            {
                IPoint pPoint = new PointClass() { 
                    X = e.mapX, Y = e.mapY
                };
                WxzUtils.Ae.DrawPoint(pPoint);
                WxzUtils.Ae.IsAddingStudent = false;

                f_AddStudent.Point = pPoint;
                f_AddStudent.Home = GetClickLocation(pPoint);

                f_AddStudent.WindowState = WindowState.Normal;
                m_pMapC2.MousePointer = esriControlsMousePointer.esriPointerArrow;
            }
        }
        void axMapControl_Main_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            string lonlatUnit = String.Format("{0} {1} {2}", e.mapX.ToString(".###"), e.mapY.ToString(".###"), m_pMapC2.MapUnits.ToString().Substring(4));

            //IPoint pPoint = WxzUtils.Ae.PRJtoGCS(new PointClass() { 
            //    X = e.mapX, Y = e.mapY, SpatialReference = m_pMapC2.SpatialReference
            //});
            //string lonlatUnit = String.Format("{0} {1} {2}", pPoint.X, pPoint.Y, "Decimal Degree");

            tbx_LocationInfo.Content = lonlatUnit;
        }
        void axMapControl_Main_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            string MapScale = String.Format("比例尺：1:{0}", m_pMapC2.MapScale);
            tbx_MapScaleInfo.Content = MapScale;
        }


        private void btn_Save_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (WxzUtils.Ae.SaveMxd())
            {
                MessageBox.Show("地图文档保存成功");
            }
        }
        private void btn_FullExtent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            m_pMapC2.Extent = m_pMapC2.FullExtent;
        }
        private void btn_ZoomIn_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            WxzUtils.Ae.Zoom(1.1);
        }
        private void btn_ZoomOut_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            WxzUtils.Ae.Zoom(0.9);
        } 
        #endregion

        private string GetClickLocation(IPoint point)
        {
            string result = "";
            IFeatureLayer pFeatureLayer = WxzUtils.Ae.GetFeatureLayerByName("BOUA_PJ");
            ISpatialFilter pSpatialFilter = new SpatialFilterClass() {
                Geometry = point,
                SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects
            };
            IFeatureCursor pFeatureCursor = pFeatureLayer.FeatureClass.Search(pSpatialFilter as IQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            if (pFeature != null)
                result = pFeature.get_Value(pFeature.Fields.FindField("NAME")).ToString();
            return result;
        }


        #region → 学生信息可视化
        private void UpdateDataTable()
        {
            DataTable dt = WxzUtils.Sql.GetDataTable("SELECT * FROM StudentInfo");
            DataGridView_Student.ItemsSource = dt.DefaultView;
        }
        private void DataGridView_Student_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "yyyy/MM/dd";
        } 
        #endregion

        #region → 学生信息增删改
        private void btn_AddStudent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            if (f_AddStudent.IsHitTestVisible)
            {
                f_AddStudent.Show();
            }
        }
        private void btn_ModifyStudent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        }
        private void btn_DeleteStudent_Click(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {

        } 
        #endregion
    }
}
