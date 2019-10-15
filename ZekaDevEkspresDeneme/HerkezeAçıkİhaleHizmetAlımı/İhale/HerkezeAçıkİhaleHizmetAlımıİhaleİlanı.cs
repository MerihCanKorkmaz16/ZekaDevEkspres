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
    public partial class HerkezeAçıkİhaleHizmetAlımıİhaleİlanı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıİhaleİlanı()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\İlan\\052 İhale İlanı.docx";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\İlan\\05 İhale İlanı.docx";
        public static string İsinAdi;
        public static DateTime tarih1, tarih2,ihaletarih;
        private void DökümanHazırla()
        {
            tarih1 = dateTimePicker1.Value;
            tarih2 = dateTimePicker2.Value;
            ihaletarih = dateTimePicker3.Value;
            İsinAdi = textBox1.Text;
           
                if (tarih2 < tarih1)
                {
                XtraMessageBox.Show("Tarih Formatını Dikkatli Giriniz.");
            }
                else
                {
                    if (ihaletarih > tarih2)
                    {
                        XtraMessageBox.Show("İhale Yapılacak Tarih , İhale tarihleri arasında olmalıdır.");
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
                                application.Selection.TypeText(textBox1.Text);
                            }

                            else if (field.Code.Text.Contains("tarih1"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateTimePicker1.Text);
                            }
                            else if (field.Code.Text.Contains("tarihiki"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateTimePicker2.Text);
                            }
                            else if (field.Code.Text.Contains("ihaletarih"))
                            {
                                field.Select();
                                application.Selection.TypeText(dateTimePicker3.Value.ToString());
                            }
                        }

                        document.SaveAs2(path1);
                        document.Close();
                        application.Quit();
                        richEditControl1.LoadDocument(path1);
                        XtraMessageBox.Show("Dökümanınınız Başarıyla Hazırlandı.");
                    }
                }

                
             
         }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }

        private void HerkezeAçıkİhaleHizmetAlımıİhaleİlanı_Load(object sender, EventArgs e)
        {

        }
    }
}