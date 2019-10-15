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
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;

namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\01 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\02 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path3 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\03 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path4 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\04 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path5 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\05 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path6 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\06 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path7 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\07 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path8 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\08 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path9 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\09 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path10 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\10 Tip Yaklaşık Maliyet Hesap Formu.doc";
        string path11 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Tip Yaklaşık Maliyet\\Tip Yaklaşık Maliyet Hesap Formu.doc";

        List<Label> YeniListem1 = new List<Label>();
        List<Label> YeniListem2 = new List<Label>();
        public static List<FirmaBilgileri> Firmalar = new List<FirmaBilgileri>();
        byte[] VeriTabanindenGelenBytes;
        DateTime tarih1;
        public static int clicksayisi;
        int tipyaklasiksayac;
        public static decimal yaklasikmaliyet;
        decimal toplam = 0;
        void TarihVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminYaklasikMaliyetFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    tarih1 = Convert.ToDateTime(reader[3]);
                }
                baglan.Close();
            }
        }
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        tipyaklasiksayac = Convert.ToInt32(reader[4]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        tipyaklasiksayac = Convert.ToInt32(reader[6]);
                    }
                    baglan.Close();
                }
            }

        }
        private void SistemFirmaLabelGöster()
        {
            
            var fliste = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar.Where(s => s.Teklifverilentarih < DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif.tarih1).ToList();
            var fliste2 = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar.Where(s => s.Teklifverilentarih > DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif.tarih1).ToList();

            for (int i = 0; i < fliste.Count; i++)//1-2
            {
                Label lb = new Label();
                tableLayoutPanel2.Controls.Add(lb);
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = fliste[i].Firmaisim.ToString();
                lb.ForeColor = Color.Green;
                label2.Visible = true;
                toplam += fliste[i].Firmafiyat;
                
            }
            for (int i = 0; i < fliste2.Count; i++)//1-2
            {
                Label lb = new Label();
                tableLayoutPanel1.Controls.Add(lb);
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = fliste2[i].Firmaisim.ToString();
                lb.ForeColor = Color.Red;
                label1.Visible = true;
            }
            yaklasikmaliyet = ((toplam) / fliste.Count);
            yaklasikmaliyet = Math.Truncate(100 * yaklasikmaliyet) / 100;
            DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet = yaklasikmaliyet;



        }
        private void VeritabanıSistemFirmaLabelGöster()
        {

            try
            {
                var fliste = Firmalar.Where(s => s.Teklifverilentarih < tarih1).ToList();
                var fliste2 = Firmalar.Where(s => s.Teklifverilentarih > tarih1).ToList();

                for (int i = 0; i < fliste.Count; i++)//1-2
                {
                    Label lb = new Label();
                    tableLayoutPanel2.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = fliste[i].Firmaisim.ToString();
                    lb.ForeColor = Color.Green;
                    label2.Visible = true;
                    toplam += fliste[i].Firmafiyat;

                }
                for (int i = 0; i < fliste2.Count; i++)//1-2
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = fliste2[i].Firmaisim.ToString();
                    lb.ForeColor = Color.Red;
                    label1.Visible = true;
                }
                yaklasikmaliyet = ((toplam) / fliste.Count);
                yaklasikmaliyet = Math.Truncate(100 * yaklasikmaliyet) / 100;
                DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet = yaklasikmaliyet;


            }
            catch (DivideByZeroException)
            {

                XtraMessageBox.Show("Tekliflerini Girdiğiniz Firmaların hepsi Teklif Tarihinden önce vermiş");
            }
           
        }
        void FirmaVeriAl()
        {
            Firmalar.Clear();
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİlkTeklifFirmalar where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    FirmaBilgileri firma = new FirmaBilgileri()
                    {
                        Firmafiyat = Convert.ToDecimal(reader[3]),
                        Firmaisim = Convert.ToString(reader[2]),
                        Teklifverilentarih = Convert.ToDateTime(reader[4])
                    };
                    Firmalar.Add(firma);

                }
                baglan.Close();
                reader.Close();
            }
        }
        void Verial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        VeriTabanindenGelenBytes = (byte[])reader["Dosya"];
                        yaklasikmaliyet = Convert.ToDecimal(reader[3]);
                    }
                    baglan.Close();
                    reader.Close();
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path11, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(500);
                            richEditControl1.LoadDocument(path11);

                        }
                        else
                        {
                            XtraMessageBox.Show("Dosya yüklenirken hata oluştu");
                        }
                    }
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 5)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        VeriTabanindenGelenBytes = (byte[])reader["Dosya"];
                        yaklasikmaliyet = Convert.ToDecimal(reader[3]);
                    }
                    baglan.Close();
                    reader.Close();
                    if (VeriTabanindenGelenBytes.Length > 0)
                    {
                        System.IO.File.WriteAllBytes(path11, VeriTabanindenGelenBytes);
                        richEditControl1.LoadDocument(path11);

                    }
                    else
                    {
                        XtraMessageBox.Show("Dosya yüklenirken hata oluştu");
                    }
                }
            }

        }
        void VeritabanıGüncelle()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet set Dosya=@dosya ,yaklasıkmaliyet=@yaklasıkmaliyet where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Connection = connn;
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", SatınAlmaBilgilendirmeFormu.kullanıcıid);
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);

                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);

                }
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path11));
                komut.Parameters.AddWithValue("@yaklasıkmaliyet", yaklasikmaliyet);
                DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet = yaklasikmaliyet;
                komut.ExecuteNonQuery();
                connn.Close();
            }
        }
        void VeritabanıKaydet()
        {
            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet (SatınAlma_id,id,Dosya,satınalmasayac,yaklasıkmaliyet) values (@SatınAlma_id ,@id,@dosya , @satınalmasayac,@yaklasıkmaliyet )", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path11));
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);

                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);

                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@satınalmasayac", 5);
                komut.Parameters.AddWithValue("@yaklasıkmaliyet", yaklasikmaliyet);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
               
            }
        }
        void DökümanHazırla()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 5)
            {
                var fliste = Firmalar.Where(s => s.Teklifverilentarih < tarih1).ToList();
                if (fliste.Count == 1)
                {
                    if (!File.Exists(path1))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path1);
                        document.Variables["sıra1"].Value = "1";
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);
                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;
                    }
                }
                if (fliste.Count == 2)
                {
                    if (!File.Exists(path2))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path2);
                        document.Variables["sıra1"].Value = "1";
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);
                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 3)
                {
                    if (!File.Exists(path3))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path3);
                        document.Variables["sıra1"].Value = "1";
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);
                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 4)
                {
                    if (!File.Exists(path4))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path4);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 5)
                {
                    if (!File.Exists(path5))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path5);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 6)
                {
                    if (!File.Exists(path6))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path6);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 7)
                {
                    if (!File.Exists(path7))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path7);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 8)
                {
                    if (!File.Exists(path8))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path8);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra8"].Value = "8";
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 9)
                {
                    if (!File.Exists(path9))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path9);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra8"].Value = "8";
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra9"].Value = "9";
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 10)
                {
                    if (!File.Exists(path10))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path10);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra8"].Value = "8";
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra9"].Value = "9";
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra10"].Value = "10";
                        document.Variables["firma10"].Value = fliste[9].Firmaisim;
                        document.Variables["satıs10"].Value = fliste[9].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
            }
            else
            {
                var fliste = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar.Where(s => s.Teklifverilentarih < DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif.tarih1).ToList();
                if (fliste.Count == 1)
                {
                    if (!File.Exists(path1))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path1);
                        document.Variables["sıra1"].Value = "1";
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);
                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;
                    }
                }
                if (fliste.Count == 2)
                {
                    if (!File.Exists(path2))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path2);
                        document.Variables["sıra1"].Value = "1";
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);
                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 3)
                {
                    if (!File.Exists(path3))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path3);
                        document.Variables["sıra1"].Value = "1";
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);
                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 4)
                {
                    if (!File.Exists(path4))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path4);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 5)
                {
                    if (!File.Exists(path5))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path5);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 6)
                {
                    if (!File.Exists(path6))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path6);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 7)
                {
                    if (!File.Exists(path7))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path7);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 8)
                {
                    if (!File.Exists(path8))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path8);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra8"].Value = "8";
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 9)
                {
                    if (!File.Exists(path9))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path9);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra8"].Value = "8";
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra9"].Value = "9";
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
                if (fliste.Count == 10)
                {
                    if (!File.Exists(path10))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word.Application();
                        var document = word.Documents.Add(path10);
                        document.Variables["sıra1"].Value = "1";
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        document.Variables["tarih"].Value = dateTimePicker1.Text;
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra2"].Value = "2";
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra3"].Value = "3";
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra4"].Value = "4";
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra5"].Value = "5";
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra6"].Value = "6";
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra7"].Value = "7";
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra8"].Value = "8";
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra9"].Value = "9";
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["sıra10"].Value = "10";
                        document.Variables["firma10"].Value = fliste[9].Firmaisim;
                        document.Variables["satıs10"].Value = fliste[9].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["ortalama"].Value = yaklasikmaliyet.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path11);
                        word.Quit();
                        System.Threading.Thread.Sleep(300);

                        richEditControl1.LoadDocument(path11);
                        clicksayisi += 1;
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 5;

                    }
                }
            }

        }
        private void DoğrudanTeminSözleşmeliDirekAlımTipYaklasikMaliyetFormu_Load(object sender, EventArgs e)
        {
            tableLayoutPanel2.Controls.Clear();
            tableLayoutPanel1.Controls.Clear();
            FirmaVeriAl();
            TarihVeriAl();
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                backgroundWorker1.RunWorkerAsync();
                VeritabanıSistemFirmaLabelGöster();
            }
            else
            {
                tableLayoutPanel2.Controls.Clear();
                tableLayoutPanel1.Controls.Clear();
                SistemFirmaLabelGöster();
            }
            
           
        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true )
            {
                if (tipyaklasiksayac == 5 )
                {
                    if (DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet > DoğrudanTeminSözleşmeliYapımİşiFormu.ParasalLimitinTuru131b)
                    {
                        XtraMessageBox.Show("Parasal Limit Aşıldı");
                        return;
                    }
                    else
                    {
                        button1.Enabled = false;
                        backgroundWorker2.RunWorkerAsync();
                    }
                   
                }
                else
                {
                    if (DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet > DoğrudanTeminSözleşmeliYapımİşiFormu.ParasalLimitinTuru131b)
                    {
                        XtraMessageBox.Show("Parasal Limit Aşıldı");
                        return;
                    }
                    else
                    {
                        button1.Enabled = false;
                        backgroundWorker3.RunWorkerAsync();
                    }
                   
                }
            }
            else
            {
                if (clicksayisi> 0)
                {
                    if (yaklasikmaliyet > DoğrudanTeminSözleşmeliYapımİşiFormu.ParasalLimitinTuru131b)
                    {
                        XtraMessageBox.Show("Parasal Limit Aşıldı");
                        return;
                    }
                    else
                    {
                        button1.Enabled = false;
                        backgroundWorker2.RunWorkerAsync();

                    }

                }
                else
                {
                    if (yaklasikmaliyet > DoğrudanTeminSözleşmeliYapımİşiFormu.ParasalLimitinTuru131b)
                    {
                        XtraMessageBox.Show("Parasal Limit Aşıldı");
                        return;
                    }
                    else
                    {
                        button1.Enabled = false;
                        backgroundWorker3.RunWorkerAsync();
                    }
                    
                }
            }
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            SayacAl();
            Verial();
        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıGüncelle();
        }
        private void BackgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıKaydet();
        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
        private void BackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
    }
}