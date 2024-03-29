﻿using System;
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
            try
            {
                var cantidad = Convert.ToInt32(this.cantidadProd.Text);
                ConteoProd(cantidad);
                InsertarBodega();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void borrar()
        {
            try
            {
                this.idProdRegis.Text = "";
                this.cantidadProd.Text = "1";
                this.idProdRegis.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void InsertarBodega()
        {
            try
            {
                string queryConsult = "select Id_Prod from Producto where Id_Prod =" + Convert.ToInt64(this.idProdRegis.Text);
                con.Open();
                SqlCommand cmdConsul = new SqlCommand(queryConsult, con);
                SqlDataReader dr = cmdConsul.ExecuteReader();
                
                var cantidadProd = Convert.ToInt32(this.cantidadProd.Text);
                int sum=0; 
                if (dr.Read())
                {
                    con.Close();
                    //
                    string queryVal = "Select * from Bodega";
                    con.Open();
                    SqlDataAdapter ad = new SqlDataAdapter(queryVal, con);
                    DataTable data = new DataTable();
                    ad.Fill(data);
                    //
                   
                    for(int i = 0; i < data.Rows.Count; i++)
                    {
                        var idProd = data.Rows[i].ItemArray[1].ToString();

                        if (idProd == this.idProdRegis.Text)
                        {
                            var cantidad = Convert.ToDouble(data.Rows[i].ItemArray[2].ToString());
                            var total = cantidadProd + cantidad;
                            string queryInsert = "update Bodega set cantidad = "+total+" where Id_Prod = " + this.idProdRegis.Text;
                            SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                            cmdInsert.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Se ha ingresado el producto correctamente");
                            return;

                        }
                        sum = 1 + sum;
                    } 
                    if(sum == data.Rows.Count)
                    {
                        string queryInsert = "insert into Bodega values (" + Convert.ToInt64(this.idProdRegis.Text) + ", '" + cantidadProd + "')";
                        //con.Open();
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, con);
                        cmdInsert.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Se ha ingresado el producto correctamente");
                    }
                    
                }
                else
                {
                    con.Close();
                    MessageBox.Show("No existe este ID (" + this.idProdRegis.Text + ")");
                }

                borrar();
            }
            catch (Exception)
            {
                con.Close();
                MessageBox.Show("Numero ID_producto no valido (" + this.idProdRegis.Text + ")");
                borrar();
            }
        }
        private void cantidadProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
            
        }
        public void ConteoProd(int a)
        {
            try
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
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
