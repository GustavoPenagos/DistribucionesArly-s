using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class Control : Form
    {
        public Control()
        {
            InitializeComponent();
            OpenFrom(new CostControl());
        }
        private void OpenFrom(object fromhijo)
        {
            if (this.panelContainControl.Controls.Count > 0)
            {
                this.panelContainControl.Controls.RemoveAt(0);
            }
            Form fh = fromhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainControl.Controls.Add(fh);
            this.panelContainControl.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFrom(new CostControl());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFrom(new CostControl());
        }
    }
}
