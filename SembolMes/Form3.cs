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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace SembolMes
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        string trh = DateTime.Now.ToString("G");

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Start();
            pictureBox2.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            this.BackColor = Color.White;
        }

        private void verileriaktar()
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand(" update u_uretim_ym_istasyonlari set ps_kodu=@ps_kodu, operator_adi=@operator_adi, uretilen_adet = @uretilen_adet Where ur_isemri_no=@ur_isemri_no and rota_no=@rota_no and op_no=@op_no ", baglan);
            kmt.Parameters.AddWithValue("@ps_kodu", label12.Text.ToString());
            kmt.Parameters.AddWithValue("@operator_adi", label2.Text.ToString());
            kmt.Parameters.AddWithValue("@ur_isemri_no", label4.Text.ToString());
            kmt.Parameters.AddWithValue("@uretilen_adet", label10.Text.ToString());
            kmt.Parameters.AddWithValue("@rota_no", label23.Text.ToString());
            kmt.Parameters.AddWithValue("@op_no", label26.Text.ToString());
            //kmt.Parameters.AddWithValue("@hes_bastarih", label17.Text); , hes_bastarih=@hes_bastarih,hes_tarih=@hes_tarih
            //kmt.Parameters.AddWithValue("@hes_tarih", label18.Text);  


            int snc1 = kmt.ExecuteNonQuery();

            if (snc1 > 0)
            {
                baglan.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglan;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Oto_IsEmrindenUretimFisi";
                cmd.Parameters.Add("IsEmriNo", SqlDbType.VarChar, 50).Value = label4.Text;
                cmd.Parameters.Add("UretimMik", SqlDbType.Float).Value = label10.Text;
                cmd.Parameters.Add("UserCode", SqlDbType.VarChar).Value = label2.Text;
                cmd.Parameters.Add("Tarih", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("islemYeriTipi", SqlDbType.SmallInt).Value = 2;
                cmd.Parameters.Add("islemFisID", SqlDbType.BigInt).Value = 0;
                cmd.Parameters.Add("RecDetIslemYeriTipi", SqlDbType.TinyInt).Value = 0;
                cmd.Parameters.Add("DepoKodu", SqlDbType.VarChar, 30).Value = default;

                int snc2 = cmd.ExecuteNonQuery();
                if (snc2 > 0)
                {
                    MessageBox.Show("HBS İŞ EMRİ TAMAMLANDI");
                    baglan.Close();
                    mes_aktarım();

                }

                else
                {
                    MessageBox.Show("HBS İŞ EMRİ AKTARIMINDA HATA OLUŞTU.TEKRAR DENEYİNİZ");
                    baglan.Close(); 
                }
            }

            else
            {
                MessageBox.Show("HBS BAGLANTINIZDA SORUN VAR.");
                baglan.Close();
            }

            
        }
        private void goster()
        {


            if (timer1.Enabled == true)
            {

                string dgr1;
                dgr1 = label12.Text.Replace('.', 'p');


                string istasyon = label12.Text.ToString();

                MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='"+dgr1+"'; persistsecurityinfo=True; allowbatch=True; ");

                verigetir.Open();

                MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);

                MySqlDataReader dr = kmt.ExecuteReader();
                if (dr.Read())
                {
                    label10.Text = dr["adet"].ToString();
                }

                verigetir.Close();
            }
        }

        private void mes_aktarım()
        {
            string dgr1;
            dgr1 = label12.Text.Replace('.', 'p');

            SqlCommand mesaktar = new SqlCommand(" update uretim_kayit set  uretim_adeti=@uretim_adeti, durum=@durum where is_emri_no='" + label4.Text.ToString() + "' and rota_no='" + label23.Text.ToString() + "' and operasyon_no='"+label26.Text.ToString()+"'", mes_baglan);
            mes_baglan.Open();
            // mesaktar.Parameters.AddWithValue("@bit_tarih", label18.Text.ToString()); bit_tarih=@bit_tarih, // 
            mesaktar.Parameters.AddWithValue("@uretim_adeti", label10.Text.ToString());
            mesaktar.Parameters.AddWithValue("@durum", "PASİF");
            mesaktar.ExecuteNonQuery();

            int snc3 = mesaktar.ExecuteNonQuery();
            if (snc3 > 0)
            {
                string istasyon = label12.Text.ToString();

                MySqlConnection tablesil = new MySqlConnection("server = 192.168.1.59; user id = root; password=1234; database='" + dgr1 + "'; persistsecurityinfo=True; allowbatch=True; ");

                tablesil.Open();

                MySqlCommand sil = new MySqlCommand(" DELETE FROM uretim where 1", tablesil);
                if (sil.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(" PHPMAYADMİN VERİLER SIFIRLANDI ");
                }
                else
                {
                    MessageBox.Show(" Hata. PHPMYADMİN Adetler Silinemedi.. ");
                }
                //detayekrani detayekrani = new detayekrani();
                //detayekrani.Show();
                tablesil.Close();
                this.Hide();

                //MessageBox.Show("İŞ EMRİ TAMAMLANDI");

            }

            else
            {
                MessageBox.Show("MES-21 İŞ EMRİ AKTARIMINDA HATA OLUŞTU.TEKRAR DENEYİNİZ");
                baglan.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string birlestir;
            birlestir = string.Concat(label4.Text, "/", label23.Text, "/", label26.Text);

            //AND SONROTA = 'EVET'

            SqlCommand kontrol = new SqlCommand("SELECT * FROM vwAktifIsEmriIstDetayli where IST_IS_EMRI='"+birlestir+"' ",baglan);
            DataTable dd = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(kontrol);
            da.Fill(dd);
            //if(dd.Rows.Count > 0)
            //{
            //    //if (MessageBox.Show("ÜRETİMDE FİRE OLUŞTU MU?", "İŞ EMRİ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    //{
            //    //    firefisi fr3 = new firefisi();
            //    //    fr3.label4.Text = label4.Text.ToString();
            //    //    fr3.label5.Text = label2.Text.ToString();
            //    //    fr3.Show();
            //    //}
            //    //else
            //    //{
            //    //    verileriaktar();
            //    //}

            //    baglan.Open();
            //    SqlCommand kmt = new SqlCommand("update u_uretim_ym_istasyonlari set ps_kodu=@ps_kodu, operator_adi=@operator_adi, uretilen_adet = @uretilen_adet Where ur_isemri_no=@ur_isemri_no and rota_no=@rota_no and op_no=@op_no ", baglan);
            //    kmt.Parameters.AddWithValue("@ps_kodu", label12.Text.ToString());
            //    kmt.Parameters.AddWithValue("@operator_adi", label2.Text.ToString());
            //    kmt.Parameters.AddWithValue("@ur_isemri_no", label4.Text.ToString());
            //    kmt.Parameters.AddWithValue("@uretilen_adet", label10.Text.ToString());
            //    kmt.Parameters.AddWithValue("@rota_no", label23.Text.ToString());
            //    kmt.Parameters.AddWithValue("@op_no", label26.Text.ToString());
            //    //kmt.Parameters.AddWithValue("@hes_bastarih", label17.Text); , hes_bastarih=@hes_bastarih,hes_tarih=@hes_tarih
            //    //kmt.Parameters.AddWithValue("@hes_tarih", label18.Text);  

            //    int snc1 = kmt.ExecuteNonQuery();

            //    if (snc1 > 0)
            //    {
            //        //baglan.Open();

            //        SqlConnection con = new SqlConnection(" Server=192.168.1.44; Database=SEM_20; User Id=hbs; Password=240305; ");
            //        con.Open();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = baglan;
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.CommandText = "sp_Oto_IsEmrindenUretimFisi";
            //        cmd.Parameters.Add("IsEmriNo", SqlDbType.VarChar, 50).Value = label4.Text;
            //        cmd.Parameters.Add("UretimMik", SqlDbType.Float).Value = label10.Text;
            //        cmd.Parameters.Add("UserCode", SqlDbType.VarChar).Value = label2.Text;
            //        cmd.Parameters.Add("Tarih", SqlDbType.DateTime).Value = DateTime.Now;
            //        cmd.Parameters.Add("islemYeriTipi", SqlDbType.SmallInt).Value = 2;
            //        cmd.Parameters.Add("islemFisID", SqlDbType.BigInt).Value = 0;
            //        cmd.Parameters.Add("RecDetIslemYeriTipi", SqlDbType.TinyInt).Value = 0;
            //        cmd.Parameters.Add("DepoKodu", SqlDbType.VarChar, 30).Value = default;

            //        int snc2 = cmd.ExecuteNonQuery();

            //        if (snc2 == 1)
            //        {
            //            baglan.Close();

            //            SqlCommand mesaktar = new SqlCommand(" update uretim_kayit set  uretim_adeti=@uretim_adeti, durum=@durum, bit_tarih=@bit_tarih where is_emri_no='" + label4.Text.ToString() + "' and rota_no='" + label23.Text.ToString() + "' and operasyon_no='" + label26.Text.ToString() + "'", mes_baglan);
            //            mes_baglan.Open();
            //            mesaktar.Parameters.AddWithValue("@bit_tarih", trh);
            //            mesaktar.Parameters.AddWithValue("@uretim_adeti", label10.Text.ToString());
            //            mesaktar.Parameters.AddWithValue("@durum", "PASİF");
            //            mesaktar.ExecuteNonQuery();

            //            int snc3 = mesaktar.ExecuteNonQuery();
            //            if (snc3 > 0)
            //            {

            //                string dgr1;
            //                dgr1 = label12.Text.Replace('.', 'p');

            //                string istasyon = label12.Text.ToString();

            //                MySqlConnection tablesil = new MySqlConnection("server = 192.168.1.59; user id = root; password=1234; database='" + dgr1 + "'; persistsecurityinfo=True; allowbatch=True; ");

            //                tablesil.Open();

            //                MySqlCommand sil = new MySqlCommand(" DELETE FROM uretim where 1", tablesil);
            //                if (sil.ExecuteNonQuery() == 1)
            //                {
            //                    MessageBox.Show(" HBS TABLO,PRESEDÜR VE PHPMYADMİN ÇALIŞTI ");
            //                }
            //                else
            //                {
            //                    MessageBox.Show(" Hata....HBS TABLO,PRESEDÜR VE PHPMYADMİN ÇALIŞTI");
            //                }
            //                tablesil.Close();
            //                this.Hide();
            //            }
            //        }

            //        else
            //        {
            //            MessageBox.Show("HATA.....HBS TABLO VE PROSEDUR ÇALIŞMADI");
            //            baglan.Close();
            //        }
            //        con.Close();
            //    }

            //    else
            //    {
            //        MessageBox.Show("HATA.... HBS TABLO GÜNCELLENMEDİ");
            //        baglan.Close();
            //    }


            //}
            //else
            //{
            if(dd.Rows.Count > 0) { 
                baglan.Open();
                
                    string dgr1;
                    dgr1 = label12.Text.Replace('.', 'p');

                    SqlCommand mesaktar = new SqlCommand(" update uretim_kayit set  uretim_adeti=@uretim_adeti, bit_tarih=@bit_tarih, durum=@durum, gemo=@gemo where is_emri_no='" + label4.Text.ToString() + "' and rota_no='" + label23.Text.ToString() + "' and operasyon_no='" + label26.Text.ToString() + "'", mes_baglan);
                    mes_baglan.Open();
                    mesaktar.Parameters.AddWithValue("@bit_tarih", trh);  
                    mesaktar.Parameters.AddWithValue("@uretim_adeti", label10.Text.ToString());
                    mesaktar.Parameters.AddWithValue("@durum", "PASİF");
                    mesaktar.Parameters.AddWithValue("@gemo", rjTextBox1.Texts.ToString());
                    mesaktar.ExecuteNonQuery();

                    int snc5 = mesaktar.ExecuteNonQuery();
                    if (snc5 > 0)
                    {
                        string istasyon = label12.Text.ToString();

                        MySqlConnection tablesil = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='"+dgr1+"'; persistsecurityinfo=True; allowbatch=True;  ");

                        tablesil.Open();

                        MySqlCommand sil = new MySqlCommand(" truncate table uretim", tablesil);
                        int sils = sil.ExecuteNonQuery();
                        if (sils > 0)
                        {
                            MessageBox.Show("Hata....SON ROTA DEĞİL. PHPMYADMİN TABLO SİLİNMEDİ");
                        }
                        else
                        {
                            
                            MessageBox.Show("BAŞARILI ... SON ROTA DEĞİL. MES AKTARILDI. PHPMYADMİN TABLO SİLİNDİ");
                        }
                        tablesil.Close();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hata....SON ROTA DEĞİL. MES AKTARILAMADI");
                        baglan.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Hata....SON ROTA DEĞİL. HBS TABLO ÇALIŞMADI");
                }
            
            this.Close();
            giris frm1 = new giris();
            frm1.Show();

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {

            detayekrani detayekrani = new detayekrani();
            detayekrani.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            goster();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //mes_baglan.Open();

            //SqlCommand komut = new SqlCommand(" insert into uretim_kayit (operator_id, is_emri_no, rota_no, stok_kodu, stok_adi, istasyon_kodu, emir_mik, bas_tarih,durum) values ('" + label2.Text.ToString() + "','" + label4.Text.ToString() + "','" + label23.Text.ToString() + "','" + label8.Text.ToString() + "', '" + label14.Text.ToString() + "','" + label12.Text.ToString() + "','" + label20.Text.ToString() + "','" + label17.Text.ToString() + "','AKTİF')", mes_baglan); ; ; ;
            //int snc1 = komut.ExecuteNonQuery();
            //if (snc1 > 0)
            //{
            //    MessageBox.Show("İŞ EMRİ TAMAMLANDI");
            //    mes_baglan.Close();

                Form3.ActiveForm.Hide();
                detayekrani detayekrani = new detayekrani();
                detayekrani.Show();
            //}

            //else
            //{
            //    MessageBox.Show("İŞ EMRİ AKTARIMINDA HATA OLUŞTU.TEKRAR DENEYİNİZ");
            //}
            //mes_baglan.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
