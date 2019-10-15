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
    public partial class HerkezeAçıkİhaleHizmetAlımıSözleşmeDavetMektubu : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıSözleşmeDavetMektubu()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\Sözleşmeye Davet Mektubu.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2Sözleşmeye Davet Mektubu.doc";
        
        private void DökümanHazırla()
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
                        else if (field.Code.Text.Contains("ihalekararonaytarih"))
                        {
                            field.Select();
                            application.Selection.TypeText(dateTimePicker1.Text);
                        }
                        else if (field.Code.Text.Contains("eldentarih"))
                        {
                            field.Select();
                            application.Selection.TypeText(dateTimePicker2.Text);
                        }
                        else if (field.Code.Text.Contains("tercihedilenfirma"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu.tercihedilenfirma);
                        }
                        else if (field.Code.Text.Contains("tercihedilenfirmaadres"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu.firmadres);
                        }
                       
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);

                
            

        }
        private void HerkezeAçıkİhaleHizmetAlımıSözleşmeDavetMektubu_Load(object sender, EventArgs e)
        {

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
    }
}