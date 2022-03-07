using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace SembolMes
{
    public partial class detayekrani : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]//kenar radusleri için
        private static extern IntPtr CreateRoundRectRgn
            (
            int nlefRect,
            int ntopRect,
            int rightRect,
            int nbottomRect,
            int nwidhtEllipse,
            int nheightEllipse
            );

        public detayekrani()
        {
            InitializeComponent();
        }

        public FilterInfoCollection fico;
        public VideoCaptureDevice vcd;

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlCommand komut = new SqlCommand();
        
        public string deger2;
        public string es_zamanlı;
        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox1.Width, pictureBox1.Height, 50, 50));
            panel2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 50, 50));
            
           

            fico = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo f in fico)
            {
                comboBox3.Items.Add(f.Name);
                comboBox3.SelectedIndex = 0;
            }

            try
            {
                vcd = new VideoCaptureDevice(fico[comboBox3.SelectedIndex].MonikerString);
                vcd.NewFrame += Vcd_NewFrame;
                vcd.Start();
                timer1.Start();
            }
            catch
            {

            }

            deger2 = textBox2.Texts.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string kod = textBox1.Texts;
            string kod1 = label17.Text;
            string[] parcala1;
            string yeni2;

            parcala1 = kod.Split('-');
            yeni2 = parcala1[1];

            if (string.IsNullOrEmpty(yeni2) == true)
            {
                comboBox2.Items.Clear();
                MessageBox.Show("İŞ EMRİ BOŞ BIRAKILAMAZ","DİKKAT EN BÜYÜK BEŞİKTAŞ",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
            else 
            {

                SqlCommand idari = new SqlCommand("select * from U_Kadro_Plani where adi_soyadi='" + textBox2.Texts.ToString() + "'", baglan);
                DataTable bolüm = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(idari);
                da.Fill(bolüm);
                if (bolüm.Rows.Count > 0)
                {
                    string yetki = bolüm.Rows[0]["kadro_adi"].ToString();

                    if (yetki == "PRESHANE")
                    {
                        comboBox2.Items.Clear();
                        SqlDataReader ist;
                        baglan.Open();
                        komut.Connection = baglan;
                        komut.CommandText = "select ps_kodu + ' /  ' + ps_adi as ist from U_Uretim_istasyon_karti where alan_3='PRESHANE' order by ps_kodu asc ";
                        ist = komut.ExecuteReader();
                        while (ist.Read())
                        {
                            comboBox2.Items.Add(ist["ist"].ToString());
                        }
                    }
                    else if (yetki == "KAYNAKHANE")
                    {
                        comboBox2.Items.Clear();
                        SqlDataReader ist;
                        baglan.Open();
                        komut.Connection = baglan;
                        komut.CommandText = "select ps_kodu + ' /  ' + ps_adi as ist from U_Uretim_istasyon_karti where alan_3='KAYNAK-PUNTA' order by ps_kodu asc ";
                        ist = komut.ExecuteReader();
                        while (ist.Read())
                        {
                            comboBox2.Items.Add(ist["ist"].ToString());
                        }
                    }
                    baglan.Close();
                }

                string ayır = textBox1.Texts;
                string ayır2 = label17.Text;
                string[] parcala;


                SqlCommand mes = new SqlCommand(" select * from vwaktif_emir where ist_is_emri='" +textBox1.Texts + "' and durum='AKTİF'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader drd = mes.ExecuteReader();
                if (drd.Read())
                {

                    detayekrani.ActiveForm.Hide();
                    try
                    {
                        if (vcd == null)
                        {

                        }
                        else
                        {
                            timer1.Stop();
                            vcd.Stop();
                        }
                    }
                    catch (Exception)
                    {

                    }
                    Form3 FR3 = new Form3();
                    FR3.timer1.Start();

                    parcala = ayır.Split('/', '/');
                    FR3.label4.Text = parcala[0];
                    FR3.label23.Text = parcala[1];



                    FR3.label2.Text = drd["operator_id"].ToString();
                    FR3.label8.Text = drd["stok_kodu"].ToString();
                    FR3.label14.Text = drd["stok_adi"].ToString();
                    FR3.label12.Text = drd["istasyon_kodu"].ToString();
                    FR3.label20.Text = drd["kalanmiktar"].ToString();
                    FR3.label17.Text = drd["bas_tarih"].ToString();
                    FR3.label26.Text = drd["operasyon_no"].ToString();
                    FR3.label25.Text = drd["operasyon_adi"].ToString();
                    FR3.label6.Text = drd["kalip_id"].ToString();

                    FR3.BackColor = Color.Green;
                    FR3.Show();

                }
                else 
                {
                    SqlCommand bak = new SqlCommand("select * from vwAktifIsEmriIstDetayli where IST_IS_EMRI='" + textBox1.Texts + "' ", baglan);
                    baglan.Open();

                    SqlDataReader dr = bak.ExecuteReader();
                    if (dr.Read())
                    {
                       
                        parcala = ayır.Split('/');
                        label9.Text = parcala[0];
                        label24.Text = parcala[1];
                        label8.Text = parcala[2];
                        label10.Text = dr["kalip_id"].ToString();
                        label11.Text = dr["stok_kodu"].ToString();
                        label12.Text = dr["STOK_ACIKLAMASI"].ToString();
                        label13.Text = dr["IST_KODU"].ToString();
                        label17.Text = dr["KalanMiktar"] + " ADET".ToString();
                        label21.Text = dr["op_adi"].ToString();
                    }

                    else
                    {
                        MessageBox.Show("İŞ EMRİ BULUNAMADI", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                baglan.Close();
                mes_baglan.Close();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(label9.Text) == true || string.IsNullOrEmpty(textBox1.Texts) == true)
            {
                MessageBox.Show("İŞ EMRİ BOŞ BIRAKILAMAZ", "DİKKAT EN BÜYÜK BEŞİKTAŞ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ayır2 = label17.Text;
                string[] parcala; Form7 form7 = new Form7();

                parcala = ayır2.Split('A');
                form7.es_zamanlı = es_zamanlı;
                form7.label9.Text = label9.Text.ToString();
                form7.label21.Text = label21.Text.ToString();
                form7.label10.Text = label10.Text.ToString();
                form7.label13.Text = label13.Text.ToString();
                form7.label11.Text = label11.Text.ToString();
                form7.label17.Text = parcala[0];
                form7.label24.Text = label24.Text.ToString();
                form7.label12.Text = label12.Text.ToString();
                form7.label8.Text = label8.Text.ToString();
                form7.label3.Text = deger2;
                detayekrani.ActiveForm.Hide();
                try
                {
                    if (vcd == null)
                    {

                    }
                    else
                    {
                        timer1.Stop();
                        vcd.Stop();
                    }
                }
                catch (Exception)
                {

                }

                var frm7 = new Form7
                {
                    ShowInTaskbar = false,
                    MinimizeBox = false,
                    MaximizeBox = false

                };
                frm7.StartPosition = FormStartPosition.CenterParent;
                form7.ShowDialog();
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ayırma = comboBox2.SelectedItem.ToString();
            string[] prcl;
            prcl = ayırma.Split(' ');
            label13.Text = prcl[0];
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("İSTASYON SEÇİMİ YAPMADINIZ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                label13.Text = comboBox2.SelectedItem.ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsNumber((char)e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == (char)47 || e.KeyChar == (char)73 || e.KeyChar == (char)83 || e.KeyChar == (char)45 || e.KeyChar == (char)115)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Vcd_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label14.Text = DateTime.Now.ToString("F");

            if (pictureBox1.Image != null)
            {
                BarcodeReader brd = new BarcodeReader();
                Result sonuc = brd.Decode((Bitmap)pictureBox1.Image);
                if(sonuc!=null)
                {
                    textBox1.ResetText();
                    textBox1.Texts = sonuc.ToString();
                }
            }

        }

        private void detayekrani_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
        string personel;
        private void d_buton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (vcd == null)
                {

                }
                else
                {
                    timer1.Stop();
                    vcd.Stop();
                }
            }
            catch (Exception)
            {

            }

            detayekrani.ActiveForm.Hide();
            ArizaBakim arbk = new ArizaBakim();
            arbk.personel = textBox2.Texts.ToString();
            arbk.talep = "1";
            arbk.Show();
        }

        private void d_buton2_Click(object sender, EventArgs e)
        {
            detayekrani.ActiveForm.Hide();
            Form12.Instance.Show();
            try
            {

                if (vcd == null)
                {

                }
                else
                {
                    timer1.Stop();
                    vcd.Stop();
                }
            }
            catch
            {
                MessageBox.Show("kameranız yok");
            }
        }
    }
}