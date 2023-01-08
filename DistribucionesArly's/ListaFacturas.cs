using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class ListaFacturas : Form
    {
        public ListaFacturas()
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
            ListarFacturas();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var select = this.boxSelect.Text;
                var valor = this.boxBuscar.Visible == false ? dateFact.Value.ToString("d/MM/yyy") : this.boxBuscar.Text;
                string complemento = "";
                switch (select){
                    case "Numero factura":
                        select = "[N° Factura]";
                        complemento = "=";
                        ListarBuscar(select, valor, complemento);
                        break;
                    case "Fecha recibido":
                        select = "[Fecha recibido]";
                        complemento = "like";
                        ListarBuscar(select, valor, complemento);
                        break;
                    case "Fecha vence":
                        select = "[Fecha vence]";
                        complemento = "like";
                        ListarBuscar(select, valor, complemento);
                        break;

                    default: break;

                }
                    

            }catch(Exception ex)
            {
                MessageBox.Show("ButtonBuscar" +ex.Message);
            }
        }

        private void ListarFacturas()
        {
            try
            {
                string query = "select * from Lista_Cartera";
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ListarFacturas" + ex.Message);
            }
        }

        private void ListarBuscar(string select, string valor, string complemento)
        {
            try
            {
                string query = "";
                if (complemento.Equals("like"))
                {
                    query = "select * from Lista_Cartera where " + select + " like '" + valor + "'";
                }
                else
                {
                    query = "select * from Lista_Cartera where " + select + " = " + valor ;
                }
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show("ListarBuscar" + ex.Message);
            }
        }

        private void boxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boxSelect.Text.Equals("Numero factura"))
            {
                this.boxBuscar.Visible = true;
                this.dateFact.Visible = false;
            }
            else if (boxSelect.Text.Equals("Fecha recibido") || boxSelect.Text.Equals("Fecha vence"))
            {
                this.boxBuscar.Visible = false;
                this.dateFact.Visible = true;
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
                        long row = Convert.ToInt64(dataGridView1.Rows[ind].Cells["N° Factura"].Value.ToString());
                        Eliminar(row);
                        ListarFacturas();
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
                string query = "delete from Cartera where Factura = " + row;
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
