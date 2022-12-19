using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace DistribucionesArly_s
{
    public partial class RegistroUsuarios : Form
    {
        public RegistroUsuarios()
        {
            InitializeComponent();
        }
        
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
       
        private void RegistroProveedor_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.distribucionesArlysDataSet.User);
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Tipo_Usuario' table. You can move, or remove it, as needed.
            this.tipo_UsuarioTableAdapter.Fill(this.distribucionesArlysDataSet.Tipo_Usuario);
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.distribucionesArlysDataSet.Company);
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Tipo_Documento' table. You can move, or remove it, as needed.
            this.tipo_DocumentoTableAdapter.Fill(this.distribucionesArlysDataSet.Tipo_Documento);
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Company' table. You can move, or remove it, as needed.
            this.companyTableAdapter.Fill(this.distribucionesArlysDataSet.Company);
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Tipo_Documento' table. You can move, or remove it, as needed.
            this.tipo_DocumentoTableAdapter.Fill(this.distribucionesArlysDataSet.Tipo_Documento);
        }
        private void guardarUsuario_Click(object sender, EventArgs e)
        {
            InsertarUser();
        }
        public void borrar()
        {
            try
            {
                this.nombreUsuario.Text = "";
                this.telefonoUsuario.Text = "";
                this.numeroDocumento.Text = "";
                this.direcUsuario.Text = "";
                this.contrUser.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void direcUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    InsertarUser();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   
        }
        private void InsertarUser()
        {
            try
            {
                string query = "INSERT INTO [dbo].[User] VALUES (" + Convert.ToInt64(this.numeroDocumento.Text) + ",'" + this.nombreUsuario.Text + "','" + telefonoUsuario.Text +
                    "','" + this.direcUsuario.Text + "'," + Convert.ToInt16(this.nitEmpresa.SelectedValue) + "," + Convert.ToInt16(this.tipoUsuario.SelectedValue) + "," +
                    "" + Convert.ToInt16(this.tipo_Documento.SelectedValue) + ",'" + this.contrUser.Text + "','"+this.eMail.Text+"')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has saved in database");
                borrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data hasn't save in database", ex.Message);
                con.Close();
            }
        }
        private void numeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    nombreUsuario.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    contrUser.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void contrUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    tipoUsuario.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tipoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    nitEmpresa.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void nitEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    telefonoUsuario.Focus();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void telefonoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    direcUsuario.Focus();
                }
            }
            catch(Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
            
        }
        private void tipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tipoUsuario.Text == "Cliente" || tipoUsuario.Text == "Proveedor")
                {
                    this.contrUser.Enabled = false;
                }
                else
                {
                    this.contrUser.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
