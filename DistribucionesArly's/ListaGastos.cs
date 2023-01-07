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
                //
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "Eliminar";
                btn.Text = "Eliminar";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(btn);
                //
                ListaGasto();
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
                var sum = 0.00;
                string query1 = "select * from Lista_Gastos";
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query1, con);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                con.Close();
                //
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    var val = double.Parse(dataTable.Rows[i].ItemArray[2].ToString(), NumberStyles.Currency);
                    sum = sum + val;
                }
                
                //
                this.textBoxTG.Text = sum.ToString("C").Replace(",00","").Trim();



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
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
                        long row = Convert.ToInt64(dataGridView1.Rows[ind].Cells["ID"].Value.ToString());
                        Eliminar(row);
                        ListaGasto();
                    }
                    else
                    {

                        MessageBox.Show("Contraseña Incorrecta", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datagridview2" + ex.Message);
            }
        }

        private void Eliminar(long row)
        {
            try
            {
                string query = "delete from Gastos where Id_Gasto = " + row;
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
