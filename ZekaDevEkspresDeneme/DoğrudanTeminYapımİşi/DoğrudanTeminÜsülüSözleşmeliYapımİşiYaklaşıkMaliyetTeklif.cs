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
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Core;
using Word=  Microsoft.Office.Interop.Word;



namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif()
        {
            InitializeComponent();
             string templateName = path;
        }
        byte[] VeriTabanindenGelenBytes;
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        static string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\01 Yaklaşık Maliyet İçin Teklif.doc";
        static string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\011 Yaklaşık Maliyet İçin Teklif.docx";
        static string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\012 Yaklaşık Maliyet İçin Teklif.docx";
        static string path3 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\EKSİZ DOSYALAR\\01 Yaklaşık Maliyet İçin Teklif EKSİZ.doc";
        static string path4 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\EKSİZ DOSYALAR\\011 Yaklaşık Maliyet İçin Teklif EKSİZ.docx";
        static string path5 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\EKSİZ DOSYALAR\\012 Yaklaşık Maliyet İçin Teklif EKSİZ.docx";

        public static DateTime tarih1;
        public static DateTime belgetarihi;
        public static int yaklasıkmaliyetteklifsayac;
        public static int clicksayisi;
        
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminYaklasikMaliyetFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        yaklasıkmaliyetteklifsayac = Convert.ToInt32(reader[6]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 3)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminYaklasikMaliyetFormu where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        yaklasıkmaliyetteklifsayac = Convert.ToInt32(reader[6]);
                    }
                    baglan.Close();
                }
            }
           
        }
        void VeritabanıKaydet()
        {
            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiSözleşmeTaslağı.conn))
            {
                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminYaklasikMaliyetFormu (SatınAlma_id,id,BelgeTarih,FirmaTanınanTarih,FirmaTanınanSaat,Dosya,satınalmasayac) values (@SatınAlma_id,@id,@BelgeTarih,@FirmaTanınanTarih,@FirmaTanınanSaat,@dosya,@satınalmasayac)", sqlConnection);
                komut.Parameters.Clear();
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@BelgeTarih", Belgetarih.Value);
                komut.Parameters.AddWithValue("@FirmaTanınanTarih", firmatarihtext.Value);
                komut.Parameters.AddWithValue("@FirmaTanınanSaat",dateEdit2.Text);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
                komut.Parameters.AddWithValue("@satınalmasayac", 3);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }
        void VerileriGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminYaklasikMaliyetFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {

                        Belgetarih.Text = dr[2].ToString();
                        Belgetarih.Value = Convert.ToDateTime(dr[2]);
                        firmatarihtext.Text = dr[3].ToString();
                        firmatarihtext.Value = Convert.ToDateTime(dr[3]);
                        tarih1 = firmatarihtext.Value;
                        belgetarihi = Belgetarih.Value;
                        dateEdit2.Text = dr[4].ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path2);
                        }
                    }
                    dr.Close();
                    connn.Close();

                }

            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac > 2 || yaklasıkmaliyetteklifsayac == 3)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminYaklasikMaliyetFormu where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        Belgetarih.Text = dr[2].ToString();
                        Belgetarih.Value = Convert.ToDateTime(dr[2]);
                        firmatarihtext.Text = dr[3].ToString();
                        firmatarihtext.Value = Convert.ToDateTime(dr[3]);
                        dateEdit2.Text = dr[4].ToString();
                        tarih1 = firmatarihtext.Value;
                        belgetarihi = Belgetarih.Value;
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(300);
                            richEditControl1.LoadDocument(path2);
                        }
                    }
                    dr.Close();
                    connn.Close();

                }

                //}
            }
        }
        void VeritabanıGüncelle()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminYaklasikMaliyetFormu set BelgeTarih=@BelgeTarih,FirmaTanınanTarih=@FirmaTanınanTarih,Dosya= @dosya ,FirmaTanınanSaat=@FirmaTanınanSaat where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Parameters.AddWithValue("@BelgeTarih", Belgetarih.Value);
                komut.Parameters.AddWithValue("@id", SatınAlmaBilgilendirmeFormu.kullanıcıid);
                komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                komut.Parameters.AddWithValue("@FirmaTanınanSaat", dateEdit2.Text);
                komut.Parameters.AddWithValue("@FirmaTanınanTarih", firmatarihtext.Value);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
            }
        }
        void DökümanHazırla()
        {
            if (!File.Exists(path))
            {
                XtraMessageBox.Show("Dosya Yok");
            }
            else
            {
                tarih1 = firmatarihtext.Value;
                belgetarihi = Belgetarih.Value;
                var word = new Word.Application();
                var document = word.Documents.Add(path);
                document.Variables["tarih"].Value = Belgetarih.Text;
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                }
                else
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                }
                document.Variables["firmadate"].Value = firmatarihtext.Text;
                document.Variables["sure"].Value = dateEdit2.Text;
                document.Fields.Update();
                document.SaveAs2(path2);
                word.Quit();
                System.Threading.Thread.Sleep(500);
                richEditControl1.LoadDocument(path2);
                clicksayisi += 1;
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 3;
            }
            
        }
        private void YaklaşıkMaliyetTeklif_Load(object sender, EventArgs e)
        {
            VeriAlthread.RunWorkerAsync();
            tarih1 = firmatarihtext.Value;

        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true )
            {
                if (yaklasıkmaliyetteklifsayac == 3 )
                {
                    button1.Enabled = false;
                    backgroundWorker3.RunWorkerAsync();
                }
                else
                {
                    button1.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }

            }
            else
            {
                if (clicksayisi > 0)
                {
                    button1.Enabled = false;
                    backgroundWorker3.RunWorkerAsync();
                }
                else
                {
                    button1.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
                
            }
            
        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıKaydet();
        }
        private void BackgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıGüncelle();
        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
        private void BackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
        private void VeriAlthread_DoWork(object sender, DoWorkEventArgs e)
        {
            VerileriGetir();
            SayacAl();
        }
    }
}