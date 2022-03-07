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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        public string talep;
       
        private void d_buton1_Click(object sender, EventArgs e)
        {
            if(rjTextBox1.Texts=="admin" && rjTextBox2.Texts=="3411" || rjTextBox1.Texts == "ADMİN" && rjTextBox2.Texts == "3411"|| rjTextBox1.Texts == "ADMIN" && rjTextBox2.Texts == "3411")
            {
                sunucuekran fr9 = new sunucuekran();
                fr9.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı");
            }            
        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (talep == "0")
            {
                System.Environment.Exit(0);
            }
            else if (talep == "1")
            {
                this.Hide();
            }
        }
    }
}
