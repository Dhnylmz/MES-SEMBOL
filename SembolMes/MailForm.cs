using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Mail;

namespace SembolMes
{
    public partial class MailForm : Form
    {
        public MailForm()
        {
            InitializeComponent();
        }

        private static MailForm instance;
        public static MailForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MailForm();
                }
                return instance;
            }
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        SqlCommand komut = new SqlCommand();

        string kalip_id;

        private void MailForm_Load(object sender, EventArgs e)
        {
            label5.Text = kalip_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                baglan.Open();
                try
                {
                    SqlCommand kayit = new SqlCommand("insert into U_KalipArizaBakimHar (KALIP_ID,TESPIT_EDEN,DURUM,ARIZA_NEDENI,ARIZA_TARIHI,TIP) VALUES ('" + label5.Text + "','" + label3.Text.ToString() + "',1,'" + comboBox1.Text + "'+' '+'" + richTextBox1.Text + "','" + DateTime.Now + "','0')", baglan);
                    int drd = kayit.ExecuteNonQuery();
                    if (drd > 0)
                    {
                        try
                        {
                            MailMessage mesajim = new MailMessage();
                            SmtpClient istemci = new SmtpClient();
                            istemci.Credentials = new System.Net.NetworkCredential("dyilmaz@sembolotomotiv.com.tr", "Dy155155");
                            istemci.Port = 587;
                            istemci.Host = "mail.sembolotomotiv.com.tr";
                            mesajim.To.Add("yguneysu@sembolotomotiv.com.tr");
                            mesajim.From = new MailAddress("yguneysu@sembolotomotiv.com.tr");
                            mesajim.Subject = radioButton1.Text;
                            mesajim.Body = label5.Text + " Numaralı kalıp kartına arıza kaydı yapıldı.";
                            istemci.Send(mesajim);
                            MessageBox.Show(radioButton1.Text + " kayıtınız başarı ile yapıldı.");
                        }
                        catch
                        {
                            MessageBox.Show("Hata. Lütfen yöneticiniz ile görüşün.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("hata");
                    }
                }
                catch
                {
                    MessageBox.Show("İNTERNET BAĞLANTINIZDA HATA VAR.");
                }
                baglan.Close();
            }
            else if (radioButton2.Checked == true)
            {
                baglan.Open();
                try
                {
                    SqlCommand kayit = new SqlCommand("insert into U_KalipArizaBakimHar (KALIP_ID,TESPIT_EDEN,DURUM,ARIZA_NEDENI,ARIZA_TARIHI,TIP) VALUES ('" + label5.Text + "','" + label3.Text.ToString() + "',1,'" + comboBox1.Text + "','" + DateTime.Now + "','1')", baglan);
                    int drd = kayit.ExecuteNonQuery();
                    if (drd > 0)
                    {
                        try
                        {
                            MailMessage mesajim = new MailMessage();
                            SmtpClient istemci = new SmtpClient();
                            istemci.Credentials = new System.Net.NetworkCredential("dyilmaz@sembolotomotiv.com.tr", "Dy155155");
                            istemci.Port = 587;
                            istemci.Host = "mail.sembolotomotiv.com.tr";
                            mesajim.To.Add("yguneysu@sembolotomotiv.com.tr");
                            mesajim.From = new MailAddress("yguneysu@sembolotomotiv.com.tr");
                            mesajim.Subject = radioButton2.Text;
                            mesajim.Body = label5.Text + " Numaralı kalıp kartına bakım kaydı yapıldı.";
                            istemci.Send(mesajim);
                            MessageBox.Show(radioButton2.Text + " kayıtınız başarı ile yapıldı.");
                        }
                        catch
                        {
                            MessageBox.Show("Hata. Lütfen yöneticiniz ile görüşün.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("hata");
                    }
                }
                catch
                {
                    MessageBox.Show("İNTERNET BAĞLANTINIZDA HATA VAR.");
                }
                baglan.Close();
            }
            else
            {
                MessageBox.Show("LÜTFEN DURUM SEÇİNİZ.");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlDataReader oku;
            mes_baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM arizabakimdurumlari where durum='arıza'", mes_baglan);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[1].ToString());
            }
            mes_baglan.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlDataReader oku;
            mes_baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM arizabakimdurumlari where durum='bakım'", mes_baglan);
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[1].ToString());
            }
            mes_baglan.Close();
        }

        private void MailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(radioButton1.Checked==true || radioButton2.Checked == true)
            {

            }
            else
            {
                MessageBox.Show("LÜTFEN DURUM SEÇİMİ YAPINIZ.");
            }
        }
    }
}