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
    public partial class HerkeseAçıkİhaleHizmetAlımıİhaleÖnYeterlilikFormu : DevExpress.XtraEditors.XtraForm
    {
        public HerkeseAçıkİhaleHizmetAlımıİhaleÖnYeterlilikFormu()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\İhale - Ön Yeterlik Dokümanı Teslim Formu.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2İhale - Ön Yeterlik Dokümanı Teslim Formu.doc";
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
                    else if (field.Code.Text.Contains("ihaletarih"))
                    {
                        field.Select();
                        application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.İsBitmeSüre.ToString());
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
    }
}