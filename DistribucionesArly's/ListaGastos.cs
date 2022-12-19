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
            ListaGasto();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void ListaGastos_Load(object sender, EventArgs e)
        { 
            try
            {
                ListaGasto();
                string query = "select format(sum(convert(decimal,Valor_Gasto)), 'C', 'es-co') AS Valor_Gasto from Lista_Gastos";
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
                var date = dateGasto.Value.ToString("d/MM/yyyy");

                string query = "SELECT * FROM Lista_Gastos where [Fecha_Gasto] like '%" + date + "%'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource = dt;
                con.Close();
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No existe gastos en esta fecha (" + date + ")");
                }
            }
            catch(Exception ex)
            {
                con.Close();
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
                var date = dateGasto.Value.ToString("dd/MM/yyyy");
                if (date == "")
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
        private void ListaGasto()
        {
            try
            {
                string query1 = "SELECT Id_Gasto AS ID, Desc_Gastos AS Descripcion, format(convert(decimal,Costo_Gasto),'C','es-CO') AS Valor_Gasto, Fecha_Gasto\r\nFROM dbo.Gastos";
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
