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
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace SembolMes
{
    public partial class acilis : Form
    {
        public acilis()
        {
            InitializeComponent();
        }

        /// <summary>
        /// /////////////////////////
        /// </summary>

        string versiyon = "v"+Application.ProductVersion;

        /// <summary>
        /// ////////////////////
        /// </summary>


        int saniye = 0;
        string nokta = ".";

        private void acilis_Load(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate("https://sites.google.com/view/sembolmes/mes-sistemi");
                webBrowser1.ScriptErrorsSuppressed = true;
                label3.Text = versiyon;
                webBrowser1.Visible = false;
                timer1.Start();
                label2.Text = "Versiyon kontrol ediliyor...";
            }
            catch
            {
                MessageBox.Show("HATA");
                /// HATA EKLENDİ
            }

        }


        private void kontrol()
        {
            try
            {
                SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
                baglan.Open();

                MySqlConnection verigetir = new MySqlConnection("server = '" + Properties.Settings.Default["mysql_server"] + "'; user id = root; password= 1234; database='test'; persistsecurityinfo=True; allowbatch=True; ");
                verigetir.Open();

                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();

                timer2.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("SUNUCU BAĞLANTILARI BAŞARISIZ. LÜTFEN KONTROL EDİNİZ.");
                admin admin = new admin();
                admin.Show();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                HtmlElementCollection classbtton = webBrowser1.Document.All;
                foreach (HtmlElement name in classbtton)
                {
                    if (name.GetAttribute("className") == "CDt4Ke zfr3Q JYVBee") //  CDt4Ke zfr3Q JYVBee
                    {

                        string kod = name.InnerText;
                        string[] parcala1;
                        string yeni2;

                        parcala1 = kod.Split(' ');
                        yeni2 = parcala1[0];

                        if (versiyon == yeni2)
                        {
                            timer1.Stop();
                            label2.Text = "Programınız Hazırlanıyor";
                            kontrol();
                        }
                        else
                        {
                            timer1.Stop();
                            var result = MessageBox.Show("Güncellemek için web sitemizi ziyaret edin.", "YENİ VERSİYON BULUNDU", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (result == DialogResult.OK)
                            {
                                System.Diagnostics.Process.Start("https://sites.google.com/view/sembolmes/program");
                                System.Environment.Exit(0);
                            }
                        }
                    }
                }
            }
            catch 
            {
                timer1.Stop();
                label2.Text = "Programınız Hazırlanıyor";
                kontrol();
            }
        }
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            saniye++;
            
            if (saniye < 5)
            {
                if (saniye % 15 != 0)
                {
                    label2.Text = label2.Text + nokta;
                }
                else
                {
                    label2.Text = "Programınız Hazırlanıyor";
                }
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}