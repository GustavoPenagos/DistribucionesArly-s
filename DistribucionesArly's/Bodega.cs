using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class Bodega : Form
    {
        public Bodega()
        {
            InitializeComponent();
            OpenFrom(new ListaBodega());
        }
        private void OpenFrom(object fromhijo)
        {
            if(this.panelContainBodega.Controls.Count > 0)
            {
                this.panelContainBodega.Controls.RemoveAt(0);
            }
            Form fh = fromhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainBodega.Controls.Add(fh);
            this.panelContainBodega.Tag = fh;
            fh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroProd());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaProd());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaBodega());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroProd());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaProd());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroProd());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFrom (new RegistroBodega());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroBodega());
        }
    }
}
