using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DistribucionesArly_s
{
    public partial class RegistroBodega : Form
    {
        public RegistroBodega()
        {
            InitializeComponent();
            this.idProdRegis.Focus();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            var cantidad = Convert.ToInt32(this.cantidadProd.Text);
            ConteoProd(cantidad);
            InsertarBodega();
        }
        private void borrar()
        {
            this.idProdRegis.Text = "";
            this.cantidadProd.Text = "1";
            this.idProdRegis.Focus();
        }
        private void InsertarBodega()
        {
            try
            {
                string queryConsult = "select Id_Prod from Producto where Id_Prod =" + Convert.ToInt16(this.idProdRegis.Text);
                con.Open();
                SqlCommand cmdConsul = new SqlCommand(queryConsult, con);
                SqlDataReader dr = cmdConsul.ExecuteReader();
                
                var cantidadProd = Convert.ToInt32(this.cantidadProd.Text);
                if (dr.Read())
                {
                    con.Close();
                    con.Open();
                    for (int i = 0; i < cantidadProd; i++)
                    {
                        
                        string queryInsert = "insert into Bodega values (" + Convert.ToInt16(this.idProdRegis.Text) + ")";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                        cmdInsert.ExecuteNonQuery();
                        
                    }
                    MessageBox.Show("Se ha ingresado el producto correctamente");
                    con.Close();
                }
                else
                {
                    MessageBox.Show("No existe este ID (" + this.idProdRegis.Text + ")");
                    con.Close();
                }

                borrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Numero ID_producto no valido (" + this.idProdRegis.Text + ")");
                borrar();
            }
        }

        private void cantidadProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar.Equals('\b'))
            {
                this.cantProdBod.Text = "";
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                var cantidad = Convert.ToInt32(this.cantidadProd.Text);
                InsertarBodega();
                ConteoProd(cantidad);
            } 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void idProdRegis_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    this.cantidadProd.Focus();
                }
                else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            
        }
        
        public void ConteoProd(int a)
        {
            string queryCantidad = "SELECT COUNT(b.Id_Prod) AS Cantidad " +
                    "FROM dbo.Producto AS p " +
                    "INNER JOIN dbo.Bodega AS b ON b.Id_Prod = p.Id_Prod " +
                    "where p.Id_Prod = " + this.idProdRegis.Text + "";
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(queryCantidad, con);
            ad.Fill(dt);
            con.Close();
            this.cantProdBod.Text = (Convert.ToInt64(dt.Rows[0].ItemArray[0]) + a).ToString();
        }
    }
}
