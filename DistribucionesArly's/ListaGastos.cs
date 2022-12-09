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
    public partial class ListaGastos : Form
    {
        public ListaGastos()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void ListaGastos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Lista_Gastos' table. You can move, or remove it, as needed.
            this.lista_GastosTableAdapter.Fill(this.distribucionesArlysDataSet.Lista_Gastos);
            this.gastosTableAdapter.Fill(this.distribucionesArlysDataSet.Gastos);
            try
            {
                string query = "select sum(Valor_Gasto) as gasto from Lista_Gastos";
                con.Open();
                //SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter(query, con);
                ad.Fill(dt);
                con.Close();
                this.textBoxTG.Text = dt.Rows[0].ItemArray[0].ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void BuscarGasto_Click(object sender, EventArgs e)
        {
            Validar();
            BuscarGastos();
        }
        private void BuscarGastos()
        {
            try
            {
                string query = "SELECT * FROM Lista_Gastos where [Fecha_Gasto] like '%" + this.bGasto.Text + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No existe gastos en esta fecha (" + this.bGasto.Text + ")");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bGasto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BuscarGastos();
            }
        }
        private void Validar()
        {
            try
            {
                if (this.bGasto.Text == "")
                {
                    MessageBox.Show("Campo vacio");
                }
                else
                {
                    BuscarGastos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
