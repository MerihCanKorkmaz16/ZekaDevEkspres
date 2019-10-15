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
    public partial class HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi : DevExpress.XtraEditors.XtraForm
    {
        public HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\İhale - Harcama Onay Belgesi.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2İhale - Harcama Onay Belgesi.doc";
        private void DökümanHazırla()
        {
            if (sekiltext.Text == "" || acıklamatext.Text == "" || bedeltext.Text == "")
            {
                XtraMessageBox.Show("Gerekli Alanları Lütfen doldurunuz..");

            }
            else
            {
                 var application = new Microsoft.Office.Interop.Word.Application();
                var document = new Microsoft.Office.Interop.Word.Document();
                application.Visible = false;
                document = application.Documents.Add(path);

                foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                {
                    if (field.Code.Text.Contains("tarih"))
                    {
                        field.Select();
                        application.Selection.TypeText(dateTimePicker1.Text);
                    }
                    else if (field.Code.Text.Contains("konu"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu.konu);
                    }
                    else if (field.Code.Text.Contains("miktar"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.miktar);
                    }
                    else if (field.Code.Text.Contains("yaklasikmaliyet"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.ortalama.ToString("#,##0.00₺"));
                    }
                    else if (field.Code.Text.Contains("ilansekil"))
                    {
                        field.Select();
                        application.Selection.TypeText(sekiltext.Text);
                    }
                    else if (field.Code.Text.Contains("satisbedeli"))
                    {
                        field.Select();
                        application.Selection.TypeText(bedeltext.Text);
                    }
                    else if (field.Code.Text.Contains("acıklama"))
                    {
                        field.Select();
                        application.Selection.TypeText(acıklamatext.Text);
                    }
                }

                document.SaveAs2(path1);
                document.Close();
                application.Quit();
                richEditControl1.LoadDocument(path1);

            }
        }
        private void HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi_Load(object sender, EventArgs e)
        {

        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
    }
}