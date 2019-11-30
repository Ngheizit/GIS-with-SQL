using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using System.Data;

namespace StudentsManagement.WxzForms
{
    /// <summary>
    /// FAddStudent.xaml 的交互逻辑
    /// </summary>
    public partial class FAddStudent : Window
    {
        public FAddStudent()
        {
            InitializeComponent();
        }
        private IPoint m_pPoint;
        public IPoint Point
        {
            get { return this.m_pPoint; }
            set { 
                this.m_pPoint = value;
                tbx_Location.Text = String.Format("{0}, {1}", m_pPoint.X, m_pPoint.Y);
            }
        }
        private string m_home;
        public string Home
        {
            get { return this.m_home; }
            set { 
                this.m_home = value;
                tbx_HOME.Text = m_home;
            }
        }
        public event Update updateDatGrid;

        private void Window_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void SimpleButton_Click_1(object sender, RoutedEventArgs e)
        {
            bool isAdding = (WxzUtils.Ae.IsAddingStudent = !WxzUtils.Ae.IsAddingStudent);
            if (isAdding)
            {
                this.WindowState = WindowState.Minimized;
                WxzUtils.Ae.SetMapC2MouseStyle(esriControlsMousePointer.esriPointerCrosshair);
            }
        }

        private void SimpleButton_Click_2(object sender, RoutedEventArgs e)
        {
            WxzUtils.Ae.DeleteAllElements();
            SetTextNull(tbx_HOME);
            SetTextNull(tbx_Location);
            SetTextNull(tbx_SBIRTH);
            SetTextNull(tbx_SID);
            SetTextNull(tbx_SNAME);
            SetTextNull(tbx_SSEX);
            this.Hide();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
        private void SetTextNull(DevExpress.Xpf.Editors.TextEdit td)
        {
            td.Text = "";
        }
        private void SetTextNull(ComboBox td)
        {
            td.Text = "";
        }

        private void SimpleButton_Click_3(object sender, RoutedEventArgs e)
        {
            string strSID = tbx_SID.Text,
                   strSNAME = tbx_SNAME.Text,
                   strSSEX = tbx_SSEX.Text,
                   strSBIRTH = tbx_SBIRTH.Text,
                   strSHOME = tbx_HOME.Text;
            if (strSHOME == "" || tbx_Location.Text == "" || strSBIRTH == "" || strSID == "" || strSNAME == "" || strSSEX == "")
            {
                MessageBox.Show("学生信息未填写完成");
                return;
            }
            if (WxzUtils.Sql.CommandSQL(
                String.Format("INSERT INTO  StudentInfo (SID,SName,SSex,SBirth,SHome) VALUES ('{0}','{1}','{2}','{3}','{4}')"
                              , strSID, strSNAME, strSSEX, strSBIRTH, strSHOME)) != 0)
            {
                DataTable dt = WxzUtils.Sql.GetDataTable(String.Format("SELECT Id FROM StudentInfo WHERE SID = '{0}' AND SName = '{1}'",
                    strSID, strSNAME));
                string strId = dt.Rows[0][0].ToString();
                WxzUtils.Ae.AddStudent(m_pPoint, strId, strSID, strSNAME, strSSEX, strSBIRTH, strSHOME);
                updateDatGrid();

                SetTextNull(tbx_HOME);
                SetTextNull(tbx_Location);
                SetTextNull(tbx_SBIRTH);
                SetTextNull(tbx_SID);
                SetTextNull(tbx_SNAME);
                SetTextNull(tbx_SSEX);
                MessageBox.Show(String.Format("学生【{0}】添加成功", strSNAME));
                this.Hide();
            }
        }

    }
}
