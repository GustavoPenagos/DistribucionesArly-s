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
            OrdenarLista();
        }

        private void verProducto_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.lista_bodega' table. You can move, or remove it, as needed.
            //this.lista_bodegaTableAdapter.Fill(this.distribucionesArlysDataSet.lista_bodega);
            BuscarEnBodega();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void nombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BuscarEnBodega();
            }
        }
        private void BuscarEnBodega()
        {
            try
            {
                string query = "SELECT *  FROM lista_bodega where Nombre_Prod like '%" + this.nombreProducto.Text + "%'";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void OrdenarLista()
        {
            string query1 = "SELECT *  FROM lista_bodega ORDER BY Cantidad asc;";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrdenarLista();
        }
    }
}
