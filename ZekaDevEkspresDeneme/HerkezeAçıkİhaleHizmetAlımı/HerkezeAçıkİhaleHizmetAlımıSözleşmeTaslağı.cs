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
    public partial class HerkezeAçıkİhaleHizmetAlımıSözleşmeTaslağı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımıSözleşmeTaslağı()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Sözleşme Taslağı.docx";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\2Sözleşme Taslağı.docx";
        private void DökümanOluştur()
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

        private void HerkezeAçıkİhaleHizmetAlımıSözleşmeTaslağı_Load(object sender, EventArgs e)
        {

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanOluştur();
        }
    }
}