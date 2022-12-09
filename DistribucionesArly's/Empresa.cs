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
    public partial class Empresa : Form
    {
        public Empresa()
        {
            InitializeComponent();
        }
        //RegistraEmpresa
        private void OpenFrom(object fromhijo)
        {
            if (this.panelContainEmpresa.Controls.Count > 0)
            {
                this.panelContainEmpresa.Controls.RemoveAt(0);
            }
            Form fh = fromhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainEmpresa.Controls.Add(fh);
            this.panelContainEmpresa.Tag = fh;
            fh.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistraEmpresa());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaEmpresa());
        }
    }
}
