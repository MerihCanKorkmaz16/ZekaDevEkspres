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
    public partial class HerkezeAcıkİhaleHizmetAlımıİhaleİptalKararıBildirimMektubu : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAcıkİhaleHizmetAlımıİhaleİptalKararıBildirimMektubu()
        {
            InitializeComponent();
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\İhale İptal Kararı Bildirim Mektubu.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Standart Formlar\\2İhale İptal Kararı Bildirim Mektubu.doc";
        public DateTime tarih1, tarih2;
        private void DökümanHazırla()
        {
            if (tarih2< tarih1)
            {
                XtraMessageBox.Show("İhale İptal Kararı İhale Tarihinden Küçük Olamaz");
            }
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    XtraMessageBox.Show("Lütfen İlgili Yerleri Doldurunuz");
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
                        else if (field.Code.Text.Contains("kayıtno"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİdariŞartName.kayıtno);
                        }
                        else if (field.Code.Text.Contains("ihaletarih"))
                        {
                            field.Select();
                            application.Selection.TypeText(dateTimePicker1.Text);
                        }
                        else if (field.Code.Text.Contains("iptalihaletarih"))
                        {
                            field.Select();
                            application.Selection.TypeText(dateTimePicker2.Text);
                        }
                        else if (field.Code.Text.Contains("iptalfirma"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text);
                        }
                        else if (field.Code.Text.Contains("iptalfirmaadres"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox2.Text);
                        }
                        else if (field.Code.Text.Contains("gerekce"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox3.Text);
                        }

                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);

                }
            }

        }

       private void HerkezeAcıkİhaleHizmetAlımıİhaleİptalKararıBildirimMektubu_Load(object sender, EventArgs e)
        {

        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox1.Visible = true;
            }
            if (checkBox1.Checked == false)
            {
                groupBox1.Visible = false;
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            tarih1 = dateTimePicker1.Value;
            tarih2 = dateTimePicker2.Value;

            DökümanHazırla();
        }
    }
}