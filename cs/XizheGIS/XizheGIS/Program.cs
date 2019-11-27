using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;

namespace XizheGIS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();

            MyForm.FSignIn f_SignIn = new MyForm.FSignIn();
            if (f_SignIn.ShowDialog() == DialogResult.OK)
            { 
                Application.Run(new FormMain(f_SignIn.ID, f_SignIn.Username));
            }
        }
    }
}
