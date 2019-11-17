﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace HeizitGIS
{
    public partial class FormTable : Form
    {
        private DataTable m_dataTable;
        private IFeatureLayer m_pFeatureLayer;

        public FormTable(DataTable dt)
        {
            InitializeComponent();

            this.m_dataTable = dt;
        }
        public FormTable(IFeatureLayer featurelayer)
        {
            InitializeComponent();

            this.m_pFeatureLayer = featurelayer;
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
            listView1.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.MultiSelect = true;

            if (this.m_dataTable != null)
            {
                ShowDataTable();
            }
            else
            {
                ShowFeatureAttribute();
            }
        }

        private void ShowDataTable()
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
        private void ShowFeatureAttribute()
        {
            IFields pFields = m_pFeatureLayer.FeatureClass.Fields;
            int len = pFields.FieldCount;
            for (int i = 0; i < len; i++)
            {
                AddHeader(pFields.get_Field(i).Name);
            }
            IFeatureCursor pFeatureCursor = m_pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            while (pFeature != null)
            {
                string[] values = new string[len];
                for (int i = 0; i < len; i++)
                {
                    if (i == 1)
                    {
                        values[1] = pFeature.Shape.GeometryType.ToString().Substring(12);
                    }
                    else
                    {
                        values[i] = pFeature.get_Value(i).ToString();
                    }
                }
                ListViewItem item = new ListViewItem(values);
                listView1.Items.Add(item);
                pFeature = pFeatureCursor.NextFeature();
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            MessageBox.Show(e.Column.ToString());
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            AeUtils.ZoomToSelect(m_pFeatureLayer);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int len = listView1.SelectedItems.Count;
            int[] fids = new int[len];
            for (int i = 0; i < len; i++)
            {
                fids[i] = listView1.SelectedIndices[i];
            }
            AeUtils.SelectFeaturesFromFIDs(m_pFeatureLayer, fids);
        }

        private void 缩放至选择集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AeUtils.ZoomToSelect(m_pFeatureLayer);
        }

    }
}
