﻿using System;
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
    public partial class RegistroProd : Form
    {
        public RegistroProd()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void RegistroProd_Load(object sender, EventArgs e)
        {
            this.unidadTableAdapter.Fill(this.distribucionesArlysDataSet.Unidad);

        }
        private void guardarProd_Click(object sender, EventArgs e)
        {
            InsertarProd();
        }
        public void borrar()
        {
            try
            {
                this.idProd.Text = "";
                this.nomProd.Text = "";
                this.precioProd.Text = "";
                
            }catch(Exception ex)
            {
                MessageBox.Show(""+ex);
            }           

        }
        private void precioProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    InsertarProd();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InsertarProd()
        {
            try
            {
                double util = Convert.ToDouble(this.utilidad.Text);
                double precProd = Convert.ToDouble(this.precioProd.Text);
                double precVenta = ((util/100) + 1) * precProd;
                string query = "INSERT INTO Producto VALUES (" + Convert.ToInt64(this.idProd.Text) + ",'" + this.nomProd.Text + "'," + Convert.ToDouble(this.precioProd.Text) + "," + Convert.ToInt64(this.unidProd.SelectedValue) + ", '"+this.marcaProd.Text+"','" + this.utilidad.Text + "','" + precVenta + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has saved in database");
                borrar();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Data hasn't save in database" + ex);
            }
        }
        private void idProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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

        private void utilidad_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
