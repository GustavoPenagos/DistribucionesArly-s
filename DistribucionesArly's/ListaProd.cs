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
    public partial class ListaProd : Form
    {
        public ListaProd()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void ListaProd_Load(object sender, EventArgs e)
        {
            //this.lista_productoTableAdapter.Fill(this.distribucionesArlysDataSet.lista_producto);
            ListaProducto();
        }
        private void buscaProd_Click(object sender, EventArgs e)
        {
            try
            {
                var selectBusc = this.selectBus.Text;
                
                if(this.buscaProd.Text == "")
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
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListaProducto()
        {
            try
            {
                string query1 = "SELECT *  FROM lista_producto";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query1, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public void ListaBusqueda(string a)
        {
            try
            {
                string query = "select * from lista_producto where " + a.ToString() + " like '" + this.buscarProd.Text + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No existe un producto con este nombre (" + this.buscaProd.Text + ")");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void buscarProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.selectBus.Text.Equals("ID"))
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){
                        e.Handled = true;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void selectBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buscarProd.Clear();
        }
    }
}
