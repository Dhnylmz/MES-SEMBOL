
namespace SembolMes
{
    partial class Form9
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form9));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.teknikresim = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Proses = new System.Windows.Forms.DataGridViewButtonColumn();
            this.is_emri_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rota_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operasyon_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stok_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operasyon_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operator_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.istasyon_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stok_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            this.d_buton1 = new CustomControls.RJControls.d_buton();
            this.toogle_buton1 = new CustomControls.RJControls.toogle_buton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.d_buton4 = new CustomControls.RJControls.d_buton();
            this.d_buton2 = new CustomControls.RJControls.d_buton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.teknikresim,
            this.Proses,
            this.is_emri_no,
            this.rota_no,
            this.operasyon_no,
            this.stok_kodu,
            this.operasyon_adi,
            this.operator_id,
            this.istasyon_kodu,
            this.stok_adi});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 100);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView1.RowTemplate.Height = 35;
            this.dataGridView1.Size = new System.Drawing.Size(1009, 350);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // teknikresim
            // 
            this.teknikresim.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.teknikresim.HeaderText = "Teknik Resim";
            this.teknikresim.Name = "teknikresim";
            this.teknikresim.ReadOnly = true;
            this.teknikresim.Text = "Aç";
            this.teknikresim.UseColumnTextForButtonValue = true;
            // 
            // Proses
            // 
            this.Proses.HeaderText = "Proses";
            this.Proses.Name = "Proses";
            this.Proses.ReadOnly = true;
            this.Proses.Text = "Proses";
            this.Proses.UseColumnTextForButtonValue = true;
            // 
            // is_emri_no
            // 
            this.is_emri_no.DataPropertyName = "is_emri_no";
            this.is_emri_no.HeaderText = "İş Emir No";
            this.is_emri_no.Name = "is_emri_no";
            this.is_emri_no.ReadOnly = true;
            // 
            // rota_no
            // 
            this.rota_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.rota_no.DataPropertyName = "rota_no";
            this.rota_no.HeaderText = "Rota No";
            this.rota_no.Name = "rota_no";
            this.rota_no.ReadOnly = true;
            this.rota_no.Width = 67;
            // 
            // operasyon_no
            // 
            this.operasyon_no.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.operasyon_no.DataPropertyName = "operasyon_no";
            this.operasyon_no.HeaderText = "Operasyon No";
            this.operasyon_no.Name = "operasyon_no";
            this.operasyon_no.ReadOnly = true;
            this.operasyon_no.Width = 92;
            // 
            // stok_kodu
            // 
            this.stok_kodu.DataPropertyName = "stok_kodu";
            this.stok_kodu.HeaderText = "Stok Kodu";
            this.stok_kodu.Name = "stok_kodu";
            this.stok_kodu.ReadOnly = true;
            // 
            // operasyon_adi
            // 
            this.operasyon_adi.DataPropertyName = "operasyon_adi";
            this.operasyon_adi.HeaderText = "Operasyon Adı";
            this.operasyon_adi.Name = "operasyon_adi";
            this.operasyon_adi.ReadOnly = true;
            // 
            // operator_id
            // 
            this.operator_id.DataPropertyName = "operator_id";
            this.operator_id.HeaderText = "Operatör Adı";
            this.operator_id.Name = "operator_id";
            this.operator_id.ReadOnly = true;
            // 
            // istasyon_kodu
            // 
            this.istasyon_kodu.DataPropertyName = "istasyon_kodu";
            this.istasyon_kodu.HeaderText = "İstasyon Kodu";
            this.istasyon_kodu.Name = "istasyon_kodu";
            this.istasyon_kodu.ReadOnly = true;
            // 
            // stok_adi
            // 
            this.stok_adi.DataPropertyName = "stok_adi";
            this.stok_adi.HeaderText = "Stok Adı";
            this.stok_adi.Name = "stok_adi";
            this.stok_adi.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(413, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "İŞ EMİR ARA:";
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.rjTextBox1.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjTextBox1.BorderRadius = 5;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjTextBox1.Location = new System.Drawing.Point(544, 59);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.Size = new System.Drawing.Size(179, 31);
            this.rjTextBox1.TabIndex = 6;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            // 
            // d_buton1
            // 
            this.d_buton1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.d_buton1.BackgroundColor = System.Drawing.Color.DarkTurquoise;
            this.d_buton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.d_buton1.BorderRadius = 20;
            this.d_buton1.BorderSize = 0;
            this.d_buton1.FlatAppearance.BorderSize = 0;
            this.d_buton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d_buton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.d_buton1.ForeColor = System.Drawing.Color.White;
            this.d_buton1.Location = new System.Drawing.Point(728, 54);
            this.d_buton1.Name = "d_buton1";
            this.d_buton1.Size = new System.Drawing.Size(150, 40);
            this.d_buton1.TabIndex = 5;
            this.d_buton1.Text = "ARA";
            this.d_buton1.TextColor = System.Drawing.Color.White;
            this.d_buton1.UseVisualStyleBackColor = false;
            this.d_buton1.Click += new System.EventHandler(this.d_buton1_Click);
            // 
            // toogle_buton1
            // 
            this.toogle_buton1.AutoSize = true;
            this.toogle_buton1.Location = new System.Drawing.Point(128, 62);
            this.toogle_buton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toogle_buton1.Name = "toogle_buton1";
            this.toogle_buton1.OffBackColor = System.Drawing.Color.ForestGreen;
            this.toogle_buton1.OffToggleColor = System.Drawing.Color.White;
            this.toogle_buton1.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.toogle_buton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toogle_buton1.Size = new System.Drawing.Size(45, 22);
            this.toogle_buton1.TabIndex = 9;
            this.toogle_buton1.UseVisualStyleBackColor = true;
            this.toogle_buton1.CheckedChanged += new System.EventHandler(this.toogle_buton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Aktif İş Emirleri";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(179, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 22);
            this.label3.TabIndex = 11;
            this.label3.Text = "Kalite Onaylı İş Emirleri";
            // 
            // d_buton4
            // 
            this.d_buton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_buton4.BackColor = System.Drawing.Color.Azure;
            this.d_buton4.BackgroundColor = System.Drawing.Color.Azure;
            this.d_buton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.d_buton4.BorderRadius = 0;
            this.d_buton4.BorderSize = 0;
            this.d_buton4.FlatAppearance.BorderSize = 0;
            this.d_buton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d_buton4.ForeColor = System.Drawing.Color.Black;
            this.d_buton4.Image = ((System.Drawing.Image)(resources.GetObject("d_buton4.Image")));
            this.d_buton4.Location = new System.Drawing.Point(950, 58);
            this.d_buton4.Name = "d_buton4";
            this.d_buton4.Size = new System.Drawing.Size(44, 36);
            this.d_buton4.TabIndex = 28;
            this.d_buton4.TextColor = System.Drawing.Color.Black;
            this.d_buton4.UseVisualStyleBackColor = false;
            this.d_buton4.Click += new System.EventHandler(this.d_buton4_Click);
            // 
            // d_buton2
            // 
            this.d_buton2.BackColor = System.Drawing.Color.DarkTurquoise;
            this.d_buton2.BackgroundColor = System.Drawing.Color.DarkTurquoise;
            this.d_buton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.d_buton2.BorderRadius = 20;
            this.d_buton2.BorderSize = 0;
            this.d_buton2.FlatAppearance.BorderSize = 0;
            this.d_buton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d_buton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.d_buton2.ForeColor = System.Drawing.Color.White;
            this.d_buton2.Location = new System.Drawing.Point(16, 9);
            this.d_buton2.Name = "d_buton2";
            this.d_buton2.Size = new System.Drawing.Size(150, 40);
            this.d_buton2.TabIndex = 29;
            this.d_buton2.Text = "Arıza - Bakım";
            this.d_buton2.TextColor = System.Drawing.Color.White;
            this.d_buton2.UseVisualStyleBackColor = false;
            this.d_buton2.Click += new System.EventHandler(this.d_buton2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.d_buton2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.d_buton4);
            this.panel1.Controls.Add(this.d_buton1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rjTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.toogle_buton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 100);
            this.panel1.TabIndex = 30;
            // 
            // Form9
            // 
            this.AcceptButton = this.d_buton1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.MaximumSize = new System.Drawing.Size(1025, 489);
            this.MinimumSize = new System.Drawing.Size(1025, 489);
            this.Name = "Form9";
            this.Text = "Kalite Kontrol";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form9_FormClosing);
            this.Load += new System.EventHandler(this.Form9_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private CustomControls.RJControls.d_buton d_buton1;
        private System.Windows.Forms.Label label1;
        private CustomControls.RJControls.toogle_buton toogle_buton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private CustomControls.RJControls.d_buton d_buton2;
        private System.Windows.Forms.Panel panel1;
        public CustomControls.RJControls.d_buton d_buton4;
        private System.Windows.Forms.DataGridViewButtonColumn teknikresim;
        private System.Windows.Forms.DataGridViewButtonColumn Proses;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_emri_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn rota_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn operasyon_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn stok_kodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn operasyon_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn operator_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn istasyon_kodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn stok_adi;
    }
}