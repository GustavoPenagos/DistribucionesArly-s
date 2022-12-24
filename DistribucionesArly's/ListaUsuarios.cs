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

        private void ListaUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
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
            catch (Exception)
            {
                MessageBox.Show("El numero " + this.idEliminar.Text + " no se ha eliminado correctamente");
            }
        }
        private void idBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.selecBus.Text.Equals("Identificacion") || this.selecBus.Text.Equals("Telefono"))
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                else if (this.selecBus.Text.Equals("Empresa"))
                {
                    e.Handled = false;
                }
                else
                {
                    if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    BuscarUser();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void borrar()
        {
            this.idEliminar.Clear(); ;
        }
        private void BuscarUser()
        {
            try
            {
                var selectBusc = this.selecBus.Text;

                if (this.idBuscar.Text == "")
                {
                    MessageBox.Show("Campo de busqueda vacio");
                    return;
                }
                else
                {
                    switch (selectBusc)
                    {
                        case "Identificacion":
                            selectBusc = "Identificacion";
                            BuscarUsuario(selectBusc.ToString());
                            break;
                        case "Nombre":
                            selectBusc = "Nombre";
                            BuscarUsuario(selectBusc.ToString());
                            break;
                        case "Empresa":
                            selectBusc = "Nombre de empresa";
                            BuscarUsuario(selectBusc.ToString());
                            break;
                        case "Telefono":
                            selectBusc = "Telefono";
                            BuscarUsuario(selectBusc.ToString());
                            break;
                        default: MessageBox.Show("No ha elegido un opcion valida"); break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No ha ingresado un documento no esiste");
            }
        }
        private void idEliminar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListarUsuarios()
        {
            try
            {
                string query1 = "SELECT *  FROM lista_usuario";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void BuscarUsuario(string a)
        {
            try
            {
                string query = " select * from lista_usuario where " + a.ToString() + " like '" + this.idBuscar.Text + "%'";
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void selecBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.idBuscar.Clear();
        }
        private void buscarId_Click(object sender, EventArgs e)
        {
            BuscarUser();
        }
    }
}
