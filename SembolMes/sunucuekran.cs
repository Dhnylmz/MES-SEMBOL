using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Net.Mail;

namespace SembolMes
{
    public partial class sunucuekran : Form
    {
        public sunucuekran()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server=192.168.1.44;Database=SEM_20;User Id=hbs;Password=240305;");
        SqlConnection mes_baglan = new SqlConnection("Server=192.168.1.44;Database=MES_21;User Id=hbs;Password=240305;");

        private void d_buton1_Click(object sender, EventArgs e)
        {
            toogle_buton1.Checked = false;

            Properties.Settings.Default["server_sql"] = rjTextBox1.Texts.ToString();
            Properties.Settings.Default["database_sql"] = rjTextBox2.Texts.ToString();
            Properties.Settings.Default["user_id_sql"] = rjTextBox3.Texts.ToString();
            Properties.Settings.Default["password_sql"] = rjTextBox4.Texts.ToString();

            try
            {
                SqlConnection baglan = new SqlConnection("Server='" + rjTextBox1.Texts.ToString() + "'; Database='" + rjTextBox2.Texts.ToString() + "'; User Id='" + rjTextBox3.Texts.ToString() + "'; Password='" + rjTextBox4.Texts.ToString() + "';");
                baglan.Open();
                Properties.Settings.Default.Save();

                toogle_buton1.Checked = true;
                label10.Text = "";

            }
            catch (Exception)
            {
                label10.Text = "BAĞLANTI BAŞARISIZ.";
            }
            baglan.Close();

        }

        private void d_buton2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["database_mes_sql"] = rjTextBox5.Texts.ToString();
            toogle_buton2.Checked = false;
            try
            {
                SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + rjTextBox5.Texts.ToString() + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
                baglan.Open();
                Properties.Settings.Default.Save();

                toogle_buton2.Checked = true;
                label11.Text = "";

            }
            catch (Exception)
            {
                label11.Text = "BAĞLANTI BAŞARISIZ.";
            }
            baglan.Close();
        }

