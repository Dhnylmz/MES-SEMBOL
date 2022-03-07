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
namespace SembolMes
{
    public partial class OPERATÖR_RAPORU : Form
    {
        public OPERATÖR_RAPORU()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        SqlCommand komut = new SqlCommand();

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            oprapor();
            opdgv();
            opgrafik();
        }
        private void opgrafik()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                mes_baglan.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT is_emri_no,stok_kodu,istasyon_kodu,CONVERT(DATE,bit_tarih) as tarih,op_suresi,(DATEDIFF(HOUR, bas_tarih, bit_tarih) / 60 + DATEDIFF(MINUTE, bas_tarih, bit_tarih) / 60 + DATEDIFF(SECOND, bas_tarih, bit_tarih) - 4500) as Verimlilik FROM vwRaporlama where operator_id='" + comboBox1.Text + "'and bit_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "' ", mes_baglan);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chart1.DataSource = dt;
                chart1.ChartAreas["Verimlilik"].AxisX.Title = "Günler";
                chart1.Series["Gerceklesen Süre"].XValueMember = "istasyon_kodu";
                chart1.Series["Gerceklesen Süre"].YValueMembers = "Verimlilik";
                mes_baglan.Close();
            }
            else
            {
            }
        }

        private void opdgv()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                mes_baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT is_emri_no,stok_kodu,istasyon_kodu,CONVERT(DATE,bit_tarih) as tarih,op_suresi,(DATEDIFF(HOUR, bas_tarih, bit_tarih) / 60 + DATEDIFF(MINUTE, bas_tarih, bit_tarih) / 60 + DATEDIFF(SECOND, bas_tarih, bit_tarih) - 4500) as Gerceklesen_Süre FROM vwRaporlama where operator_id='" + comboBox1.Text + "'and bit_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "'", mes_baglan);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                mes_baglan.Close();
            }
            else
            {
            }
        }
        private void oprapor()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                string personel = comboBox1.SelectedItem.ToString();
                mes_baglan.Open();

                SqlCommand bak = new SqlCommand("select count(durum) as ToplamAdet from vwRaporlama where operator_id='" + comboBox1.Text.ToString() + "' and bit_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "' ", mes_baglan);
                SqlDataReader dr = bak.ExecuteReader();
                while (dr.Read())
                {
                    label3.Text = dr[0].ToString();
                }
                mes_baglan.Close();


                mes_baglan.Open();

                SqlCommand bak1 = new SqlCommand("select sum(uretim_adeti) as ToplamAdet from vwRaporlama where operator_id='" + comboBox1.Text.ToString() + "' and bit_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "' ", mes_baglan);
                SqlDataReader dr1 = bak1.ExecuteReader();
                while (dr1.Read())
                {
                    label4.Text = dr1[0].ToString();
                }

                mes_baglan.Close();
            }
            else
            {
                MessageBox.Show("Lütfen bölüm ve operatör seçiniz.");
            }
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlDataReader oku;
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "select * from U_Kadro_Plani where online='0' and kadro_adi='PRESHANE'";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[2].ToString());

            }
            baglan.Close();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlDataReader oku;
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "select * from U_Kadro_Plani where online='0' and kadro_adi='KAYNAKHANE'";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[2].ToString());

            }
            baglan.Close();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            SqlDataReader oku;
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "select * from U_Kadro_Plani where online='0' and kadro_adi='AMBAR'";
            oku = komut.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[2].ToString());

            }
            baglan.Close();
        }

        private void OPERATÖR_RAPORU_Load(object sender, EventArgs e)
        {

        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
