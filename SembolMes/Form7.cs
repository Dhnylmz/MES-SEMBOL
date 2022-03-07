using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SembolMes
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        string trh = DateTime.Now.ToString("G");

        public string es_zamanlı;

        private void Form7_Load(object sender, EventArgs e)
        {
            label1.Text = trh;
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlCommand komut = new SqlCommand();


        private void button1_Click(object sender, EventArgs e)
        {
            Form7.ActiveForm.Hide();
            mes_baglan.Open();

            SqlCommand komut = new SqlCommand(" insert into uretim_kayit (operasyon_adi,operator_id,operasyon_no, is_emri_no, rota_no, stok_kodu, stok_adi, istasyon_kodu,KalanMiktar,durum,kalip_id,bas_tarih,klt_onay,es_zamanlı) values ('" + label21.Text.ToString() + "','" + label3.Text.ToString() + "','" + label8.Text.ToString() + "','" + label9.Text.ToString() + "','" + label24.Text.ToString() + "','" + label11.Text.ToString() + "', '" + label12.Text.ToString() + "','" + label13.Text.ToString() + "','" + label17.Text.ToString() + "','AKTİF','"+label10.Text.ToString()+"','"+trh+"','0','"+ es_zamanlı.ToString()+"')", mes_baglan);
            int snc1 = komut.ExecuteNonQuery();
            if (snc1 > 0)
            {
                MessageBox.Show("İŞ EMRİ TAMAMLANDI");
                mes_baglan.Close();

                giris frm1 = new giris();
                frm1.Show();
           
            }

            else
            {
                MessageBox.Show("İŞ EMRİ AKTARIMINDA HATA OLUŞTU.TEKRAR DENEYİNİZ");
            }
            mes_baglan.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            Form7.ActiveForm.Hide();
            detayekrani dt = new detayekrani();
            dt.Show();
            dt.textBox2.Texts = label3.Text.ToString();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}