using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class ListaFacturas : Form
    {
        public ListaFacturas()
        {
            InitializeComponent();
            ListarFacturas();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var select = this.boxSelect.Text;
                var valor = this.boxBuscar.Text;
                string complemento = "";
                switch (select){
                    case "Numero factura":
                        select = "[N° Factua]";
                        complemento = "=";
                        ListarBuscar(select, valor, complemento);
                        break;
                    case "Fecha recibido":
                        select = "[Fecha recibido]";
                        complemento = "like";
                        ListarBuscar(select, valor, complemento);
                        break;
                    default: break;

                }
                    

            }catch(Exception ex)
            {
                MessageBox.Show("ButtonBuscar" +ex.Message);
            }
        }
        private void ListarFacturas()
        {
            try
            {
                string query = "select * from Lista_Cartera";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ListarFacturas" + ex.Message);
            }
        }
        private void ListarBuscar(string select, string valor, string complemento)
        {
            try
            {
                string query = "";
                if (complemento.Equals("like"))
                {
                    query = "select * from Lista_Cartera where " + select + " like '" + valor + "'";
                }
                else
                {
                    query = "select * from Lista_Cartera where " + select + " = " + valor ;
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show("ListarBuscar" + ex.Message);
            }
        }
    }
}
