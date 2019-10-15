namespace ZekaDevEkspresDeneme
{
    partial class SatınAlmaBilgilendirmeFormu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.satınAlmaidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soyadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.üsülAdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.işinAdıDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.firmaEklemeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nihaiTeklifDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.satınalmasayacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doğrudanTeminBilgilendirmeTablosuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.zekaDenemeProje1DataSet = new ZekaDevEkspresDeneme.ZekaDenemeProje1DataSet();
            this.doğrudanTeminBilgilendirmeTablosuTableAdapter = new ZekaDevEkspresDeneme.ZekaDenemeProje1DataSetTableAdapters.DoğrudanTeminBilgilendirmeTablosuTableAdapter();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doğrudanTeminBilgilendirmeTablosuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zekaDenemeProje1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.satınAlmaidDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.adDataGridViewTextBoxColumn,
            this.soyadDataGridViewTextBoxColumn,
            this.üsülAdDataGridViewTextBoxColumn,
            this.işinAdıDataGridViewTextBoxColumn,
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn,
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn,
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn,
            this.firmaEklemeDataGridViewCheckBoxColumn,
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn,
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn,
            this.nihaiTeklifDataGridViewCheckBoxColumn,
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn,
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn,
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn,
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn,
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn,
            this.satınalmasayacDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.doğrudanTeminBilgilendirmeTablosuBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 8.164948F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 476);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 8.164948F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 265);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
            // 
            // satınAlmaidDataGridViewTextBoxColumn
            // 
            this.satınAlmaidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.satınAlmaidDataGridViewTextBoxColumn.DataPropertyName = "SatınAlma_id";
            this.satınAlmaidDataGridViewTextBoxColumn.HeaderText = "SatınAlma_id";
            this.satınAlmaidDataGridViewTextBoxColumn.Name = "satınAlmaidDataGridViewTextBoxColumn";
            this.satınAlmaidDataGridViewTextBoxColumn.ReadOnly = true;
            this.satınAlmaidDataGridViewTextBoxColumn.Width = 105;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // adDataGridViewTextBoxColumn
            // 
            this.adDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.adDataGridViewTextBoxColumn.DataPropertyName = "Ad";
            this.adDataGridViewTextBoxColumn.HeaderText = "Ad";
            this.adDataGridViewTextBoxColumn.Name = "adDataGridViewTextBoxColumn";
            this.adDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // soyadDataGridViewTextBoxColumn
            // 
            this.soyadDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.soyadDataGridViewTextBoxColumn.DataPropertyName = "Soyad";
            this.soyadDataGridViewTextBoxColumn.HeaderText = "Soyad";
            this.soyadDataGridViewTextBoxColumn.Name = "soyadDataGridViewTextBoxColumn";
            this.soyadDataGridViewTextBoxColumn.ReadOnly = true;
            this.soyadDataGridViewTextBoxColumn.Width = 66;
            // 
            // üsülAdDataGridViewTextBoxColumn
            // 
            this.üsülAdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.üsülAdDataGridViewTextBoxColumn.DataPropertyName = "ÜsülAd";
            this.üsülAdDataGridViewTextBoxColumn.HeaderText = "ÜsülAd";
            this.üsülAdDataGridViewTextBoxColumn.Name = "üsülAdDataGridViewTextBoxColumn";
            this.üsülAdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // işinAdıDataGridViewTextBoxColumn
            // 
            this.işinAdıDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.işinAdıDataGridViewTextBoxColumn.DataPropertyName = "İşin Adı";
            this.işinAdıDataGridViewTextBoxColumn.HeaderText = "İşin Adı";
            this.işinAdıDataGridViewTextBoxColumn.Name = "işinAdıDataGridViewTextBoxColumn";
            this.işinAdıDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idariVeTeknikŞartNameDataGridViewCheckBoxColumn
            // 
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn.DataPropertyName = "İdari ve Teknik Şart Name";
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn.HeaderText = "İdari ve Teknik Şart Name";
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn.Name = "idariVeTeknikŞartNameDataGridViewCheckBoxColumn";
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn.ReadOnly = true;
            this.idariVeTeknikŞartNameDataGridViewCheckBoxColumn.Width = 69;
            // 
            // sözlesmeTaslagıDataGridViewCheckBoxColumn
            // 
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn.DataPropertyName = "Sözlesme Taslagı";
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn.HeaderText = "Sözlesme Taslagı";
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn.Name = "sözlesmeTaslagıDataGridViewCheckBoxColumn";
            this.sözlesmeTaslagıDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // yaklasıkMaliyetDataGridViewCheckBoxColumn
            // 
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn.DataPropertyName = "Yaklasık Maliyet";
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn.HeaderText = "Yaklasık Maliyet";
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn.Name = "yaklasıkMaliyetDataGridViewCheckBoxColumn";
            this.yaklasıkMaliyetDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // firmaEklemeDataGridViewCheckBoxColumn
            // 
            this.firmaEklemeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.firmaEklemeDataGridViewCheckBoxColumn.DataPropertyName = "Firma Ekleme";
            this.firmaEklemeDataGridViewCheckBoxColumn.HeaderText = "Firma Ekleme";
            this.firmaEklemeDataGridViewCheckBoxColumn.Name = "firmaEklemeDataGridViewCheckBoxColumn";
            this.firmaEklemeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn
            // 
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn.DataPropertyName = "Birinci Teklif Tip Yaklasık";
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn.HeaderText = "Birinci Teklif Tip Yaklasık";
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn.Name = "birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn";
            this.birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // satınAlmaTalepFormuDataGridViewCheckBoxColumn
            // 
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn.DataPropertyName = "Satın Alma Talep Formu";
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn.HeaderText = "Satın Alma Talep Formu";
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn.Name = "satınAlmaTalepFormuDataGridViewCheckBoxColumn";
            this.satınAlmaTalepFormuDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // nihaiTeklifDataGridViewCheckBoxColumn
            // 
            this.nihaiTeklifDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nihaiTeklifDataGridViewCheckBoxColumn.DataPropertyName = "Nihai Teklif";
            this.nihaiTeklifDataGridViewCheckBoxColumn.HeaderText = "Nihai Teklif";
            this.nihaiTeklifDataGridViewCheckBoxColumn.Name = "nihaiTeklifDataGridViewCheckBoxColumn";
            this.nihaiTeklifDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // teklifFirmaEklemeDataGridViewCheckBoxColumn
            // 
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn.DataPropertyName = "2_Teklif Firma Ekleme";
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn.HeaderText = "2_Teklif Firma Ekleme";
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn.Name = "teklifFirmaEklemeDataGridViewCheckBoxColumn";
            this.teklifFirmaEklemeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // ihaleHarcamaOnayFormDataGridViewCheckBoxColumn
            // 
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn.DataPropertyName = "İhale Harcama Onay Form";
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn.HeaderText = "İhale Harcama Onay Form";
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn.Name = "ihaleHarcamaOnayFormDataGridViewCheckBoxColumn";
            this.ihaleHarcamaOnayFormDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn
            // 
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn.DataPropertyName = "Piyasa Fiyat Arastırma Tutanağı";
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn.HeaderText = "Piyasa Fiyat Arastırma Tutanağı";
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn.Name = "piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn";
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn.ReadOnly = true;
            this.piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn.Width = 72;
            // 
            // kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn
            // 
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn.DataPropertyName = "Kabul Komisyonu Olur Yazısı";
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn.HeaderText = "Kabul Komisyonu Olur Yazısı";
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn.Name = "kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn";
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn.ReadOnly = true;
            this.kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn.Width = 90;
            // 
            // kesinKabulTutanağıDataGridViewCheckBoxColumn
            // 
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn.DataPropertyName = "Kesin Kabul Tutanağı";
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn.HeaderText = "Kesin Kabul Tutanağı";
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn.Name = "kesinKabulTutanağıDataGridViewCheckBoxColumn";
            this.kesinKabulTutanağıDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // satınalmasayacDataGridViewTextBoxColumn
            // 
            this.satınalmasayacDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.satınalmasayacDataGridViewTextBoxColumn.DataPropertyName = "satınalmasayac";
            this.satınalmasayacDataGridViewTextBoxColumn.HeaderText = "satınalmasayac";
            this.satınalmasayacDataGridViewTextBoxColumn.Name = "satınalmasayacDataGridViewTextBoxColumn";
            this.satınalmasayacDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // doğrudanTeminBilgilendirmeTablosuBindingSource
            // 
            this.doğrudanTeminBilgilendirmeTablosuBindingSource.DataMember = "DoğrudanTeminBilgilendirmeTablosu";
            this.doğrudanTeminBilgilendirmeTablosuBindingSource.DataSource = this.zekaDenemeProje1DataSet;
            // 
            // zekaDenemeProje1DataSet
            // 
            this.zekaDenemeProje1DataSet.DataSetName = "ZekaDenemeProje1DataSet";
            this.zekaDenemeProje1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // doğrudanTeminBilgilendirmeTablosuTableAdapter
            // 
            this.doğrudanTeminBilgilendirmeTablosuTableAdapter.ClearBeforeFill = true;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            // 
            // SatınAlmaBilgilendirmeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1338, 741);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SatınAlmaBilgilendirmeFormu";
            this.Text = "Satın Alma Bilgilendirme Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SatınAlmaBilgilendirmeFormu_FormClosing);
            this.Load += new System.EventHandler(this.SatınAlmaBilgilendirmeFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doğrudanTeminBilgilendirmeTablosuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zekaDenemeProje1DataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ZekaDenemeProje1DataSet zekaDenemeProje1DataSet;
        private System.Windows.Forms.BindingSource doğrudanTeminBilgilendirmeTablosuBindingSource;
        private ZekaDenemeProje1DataSetTableAdapters.DoğrudanTeminBilgilendirmeTablosuTableAdapter doğrudanTeminBilgilendirmeTablosuTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn satınAlmaidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soyadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn üsülAdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn işinAdıDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn idariVeTeknikŞartNameDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sözlesmeTaslagıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn yaklasıkMaliyetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn firmaEklemeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn birinciTeklifTipYaklasıkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn satınAlmaTalepFormuDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn nihaiTeklifDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn teklifFirmaEklemeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ihaleHarcamaOnayFormDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn piyasaFiyatArastırmaTutanağıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kabulKomisyonuOlurYazısıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn kesinKabulTutanağıDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn satınalmasayacDataGridViewTextBoxColumn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}