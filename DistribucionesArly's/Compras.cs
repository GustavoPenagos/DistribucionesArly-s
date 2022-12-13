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
    public partial class Compras : Form
    {
        public Compras()
        {
            //GuardarCompra();
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        
        private void butBusComp_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                ListaProd();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void idProdC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ListaProd();
            }
        }
        private void ListaProd()
        {
            try
            {
                string queryProducto = "Select * from producto where Id_Prod = " + this.idProdC.Text + "";
                //string queryBodega = "select * from bodega";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryProducto, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var id_prod = dt.Rows[0].ItemArray[0].ToString();
                var nombre = dt.Rows[0].ItemArray[1].ToString();
                var precio = dt.Rows[0].ItemArray[2].ToString();
                var unidades = dt.Rows[0].ItemArray[3].ToString();
                //dataGridView1.Rows.Add(new object[]{id_prod, nombre, precio, unidades, "Eliminar"});
                //var id = ""; 
                //var nProd = "";
                
                //SqlDataAdapter dat = new SqlDataAdapter(queryBodega, con);
                //DataTable dataTable = new DataTable();
                //dat.Fill(dataTable);
                //var id = dataTable.Rows[0].ItemArray[0].ToString();
                //var nProd = dataTable.Rows[0].ItemArray[1].ToString();

                string query2 = "INSERT INTO [dbo].[Compras] " +
                    "([Id_Prod],[Nom_Prod],[Precio_Prod],[Unid_Prod]) " +
                    "VALUES (" + Convert.ToInt32(id_prod) + ",'" + nombre + 
                    "','" + precio + "'," + Convert.ToInt32(unidades) + ")";

                SqlCommand cmd = new SqlCommand(query2, con);
                cmd.ExecuteNonQuery();
                con.Close();
                ListaCompra();
                this.idProdC.Text = "";
                this.idProdC.Focus();
            }
            catch (Exception ex)
            {
                con.Close();
                this.idProdC.Text = "";
                this.idProdC.Focus();
                MessageBox.Show(ex.Message);
            }
        }
        
        private void fCompra_Click(object sender, EventArgs e)
        {
            try
            {
                string queryCompra = "select * from Lista_Compras";
                SqlDataAdapter adap = new SqlDataAdapter(queryCompra, con);
                DataTable dTable = new DataTable();
                adap.Fill(dTable);
                con.Open();
                string queryDeleteCompras = "delete from Compras";
                for (int i = 0; i < dTable.Rows.Count; i++)
                {
                    var idPro = dTable.Rows[i].ItemArray[0].ToString();
                    var cantidad = dTable.Rows[i].ItemArray[3].ToString();
                    string queryDelete = "delete top (" + cantidad + ")  from bodega where Id_Prod = " +  idPro;
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, con);
                    cmdDelete.ExecuteNonQuery();
                }
                SqlCommand cmdDeleteCompras = new SqlCommand(queryDeleteCompras, con);
                cmdDeleteCompras.ExecuteNonQuery();
                con.Close();
                dataGridView2.DataSource = null;
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void Facturacion()
        {
            try
            {
                string query = "delete from compra";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Factura asi :P");
            }catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ListaCompra()
        {
            try
            {
                string query = "select * from Lista_Compras";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void GuardarCompra()
        {
            try
            {
                string query1 = "SELECT *  FROM bodega;";
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView2.DataSource = dataTable;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
