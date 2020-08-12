using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oef5WindowsFormsApp1108
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            {
                lb1.Items.Add(tbAdd.Text);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lb1.Items.Count > 0)
                lb1.Items.RemoveAt(lb1.SelectedIndex);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
            for (int i = 0; i < lb1.Items.Count; i++)
                {
                    writer.WriteLine((string)lb1.Items[i]);
                }
                writer.Close();
            }
            dlg.Dispose();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                lb1.Items.Clear();

                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(f.OpenFile()))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lb1.Items.Add(line);

                    }
                }
            }
        }
    }
}
