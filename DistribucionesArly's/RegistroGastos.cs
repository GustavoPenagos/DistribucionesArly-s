using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class RegistroGastos : Form
    {
        public RegistroGastos()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void guardarRegistro_Click(object sender, EventArgs e)
        {
            RegistroGasto();
        }

        private void RegistroGasto()
        {
            try
            {
                string date = DateTime.Now.ToShortDateString();
                string query = "INSERT INTO [dbo].[Gastos] VALUES ('" + this.descriGasto.Text + "'," + this.dineroGasto.Text + ",'" + date + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro de gastos exitoso");
                borrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar"+ex);
            }
            con.Close();
            
        }
        private void borrar()
        {
            this.dineroGasto.Text = "";
            this.descriGasto.Text = "";
        }

        private void descriGasto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                RegistroGasto();
            }
        }
    } 
}
