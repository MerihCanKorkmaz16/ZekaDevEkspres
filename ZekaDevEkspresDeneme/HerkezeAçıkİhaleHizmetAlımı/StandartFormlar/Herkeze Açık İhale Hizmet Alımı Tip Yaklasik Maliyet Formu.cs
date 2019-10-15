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
    public partial class HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Tip Yaklaşık Maliyet Hesap Formu.doc";
        public static decimal firma1fiyat, firma2fiyat, firma3fiyat, ortalama;
        public static string firma1, firma2, firma3;
        public static int teklifsayisi;
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
                else if (field.Code.Text.Contains("isinkodu"))
                {
                    field.Select();
                    application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.kayıtno);
                }
                else if (field.Code.Text.Contains("sıra1"))
                {
                    if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true )
                    {
                        field.Select();
                        application.Selection.TypeText("1");
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("sıra2"))
                {
                    if (radioButton2.Checked == true || radioButton3.Checked == true)
                    {
                        field.Select();
                        application.Selection.TypeText("2");
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("sıra3"))
                {
                    if (radioButton3.Checked == true)
                    {
                        field.Select();
                        application.Selection.TypeText("3");
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("satıs1"))
                {
                    if (radioButton1.Checked == true  || radioButton2.Checked == true || radioButton3.Checked)
                    {
                        field.Select();
                        application.Selection.TypeText(firma1text.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("satıs2"))
                {
                    if (radioButton2.Checked == true || radioButton3.Checked)
                    {
                        field.Select();
                        application.Selection.TypeText(firma2text.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("satıs3"))
                {
                    if (radioButton3.Checked == true)
                    {
                        field.Select();
                        application.Selection.TypeText(firma3text.Text);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("fiyat1"))
                {
                    if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true)
                    {
                        field.Select();
                        application.Selection.TypeText(firma1fiyat.ToString("#,##0.00₺"));
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("fiyat2"))
                {
                    if (radioButton2.Checked == true || radioButton3.Checked == true)
                    {
                        field.Select();
                        application.Selection.TypeText(firma2fiyat.ToString("#,##0.00₺"));
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("fiyat3"))
                {
                    if (radioButton3.Checked == true)
                    {
                        field.Select();
                        application.Selection.TypeText(firma3fiyat.ToString("#,##0.00₺"));
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("yaklasikmaliyet"))
                {
                     field.Select();
                     application.Selection.TypeText(ortalama.ToString("#,##0.00₺"));
                }
                else if (field.Code.Text.Contains("komisyon1"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2);
                    }

                }
                else if (field.Code.Text.Contains("komisyon2"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3);
                    }
                }
                else if (field.Code.Text.Contains("metin1"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText("İhale Komisyonu Üyesi");
                    }
                }
                else if (field.Code.Text.Contains("metin2"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText("İhale Komisyonu Üyesi");
                    }
                }
                else if (field.Code.Text.Contains("komisyonbaskan"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1);
                    }
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
        private void OrtalamaAlma()
        {
            if (radioButton1.Checked)
            {
                ortalama = firma1fiyat;
                ortalama = Math.Truncate(100 * ortalama) / 100;
                firma1 = firma1text.Text;
                teklifsayisi = 1;
            }
            if (radioButton2.Checked)
            {
                ortalama = (firma1fiyat + firma2fiyat) /2;
                ortalama = Math.Truncate(100 * ortalama) / 100;
                firma1 = firma1text.Text;
                firma2 = firma2text.Text;
                teklifsayisi = 2;
            }
            if (radioButton3.Checked)
            {
                ortalama = (firma1fiyat + firma2fiyat + firma3fiyat) / 3;
                ortalama = Math.Truncate(100 * ortalama) / 100;
                firma1 = firma1text.Text;
                firma2 = firma2text.Text;
                firma3 = firma3text.Text;
                teklifsayisi = 3;

            }
        }
        private void Firma2maliyettext_Leave(object sender, EventArgs e)
        {
            if (Decimal.TryParse(firma2maliyettext.Text, out firma2fiyat))
                firma2maliyettext.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", firma2fiyat);
            else
                firma2maliyettext.Text = String.Empty;
        }
        private void Firma3maliyettext_Leave(object sender, EventArgs e)
        {
            if (Decimal.TryParse(firma3maliyettext.Text, out firma3fiyat))
                firma3maliyettext.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", firma3fiyat);
            else
                firma3maliyettext.Text = String.Empty;
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label1.Visible = true;
                label5.Visible = true;
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;

            }
            if (radioButton2.Checked)
            {
                label1.Visible = true;
                label5.Visible = true;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;

            }
            if (radioButton3.Checked)
            {
                label1.Visible = true;
                label5.Visible = true;
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;

            }
        }
        private void Firma1maliyettext_Leave(object sender, EventArgs e)
        {
            if (Decimal.TryParse(firma1maliyettext.Text, out firma1fiyat))
                firma1maliyettext.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:C2}", firma1fiyat);
            else
                firma1maliyettext.Text = String.Empty;
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            OrtalamaAlma();
            DökümanıOluştur();
        }
        private void HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu_Load(object sender, EventArgs e)
        {

        }
    }
}