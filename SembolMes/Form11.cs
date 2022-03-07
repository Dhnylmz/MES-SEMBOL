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
using System.Globalization;

namespace SembolMes
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlDataAdapter da;

        public string is_emri;
        public string rota_no;
        public string stok_kodu;
        public string op_no;
        public string SIRA_NO;
        public string kullanici;

        private void Form11_Load(object sender, EventArgs e)
        {
            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ",";

            try
            {
                baglan.Open();
                da = new SqlDataAdapter("select SIRA_NO,OLCU_OZELLIK, ISTENEN_OLCU, SERI_ONAY, OLCUM1, OLCUM2, OLCUM3, OLCUM4, OLCUM5, OLCUM6, OLCUM7 from KLT_PROCESS_KONTROL_KART where ISEMRI = '" + is_emri + "' and rota_no = '" + rota_no + "' and op_no = '" + op_no + "'", baglan);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglan.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglan.Close();
            }
            baglan.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            //string OLCU_OZELLIK = dataGridView1.CurrentRow.Cells["OLCU_OZELLIK"].Value.ToString();
            //string SIRA_NO = dataGridView1.Rows[secilialan].Cells["SIRA_NO"].Value.ToString();
            //string OLCUM1 = dataGridView1.Rows[secilialan].Cells["OLCUM1"].Value.ToString();
            //string OLCUM2 = dataGridView1.Rows[secilialan].Cells["OLCUM2"].Value.ToString();
            //string OLCUM3 = dataGridView1.Rows[secilialan].Cells["OLCUM3"].Value.ToString();
            //string OLCUM4 = dataGridView1.Rows[secilialan].Cells["OLCUM4"].Value.ToString();
            //string OLCUM5 = dataGridView1.Rows[secilialan].Cells["OLCUM5"].Value.ToString();
            //string OLCUM6 = dataGridView1.Rows[secilialan].Cells["OLCUM6"].Value.ToString();
            //string OLCUM7 = dataGridView1.Rows[secilialan].Cells["OLCUM7"].Value.ToString();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string OLCUM1, OLCUM2, OLCUM3, OLCUM4, OLCUM5, OLCUM6, OLCUM7;
            string OLCU_OZELLIK, SIRA_NO, SERI_ONAY;

            int secilialan = dataGridView1.SelectedCells[0].RowIndex;
            OLCU_OZELLIK = dataGridView1.CurrentRow.Cells["OLCU_OZELLIK"].Value.ToString();
            SIRA_NO = dataGridView1.CurrentRow.Cells["SIRA_NO"].Value.ToString();
            SERI_ONAY = dataGridView1.CurrentRow.Cells["SERI_ONAY"].Value.ToString();
            OLCUM1 = dataGridView1.CurrentRow.Cells["OLCUM1"].Value.ToString();
            OLCUM2 = dataGridView1.CurrentRow.Cells["OLCUM2"].Value.ToString().Replace(".", ",");
            OLCUM3 = dataGridView1.CurrentRow.Cells["OLCUM3"].Value.ToString().Replace(".", ",");
            OLCUM4 = dataGridView1.CurrentRow.Cells["OLCUM4"].Value.ToString().Replace(".", ",");
            OLCUM5 = dataGridView1.CurrentRow.Cells["OLCUM5"].Value.ToString().Replace(".", ",");
            OLCUM6 = dataGridView1.CurrentRow.Cells["OLCUM6"].Value.ToString().Replace(".", ",");
            OLCUM7 = dataGridView1.CurrentRow.Cells["OLCUM7"].Value.ToString().Replace(".", ",");


            try
            {
                baglan.Open();
                SqlCommand dt = new SqlCommand(" update KLT_PROCESS_KONTROL_KART set SERI_ONAY='" + SERI_ONAY + "',OLCUM1=@OLCUM1 , OLCUM2=@OLCUM2, OLCUM3=@OLCUM3, OLCUM4=@OLCUM4, OLCUM5=@OLCUM5, OLCUM6=@OLCUM6, OLCUM7=@OLCUM7  where ISEMRI = '" + is_emri + "' and rota_no = '" + rota_no + "' and op_no = '" + op_no + "'and SIRA_NO='" + SIRA_NO + "'", baglan);
                dt.Parameters.AddWithValue("@OLCUM1", Convert.ToDecimal(OLCUM1.ToString()));
                dt.Parameters.AddWithValue("@OLCUM2", Convert.ToDecimal(OLCUM2.ToString()));
                dt.Parameters.AddWithValue("@OLCUM3", Convert.ToDecimal(OLCUM3.ToString()));
                dt.Parameters.AddWithValue("@OLCUM4", Convert.ToDecimal(OLCUM4.ToString()));
                dt.Parameters.AddWithValue("@OLCUM5", Convert.ToDecimal(OLCUM5.ToString()));
                dt.Parameters.AddWithValue("@OLCUM6", Convert.ToDecimal(OLCUM6.ToString()));
                dt.Parameters.AddWithValue("@OLCUM7", Convert.ToDecimal(OLCUM7.ToString()));
                int sonuc=dt.ExecuteNonQuery();

                baglan.Close();
                if (sonuc > 0)
                {
                    if (SERI_ONAY == "True")
                    {
                        mes_baglan.Open();
                        SqlCommand komut = new SqlCommand("update uretim_kayit set klt_onay='" + SERI_ONAY + "',klt_onaylayan='" + kullanici.ToString() + "' where is_emri_no='" + is_emri + "' and rota_no='" + rota_no + "' and operasyon_no='" + op_no + "' ", mes_baglan);
                        komut.ExecuteNonQuery();
                        int snc1 = komut.ExecuteNonQuery();
                        if (snc1 > 0)
                        {
                            mes_baglan.Close();
                        }
                    }
                    else if (SERI_ONAY == "False")
                    {
                        mes_baglan.Open();
                        SqlCommand komut = new SqlCommand("update uretim_kayit set klt_onay='" + SERI_ONAY + "',klt_onaylayan='NULL' where is_emri_no='" + is_emri + "' and rota_no='" + rota_no + "' and operasyon_no='" + op_no + "' ", mes_baglan);
                        komut.ExecuteNonQuery();
                        int snc1 = komut.ExecuteNonQuery();
                        if (snc1 > 0)
                        {
                            mes_baglan.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("İŞ EMRİNİ YÖNETİCİNİZE BİLDİRİNİZ.");
                        mes_baglan.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("HATA. LÜTFEN YÖNETİCİYE BAŞVURUN.");
                mes_baglan.Close();
            }
        }

        private void Form11_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox innerTextBox;

            if (e.Control is TextBox)
            {

                innerTextBox = e.Control as TextBox;

                innerTextBox.KeyPress += new KeyPressEventHandler(innerTextBox_KeyPress);
            }
        }
        private void innerTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber((char)e.KeyChar) || e.KeyChar <= ',')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}