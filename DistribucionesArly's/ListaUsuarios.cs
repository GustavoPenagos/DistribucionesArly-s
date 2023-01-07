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
            //
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Eliminar";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            //
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    string passw = "select (u.Password) from [User] as u where Id_User = 1006508619";
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(passw, con);
                    DataTable dt = new DataTable();
                    ad.Fill(dt);
                    var passW = dt.Rows[0].ItemArray[0].ToString();
                    con.Close();
                    string password = Microsoft.VisualBasic.Interaction.InputBox("CONTRASEÑA DE ADMINISTRADOR", "Prohibido el acceso");
                    if (password.Equals(passW))
                    {
                        int ind = Convert.ToInt32(e.RowIndex.ToString());
                        long row = Convert.ToInt64(dataGridView1.Rows[ind].Cells["identificacion"].Value.ToString());
                        if(row == 1006508619)
                        {
                            MessageBox.Show("Este usuario no se puede eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        Eliminar(row);
                        //ListaProducto();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña Incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datagridview2" + ex.Message);
            }
        }
        private void Eliminar(long row)
        {
            try
            {
                string query = "delete from Producto where Id_Prod = " + row;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar" + ex.Message); ;
            }
        }
    }
}
