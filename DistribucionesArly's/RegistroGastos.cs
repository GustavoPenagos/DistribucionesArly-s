﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class RegistroGastos : Form
    {
        public RegistroGastos()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");

        private void guardarRegistro_Click(object sender, EventArgs e)
        {
            RegistroGasto();
        }

        private void RegistroGasto()
        {
            try
            {
                var valor = double.Parse(this.dineroGasto.Text.ToString()).ToString("C").Replace(",00","").Trim();
                string date = DateTime.Now.ToShortDateString();
                string query = "INSERT INTO [dbo].[Gastos] VALUES ('" + this.descriGasto.Text + "','" + valor + "','" + date + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                //DateTimeNow.Short.ToString
                string fecha = DateTime.Now.ToShortDateString().ToString();
                //
                string queryFacRem = "INSERT INTO CARTERA VALUES (3,'" + this.dineroGasto.Text + "','" + fecha + "','0','0', '0')";
                SqlCommand cmdFact = new SqlCommand(queryFacRem, con);
                cmdFact.ExecuteReader();
                MessageBox.Show("Registro de gastos exitoso");
                borrar();
            }
            catch (Exception )
            {
                MessageBox.Show("Campo vacio");
            }
            con.Close();
            
        }

        private void borrar()
        {
            try
            {
                this.dineroGasto.Text = "";
                this.descriGasto.Text = "";
                this.dineroGasto.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void descriGasto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    RegistroGasto();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dineroGasto_KeyPress(object sender, KeyPressEventArgs e)
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
    } 
}
