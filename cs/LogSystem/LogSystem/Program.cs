using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormSignIn f_SignIn = new FormSignIn();
            if (f_SignIn.ShowDialog() == DialogResult.OK)
            {
                string strId = f_SignIn.Id,
                       strUsername = f_SignIn.Username;

                Application.Run(new FormMain(strId, strUsername));
            }

        }
    }
}
