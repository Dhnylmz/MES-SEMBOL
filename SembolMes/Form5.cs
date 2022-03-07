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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        SqlCommand komut = new SqlCommand();


        // Canlı üretim alanı ekran kodlarıdır.




        // Operatör Raporu alanına ait kodlardır.

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

        private void oprapor()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                string personel = comboBox1.SelectedItem.ToString();
                mes_baglan.Open();

                SqlCommand bak = new SqlCommand("select count(durum) as ToplamAdet from vwRaporlama where operator_id='" + comboBox1.Text.ToString() + "' and bit_tarih between '" + dateTimePicker1.Text.ToString() + "' and '" + dateTimePicker2.Text.ToString() + "' ", mes_baglan);
                SqlDataReader dr = bak.ExecuteReader();
                while (dr.Read())
                {
                    label3.Text = dr[0].ToString();
                }
                mes_baglan.Close();


                mes_baglan.Open();

                SqlCommand bak1 = new SqlCommand("select sum(uretim_adeti) as ToplamAdet from vwRaporlama where operator_id='" + comboBox1.Text.ToString() + "' and bit_tarih between '" + dateTimePicker1.Text.ToString() + "' and '" + dateTimePicker2.Text.ToString() + "' ", mes_baglan);
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

        private void opdgv()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                mes_baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT is_emri_no,stok_kodu,istasyon_kodu,CONVERT(DATE,bit_tarih) as tarih,op_suresi,(DATEDIFF(HOUR, bas_tarih, bit_tarih) / 60 + DATEDIFF(MINUTE, bas_tarih, bit_tarih) / 60 + DATEDIFF(SECOND, bas_tarih, bit_tarih) - 4500) as Gerceklesen_Süre FROM vwRaporlama where operator_id='" + comboBox1.Text + "'and bit_tarih between '" + dateTimePicker1.Text.ToString() + "' and '" + dateTimePicker2.Text.ToString() + "'", mes_baglan);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                mes_baglan.Close();
            }
            else
            {
            }
        }

        private void opgrafik()
        {
            if (string.IsNullOrEmpty(comboBox1.Text) == false)
            {
                mes_baglan.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT is_emri_no,stok_kodu,istasyon_kodu,CONVERT(DATE,bit_tarih) as tarih,op_suresi,(DATEDIFF(HOUR, bas_tarih, bit_tarih) / 60 + DATEDIFF(MINUTE, bas_tarih, bit_tarih) / 60 + DATEDIFF(SECOND, bas_tarih, bit_tarih) - 4500) as Verimlilik FROM vwRaporlama where operator_id='" + comboBox1.Text + "'and bit_tarih between '" + dateTimePicker1.Text.ToString() + "' and '" + dateTimePicker2.Text.ToString() + "' ", mes_baglan);
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

        private void button3_Click(object sender, EventArgs e)
        {
            oprapor();
            opdgv();
            opgrafik();
        }

        // Üretim raporu alanına ait kodlardır.


        private void uretimraporu()
        {
            mes_baglan.Open();

            SqlCommand bak = new SqlCommand("select count(durum) as ToplamAdet from vwRaporlama where bit_tarih between '" + dateTimePicker3.Text.ToString() + "' and '" + dateTimePicker4.Text.ToString() + "'", mes_baglan);
            SqlDataReader dr = bak.ExecuteReader();
            while (dr.Read())
            {
                label12.Text = dr[0].ToString();
            }

            mes_baglan.Close();


            mes_baglan.Open();

            SqlCommand bak1 = new SqlCommand("select count(uretim_adeti) as ToplamAdet from vwRaporlama where bit_tarih between'" + dateTimePicker3.Text.ToString() + "' and '" + dateTimePicker4.Text.ToString() + "'", mes_baglan);
            SqlDataReader dr1 = bak1.ExecuteReader();
            while (dr1.Read())
            {
                label10.Text = dr1[0].ToString();
            }

            mes_baglan.Close();


            mes_baglan.Open();
            SqlCommand bak2 = new SqlCommand(" select count( istasyon_kodu) as toplam_is from vwRaporlama where istasyon_kodu='253.10.02.06' and bas_tarih between '" + dateTimePicker3.Text.ToString() + "' and '" + dateTimePicker4.Text.ToString() + "' ", mes_baglan);
            SqlDataReader dr2 = bak2.ExecuteReader();
            while (dr2.Read())
            {
                label15.Text = dr2[0].ToString();
            }
            mes_baglan.Close();

            mes_baglan.Open();
            SqlCommand bak3 = new SqlCommand(" select count( istasyon_kodu) as toplam_is from vwRaporlama where istasyon_kodu='253.10.10.02' and bas_tarih between '" + dateTimePicker3.Text.ToString() + "' and '" + dateTimePicker4.Text.ToString() + "' ", mes_baglan);
            SqlDataReader dr3 = bak3.ExecuteReader();
            while (dr3.Read())
            {
                label16.Text = dr3[0].ToString();
            }

            mes_baglan.Close();

        }

        private void uretimdgv()
        {
            mes_baglan.Open();
            SqlDataAdapter daa = new SqlDataAdapter(" select istasyon_kodu,operator_id,stok_kodu,stok_adi,operasyon_adi,uretim_adeti from vwRaporlama where bas_tarih between '" + dateTimePicker3.Text.ToString() + "' and '" + dateTimePicker4.Text.ToString() + "'  ", mes_baglan);
            DataTable tabloo = new DataTable();
            daa.Fill(tabloo);
            dataGridView2.DataSource = tabloo;
            mes_baglan.Close();
        }

        private void uretimgrafik()
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            uretimraporu();
            uretimdgv();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            listele();
            uretimraporu();
            uretimdgv();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 KYNK = new Form8();
            KYNK.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form6 FR = new Form6();
            FR.Show();
        }
        private void listele()
        {
            if (string.IsNullOrEmpty(rjTextBox1.Texts) == true)
            {
                istasyon_sec.Items.Clear();
                SqlDataReader ist;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "select ps_kodu from U_Uretim_istasyon_karti order by ps_kodu asc ";
                ist = komut.ExecuteReader();
                while (ist.Read())
                {
                    istasyon_sec.Items.Add(ist["ps_kodu"].ToString());
                }

                baglan.Close();

                mes_baglan.Open();
                SqlDataAdapter da = new SqlDataAdapter(" select istasyon_kodu,operator_id,stok_kodu,stok_adi,is_emri_no,rota_no,operasyon_no from uretim_kayit ", mes_baglan);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView3.DataSource = tablo;
                mes_baglan.Close();
            }
            else
            {
                try
                {
                    string[] parcala;
                    string ayır = rjTextBox1.Texts;
                    parcala = ayır.Split('/', '/');
                    string is_emri_ = parcala[0];
                    string rota_ = parcala[1];
                    string op_ = parcala[2];

                    istasyon_sec.Items.Clear();
                    SqlDataReader ist;
                    baglan.Open();
                    komut.Connection = baglan;
                    komut.CommandText = "select ps_kodu from U_Uretim_istasyon_karti  order by ps_kodu asc ";
                    ist = komut.ExecuteReader();
                    while (ist.Read())
                    {
                        istasyon_sec.Items.Add(ist["ps_kodu"].ToString());
                    }

                    baglan.Close();

                    mes_baglan.Open();
                    SqlDataAdapter da = new SqlDataAdapter("select istasyon_kodu,operator_id,stok_kodu,stok_adi,is_emri_no,rota_no,operasyon_no from uretim_kayit where is_emri_no='" + is_emri_ + "' and rota_no='" + rota_ + "' and operasyon_no='" + op_ + "' ", mes_baglan);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView3.DataSource = tablo;
                    mes_baglan.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("İş emiri bulunamadı.Doğru yazdığınızdan emin olunuz.");
                }
            }
        }
        private void d_buton4_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "TEMİZLE")
            {
                istasyon_sec.CellTemplate.Value = "";
                MessageBox.Show("İstasyon verisi temizlendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (dataGridView3.Columns[e.ColumnIndex].Name == "KAYDET")
            {
                if (dataGridView3.CurrentRow.Cells["istasyon_sec"].Value == null)
                {
                    MessageBox.Show("İstasyon seçimi yapılmadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string operator_id, stok_kodu, stok_adi, is_emri_no, istasyon_sec, operasyon_no, rota_no;

                    int secilialan = dataGridView3.SelectedCells[0].RowIndex;
                    operator_id = dataGridView3.CurrentRow.Cells["operator_id"].Value.ToString();
                    stok_kodu = dataGridView3.CurrentRow.Cells["stok_kodu"].Value.ToString();
                    stok_adi = dataGridView3.CurrentRow.Cells["stok_adi"].Value.ToString();
                    is_emri_no = dataGridView3.CurrentRow.Cells["is_emri_no"].Value.ToString();
                    rota_no = dataGridView3.CurrentRow.Cells["rota_no"].Value.ToString();
                    operasyon_no = dataGridView3.CurrentRow.Cells["operasyon_no"].Value.ToString();
                    istasyon_sec = dataGridView3.CurrentRow.Cells["istasyon_sec"].Value.ToString();

                    mes_baglan.Open();
                    SqlCommand dt = new SqlCommand("update uretim_kayit set istasyon_kodu='" + istasyon_sec + "' where stok_adi='" + stok_adi + "' and stok_kodu='" + stok_kodu + "' and is_emri_no='" + is_emri_no + "' and rota_no='" + rota_no + "' and operasyon_no='" + operasyon_no + "' and operator_id='" + operator_id + "' ", mes_baglan);
                    dt.ExecuteNonQuery();
                    mes_baglan.Close();
                    listele();
                    MessageBox.Show("İstasyon verisi güncellendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void d_buton5_Click(object sender, EventArgs e)
        {
            nodemcu nd = new nodemcu();
            nd.Show();
        }

        private void d_buton1_Click(object sender, EventArgs e)
        {

        }

        private void d_buton2_Click(object sender, EventArgs e)
        {

        }

        private void d_buton3_Click(object sender, EventArgs e)
        {

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }
    }
}
