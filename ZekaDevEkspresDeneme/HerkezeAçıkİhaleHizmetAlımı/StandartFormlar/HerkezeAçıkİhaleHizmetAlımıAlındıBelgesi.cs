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
    public partial class HerkezeAçıkİhaleHizmetAlımıAlındıBelgesi : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıAlındıBelgesi()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Alındı Belgesi.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Alındı Belgesi.doc";
        public static DateTime isverentekliftarih;
        private void DökümanHazırla()
        {
            isverentekliftarih = dateTimePicker1.Value;
            if (isverentekliftarih > HerkezeAçıkİhaleHizmetAlımıİdariŞartName.İsBitmeSüre)
            {
                XtraMessageBox.Show("İsteklinin Verdiği Tarih Son Teklif Tarihinden Geç Verilmiş");
            }
            else
            {
                if (isteklifirmatext.Text == "" || sıranotext.Text == "")
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
                        else if (field.Code.Text.Contains("sonteklif"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.sontekliftarih + " " + HerkezeAçıkİhaleHizmetAlımıİdariŞartName.sontarihzaman);
                        }
                        else if (field.Code.Text.Contains("verensaat"))
                        {
                            field.Select();
                            application.Selection.TypeText(dateTimePicker1.Text + " " + dateEdit1.Text);
                        }
                        else if (field.Code.Text.Contains("sırano"))
                        {
                            field.Select();
                            application.Selection.TypeText(sıranotext.Text);
                        }
                        else if (field.Code.Text.Contains("istekliad"))
                        {
                            field.Select();
                            application.Selection.TypeText(isteklifirmatext.Text);
                        }
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);

                }
            }
        }
        private void HerkezeAçıkİhaleHizmetAlımıAlındıBelgesi_Load(object sender, EventArgs e)
        {

        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
     }
}