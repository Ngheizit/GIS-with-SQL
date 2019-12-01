using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Geodatabase;

namespace StudentsManagement.WxzForms
{
    public partial class FStudentInfo : Form
    {
        public FStudentInfo()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        public void SetInfo(string sid, string sname, string ssex, string sbirth, string shome)
        {
            listBoxControl1.Items.Clear();
            listBoxControl1.Items.Add(String.Format("学号：{0}", sid));
            listBoxControl1.Items.Add(String.Format("姓名：{0}", sname));
            listBoxControl1.Items.Add(String.Format("性别：{0}", ssex));
            listBoxControl1.Items.Add(String.Format("生日：{0}", sbirth));
            listBoxControl1.Items.Add(String.Format("家庭地址：{0}", shome));
        }
    }
}
