using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net;

namespace SembolMes
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            robot();
        }

        private void robot()
        {
            WebRequest SiteyeBaglantiTalebi = HttpWebRequest.Create("http://192.168.1.20/MD/NUMREG.VA");

            SiteyeBaglantiTalebi.Timeout = 300;

            try
            {

                WebResponse GelenCevap = SiteyeBaglantiTalebi.GetResponse();

                StreamReader CevapOku = new StreamReader(GelenCevap.GetResponseStream());

                string KaynakKodlar = CevapOku.ReadToEnd();

                int IcerikBaslangicIndex = KaynakKodlar.IndexOf("<PRE>") + 575;

                int IcerikBitisIndex = KaynakKodlar.Substring(IcerikBaslangicIndex).IndexOf("</PRE>") - 3153;

                string KaynakKodları = KaynakKodlar.Substring(IcerikBaslangicIndex, IcerikBitisIndex);

                 label25.Text = KaynakKodları;

            }
            catch (WebException)
            {
                label25.Text = ("KAPALI");

            }
        }
    }

    
}
