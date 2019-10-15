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
using System.Data.SqlClient;

namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminPeriyodikİdariVeTeknikŞartname : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPeriyodikİdariVeTeknikŞartname()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\2Teknik ve İdari Şartname.docx";
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Teknik ve İdari Şartname.docx";
        //private void dökümanyükle()
        //{
        //    if (!File.Exists(path))
        //    {
        //        XtraMessageBox.Show("Dosya Yok");
        //    }
        //    else
        //    {
        //        var word = new Word.Application();
        //        var document = word.Documents.Add(path);
        //        if (DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.tercihedilenfirma == null)
        //        {
        //            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

        //        }
        //        else
        //        {
        //            document.Variables["isAdi"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.tercihedilenfirma;

        //        }
        //        document.Variables["hizmet"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.tercihedilenfirma;
        //        document.Variables["yüklenicivergino"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.vergino;
        //        document.Variables["yükleniciadres"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.adres;
        //        document.Variables["yüklenicitelno"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.telno;
        //        document.Variables["yüklenicieposta"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.eposta;
        //        document.Variables["yüklenicifaxno"].Value = DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.faxno;
        //        document.SaveAs2(path1);
        //        word.Quit();
        //        System.Threading.Thread.Sleep(500);
        //        richEditControl1.LoadDocument(path1);
        //    }

        //}
        private void DoğrudanTeminPeriyodikİdariVeTeknikŞartname_Load(object sender, EventArgs e)
        {

        }
    }
}