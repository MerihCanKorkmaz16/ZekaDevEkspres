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
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı()
        {
            InitializeComponent();
        }
        public static List<AsilKomisyonÜyeleri> AsilKomisyonlar = new List<AsilKomisyonÜyeleri>();
        public static List<YedekKomisyonÜyeleri> YedekKomisyonlar = new List<YedekKomisyonÜyeleri>();
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Kabul Komisyonu Olur Yazısı.doc";
        string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\2-Kabul Komisyonu Olur Yazısı.docx";
        public static int kabulkomisyonsayac;
        public static int clicksayisi;
        byte[] VeriTabanindenGelenBytes;
        void DökümanHazırla()
        {
            if (!File.Exists(path))
            {
                XtraMessageBox.Show("Dosya Yok");
            }
            else
            {
                var word = new Word.Application();
                var document = word.Documents.Add(path);
                document.Variables["tarih"].Value = tarihdatepicker.Text;
                if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;
                }
                else
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                }
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 11;
                clicksayisi += 1;
                if (AsilKomisyonlar.Count == 1)
                {
                        document.Variables["komisyon1"].Value =","+AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                        document.Variables["komisyon2"].Value = " ";
                        document.Variables["komisyon3"].Value = " ";
                        document.Variables["komisyon4"].Value = " ";
                        document.Variables["komisyon5"].Value = " ";
                        document.Variables["komisyon6"].Value = " ";
                        document.Variables["komisyon7"].Value = " ";
                        document.Variables["komisyon8"].Value = " ";
                        document.Variables["komisyon9"].Value = " ";
                        document.Variables["komisyon10"].Value = " ";
                }
                if (AsilKomisyonlar.Count == 2)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = " ";
                    document.Variables["komisyon4"].Value = " ";
                    document.Variables["komisyon5"].Value = " ";
                    document.Variables["komisyon6"].Value = " ";
                    document.Variables["komisyon7"].Value = " ";
                    document.Variables["komisyon8"].Value = " ";
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";


                }
                if (AsilKomisyonlar.Count == 3)
                {

                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = " ";
                    document.Variables["komisyon5"].Value = " ";
                    document.Variables["komisyon6"].Value = " ";
                    document.Variables["komisyon7"].Value = " ";
                    document.Variables["komisyon8"].Value = " ";
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 4)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad;
                    document.Variables["komisyon5"].Value = " ";
                    document.Variables["komisyon6"].Value = " ";
                    document.Variables["komisyon7"].Value = " ";
                    document.Variables["komisyon8"].Value = " ";
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 5)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = ","+"," + AsilKomisyonlar[3].AsilKomisyonAdSoyad; 
                    document.Variables["komisyon5"].Value = "," + AsilKomisyonlar[4].AsilKomisyonAdSoyad;
                    document.Variables["komisyon6"].Value = " ";
                    document.Variables["komisyon7"].Value = " ";
                    document.Variables["komisyon8"].Value = " ";
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 6)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad; 
                    document.Variables["komisyon5"].Value = "," + AsilKomisyonlar[4].AsilKomisyonAdSoyad;
                    document.Variables["komisyon6"].Value = "," + AsilKomisyonlar[5].AsilKomisyonAdSoyad;
                    document.Variables["komisyon7"].Value = " ";
                    document.Variables["komisyon8"].Value = " ";
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 7)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad;
                    document.Variables["komisyon5"].Value = "," + AsilKomisyonlar[4].AsilKomisyonAdSoyad;
                    document.Variables["komisyon6"].Value = "," + AsilKomisyonlar[5].AsilKomisyonAdSoyad;
                    document.Variables["komisyon7"].Value = "," + AsilKomisyonlar[6].AsilKomisyonAdSoyad;
                    document.Variables["komisyon8"].Value = " ";
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 8)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad;
                    document.Variables["komisyon5"].Value = "," + AsilKomisyonlar[4].AsilKomisyonAdSoyad;
                    document.Variables["komisyon6"].Value = "," + AsilKomisyonlar[5].AsilKomisyonAdSoyad;
                    document.Variables["komisyon7"].Value = "," + AsilKomisyonlar[6].AsilKomisyonAdSoyad;
                    document.Variables["komisyon8"].Value = "," + AsilKomisyonlar[7].AsilKomisyonAdSoyad; 
                    document.Variables["komisyon9"].Value = " ";
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 9)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad;
                    document.Variables["komisyon5"].Value = "," + AsilKomisyonlar[4].AsilKomisyonAdSoyad;
                    document.Variables["komisyon6"].Value = "," + AsilKomisyonlar[5].AsilKomisyonAdSoyad;
                    document.Variables["komisyon7"].Value = "," + AsilKomisyonlar[6].AsilKomisyonAdSoyad;
                    document.Variables["komisyon8"].Value = "," + AsilKomisyonlar[7].AsilKomisyonAdSoyad; 
                    document.Variables["komisyon9"].Value = "," + AsilKomisyonlar[8].AsilKomisyonAdSoyad;
                    document.Variables["komisyon10"].Value = " ";

                }
                if (AsilKomisyonlar.Count == 10)
                {
                    document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
                    document.Variables["komisyon2"].Value = "," + AsilKomisyonlar[1].AsilKomisyonAdSoyad;
                    document.Variables["komisyon3"].Value = "," + AsilKomisyonlar[2].AsilKomisyonAdSoyad;
                    document.Variables["komisyon4"].Value = "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad;
                    document.Variables["komisyon5"].Value = "," + AsilKomisyonlar[4].AsilKomisyonAdSoyad;
                    document.Variables["komisyon6"].Value = "," + AsilKomisyonlar[5].AsilKomisyonAdSoyad;
                    document.Variables["komisyon7"].Value = "," + AsilKomisyonlar[6].AsilKomisyonAdSoyad;
                    document.Variables["komisyon8"].Value = "," + AsilKomisyonlar[7].AsilKomisyonAdSoyad;
                    document.Variables["komisyon9"].Value = "," + AsilKomisyonlar[8].AsilKomisyonAdSoyad;
                    document.Variables["komisyon10"].Value = "," + AsilKomisyonlar[9].AsilKomisyonAdSoyad;

                }

                ////////////////////////////////////////////////////////
                if (YedekKomisyonlar.Count == 1)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = " ";
                    document.Variables["yedekkomisyon3"].Value = " ";
                    document.Variables["yedekkomisyon4"].Value = " ";
                    document.Variables["yedekkomisyon5"].Value = " ";
                    document.Variables["yedekkomisyon6"].Value = " ";
                    document.Variables["yedekkomisyon7"].Value = " ";
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 2)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = " ";
                    document.Variables["yedekkomisyon4"].Value = " ";
                    document.Variables["yedekkomisyon5"].Value = " ";
                    document.Variables["yedekkomisyon6"].Value = " ";
                    document.Variables["yedekkomisyon7"].Value = " ";
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 3)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = " ";
                    document.Variables["yedekkomisyon5"].Value = " ";
                    document.Variables["yedekkomisyon6"].Value = " ";
                    document.Variables["yedekkomisyon7"].Value = " ";
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 4)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = " ";
                    document.Variables["yedekkomisyon6"].Value = " ";
                    document.Variables["yedekkomisyon7"].Value = " ";
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 5)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = "," + YedekKomisyonlar[4].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon6"].Value = " ";
                    document.Variables["yedekkomisyon7"].Value = " ";
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 6)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = "," + YedekKomisyonlar[4].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon6"].Value = "," + YedekKomisyonlar[5].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon7"].Value = " ";
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 7)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = "," + YedekKomisyonlar[4].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon6"].Value = "," + YedekKomisyonlar[5].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon7"].Value = "," + YedekKomisyonlar[6].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon8"].Value = " ";
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 8)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = "," + YedekKomisyonlar[4].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon6"].Value = "," + YedekKomisyonlar[5].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon7"].Value = "," + YedekKomisyonlar[6].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon8"].Value = "," + YedekKomisyonlar[7].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon9"].Value = " ";
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 9)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = "," + YedekKomisyonlar[4].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon6"].Value = "," + YedekKomisyonlar[5].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon7"].Value = "," + YedekKomisyonlar[6].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon8"].Value = "," + YedekKomisyonlar[7].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon9"].Value = "," + YedekKomisyonlar[8].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon10"].Value = " ";
                }
                if (YedekKomisyonlar.Count == 10)
                {
                    document.Variables["yedekkomisyon1"].Value = "," + YedekKomisyonlar[0].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon2"].Value = "," + YedekKomisyonlar[1].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon3"].Value = "," + YedekKomisyonlar[2].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon4"].Value = "," + YedekKomisyonlar[3].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon5"].Value = "," + YedekKomisyonlar[4].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon6"].Value = "," + YedekKomisyonlar[5].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon7"].Value = "," + YedekKomisyonlar[6].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon8"].Value = "," + YedekKomisyonlar[7].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon9"].Value = "," + YedekKomisyonlar[8].YedekKomisyonAdSoyad;
                    document.Variables["yedekkomisyon10"].Value = "," + YedekKomisyonlar[9].YedekKomisyonAdSoyad;
                }


                document.Fields.Update();
                document.SaveAs2(path2);
                word.Quit();
                System.Threading.Thread.Sleep(500);
                richEditControl1.LoadDocument(path2);
                
            }
        }
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminAsilKabulKomisyonÜyeler where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        kabulkomisyonsayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminKabulKomisyonOlurYazısı where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        kabulkomisyonsayac = Convert.ToInt32(reader[6]);
                    }
                    baglan.Close();
                }
            }

        }
        void AsilÜyeVeritabanıSil()
        {
            SqlConnection baglanti = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from DoğrudanTeminAsilKabulKomisyonÜyeler where id = @id and SatınAlma_id = @SatınAlma_id ", baglanti);
            komut.Parameters.AddWithValue("@id", 2);
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
            }
            else
            {
                komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        void YedekÜyeVeritabanıSil()
        {
            SqlConnection baglanti = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from DoğrudanTeminYedekKabulKomisyonÜyeler where id = @id and SatınAlma_id = @SatınAlma_id ", baglanti);
            komut.Parameters.AddWithValue("@id", 2);
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
            }
            else
            {
                komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
            }
            komut.ExecuteNonQuery();
            baglanti.Close();

        }
        void AsilÜyeBilgileriverial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true && kabulkomisyonsayac == 11)
            {
                AsilKomisyonlar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminAsilKabulKomisyonÜyeler where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        AsilKomisyonÜyeleri asil = new AsilKomisyonÜyeleri()
                        {
                            AsilKomisyonAdSoyad = Convert.ToString(reader[3])
                        };
                        AsilKomisyonlar.Add(asil);
                        tarihdatepicker.Text = (reader[2]).ToString();
                        VeriTabanindenGelenBytes = (byte[])reader["Dosya"];
                    }
                    baglan.Close();
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


            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                AsilKomisyonlar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİlkTeklifFirmalar where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {

                        AsilKomisyonÜyeleri asil = new AsilKomisyonÜyeleri()
                        {
                            AsilKomisyonAdSoyad = Convert.ToString(reader[3])
                        };
                        AsilKomisyonlar.Add(asil);
                        tarihdatepicker.Text = (reader[2]).ToString();
                        VeriTabanindenGelenBytes = (byte[])reader["Dosya"];
                    }
                    baglan.Close();
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path2);
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        void YedekÜyeBilgileriverial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true && kabulkomisyonsayac == 11)
            {
                
                YedekKomisyonlar.Clear();

                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminYedekKabulKomisyonÜyeler where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        YedekKomisyonÜyeleri yedek = new YedekKomisyonÜyeleri()
                        {
                            YedekKomisyonAdSoyad = Convert.ToString(reader[2])
                        };
                        YedekKomisyonlar.Add(yedek);
                        
                        
                    }
                    baglan.Close();
                }
               
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                
                YedekKomisyonlar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİlkTeklifFirmalar where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {

                        YedekKomisyonÜyeleri yedek = new YedekKomisyonÜyeleri()
                        {
                            YedekKomisyonAdSoyad = Convert.ToString(reader[2])
                        };
                        YedekKomisyonlar.Add(yedek);
                       
                    }
                    baglan.Close();
                    
                }
            }
            else
            {
                return;
            }
        }
        private void AsilÜyeAdLabel()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                Label lb = new Label();
                tableLayoutPanel2.Controls.Add(lb);

                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = i.ToString() + "." + "Asil Üye:";

            }
        }
        private void YedekÜyeAdLabel()
        {
            int sayi = Convert.ToInt32(textBox2.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                Label lb = new Label();
                tableLayoutPanel3.Controls.Add(lb);
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = i.ToString() + "." + "Yedek Üye:";

            }
        }
        private void AsilÜyeAdText()
        {
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                tableLayoutPanel1.Controls.Add(txt);
                txt.Name = "asilüye" + i.ToString();
                
            }

        }
        private void YedekÜyeAdText()
        {
            for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                tableLayoutPanel4.Controls.Add(txt);
                txt.Name = "yedeküye" + i.ToString();
                
            }

        }
        //-----------------------------------------------------
        private void VeritabanıAsilÜyeAdText()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                textBox1.Text = AsilKomisyonlar.Count.ToString();
                textBox2.Text = YedekKomisyonlar.Count.ToString();
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel1.Controls.Add(txt);
                    txt.Name = "asilüye" + i.ToString();
                    txt.Text = AsilKomisyonlar[i].AsilKomisyonAdSoyad;

                }
                for (int i = 1; i < Convert.ToInt32(textBox1.Text)+1; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel2.Controls.Add(lb);

                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = i.ToString() + "." + "Asil Üye:";

                }
                for (int i = 1; i < Convert.ToInt32(textBox2.Text)+1; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel3.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = i.ToString() + "." + "Yedek Üye:";

                }

            }
            else
            {
                return;
            }
           

        }
        private void VeritabanıYedekÜyeAdText()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                textBox2.Text = YedekKomisyonlar.Count.ToString();
                for (int i = 0; i < Convert.ToInt32(textBox2.Text); i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel4.Controls.Add(txt);
                    txt.Name = "yedeküye" + i.ToString();
                    txt.Text = YedekKomisyonlar[i].YedekKomisyonAdSoyad;

                }
            }
            else
            {
                return;
            }
           

        }
        //------------------------------------------------------
        private void BosGecilemezKontrol()
        {
            AsilKomisyonlar.Clear();
            YedekKomisyonlar.Clear();
            foreach (Control ctl in tableLayoutPanel1.Controls)
            {
                if (ctl is TextBox)
                {
                    if (ctl.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Lütfen Gerekli Yerleri Doldurmayı unutmayınız");
                        return;
                    }

                }

            }
            foreach (Control ctl2 in tableLayoutPanel4.Controls)
            {
                if (ctl2 is TextBox)
                {
                    if (ctl2.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Lütfen Gerekli Yerleri Doldurmayı unutmayınız");
                        return;

                    }

                }

            }
            FirmaBilgileriGetir();
            DökümanHazırla();
            AsilÜyeVeritabanıEkle();
            YedekÜyeVeritabanıEkle();


        }
        private void GüncelleBosGecilemezKontrol()
        {
            AsilKomisyonlar.Clear();
            YedekKomisyonlar.Clear();
            foreach (Control ctl in tableLayoutPanel1.Controls)
            {
                if (ctl is TextBox)
                {
                    if (ctl.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Lütfen Gerekli Yerleri Doldurmayı unutmayınız");
                        return;
                    }

                }

            }
            foreach (Control ctl2 in tableLayoutPanel4.Controls)
            {
                if (ctl2 is TextBox)
                {
                    if (ctl2.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Lütfen Gerekli Yerleri Doldurmayı unutmayınız");
                        return;

                    }

                }

            }
            FirmaBilgileriGetir();
            DökümanHazırla();
            AsilÜyeVeritabanıSil();
            YedekÜyeVeritabanıSil();
            AsilÜyeVeritabanıEkle();
            YedekÜyeVeritabanıEkle();

        }
        void AsilÜyeVeritabanıEkle()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut2 = new SqlCommand("Insert into DoğrudanTeminAsilKabulKomisyonÜyeler(SatınAlma_id,id,BelgeTarih,asilkomisyonadsoyad,Dosya,satınalmasayac) VALUES (@SatınAlma_id,@id,@Belgetarih,@asilkomisyonadsoyad,@dosya,@satınalmasayac) ", baglan))
            {
                baglan.Open();

                foreach (var nesne in AsilKomisyonlar)
                {
                    komut2.Parameters.Clear();
                    if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminSözleşmeliYapımİşiFormu.SatınAlma_id);

                    }
                    else
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);

                    }
                    komut2.Parameters.AddWithValue("@id", 2);
                    komut2.Parameters.AddWithValue("@asilkomisyonadsoyad", nesne.AsilKomisyonAdSoyad);
                    komut2.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
                    komut2.Parameters.AddWithValue("@BelgeTarih", tarihdatepicker.Value);
                    komut2.Parameters.AddWithValue("@satınalmasayac", 11);
                    komut2.ExecuteNonQuery();
                }

                baglan.Close();
            }

        }
        void YedekÜyeVeritabanıEkle()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut2 = new SqlCommand("Insert into DoğrudanTeminYedekKabulKomisyonÜyeler(SatınAlma_id,id,yedekkomisyonadsoyad) VALUES (@SatınAlma_id,@id,@yedekkomisyonadsoyad) ", baglan))
            {
                baglan.Open();

                foreach (var nesne in YedekKomisyonlar)
                {
                    komut2.Parameters.Clear();
                    if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminSözleşmeliYapımİşiFormu.SatınAlma_id);

                    }
                    else
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);

                    }
                    komut2.Parameters.AddWithValue("@id", 2);
                    komut2.Parameters.AddWithValue("@yedekkomisyonadsoyad", nesne.YedekKomisyonAdSoyad);
                    komut2.ExecuteNonQuery();
                }

                baglan.Close();
            }

        }
        private void FirmaBilgileriGetir()
        {
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                AsilKomisyonlar.Add(new AsilKomisyonÜyeleri()
                {
                    AsilKomisyonAdSoyad = ((TextBox)tableLayoutPanel1.Controls["asilüye" + (i).ToString()]).Text,

                });
            }
            for (int a = 0; a < Convert.ToInt32(textBox2.Text); a++)
            {
                YedekKomisyonlar.Add(new YedekKomisyonÜyeleri()
                {
                    YedekKomisyonAdSoyad = ((TextBox)tableLayoutPanel4.Controls["yedeküye" + (a).ToString()]).Text,

                });
            }

        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int uzunluk = 10;
            if (textBox1.Text != "")
            {
                if (int.Parse(textBox1.Text) > uzunluk)
                {
                    XtraMessageBox.Show("Belirlenen Maksimum Komisyon Asil Üye Sayısı :" + uzunluk + "dir");
                    simpleButton1.Enabled = false;
                }
                else if (int.Parse(textBox1.Text) < uzunluk)
                {

                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        simpleButton1.Enabled = true;
                    }
                    
                }


            }
        }
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            int uzunluk = 10;
            if (textBox2.Text != "")
            {
                if (int.Parse(textBox2.Text) > uzunluk)
                {
                    XtraMessageBox.Show("Belirlenen Maksimum Komisyon Yedek Üye Sayısı :" + uzunluk + "dir");
                    simpleButton1.Enabled = false;
                }
                else if (int.Parse(textBox2.Text) < uzunluk)
                {

                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        simpleButton1.Enabled = true;
                    }

                }


            }
        }
        private void DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı_Load(object sender, EventArgs e)
        {
            SayacAl();
            AsilÜyeBilgileriverial();
            YedekÜyeBilgileriverial();
            VeritabanıAsilÜyeAdText();
            VeritabanıYedekÜyeAdText();
        }
        private void KaydetDüğmesi_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (kabulkomisyonsayac == 11)
                {
                    GüncelleBosGecilemezKontrol();
                }
                else
                {
                    BosGecilemezKontrol();
                }
            }
            else
            {
                if (clicksayisi > 0)
                {
                    GüncelleBosGecilemezKontrol();
                }
                else
                {
                    BosGecilemezKontrol();
                }
            }
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                XtraMessageBox.Show("Lütfen Asil Ve Yedek Üyeleri Giriniz");
            }
            else
            {
                AsilKomisyonlar.Clear();
                YedekKomisyonlar.Clear();
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel2.Controls.Clear();
                tableLayoutPanel3.Controls.Clear();
                tableLayoutPanel4.Controls.Clear();

                AsilÜyeAdLabel();
                YedekÜyeAdLabel();
                AsilÜyeAdText();
                YedekÜyeAdText();
            }
        }
    }
}