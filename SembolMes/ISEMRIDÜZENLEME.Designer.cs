
namespace SembolMes
{
    partial class ISEMRIDÜZENLEME
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ISEMRIDÜZENLEME));
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.istasyon_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operator_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stok_kodu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stok_adi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_emri_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rota_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operasyon_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.istasyon_sec = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.KAYDET = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TEMİZLE = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.d_buton4 = new CustomControls.RJControls.d_buton();
            this.rjTextBox1 = new CustomControls.RJControls.RJTextBox();
            this.d_buton1 = new CustomControls.RJControls.d_buton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AllowUserToOrderColumns = true;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView3.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.istasyon_kodu,
            this.operator_id,
            this.stok_kodu,
            this.stok_adi,
            this.is_emri_no,
            this.rota_no,
            this.operasyon_no,
            this.istasyon_sec,
            this.KAYDET,
            this.TEMİZLE});
            this.dataGridView3.Location = new System.Drawing.Point(4, 87);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView3.Size = new System.Drawing.Size(863, 413);
            this.dataGridView3.TabIndex = 5;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // istasyon_kodu
            // 
            this.istasyon_kodu.DataPropertyName = "istasyon_kodu";
            this.istasyon_kodu.HeaderText = "İSTASYON KODU";
            this.istasyon_kodu.Name = "istasyon_kodu";
            this.istasyon_kodu.ReadOnly = true;
            this.istasyon_kodu.Width = 110;
            // 
            // operator_id
            // 
            this.operator_id.DataPropertyName = "operator_id";
            this.operator_id.HeaderText = "OPERATOR ADI";
            this.operator_id.Name = "operator_id";
            this.operator_id.ReadOnly = true;
            this.operator_id.Width = 104;
            // 
            // stok_kodu
            // 
            this.stok_kodu.DataPropertyName = "stok_kodu";
            this.stok_kodu.HeaderText = "STOK KODU";
            this.stok_kodu.Name = "stok_kodu";
            this.stok_kodu.ReadOnly = true;
            this.stok_kodu.Width = 87;
            // 
            // stok_adi
            // 
            this.stok_adi.DataPropertyName = "stok_adi";
            this.stok_adi.HeaderText = "STOK ADI";
            this.stok_adi.Name = "stok_adi";
            this.stok_adi.ReadOnly = true;
            this.stok_adi.Width = 76;
            // 
            // is_emri_no
            // 
            this.is_emri_no.DataPropertyName = "is_emri_no";
            this.is_emri_no.HeaderText = "İŞ EMRİ NO";
            this.is_emri_no.Name = "is_emri_no";
            this.is_emri_no.ReadOnly = true;
            this.is_emri_no.Width = 84;
            // 
            // rota_no
            // 
            this.rota_no.DataPropertyName = "rota_no";
            this.rota_no.HeaderText = "ROTA NO";
            this.rota_no.Name = "rota_no";
            this.rota_no.ReadOnly = true;
            this.rota_no.Width = 75;
            // 
            // operasyon_no
            // 
            this.operasyon_no.DataPropertyName = "operasyon_no";
            this.operasyon_no.HeaderText = "OPERASYON NO";
            this.operasyon_no.Name = "operasyon_no";
            this.operasyon_no.ReadOnly = true;
            this.operasyon_no.Width = 108;
            // 
            // istasyon_sec
            // 
            this.istasyon_sec.DropDownWidth = 25;
            this.istasyon_sec.HeaderText = "İSTASYON SEÇ";
            this.istasyon_sec.Name = "istasyon_sec";
            this.istasyon_sec.Width = 82;
            // 
            // KAYDET
            // 
            this.KAYDET.HeaderText = "KAYDET";
            this.KAYDET.Name = "KAYDET";
            this.KAYDET.Text = "KAYDET";
            this.KAYDET.UseColumnTextForButtonValue = true;
            this.KAYDET.Width = 56;
            // 
            // TEMİZLE
            // 
            this.TEMİZLE.HeaderText = "TEMİZLE";
            this.TEMİZLE.Name = "TEMİZLE";
            this.TEMİZLE.Text = "TEMİZLE";
            this.TEMİZLE.UseColumnTextForButtonValue = true;
            this.TEMİZLE.Width = 59;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.d_buton1);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.d_buton4);
            this.panel1.Controls.Add(this.rjTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 81);
            this.panel1.TabIndex = 6;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(26, 30);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 17);
            this.label18.TabIndex = 3;
            this.label18.Text = "İŞ EMİR NO :";
            // 
            // d_buton4
            // 
            this.d_buton4.BackColor = System.Drawing.Color.DarkTurquoise;
            this.d_buton4.BackgroundColor = System.Drawing.Color.DarkTurquoise;
            this.d_buton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.d_buton4.BorderRadius = 0;
            this.d_buton4.BorderSize = 0;
            this.d_buton4.FlatAppearance.BorderSize = 0;
            this.d_buton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d_buton4.ForeColor = System.Drawing.Color.White;
            this.d_buton4.Location = new System.Drawing.Point(323, 23);
            this.d_buton4.Name = "d_buton4";
            this.d_buton4.Size = new System.Drawing.Size(164, 31);
            this.d_buton4.TabIndex = 1;
            this.d_buton4.Text = "ARA";
            this.d_buton4.TextColor = System.Drawing.Color.White;
            this.d_buton4.UseVisualStyleBackColor = false;
            this.d_buton4.Click += new System.EventHandler(this.d_buton4_Click_1);
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.rjTextBox1.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjTextBox1.BorderRadius = 0;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rjTextBox1.Location = new System.Drawing.Point(135, 23);
            this.rjTextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "";
            this.rjTextBox1.Size = new System.Drawing.Size(164, 31);
            this.rjTextBox1.TabIndex = 2;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            // 
            // d_buton1
            // 
            this.d_buton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.d_buton1.BackColor = System.Drawing.Color.Azure;
            this.d_buton1.BackgroundColor = System.Drawing.Color.Azure;
            this.d_buton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.d_buton1.BorderRadius = 0;
            this.d_buton1.BorderSize = 0;
            this.d_buton1.FlatAppearance.BorderSize = 0;
            this.d_buton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d_buton1.ForeColor = System.Drawing.Color.Black;
            this.d_buton1.Image = ((System.Drawing.Image)(resources.GetObject("d_buton1.Image")));
            this.d_buton1.Location = new System.Drawing.Point(819, 18);
            this.d_buton1.Name = "d_buton1";
            this.d_buton1.Size = new System.Drawing.Size(44, 36);
            this.d_buton1.TabIndex = 29;
            this.d_buton1.TextColor = System.Drawing.Color.Black;
            this.d_buton1.UseVisualStyleBackColor = false;
            this.d_buton1.Click += new System.EventHandler(this.d_buton1_Click);
            // 
            // ISEMRIDÜZENLEME
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 502);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.panel1);
            this.Name = "ISEMRIDÜZENLEME";
            this.Text = "ISEMRIDÜZENLEME";
            this.Load += new System.EventHandler(this.ISEMRIDÜZENLEME_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewTextBoxColumn istasyon_kodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn operator_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn stok_kodu;
        private System.Windows.Forms.DataGridViewTextBoxColumn stok_adi;
        private System.Windows.Forms.DataGridViewTextBoxColumn is_emri_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn rota_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn operasyon_no;
        private System.Windows.Forms.DataGridViewComboBoxColumn istasyon_sec;
        private System.Windows.Forms.DataGridViewButtonColumn KAYDET;
        private System.Windows.Forms.DataGridViewButtonColumn TEMİZLE;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private CustomControls.RJControls.d_buton d_buton4;
        private CustomControls.RJControls.RJTextBox rjTextBox1;
        private CustomControls.RJControls.d_buton d_buton1;
    }
}