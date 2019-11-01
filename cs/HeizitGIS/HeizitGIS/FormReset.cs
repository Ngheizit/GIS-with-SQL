using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeizitGIS
{
    public partial class FormReset : Form
    {
        public FormReset()
        {
            InitializeComponent();
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            if ((Button)sender == btn_reset)
            {

                return;
            }

            if ((Button)sender == btn_cancel)
            {
                this.Close();
                return;
            }
        }
    }
}
