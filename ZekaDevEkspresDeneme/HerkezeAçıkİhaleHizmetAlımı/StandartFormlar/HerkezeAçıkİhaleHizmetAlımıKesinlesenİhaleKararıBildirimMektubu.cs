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
    public partial class HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Kesinleşen İhale Kararı Bildirim Mektubu.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Kesinleşen İhale Kararı Bildirim Mektubu.doc";
        public static string tercihedilenfirma;
        public static string firmadres;
        private void TercihEdilenFirmaGetir()
        {
            if (HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı.tercihedilenfirma != null)
            {
                label4.Text = HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı.tercihedilenfirma;
            }
        }
        private void DökümanıOluştur()
        {
            if (adrestext.Text == "")
            {
                XtraMessageBox.Show("İlgili Alanları Doldurunuz");
            }
            else
            {
                firmadres = adrestext.Text;
                var application = new Microsoft.Office.Interop.Word.Application();
                var document = new Microsoft.Office.Interop.Word.Document();
                application.Visible = false;
                document = application.Documents.Add(path);
                foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                {
                    if (field.Code.Text.Contains("kayıtno"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.kayıtno);
                    }
                    else if (field.Code.Text.Contains("ihalekarartarih"))
                    {
                        field.Select();
                        application.Selection.TypeText(dateTimePicker1.Text);

                    }
                    else if (field.Code.Text.Contains("onayihalekarar"))
                    {

                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.sontarihzaman);

                    }
                    else if (field.Code.Text.Contains("tercihedilenfirma"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı.tercihedilenfirma);

                    }
                    else if (field.Code.Text.Contains("tercihedilenfirmaadres"))
                    {
                        field.Select();
                        application.Selection.TypeText(adrestext.Text);

                    }
                    else if (field.Code.Text.Contains("ihaledate"))
                    {
                       field.Select();
                       application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.İsBitmeSüre.ToString());
                      
                    }
                    else if (field.Code.Text.Contains("isAdi"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.isAdi);
                    }


                }
                document.SaveAs2(path1);
                document.Close();
                application.Quit();
                richEditControl1.LoadDocument(path1);

            }


        }
        private void HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu_Load(object sender, EventArgs e)
        {
            TercihEdilenFirmaGetir();
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanıOluştur();
        }
    }
}