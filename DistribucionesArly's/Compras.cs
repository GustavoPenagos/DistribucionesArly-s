using System;
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
                CompareExistente();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void idProdC_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    this.canProd.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void ListaProd()
        {
            try
            {
                string queryProducto = "Select * from producto where Id_Prod = " + this.idProdC.Text + "";
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
                    "','" + precio + "'," + Convert.ToInt64(unidades) + ", '"+v+"')";
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
                MessageBox.Show("ListaProd_"+ ex.Message);
            }
        }
        private void fCompra_Click(object sender, EventArgs e)
        {
            try
            {
                
                DialogResult dr = MessageBox.Show("¿FINALIZAR VENTA?", "Seleccionar", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        DialogResult dr2 = MessageBox.Show("¿IMPRIMIR FACTURA?", "Seleccionar", MessageBoxButtons.YesNo);
                        switch (dr2)
                        {
                            case DialogResult.Yes:
                                SeleccionImp("yes");
                                break;
                            case DialogResult.No:
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
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("fCompra_Click", ex.Message);
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
                        //con.Open();
                        string queryIdFac = "select MAX(Id_Factura) + 1 from Factura ";
                        SqlDataAdapter da = new SqlDataAdapter(queryIdFac, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var idFactura = dt.Rows[0].ItemArray[0].ToString();
                        var facturaN = idFactura.Equals("")  ? 0 + 1 : Convert.ToInt64(idFactura);
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
                            // PROD                     //PrECIO                                    CANT                         TOTAL
                            Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse((double.Parse((r.Cells[2].Value.ToString()), NumberStyles.Currency)).ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse((double.Parse((r.Cells[5].Value).ToString(), NumberStyles.Currency)).ToString())); //imprime una linea de descripcion
                        }
                        var totalComp = double.Parse(this.totalVenta.Text, NumberStyles.Currency);
                        var ivaComp = (totalComp / 1.19) * 0.19;
                        //DateTimeNow.Short.ToString
                        string fecha = DateTime.Now.ToShortDateString().ToString();
                        //
                        con.Open();
                        string queryFacRem = "INSERT INTO CARTERA VALUES (1,'" + totalComp.ToString() + "','" + fecha + "','" + facturaN.ToString() + "', '" + facturaN.ToString()+"')";
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
                        Ticket1.AgregaTotales("Efectivo Entregado:", double.Parse(this.cancelaCon.Text, NumberStyles.Currency));
                        Ticket1.AgregaTotales("Efectivo Devuelto:", double.Parse(this.cambioDe.Text, NumberStyles.Currency));
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
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("(2)FacturacionNit", ex.Message);
            }
        }
        private void ListaCompra()
        {
            try
            {
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
                string query = "select * from Lista_Compras where [# Venta] like '"+v+"'";

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
                MessageBox.Show("button1_Click", ex.Message);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void DatosCompra()
        {
            try
            {
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
                string query = "select sum(convert(decimal, Precio_Prod)) as total from Compras where [Num_Venta] like '"+v+"'";
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
                    if(dataGridView2 == null)
                    {
                        this.totalVenta.Text = "";
                    }
                    else
                    {
                        var st = double.Parse(itemArray.ToString());
                        var tv = (0.19 * st) + st;
                        this.totalVenta.Text = st.ToString("C");
                    }   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("DatosCompra", ex.Message);
            }
        }
        private void SeleccionImp(string a)
        {
            try
            {

                if (a.Equals("yes"))
                {
                    DialogResult dr = MessageBox.Show("¿FACTURA CON NIT?", "Seleccionar", MessageBoxButtons.YesNo);
                    switch (dr)
                    {
                        case DialogResult.Yes:
                            FacturacionNit();
                            break;
                        case DialogResult.No:
                            FacturacionRem();
                            break;
                        default: break;
                    }
                }
                else
                {
                    //DateTimeNow.Short.ToString
                    string fecha = DateTime.Now.ToShortDateString().ToString();
                    //Total Venta
                    int totalVenta= int.Parse(this.totalVenta.Text, NumberStyles.Currency);
                    //
                    con.Open();
                    string queryFacRem = "INSERT INTO CARTERA VALUES (6,'" + totalVenta.ToString() + "','" + fecha + "','0')";
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
                        v = "1";;
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
                string queryCompra = "select * from Lista_Compras where [# Venta] like  '"+v+"'";
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
                    string queryDeleteCompras = "delete from Compras where [Num_Venta] like '"+v+"'";
                    SqlCommand cmdDeleteCompras = new SqlCommand(queryDeleteCompras, con);
                    cmdDeleteCompras.ExecuteNonQuery();
                }
                con.Close();
                dataGridView2.DataSource = null;
                this.cambioDe.Text = "";
                this.cancelaCon.Text = "";
                this.totalVenta.Text = "";
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("SeleccionImp", ex.Message);
            }
            
        }
        private void FacturacionRem()
        {
            try
            {
                string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre del cliente","Datos de factura remisión");
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
                        string queryIdFac = "select MAX(Id_Factura) + 1 from Factura ";
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
                            // PROD                     //PrECIO                                    CANT                         TOTAL
                            Ticket1.AgregaArticulo(r.Cells[1].Value.ToString(), double.Parse((double.Parse((r.Cells[2].Value.ToString()), NumberStyles.Currency)).ToString()), int.Parse(r.Cells[3].Value.ToString()), double.Parse((double.Parse((r.Cells[5].Value).ToString(), NumberStyles.Currency)).ToString())); //imprime una linea de descripcion
                        }
                        var totalComp = double.Parse(this.totalVenta.Text, NumberStyles.Currency);
                        var ivaComp = (totalComp / 1.19) * 0.19;
                        //DateTimeNow.Short.ToString
                        string fecha = DateTime.Now.ToShortDateString().ToString();
                        //
                        con.Open();
                        string queryFacRem = "INSERT INTO CARTERA VALUES (2,'" + totalComp.ToString() + "','" + fecha + "','" + facturaN.ToString() +"')";
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
                string queryCompare = "Select * from bodega where Id_Prod = " + this.idProdC.Text;
                con.Open();
                SqlCommand cmd = new SqlCommand(queryCompare, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var existe = dt.Rows.Count;
                con.Close();
                var cantidad = Convert.ToInt64(this.canProd.Text);
                var result = existe - cantidad;
                var id = Convert.ToInt64(this.idProdC.Text);
                if (existe == 0)
                {
                    MessageBox.Show("No existen productos en bodega con este id:" + this.idProdC.Text);
                    return;
                }
                else
                {
                    if (result >= 0)
                    {
                        CantidadData(existe, cantidad, id, result);
                    }
                    else
                    {
                        MessageBox.Show("El numero maximo de articulos en bodega es: " + existe);
                        return;
                    }
                }     
            }
            catch(Exception ex)
            {
                MessageBox.Show("CompareExistente", ex.Message);
            }
            
        }
        private void CantidadData(int existe, long cantidad, long id, long result) //EXISTE lo que hay en data y CANTIDAD lo que se pone en el text
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
                            if (Convert.ToInt64(dataGridView2.Rows[i].Cells[0].Value) == id)
                            {
                                int lastRow = count - 1;
                                var cellCant = Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
                                var cellID = Convert.ToInt64(dataGridView2.Rows[i].Cells[0].Value);//error
                                var idText = Convert.ToInt64(this.idProdC.Text);

                                if (cellID == idText && cellCant < existe)
                                {
                                    VaidarDataGridView(lastRow, cellCant, cellID, idText);
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("La cantidad en bodega es: " + existe + " unidades");
                                    return;
                                }
                            }else if(k == dataGridView2.Rows.Count)
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
            catch(Exception ex)
            {
                MessageBox.Show("CantidadData", ex.Message);
            }
        }
        private void VaidarDataGridView(int lastRow, int cellCant, long cellID, long idText)
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
                var numero = dt.Rows.Count;
                con.Close();

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (Convert.ToInt64(dataGridView2.Rows[i].Cells[0].Value) == Convert.ToInt64(this.idProdC.Text))
                    {
                        var cant = Convert.ToInt32(dataGridView2.Rows[i].Cells[3].Value);
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
            catch(Exception ex)
            {
                MessageBox.Show("VaidarDataGridView ", ex.Message);
            }
        }

        private void ventaBut1_Click(object sender, EventArgs e)
        {
            try
            {
                ListaCompra();
            }catch(Exception ex)
            {
                MessageBox.Show("venta click" + ex.Message);
            }
        }
    }
}
