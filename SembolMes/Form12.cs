using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SembolMes
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        private static Form12 instance;
        public static Form12 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Form12();
                }
                return instance;
            }
        }
        private void d_buton1_Click(object sender, EventArgs e)
        {
            if (rjRadioButton1.Checked == true)
            {
                try
                {
                    MailMessage mesajim = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("itasgeyen@sembolotomotiv.com.tr", "iT155*+*");
                    istemci.Port = 587;
                    istemci.Host = "mail.sembolotomotiv.com.tr";
                    mesajim.To.Add("itasgeyen@sembolotomotiv.com.tr");
                    mesajim.From = new MailAddress("itasgeyen@sembolotomotiv.com.tr");
                    mesajim.Subject = rjRadioButton1.Text;
                    mesajim.Body = "Merhaba Ben " + textBox2.Text + ", " + textBox1.Text;
                    istemci.Send(mesajim);
                    MessageBox.Show("Mesajınız başarıyla gönderildi.");
                    textBox2.Clear();
                    textBox1.Clear();
                    rjRadioButton2.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Mesajınız gönderilemedi.");
                }

            }
            else if (rjRadioButton2.Checked == true)
            {
                try
                {
                    MailMessage mesajim = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("itasgeyen@sembolotomotiv.com.tr", "iT155*+*");
                    istemci.Port = 587;
                    istemci.Host = "mail.sembolotomotiv.com.tr";
                    mesajim.To.Add("itasgeyen@sembolotomotiv.com.tr");
                    mesajim.From = new MailAddress("itasgeyen@sembolotomotiv.com.tr");
                    mesajim.Subject = rjRadioButton2.Text;
                    mesajim.Body = "Merhaba Ben " + textBox2.Text + ", " + textBox1.Text;
                    istemci.Send(mesajim);
                    MessageBox.Show("Mesajınız başarıyla gönderildi.");
                    textBox2.Clear();
                    textBox1.Clear();
                    rjRadioButton2.Checked = false;
                }
                catch
                {
                    MessageBox.Show("Mesajınız gönderilemedi.");
                }


            }
            else
            {
                MessageBox.Show("Lütfen herhangi bir talep seçiniz.");
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            rjRadioButton1.Checked = false;
            rjRadioButton2.Checked = false;
        }

        private void Form12_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form12.ActiveForm.Hide();
            detayekrani dt = new detayekrani();
            dt.Show();
        }
    }
}
