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
using System.IO;

namespace SembolMes
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();

        }
        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        SqlDataAdapter da;
        public string kullanici;
        public string talep;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1.Text = DateTime.Now.ToString("F");
        }

        
        private void Form9_Load(object sender, EventArgs e)
        {
            timer1.Start();
            verigetir();
        }

        public void verigetir()
        {
            mes_baglan.Open();
            da = new SqlDataAdapter("SELECT is_emri_no,rota_no,operasyon_no,operasyon_adi,operator_id, istasyon_kodu,stok_kodu,stok_adi FROM uretim_kayit where durum='aktif'", mes_baglan);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            mes_baglan.Close();
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string is_emri = dataGridView1.Rows[secilialan].Cells["is_emri_no"].Value.ToString();
            string rota_no = dataGridView1.Rows[secilialan].Cells["rota_no"].Value.ToString();
            string stok_kodu = dataGridView1.Rows[secilialan].Cells["stok_kodu"].Value.ToString();
            string op_no = dataGridView1.Rows[secilialan].Cells["operasyon_no"].Value.ToString();


            if (dataGridView1.Columns[e.ColumnIndex].Name == "teknikresim")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from KLT_OPERASYON_KONTROL_KARTI WHERE STOK_KODU='" + stok_kodu.ToString() + "' AND ROTA_NO='" + rota_no.ToString() + "' AND OP_NO='" + op_no.ToString() + "'", baglan);
                SqlDataReader dt = komut.ExecuteReader();
                if (dt.Read())
                {
                    try
                    {
                        if (dt["RESIM"] != null)
                        {
                            Form10 fr11 = new Form10();
                            byte[] resim = new byte[0];
                            resim = (byte[])dt["RESIM"];
                            MemoryStream ms = new MemoryStream(resim);
                            fr11.pictureBox1.Image = Image.FromStream(ms);
                            dt.Close();
                            komut.Dispose();
                            baglan.Close();
                            fr11.Show();
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Teknik resim bulunamadı");
                    }
                }
                baglan.Close();

            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Proses")
            {
                Form11 fr11 = new Form11();
                fr11.is_emri = dataGridView1.Rows[secilialan].Cells["is_emri_no"].Value.ToString();
                fr11.rota_no = dataGridView1.Rows[secilialan].Cells["rota_no"].Value.ToString();
                fr11.stok_kodu = dataGridView1.Rows[secilialan].Cells["stok_kodu"].Value.ToString();
                fr11.op_no = dataGridView1.Rows[secilialan].Cells["operasyon_no"].Value.ToString();
                fr11.kullanici = kullanici;
                fr11.Show();
            }
        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (talep == "1")
            {
                Form9.ActiveForm.Hide();
            }
            else if (talep == "0")
            {
                System.Environment.Exit(0);
            }
        }

        private void d_buton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(rjTextBox1.Texts) == false)
                {
                    baglan.Open();
                    da = new SqlDataAdapter("SELECT is_emri_no,rota_no,operasyon_no,operasyon_adi,operator_id, istasyon_kodu,stok_kodu,stok_adi FROM uretim_kayit where is_emri_no='" + rjTextBox1.Texts.ToString() + "' and durum='aktif' and klt_onay=0", mes_baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();
                }
                else
                {
                    baglan.Open();
                    da = new SqlDataAdapter("SELECT is_emri_no,rota_no,operasyon_no,operasyon_adi,operator_id, istasyon_kodu,stok_kodu,stok_adi FROM uretim_kayit where durum='aktif' and klt_onay=0", mes_baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    baglan.Close();
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglan.Close();
            }
            baglan.Close();
        }

        private void toogle_buton1_CheckedChanged(object sender, EventArgs e)
        {
            if (toogle_buton1.Checked == true)
            {
                mes_baglan.Open();
                da = new SqlDataAdapter("SELECT is_emri_no,rota_no,operasyon_no,operasyon_adi,operator_id, istasyon_kodu,stok_kodu,stok_adi FROM uretim_kayit where durum='aktif' and klt_onay=0", mes_baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                mes_baglan.Close();
            }
            else if (toogle_buton1.Checked == false)
            {
                mes_baglan.Open();
                da = new SqlDataAdapter("SELECT is_emri_no,rota_no,operasyon_no,operasyon_adi,operator_id, istasyon_kodu,stok_kodu,stok_adi FROM uretim_kayit where durum='aktif'", mes_baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                mes_baglan.Close();
            }
        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void d_buton2_Click(object sender, EventArgs e)
        {
            Form9.ActiveForm.Hide();
            ArizaBakim arz = new ArizaBakim();
            arz.talep = "0";
            arz.personel = kullanici;
            arz.Show();
        }
    }
}