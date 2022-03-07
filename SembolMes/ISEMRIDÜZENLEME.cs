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
    public partial class ISEMRIDÜZENLEME : Form
    {
        public ISEMRIDÜZENLEME()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlCommand komut = new SqlCommand();

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

        private void d_buton4_Click_1(object sender, EventArgs e)
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

        private void ISEMRIDÜZENLEME_Load(object sender, EventArgs e)
        {

        }

        private void d_buton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
