using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class ControlFacturas : Form
    {
        public ControlFacturas()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void buscarFact_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void Buscar()
        {
            try
            {
                var seleccion = this.selecBus.Text.Trim().Equals("Factura de venta") ? "Factura" : "FacturaRem";
                var cBarras = Convert.ToInt64(this.buscaID.Text.Trim());
                switch (seleccion)
                {
                    case ("Factura"):
                        Mostrar(seleccion, cBarras);
                        break;
                    case ("FacturaRem"):
                        Mostrar(seleccion, cBarras);
                        break;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Buscar" +ex.Message);
            }
        }
        private void Mostrar(string factura, long barras)
        {
            try
            {
                string queryBusca = "SELECT * FROM " + factura.ToString() + " WHERE Id_Factura = " + barras;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryBusca, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var codeB64 = dt.Rows[0].ItemArray[1].ToString();
                var B64ToByte = Convert.FromBase64String(codeB64);
                var a = System.Text.Encoding.UTF8.GetString(B64ToByte);
                con.Close();
                this.multiFact.Text = a;
                
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("Mostar" + ex.Message);
            }
        }
        private void Clean()
        {
            try
            {
                this.buscaID.Clear();
                this.multiFact.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void selecBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.buscaID.Clear();
                this.multiFact.Clear();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
