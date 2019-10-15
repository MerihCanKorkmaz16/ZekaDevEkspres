namespace ZekaDevEkspresDeneme
{
    partial class DoğrudanTeminPeriyodikİdariVeTeknikŞartname
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
            this.richEditControl1 = new DevExpress.XtraRichEdit.RichEditControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hizmetinkapsamıtext = new System.Windows.Forms.TextBox();
            this.niteliktext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richEditControl1
            // 
            this.richEditControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.richEditControl1.Location = new System.Drawing.Point(556, 0);
            this.richEditControl1.Name = "richEditControl1";
            this.richEditControl1.Size = new System.Drawing.Size(820, 748);
            this.richEditControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mal ve Hizmetin Kapsamı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(367, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Satın Alınacak Malın Cinsi ve Miktarı,Hizmetin ve Yapım İşinin Niteliği";
            // 
            // hizmetinkapsamıtext
            // 
            this.hizmetinkapsamıtext.Location = new System.Drawing.Point(228, 30);
            this.hizmetinkapsamıtext.Name = "hizmetinkapsamıtext";
            this.hizmetinkapsamıtext.Size = new System.Drawing.Size(215, 21);
            this.hizmetinkapsamıtext.TabIndex = 3;
            // 
            // niteliktext
            // 
            this.niteliktext.Location = new System.Drawing.Point(68, 147);
            this.niteliktext.Multiline = true;
            this.niteliktext.Name = "niteliktext";
            this.niteliktext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.niteliktext.Size = new System.Drawing.Size(441, 444);
            this.niteliktext.TabIndex = 4;
            // 
            // DoğrudanTeminPeriyodikİdariVeTeknikŞartname
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 748);
            this.Controls.Add(this.niteliktext);
            this.Controls.Add(this.hizmetinkapsamıtext);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richEditControl1);
            this.Name = "DoğrudanTeminPeriyodikİdariVeTeknikŞartname";
            this.Text = "DoğrudanTeminPeriyodikİdariVeTeknikŞartname";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.DoğrudanTeminPeriyodikİdariVeTeknikŞartname_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraRichEdit.RichEditControl richEditControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hizmetinkapsamıtext;
        private System.Windows.Forms.TextBox niteliktext;
    }
}