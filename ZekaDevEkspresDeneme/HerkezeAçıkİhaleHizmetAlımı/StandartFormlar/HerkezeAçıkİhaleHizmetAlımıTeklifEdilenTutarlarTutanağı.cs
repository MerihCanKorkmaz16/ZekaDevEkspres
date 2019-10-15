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
    public partial class HerkezeAçıkİhaleHizmetAlımıTeklifEdilenTutarlarTutanağı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıTeklifEdilenTutarlarTutanağı()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Teklif Edilen Fiyatlar Tutanağı.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Teklif Edilen Fiyatlar Tutanağı.doc";
        private void FirmalarıGetir()
        {
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
            {
                label4.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
            {
                label5.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
            {
                label6.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1fiyat != 0)
            {
                label8.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1fiyat.ToString("#,##0.00₺");
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2fiyat != 0)
            {
                label9.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2fiyat.ToString("#,##0.00₺");
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3fiyat != 0)
            {
                label10.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3fiyat.ToString("#,##0.00₺");
            }
        }
        private void DökümanıOluştur()
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            application.Visible = false;
            document = application.Documents.Add(path);
            foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
            {
                if (field.Code.Text.Contains("isAdi"))
                {
                    field.Select();
                    application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.isAdi);
                }
                else if (field.Code.Text.Contains("kayıtno"))
                {
                    field.Select();
                    application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.kayıtno);
                }
                else if (field.Code.Text.Contains("tarih"))
                {
                     field.Select();
                     application.Selection.TypeText(dateTimePicker1.Text);
                   
                }
                else if (field.Code.Text.Contains("saat"))
                {
                   
                    field.Select();
                    application.Selection.TypeText(dateEdit1.Text);
                   
                }
                else if (field.Code.Text.Contains("firma1"))
                {
                    if (label4.Text != "")
                    {
                        field.Select();
                        application.Selection.TypeText(label4.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("firma2"))
                {
                    if (label5.Text != "")
                    {
                        field.Select();
                        application.Selection.TypeText(label5.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("firma3"))
                {
                    if (label6.Text != "")
                    {
                        field.Select();
                        application.Selection.TypeText(label6.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("fiyat1"))
                {
                    if (label8.Text != "")
                    {
                        field.Select();
                        application.Selection.TypeText(label8.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("fiyat2"))
                {
                    if (label9.Text != "")
                    {
                        field.Select();
                        application.Selection.TypeText(label9.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("fiyat3"))
                {
                    if (label10.Text != "")
                    {
                        field.Select();
                        application.Selection.TypeText(label10.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("komisyonbaskan"))
                {
                    field.Select();
                    application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1);
                }
                else if (field.Code.Text.Contains("komisyon1"))
                {
                    field.Select();
                    application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2);
                }
                else if (field.Code.Text.Contains("komisyon2"))
                {
                    field.Select();
                    application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3);
                }


            }
            document.SaveAs2(path1);
            document.Close();
            application.Quit();
            richEditControl1.LoadDocument(path1);

        }

        private void HerkezeAçıkİhaleHizmetAlımıTeklifEdilenTutarlarTutanağı_Load(object sender, EventArgs e)
        {
            FirmalarıGetir();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanıOluştur();
        }
    }
}
       