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
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace SembolMes
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        FilterInfoCollection fico;
        VideoCaptureDevice vcd;

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        SqlCommand komut = new SqlCommand();

        public string deger;

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                fico = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo f in fico)
                {
                    comboBox2.Items.Add(f.Name);
                    comboBox2.SelectedIndex = 0;
                }
                vcd = new VideoCaptureDevice(fico[comboBox2.SelectedIndex].MonikerString);
                vcd.NewFrame += Vcd_NewFrame;
                if (vcd == null)
                {
                    vcd.Start();
                    timer2.Start();
                }
                else
                {
                    vcd.Start();
                    timer2.Start();
                }

            }
            catch (Exception)
            {

            }


            comboBox1.Text = Properties.Settings.Default["kullaniciadi"].ToString();
            textBox1.Text = Properties.Settings.Default["sifre"].ToString();
            if (comboBox1.Text.Count() > 1)
            {
                comboBox1.Items.Clear();
                SqlDataReader oku;
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = " select * from U_Kadro_Plani where online='0' order by adi_soyadi asc ";
                oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    comboBox1.Items.Add(oku[2].ToString());
                }
            }
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            const string message ="UYGULAMAYI KAPATMAK İSTEDİĞİNİZE EMİN MİSİNİZ?";
            const string caption = "Uygulama Kapatılıyor";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);


            if (result == DialogResult.Yes)
            {

                //e.Cancel = true;
                Environment.Exit(0);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (vcd == null)
                {

                }
                else
                {
                    timer2.Stop();
                    vcd.Stop();
                }
            }
            catch
            {
                MessageBox.Show("kameranız yok");
            }
            baglan.Open();
            SqlCommand idari = new SqlCommand("select * from U_Kadro_Plani where adi_soyadi='" + comboBox1.Text + "'and term_parola='" + textBox1.Text + "'", baglan);

            //string sql = "select * from U_Kadro_Plani where adi_soyadi='" + comboBox1.Text + "'and term_parola='" + textBox1.Text + "'";
            SqlParameter prm1 = new SqlParameter("adi_soyadi", comboBox1.Text.ToString());
            SqlParameter prm2 = new SqlParameter("term_parola", textBox1.Text.ToString());

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(idari);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string yetki = dt.Rows[0]["kadro_adi"].ToString();

                if (yetki == "İDARİ")
                {
                    giris.ActiveForm.Hide();
                    deger = comboBox1.Text.ToUpper();
                    IDARI fr5 = new IDARI();
                    fr5.kullanici = deger;
                    fr5.Show();
                    baglan.Close();
                }
                else if (yetki == "KALİTE KONTROL")
                {
                    giris.ActiveForm.Hide();
                    deger = comboBox1.Text.ToUpper();
                    Form9 fr9 = new Form9();
                    fr9.kullanici = deger;
                    fr9.d_buton4.Visible = false;
                    fr9.talep = "0";
                    fr9.Show();
                    baglan.Close();
                }
                else if (yetki == "PRESHANE" || yetki == "KAYNAKHANE")
                {
                    SqlCommand mes = new SqlCommand(" select * from uretim_kayit where operator_id='" + comboBox1.Text + "' and durum='AKTİF'", mes_baglan);
                    mes_baglan.Open();

                    SqlDataReader drd = mes.ExecuteReader();
                    if (drd.Read())
                    {
                        DialogResult emir = MessageBox.Show("AKTİF BİR İŞ EMİRİNİZ BULUMAKTADIR. KAPATMAK İSTER MİSİNİZ?", "DİKKAT", MessageBoxButtons.YesNo);
                        if (emir == DialogResult.Yes)
                        {
                            detayekrani.ActiveForm.Hide();
                            try
                            {
                                if (vcd == null)
                                {

                                }
                                else
                                {
                                    vcd.Stop();
                                }
                            }
                            catch (Exception)
                            {

                            }
                            Form3 FR3 = new Form3();
                            FR3.timer1.Start();

                            FR3.label2.Text = drd["operator_id"].ToString();
                            FR3.label4.Text = drd["is_emri_no"].ToString();
                            FR3.label23.Text = drd["rota_no"].ToString();
                            FR3.label26.Text = drd["operasyon_no"].ToString();
                            FR3.label8.Text = drd["stok_kodu"].ToString();
                            FR3.label14.Text = drd["stok_adi"].ToString();
                            FR3.label6.Text = drd["kalip_id"].ToString();
                            FR3.label12.Text = drd["istasyon_kodu"].ToString();
                            FR3.label25.Text = drd["operasyon_adi"].ToString();
                            FR3.label20.Text = drd["kalanmiktar"].ToString();
                            FR3.label17.Text = drd["bas_tarih"].ToString();

                            FR3.BackColor = Color.Green;
                            FR3.Show();
                        }
                        else
                        {

                            giris.ActiveForm.Hide();
                            detayekrani fr = new detayekrani();
                            deger = comboBox1.Text.ToUpper();
                            fr.textBox2.Texts = deger;
                            fr.es_zamanlı = "EVET";
                            fr.Show();
                            baglan.Close();
                        }
                       
                    }
                    else
                    {
                        giris.ActiveForm.Hide();
                        detayekrani fr = new detayekrani();
                        deger = comboBox1.Text.ToUpper();
                        fr.textBox2.Texts = deger;
                        fr.es_zamanlı = "HAYIR";
                        fr.Show();
                        baglan.Close();

                    }
                }
            }
            else
            {
                MessageBox.Show("Hatalı veya eksik giriş yaptınız.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglan.Close();
            }

            Properties.Settings.Default["kullaniciadi"] = comboBox1.Text;
            Properties.Settings.Default["sifre"] = textBox1.Text;
            Properties.Settings.Default.Save();

            baglan.Close();

        }
    private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            {
                //checkBox işaretli ise
                if (checkBox1.Checked)
                {
                    //karakteri göster.
                    textBox1.PasswordChar = '\0';
                }
                //değilse karakterlerin yerine * koy.
                else
                {
                    textBox1.PasswordChar = '*';
                }

            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Char.IsWhiteSpace(e.KeyChar);
        }

        private void Vcd_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader brd = new BarcodeReader();
                Result sonuc = brd.Decode((Bitmap)pictureBox1.Image);
                if(sonuc!= null)
                {
                    comboBox1.Text = sonuc.ToString();
                }
            }
        }
        private void giris_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        internal class erdbutton
        {
            internal class ERBUTTON
            {
                public Color BackColor { get; internal set; }
                public Color BorderColor { get; internal set; }
                public int BorderSize { get; internal set; }
                public int BorderRadius { get; internal set; }
                public object FlatAppearance { get; internal set; }
                public FlatStyle FlatStyle { get; internal set; }
                public Color ForeColor { get; internal set; }
                public Point Location { get; internal set; }
                public string Name { get; internal set; }
                public int TabIndex { get; internal set; }
                public Size Size { get; internal set; }
                public bool UseVisualStyleBackColor { get; internal set; }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            admin fr11 = new admin();
            fr11.talep = "0";
            fr11.Show();
            
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.BackColor = Color.Blue;
            label4.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
            label4.BackColor = Color.White;
        }

        private void d_buton1_Click(object sender, EventArgs e)
        {
            IDARI idari = new IDARI();
            idari.Show();
        }

        private void d_buton1_Click_1(object sender, EventArgs e)
        {
            IDARI idari = new IDARI();
            idari.Show();
        }
    }
}
