
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;


namespace SembolMes
{
    public partial class Form6 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]//kenar radusleri için
        private static extern IntPtr CreateRoundRectRgn
            (
            int nlefRect,
            int ntopRect,
            int rightRect,
            int nbottomRect,
            int nwidhtEllipse,
            int nheightEllipse
            );                                                    //kenar radusleri için


        public Form6()
        {
            InitializeComponent();
            menü();
        }

        #region HAMBURGER PANEL
        private void menü()
        {
            panel20.Visible = false;
            panel21.Visible = false;
            panel23.Visible = false;
        }
        private void menügizleme()
        {
            if (panel23.Visible == true)
                panel23.Visible = false;
            if (panel20.Visible == true)
                panel20.Visible = false;
            if (panel21.Visible == true)
                panel21.Visible = false;
        }

        private void menüaçma (Panel submenu)
        {
            if (submenu.Visible == false)
            {
                menügizleme();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        private void d_buton4_Click(object sender, EventArgs e)
        {
            menüaçma(panel23);
        }
        private void d_buton4_MouseHover(object sender, EventArgs e)
        {
            menüaçma(panel23);
        }
        //private void button5_MouseLeave(object sender, EventArgs e)
        //{   
        //    menüaçma(panel20);
        //}
        private void d_buton1_Click(object sender, EventArgs e)
        {
            menüaçma(panel20);
        }
        private void d_buton1_MouseHover(object sender, EventArgs e)
        {
            menüaçma(panel20);
        }
        //private void button2_MouseLeave(object sender, EventArgs e)
        //{
        //    menüaçma(panel21);
        //}
        private void d_buton2_Click(object sender, EventArgs e)
        {
            menüaçma(panel21);
        }
        private void d_buton2_MouseHover(object sender, EventArgs e)
        {
            menüaçma(panel21);
        }
        //private void button1_MouseLeave(object sender, EventArgs e)
        //{
        //    menüaçma(panel19);
        //}

        #endregion

        SqlConnection baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        SqlConnection mes_baglan = new SqlConnection("Server='" + Properties.Settings.Default["server_sql"] + "'; Database='" + Properties.Settings.Default["database_mes_sql"] + "'; User Id='" + Properties.Settings.Default["user_id_sql"] + "'; Password='" + Properties.Settings.Default["password_sql"] + "';");
        
        SqlCommand komut = new SqlCommand();

        private void Form6_Load(object sender, EventArgs e)
        {
            
            GRPBX1EMRÇEKM();//anlık üretime veri çekme, 10 dakka sonra tekrar kodu çalıştırma
            GRPBX2EMRÇEKM();
            GRPBX3EMRÇEKM();
            GRPBX4EMRÇEKM();
            GRPBX5EMRÇEKM();
            GRPBX6EMRÇEKM();
            GRPBX7EMRÇEKM();
            GRPBX8EMRÇEKM();
            GRPBX9EMRÇEKM();
            GRPBX10EMRÇEKM();
            GRPBX11EMRÇEKM();
            GRPBX12EMRÇEKM();
            GRPBX13EMRÇEKM();
            GRPBX14EMRÇEKM();

            timer1.Start();
            timer2.Start();
                                 //kenar radusleri için
            groupBox1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox1.Width, groupBox1.Height, 30, 30));
            groupBox2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox2.Width, groupBox2.Height, 30, 30));
            groupBox3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox3.Width, groupBox3.Height, 30, 30));
            groupBox4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox4.Width, groupBox4.Height, 30, 30));
            groupBox5.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox5.Width, groupBox5.Height, 30, 30));
            groupBox6.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox6.Width, groupBox6.Height, 30, 30));
            groupBox7.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox7.Width, groupBox7.Height, 30, 30));
            groupBox8.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox8.Width, groupBox8.Height, 30, 30));
            groupBox9.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox9.Width, groupBox9.Height, 30, 30));
            groupBox10.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox10.Width, groupBox10.Height, 30, 30));
            groupBox11.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox11.Width, groupBox11.Height, 30, 30));
            groupBox12.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox12.Width, groupBox12.Height, 30, 30));
            groupBox13.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox13.Width, groupBox13.Height, 30, 30));
            groupBox14.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox14.Width, groupBox14.Height, 30, 30));
            groupBox15.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, groupBox15.Width, groupBox15.Height, 30, 30));
            panel23.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel23.Width, panel23.Height, 30, 30));
            panel20.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel20.Width, panel20.Height, 30, 30));
            panel21.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel21.Width, panel21.Height, 30, 30));
            //kenar radusleri için
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Goster1();
            Goster2();
            Goster3();
            Goster4();
            Goster5();
            Goster6();
            Goster7();
            Goster8();
            Goster9();
            Goster10();
            Goster11();
            Goster12();
            Goster13();
            Goster14();

            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            label136.Text = DateTime.Now.ToString("D");
        }

        #region Grupboxlara sayı verisi çekme
        public void Goster1()
        {
           

            try
            {                                                                                                   //circularProgressBar çalışması baş
               

                int a = Convert.ToInt32(label35.Text); //toplam is emir miktarı                                           
                int b = Convert.ToInt32(label2.Text); // anlık basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar1.Maximum = a;
                    circularProgressBar1.Minimum = 0;
                    circularProgressBar1.Step = 1;
                    circularProgressBar1.Value = b;
                    circularProgressBar1.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar1.Maximum = a;
                    circularProgressBar1.Minimum = 0;
                    circularProgressBar1.Step = 1;
                    circularProgressBar1.Value = b;
                    circularProgressBar1.Text = "%" + yuzde.ToString();
                }
                if  (yuzde > 80)
                {
                    circularProgressBar1.ProgressColor = Color.Red;
                }
                else if (yuzde > 50)
                {
                    circularProgressBar1.ProgressColor = Color.Yellow;
                }
                else 
                {
                    circularProgressBar1.ProgressColor = Color.Green;
                }
                                                                                                                 //circularProgressBar çalışması son

                if (timer1.Enabled == true)
                {
                    string dgr1;
                    dgr1 = groupBox1.Text.Replace('.', 'p');

                    MySqlConnection verigetir = new MySqlConnection("server ='"+Properties.Settings.Default["mysql_server"].ToString()+"'; user id = root; password= 1234; database='"+dgr1+"'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    //kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        groupBox1.BackColor = Color.PaleTurquoise;
                        panel1.Hide();
                        label2.Text = dr["adet"].ToString();
                        label2.ForeColor = Color.Black;


                    }
                    verigetir.Close();
                   
                }
            }
            catch (MySqlException)
            {
                panel1.Show();
                groupBox1.BackColor = ColorTranslator.FromHtml("#2596be");
            }

        }
        private void Goster2()
        {
            try
            {
                int a = Convert.ToInt32(label8.Text); //is emir miktarı
                int b = Convert.ToInt32(label11.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar2.Maximum = a;
                    circularProgressBar2.Minimum = 0;
                    circularProgressBar2.Step = 1;
                    circularProgressBar2.Value = b;
                    circularProgressBar2.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar2.Maximum = a;
                    circularProgressBar2.Minimum = 0;
                    circularProgressBar2.Step = 1;
                    circularProgressBar2.Value = b;
                    circularProgressBar2.Text = "%" + yuzde.ToString();
                }
                if (timer1.Enabled == true)
                {
                    string dgr2;
                    dgr2 = groupBox2.Text.Replace('.', 'p');

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr2 + "'; persistsecurityinfo=True; allowbatch=True; ");

                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel2.Hide();
                     groupBox2.BackColor = Color.PaleTurquoise;
                        label11.Text = dr["adet"].ToString();
                        label11.ForeColor = Color.Black;
                    }
                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel2.Show();
            }
        }
        private void Goster3()
        {
            
            
            try
            {
                int a = Convert.ToInt32(label18.Text); //is emir miktarı
                int b = Convert.ToInt32(label22.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar3.Maximum = a;
                    circularProgressBar3.Minimum = 0;
                    circularProgressBar3.Step = 1;
                    circularProgressBar3.Value = b;
                    circularProgressBar3.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar3.Maximum = a;
                    circularProgressBar3.Minimum = 0;
                    circularProgressBar3.Step = 1;
                    circularProgressBar3.Value = b;
                    circularProgressBar3.Text = "%" + yuzde.ToString();
                }

                if (timer1.Enabled == true)
                {
                    string dgr3;
                    dgr3 = groupBox3.Text.Replace('.', 'p');

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr3 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        groupBox3.BackColor = Color.PaleTurquoise;
                        panel3.Hide();
                        label22.Text = dr["adet"].ToString();
                        label22.ForeColor = Color.Black;
                    }
                    verigetir.Close();
                    
                }
            }
            catch (MySqlException)
            {
                panel3.Show();
            }

        }
        private void Goster4()
        {
            
            try
            {
                int a = Convert.ToInt32(label29.Text); //is emir miktarı
                int b = Convert.ToInt32(label32.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar4.Maximum = a;
                    circularProgressBar4.Minimum = 0;
                    circularProgressBar4.Step = 1;
                    circularProgressBar4.Value = b;
                    circularProgressBar4.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar4.Maximum = a;
                    circularProgressBar4.Minimum = 0;
                    circularProgressBar4.Step = 1;
                    circularProgressBar4.Value = b;
                    circularProgressBar4.Text = "%" + yuzde.ToString();
                }

                if (timer1.Enabled == true)
                {
                    string dgr4;
                    dgr4 = groupBox4.Text.Replace('.', 'p');

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr4 + "'; persistsecurityinfo=True; allowbatch=True; ");

                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    
                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        groupBox4.BackColor = Color.PaleTurquoise;
                        panel4.Hide();
                        label32.Text = dr["adet"].ToString();
                        label32.ForeColor = Color.Black;


                    }
                    verigetir.Close();

                }
            }
            catch (MySqlException)
            {
                panel4.Show();
                groupBox4.BackColor = ColorTranslator.FromHtml("#2596be");
            }
        }
        private void Goster5()
        {
            try
            {

                int a = Convert.ToInt32(label42.Text); //is emir miktarı
                int b = Convert.ToInt32(label45.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar5.Maximum = a;
                    circularProgressBar5.Minimum = 0;
                    circularProgressBar5.Step = 1;
                    circularProgressBar5.Value = b;
                    circularProgressBar5.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar5.Maximum = a;
                    circularProgressBar5.Minimum = 0;
                    circularProgressBar5.Step = 1;
                    circularProgressBar5.Value = b;
                    circularProgressBar5.Text = "%" + yuzde.ToString();
                }

                if (timer1.Enabled == true)
                {
                    string dgr5;
                    dgr5 = groupBox5.Text.Replace('.', 'p');

                    string istasyon = groupBox5.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr5 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        groupBox5.BackColor = Color.PaleTurquoise;
                        panel5.Hide();
                        label45.Text = dr["adet"].ToString();
                        label45.ForeColor = Color.Black;
                    }

                    //verigetir.Open();
                    //MySqlCommand drc = new MySqlCommand("Select * from sicaklik order by ID desc", verigetir);

                    //MySqlDataReader derece = drc.ExecuteReader();
                    //if (derece.Read())
                    //{
                    //   // label5.Text = derece["derece"] + "°C".ToString();
                    //}

                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel5.Show();
            }
        }
        private void Goster6()
        {
            
            try
            {
                int a = Convert.ToInt32(label52.Text); //is emir miktarı
                int b = Convert.ToInt32(label55.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar6.Maximum = a;
                    circularProgressBar6.Minimum = 0;
                    circularProgressBar6.Step = 1;
                    circularProgressBar6.Value = b;
                    circularProgressBar6.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar6.Maximum = a;
                    circularProgressBar6.Minimum = 0;
                    circularProgressBar6.Step = 1;
                    circularProgressBar6.Value = b;
                    circularProgressBar6.Text = "%" + yuzde.ToString();
                }

                if (timer1.Enabled == true)
                {
                    string dgr6;
                    dgr6 = groupBox6.Text.Replace('.', 'p');

                    string istasyon = groupBox6.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr6 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                   

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel6.Hide();
                        groupBox6.BackColor = Color.PaleTurquoise;
                        label55.Text = dr["adet"].ToString();
                        label55.ForeColor = Color.Black;
                    }
                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel6.Show();
            }
        }
        private void Goster7()
        {    
            try
            {
                int a = Convert.ToInt32(label62.Text); //is emir miktarı
                int b = Convert.ToInt32(label65.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar7.Maximum = a;
                    circularProgressBar7.Minimum = 0;
                    circularProgressBar7.Step = 1;
                    circularProgressBar7.Value = b;
                    circularProgressBar7.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar7.Maximum = a;
                    circularProgressBar7.Minimum = 0;
                    circularProgressBar7.Step = 1;
                    circularProgressBar7.Value = b;
                    circularProgressBar7.Text = "%" + yuzde.ToString();
                }

                if (yuzde > circularProgressBar7.Value)
                {
                    circularProgressBar7.ProgressColor = Color.Green;
                }
                else if (yuzde > circularProgressBar7.Value)
                {
                    circularProgressBar7.ProgressColor = Color.Yellow;
                    groupBox7.BackColor = Color.Red;
                }
                else
                {
                    //groupBox7.BackColor = Color.PaleTurquoise;
                }
                if (timer1.Enabled == true)
                {
                    string dgr7;
                    dgr7 = groupBox7.Text.Replace('.', 'p');

                    string istasyon = groupBox7.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr7 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel7.Hide();
                        groupBox7.BackColor = Color.PaleTurquoise;
                        label65.Text = dr["adet"].ToString();
                        label65.ForeColor = Color.Green;
                    }
                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel7.Show();
            }
        }
        private void Goster8()
        {
            
            try
            {
                int a = Convert.ToInt32(label72.Text); //is emir miktarı
                int b = Convert.ToInt32(label75.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar8.Maximum = a;
                    circularProgressBar8.Minimum = 0;
                    circularProgressBar8.Step = 1;
                    circularProgressBar8.Value = b;
                    circularProgressBar8.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar8.Maximum = a;
                    circularProgressBar8.Minimum = 0;
                    circularProgressBar8.Step = 1;
                    circularProgressBar8.Value = b;
                    circularProgressBar8.Text = "%" + yuzde.ToString();
                }

                if (timer1.Enabled == true)
                {
                    string dgr4;
                    dgr4 = groupBox8.Text.Replace('.', 'p');

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr4 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel8.Hide();
                        groupBox8.BackColor = Color.PaleTurquoise;
                        label75.Text = dr["adet"].ToString();
                        label75.ForeColor = Color.Green;
                    }
                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel8.Show();
            }
        }
        private void Goster9()
        {
            
            try
            {
                int a = Convert.ToInt32(label82.Text); //is emir miktarı
                int b = Convert.ToInt32(label85.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar9.Maximum = a;
                    circularProgressBar9.Minimum = 0;
                    circularProgressBar9.Step = 1;
                    circularProgressBar9.Value = b;
                    circularProgressBar9.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar9.Maximum = a;
                    circularProgressBar9.Minimum = 0;
                    circularProgressBar9.Step = 1;
                    circularProgressBar9.Value = b;
                    circularProgressBar9.Text = "%" + yuzde.ToString();
                }

                if (timer1.Enabled == true)
                {
                    string dgr9;
                    dgr9 = groupBox9.Text.Replace('.', 'p');

                    string istasyon = groupBox9.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr9 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                   // kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel9.Hide();
                        groupBox9.BackColor = Color.PaleTurquoise;
                        label85.Text = dr["adet"].ToString();
                        label85.ForeColor = Color.Black;
                    }

                    //MySqlCommand drc = new MySqlCommand("Select * from sicaklik order by ID desc", verigetir);

                    //MySqlDataReader derece = drc.ExecuteReader();
                    //if (derece.Read())
                    //{
                    //    //label5.Text = derece["derece"] + "°C".ToString();
                    //}

                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel9.Show();
            }
        }
        private void Goster10()
        {
            
            try
            {
                int a = Convert.ToInt32(label92.Text); //is emir miktarı
                int b = Convert.ToInt32(label95.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar10.Maximum = a;
                    circularProgressBar10.Minimum = 0;
                    circularProgressBar10.Step = 1;
                    circularProgressBar10.Value = b;
                    circularProgressBar10.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar10.Maximum = a;
                    circularProgressBar10.Minimum = 0;
                    circularProgressBar10.Step = 1;
                    circularProgressBar10.Value = b;
                    circularProgressBar10.Text = "%" + yuzde.ToString();
                }
                if (timer1.Enabled == true)
                {
                    string dgr10;
                    dgr10 = groupBox10.Text.Replace('.', 'p');

                    string istasyon = groupBox10.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr10 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                   // kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel10.Hide();
                        groupBox10.BackColor = Color.PaleTurquoise;
                        label95.Text = dr["adet"].ToString();
                        label95.ForeColor = Color.Green;
                    }
                    verigetir.Close();
                }
            }
            catch (MySqlException)
            {
                panel10.Show();
            }
        }
        private void Goster11()
        {
            
            try
            {
                int a = Convert.ToInt32(label102.Text); //is emir miktarı
                int b = Convert.ToInt32(label105.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar11.Maximum = a;
                    circularProgressBar11.Minimum = 0;
                    circularProgressBar11.Step = 1;
                    circularProgressBar11.Value = b;
                    circularProgressBar11.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar11.Maximum = a;
                    circularProgressBar11.Minimum = 0;
                    circularProgressBar11.Step = 1;
                    circularProgressBar11.Value = b;
                    circularProgressBar11.Text = "%" + yuzde.ToString();
                }
                if (timer1.Enabled == true)
                {
                    string dgr11;
                    dgr11 = groupBox11.Text.Replace('.', 'p');

                    string istasyon = groupBox11.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr11 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                  //  kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel11.Hide();
                        groupBox11.BackColor = Color.PaleTurquoise;
                        label105.Text = dr["adet"].ToString();
                        label105.ForeColor = Color.Green;
                    }
                    verigetir.Close();

                }
            }
            catch (MySqlException)
            {
                panel11.Show();
            }
        }
        private void Goster12()
        {

            try
            {
                int a = Convert.ToInt32(label112.Text); //is emir miktarı
                int b = Convert.ToInt32(label115.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar12.Maximum = a;
                    circularProgressBar12.Minimum = 0;
                    circularProgressBar12.Step = 1;
                    circularProgressBar12.Value = b;
                    circularProgressBar12.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar12.Maximum = a;
                    circularProgressBar12.Minimum = 0;
                    circularProgressBar12.Step = 1;
                    circularProgressBar12.Value = b;
                    circularProgressBar12.Text = "%" + yuzde.ToString();
                }
                if (timer1.Enabled == true)
                {
                    string dgr12;
                    dgr12 = groupBox12.Text.Replace('.', 'p');

                    string istasyon = groupBox12.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server = '" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr12 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    //  kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel12.Hide();
                        groupBox12.BackColor = Color.PaleTurquoise;
                        label115.Text = dr["adet"].ToString();
                        label115.ForeColor = Color.Green;
                    }
                    verigetir.Close();

                }
            }
            catch (MySqlException)
            {
                panel12.Show();
            }
        }
        private void Goster13()
        {

            try
            {
                int a = Convert.ToInt32(label122.Text); //is emir miktarı
                int b = Convert.ToInt32(label125.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar13.Maximum = a;
                    circularProgressBar13.Minimum = 0;
                    circularProgressBar13.Step = 1;
                    circularProgressBar13.Value = b;
                    circularProgressBar13.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar13.Maximum = a;
                    circularProgressBar13.Minimum = 0;
                    circularProgressBar13.Step = 1;
                    circularProgressBar13.Value = b;
                    circularProgressBar13.Text = "%" + yuzde.ToString();
                }
                if (timer1.Enabled == true)
                {
                    string dgr13;
                    dgr13 = groupBox13.Text.Replace('.', 'p');

                    string istasyon = groupBox13.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr13 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    //  kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel13.Hide();
                        groupBox13.BackColor = Color.PaleTurquoise;
                        label125.Text = dr["adet"].ToString();
                        label125.ForeColor = Color.Green;
                    }
                    verigetir.Close();

                }
            }
            catch (MySqlException)
            {
                panel13.Show();
            }
        }
        private void Goster14()
        {

            try
            {
                int a = Convert.ToInt32(label132.Text); //is emir miktarı
                int b = Convert.ToInt32(label135.Text); // basılan adet
                int yuzde = (b * 100) / a;

                if (b > a)
                {
                    b = a;
                    circularProgressBar14.Maximum = a;
                    circularProgressBar14.Minimum = 0;
                    circularProgressBar14.Step = 1;
                    circularProgressBar14.Value = b;
                    circularProgressBar14.Text = "%" + yuzde.ToString();

                }
                else
                {
                    circularProgressBar14.Maximum = a;
                    circularProgressBar14.Minimum = 0;
                    circularProgressBar14.Step = 1;
                    circularProgressBar14.Value = b;
                    circularProgressBar14.Text = "%" + yuzde.ToString();
                }
                if (timer1.Enabled == true)
                {
                    string dgr14;
                    dgr14 = groupBox14.Text.Replace('.', 'p');

                    string istasyon = groupBox14.Text.ToString();

                    MySqlConnection verigetir = new MySqlConnection("server ='" + Properties.Settings.Default["mysql_server"].ToString() + "'; user id = root; password= 1234; database='" + dgr14 + "'; persistsecurityinfo=True; allowbatch=True; ");
                    verigetir.Open();

                    MySqlCommand kmt = new MySqlCommand("SELECT * FROM uretim ORDER BY  adet DESC", verigetir);
                    //  kmt.CommandTimeout = 120;

                    MySqlDataReader dr = kmt.ExecuteReader();
                    if (dr.Read())
                    {
                        panel14.Hide();
                        groupBox14.BackColor = Color.PaleTurquoise;
                        label135.Text = dr["adet"].ToString();
                        label135.ForeColor = Color.Green;
                    }
                    verigetir.Close();

                }
            }
            catch (MySqlException)
            {
                panel14.Show();
            }
        }
        
        #endregion 

        #region LABEL'LARA GEREKLİ BİLGİLERİN ÇEKİLMESİ

        private void GRPBX1EMRÇEKM()
        {
            string s_kodu;
            try
            {
                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='"+groupBox1.Text.ToString()+"' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label34.Text = dr["operator_id"].ToString();
                    label157.Text = dr["operasyon_adi"].ToString();
                    label158.Text = dr["stok_kodu"].ToString();
                    label159.Text = dr["stok_adi"].ToString();
                    label160.Text = dr["is_emri_no"].ToString();
                    label35.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label158.Text + "' and sonrota='evet' and op_adi='" + label157.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI='" + label160.Text + "' and op_adi='" + label157.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label151.Text = drd["temin_adi_detay"].ToString();
                            label152.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label160.Text + "' and op_adi = '" + label157.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label151.Text = drd["temin_adi_detay"].ToString();
                            label152.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();
                }
                else
                {
                    panel1.Show();
                }
            }
            catch
            {
                
            }
            mes_baglan.Close();
        }
        private void GRPBX2EMRÇEKM()
        {
            try
            {
                string s_kodu;
                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox2.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label9.Text = dr["operator_id"].ToString();
                    label164.Text = dr["operasyon_adi"].ToString();
                    label163.Text = dr["stok_kodu"].ToString();
                    label165.Text = dr["stok_adi"].ToString();
                    label162.Text = dr["is_emri_no"].ToString();
                    label8.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label163.Text + "' and sonrota='evet' and op_adi='" + label164.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI='" + label162.Text + "' and op_adi='" + label164.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label6.Text = drd["temin_adi_detay"].ToString();
                            label7.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI='" + label162.Text + "' and op_adi='" + label164.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label6.Text = drd["temin_adi_detay"].ToString();
                            label7.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();
                }
                else
                {
                    panel2.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX3EMRÇEKM()
        {
            string s_kodu;

            try
            {
                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='253.10.02.01' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label19.Text = dr["operator_id"].ToString();
                    label168.Text = dr["operasyon_adi"].ToString();
                    label167.Text = dr["stok_kodu"].ToString();
                    label169.Text = dr["stok_adi"].ToString();
                    label166.Text = dr["is_emri_no"].ToString();
                    label18.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='"+label167.Text+"' and sonrota='evet' and op_adi='"+label168.Text+"' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI='" + label166.Text + "' and op_adi='" + label168.Text + "')) ", baglan);
                        

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label16.Text = drd["temin_adi_detay"].ToString();
                            label17.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '"+label166.Text+"' and op_adi = '"+label168.Text+"')", baglan);
                        
                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label16.Text = drd["temin_adi_detay"].ToString();
                            label17.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();

                    
                }
                    else
                    {
                        panel3.Show();
                    }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            mes_baglan.Close();
        }
        private void GRPBX4EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox4.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label30.Text = dr["operator_id"].ToString();
                    label172.Text = dr["operasyon_adi"].ToString();
                    label171.Text = dr["stok_kodu"].ToString();
                    label173.Text = dr["stok_adi"].ToString();
                    label170.Text = dr["is_emri_no"].ToString();
                    label29.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label171.Text + "' and sonrota='evet' and op_adi='" + label172.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI='" + label170.Text + "' and op_adi='" + label172.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label28.Text = drd["temin_adi_detay"].ToString();
                            label28.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label170.Text + "' and op_adi = '" + label172.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label27.Text = drd["temin_adi_detay"].ToString();
                            label28.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();

                }
                else
                {
                    panel4.Show();
                }
            }
            catch
            {


            }
            mes_baglan.Close();
        }
        private void GRPBX5EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox5.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label43.Text = dr["operator_id"].ToString();
                    label176.Text = dr["operasyon_adi"].ToString();
                    label175.Text = dr["stok_kodu"].ToString();
                    label177.Text = dr["stok_adi"].ToString();
                    label174.Text = dr["is_emri_no"].ToString();
                    label42.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label175.Text + "' and sonrota='evet' and op_adi='" + label176.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI= '" + label174.Text + "' and op_adi = '" + label176.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label40.Text = drd["temin_adi_detay"].ToString();
                            label41.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label174.Text + "' and op_adi = '" + label176.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label40.Text = drd["temin_adi_detay"].ToString();
                            label41.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel5.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX6EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox6.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label53.Text = dr["operator_id"].ToString();
                    label189.Text = dr["operasyon_adi"].ToString();
                    label188.Text = dr["stok_kodu"].ToString();
                    label186.Text = dr["stok_adi"].ToString();
                    label187.Text = dr["is_emri_no"].ToString();
                    label52.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label188.Text + "' and sonrota='evet' and op_adi='" + label189.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where  STOK_IS_EMRI = '" + label187.Text + "' and op_adi = '" + label189.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label50.Text = drd["temin_adi_detay"].ToString();
                            label51.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label187.Text + "' and op_adi = '" + label189.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label50.Text = drd["temin_adi_detay"].ToString();
                            label51.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel6.Show();
                }
            }
            catch
            {


            }
            mes_baglan.Close();
        }
        private void GRPBX7EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox7.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label63.Text = dr["operator_id"].ToString();
                    label185.Text = dr["operasyon_adi"].ToString();
                    label184.Text = dr["stok_kodu"].ToString();
                    label182.Text = dr["stok_adi"].ToString();
                    label183.Text = dr["is_emri_no"].ToString();
                    label62.Text = dr["KalanMiktar"].ToString();

                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label184.Text + "' and sonrota='evet' and op_adi='" + label185.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label183.Text + "' and op_adi = '" + label185.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label60.Text = drd["temin_adi_detay"].ToString();
                            label61.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label183.Text + "' and op_adi = '" + label185.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label60.Text = drd["temin_adi_detay"].ToString();
                            label61.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel7.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX8EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox8.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label73.Text = dr["operator_id"].ToString();
                    label180.Text = dr["operasyon_adi"].ToString();
                    label179.Text = dr["stok_kodu"].ToString();
                    label181.Text = dr["stok_adi"].ToString();
                    label178.Text = dr["is_emri_no"].ToString();
                    label72.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label179.Text + "' and sonrota='evet' and op_adi='" + label180.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label178.Text + "' and op_adi = '" + label180.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label70.Text = drd["temin_adi_detay"].ToString();
                            label71.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label178.Text + "' and op_adi = '" + label180.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label70.Text = drd["temin_adi_detay"].ToString();
                            label71.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel8.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX9EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox9.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label83.Text = dr["operator_id"].ToString();
                    label193.Text = dr["operasyon_adi"].ToString();
                    label192.Text = dr["stok_kodu"].ToString();
                    label190.Text = dr["stok_adi"].ToString();
                    label191.Text = dr["is_emri_no"].ToString();
                    label82.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label192.Text + "' and sonrota='evet' and op_adi='" + label193.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label191.Text + "' and op_adi = '" + label193.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label80.Text = drd["temin_adi_detay"].ToString();
                            label81.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label191.Text + "' and op_adi = '" + label193.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label80.Text = drd["temin_adi_detay"].ToString();
                            label81.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel9.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX10EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox10.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label93.Text = dr["operator_id"].ToString();
                    label197.Text = dr["operasyon_adi"].ToString();
                    label196.Text = dr["stok_kodu"].ToString();
                    label194.Text = dr["stok_adi"].ToString();
                    label195.Text = dr["is_emri_no"].ToString();
                    label92.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label196.Text + "' and sonrota='evet' and op_adi='" + label197.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label195.Text + "' and op_adi = '" + label197.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label90.Text = drd["temin_adi_detay"].ToString();
                            label91.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label195.Text + "' and op_adi = '" + label197.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label90.Text = drd["temin_adi_detay"].ToString();
                            label91.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel10.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX11EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox11.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label103.Text = dr["operator_id"].ToString();
                    label201.Text = dr["operasyon_adi"].ToString();
                    label200.Text = dr["stok_kodu"].ToString();
                    label198.Text = dr["stok_adi"].ToString();
                    label199.Text = dr["is_emri_no"].ToString();
                    label102.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label200.Text + "' and sonrota='evet' and op_adi='" + label201.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label199.Text + "' and op_adi = '" + label201.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label100.Text = drd["temin_adi_detay"].ToString();
                            label101.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label199.Text + "' and op_adi = '" + label201.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label100.Text = drd["temin_adi_detay"].ToString();
                            label101.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel11.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX12EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox12.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label113.Text = dr["operator_id"].ToString();
                    label205.Text = dr["operasyon_adi"].ToString();
                    label204.Text = dr["stok_kodu"].ToString();
                    label202.Text = dr["stok_adi"].ToString();
                    label203.Text = dr["is_emri_no"].ToString();
                    label112.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label204.Text + "' and sonrota='evet' and op_adi='" + label205.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label203.Text + "' and op_adi = '" + label205.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label110.Text = drd["temin_adi_detay"].ToString();
                            label111.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label203.Text + "' and op_adi = '" + label205.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label110.Text = drd["temin_adi_detay"].ToString();
                            label111.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel12.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX13EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox13.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label123.Text = dr["operator_id"].ToString();
                    label209.Text = dr["operasyon_adi"].ToString();
                    label208.Text = dr["stok_kodu"].ToString();
                    label206.Text = dr["stok_adi"].ToString();
                    label207.Text = dr["is_emri_no"].ToString();
                    label122.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label208.Text + "' and sonrota='evet' and op_adi='" + label209.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label207.Text + "' and op_adi = '" + label209.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label120.Text = drd["temin_adi_detay"].ToString();
                            label121.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label207.Text + "' and op_adi = '" + label209.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label120.Text = drd["temin_adi_detay"].ToString();
                            label121.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel13.Show();
                }
            }
            catch
            {

            }
            mes_baglan.Close();
        }
        private void GRPBX14EMRÇEKM()
        {
            try
            {
                string s_kodu;

                SqlCommand mes = new SqlCommand("select * from uretim_kayit where istasyon_kodu='" + groupBox14.Text.ToString() + "' and durum='aktif'", mes_baglan);
                mes_baglan.Open();

                SqlDataReader dr = mes.ExecuteReader();
                if (dr.Read())
                {
                    label133.Text = dr["operator_id"].ToString();
                    label213.Text = dr["operasyon_adi"].ToString();
                    label212.Text = dr["stok_kodu"].ToString();
                    label210.Text = dr["stok_adi"].ToString();
                    label211.Text = dr["is_emri_no"].ToString();
                    label132.Text = dr["KalanMiktar"].ToString();
                    s_kodu = dr["stok_kodu"].ToString();

                    SqlCommand emir = new SqlCommand("SELECT *FROM vwAktifIsEmriIstDetayli  where stok_kodu='" + label212.Text + "' and sonrota='evet' and op_adi='" + label213.Text + "' ", baglan);
                    baglan.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter drd2 = new SqlDataAdapter(emir);
                    drd2.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in (select a_stok_kodu from MRP_Urun_Agaci where yer ='ust' and s_stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label211.Text + "' and op_adi = '" + label213.Text + "')) ", baglan);


                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label130.Text = drd["temin_adi_detay"].ToString();
                            label131.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    else
                    {
                        SqlCommand bolüm = new SqlCommand("select temin_adi_detay,ozel_kod2 from M_Stok_Karti where stok_kodu in ( select stok_kodu from vwAktifIsEmriIstDetayli where STOK_IS_EMRI = '" + label211.Text + "' and op_adi = '" + label213.Text + "')", baglan);

                        SqlDataReader drd = bolüm.ExecuteReader();
                        if (drd.Read())
                        {
                            label130.Text = drd["temin_adi_detay"].ToString();
                            label131.Text = drd["ozel_kod2"].ToString();
                        }
                        baglan.Close();
                    }
                    baglan.Close();


                }
                else
                {
                    panel14.Show();
                }
            }
            catch
            {
                
            }
            mes_baglan.Close();
        }

        #endregion

    }
}
