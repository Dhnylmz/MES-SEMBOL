
namespace SembolMes
{
    partial class Form11
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form11));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.OLCU_OZELLIK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISTENEN_OLCU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERI_ONAY = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.OLCUM1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLCUM2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLCUM3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLCUM4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLCUM5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLCUM6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLCUM7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_buton4 = new CustomControls.RJControls.d_buton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleTurquoise;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeight = 40;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OLCU_OZELLIK,
            this.ISTENEN_OLCU,
            this.SERI_ONAY,
            this.OLCUM1,
            this.OLCUM2,
            this.OLCUM3,
            this.OLCUM4,
            this.OLCUM5,
            this.OLCUM6,
            this.OLCUM7});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 10;
            this.dataGridView1.Size = new System.Drawing.Size(993, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView1_EditingControlShowing);
            // 
            // OLCU_OZELLIK
            // 
            this.OLCU_OZELLIK.DataPropertyName = "OLCU_OZELLIK";
            dataGridViewCellStyle1.NullValue = null;
            this.OLCU_OZELLIK.DefaultCellStyle = dataGridViewCellStyle1;
            this.OLCU_OZELLIK.HeaderText = "Ölçü Özellik";
            this.OLCU_OZELLIK.Name = "OLCU_OZELLIK";
            this.OLCU_OZELLIK.ReadOnly = true;
            this.OLCU_OZELLIK.Width = 81;
            // 
            // ISTENEN_OLCU
            // 
            this.ISTENEN_OLCU.DataPropertyName = "ISTENEN_OLCU";
            this.ISTENEN_OLCU.HeaderText = "İstenilen Ölçü";
            this.ISTENEN_OLCU.Name = "ISTENEN_OLCU";
            this.ISTENEN_OLCU.ReadOnly = true;
            this.ISTENEN_OLCU.Width = 88;
            // 
            // SERI_ONAY
            // 
            this.SERI_ONAY.DataPropertyName = "SERI_ONAY";
            this.SERI_ONAY.FalseValue = "FALSE";
            this.SERI_ONAY.HeaderText = "Seri Onay";
            this.SERI_ONAY.Name = "SERI_ONAY";
            this.SERI_ONAY.TrueValue = "True";
            this.SERI_ONAY.Width = 53;
            // 
            // OLCUM1
            // 
            this.OLCUM1.DataPropertyName = "OLCUM1";
            dataGridViewCellStyle2.NullValue = null;
            this.OLCUM1.DefaultCellStyle = dataGridViewCellStyle2;
            this.OLCUM1.HeaderText = "1.Ölçüm";
            this.OLCUM1.Name = "OLCUM1";
            this.OLCUM1.Width = 71;
            // 
            // OLCUM2
            // 
            this.OLCUM2.DataPropertyName = "OLCUM2";
            this.OLCUM2.HeaderText = "2.Ölçüm";
            this.OLCUM2.Name = "OLCUM2";
            this.OLCUM2.Width = 71;
            // 
            // OLCUM3
            // 
            this.OLCUM3.DataPropertyName = "OLCUM3";
            this.OLCUM3.HeaderText = "3.Ölçüm";
            this.OLCUM3.Name = "OLCUM3";
            this.OLCUM3.Width = 71;
            // 
            // OLCUM4
            // 
            this.OLCUM4.DataPropertyName = "OLCUM4";
            this.OLCUM4.HeaderText = "4.Ölçüm";
            this.OLCUM4.Name = "OLCUM4";
            this.OLCUM4.Width = 71;
            // 
            // OLCUM5
            // 
            this.OLCUM5.DataPropertyName = "OLCUM5";
            this.OLCUM5.HeaderText = "5.Ölçüm";
            this.OLCUM5.Name = "OLCUM5";
            this.OLCUM5.Width = 71;
            // 
            // OLCUM6
            // 
            this.OLCUM6.DataPropertyName = "OLCUM6";
            this.OLCUM6.HeaderText = "6.Ölçüm";
            this.OLCUM6.Name = "OLCUM6";
            this.OLCUM6.Width = 71;
            // 
            // OLCUM7
            // 
            this.OLCUM7.DataPropertyName = "OLCUM7";
            this.OLCUM7.HeaderText = "7.Ölçüm";
            this.OLCUM7.Name = "OLCUM7";
            this.OLCUM7.Width = 71;
            // 
            // d_buton4
            // 
            this.d_buton4.BackColor = System.Drawing.Color.Azure;
            this.d_buton4.BackgroundColor = System.Drawing.Color.Azure;
            this.d_buton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.d_buton4.BorderRadius = 0;
            this.d_buton4.BorderSize = 0;
            this.d_buton4.FlatAppearance.BorderSize = 0;
            this.d_buton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.d_buton4.ForeColor = System.Drawing.Color.Black;
            this.d_buton4.Image = ((System.Drawing.Image)(resources.GetObject("d_buton4.Image")));
            this.d_buton4.Location = new System.Drawing.Point(937, 2);
            this.d_buton4.Name = "d_buton4";
            this.d_buton4.Size = new System.Drawing.Size(44, 36);
            this.d_buton4.TabIndex = 28;
            this.d_buton4.TextColor = System.Drawing.Color.Black;
            this.d_buton4.UseVisualStyleBackColor = false;
            this.d_buton4.Click += new System.EventHandler(this.d_buton4_Click);
            // 
            // Form11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 450);
            this.Controls.Add(this.d_buton4);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1009, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1009, 489);
            this.Name = "Form11";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proses Kontrol";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form11_FormClosed);
            this.Load += new System.EventHandler(this.Form11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CustomControls.RJControls.d_buton d_buton4;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCU_OZELLIK;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISTENEN_OLCU;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SERI_ONAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM1;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM3;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM4;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM5;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM6;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLCUM7;
    }
}