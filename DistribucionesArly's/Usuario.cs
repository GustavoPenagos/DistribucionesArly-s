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
    public partial class Usuario : Form
    {
        public Usuario()
        {
            InitializeComponent();
            OpenFrom(new ListaUsuarios());
        }
        private void OpenFrom(object fromhijo)
        {
            if (this.panelContainerProveedor.Controls.Count > 0)
            {
                this.panelContainerProveedor.Controls.RemoveAt(0);
            }
            Form fh = fromhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContainerProveedor.Controls.Add(fh);
            this.panelContainerProveedor.Tag = fh;
            fh.Show();
        }
        private void registroProveedores_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroUsuarios());
        }

        private void registroProveedor_Click(object sender, EventArgs e)
        {
            OpenFrom(new RegistroUsuarios());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaUsuarios());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFrom(new ListaUsuarios());
        }
    }
}
