using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace XizheGIS.MyUtils
{
    class System
    {
        public static void ReLoign()
        {
            Application.ExitThread();
            Thread thtmp = new Thread(new ParameterizedThreadStart(Run));
            object appName = Application.ExecutablePath;
            Thread.Sleep(1);
            thtmp.Start(appName);
        }
        private static void Run(object appName)
        {
            Process ps = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = appName.ToString()
                }
            };
            ps.Start();
        } 
    }
}
