using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class ControlCaja : Form
    {
        public ControlCaja()
        {
            InitializeComponent();
            //
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Eliminar";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);
            //
            Capital();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");

        private void Capital()
        {
            try
            {
                string query = "select sum(convert(decimal, Valor_Cartera)) from Cartera where Id_Cartera = 6";
                con.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                this.tBCapital.Text = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]).ToString("C").Replace(",00", string.Empty);
                con.Close();
                Ventas();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("Capital" + ex.Message);
            }
        }

        private void Ventas()
        {
            try
            {
                string queryVenta = "select sum(convert(decimal, Valor_Cartera)) from Cartera where Id_Cartera = 1  or Id_Cartera = 2 or Id_Cartera = 5";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryVenta, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                var s = double.Parse(dt.Rows[0].ItemArray[0].ToString());
                this.tBVenta.Text = s.ToString("C").Replace(",00", string.Empty);
                con.Close();
                Gasto();

            }catch(Exception ex)
            {
                MessageBox.Show("Venta" + ex.Message);
            }
        }
        
        private void Gasto()
        {
            try
            {
                string queryVenta = "select sum(convert(decimal, Valor_Cartera)) from Cartera  where Id_Cartera = 3";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryVenta, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString().Equals(""))
                {
                    this.tBGasto.Text = 0.ToString("C").Replace(",00", string.Empty);
                }
                else
                {
                    var s = double.Parse(dt.Rows[0].ItemArray[0].ToString());
                    this.tBGasto.Text = s.ToString("C").Replace(",00", string.Empty);
                }
                con.Close();
                Facturas();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gasto" + ex.Message);
            }
        }
        
        private void Facturas()
        {
            try
            {
                string queryVenta = "select sum(convert(decimal, Valor_Cartera)) from Cartera  where Id_Cartera = 4";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryVenta, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows[0].ItemArray[0].ToString().Equals(""))
                {
                    this.tBTotalF.Text = 0.ToString("C").Replace(",00", string.Empty);
                }
                else
                {
                    var s = double.Parse(dt.Rows[0].ItemArray[0].ToString());
                    this.tBTotalF.Text = s.ToString("C").Replace(",00", string.Empty);
                }
                con.Close();
                Abono();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Gasto" + ex.Message);
            }
        }
        
        private void Abono()
        {
            try
            {
                string queryVenta = "select sum(CONVERT(decimal, Abono)) from Abono";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(queryVenta, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                
                var s = dt.Rows.Count == 1 ? 0 : double.Parse(dt.Rows[0].ItemArray[0].ToString());
                this.tBAbono.Text = s.ToString("C").Replace(",00", string.Empty);
                con.Close();
                Total();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abono" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string password = ""; string capital = ""; var sum = 0.00; var num = 0.00;int n = 0;
                var date = DateTime.Now.ToShortDateString();
                //
                string passw = "select (u.Password) from [User] as u where Id_User = 1006508619";
                con.Open();
                SqlDataAdapter adT = new SqlDataAdapter(passw, con);
                DataTable dtT = new DataTable();
                adT.Fill(dtT);
                var passW = dtT.Rows[0].ItemArray[0].ToString();
                con.Close();
                //
                password = Microsoft.VisualBasic.Interaction.InputBox("Contraseña", "Password");
                if (password.Equals(passW))
                {
                    double cont = 0.00; int r = 0;
                    while (cont <= 0 && r != 3)
                    {
                        capital = Microsoft.VisualBasic.Interaction.InputBox("Valor de capital", "Capital");
                        bool result = double.TryParse(capital.Trim(), out cont);
                        if (cont == 0)
                        {
                            MessageBox.Show("No es un valor valido");
                            r = r + 1;
                        }
                        else
                        {
                            r = r + 3;
                        }
                    }
                    capital = capital.Equals("") ? "0" : capital;
                    string queryCapital = "INSERT INTO Cartera values (6, '"+capital.Trim()+"', '"+date+"', '0', '0', '0')";
                    con.Open();
                    SqlCommand cmdCap = new SqlCommand(queryCapital, con);
                    cmdCap.ExecuteNonQuery();
                    con.Close();
                    //
                    string queryConsult = "SELECT * FROM Cartera where Id_Cartera = 6";
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryConsult, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    var count = dt.Rows.Count;
                    
                    if (count > 0)
                    {
                        for(int i=0;i <count; i++)
                        {
                            num = double.Parse(dt.Rows[i].ItemArray[2].ToString());
                            sum = sum + num;
                        }
                        this.tBCapital.Text = sum.ToString("C").Replace(",00", string.Empty);
                        con.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
                Total();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Button" + ex.Message);
            }
        }

        private void Total()
        {
            try
            {
                var capital = double.Parse(this.tBCapital.Text, NumberStyles.Currency);
                var ventas = double.Parse(this.tBVenta.Text, NumberStyles.Currency);
                var gastos = double.Parse(this.tBGasto.Text, NumberStyles.Currency);
                var abonos = double.Parse(this.tBAbono.Text, NumberStyles.Currency);

                var total = (capital+ventas)- (gastos-abonos);
                this.tBTotal.Text= total.ToString("C").Replace(",00", string.Empty);
                    
            }catch(Exception ex)
            {
                MessageBox.Show("Total" + ex.Message);
            }
        }

        private void ListaCapital_Click(object sender, EventArgs e)
        {

            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
            this.label7.Visible = false;
            //
            this.tBAbono.Visible = false;
            this.tBCapital.Visible= false;
            this.tBGasto.Visible= false;
            this.tBTotal.Visible= false;
            this.tBTotalF.Visible= false;
            this.tBVenta.Visible= false;
            //
            dataGridView1.Visible = true;
            dataGridView1.Dock= DockStyle.Fill;
            //
            this.button2.Visible = true;
            this.ListaCapital.Visible = false;
            this.button1.Visible = false;
            Listar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ListaCapital.Visible  =true;
            this.button2.Visible = false;
            this.button1.Visible = true;
            //  
            this.label2.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
            this.label5.Visible = true;
            this.label6.Visible = true;
            this.label7.Visible = true;
            //
            this.tBAbono.Visible = true;
            this.tBCapital.Visible = true;
            this.tBGasto.Visible = true;
            this.tBTotal.Visible = true;
            this.tBTotalF.Visible = true;
            this.tBVenta.Visible = true;
            //
            dataGridView1.Visible = false;
        }

        private void Listar()
        {
            try
            {
                string query = "select tc.Tipo_Cartera as 'Tipo de registro'" +
                    ",FORMAT(CONVERT(decimal, c.Valor_Cartera), 'C', 'es-CO') as 'Valor ingreso' " +
                    ", c.Fecha as 'Fecha de ingreso'" +
                    "from Cartera as c " +
                    "inner join Tipo_Cartera as tc on (tc.Id_Cartera = c.Id_Cartera)" +
                    "where c.Id_Cartera = 6";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource= dt;
            }catch(Exception ex)
            {
                MessageBox.Show("Listar "+ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string passw = "select (u.Password) from [User] as u where Id_User = 1006508619";
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(passw, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                var passW = dt.Rows[0].ItemArray[0].ToString();
                con.Close();
                string password = Microsoft.VisualBasic.Interaction.InputBox("CONTRASEÑA DE ADMINISTRADOR", "Prohibido el acceso");
                if (password.Equals(passW))
                {
                    int ind = Convert.ToInt32(e.RowIndex.ToString());
                    string row = dataGridView1.Rows[ind].Cells["Valor ingreso"].Value.ToString();
                    double valor = double.Parse(row, NumberStyles.Currency);
                    Eliminar(valor);
                    Listar();
                }
                else
                {

                    MessageBox.Show("Contraseña Incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void Eliminar(double valor)
        {
            try
            {
                string query = "delete from Cartera where Id_Cartera = " + 6 + " and Valor_Cartera = '" + valor + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Eliminar" + ex.Message); ;
            }
        }
    }
}
