using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class Validacion : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        public Validacion()
        {
            InitializeComponent();
        }

        private void validarPass_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Validar();
            }
        }
        private void Validar()
        {
            string query = "select [Password] from [User] where [Password] like '" + this.password.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            if (dt.Rows.Count > 0)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Contraseña invalida (" + this.password.Text + ")");
            }
            con.Close();
        }
    }
}
