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
    public partial class HerkezeAçıkİhaleHizmetAlımıDeğerlendirmeDışıBırakılanTekliflerİçinİhaleKomisyonuTutanağı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıDeğerlendirmeDışıBırakılanTekliflerİçinİhaleKomisyonuTutanağı()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Değerlendirme Dışı Bırakılan Teklifler İçin İhale Komisyonu Tutanağı.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Değerlendirme Dışı Bırakılan Teklifler İçin İhale Komisyonu Tutanağı.doc";
        public static int gecerliteklif;
        private void SeriLabelGeçir()
        {
            Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label2").Click += (s, evt) =>
            {
                if (label6.Text == "")
                {
                    label6.Text = label2.Text;
                    label2.Enabled = false;
                }
                else if (label9.Text == "")
                {
                    label9.Text = label2.Text;
                    label2.Enabled = false;
                }
                else if (label11.Text == "")
                {
                    label11.Text = label2.Text;
                    label2.Enabled = false;
                }
               
            };
            Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label3").Click += (s, evt) =>
            {
                if (label6.Text == "")
                {
                    label6.Text = label3.Text;
                    label3.Enabled = false;
                }
                else if (label9.Text == "")
                {
                    label9.Text = label3.Text;
                    label3.Enabled = false;
                }
                else if (label11.Text == "")
                {
                    label11.Text = label3.Text;
                    label3.Enabled = false;
                }

            };
            Controls.OfType<Label>().FirstOrDefault(x => x.Name == "label4").Click += (s, evt) =>
            {
                if (label6.Text == "")
                {
                    label6.Text = label4.Text;
                    label4.Enabled = false;
                }
                else if (label9.Text == "")
                {
                    label9.Text = label4.Text;
                    label4.Enabled = false;
                }
                else if (label11.Text == "")
                {
                    label11.Text = label4.Text;
                    label4.Enabled = false;
                }

            };
        }
        private void FirmalarıGetir()
        {
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1 != null)
            {
                label2.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma1;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2 != null)
            {
                label3.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma2;
            }
            if (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3 != null)
            {
                label4.Text = HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.firma3;
            }
        }
        private void DökümanHazırla()
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text == "")
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
                        if (field.Code.Text.Contains("isAdi"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.isAdi);
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
                        else if (field.Code.Text.Contains("field1"))
                        {
                            field.Select();
                            application.Selection.TypeText(label6.Text);
                        }
                        else if (field.Code.Text.Contains("why1"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text);
                        }
                        else if (field.Code.Text.Contains("field2"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("field3"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("why2"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("why3"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("komisyonbaskan"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1);
                        }
                        else if (field.Code.Text.Contains("komisyon1"))
                        {
                            if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2 != null)
                            {
                                field.Select();
                                application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2);
                            }
                            else
                            {
                                field.Delete();
                            };
                        }
                        else if (field.Code.Text.Contains("komisyon2"))
                        {
                            if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3 != null)
                            {
                                field.Select();
                                application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3);
                            }
                            else
                            {
                                field.Delete();
                            }
                           
                        }
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);
                    gecerliteklif = (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.teklifsayisi) - 1;

                }
            }
            if (radioButton2.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
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
                        if (field.Code.Text.Contains("isAdi"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.isAdi);
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
                        else if (field.Code.Text.Contains("field1"))
                        {
                            field.Select();
                            application.Selection.TypeText(label6.Text);
                        }
                        else if (field.Code.Text.Contains("why1"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text);
                        }
                        else if (field.Code.Text.Contains("field2"))
                        {
                            field.Select();
                            application.Selection.TypeText(label9.Text);
                        }
                        else if (field.Code.Text.Contains("field3"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("why2"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox2.Text);
                        }
                        else if (field.Code.Text.Contains("why3"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("komisyonbaskan"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1);
                        }
                        else if (field.Code.Text.Contains("komisyon1"))
                        {
                            if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2 != null)
                            {
                                field.Select();
                                application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2);
                            }
                            else
                            {
                                field.Delete();
                            };
                        }
                        else if (field.Code.Text.Contains("komisyon2"))
                        {
                            if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3 != null)
                            {
                                field.Select();
                                application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3);
                            }
                            else
                            {
                                field.Delete();
                            }

                        }
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);
                    gecerliteklif = (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.teklifsayisi) - 2;

                }
            }
            if (radioButton3.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
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
                        if (field.Code.Text.Contains("isAdi"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.isAdi);
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
                        else if (field.Code.Text.Contains("field1"))
                        {
                            field.Select();
                            application.Selection.TypeText(label6.Text);
                        }
                        else if (field.Code.Text.Contains("why1"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text);
                        }
                        else if (field.Code.Text.Contains("field2"))
                        {
                            field.Select();
                            application.Selection.TypeText(label9.Text);
                        }
                        else if (field.Code.Text.Contains("field3"))
                        {
                            field.Select();
                            application.Selection.TypeText(label11.Text);
                        }
                        else if (field.Code.Text.Contains("why2"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox2.Text);
                        }
                        else if (field.Code.Text.Contains("why3"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox3.Text);
                        }
                        else if (field.Code.Text.Contains("komisyonbaskan"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon1);
                        }
                        else if (field.Code.Text.Contains("komisyon1"))
                        {
                            if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2 != null)
                            {
                                field.Select();
                                application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon2);
                            }
                            else
                            {
                                field.Delete();
                            };
                        }
                        else if (field.Code.Text.Contains("komisyon2"))
                        {
                            if (HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3 != null)
                            {
                                field.Select();
                                application.Selection.TypeText(HerkezeAçıkİhaleKomisyonOlurYazısı.komisyon3);
                            }
                            else
                            {
                                field.Delete();
                            }

                        }
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);
                    gecerliteklif = (HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu.teklifsayisi) - 3;

                }
            }

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked ==true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
            }
            if (radioButton2.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
            }
            if (radioButton3.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
            }
        }
        private void DeğerlendirmeDışıBırakılanTekliflerİçinİhaleKomisyonuTutanağı_Load(object sender, EventArgs e)
        {
            FirmalarıGetir();
            SeriLabelGeçir();
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
    }
}