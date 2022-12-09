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
    public partial class RegistraEmpresa : Form
    {
        public RegistraEmpresa()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        

        private void RegistraEmpresa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'distribucionesArlysDataSet.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.distribucionesArlysDataSet.Department);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void selectDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT  Municipality, Id_Municipality " +
                    "FROM Municipality " +
                    "inner join Department on(Municipality.Id_Department = Department.Id_Department) " +
                    "where Municipality.Id_Department =" + this.selectDepart.SelectedValue;
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(query,con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DataRow dr = dt.NewRow();

                this.selectCiudad.ValueMember = "Id_Municipality";
                this.selectCiudad.DisplayMember = "Municipality";
                this.selectCiudad.DataSource = dt;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void GuardarEmp_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                string query = "INSERT INTO [Company] VALUES (" + this.NiEmp.Text + ",'" + this.nomEmp.Text + "','" + this.proEmp.Text + "','" + this.dirEmp.Text +"','"+this.telEmp.Text + "'," + this.selectDepart.SelectedValue + "," + this.selectCiudad.SelectedValue + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data has saved in database");
                con.Close();
                //Borrar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Borrar()
        {
            this.NiEmp.Text = "";
            this.nomEmp .Text = "";
            this.proEmp.Text = "";
            this.dirEmp.Text = "";
            this.telEmp.Text = "";
            //this.selectDepart 
            //this.selectCiudad.ValueMember 
        }
    }
}
