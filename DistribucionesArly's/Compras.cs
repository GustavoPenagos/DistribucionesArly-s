using Aspose.Words.Drawing;
using Aspose.Words.Shaping;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
            //

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Eliminar";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(btn);
            //
            DatosCompra();
            ListaCompra();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");

        private void butBusComp_Click(object sender, EventArgs e)
        {
            try
            {
                CompareExistente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void idProdC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    this.canProd.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ListaProd()
        {
            try
            {
                long numericValue;
                bool isNumber = long.TryParse(this.idProdC.Text, out numericValue);
                string queryProducto = ""; long ID = 0;
                if (!isNumber)
                {
                    string query = "select ID from lista_bodega where Producto like '%" + this.idProdC.Text + "%'";
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(query, con);
                    DataTable dtt = new DataTable();
                    ad.Fill(dtt);
                    ID = Convert.ToInt64(dtt.Rows[0].ItemArray[0].ToString());
                    con.Close();
                    queryProducto = "Select * from producto where Id_Prod = " + ID;
                }
                else
                {
                    queryProducto = "Select * from producto where Id_Prod = " + this.idProdC.Text;
                }
                //queryProducto = "Select * from producto where Id_Prod = " + this.idProdC.Text;
                if (this.idProdC.Text.Equals(""))
                {
                    return;
                }
                //string queryBodega = "select * from bodega";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryProducto, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var id_prod = dt.Rows[0].ItemArray[0].ToString();
                var nombre = dt.Rows[0].ItemArray[1].ToString();
                var precio = dt.Rows[0].ItemArray[6].ToString();
                var unidades = dt.Rows[0].ItemArray[3].ToString();
                //con.Close();
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;
                //
                string v = "";
                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }
                var cantidad = Convert.ToInt64(this.canProd.Text);
                for (int i = 0; i < cantidad; i++)
                {
                    string query2 = "INSERT INTO [dbo].[Compras] " +
                    "VALUES (" + Convert.ToInt64(id_prod) + ",'" + nombre +
                    "','" + precio + "'," + Convert.ToInt64(unidades) + ", '" + v + "')";
                    //con.Open();
                    SqlCommand cmd = new SqlCommand(query2, con);
                    cmd.ExecuteNonQuery();
                }
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
                MessageBox.Show("ListaProd_" + ex.Message);
            }
        }

        private void fCompra_Click(object sender, EventArgs e)
        {
            try
            {
                double total = double.Parse(this.totalVenta.Text, NumberStyles.Currency);
                double cancela = this.cancelaCon.Text.Equals("") ? total : double.Parse(this.cancelaCon.Text);
                if (total > cancela)
                {
                    MessageBox.Show(cancela + " es menor a la venta de " + total);
                    return;
                }
                DialogResult dr = MessageBox.Show("¿FINALIZAR VENTA?", "Seleccionar", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        var resultImp = this.rBImprimir.Checked;
                        switch (resultImp)
                        {
                            case (true):
                                SeleccionImp("yes");
                                break;
                            case (false):
                                SeleccionImp("no");
                                break;
                            default: break;
                        }
                        break;
                    case DialogResult.No:
                        con.Close();
                        MessageBox.Show("COMPRA CANCELADA");
                        break;
                }


            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("fCompra_Click" + ex.Message);
            }
        }

        private void FacturacionNit()
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
                    this.cambioDe.Text = cambio.ToString("C").Replace(",00", string.Empty);
                    MessageBox.Show("El cambio al cliente es:" + cambio.ToString("C").Replace(",00", string.Empty), "CAMBIO");
                }
                //MessageBox.Show("paso");
                //IMPRIMIR FACTURA

                var conteo = dataGridView2.Rows.Count;
                string nombreStr = "";
                string direcStr = "";
                string telStr = "";
                string nitStr = "";
                
                if (conteo != 0)
                {
                    try
                    {
                        string ID = Microsoft.VisualBasic.Interaction.InputBox("Identificación del cliente", "Datos de factura Nit");
                       
                        ClsFactura.CreaTicket Ticket1 = new ClsFactura.CreaTicket();

                        Ticket1.TextoCentro("Empresa Distribuciones Arly's ");
                        Ticket1.TextoCentro("NIT: 40079945-0 ");//imprime una linea de descripcion
                        Ticket1.TextoCentro("**********************************");
                        //
                        string queryNit = "select * from [User] where Id_User like '" + ID + "'";
                        con.Open();
                        SqlDataAdapter ad = new SqlDataAdapter(queryNit, con);
                        DataTable td = new DataTable();
                        ad.Fill(td);
                        var cc = ""; int i = 0;
                        var nombre = ""; var direc = ""; var tel = ""; var nit = ""; 
                        for (i = 0; i < td.Rows.Count; i++)
                        {
                            cc = td.Rows[i].ItemArray[0].ToString();
                            if (cc == ID)
                            {
                                //
                                cc = td.Rows[i].ItemArray[0].ToString();
                                //
                                nombre = td.Rows[i].ItemArray[1].ToString();
                                direc = td.Rows[i].ItemArray[3].ToString();
                                tel = td.Rows[i].ItemArray[2].ToString();
                                nit = td.Rows[i].ItemArray[4].ToString();
                                //
                                Ticket1.TextoIzquierda("Nombre: " + nombre);
                                Ticket1.TextoIzquierda("Dirc: " + direc);
                                Ticket1.TextoIzquierda("Tel: " + tel);
                                Ticket1.TextoIzquierda("Nit: " + nit);
                                break;
                            }
                        }
                        if (i == td.Rows.Count)
                        {
                            con.Close();
                            MessageBox.Show("No existe este cliente", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            nombreStr = Microsoft.VisualBasic.Interaction.InputBox("Por favor\nEsribir nombre", "Datos de factura Nit");//NIT OTRA EMPRESA
                            direcStr = Microsoft.VisualBasic.Interaction.InputBox("Por favor\nEsribir dirección", "Datos de factura Nit");//NIT OTRA EMPRESA
                            telStr = Microsoft.VisualBasic.Interaction.InputBox("Por favor\nEsribir telefono", "Datos de factura Nit");//NIT OTRA EMPRESA
                            nitStr = Microsoft.VisualBasic.Interaction.InputBox("Por favor\nEsribir NIT", "Datos de factura Nit");//NIT OTRA EMPRESA
                            
                            Ticket1.TextoIzquierda("Nombre: " + nombreStr);
                            Ticket1.TextoIzquierda("Dirc: " + direcStr);
                            Ticket1.TextoIzquierda("Tel: " + telStr);
                            Ticket1.TextoIzquierda("Nit: " + nitStr);
                        }
                        
                        Ticket1.TextoIzquierda("");
                        Ticket1.TextoIzquierda("");
                        Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                        //con.Open();
                        string queryIdFac = "select MAX(Id_Factura) + 1 from Factura ";
                        SqlDataAdapter da = new SqlDataAdapter(queryIdFac, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var idFactura = dt.Rows[0].ItemArray[0].ToString();
                        var facturaN = idFactura.Equals("") ? 0 + 1 : Convert.ToInt64(idFactura);
                        Ticket1.TextoIzquierda("No Fac:" + facturaN.ToString());
                        //con.Close();
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        Ticket1.TextoIzquierda("Le Atendio: Distribuciones Arly´s");
                        Ticket1.TextoIzquierda("");
                        ClsFactura.CreaTicket.LineasGuion();

                        ClsFactura.CreaTicket.EncabezadoVenta();
                        ClsFactura.CreaTicket.LineasGuion();
                        var n = dataGridView2.RowCount;
                        foreach (DataGridViewRow r in dataGridView2.Rows)
                        {
                                                        // PROD                                                 //PrECIO                                                                    CANT                                                       TOTAL
                            Ticket1.AgregaArticulo(r.Cells[3].Value.ToString(), double.Parse((double.Parse((r.Cells[4].Value.ToString()), NumberStyles.Currency)).ToString()), int.Parse(r.Cells[5].Value.ToString()), double.Parse((double.Parse((r.Cells[7].Value).ToString(), NumberStyles.Currency)).ToString())); //imprime una linea de descripcion
                        }
                        var totalComp = double.Parse(this.totalVenta.Text, NumberStyles.Currency);
                        var ivaComp = (totalComp / 1.19) * 0.19;
                        //DateTimeNow.Short.ToString
                        string fecha = DateTime.Now.ToShortDateString().ToString();
                        //

                        //
                        con.Open();
                        string queryFacRem = "INSERT INTO CARTERA VALUES (1,'" + totalComp.ToString() + "','" + fecha + "','" + facturaN.ToString() + "', '" + fecha + "', '0')";
                        SqlCommand cmdFact = new SqlCommand(queryFacRem, con);
                        cmdFact.ExecuteReader();
                        con.Close();
                        ClsFactura.CreaTicket.LineasGuion();
                        Ticket1.AgregaTotales("Sub-Total", totalComp); // imprime linea con Subtotal
                        Ticket1.AgregaTotales("Menos Descuento", double.Parse("000")); // imprime linea con decuento total
                        Ticket1.AgregaTotales("Mas IVA (19%)", ivaComp); // imprime linea con ITBis total
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total", totalComp); // imprime linea con total
                        Ticket1.TextoIzquierda(" ");
                        var efec = this.efectivo.Checked;
                        var transf = this.transferencia.Checked;
                        //
                        switch (true)
                        {
                            case true when efec:
                                Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(this.cancelaCon.Text, NumberStyles.Currency));
                                Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(this.cambioDe.Text, NumberStyles.Currency));
                                break;
                            case true when transf:
                                Ticket1.AgregaTotales("Pago por transferencia:", double.Parse(this.cancelaCon.Text, NumberStyles.Currency));
                                break;
                            default: break;
                        }
                        con.Close();

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
                        MessageBox.Show("(1)FacturacionNit", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("(2)FacturacionNit", ex.Message);
            }
        }

        private void ListaCompra()
        {
            try
            {
                //dataGridView2.Visible = true;
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;
                //
                string v = "";
                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }
                string query = "select * from Lista_Compras where [# Venta] like '" + v + "'";

                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView2.DataSource = dt;
                con.Close();
                this.canProd.Text = "1";
                
                if (dataGridView2.Rows.Count == 0) { totalVenta.Clear(); }
                DatosCompra();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("ListaCompra", ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.canProd.Text.Equals(""))
                {
                    MessageBox.Show("Campo candidad esta vacio");
                    return;
                }
                var cantidad = Convert.ToInt64(this.canProd.Text);
                if (this.idProdC.Text.Equals(""))
                {
                    MessageBox.Show("Campo ID esta vacio");
                    return;
                }
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;
                //
                string v = "";
                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }
                long numericValue;
                bool isNumber = long.TryParse(this.idProdC.Text, out numericValue);
                string query = ""; long ID = 0;
                if (!isNumber)
                {
                    string queryC = "select ID from lista_bodega where Producto like '%" + this.idProdC.Text + "%'";
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(queryC, con);
                    DataTable dtt = new DataTable();
                    ad.Fill(dtt);
                    ID = Convert.ToInt64(dtt.Rows[0].ItemArray[0].ToString());
                    con.Close();
                    query = "delete top (" + cantidad + ") from Compras where Id_Prod = " + ID + " and Num_Venta = " + v;
                } 
                else
                {
                    query = "delete top (" + cantidad + ") from Compras where Id_Prod = " + this.idProdC.Text + " and Num_Venta = " + v;
                }


                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                this.idProdC.Text = "";
                this.canProd.Text = "1";
                idProdC.Focus();

                ListaCompra();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("button1_Click" + ex.Message);
            }
        }

        private void canProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    CompareExistente();

                    this.idProdC.Focus();
                }
                else if (e.KeyChar == Convert.ToChar(Keys.Space))
                {
                    button1_Click(sender, e);
                    this.idProdC.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DatosCompra()
        {
            try
            {
                if (rBImprimir.Checked == false)
                {
                    rBFactNit.Visible = false;
                    rBRemision.Visible = false;
                    rBNImprimir.Visible = false;
                }
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;
                //
                string v = "";
                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }
                string query = "select sum(convert(decimal, Precio_Prod)) as total from Compras where [Num_Venta] like '" + v + "'";
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
                    if (dataGridView2 == null)
                    {
                        this.totalVenta.Text = "";
                    }
                    else
                    {
                        var st = double.Parse(itemArray.ToString());
                        var tv = (0.19 * st) + st;
                        this.totalVenta.Text = st.ToString("C").Replace(",00", string.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("DatosCompra", ex.Message);
            }
        }

        private void SeleccionImp(string a)
        {
            try
            {

                if (a.Equals("yes"))
                {
                    var resultImpNit = this.rBFactNit.Checked;
                    var resultImpREM = this.rBRemision.Checked;
                    if (resultImpNit == true)
                    {
                        FacturacionNit();
                    }
                    else if (resultImpREM == true)
                    {
                        FacturacionRem();
                    }
                }
                else
                {
                    //DateTimeNow.Short.ToString
                    string fecha = DateTime.Now.ToShortDateString().ToString();
                    //Total Venta
                    int totalVenta = int.Parse(this.totalVenta.Text, NumberStyles.Currency);
                    //

                    //
                    con.Open();
                    string queryFacRem = "INSERT INTO CARTERA VALUES (5,'" + totalVenta.ToString() + "','" + fecha + "','0','0','0')";
                    SqlCommand cmdFact = new SqlCommand(queryFacRem, con);
                    cmdFact.ExecuteReader();
                    con.Close();
                }
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;
                //
                string v = "";
                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }
                string queryCompra = "select * from Lista_Compras where [# Venta] like  '" + v + "'";
                SqlDataAdapter adap = new SqlDataAdapter(queryCompra, con);
                DataTable dTable = new DataTable();
                adap.Fill(dTable);
                con.Open();

                for (int i = 0; i < dTable.Rows.Count; i++)
                {

                    var idPro = dTable.Rows[i].ItemArray[1].ToString();
                    //
                    string queryBodega = "select * from Bodega where Id_Prod = " + idPro;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(queryBodega, con);
                    DataTable data = new DataTable();
                    dataAdapter.Fill(data);
                    //
                    var cantCompra = Convert.ToDouble(dTable.Rows[i].ItemArray[4].ToString());
                    var cantBodega = Convert.ToDouble(data.Rows[0].ItemArray[2].ToString());
                    var totalCan = cantBodega - cantCompra;
                    //
                    string queryDelete = "update Bodega set cantidad = " + totalCan + " where Id_Prod = " + idPro;
                    SqlCommand cmdDelete = new SqlCommand(queryDelete, con);
                    cmdDelete.ExecuteNonQuery();
                    //
                    string queryDeleteCompras = "delete from Compras where [Num_Venta] like '" + v + "' and Id_Prod =" + idPro;
                    SqlCommand cmdDeleteCompras = new SqlCommand(queryDeleteCompras, con);
                    cmdDeleteCompras.ExecuteNonQuery();
                }
                con.Close();
                dataGridView2.DataSource = null;
                this.cambioDe.Text = "";
                this.cancelaCon.Text = "";
                this.totalVenta.Text = "";
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("SeleccionImp", ex.Message);
            }

        }

        private void FacturacionRem()
        {
            try
            {
                string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre del cliente", "Datos de factura remisión");
                string telefono = Microsoft.VisualBasic.Interaction.InputBox("Telefono del cliente", "Datos de factura remisión");
                string direccion = Microsoft.VisualBasic.Interaction.InputBox("Dirección del cliente", "Datos de factura remisión");

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
                    this.cambioDe.Text = cambio.ToString("C").Replace(",00", string.Empty);
                    MessageBox.Show("El cambio al cliente es:" + cambio.ToString("C").Replace(",00", string.Empty), "CAMBIO");
                }
                //MessageBox.Show("paso");
                //IMPRIMIR FACTURA

                var conteo = dataGridView2.Rows.Count;
                if (conteo != 0)
                {
                    try
                    {
                        FacturaRem.CreaTicket Ticket1 = new FacturaRem.CreaTicket();

                        //Ticket1.TextoCentro("Empresa Distribuciones Arly's ");
                        //Ticket1.TextoCentro("NIT: 40079945-0 ");//imprime una linea de descripcion
                        //Ticket1.TextoCentro("NOTA REMISION");
                        Ticket1.TextoCentro("**********************************");

                        Ticket1.TextoIzquierda("Nombre: " + nombre);
                        Ticket1.TextoIzquierda("Dirc: " + direccion);
                        Ticket1.TextoIzquierda("Tel: " + telefono);
                        Ticket1.TextoIzquierda("");
                        //Ticket1.TextoCentro("Factura de Venta"); //imprime una linea de descripcion
                        //con.Open();
                        string queryIdFac = "select MAX(Id_Factura) + 1 from FacturaRem ";
                        SqlDataAdapter da = new SqlDataAdapter(queryIdFac, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var idFactura = dt.Rows[0].ItemArray[0].ToString();
                        var facturaN = idFactura.Equals("") ? 0 + 1 : Convert.ToInt64(idFactura);
                        Ticket1.TextoIzquierda("No Fac:" + facturaN.ToString());
                        //con.Close();
                        Ticket1.TextoIzquierda("Fecha:" + DateTime.Now.ToShortDateString() + " Hora:" + DateTime.Now.ToShortTimeString());
                        //Ticket1.TextoIzquierda("Le Atendio: Distribuciones Arly´s");
                        Ticket1.TextoIzquierda("");
                        FacturaRem.CreaTicket.LineasGuion();

                        FacturaRem.CreaTicket.EncabezadoVenta();
                        FacturaRem.CreaTicket.LineasGuion();
                        var n = dataGridView2.RowCount;
                        foreach (DataGridViewRow r in dataGridView2.Rows)
                        {
                                                         // PROD                                                 //PrECIO                                                                    CANT                                                       TOTAL
                            Ticket1.AgregaArticulo(r.Cells[3].Value.ToString(), double.Parse((double.Parse((r.Cells[4].Value.ToString()), NumberStyles.Currency)).ToString()), int.Parse(r.Cells[5].Value.ToString()), double.Parse((double.Parse((r.Cells[7].Value).ToString(), NumberStyles.Currency)).ToString())); //imprime una linea de descripcion
                        }
                        var totalComp = double.Parse(this.totalVenta.Text, NumberStyles.Currency);
                        var ivaComp = (totalComp / 1.19) * 0.19;
                        //DateTimeNow.Short.ToString
                        string fecha = DateTime.Now.ToShortDateString().ToString();
                        //
                        con.Open();
                        string queryFacRem = "INSERT INTO CARTERA VALUES (2,'" + totalComp.ToString() + "','" + fecha + "','" + facturaN.ToString() + "', '" + fecha + "', '0')";
                        SqlCommand cmdFact = new SqlCommand(queryFacRem, con);
                        cmdFact.ExecuteReader();
                        con.Close();
                        FacturaRem.CreaTicket.LineasGuion();
                        Ticket1.AgregaTotales("Sub-Total", totalComp); // imprime linea con Subtotal
                        Ticket1.AgregaTotales("Menos Descuento", double.Parse("000")); // imprime linea con decuento total
                        Ticket1.AgregaTotales("Mas IVA (19%)", ivaComp); // imprime linea con ITBis total
                        Ticket1.TextoIzquierda(" ");
                        Ticket1.AgregaTotales("Total", totalComp); // imprime linea con total
                        Ticket1.TextoIzquierda(" ");
                        var efec = this.efectivo.Checked;
                        var transf = this.transferencia.Checked;
                        //
                        switch (true)
                        {
                            case true when efec:
                                Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(this.cancelaCon.Text, NumberStyles.Currency));
                                Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(this.cambioDe.Text, NumberStyles.Currency));
                                break;
                            case true when transf:
                                Ticket1.AgregaTotales("Pago por transferencia:", double.Parse(this.cancelaCon.Text, NumberStyles.Currency));
                                break;
                            default: break;
                        }
                        con.Close();

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
                        MessageBox.Show("FacturacionRem", ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void CompareExistente()
        {
            try
            {
                if (this.canProd.Text.Equals(""))
                {
                    MessageBox.Show("Campo cantidad esta vacio"); return;
                }
                if (this.idProdC.Text.Equals(""))
                {
                    MessageBox.Show("Campo ID esta vacio"); return;
                }
                //
                long numericValue;
                bool isNumber = long.TryParse(this.idProdC.Text, out numericValue);
                string queryCompare = ""; long ID = 0;
                if (!isNumber)
                {
                    string query = "select ID from lista_bodega where Producto like '%" + this.idProdC.Text + "%'";
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(query, con);
                    DataTable dtt = new DataTable();
                    ad.Fill(dtt);
                    ID = Convert.ToInt64(dtt.Rows[0].ItemArray[0].ToString());
                    con.Close();
                    queryCompare = "Select * from bodega where Id_Prod = " + ID;
                }
                else
                {
                    queryCompare = "Select * from bodega where Id_Prod = " + this.idProdC.Text;
                }

                //
                con.Open();
                SqlCommand cmd = new SqlCommand(queryCompare, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var existe = Convert.ToInt64(dt.Rows[0].ItemArray[2].ToString());
                con.Close();
                var cantidad = Convert.ToInt64(this.canProd.Text);
                var result = existe - cantidad;
                //var id = Convert.ToInt64(this.idProdC.Text);
                if (existe <= 0 && result == 0)
                {
                    MessageBox.Show("El numero maximo de articulos en bodega es: " + existe);
                    return;
                }
                else
                {
                    if (result >= 0)
                    {
                        CantidadData(existe, cantidad, ID, result);
                    }
                    else
                    {
                        MessageBox.Show("El numero maximo de articulos en bodega es: " + existe);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("CompareExistente", ex.Message);
            }

        }

        private void CantidadData(long existe, long cantidad, long id, long result)
        {
            try
            {
                int count = Convert.ToInt32(dataGridView2.Rows.Count);
                if (existe >= cantidad)
                {
                    if (count == 0)
                    {
                        ListaProd();
                    }
                    else
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            var k = i + 1;
                            if (Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value) == id)
                            {
                                int lastRow = count - 1;
                                var cellCant = Convert.ToInt64(dataGridView2.Rows[i].Cells[5].Value);
                                var cellID = Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value);//error
                                //var idText = Convert.ToInt64(this.idProdC.Text);

                                if (cellID == id && cellCant <= existe)
                                {
                                    VaidarDataGridView(lastRow, cellCant, cellID, id);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("La cantidad en bodega es: " + existe + " unidades");
                                    return;
                                }
                            }
                            else if (k == dataGridView2.Rows.Count)
                            {
                                ListaProd();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El maximo de articulos disponibles es: " + existe + " Unidades");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CantidadData", ex.Message);
            }
        }

        private void VaidarDataGridView(int lastRow, long cellCant, long cellID, long idText)
        {
            try
            {
                //ultimo fila (index), cantidad de la fila, id de la fila, id en la caja de texto
                string queryCompare = "Select * from bodega where Id_Prod = " + idText;
                con.Open();
                SqlCommand cmd = new SqlCommand(queryCompare, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var numero = Convert.ToInt32(dt.Rows[0].ItemArray[2].ToString());
                con.Close();

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (Convert.ToInt64(dataGridView2.Rows[i].Cells[2].Value) == Convert.ToInt64(idText))
                    {
                        var cant = Convert.ToInt32(dataGridView2.Rows[i].Cells[5].Value);
                        int result = Convert.ToInt32(this.canProd.Text) + cant;
                        if (result <= numero)
                        {
                            ListaProd();
                            return;
                        }
                        else if (result > numero)
                        {
                            MessageBox.Show("El maximo de articulos disponibles es: " + numero + " Unidades");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("VaidarDataGridView ", ex.Message);
            }
        }

        private void ventaBut1_Click(object sender, EventArgs e)
        {
            try
            {
                ListaCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("venta click" + ex.Message);
            }
        }

        private void rBImprimir_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rBImprimir.Checked == true)
                {
                    this.rBNImprimir.Visible = true;
                    this.rBImprimir.Visible = false;
                }
                else if (this.rBImprimir.Checked == false)
                {
                    this.rBNImprimir.Visible = false;
                    this.rBImprimir.Visible = true;
                }
                if (this.rBNImprimir.Checked == true)
                {
                    this.rBFactNit.Visible = false;
                    this.rBRemision.Visible = false;
                }
                if (this.rBImprimir.Checked == true)
                {
                    this.rBFactNit.Visible = true;
                    this.rBRemision.Visible = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ventaBut1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                rBImprimir.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void idProdC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "select * from lista_bodega where Producto like '%" + this.idProdC.Text + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                this.idProdC.AutoCompleteMode = AutoCompleteMode.Suggest;
                this.idProdC.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection data = new AutoCompleteStringCollection();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    data.Add(dt.Rows[i].ItemArray[1].ToString());

                }
                this.idProdC.AutoCompleteCustomSource = data;
                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("idProdC" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;
                string query = "";
                //
                string v = "";
                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }
                con.Open();
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    var id = dataGridView2.Rows[i].Cells["ID"].Value.ToString();
                    var cantidad = dataGridView2.Rows[i].Cells["Cantidad"].Value.ToString();
                    //
                    query = "delete top (" + cantidad + ") from Compras where Id_Prod = " + id + "and Num_Venta = " + v;
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
                ListaCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("vaciar" + ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    int row = Convert.ToInt32(e.RowIndex.ToString());
                    string str = "psi";
                    Eliminar(row, str);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datagridview2" + ex.Message);
            }
        }
        private void Eliminar(int row, string str)
        {
            try
            {
                
                int index = str.Equals("") ? Convert.ToInt32(dataGridView2.CurrentCell.RowIndex.ToString()) : row;
                long ID = Convert.ToInt64(dataGridView2.Rows[index].Cells["ID"].Value);
                var cantidad = dataGridView2.Rows[index].Cells["cantidad"].Value.ToString();
                string query = ""; string v = "";
                
                var value1 = this.ventaBut1.Checked; var value2 = this.ventaBut2.Checked;
                var value3 = this.ventaBut3.Checked; var value4 = this.ventaBut4.Checked;

                switch (true)
                {
                    case true when value1:
                        v = "1";
                        break;
                    case true when value2:
                        v = "2";
                        break;
                    case true when value3:
                        v = "3";
                        break;
                    case true when value4:
                        v = "4";
                        break;
                    default: break;
                }

                query = "delete from Compras where Id_Prod = " + ID + " and Num_Venta = " + v;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                //
                this.idProdC.Text = "";
                this.canProd.Text = "1";
                idProdC.Focus();

                ListaCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Elimar" + ex.Message);
            }
        }

        private void RegistroUsuarioCompras(string cc, string nombre, string telefono, string direccion, string nit, string correo)
        {
            try
            {
                string query = "INSERT INTO [dbo].[User] VALUES (" + cc + ",'" + nombre + "','" + telefono + "','" + direccion + "'," + nit + "," + 1 + "," + 1 + ",'','" + correo + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has saved in database");


            }
            catch(Exception ex)
            {
                MessageBox.Show("RegistoUsuarioCompras" + ex.Message);
            }
        }
    }
}
