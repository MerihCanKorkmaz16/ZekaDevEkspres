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

namespace ZekaDevEkspresDeneme
{
    public partial class HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Satınalma Talep Formu.docx";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Satınalma Talep Formu.docx";
        public static string konu;
        private void DökümanHazırla()
        {
            
            if (konutext.Text == "" || gerekcetext.Text == "" || acıklamatext.Text == "")
            {
                XtraMessageBox.Show("Gerekli Alanları Lütfen doldurunuz..");

            }
            else
            {
                konu = konutext.Text;
                var application = new Microsoft.Office.Interop.Word.Application();
                var document = new Microsoft.Office.Interop.Word.Document();
                application.Visible = false;
                document = application.Documents.Add(path);

                foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                {
                    if (field.Code.Text.Contains("kayıtno"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.kayıtno);
                    }
                    else if (field.Code.Text.Contains("konu"))
                    {
                        field.Select();
                        application.Selection.TypeText(konutext.Text);
                    }
                    else if (field.Code.Text.Contains("gerekçe"))
                    {
                        field.Select();
                        application.Selection.TypeText(gerekcetext.Text);
                    }
                    else if (field.Code.Text.Contains("yaklasikmaliyet"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.ortalama.ToString("#,##0.00₺"));
                    }
                    else if (field.Code.Text.Contains("tarih1"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.istarih1);
                    }
                    else if (field.Code.Text.Contains("tarih2"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.istarih2);
                    }
                    else if (field.Code.Text.Contains("açıklama"))
                    {
                        field.Select();
                        application.Selection.TypeText(acıklamatext.Text);
                    }
                    else if (field.Code.Text.Contains("tarih"))
                    {
                        field.Select();
                        application.Selection.TypeText(dateTimePicker1.Text);
                    }
                }

                document.SaveAs2(path1);
                document.Close();
                application.Quit();
                richEditControl1.LoadDocument(path1);
                
            }
        }
        private void HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu_Load(object sender, EventArgs e)
        {

        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
        private void Acıklamatext_TextChanged(object sender, EventArgs e)
        {
            if (acıklamatext.TextLength == acıklamatext.MaxLength )
            {
                XtraMessageBox.Show("Karakter Sınırını Aştınız");
            }
        }
        private void Konutext_TextChanged(object sender, EventArgs e)
        {
            if (konutext.TextLength == konutext.MaxLength)
            {
                XtraMessageBox.Show("Karakter Sınırını Aştınız");
            }
        }
        private void Gerekcetext_TextChanged(object sender, EventArgs e)
        {
            if (gerekcetext.TextLength == gerekcetext.MaxLength)
            {
                XtraMessageBox.Show("Karakter Sınırını Aştınız");
            }
        }
    }
}