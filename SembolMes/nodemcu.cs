using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Net;
using System.Data.SqlClient;
using System.Data;

namespace SembolMes
{
    public partial class nodemcu : Form
    {
        public nodemcu()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        public void nodemcu_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        // SqlCommand sql = new SqlCommand("insert into nodemcu (nodemcu,IP,Zaman,Durum) values('253.10.01.01','193.168.1.181','" + DateTime.Now.ToString() + "','KOPTU') ", mes_baglan);
        

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            PingTest181();
            PingTest182();
            PingTest183();
            PingTest184();
            PingTest185();
            PingTest186();
            PingTest191();
            PingTest192();
            PingTest193();
            PingTest194();
            PingTest195();
            PingTest196();
            PingTest198();
            PingTest199();
        }

        public bool PingTest181()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.181"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar1.InnerColor = Color.Green;
                mes_baglan.Open();  
                SqlCommand sql = new SqlCommand("UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.181' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {              
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar1.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.181' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest182()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.182"), 1000);

            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {

                circularProgressBar2.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.182' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;     
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar2.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.182' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest183()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.183"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar3.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.183' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar3.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.183' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest184()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.184"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar12.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.184' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar12.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.184' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest185()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.185"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar13.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.185' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar13.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.185' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest186()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.186"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar14.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.186' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar14.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.186' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest191()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.191"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar4.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.191' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar4.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.191' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest192()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.192"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar5.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.192' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar5.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.192' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest193()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.193"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar6.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.193' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar6.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.193' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest194()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.194"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar8.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.194' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar8.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.194' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest195()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.195"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar7.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.195' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar7.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.195' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }

        public bool PingTest196()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.196"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar9.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.196' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar9.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.196' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }

        public bool PingTest198()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.198"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar11.InnerColor = Color.Green;
                mes_baglan.Open(); 
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.198' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar11.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.198' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        public bool PingTest199()
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply pingStatus =
                ping.Send(IPAddress.Parse("192.168.1.199"), 1000);
            if (pingStatus.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                circularProgressBar10.InnerColor = Color.Green;
                mes_baglan.Open();
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='BAGLANDI' WHERE IP= '193.168.1.199' AND  Durum='KOPTU'", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();
                }
                else
                {
                    mes_baglan.Close();
                }
                return true;
            }
            else
            {
                mes_baglan.Open();
                circularProgressBar10.InnerColor = Color.Red;
                SqlCommand sql = new SqlCommand(" UPDATE nodemcu SET  Zaman='" + DateTime.Now.ToString() + "',Durum='KOPTU' WHERE IP= '193.168.1.199' AND  Durum='BAGLANDI' ", mes_baglan);
                int sonuc = sql.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    mes_baglan.Close();

                }
                else
                {
                    mes_baglan.Close();
                }
                return false;
            }
        }
        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.181");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.181/update");
        }
        

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel3.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.182");
        }

        private void linkLabel4_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel4.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.182/update");
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel5.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.183");
        }

        private void linkLabel29_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel29.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.183/update");
        }
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel7.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.191");
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel8.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.191/update");
        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel9.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.192");
        }

        private void linkLabel30_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel30.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.192/update");
        }
        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel11.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.193");
        }
        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel12.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.193/update");
        }
        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel15.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.194");
        }

        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel17.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.194/update");
        }
        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel13.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.195");
        }
        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel14.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.195/update");
        }
        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel16.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.196");
        }

        private void linkLabel31_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel31.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.196/update");
        }
        private void linkLabel32_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel32.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.198");
        }

        private void linkLabel23_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel23.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.198/update");
        }
        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel19.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.199");
        }

        private void linkLabel20_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel20.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.199/update");

        }
        private void linkLabel22_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel22.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.184");

        }

        private void linkLabel24_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel24.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.184/update");

        }
        private void linkLabel25_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel25.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.185");

        }

        private void linkLabel26_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel26.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.185/update");

        }
        private void linkLabel27_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel27.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.186");

        }

        private void linkLabel28_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel28.LinkVisited = true;
            System.Diagnostics.Process.Start("http://192.168.1.186/update");

        }

        private void nodemcu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                mes_baglan.Open();
                SqlCommand kmt = new SqlCommand("update form_durum set form_acik = '0' ", mes_baglan);
                int sonuc = kmt.ExecuteNonQuery();
                if (sonuc > 0)
                {
                   
                    nodemcu.ActiveForm.Hide();
                }
                else
                {
                    MessageBox.Show("Hata");
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
    }
}