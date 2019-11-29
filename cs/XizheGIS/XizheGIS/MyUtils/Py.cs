using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Diagnostics;

namespace XizheGIS.MyUtils
{
    class Py
    {
        private static string outputInfo = "";
        public static string GetOutputInfo()
        { return outputInfo; }

        public static void RunPy(string filename, string pythonExe = "python.exe", params string[] teps)
        {
            outputInfo = "";
            string args = "";
            string sArguments = filename;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            sArguments += " " + args;

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = pythonExe,
                Arguments = sArguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            Process p = new Process()
            {
                StartInfo = startInfo
            };
            p.Start();
            p.BeginOutputReadLine();
            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.WaitForExit();
        }
        
        private static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                outputInfo += (e.Data + Environment.NewLine);
            }
        }
    }

}
