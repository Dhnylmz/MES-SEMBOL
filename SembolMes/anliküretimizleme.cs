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

namespace SembolMes
{
    public partial class anliküretimizleme : Form
    {
        public anliküretimizleme()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");

        private void d_buton5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 FR = new Form6();
            FR.Show();
        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 KYNK = new Form8();
            KYNK.Show();
        }

        private void d_buton5_Click_1(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("SELECT * FROM form_durum where form_acik='1' ", mes_baglan);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(kmt);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Açmak istediğiniz form şuan başka bir kullanıcıda aktif.\nLütfen daha sonra deneyiniz.");
            }
            else
            {
                try
                {
                    mes_baglan.Open();
                    SqlCommand kmta = new SqlCommand("update form_durum set form_acik='1' ", mes_baglan);
                    int sonuc = kmta.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        nodemcu nd = new nodemcu();
                        nd.Show();
                    }
                    else
                    {
                        MessageBox.Show("Hata");
                    }
                }
                catch
                {
                    
                }
            }
            mes_baglan.Close();
        }

        private void anliküretimizleme_Load(object sender, EventArgs e)
        {

        }

        private void d_buton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}