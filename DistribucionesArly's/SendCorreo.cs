using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Management.Instrumentation;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace DistribucionesArly_s
{
    internal class SendCorreo
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-VNGF9BS;Initial Catalog=DistribucionesArlys;Integrated Security=True;");
        //pendiente cambiar ruta de FACTURAS
        public void SendMail(string factura)
        {
            try
            {
                string path = @"C:\\Users\\kmtav\\OneDrive\\Documentos\\Factura.txt";
                string mail = "";
                DialogResult de = MessageBox.Show("¿Enviar correo?", "Seleccionar", MessageBoxButtons.YesNo);
                switch (de)
                {
                    case DialogResult.Yes:
                        string id = Microsoft.VisualBasic.Interaction.InputBox("Numero de identificación", "Datos de envio factura al correo");
                        var sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                        if (Regex.IsMatch(id, sFormato))
                        {
                            if (Regex.Replace(id, sFormato, String.Empty).Length == 0)
                            {
                                MessageBox.Show("Correo enviado");
                            }
                            else
                            {
                               
                            }
                        }
                        else
                        {
                            string query = "select mail from [user] where Id_User = " + id;
                            //buscar mail en base de datos
                            con.Open();
                            SqlDataAdapter ad = new SqlDataAdapter(query, con);
                            DataTable dtF = new DataTable();
                            ad.Fill(dtF);
                            mail = dtF.Rows[0].ItemArray[0].ToString();
                            if (dtF.Rows.Count == 0 || mail.Equals(""))
                            {
                                return;
                            }
                            con.Close();
                            //
                        }
                        //extract factura from data base
                        string queryBusca = "select top (1) * from Factura order by Id_Factura desc";
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(queryBusca, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var codeB64 = dt.Rows[0].ItemArray[1].ToString();
                        var B64ToByte = Convert.FromBase64String(codeB64);
                        var a = System.Text.Encoding.UTF8.GetString(B64ToByte);
                        con.Close();
                        File.WriteAllText(path, a);

                        //

                        MailMessage correo = new MailMessage();
                        
                        correo.From = new MailAddress("distribucionesarlys@gmail.com", "Distribuciones Arly's", System.Text.Encoding.UTF8);//Correo de salida
                        correo.To.Add(mail.Equals("") ? id : mail); //Correo destino
                        correo.Subject = "Gracias por su compra Distribuciones Arly's"; //Asunto
                        correo.Body = "El día de hoy se realiza el envio de su factura,\n Gracias por su compra"; //Mensaje del correo
                        correo.Attachments.Add(new Attachment(path)); 
                        correo.IsBodyHtml = true;
                        correo.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("distribucionesarlys@gmail.com", "wpyjwpvhspiebqcd");//Cuenta de correo
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                        smtp.Send(correo);
                        //
                        correo.Dispose();
                        //
                        break;
                    case DialogResult.No:
                        return;
                    default: break;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("SendMail" + ex);
            }   
        }
        public void SendMailRem(string factura)
        {
            try
            {
                string path = @"C:\\Users\\kmtav\\OneDrive\\Documentos\\Factura.txt";
                string mail = "";
                DialogResult de = MessageBox.Show("¿Enviar correo?", "Seleccionar", MessageBoxButtons.YesNo);
                switch (de)
                {
                    case DialogResult.Yes:
                        string id = Microsoft.VisualBasic.Interaction.InputBox("Numero de identificación o correo electronico", "Datos de envio factura al correo");
                        var sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                        if (Regex.IsMatch(id, sFormato))
                        {
                            if (Regex.Replace(id, sFormato, String.Empty).Length == 0)
                            {
                                MessageBox.Show("Correo enviado");
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            string query = "select mail from [user] where Id_User = " + id;
                            //buscar mail en base de datos
                            con.Open();
                            SqlDataAdapter ad = new SqlDataAdapter(query, con);
                            DataTable dtF = new DataTable();
                            ad.Fill(dtF);
                            mail = dtF.Rows[0].ItemArray[0].ToString();
                            if (dtF.Rows.Count == 0 || mail.Equals(""))
                            {
                                return;
                            }
                            con.Close();
                            //
                        }
                        //extract factura from data base
                        string queryBusca = "select top (1) * from FacturaRem order by Id_Factura desc";
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(queryBusca, con);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        var codeB64 = dt.Rows[0].ItemArray[1].ToString();
                        var B64ToByte = Convert.FromBase64String(codeB64);
                        var a = System.Text.Encoding.UTF8.GetString(B64ToByte);
                        con.Close();
                        File.WriteAllText(path, a);

                        //

                        MailMessage correo = new MailMessage();

                        correo.From = new MailAddress("distribucionesarlys@gmail.com", "Distribuciones Arly's", System.Text.Encoding.UTF8);//Correo de salida
                        correo.To.Add(mail.Equals("") ? id : mail); //Correo destino
                        correo.Subject = "Gracias por su compra Distribuciones Arly's"; //Asunto
                        correo.Body = "El día de hoy se realiza el envio de su factura,\n Gracias por su compra"; //Mensaje del correo
                        correo.Attachments.Add(new Attachment(path));
                        correo.IsBodyHtml = true;
                        correo.Priority = MailPriority.Normal;
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("distribucionesarlys@gmail.com", "wpyjwpvhspiebqcd");//Cuenta de correo
                        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                        smtp.EnableSsl = true;//True si el servidor de correo permite ssl
                        smtp.Send(correo);
                        //
                        correo.Dispose();
                        //
                        break;
                    case DialogResult.No:
                        return;
                    default: break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("SendMail" + ex);
            }
        }
    }
}
