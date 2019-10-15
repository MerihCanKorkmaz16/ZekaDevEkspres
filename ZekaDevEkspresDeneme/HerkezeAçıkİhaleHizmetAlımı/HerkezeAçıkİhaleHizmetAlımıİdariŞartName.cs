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
    public partial class HerkezeAçıkİhaleHizmetAlımıİdariŞartName : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıİdariŞartName()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\01.01 İdari Şartname.docx";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\012.01 İdari Şartname.docx";
        public static string isAdi, istarih1, istarih2, sontekliftarih, sontarihzaman,kayıtno,miktar;
        public static DateTime İsinTarih1, İsinTarih2,İsBitmeSüre;
        private void DökümanHazırla()
        {
            İsinTarih1 = dateTimePicker1.Value;
            İsinTarih2 = dateTimePicker2.Value;
            İsBitmeSüre = dateTimePicker3.Value;
            if (İsBitmeSüre > İsinTarih2)
            {
                XtraMessageBox.Show("Son Teklif Tarihi İş Süresi Tarihleri Arasında Olmalı");
            }
            else
            {
                if (İsinTarih1 > İsinTarih2)
                {
                    XtraMessageBox.Show("İşin Süresi Belirlenirken Birinci Tarih İkinci Tarihten Büyük Olamaz");
                }
                else
                {
                    if (isaditext.Text == "" || miktartext.Text == "" || kayıtnotext.Text == "")
                    {
                        XtraMessageBox.Show("Gerekli Alanları Lütfen doldurunuz..");

                    }
                    else
                    {
                        isAdi = isaditext.Text;
                        istarih1 = dateTimePicker1.Text;
                        istarih2 = dateTimePicker2.Text;
                        sontekliftarih = dateTimePicker3.Text;
                        sontarihzaman = dateEdit1.Text;
                        kayıtno = kayıtnotext.Text;
                        miktar = miktartext.Text;
                        var application = new Microsoft.Office.Interop.Word.Application();
                        var document = new Microsoft.Office.Interop.Word.Document();
                        application.Visible = false;
                        document = application.Documents.Add(path);

                        foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                        {
                            if (field.Code.Text.Contains("isAdi"))
                            {
                                field.Select();
                                application.Selection.TypeText(isaditext.Text);
                            }
                            else if (field.Code.Text.Contains("miktar"))
                            {
                                field.Select();
                                application.Selection.TypeText(miktartext.Text);
                            }
                            else if (field.Code.Text.Contains("tarih1"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateTimePicker1.Text);
                            }
                            else if (field.Code.Text.Contains("tarih2"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateTimePicker2.Text);
                            }
                            else if (field.Code.Text.Contains("sonteklifdate"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateTimePicker3.Text);
                            }
                            else if (field.Code.Text.Contains("sontekliftime"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateEdit1.Text);
                            }
                            else if (field.Code.Text.Contains("kayıtno"))
                            {
                                field.Select();
                                application.Selection.TypeText(kayıtnotext.Text);
                            }
                        }

                        document.SaveAs2(path1);
                        document.Close();
                        application.Quit();
                        richEditControl1.LoadDocument(path1);
                    }
                }
            }
        }
        private void HerkezeAçıkİhaleHizmetAlımıİdariŞartName_Load(object sender, EventArgs e)
        {

        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
    }
}