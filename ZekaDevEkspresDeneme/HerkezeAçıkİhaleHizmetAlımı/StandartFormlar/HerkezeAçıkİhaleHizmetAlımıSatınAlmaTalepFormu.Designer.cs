namespace ZekaDevEkspresDeneme
{
    partial class HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu));
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.konutext = new System.Windows.Forms.TextBox();
            this.gerekcetext = new System.Windows.Forms.TextBox();
            this.acıklamatext = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // richEditControl1
            // 
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richEditControl1.Location = new System.Drawing.Point(481, 0);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(835, 630);
            this.richEditControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Belge Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Konu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gerekçe :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Açıklama";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(102, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // konutext
            // 
            this.konutext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.konutext.Location = new System.Drawing.Point(129, 65);
            this.konutext.MaxLength = 200;
            this.konutext.Multiline = true;
            this.konutext.Name = "konutext";
            this.konutext.Size = new System.Drawing.Size(139, 20);
            this.konutext.TabIndex = 6;
            this.konutext.TextChanged += new System.EventHandler(this.Konutext_TextChanged);
            // 
            // gerekcetext
            // 
            this.gerekcetext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gerekcetext.Location = new System.Drawing.Point(129, 103);
            this.gerekcetext.MaxLength = 200;
            this.gerekcetext.Multiline = true;
            this.gerekcetext.Name = "gerekcetext";
            this.gerekcetext.Size = new System.Drawing.Size(139, 21);
            this.gerekcetext.TabIndex = 7;
            this.gerekcetext.TextChanged += new System.EventHandler(this.Gerekcetext_TextChanged);
            // 
            // acıklamatext
            // 
            this.acıklamatext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.acıklamatext.Location = new System.Drawing.Point(127, 147);
            this.acıklamatext.MaxLength = 200;
            this.acıklamatext.Multiline = true;
            this.acıklamatext.Name = "acıklamatext";
            this.acıklamatext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.acıklamatext.Size = new System.Drawing.Size(151, 95);
            this.acıklamatext.TabIndex = 8;
            this.acıklamatext.TextChanged += new System.EventHandler(this.Acıklamatext_TextChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(78, 275);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(200, 35);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Satın Alma Talep Formu Oluştur";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 630);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.acıklamatext);
            this.Controls.Add(this.gerekcetext);
            this.Controls.Add(this.konutext);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richEditControl1);
            this.Name = "HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu";
            this.Text = "Herkeze Açık İhale Hizmet Alımı Satın Alma TalepFormu";
            this.Load += new System.EventHandler(this.HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox konutext;
        private System.Windows.Forms.TextBox gerekcetext;
        private System.Windows.Forms.TextBox acıklamatext;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}