using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class AbonosFacturas : Form
    {
        public AbonosFacturas()
        {
            InitializeComponent();
            ListaAbonos();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void buscarFactura_Click(object sender, EventArgs e)
        {
            try
            {
                var nFactura = this.numFactura.Text;
                string queryAbonos = "select * from Listado_Abono where [N° factura] = " + this.numFactura.Text; 
                con.Open();
                SqlCommand cmd = new SqlCommand(queryAbonos, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
                if(dt.Rows.Count != 0 )
                {
                    string send = "where Id_Factura = " + nFactura ;
                    MostrarTotal(send);
                }
                else
                {
                    MessageBox.Show("No existe este numero de factura: " + nFactura);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListaAbonos()
        {
            try
            {
                string queryAbonos = "select * from Listado_Abono";
                con.Open();
                SqlCommand cmd = new SqlCommand(queryAbonos, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource= dt;
                con.Close();
                string send = "empty";
                if (this.numFactura.Text.Equals(""))
                {
                    this.label3.Visible = false;
                    this.label4.Visible = false;
                    this.total.Visible = false;
                    this.sPendiente.Visible=false;
                }
                else
                {
                    MostrarTotal(send);
                }
                
            }catch(Exception ex)
            {
                MessageBox.Show("ListaAbonos"+ex.Message);
            }
        }
        private void MostrarTotal(string send)
        {
            try
            {
                this.label3.Visible = true;
                this.label4.Visible = true;
                this.total.Visible = true;
                this.sPendiente.Visible = true;
                //TOTAL ABONOS
                var queryAbonos = send.Equals("empty") ? "select format(sum(convert(decimal, abono)), 'C', 'es-CO') from Abono" : "select format(sum(convert(decimal, abono)), 'C', 'es-CO') from Abono " + send; 
                con.Open();
                SqlCommand cmd = new SqlCommand(queryAbonos, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var totales = dt.Rows[0].ItemArray[0].ToString();
                this.total.Text = totales;
                //SALDO PENDIENTE
                var queryPendiente = "select  top (1) convert(decimal, Valor_Total) from Abono " + send;
                SqlCommand cmdP = new SqlCommand(queryPendiente, con);
                SqlDataReader drP = cmdP.ExecuteReader();
                DataTable dtP = new DataTable();
                dtP.Load(drP);
                var pendiente = dtP.Rows[0].ItemArray[0].ToString();
                var total = double.Parse(totales, NumberStyles.Currency);
                var result = Convert.ToDouble(pendiente) - Convert.ToDouble(total);
                this.sPendiente.Text = result.ToString("C").Replace(",00", string.Empty);
                con.Close();

                
            }
            catch(Exception ex)
            {
                MessageBox.Show("MostrarTotal" + ex.Message);
            }
           
        }

    }
}
