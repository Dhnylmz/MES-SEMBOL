using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SembolMes
{
    public partial class IDARI : Form
    {
        public IDARI()
        {
            InitializeComponent();
            tasarım();
        }
        public string kullanici;
        private void IDARI_Load(object sender, EventArgs e)
        {
            label1.Text = kullanici;
        }
        private void tasarım()
        {
            panel3Submenu.Visible = false;
            panel4Submenu.Visible = false;
            panel5Submenu.Visible = false;
            panel6Submenu.Visible = false;
            panel7Submenu.Visible = false;
            panel8Submenu.Visible = false;
        }
        private void hidesubmenu()
        {
            if (panel3Submenu.Visible == true)
                panel3Submenu.Visible = false;

            if (panel4Submenu.Visible == true)
                panel4Submenu.Visible = false;

            if (panel5Submenu.Visible == true)
                panel5Submenu.Visible = false;

            if (panel6Submenu.Visible == true)
                panel6Submenu.Visible = false;

            if (panel7Submenu.Visible == true)
                panel7Submenu.Visible = false;

            if (panel8Submenu.Visible == true)
                panel8Submenu.Visible = false;
        }
        private void showsubmenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hidesubmenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void d_buton1_Click(object sender, EventArgs e)
        {
            showsubmenu(panel3Submenu);
        }

        private void d_buton2_Click(object sender, EventArgs e)
        {
           // openChildForm(new ISEMRIDÜZENLEME());

            ISEMRIDÜZENLEME frm20 = new ISEMRIDÜZENLEME();
            frm20.Show();
        }

        private void d_buton3_Click(object sender, EventArgs e)
        {
            openChildForm(new anliküretimizleme());

            //anliküretimizleme frm21 = new anliküretimizleme();
            //frm21.Show();
        }

        private void d_buton4_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton5_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton6_Click(object sender, EventArgs e)
        {
            showsubmenu(panel4Submenu);
        }

        private void d_buton10_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton9_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton8_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton7_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton11_Click(object sender, EventArgs e)
        {
            showsubmenu(panel5Submenu);
        }

        private void d_buton15_Click(object sender, EventArgs e)
        {
            //openChildForm(new Form9());
            Form9 frm26 = new Form9();
            frm26.kullanici = kullanici;
            frm26.talep = "1";
            frm26.Show();
        }

        private void d_buton14_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton13_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton12_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton16_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton17_Click(object sender, EventArgs e)
        {
            
        }

        private void d_buton18_Click(object sender, EventArgs e)
        {
            
        }
        private void d_buton20_Click(object sender, EventArgs e)
        {
            showsubmenu(panel6Submenu);
        }

        private void d_buton25_Click(object sender, EventArgs e)
        {
            showsubmenu(panel7Submenu);
        }

        private void d_buton30_Click(object sender, EventArgs e)
        {
            showsubmenu(panel8Submenu);
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void closeChildForm()
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private void d_buton31_Click(object sender, EventArgs e)
        {
            hidesubmenu();
        }

        private void d_buton32_Click(object sender, EventArgs e)
        {
            const string message ="UYGULAMAYI KAPATMAK İSTEDİĞİNİZE EMİN MİSİNİZ?";
            const string caption = "Uygulama Kapatılıyor";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);


            if (result == DialogResult.Yes)
            {

                //e.Cancel = true;
                Environment.Exit(0);

            }
        }

        private void d_buton19_Click(object sender, EventArgs e)
        {
            //openChildForm(new OPERATÖR_RAPORU());

            OPERATÖR_RAPORU frm22 = new OPERATÖR_RAPORU();
            frm22.Show();
        }

        private void d_buton18_Click_1(object sender, EventArgs e)
        {
         //   openChildForm(new ÜRETİMRAPORU());

            ÜRETİMRAPORU frm23 = new ÜRETİMRAPORU();
            frm23.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //panelChildForm.Controls.Clear();
            closeChildForm();
        }

        private void d_buton17_Click_1(object sender, EventArgs e)
        {

        }

        private void d_buton24_Click(object sender, EventArgs e)
        {

        }

        private void d_buton23_Click(object sender, EventArgs e)
        {

        }

        private void d_buton29_Click(object sender, EventArgs e)
        {
            admin fr98 = new admin();
            fr98.talep = "1";
            fr98.Show();
        }
    }
}
