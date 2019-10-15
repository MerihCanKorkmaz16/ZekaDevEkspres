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
using DevExpress.Utils;

namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiKesinKabulTutanağı : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiKesinKabulTutanağı()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Kesin-Geçiçi Kabul Dosyası\\Kesin Kabul Tutanağı.doc";
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Kesin-Geçiçi Kabul Dosyası\\1-Kesin Kabul Tutanağı.doc";
        string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Kesin-Geçiçi Kabul Dosyası\\2-Kesin Kabul Tutanağı.doc";
        public static List<AsilKomisyonÜyeleri> AsilKomisyonlar = new List<AsilKomisyonÜyeleri>();
        public static List<YedekKomisyonÜyeleri> YedekKomisyonlar = new List<YedekKomisyonÜyeleri>();

        static int kesinkabulsayac = 0;
        void AsilÜyeBilgileriverial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
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
                        
                    }
                    baglan.Close();
                }
               
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 11)
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
                        
                    }
                    baglan.Close();
                   
                }
            }
            else
            {
                return;
            }
        }
        void YedekÜyeBilgileriverial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
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
        private void KomisyonÜyeleriniGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                for (int i = 0; i < AsilKomisyonlar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = AsilKomisyonlar[i].AsilKomisyonAdSoyad;

                }
                for (int a = 0; a < YedekKomisyonlar.Count; a++)
                {
                    Label lb = new Label();
                    tableLayoutPanel2.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = YedekKomisyonlar[a].YedekKomisyonAdSoyad;

                }
            }
            else
            {
                for (int i = 0; i < DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı.AsilKomisyonlar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı.AsilKomisyonlar[i].AsilKomisyonAdSoyad;

                }
                for (int a = 0; a < DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı.YedekKomisyonlar.Count; a++)
                {
                    Label lb = new Label();
                    tableLayoutPanel2.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı.YedekKomisyonlar[a].YedekKomisyonAdSoyad;

                }
            }
           
        }
        void DökümanHazırla()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum== true)
            {
                if (!File.Exists(path))
                {
                    XtraMessageBox.Show("Dosya Yok");
                }
                else
                {
                   
    
                    var word = new Word.Application();
                    var document = word.Documents.Add(path);
                    document.Variables["sözlesmetarih"].Value = sözlesmetarihi.Text;
                    document.Variables["yükleniciad"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiPiyasaFiyatAraştırmaTutanağı.tercihedilenfirma;

                    document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;
                    if (AsilKomisyonlar.Count == 1)
                    {

                        document.Variables["komisyon1"].Value = "," + AsilKomisyonlar[0].AsilKomisyonAdSoyad;
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
                        document.Variables["komisyon4"].Value = "," + "," + AsilKomisyonlar[3].AsilKomisyonAdSoyad;
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
                    richEditControl1.LoadDocument(path2);

                }

            }

           
        }
        private void KabulKomisyonuOlurYazısı_Load(object sender, EventArgs e)
        {
            AsilÜyeBilgileriverial();
            YedekÜyeBilgileriverial();
            KomisyonÜyeleriniGetir();
            
        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
            
        
    
