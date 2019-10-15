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
    public partial class HerkezeAçıkİhaleHizmetAlımıTeknikŞartName : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıTeknikŞartName()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\01.02 Teknik Şartname.docx";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\012.02 Teknik Şartname.docx";

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
                           
                        }

                        document.SaveAs2(path1);
                        document.Close();
                        application.Quit();
                        richEditControl1.LoadDocument(path1);

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }

        private void HerkezeAçıkİhaleHizmetAlımıTeknikŞartName_Load(object sender, EventArgs e)
        {

        }
    }
}