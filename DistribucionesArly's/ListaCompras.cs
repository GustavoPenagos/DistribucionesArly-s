using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
                imgFactura.Image = Image.FromFile(@"C:\Users\kmtav\OneDrive\Documentos\Facturas\" + nFactura.ToString() + ".jpg");
                imgFactura.SizeMode = PictureBoxSizeMode.StretchImage;
                string queryTotal = "select * from Cartera where Factura like '" + nFactura.ToString() + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(queryTotal, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var valor = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
                con.Close();
                this.totalFact.Text = valor.ToString();
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
                var nFactura = Convert.ToInt64(this.bFCompra.Text.ToString());
                string queryCartera = "select * from Cartera where Factura like '"+nFactura.ToString()+"'";
                con.Open();
                SqlCommand cmd = new SqlCommand(queryCartera, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                var valorFactura = dt.Rows[0].ItemArray[2].ToString();
                
                var date = DateTime.Now.ToShortDateString().ToString();
                var abono = this.abonoFact.Text.ToString();
                string queryAbono = "INSERT INTO Abono VALUES("+nFactura+ ",'"+ valorFactura + "','"+abono+"','"+date+"')";
                SqlCommand cmdInsert = new SqlCommand(queryAbono, con);
                cmdInsert.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
