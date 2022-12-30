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
            if(empComBox.Text.Equals("Nombre") || empComBox.Text.Equals("Ciudad"))
            {
                if (!char.IsControl(e.KeyChar) && char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else if(empComBox.Text.Equals("Nit"))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }  
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Validar();
            }
        }
        private void BuscarEmpresa()
        {
            try
            {
                var buscar = empComBox.Text;
                var id = this.bNomEmp.Text;
                switch (buscar)
                {
                    case ("Nit"):
                        buscar = "where Nit = "+ id;
                        ComboBoxEmp(buscar);
                        break;
                    case ("Nombre"):
                        buscar = "where Nombre like '%" + id + "%'";
                        ComboBoxEmp(buscar);
                        break;
                    case ("Productos"):
                        buscar = "where Información like '%" + id + "%'";
                        ComboBoxEmp(buscar);
                        break;
                    case ("Ciudad"):
                        buscar = "where Ciudad like '%" + id + "%'";
                        ComboBoxEmp(buscar);
                        break;
                }
                
                
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
        private void ComboBoxEmp(string buscar)
        {
            try
            {
                string query = " select * from Lista_Emp " + buscar;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("No existe un registro con este dato");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("ComboBoxEmp" + ex.Message);
            }
        }

        private void empComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.bNomEmp.Clear();
        }
    }
}
