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
using ESRI.ArcGIS.Controls;

namespace StudentManagementSystem.Forms
{
    public partial class FormEditStudent : DevExpress.XtraEditors.XtraForm
    {
        public event UpdataDatabaseView UpdataDatabaseView;
        private bool m_pIsAdd; // true → 添加; false → 编辑
        private bool m_pIsGettingPoint = false;// 指示是主窗体是否采集点
        public bool IsGettingPoint {
            get { return this.m_pIsGettingPoint; }
            set { this.m_pIsGettingPoint = value; }
        }
        private IPoint m_pPoint;
        public IPoint Point {
            set { 
                this.m_pPoint = value;
                tbx_Location.Text = String.Format("{0}, {1}", m_pPoint.X.ToString(".###"), m_pPoint.Y.ToString(".###"));
                AeUtils.DrawPoint(m_pPoint);
            }
        }
        private string m_pSHome;
        public string Home {
            set {
                this.m_pSHome = value;
                tbx_Home.Text = m_pSHome;
            }
        }
        private string m_pId;

        public FormEditStudent()
        {
            InitializeComponent();
            this.Text = "添加学生信息";
            this.m_pIsAdd = true;
            InitStudentInfo();
        }
        public FormEditStudent(IPoint point, string id, string sid, string sname, string ssex, string sbirth, string shome)
        {
            InitializeComponent();
            this.Text = "编辑学生信息";
            this.m_pIsAdd = false;
            this.Point = point;
            this.m_pId = id;
            this.tbx_SId.Text = sid;
            this.tbx_SName.Text = sname;
            this.cbx_SSex.Text = ssex;
            this.dtime_SBirth.Text = sbirth.Split(' ')[0];
            this.Home = shome;
        }

        #region 自定义事件
        private void InitStudentInfo()
        {
            tbx_Location.Text = "";
            tbx_SId.Text = "";
            tbx_SName.Text = "";
            cbx_SSex.SelectedIndex = -1;
            dtime_SBirth.Text = "";
            tbx_Home.Text = "";
        }
        #endregion

        private void btn_GetLocation_Click(object sender, EventArgs e)
        {
            m_pIsGettingPoint = true;
            this.WindowState = FormWindowState.Minimized;
            AeUtils.SetMousePointer(esriControlsMousePointer.esriPointerCrosshair);
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (cbx_SSex.SelectedIndex == -1)
            {
                MessageBox.Show("学生信息未填写完成！", "无法添加学生信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string strSID = tbx_SId.Text,
                   strSNAME = tbx_SName.Text,
                   strSSEX = cbx_SSex.SelectedItem.ToString(),
                   strSBIRTH = dtime_SBirth.Value.ToShortDateString(),
                   strSHOME = tbx_Home.Text;
            if (strSID == "" || strSNAME == "" || strSSEX == "" || strSBIRTH == "" || strSHOME == "")
            {
                MessageBox.Show("学生信息未填写完成！", "无法添加学生信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (m_pIsAdd)
            {
                if (SqlUtils.AddStudent(strSID, strSNAME, strSSEX, strSBIRTH, strSHOME))
                {
                    string id = SqlUtils.GetIdFromSId(strSID);
                    AeUtils.AddStudent(m_pPoint, id, strSID, strSNAME, strSSEX, strSBIRTH, strSHOME);
                    MessageBox.Show(String.Format("学生【{0}】添加成功", strSNAME));
                    UpdataDatabaseView();
                    this.Close();
                }
            }
            else
            {
                if (SqlUtils.EditStudent(m_pId, strSID, strSNAME, strSSEX, strSBIRTH, strSHOME))
                {
                    AeUtils.EditStudent(this.m_pPoint, m_pId, strSID, strSNAME, strSSEX, strSBIRTH, strSHOME);
                    MessageBox.Show(String.Format("学生【Id:{0}】信息修改成功", m_pId));
                    UpdataDatabaseView();
                    this.Close();
                }
            }
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            InitStudentInfo();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            AeUtils.DeleteAllMapElement();
            this.Close();
        }
        private void FormEditStudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            AeUtils.DeleteAllMapElement();
        }

        private void tbx_SId_KeyPress(object sender, KeyPressEventArgs e) // 学号输入框仅允许输入数字
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (Char)8) // (Char)8 → 退格键
            {
                e.Handled = true;
                label_SId.Text = "学号：（仅能输入数字！）";
            }
            else
            {
                label_SId.Text = "学号：";
            }
        }


    }
}