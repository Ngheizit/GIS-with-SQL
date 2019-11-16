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
    public partial class FormTable : Form
    {
        private DataTable m_dataTable;

        public FormTable(DataTable dt)
        {
            InitializeComponent();

            this.m_dataTable = dt;
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
        }

        private void AddHeader(string name)
        {
            ColumnHeader colhdr = new ColumnHeader() { 
                Text = name,
                Width = 100
            };
            listView1.Columns.Add(colhdr);
        }

        private void FormTable_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_dataTable.Columns.Count; i++)
            {
                AddHeader(m_dataTable.Columns[i].ToString());
            }
            for (int i = 0; i < m_dataTable.Rows.Count; i++)
            {
                object[] obj_values = m_dataTable.Rows[i].ItemArray;
                string[] values = new string[obj_values.Length];
                for (int j = 0; j < obj_values.Length; j++)
                {
                    values[j] = obj_values[j].ToString();
                }

                ListViewItem item = new ListViewItem(values);
                listView1.Items.Add(item);
            }
        }
    }
}
