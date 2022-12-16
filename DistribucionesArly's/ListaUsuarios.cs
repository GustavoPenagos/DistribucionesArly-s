using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DistribucionesArly_s
{
    public partial class ListaUsuarios : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        public ListaUsuarios()
        {
            InitializeComponent();
        }

        private void buscarId_Click(object sender, EventArgs e)
        {
            BuscarUser();            
        }

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.lista_usuario' table. You can move, or remove it, as needed.
            this.lista_usuarioTableAdapter.Fill(this.distribucionesArlysDataSet.lista_usuario);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = " delete from [User] where Id_User = " + this.idEliminar.Text;
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("El numero " + this.idEliminar.Text + " se ha eliminado correctamente");
                borrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El numero " + this.idEliminar.Text + " no se ha eliminado correctamente");
            }
        }

        private void idBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BuscarUser();
            }
        }
        private void borrar()
        {
            this.idEliminar.Text = "";
        }
        private void BuscarUser()
        {
            try
            {
                string query = " select * from lista_usuario where Nombre like '%" + this.idBuscar.Text + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe un registro con este numero");
                }
                con.Close();
                borrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha ingresado un documento no esiste");
            }
        }

        private void idEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button1_Click(sender, e);
            }
        }
    }
}