        private void d_buton3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["mysql_server"] = rjTextBox6.Texts.ToString();
            toogle_buton3.Checked = false;
            try
            {
                MySqlConnection verigetir = new MySqlConnection("server = '" + rjTextBox6.Texts.ToString() + "'; user id = root; password= 1234; database='test'; persistsecurityinfo=True; allowbatch=True; ");
                verigetir.Open();

                Properties.Settings.Default.Save();
                toogle_buton3.Checked = true;
                label12.Text = "";

                verigetir.Close();
            }
            catch (Exception)
            {
                label12.Text = "BAĞLANTI BAŞARISIZ.";
            }
        }

        private void sunucuekran_Load(object sender, EventArgs e)
        {

            rjTextBox1.Texts = Properties.Settings.Default["server_sql"].ToString();
            rjTextBox2.Texts = Properties.Settings.Default["database_sql"].ToString();
            rjTextBox3.Texts = Properties.Settings.Default["user_id_sql"].ToString();
            rjTextBox4.Texts = Properties.Settings.Default["password_sql"].ToString();
            rjTextBox5.Texts = Properties.Settings.Default["database_mes_sql"].ToString();
            rjTextBox6.Texts = Properties.Settings.Default["mysql_server"].ToString();
            rjTextBox8.Texts = Properties.Settings.Default["oneri_gonderen_mail"].ToString();
            rjTextBox7.Texts = Properties.Settings.Default["oneri_gonderen_sifre"].ToString();
            rjTextBox11.Texts = Properties.Settings.Default["oneri_alici_mail"].ToString();
            rjTextBox14.Texts = Properties.Settings.Default["ariza_gonderen_mail"].ToString();
            rjTextBox13.Texts = Properties.Settings.Default["ariza_gonderen_sifre"].ToString();
            rjTextBox10.Texts = Properties.Settings.Default["ariza_alici_mail"].ToString();

            try
            {
                SqlConnection baglan = new SqlConnection("Server='" + rjTextBox1.Texts.ToString() + "'; Database='" + rjTextBox2.Texts.ToString() + "'; User Id='" + rjTextBox3.Texts.ToString() + "'; Password='" + rjTextBox4.Texts.ToString() + "';");
                baglan.Open();
                Properties.Settings.Default.Save();

                toogle_buton1.Checked = true;

            }
            catch (Exception)
            {
                label10.Text = "BAĞLANTI BAŞARISIZ.";
            }
            baglan.Close();

            try
            {
                SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + rjTextBox5.Texts.ToString() + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
                baglan.Open();
                Properties.Settings.Default.Save();

                toogle_buton2.Checked = true;

            }
            catch (Exception)
            {
                label11.Text = "BAĞLANTI BAŞARISIZ.";
            }
            baglan.Close();

            try
            {
                MySqlConnection verigetir = new MySqlConnection("server = '" + rjTextBox6.Texts.ToString() + "'; user id = root; password= 1234; database='test'; persistsecurityinfo=True; allowbatch=True; ");
                verigetir.Open();

                Properties.Settings.Default.Save();
                toogle_buton3.Checked = true;

                verigetir.Close();
            }
            catch (Exception)
            {
                label12.Text = "BAĞLANTI BAŞARISIZ.";
            }
        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UYGULAMAYI TEKRAR BAŞLATINIZ!");
            System.Environment.Exit(0);

        }

        private void d_buton5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["oneri_gonderen_mail"] = rjTextBox8.Texts.ToString();
            Properties.Settings.Default["oneri_gonderen_sifre"] = rjTextBox7.Texts.ToString();
            Properties.Settings.Default["oneri_alici_mail"] = rjTextBox11.Texts.ToString();

            try
            {
                MailMessage mesajim = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential(rjTextBox8.Texts, rjTextBox7.Texts);
                istemci.Port = 587;
                istemci.Host = "mail.sembolotomotiv.com.tr";
                mesajim.To.Add(rjTextBox11.Texts);
                mesajim.From = new MailAddress(rjTextBox11.Texts);
                mesajim.Subject = "SİSTEM KAYIT MAİLİDİR.";
                mesajim.Body = " MAİL ADRESİNİZ SİSTEMİMİZE BAŞARIYLA KAYIT EDİLMİŞTİR..";
                istemci.Send(mesajim);
                
                Properties.Settings.Default.Save();
            }
            catch
            {
                label15.Text = "HATA";
                toogle_buton4.Checked = false;
            }
        }

        private void d_buton6_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["ariza_gonderen_mail"] = rjTextBox14.Texts.ToString();
            Properties.Settings.Default["ariza_gonderen_sifre"] = rjTextBox13.Texts.ToString();
            Properties.Settings.Default["ariza_alici_mail"] = rjTextBox10.Texts.ToString();

            try
            {
                MailMessage mesajim = new MailMessage();
                SmtpClient istemci = new SmtpClient();
                istemci.Credentials = new System.Net.NetworkCredential(rjTextBox14.Texts, rjTextBox13.Texts);
                istemci.Port = 587;
                istemci.Host = "mail.sembolotomotiv.com.tr";
                mesajim.To.Add(rjTextBox10.Texts);
                mesajim.From = new MailAddress(rjTextBox10.Texts);
                mesajim.Subject = "SİSTEM KAYIT MAİLİDİR.";
                mesajim.Body = " MAİL ADRESİNİZ SİSTEMİMİZE BAŞARIYLA KAYIT EDİLMİŞTİR..";
                istemci.Send(mesajim);

                label18.Text = "BAŞARILI";
                toogle_buton5.Checked = true;

                Properties.Settings.Default.Save();
            }
            catch
            {
                label18.Text = "HATA";
                toogle_buton5.Checked = false;
            }

        }
    }
}
