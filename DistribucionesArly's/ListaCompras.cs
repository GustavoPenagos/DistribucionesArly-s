using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class ListaCompras : Form
    {
        public ListaCompras()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void buscarFactura_Click(object sender, EventArgs e)
        {
            BuscarFactura();
        }
        private void BuscarFactura()
        {
            try
            {
                var nFactura = this.bFCompra.Text;
                var resul = 0.00;
                con.Open();
                //CARTERA
                string queryTotal = "select * from Cartera where Factura like '" + nFactura.ToString() + "'";
                SqlCommand cmd = new SqlCommand(queryTotal, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var valorF = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
                //ABONO
                string queryAbono = "select sum(convert(decimal, abono)) from Abono where Id_Factura = '" + nFactura.ToString() + "'";
                SqlCommand cmdA = new SqlCommand(queryAbono, con);
                SqlDataReader drA = cmdA.ExecuteReader();
                DataTable dtA = new DataTable();
                dtA.Load(drA);
                //CONTAR ABONO
                string queryCAbono = "select  abono from Abono where Id_Factura = '" + nFactura.ToString() + "'";
                SqlCommand cmdCA = new SqlCommand(queryCAbono, con);
                SqlDataReader drCA = cmdCA.ExecuteReader();
                DataTable dtCA = new DataTable();
                dtCA.Load(drCA);
                if (dtCA.Rows.Count == 0)
                {
                    resul = valorF;
                }
                else
                {
                   var valorA = Convert.ToDouble(dtA.Rows[0].ItemArray[0].ToString()); 
                   resul = valorF - valorA;
                }
                
                //
                MostrarImg();
                con.Close();
                this.totalFact.Text = resul.ToString("C").Replace(",00", string.Empty);
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void bFCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void insertAbono_Click(object sender, EventArgs e)
        {
            try
            {
                var total = double.Parse(totalFact.Text, NumberStyles.Currency);
                if(total == 0) 
                {
                    MessageBox.Show("La factura esta en saldo 0");
                    return;
                }
                var nFactura = Convert.ToInt64(this.bFCompra.Text.ToString());
                string queryCartera = "select * from Cartera where Factura like '"+nFactura.ToString()+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(queryCartera, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var valorFactura = dt.Rows[0].ItemArray[2].ToString();

                var date = DateTime.Now.ToShortDateString().ToString();
                var abono = Convert.ToInt64(this.abonoFact.Text);
                
                var resultado = total - abono;
                if (resultado <0)
                {
                    con.Close();
                    MessageBox.Show("Ese valor es mayor al valor por pagar");
                    return;
                }
                else
                {
                    string queryAbono = "INSERT INTO Abono VALUES(" + nFactura + ",'" + valorFactura + "','" + abono.ToString() + "','" + date + "')";
                    SqlCommand cmdInsert = new SqlCommand(queryAbono, con);
                    cmdInsert.ExecuteNonQuery();
                    //
                    MessageBox.Show("Se ha guardado el abono a la factura "+ nFactura);
                    Borrar(resultado);
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void MostrarImg()
        {
            try
            {
                string queryImg = "select * from FacturaCompras where Id_Factura = "+ bFCompra.Text.ToString();
                //con.Open();
                SqlCommand cmdImg = new SqlCommand(queryImg, con);
                SqlDataReader drImg = cmdImg.ExecuteReader();
                DataTable dtImg = new DataTable();
                dtImg.Load(drImg);
                var imgBase64 = dtImg.Rows[0].ItemArray[1].ToString();
                //con.Close();
                byte[] imageBytes = Convert.FromBase64String(imgBase64);
                // Convert byte[] to Image
                using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    Image image = Image.FromStream(ms, true);
                    imgFactura.Image = image;
                    imgFactura.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Borrar(double resultado)
        {
            try
            {
                totalFact.Text = resultado.ToString("C").Replace(",00", string.Empty);
                abonoFact.Clear();
                bFCompra.Clear();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
