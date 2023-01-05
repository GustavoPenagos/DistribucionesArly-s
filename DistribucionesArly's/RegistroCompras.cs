using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistribucionesArly_s
{
    public partial class RegistroCompras : Form
    {
        public RegistroCompras()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        private void CargarImg_Click(object sender, EventArgs e)
        {
            try
            {

                OpenFileDialog abrirImg = new OpenFileDialog();

                if (abrirImg.ShowDialog() == DialogResult.OK)
                {
                    ImgFact.ImageLocation = abrirImg.FileName;
                    ImgFact.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                this.GuardarFact.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("CargarImg" + ex.Message);
            }
        }
        private void GuardarFact_Click(object sender, EventArgs e)
        {
            GuardarData();
        }
        private void GuardarData()
        {
            try
            {
                var nFactura = this.numFact.Text;
                var valorFac = this.valorFact.Text;
                var img = this.ImgFact.Image;
                var date = this.dateFact.Value.ToString("d/MM/yyyy");
                var dateLimi = this.dateLimite.Value.ToString("d/MM/yyyy");

                if (nFactura.Equals("") || valorFac.Equals("") || img == null)
                {
                    MessageBox.Show("Llene todos los campos");
                    return;
                }
                byte[] bytes = (byte[])(new ImageConverter()).ConvertTo(img, typeof(byte[]));
                var base64Img = System.Convert.ToBase64String(bytes).ToString();
                string queryImgCompra = "INSERT INTO Cartera VALUES(4,'" + valorFac + "','" + date + "','" + nFactura + "', '"+dateLimi+"')";
                string queryInsertImg = "INSERT INTO FacturaCompras VALUES (" + Convert.ToInt64(nFactura) + ",'" + base64Img + "')";
                con.Open();
                SqlCommand cmdImgCompra = new SqlCommand(queryImgCompra, con);
                cmdImgCompra.ExecuteNonQuery();
                SqlCommand cmdInsertImg = new SqlCommand(queryInsertImg, con);
                cmdInsertImg.ExecuteNonQuery();
                con.Close();
                string queryAbonoP = "INSERT INTO Abono VALUES ("+nFactura+", '"+valorFac+"', '0', "+date+")";
                con.Open();
                SqlCommand cmdAP = new SqlCommand(queryAbonoP, con);
                cmdAP.ExecuteNonQuery();
                con.Close();
                Clean();
            }
            catch (Exception ex)
            {
                con.Close();
                MessageBox.Show("GuardarImg" + ex.Message);
            }
        }

        private void numFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (e.KeyChar == Convert.ToChar(Keys.Enter))
                {
                    valorFact.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void valorFact_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Clean()
        {
            try
            {
                this.numFact.Clear();
                this.ImgFact.Image= null;
                this.valorFact.Clear();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
