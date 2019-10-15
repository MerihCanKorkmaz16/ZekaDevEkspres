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
    public partial class HerkezeAçıkİhaleHizmetAlımıZarfAçmaKontrolTutanağı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıZarfAçmaKontrolTutanağı()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Zarf Açma ve Kontrol Tutanağı.docx";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Zarf Açma ve Kontrol Tutanağı.docx";
        private void FirmaGetir()
        {
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
            {
                groupBox1.Visible = true;
                label3.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
            {
                groupBox2.Visible = true;
                label4.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
            {
                groupBox3.Visible = true;
                label5.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3;
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
                else if (field.Code.Text.Contains("firmatarih"))
                {
                    
                   field.Select();
                   application.Selection.TypeText(dateTimePicker1.Text);
                   
                }
                else if (field.Code.Text.Contains("firmasaat"))
                {

                    field.Select();
                    application.Selection.TypeText(dateEdit1.Text); ;

                }
                else if (field.Code.Text.Contains("firma1"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("firma2"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("firma3"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3);
                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("teklifmektubu"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox1.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");

                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }
                        
                    }
                 
                }
                else if (field.Code.Text.Contains("birimfiyatcetveli"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox2.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("ticaretsicil"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox3.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("odakayıt"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox4.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("imza"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox5.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("velaketname"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox6.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("isdeneyim"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox7.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("geciciteminat"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox8.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("isortak"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox9.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("faaliyet"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox10.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("ortaklıkdurum"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
                    {
                        if (checkBox11.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }

                }
                else if (field.Code.Text.Contains("1a"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox22.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }

                }
                else if (field.Code.Text.Contains("2b"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox21.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("3c"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox20.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("4d"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox19.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("5e"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox18.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("6f"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox17.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("7g"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox16.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("8x"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox15.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("9y"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox14.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("10m"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox13.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("11z"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
                    {
                        if (checkBox12.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        else
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("one"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (one.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (one.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("two"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (two.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (two.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("tri"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (tri.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (tri.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("four"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (four.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (four.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("five"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (five.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (five.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("six"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (six.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (six.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("seven"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (seven.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (seven.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("eight"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (eight.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (eight.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("nine"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (nine.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (nine.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("ten"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (ten.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (ten.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

                    }
                    else
                    {
                        field.Delete();
                    }
                }
                else if (field.Code.Text.Contains("eleven"))
                {
                    if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
                    {
                        if (eleven.Checked == true)
                        {
                            field.Select();
                            application.Selection.TypeText("✓");
                        }
                        if (eleven.Checked == false)
                        {
                            field.Select();
                            application.Selection.TypeText("GD");
                        }

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


        private void HerkezeAçıkİhaleHizmetAlımıZarfAçmaKontrolTutanağı_Load(object sender, EventArgs e)
        {
            FirmaGetir();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanıOluştur();
        }
    }
}