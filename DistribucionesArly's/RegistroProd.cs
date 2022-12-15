using System;
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
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Unidad' table. You can move, or remove it, as needed.
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                InsertarProd();
            }
        }
        private void InsertarProd()
        {
            try
            {
                string query = "INSERT INTO [dbo].[Producto] VALUES (" + Convert.ToInt16(this.idProd.Text) + ",'" + this.nomProd.Text + "'," + ((Convert.ToDouble(this.precioProd.Text) * 0.19) + Convert.ToDouble(this.precioProd.Text)) + "," + Convert.ToInt16(this.unidProd.SelectedValue) + ")";
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
