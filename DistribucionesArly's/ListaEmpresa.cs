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
    public partial class ListaEmpresa : Form
    {
        public ListaEmpresa()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");

        private void ListaEmpresa_Load(object sender, EventArgs e)
        {
            ListEmpresa();
        }

        private void bNomEmp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Validar();
            }
        }
        private void BuscarEmpresa()
        {
            try
            {
                string query = " select * from Lista_Emp where Nombre_Empresa like '%" + this.bNomEmp.Text + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe un registro con este numero");
                }
                con.Close();
                
                //Borrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Borrar()
        {
            this.bNomEmp.Text = "";
        }

        private void buscarEmp_Click(object sender, EventArgs e)
        {
            Validar();
            BuscarEmpresa();
        }
        private void Validar()
        {
            try
            {
                if (this.bNomEmp.Text == "")
                {
                    MessageBox.Show("Campo vacio");
                }
                else
                {
                    BuscarEmpresa();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void ListEmpresa()
        {
            try
            {
                string query = "select * from Lista_Emp";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
