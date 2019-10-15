namespace ZekaDevEkspresDeneme
{
    partial class HerkeseAçıkİhaleHizmetAlımıMuayeneVeKabulKomisyonuOluşturmaYazısı
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HerkeseAçıkİhaleHizmetAlımıMuayeneVeKabulKomisyonuOluşturmaYazısı));
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // richEditControl1
            // 
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richEditControl1.Location = new System.Drawing.Point(369, 0);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(825, 619);
            this.richEditControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.simpleButton1.Location = new System.Drawing.Point(12, 142);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(311, 39);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Muayene ve Kabul Komisyonu Oluşturma Yazısı Oluştur";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // HerkeseAçıkİhaleHizmetAlımıMuayeneVeKabulKomisyonuOluşturmaYazısı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 619);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.richEditControl1);
            this.Name = "HerkeseAçıkİhaleHizmetAlımıMuayeneVeKabulKomisyonuOluşturmaYazısı";
            this.Text = "Herkese Açık İhale Hizmet Alımı Muayene Ve Kabul Komisyonu Oluşturma Yazısı";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}