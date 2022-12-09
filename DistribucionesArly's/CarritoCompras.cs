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
    public partial class CarritoCompras : Form
    {
        public CarritoCompras()
        {
            InitializeComponent();
        }
        private void OpenFrom(object fromhijo)
        {
            if (this.panelContainCompras.Controls.Count > 0)
            {
                this.panelContainCompras.Controls.RemoveAt(0);
            }
            Form fh = fromhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainCompras.Controls.Add(fh);
            this.panelContainCompras.Tag = fh;
            fh.Show();
        }

        private void carroCompra_Click(object sender, EventArgs e)
        {
            OpenFrom(new Compras());
        }
    }
}
