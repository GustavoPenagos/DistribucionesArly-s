using System;
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
    public partial class ListaBodega : Form
    {
        public ListaBodega()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void RegistroBodega_Load(object sender, EventArgs e)
        {
            //
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Eliminar";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            //
            OrdenarLista();
        }
        private void verProducto_Click(object sender, EventArgs e)
        {
            BuscarEnBodega();
        }
        private void nombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.selecBus.Text.Equals("ID"))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BuscarEnBodega();
            }
        }
        private void BuscarEnBodega()
        {
            try
            {
                var selectBusc = this.selecBus.Text;

                if (this.nombreProducto.Text == "")
                {
                    MessageBox.Show("Campo de busqueda vacio");
                    return;
                }
                else
                {
                    switch (selectBusc)
                    {
                        case "ID":
                            selectBusc = "ID";
                            ListaBusqueda(selectBusc.ToString());
                            break;
                        case "Nombre":
                            selectBusc = "Producto";
                            ListaBusqueda(selectBusc.ToString());
                            break;
                        case "Marca":
                            selectBusc = "Marca";
                            ListaBusqueda(selectBusc.ToString());
                            break;
                        default: MessageBox.Show("No ha elegido un opcion valida"); break;
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void OrdenarLista()
        {
            try
            {
                string query1 = "SELECT *  FROM lista_bodega ORDER BY Cantidad asc;";
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                con.Close();
                this.nombreProducto.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OrdenarLista();
        }
        private void ListaBusqueda(string a)
        {
            try
            {
                string query = "SELECT *  FROM lista_bodega where " + a + " like '" + this.nombreProducto.Text + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe un producto con este codigo de barras (" + this.nombreProducto.Text + ")");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void selecBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.nombreProducto.Clear();
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
                        long row = Convert.ToInt64(dataGridView1.Rows[ind].Cells["ID"].Value.ToString());
                        Eliminar(row);
                        OrdenarLista();
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
                string query = "delete from bodega where Id_Prod = " + row;
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
