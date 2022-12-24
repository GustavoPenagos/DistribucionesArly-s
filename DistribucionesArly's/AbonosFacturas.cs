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
    public partial class AbonosFacturas : Form
    {
        public AbonosFacturas()
        {
            InitializeComponent();
            ListaAbonos();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void buscarFactura_Click(object sender, EventArgs e)
        {

        }
        private void ListaAbonos()
        {
            try
            {
                string queryAbonos = "select * from Abono"; //crear view Lista_Abonos
                con.Open();
                SqlCommand cmd = new SqlCommand(queryAbonos, con);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                dataGridView1.DataSource= dt;
                con.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("ListaAbonos"+ex.Message);
            }
        }
    }
}
