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
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.lista_producto' table. You can move, or remove it, as needed.
            
            ListaProducto();
        }
        private void buscaProd_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from lista_producto where Nombre_Prod like '" + this.buscarProd.Text + "%'";
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
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListaProducto()
        {
            string query1 = "SELECT *  FROM lista_producto";
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }
    }
}
