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
    public partial class HerkezeAçıkİhaleHizmetAlımıKontrolVeMuayneKomisyonTablosu : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıKontrolVeMuayneKomisyonTablosu()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Komisyon\\2Kontrol ve Muayne Komisyon Tablosu.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Komisyon\\Kontrol ve Muayne Komisyon Tablosu.doc";
        private void KayıtlıKomisyonGetir()
        {
            label6.Text = HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1;
            label7.Text = HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2;
            label8.Text = HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3;
            

            if (HerkezeAçıkİhaleKomisyonOlurYazısı.dökümansayac == 1)
            {
                groupBox1.Visible = true;
            }
            if (HerkezeAçıkİhaleKomisyonOlurYazısı.dökümansayac == 2)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
            }
            if (HerkezeAçıkİhaleKomisyonOlurYazısı.dökümansayac == 3)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
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
                        else if (field.Code.Text.Contains("komisyon1"))
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
                        else if (field.Code.Text.Contains("komisyon2"))
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
                        else if (field.Code.Text.Contains("komisyon3"))
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
                        else if (field.Code.Text.Contains("yedek1"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText(textBox1.Text);
                    }

                }
                        else if (field.Code.Text.Contains("yedek2"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText(textBox2.Text);
                    }
                }
                        else if (field.Code.Text.Contains("yedek3"))
                {
                    if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3 == null)
                    {
                        field.Delete();
                    }
                    else
                    {

                        field.Select();
                        application.Selection.TypeText(textBox3.Text);
                    }
                }
                        else if (field.Code.Text.Contains("asil"))
                        {
                         field.Select();
                         application.Selection.TypeText(textBox5.Text);
                        }
                        else if (field.Code.Text.Contains("yedek"))
                        {
                  
                        field.Select();
                        application.Selection.TypeText(textBox6.Text);
                         }

                  }
            document.SaveAs2(path1);
            document.Close();
            application.Quit();
            richEditControl1.LoadDocument(path1);
             
        }
        private void HerkezeAçıkİhaleHizmetAlımıKontrolVeMuayneKomisyonTablosu_Load(object sender, EventArgs e)
        {
            KayıtlıKomisyonGetir();
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanıOluştur();
        }
    }
}