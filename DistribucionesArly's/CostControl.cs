using DocumentFormat.OpenXml.Spreadsheet;
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
                string query = "select * from Lista_Ventas";
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
                    this.totalCartera.Text = suma.ToString("C").Replace(",00", "").Trim();
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
                selectCartera_SelectedIndexChanged(sender, e);
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
                if (selectCartera.Text.Equals("Fecha de venta") || selectCartera.Text.Equals("Venta sin factura"))
                {
                    dateCartera.Visible = true;
                    dateFin.Visible = true;
                    tBoxBusca.Visible = false;
                }
                else
                {
                    dateCartera.Visible = false;
                    dateFin.Visible = false;
                    tBoxBusca.Visible = true;
                }
                string selecBox = selectCartera.Text;
                var date1 = dateCartera.Value.ToString("yyyy-d-MM");
                var date2 = dateFin.Value.ToString("yyyy-d-MM");
                switch (selecBox)
                {
                    case ("Factura Nit"):
                        selecBox = "[Tipo de venta] = 'Factura con Nit' and [Factura] = "+ this.tBoxBusca.Text;
                        BuscarCartera(selecBox);
                        break;
                    case ("Remision"):
                        selecBox = "[Tipo de venta] = 'Remision' and [Factura] = "+ this.tBoxBusca.Text;
                        BuscarCartera(selecBox);
                        break;
                    case ("Venta sin factura"):
                        selecBox = "[Tipo de venta] = 'Venta sin factura' and [Fecha de venta] between convert(date, '"+date1+"') and  convert(date, '"+date2+ "')";
                        BuscarCartera(selecBox);
                        break;
                    case ("Fecha de venta"):
                        selecBox = "[Fecha de venta] between convert(date, '"+date1+"') and  convert(date, '"+date2+"')";
                        BuscarCartera(selecBox);
                        break;
                }
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("selectCartera_SelectedIndexChanged", ex.Message);
            }   
        }
        private void BuscarCartera(string selecBox)
        {
            try
            {
                string querySWhere = "";
                if (this.tBoxBusca.Text.Equals("") && dateCartera.Visible == false)
                {
                    querySWhere = "select * from Lista_Ventas";
                }
                else
                {
                    querySWhere = "select * from Lista_Ventas WHERE " + selecBox;
                }
                
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
                        var Cart = double.Parse(dt.Rows[i].ItemArray[2].ToString(), NumberStyles.Currency);
                        var totalCart = Convert.ToDouble(Cart);
                        suma = suma + totalCart;
                    }
                    this.totalCartera.Text = suma.ToString("C").Replace(",00", string.Empty);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("BuscarCartera", ex.Message);
            }
        }

        private void selectCartera_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                

            }catch(Exception ex)
            {
                MessageBox.Show("Select" + ex.Message);
            }
        }

        private void impVentas_Click(object sender, EventArgs e)
        {
            try
            {
                string queryImp = "";
                var swt = this.selectCartera.Text;
                switch (swt)
                {
                    case "Factura Nit":
                        queryImp = "select * from cartera where Id_Cartera = 1";
                        break;
                    case "Remision":
                        queryImp = "select * from cartera where Id_Cartera = 2";
                        break;
                    case "Venta sin factura":
                        queryImp = "select * from cartera where Id_Cartera = 5";
                        break;
                }
                SqlDataAdapter da = new SqlDataAdapter(queryImp, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
