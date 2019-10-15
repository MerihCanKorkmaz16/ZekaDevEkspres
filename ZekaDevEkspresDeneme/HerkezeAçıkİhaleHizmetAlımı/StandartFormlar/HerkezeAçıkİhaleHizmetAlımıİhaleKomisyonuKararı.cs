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
    public partial class HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\İhale Komisyonu Kararı.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2İhale Komisyonu Kararı.doc";
        public static string tercihedilenfirma;
        private void FirmalarıGetir()
        {
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
            {
                radioButton1.Visible = true;
                radioButton1.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1;
                tercihedilenfirma = radioButton1.Text;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
            {
                radioButton2.Visible = true;
                radioButton2.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2;
                tercihedilenfirma = radioButton2.Text;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
            {
                radioButton3.Visible = true;
                radioButton3.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3;
                tercihedilenfirma = radioButton3.Text;
            }
        }
        private void DökümanıOluştur()
        {
            if (karartext.Text == "")
            {
                XtraMessageBox.Show("İlgili Alanları Doldurunuz");
            }
            else
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
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.sontekliftarih);

                    }
                    else if (field.Code.Text.Contains("saat"))
                    {

                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.sontarihzaman);

                    }
                    else if (field.Code.Text.Contains("toplamteklif"))
                    {
                         field.Select();
                         application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.teklifsayisi.ToString());
                       
                    }
                    else if (field.Code.Text.Contains("gecerliteklif"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıDeğerlendirmeDışıBırakılanTekliflerİçinİhaleKomisyonuTutanağı.gecerliteklif.ToString());

                    }
                    else if (field.Code.Text.Contains("tercihfirma"))
                    {
                        if (radioButton1.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText(radioButton1.Text);
                        }
                        else if (radioButton2.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText(radioButton2.Text);
                        }
                        else if (radioButton3.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText(radioButton3.Text);
                        }

                    }
                    else if (field.Code.Text.Contains("tercihfiyat"))
                    {
                        if (radioButton1.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1fiyat.ToString("#,##0.00₺"));
                        }
                        else if (radioButton2.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2fiyat.ToString("#,##0.00₺"));
                        }
                        else if (radioButton3.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3fiyat.ToString("#,##0.00₺"));
                        }
                    }
                    else if (field.Code.Text.Contains("belgetarih"))
                    {
                        
                            field.Select();
                            application.Selection.TypeText(dateTimePicker1.Text + " " + dateEdit1.Text);
                      
                    }
                    else if (field.Code.Text.Contains("karar"))
                    {
                       
                         field.Select();
                        application.Selection.TypeText(karartext.Text);
                       
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


        }
        private void HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı_Load(object sender, EventArgs e)
        {
            FirmalarıGetir();
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanıOluştur();
        }
        private void Karartext_TextChanged(object sender, EventArgs e)
        {
            if (karartext.TextLength == karartext.MaxLength)
            {
                XtraMessageBox.Show("Maximum karakter sınırını aştınız");
            }
        }
    }
}