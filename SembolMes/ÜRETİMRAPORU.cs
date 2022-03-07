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
    public partial class ÜRETİMRAPORU : Form
    {
        public ÜRETİMRAPORU()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        SqlCommand komut = new SqlCommand();

        private void button4_Click(object sender, EventArgs e)
        {
            uretimraporu();
            uretimdgv();
            opgrafik();
        }
        private void uretimraporu()
        {
            mes_baglan.Open();

            SqlCommand bak = new SqlCommand("select count(durum) as ToplamAdet from vwRaporlama where bit_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "'", mes_baglan);
            SqlDataReader dr = bak.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr[0].ToString();
            }

            mes_baglan.Close();


            mes_baglan.Open();

            SqlCommand bak1 = new SqlCommand("select count(uretim_adeti) as ToplamAdet from vwRaporlama where bit_tarih between'" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "'", mes_baglan);
            SqlDataReader dr1 = bak1.ExecuteReader();
            while (dr1.Read())
            {
                label10.Text = dr1[0].ToString();
            }

            mes_baglan.Close();


            mes_baglan.Open();
            SqlCommand bak2 = new SqlCommand(" select count( istasyon_kodu) as toplam_is from vwRaporlama where istasyon_kodu='253.10.02.06' and bas_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "' ", mes_baglan);
            SqlDataReader dr2 = bak2.ExecuteReader();
            while (dr2.Read())
            {
                label15.Text = dr2[0].ToString();
            }
            mes_baglan.Close();

            mes_baglan.Open();
            SqlCommand bak3 = new SqlCommand(" select count( istasyon_kodu) as toplam_is from vwRaporlama where istasyon_kodu='253.10.10.02' and bas_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "' ", mes_baglan);
            SqlDataReader dr3 = bak3.ExecuteReader();
            while (dr3.Read())
            {
                label16.Text = dr3[0].ToString();
            }

            mes_baglan.Close();

        }

        private void opgrafik()
        {
                mes_baglan.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT is_emri_no,stok_kodu,istasyon_kodu,CONVERT(DATE,bit_tarih) as tarih,op_suresi,(DATEDIFF(HOUR, bas_tarih, bit_tarih) / 60 + DATEDIFF(MINUTE, bas_tarih, bit_tarih) / 60 + DATEDIFF(SECOND, bas_tarih, bit_tarih) - 4500) as Verimlilik FROM vwRaporlama where bit_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "' ", mes_baglan);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                chart2.DataSource = dt;
                chart2.ChartAreas["Verimlilik"].AxisX.Title = "Günler";
                chart2.Series["Gerceklesen Süre"].XValueMember = "istasyon_kodu";
                chart2.Series["Gerceklesen Süre"].YValueMembers = "Verimlilik";
                mes_baglan.Close();
           
        }
        private void uretimdgv()
        {
            mes_baglan.Open();
            SqlDataAdapter daa = new SqlDataAdapter(" select istasyon_kodu,operator_id,stok_kodu,stok_adi,operasyon_adi,uretim_adeti from vwRaporlama where bas_tarih between '" + rjDatePicker1.Text.ToString() + "' and '" + rjDatePicker2.Text.ToString() + "'  ", mes_baglan);
            DataTable tabloo = new DataTable();
            daa.Fill(tabloo);
            dataGridView2.DataSource = tabloo;
            mes_baglan.Close();
        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ÜRETİMRAPORU_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
