using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminPeriyodikSözlesmeTaslağı : DevExpress.XtraEditors.XtraForm 
    {
        private DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama x;
        public DoğrudanTeminPeriyodikSözlesmeTaslağı(DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama x)
        {
            InitializeComponent();
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_closing);
            this.x = x;
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Sözleşme2.docx";
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Sözleşme.docx";
        public static bool sözlesmetaslagıdurum = false;
        
        private void dökümanyükle()
        {
            if (!File.Exists(path))
            {
                XtraMessageBox.Show("Dosya Yok");
            }
            else
            {
                var word = new Word.Application();
                var document = word.Documents.Add(path);
                if (DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.tercihedilenfirma == null)
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                }
                else
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.tercihedilenfirma;

                }
                document.Variables["yükleniciad"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.tercihedilenfirma;
                document.Variables["yüklenicivergino"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.vergino;
                document.Variables["yükleniciadres"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.adres;
                document.Variables["yüklenicitelno"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.telno;
                document.Variables["yüklenicieposta"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.eposta;
                document.Variables["yüklenicifaxno"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.faxno;
                document.SaveAs2(path1);
                word.Quit();
                System.Threading.Thread.Sleep(500);
                richEditControl1.LoadDocument(path1);
            }

        }
        private void DoğrudanTeminPeriyodikSözlesmeTaslağı_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            DökümanyükleThread.RunWorkerAsync();
        }
        private void form_closing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (sözlesmetaslagıdurum == true)
            {
                x.label12.Text = "Sözlesme Taslağı Başarıyla Hazırlandı";
                x.label12.ForeColor = Color.Green;
                x.button4.Enabled = true;
                Dispose();
            }
        }
        private void DökümanyükleThread_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            dökümanyükle();
        }
        private void RichEditControl1_AutoCorrect(object sender, DevExpress.XtraRichEdit.AutoCorrectEventArgs e)
        {
            sözlesmetaslagıdurum = false;
        }
        private void FileSaveItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            sözlesmetaslagıdurum = true;

        }
    }
}