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
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DistribucionesArly_s
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
            DatosCompra();
            ListaCompra();
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
                this.canProd.Focus();
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
                con.Close();
                var cantidad = Convert.ToInt64(this.canProd.Text);
                for (int i = 0; i < cantidad; i++)
                {
                    string query2 = "INSERT INTO [dbo].[Compras] " +
                    "([Id_Prod],[Nom_Prod],[Precio_Prod],[Unid_Prod]) " +
                    "VALUES (" + Convert.ToInt32(id_prod) + ",'" + nombre +
                    "','" + precio + "'," + Convert.ToInt32(unidades) + ")";
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                
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
                Facturacion();

                string queryCompra = "select * from Lista_Compras";
                SqlDataAdapter adap = new SqlDataAdapter(queryCompra, con);
                DataTable dTable = new DataTable();
                adap.Fill(dTable);
                con.Open();
                for (int i = 0; i < dTable.Rows.Count; i++)
                {
                    var idPro = dTable.Rows[i].ItemArray[0].ToString();
                    var cantidad = dTable.Rows[i].ItemArray[3].ToString();
                    string queryDelete = "delete top (" + cantidad + ")  from bodega where Id_Prod = " + idPro;
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, con);
                    cmdDelete.ExecuteNonQuery();
                }
                string queryDeleteCompras = "delete from Compras";
                SqlCommand cmdDeleteCompras = new SqlCommand(queryDeleteCompras, con);
                cmdDeleteCompras.ExecuteNonQuery();
                con.Close();
                dataGridView2.DataSource = null;
                this.cambioDe.Text = "";
                this.cancelaCon.Text = "";
                this.totalVenta.Text = "";
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
                double cancela = this.cancelaCon.Text.Equals("") ? Convert.ToDouble(this.cancelaCon.Text = "0") : double.Parse(this.cancelaCon.Text, NumberStyles.Currency);

                if (this.cancelaCon.Text.Equals("0"))
                {
                    this.cancelaCon.Text = this.totalVenta.Text;
                    this.cambioDe.Text = "0";
                    MessageBox.Show("El cambio al cliente es: 0");
                }
                else if (!this.cancelaCon.Text.Equals(""))
                {

                    var value = double.Parse(this.totalVenta.Text, NumberStyles.Currency);

                    var cambio = cancela - value;
                    this.cambioDe.Text = cambio.ToString("C");
                    MessageBox.Show("El cambio al cliente es:" + cambio.ToString("C"), "CAMBIO");
                }
                //MessageBox.Show("paso");
                //IMPRIMIR FACTURA

                var conteo = dataGridView2.Rows.Count;
                if (conteo != 0)
                {
                    try
                    {
                        ClsFactura.CreaTicket Ticket1 = new ClsFactura.CreaTicket();

                        Ticket1.TextoCentro("Empresa Distribuciones Arly's ");
                        Ticket1.TextoCentro("NIT: 40079945-0 ");//imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");

                        Ticket1.TextoIzquierda("Dirc: xxxx");
                        Ticket1.TextoIzquierda("Tel: xxxx");
                        Ticket1.TextoIzquierda("");
                        Ticket1.TextoIzquierda("");
                        Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                        con.Open();
                        string queryIdFac = "select MAX(Id_Factura) + 1 from Factura ";
                        SqlDataAdapter da = new SqlDataAdapter(queryIdFac, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var idFactura = dt.Rows[0].ItemArray[0].ToString();
                        Ticket1.TextoIzquierda("No Fac:" + idFactura);
                        con.Close();
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        Ticket1.TextoIzquierda("Le Atendio: Distribuciones Arly´s");
                        Ticket1.TextoIzquierda("");
                        ClsFactura.CreaTicket.LineasGuion();

                        ClsFactura.CreaTicket.EncabezadoVenta();
                        ClsFactura.CreaTicket.LineasGuion();
                        var n = dataGridView2.RowCount;
                        foreach (DataGridViewRow r in dataGridView2.Rows)
                        {
                            // PROD                     //PrECIO                                    CANT                         TOTAL
                            Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse((double.Parse((r.Cells[2].Value.ToString()), NumberStyles.Currency)).ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse((double.Parse((r.Cells[5].Value).ToString(), NumberStyles.Currency)).ToString())); //imprime una linea de descripcion
                        }
                        var totalComp = double.Parse(this.totalVenta.Text, NumberStyles.Currency);
                        var ivaComp = (totalComp / 1.19) * 0.19;

                        ClsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaTotales("Sub-Total", totalComp / 1.19); // imprime linea con Subtotal
                        Ticket1.AgregaTotales("Menos Descuento", double.Parse("000")); // imprime linea con decuento total
                        Ticket1.AgregaTotales("Mas IVA (19%)", ivaComp); // imprime linea con ITBis total
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total", totalComp); // imprime linea con total
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(this.cancelaCon.Text, NumberStyles.Currency));
                        Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(this.cambioDe.Text, NumberStyles.Currency));


                        // Ticket1.LineasTotales(); // imprime linea 

                        Ticket1.TextoIzquierda(" ");
                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoCentro("*     Gracias por preferirnos    *");

                        Ticket1.TextoCentro("**********************************");
                        Ticket1.TextoIzquierda(" ");
                        string impresora = "Microsoft XPS Document Writer";
                        Ticket1.ImprimirTiket(impresora);




                        //MessageBox.Show("Gracias por preferirnos");
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        MessageBox.Show("Error");
                    }
                }
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("Error");
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
                this.canProd.Text = "1";
                DatosCompra();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cantidad = Convert.ToInt64(this.canProd.Text);
                string query = "delete top ("+cantidad+") from Compras where Id_Prod = "+this.idProdC.Text;

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.idProdC.Text = "";
                this.canProd.Text = "1";
                ListaCompra();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void canProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ListaProd();
                this.idProdC.Focus();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Space))
            {
                button1_Click(sender, e);
                this.idProdC.Focus();
            }
        }
        private void DatosCompra()
        {
            try
            {
                string query = "select sum(convert(decimal, Precio_Prod)) as total from Compras";
                con.Open();
                //SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                con.Close();
                var itemArray = dt.Rows[0].ItemArray[0].ToString();
                if (itemArray.Equals(""))
                {
                    return;
                }
                else
                {
                    var st = double.Parse(itemArray.ToString());
                    var tv = (0.19 * st) + st;
                    this.totalVenta.Text = st.ToString("C");
                }
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
