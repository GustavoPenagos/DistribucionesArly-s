using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class CostControl : Form
    {
        public CostControl()
        {
            InitializeComponent();
            CostContol_Load();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void CostContol_Load()
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Lista_Cartera";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                double suma = 0;
                if (dataGridView1.Rows.Count != 0)
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        var Cart = double.Parse(dt.Rows[i].ItemArray[2].ToString(), NumberStyles.Currency);
                        suma = suma + Cart;
                    }
                    this.totalCartera.Text = suma.ToString("C");
                }
                con.Close();
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("CostControl_Load", ex.Message);
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCartera();
            }
            catch(Exception ex)
            {
                con.Close();
                MessageBox.Show("buttonBuscar_Click", ex.Message);
            }
            
        }

        private void selectCartera_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarCartera();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("selectCartera_SelectedIndexChanged", ex.Message);
            }   
        }
        private void BuscarCartera()
        {
            try
            {
                string selecBox = selectCartera.Text;
                string fecha = dateCartera.Value.ToString("d/MM/yyyy");
                string querySWhere = "SELECT * FROM Lista_Cartera WHERE [Tipo venta] LIKE '" + selecBox + "' AND [Fecha venta] like '" + fecha + "'";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(querySWhere, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
                double suma = 0;
                if (dataGridView1.Rows.Count != 0)
                {
                    for (int i = 0 ; i < dataGridView1.Rows.Count ; i++)
                    {
                        var Cart = double.Parse(dt.Rows[i].ItemArray[1].ToString(), NumberStyles.Currency);
                        var totalCart = Convert.ToDouble(Cart);
                        suma = suma + totalCart;
                    }
                    this.totalCartera.Text = suma.ToString("C");
                }

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("BuscarCartera", ex.Message);
            }
        }
    }
}
