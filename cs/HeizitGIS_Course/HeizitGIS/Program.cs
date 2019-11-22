using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeizitGIS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormSignIn form_signIn = new FormSignIn();
            if (form_signIn.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FormMain(Convert.ToInt32(form_signIn.ID), form_signIn.Username));
            }
        }
    }
}
