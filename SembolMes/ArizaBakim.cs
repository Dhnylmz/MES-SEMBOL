using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;

namespace SembolMes
{
    public partial class ArizaBakim : Form
    {
        public ArizaBakim()
        {
            InitializeComponent();
        }

        public string talep;

        FilterInfoCollection fico;
        VideoCaptureDevice vcd;

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        public string personel;
        private void ArizaBakim_Load(object sender, EventArgs e)
        {
            try
            {
                fico = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo f in fico)
                {
                    comboBox1.Items.Add(f.Name);
                    comboBox1.SelectedIndex = 0;
                }
                vcd = new VideoCaptureDevice(fico[comboBox1.SelectedIndex].MonikerString);
                vcd.NewFrame += Vcd_NewFrame;
                if (vcd == null)
                {
                    vcd.Start();
                    timer1.Start();
                }
                else
                {
                    vcd.Start();
                    timer1.Start();
                }

            }
            catch (Exception)
            {

            }
        }
        private void Vcd_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stok_kodu;
            baglan.Open();
            SqlDataAdapter bak = new SqlDataAdapter("select STOK_KODU from U_Uretim_YM_isemri where ur_emri_no='" + textBox1.Text + "' ", baglan);
            DataTable drd = new DataTable();
            bak.Fill(drd);
            if (drd.Rows.Count > 0)
            {
                stok_kodu = drd.Rows[0]["stok_kodu"].ToString();
                if (string.IsNullOrEmpty(stok_kodu))
                {
                    MessageBox.Show("hata");
                }
                else
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT A.KALIP_ID,A.STOK_KODU,B.ACIKLAMA FROM dbo.U_KalipStokListesi AS A INNER JOIN dbo.U_KalipKarti AS b WITH (nolock) ON A.KALIP_ID = b.ID WHERE A.STOK_KODU='" + stok_kodu + "' GROUP BY A.STOK_KODU,B.ACIKLAMA,A.KALIP_ID,b.KAYIT_ID", baglan);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            baglan.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            string kalip_id = dataGridView1.Rows[secilialan].Cells["KALIP_ID"].Value.ToString();

            if (dataGridView1.Columns[e.ColumnIndex].Name == "SEC")
            {
                MailForm.Instance.Show();
                MailForm.Instance.label5.Text = kalip_id;
                MailForm.Instance.label3.Text = personel;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BarcodeReader brd = new BarcodeReader();
                Result sonuc = brd.Decode((Bitmap)pictureBox1.Image);
                if (sonuc != null)
                {
                    //textBox1.Text = sonuc.ToString();

                    string kod = sonuc.ToString();
                    string[] parcala1;
                    string yeni2;

                    parcala1 = kod.Split('/');
                    yeni2 = parcala1[0];
                    textBox1.Text = yeni2;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                vcd = new VideoCaptureDevice(fico[comboBox1.SelectedIndex].MonikerString);
                vcd.NewFrame += Vcd_NewFrame;
                if (vcd == null)
                {
                    vcd.Start();
                    timer1.Start();
                }
                else
                {
                    vcd.Start();
                    timer1.Start();
                }

            }
            catch (Exception)
            {

            }
        }

        private void ArizaBakim_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (talep == "1")
            {
                ArizaBakim.ActiveForm.Hide();
                detayekrani fr2 = new detayekrani();
                fr2.Show();
            }
            else if(talep == "0")
            {
                ArizaBakim.ActiveForm.Hide();
                Form9 fr9 = new Form9();
                fr9.Show();
            }
        }
    }
}