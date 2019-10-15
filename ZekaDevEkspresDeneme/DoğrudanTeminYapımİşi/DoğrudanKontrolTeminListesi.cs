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
    public partial class DoğrudanKontrolTeminListesi : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanKontrolTeminListesi()
        {
            InitializeComponent();
        }

        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\07 Doğrudan Temin Kontrol Listesi.docx";
        string path1 = ExeDosyaYolu + "\\071 Doğrudan Temin Kontrol Listesi.docx";
        string path2 = ExeDosyaYolu + "\\072 Doğrudan Temin Kontrol Listesi.docx";

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Microsoft.Office.Interop.Word.Document();
            application.Visible = false;
            document = application.Documents.Add(path);

          

            document.SaveAs2(path2);
            document.Close();
            application.Quit();
            richEditControl1.LoadDocument(path2);
            XtraMessageBox.Show("Dökümanınınız Başarıyla Hazırlandı.");
            
        }

        private void DoğrudanKontrolTeminListesi_Load(object sender, EventArgs e)
                {
                }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            foreach (Control item in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
            {
                if (item is TreeView)
                {
                    foreach (Control item1 in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
                    {
                        if (item1 is Panel)
                        {
                            DoğrudanTeminSözleşmeliYapımİşiFormu.nodeDegistirme(((TreeView)item).SelectedNode, ((TreeView)item), ((Panel)item1));
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }


    }