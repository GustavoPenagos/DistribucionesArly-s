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
    public partial class Gastos : Form
    {
        public Gastos()
        {
            InitializeComponent();
        }
        private void OpenFrom(object fromhijo)
        {
            if (this.panelGastos.Controls.Count > 0)
            {
                this.panelGastos.Controls.RemoveAt(0);
            }
            Form fh = fromhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelGastos.Controls.Add(fh);
            this.panelGastos.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroGastos());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaGastos());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroGastos());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaGastos());
        }
    }
}
