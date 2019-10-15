namespace ZekaDevEkspresDeneme
{
    partial class HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi));
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sekiltext = new System.Windows.Forms.TextBox();
            this.bedeltext = new System.Windows.Forms.TextBox();
            this.acıklamatext = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // richEditControl1
            // 
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richEditControl1.Location = new System.Drawing.Point(595, 0);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(718, 629);
            this.richEditControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Belge Tarihi :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "İlan Şekli Ve Adeti :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ön Yeterlik / İhale Dokümanı Satış Bedeli :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "İhale İle İlgili Açıklama :";
            // 
            // sekiltext
            // 
            this.sekiltext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sekiltext.Location = new System.Drawing.Point(281, 64);
            this.sekiltext.Name = "sekiltext";
            this.sekiltext.Size = new System.Drawing.Size(137, 14);
            this.sekiltext.TabIndex = 6;
            // 
            // bedeltext
            // 
            this.bedeltext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bedeltext.Location = new System.Drawing.Point(281, 105);
            this.bedeltext.Name = "bedeltext";
            this.bedeltext.Size = new System.Drawing.Size(137, 14);
            this.bedeltext.TabIndex = 7;
            // 
            // acıklamatext
            // 
            this.acıklamatext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.acıklamatext.Location = new System.Drawing.Point(281, 141);
            this.acıklamatext.Multiline = true;
            this.acıklamatext.Name = "acıklamatext";
            this.acıklamatext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.acıklamatext.Size = new System.Drawing.Size(137, 70);
            this.acıklamatext.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(281, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(151, 271);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(207, 41);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Text = "İhale Harcama Onay Oluştur";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 629);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.acıklamatext);
            this.Controls.Add(this.bedeltext);
            this.Controls.Add(this.sekiltext);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richEditControl1);
            this.Name = "HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi";
            this.Text = "Herkes Açık İhale Hizmet Alımı İhale Harcama Onay Belgesi";
            this.Load += new System.EventHandler(this.HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox sekiltext;
        private System.Windows.Forms.TextBox bedeltext;
        private System.Windows.Forms.TextBox acıklamatext;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}