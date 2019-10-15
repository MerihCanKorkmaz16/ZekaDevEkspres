namespace ZekaDevEkspresDeneme
{
    partial class DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zekaDenemeProje1DataSet3 = new ZekaDevEkspresDeneme.ZekaDenemeProje1DataSet3();
            this.doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter = new ZekaDevEkspresDeneme.ZekaDenemeProje1DataSet3TableAdapters.DoğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter();
            this.satınAlmaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.işKısmıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.firmaEklemeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.evrakEklemeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.satınalmasayacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zekaDenemeProje1DataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.satınAlmaidDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.işKısmıDataGridViewCheckBoxColumn,
            this.firmaEklemeDataGridViewCheckBoxColumn,
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn,
            this.evrakEklemeDataGridViewCheckBoxColumn,
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn,
            this.satınalmasayacDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 537);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1376, 211);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // zekaDenemeProje1DataSet3
            // 
            this.zekaDenemeProje1DataSet3.DataSetName = "ZekaDenemeProje1DataSet3";
            this.zekaDenemeProje1DataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource
            // 
            this.doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource.DataMember = "DoğrudanTeminPeriyodikBilgilendirmeTablosu";
            this.doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource.DataSource = this.zekaDenemeProje1DataSet3;
            // 
            // doğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter
            // 
            this.doğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter.ClearBeforeFill = true;
            // 
            // satınAlmaidDataGridViewTextBoxColumn
            // 
            this.satınAlmaidDataGridViewTextBoxColumn.DataPropertyName = "SatınAlma_id";
            this.satınAlmaidDataGridViewTextBoxColumn.HeaderText = "SatınAlma_id";
            this.satınAlmaidDataGridViewTextBoxColumn.Name = "satınAlmaidDataGridViewTextBoxColumn";
            this.satınAlmaidDataGridViewTextBoxColumn.ReadOnly = true;
            this.satınAlmaidDataGridViewTextBoxColumn.Width = 101;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 101;
            // 
            // işKısmıDataGridViewCheckBoxColumn
            // 
            this.işKısmıDataGridViewCheckBoxColumn.DataPropertyName = "İş Kısmı";
            this.işKısmıDataGridViewCheckBoxColumn.HeaderText = "İş Kısmı";
            this.işKısmıDataGridViewCheckBoxColumn.Name = "işKısmıDataGridViewCheckBoxColumn";
            this.işKısmıDataGridViewCheckBoxColumn.ReadOnly = true;
            this.işKısmıDataGridViewCheckBoxColumn.Width = 101;
            // 
            // firmaEklemeDataGridViewCheckBoxColumn
            // 
            this.firmaEklemeDataGridViewCheckBoxColumn.DataPropertyName = "Firma Ekleme";
            this.firmaEklemeDataGridViewCheckBoxColumn.HeaderText = "Firma Ekleme";
            this.firmaEklemeDataGridViewCheckBoxColumn.Name = "firmaEklemeDataGridViewCheckBoxColumn";
            this.firmaEklemeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.firmaEklemeDataGridViewCheckBoxColumn.Width = 101;
            // 
            // firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn
            // 
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn.DataPropertyName = "Firma Seç ve Sözlesme Taslağı";
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn.HeaderText = "Firma Seç ve Sözlesme Taslağı";
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn.Name = "firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn";
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn.ReadOnly = true;
            this.firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn.Width = 101;
            // 
            // evrakEklemeDataGridViewCheckBoxColumn
            // 
            this.evrakEklemeDataGridViewCheckBoxColumn.DataPropertyName = "Evrak Ekleme";
            this.evrakEklemeDataGridViewCheckBoxColumn.HeaderText = "Evrak Ekleme";
            this.evrakEklemeDataGridViewCheckBoxColumn.Name = "evrakEklemeDataGridViewCheckBoxColumn";
            this.evrakEklemeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.evrakEklemeDataGridViewCheckBoxColumn.Width = 101;
            // 
            // süreUzatımTutanağıDataGridViewCheckBoxColumn
            // 
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn.DataPropertyName = "Süre Uzatım tutanağı";
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn.HeaderText = "Süre Uzatım tutanağı";
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn.Name = "süreUzatımTutanağıDataGridViewCheckBoxColumn";
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn.ReadOnly = true;
            this.süreUzatımTutanağıDataGridViewCheckBoxColumn.Width = 101;
            // 
            // satınalmasayacDataGridViewTextBoxColumn
            // 
            this.satınalmasayacDataGridViewTextBoxColumn.DataPropertyName = "satınalmasayac";
            this.satınalmasayacDataGridViewTextBoxColumn.HeaderText = "satınalmasayac";
            this.satınalmasayacDataGridViewTextBoxColumn.Name = "satınalmasayacDataGridViewTextBoxColumn";
            this.satınalmasayacDataGridViewTextBoxColumn.ReadOnly = true;
            this.satınalmasayacDataGridViewTextBoxColumn.Width = 101;
            // 
            // DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 748);
            this.Controls.Add(this.dataGridView1);
            this.Name = "DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu";
            this.Text = "DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zekaDenemeProje1DataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private ZekaDenemeProje1DataSet3 zekaDenemeProje1DataSet3;
        private System.Windows.Forms.BindingSource doğrudanTeminPeriyodikBilgilendirmeTablosuBindingSource;
        private ZekaDenemeProje1DataSet3TableAdapters.DoğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter doğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn satınAlmaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn işKısmıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn firmaEklemeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn firmaSeçVeSözlesmeTaslağıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn evrakEklemeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn süreUzatımTutanağıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn satınalmasayacDataGridViewTextBoxColumn;
    }
}