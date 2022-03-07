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

namespace SembolMes
{
    public partial class firefisi : Form
    {
        public firefisi()
        {
            InitializeComponent();
        }

        //SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        //SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlCommand hata = new SqlCommand();

        private void firefisi_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Clear();
            //SqlDataReader ist;
            //baglan.Open();
            //hata.Connection = baglan;
            //hata.CommandText = " select * from KLT_KKNT_HATA_TANIM ";
            //ist = hata.ExecuteReader();
            //while (ist.Read())
            //{
            //    comboBox1.Items.Add(ist["acıklama"].ToString());

            //}
            //baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////SqlConnection con = new SqlConnection("Server=DESKTOP-BSM8ICL\\SQLEXPRESS; Database=SEMBOL_20; User Id=sa; Password=240305;");
            //SqlConnection con = new SqlConnection(" Server=192.168.1.44;Database=SEM_20;User Id=hbs;Password=240305;");
            //SqlCommand cmd = new SqlCommand();
            //con.Open();
            //cmd.Connection = con;
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "sp_Oto_IsEmrindenUretimFisi";
            //cmd.Parameters.Add("IsEmriNo", SqlDbType.VarChar, 50).Value = label4.Text;
            //cmd.Parameters.Add("UretimMik", SqlDbType.Float).Value = textBox1.Text;
            //cmd.Parameters.Add("UserCode", SqlDbType.VarChar).Value = label2.Text;
            //cmd.Parameters.Add("Tarih", SqlDbType.DateTime).Value = DateTime.Now;
            //cmd.Parameters.Add("islemYeriTipi", SqlDbType.SmallInt).Value = 2;
            //cmd.Parameters.Add("islemFisID", SqlDbType.BigInt).Value = 0;
            //cmd.Parameters.Add("RecDetIslemYeriTipi", SqlDbType.TinyInt).Value = 0;
            //cmd.Parameters.Add("DepoKodu", SqlDbType.VarChar, 30).Value = default;

            //int snc2 = cmd.ExecuteNonQuery();
            //if (snc2 > 0)
            //{
            //    MessageBox.Show("İŞ EMRİ TAMAMLANDI");
            //    baglan.Close();

            //}

            //else
            //{
            //    MessageBox.Show("İŞ EMRİ AKTARIMINDA HATA OLUŞTU.TEKRAR DENEYİNİZ");
            //}
            //con.Close();

            //firefisi.ActiveForm.Hide();
            //Form3.ActiveForm.Show();
        }
    }
}
