using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace DistribucionesArly_s
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        
        public Form1()
        {
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            InitializeComponent();
        }
        private void OpenFrom(object fromhijo)
        {
            try
            {
                if (this.panelContainer.Controls.Count > 0)
                {
                    this.panelContainer.Controls.RemoveAt(0);
                }
                Form fh = fromhijo as Form;
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelContainer.Controls.Add(fh);
                this.panelContainer.Tag = fh;
                fh.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void carroCompra_Click(object sender, EventArgs e)
        {
            OpenFrom(new Compras());
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFrom(new Bodega());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFrom(new Usuario());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFrom(new Control());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFrom(new Gastos());
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //OpenFrom(new Validacion());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFrom(new CarritoCompras());
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFrom(new Bodega());
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OpenFrom(new Usuario());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            OpenFrom(new Control());
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            OpenFrom(new Gastos());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFrom(new Inicio());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MessageBox.Show("Esta ventana no se puede cerrar");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFrom(new Empresa());
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            OpenFrom(new Empresa());
        }
    }
}
