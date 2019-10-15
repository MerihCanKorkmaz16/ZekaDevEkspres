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
    public partial class HerkezeAçıkİhaleKomisyonOlurYazısı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleKomisyonOlurYazısı()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Komisyon\\012 İhale - Satınalma Komisyonu Oluşturma Yazısı.doc";
        string path1 = ExeDosyaYolu + "\\Herkeze Açık İhale Hizmet Alımı\\Komisyon\\01 İhale - Satınalma Komisyonu Oluşturma Yazısı.doc";
        public static string komisyon1, komisyon2, komisyon3;
        public static int dökümansayac = 0;
        private void DökümanHazırla()
        {
            if (radioButton1.Checked == true)
            {
                if (textBox1.Text == "")
                {
                    XtraMessageBox.Show("Gerekli Alanları Lütfen doldurunuz..");

                }
                else
                {
                    komisyon1 = textBox1.Text;
                    var application = new Microsoft.Office.Interop.Word.Application();
                    var document = new Microsoft.Office.Interop.Word.Document();
                    application.Visible = false;
                    document = application.Documents.Add(path);

                    foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                    {
                        if (field.Code.Text.Contains("isAdi"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİhaleİlanı.İsinAdi);
                        }

                        else if (field.Code.Text.Contains("komisyon1"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text);
                        }
                        else if (field.Code.Text.Contains("komisyon2"))
                        {
                            field.Delete();
                        }
                        else if (field.Code.Text.Contains("komisyon3"))
                        {
                            field.Delete();
                        }
                       
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);
                    dökümansayac = 1;
                }
            }
            if (radioButton2.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    XtraMessageBox.Show("Gerekli Alanları Lütfen doldurunuz..");

                }
                else
                {
                    komisyon1 = textBox1.Text;
                    komisyon2 = textBox2.Text;
                    var application = new Microsoft.Office.Interop.Word.Application();
                    var document = new Microsoft.Office.Interop.Word.Document();
                    application.Visible = false;
                    document = application.Documents.Add(path);

                    foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                    {
                        if (field.Code.Text.Contains("isAdi"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİhaleİlanı.İsinAdi);
                        }

                        else if (field.Code.Text.Contains("komisyon1"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text + "(BAŞKAN)" + "" + "ve" + "");
                        }
                        else if (field.Code.Text.Contains("komisyon2"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox2.Text + "(ÜYE)");
                        }
                        else if (field.Code.Text.Contains("komisyon3"))
                        {
                            field.Delete();
                        }
                       
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);
                    dökümansayac = 2;
                }

            }
            if (radioButton3.Checked == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    XtraMessageBox.Show("Gerekli Alanları Lütfen doldurunuz..");

                }
                else
                {
                    komisyon1 = textBox1.Text;
                    komisyon2 = textBox2.Text;
                    komisyon3 = textBox3.Text;
                    var application = new Microsoft.Office.Interop.Word.Application();
                    var document = new Microsoft.Office.Interop.Word.Document();
                    application.Visible = false;
                    document = application.Documents.Add(path);

                    foreach (Microsoft.Office.Interop.Word.Field field in document.Fields)
                    {
                        if (field.Code.Text.Contains("isAdi"))
                        {
                            field.Select();
                            application.Selection.TypeText(HerkezeAçıkİhaleHizmetAlımıİhaleİlanı.İsinAdi);
                        }
                        else if (field.Code.Text.Contains("komisyon1"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox1.Text + "(BAŞKAN)" + "," + "");
                        }
                        else if (field.Code.Text.Contains("komisyon2"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox2.Text + "(ÜYE)" + "ve" + "");
                        }
                        else if (field.Code.Text.Contains("komisyon3"))
                        {
                            field.Select();
                            application.Selection.TypeText(textBox3.Text +"(ÜYE)");
                        }
                        
                    }

                    document.SaveAs2(path1);
                    document.Close();
                    application.Quit();
                    richEditControl1.LoadDocument(path1);
                    dökümansayac = 3;
                }
            }
            

        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
                groupBox3.Visible = false;
                
            }
            if (radioButton2.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = false;
                
                
            }
            if (radioButton3.Checked == true)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                groupBox3.Visible = true;
                
            }
            
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            DökümanHazırla();
        }
        private void HerkezeAçıkİhaleKomisyonOlurYazısı_Load(object sender, EventArgs e)
        {

        }
    }
}