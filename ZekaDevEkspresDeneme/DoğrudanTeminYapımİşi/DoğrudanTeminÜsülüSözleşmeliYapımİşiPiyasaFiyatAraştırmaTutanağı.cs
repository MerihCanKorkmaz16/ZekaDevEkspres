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
using Word2 = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;


namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiPiyasaFiyatAraştırmaTutanağı : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiPiyasaFiyatAraştırmaTutanağı()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\01 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\02 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path3 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\03 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path4 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\04 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path5 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\05 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path6 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\06 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path7 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\07 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path8 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\08 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path9 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\09 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path10 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\10 Piyasa Fiyat Araştırması Tutanağı.docx";
        string path11 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\Piyasa Fiyat Araştırması Tutanağı.docx";
        string path12 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\Piyasa Fiyat Araştırması Tutanağı .docx";

        public static string tercihedilenfirma;
        public static List<FirmaBilgileri> İkinciTeklifVerenFirmalar = new List<FirmaBilgileri>();
        public static List<FirmaBilgileri> Firmalar = new List<FirmaBilgileri>();
        public static int clicksayisi;
        public static int piyasafiyatarastırmasayac;
        public static DateTime NihaiTeklifTarihi,tarih1;
        public static string yaklasikmaliyettercihedilenfirma;
        public static bool kabulkomisyonuonay = false;
        public static bool gecicikesinkabul = false;
        public static bool kesinkabul = false;
        public static string birincitekliftercihedilenfirma;
        public static string ikincitekliftercihedilenfirma;
        public static string birinciteklifsecim;
        public static string ikinciteklifsecim;

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
            NodeDisabledEtme();
        }
        void NodeDisabledEtme()
        {
            if (kabulkomisyonuonay == false)
            {
                foreach (Control item in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
                {
                    if (item is TreeView)
                    {
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
                        ((TreeView)(item)).Nodes[10].ForeColor = Color.Red;

                    }
                }
            }
            if (gecicikesinkabul == false)
            {
                foreach (Control item in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
                {
                    if (item is TreeView)
                    {
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
                        ((TreeView)(item)).Nodes[12].ForeColor = Color.Red;

                    }
                }
            }
            if (kesinkabul == false)
            {
                foreach (Control item in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
                {
                    if (item is TreeView)
                    {
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
                        ((TreeView)(item)).Nodes[11].ForeColor = Color.Red;

                    }
                }
            }
        }
        private void DoğrudanTeminÜsülüSözleşmeliYapımİşiPiyasaFiyatAraştırmaTutanağı_Load(object sender, EventArgs e)
        {
            SayacAl();
            TarihVeriAl();
            YaklasikTarihVeriAl();
            İlkTeklifFirmaVeriAl();
            İKinciTeklifFirmaVeriAl();
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel2.Controls.Clear();
            verial();
            SistemBirinciTeklifFirmaGetir();
            SistemİkinciTeklifFirmaGetir();
            GroupBoxBilgiGöster();

        }
        void TarihVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminNihaiTeklif where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    NihaiTeklifTarihi = Convert.ToDateTime(reader[3]);
                }
                baglan.Close();
            }
        }
        void YaklasikTarihVeriAl()
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
        void VeritabanıKaydet()
        {

            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminPiyasaFiyatArastırmaTutanağı (SatınAlma_id,id,BelgeTarih,Dosya,satınalmasayac,tercihedilenfirma,tercihedilenfirmaadres,kabulkomisyonuonay,gecicikesinkabulonay,kesinkabulonay,İkinciDosya,TeklifSecimDurumu) values (@SatınAlma_id ,@id,@BelgeTarih,@dosya,@satınalmasayac,@tercihedilenfirma,@tercihedilenfirmaadres,@kabulkomisyonuonay,@gecicikesinkabulonay,@kesinkabulonay , @İkinciDosya,@TeklifSecimDurumu)", sqlConnection);
                komut.Parameters.Clear();
                System.Threading.Thread.Sleep(200);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path11));
                System.Threading.Thread.Sleep(300);
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                else {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@id", 2);
                if (radioButton1.Checked== true)
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirmaadres",ilktekliffirmaadres.Text);
                }
                else
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirmaadres", ikincitekliffirmadres.Text);

                }
                komut.Parameters.AddWithValue("@BelgeTarih", BelgeTarih.Value); ;
                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirma", birincitekliftercihedilenfirma);

                }
                else if (radioButton2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirma", ikincitekliftercihedilenfirma);

                }
                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@TeklifSecimDurumu", birinciteklifsecim);
                }
                else if (radioButton2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@TeklifSecimDurumu", ikinciteklifsecim);

                }
                komut.Parameters.AddWithValue("@satınalmasayac", 10);
                komut.Parameters.AddWithValue("@kabulkomisyonuonay", kabulkomisyonuonay);
                komut.Parameters.AddWithValue("@gecicikesinkabulonay", gecicikesinkabul);
                komut.Parameters.AddWithValue("@kesinkabulonay",kesinkabul);
                komut.Parameters.AddWithValue("@İkinciDosya", File.ReadAllBytes(path12));
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }
        void İlkTeklifFirmaVeriAl()
        {

            Firmalar.Clear();
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true  )
            {
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
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 9)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİlkTeklifFirmalar where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
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

        }
        void VeritabanıGüncelle()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminPiyasaFiyatArastırmaTutanağı set BelgeTarih=@BelgeTarih,Dosya = @dosya, tercihedilenfirma = @tercihedilenfirma, tercihedilenfirmaadres = @tercihedilenfirmaadres, kabulkomisyonuonay = @kabulkomisyonuonay , gecicikesinkabulonay = @gecicikesinkabulonay, kesinkabulonay=@kesinkabulonay,İkinciDosya = @İkinciDosya, TeklifSecimDurumu = @TeklifSecimDurumu where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Parameters.AddWithValue("@BelgeTarih", BelgeTarih.Value);
                komut.Parameters.AddWithValue("@id", 2);
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirmaadres", ilktekliffirmaadres.Text);
                }
                else
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirmaadres", ikincitekliffirmadres.Text);

                }
                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirma", birincitekliftercihedilenfirma);

                }
                else if (radioButton2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@tercihedilenfirma", ikincitekliftercihedilenfirma);

                }
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path11));
                System.Threading.Thread.Sleep(300);
                if (radioButton1.Checked == true)
                {
                    komut.Parameters.AddWithValue("@TeklifSecimDurumu", birinciteklifsecim);
                }
                else if (radioButton2.Checked == true)
                {
                    komut.Parameters.AddWithValue("@TeklifSecimDurumu", ikinciteklifsecim);

                }
                komut.Parameters.AddWithValue("@kabulkomisyonuonay", kabulkomisyonuonay);
                komut.Parameters.AddWithValue("@gecicikesinkabulonay", gecicikesinkabul);
                komut.Parameters.AddWithValue("@kesinkabulonay", kesinkabul);
                komut.Parameters.AddWithValue("@İkinciDosya", File.ReadAllBytes(path12));

                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
               
            }
        }
        void İKinciTeklifFirmaVeriAl()
        {
            İkinciTeklifVerenFirmalar.Clear();
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (DoğrudanTeminSözleşmeliYapımİşiFormu.İkinciTeklifDurum == true)
                {
                    using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                    using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİkinciTeklifFirma where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                    {
                        baglan.Open();
                        SqlDataReader reader = komut.ExecuteReader();
                        while (reader.Read())
                        {
                            FirmaBilgileri firma = new FirmaBilgileri()
                            {
                                Firmafiyat = Convert.ToDecimal(reader[4]),
                                Firmaisim = Convert.ToString(reader[3]),
                                Teklifverilentarih = Convert.ToDateTime(reader[5])
                            };
                            İkinciTeklifVerenFirmalar.Add(firma);

                        }
                        baglan.Close();
                        reader.Close();
                        
                    }

                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 9)
            {
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifDurum == true)
                {
                    using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                    using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİkinciTeklifFirma where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                    {
                        baglan.Open();
                        SqlDataReader reader = komut.ExecuteReader();
                        while (reader.Read())
                        {
                            FirmaBilgileri firma = new FirmaBilgileri()
                            {
                                Firmafiyat = Convert.ToDecimal(reader[3]),
                                Firmaisim = reader[2].ToString(),
                                Teklifverilentarih = Convert.ToDateTime(reader[4])
                            };
                            İkinciTeklifVerenFirmalar.Add(firma);

                        }
                        baglan.Close();
                        reader.Close();
                    }


                }


            }
        }
        void GroupBoxBilgiGöster()
        {
            var yaklasiktercihedilenfirmabilgi = Firmalar
           .OrderBy(k => k.Firmafiyat)
           .FirstOrDefault();
            yaklasikmaliyettercihedilenfirma = yaklasiktercihedilenfirmabilgi.Firmaisim;
            textBox1.Text = yaklasiktercihedilenfirmabilgi.Firmaisim;
            textBox2.Text = DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet.ToString("#,##0.00₺");
            if ( DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifDurum == true)
            {
                var nihaitercihedilenfirmabilgi = DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifVerenFirmalar
               .OrderBy(k => k.Firmafiyat)
               .FirstOrDefault();
                textBox3.Text = nihaitercihedilenfirmabilgi.Firmaisim;
                textBox4.Text = DoğrudanTeminSözleşmeliYapımİşiFormu.nihaiyaklasikmaliyet.ToString("#,##0.00₺");
                groupBox4.Visible = true;
                flowLayoutPanel2.Visible = true;
            }
            else
            {
                var nihaitercihedilenfirmabilgi = İkinciTeklifVerenFirmalar
              .OrderBy(k => k.Firmafiyat)
              .FirstOrDefault();
                textBox3.Text = nihaitercihedilenfirmabilgi.Firmaisim;
                textBox4.Text = DoğrudanTeminSözleşmeliYapımİşiFormu.nihaiyaklasikmaliyet.ToString("#,##0.00₺");
                groupBox4.Visible = true;
                flowLayoutPanel2.Visible = true;
            }
        }
        void verial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true  && piyasafiyatarastırmasayac == 10)
            {
                
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPiyasaFiyatArastırmaTutanağı where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        BelgeTarih.Text = reader[3].ToString();
                        BelgeTarih.Value = Convert.ToDateTime(reader[3]);
                        tercihedilenfirma = reader[5].ToString();
                        birinciteklifsecim = reader[12].ToString();
                        kabulkomisyonuonay = Convert.ToBoolean(reader[7]);
                        gecicikesinkabul = Convert.ToBoolean(reader[8]);
                        kesinkabul = Convert.ToBoolean(reader[9]);
                        if (birinciteklifsecim == "BirinciTeklif")
                        {
                            radioButton1.Checked = true;
                            ilktekliffirmaadres.Text = reader[6].ToString();
                        }
                        else
                        {
                            radioButton2.Checked = true;
                            ikincitekliffirmadres.Text = reader[6].ToString();
                        }
                        if (kabulkomisyonuonay == true)
                        {
                            checkBox1.Checked = true;
                        }
                        if (gecicikesinkabul == true)
                        {
                            checkBox3.Checked = true;
                        }
                        if (kesinkabul == true)
                        {
                            checkBox2.Checked = true;
                        }
                    }
                   
                    baglan.Close();
                }
                
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 9)
            {
                
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPiyasaFiyatArastırmaTutanağı where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        BelgeTarih.Text = reader[3].ToString();
                        BelgeTarih.Value = Convert.ToDateTime(reader[3]);
                        tercihedilenfirma = reader[5].ToString();
                        birinciteklifsecim = reader[12].ToString();
                        if (birinciteklifsecim == "BirinciTeklif")
                        {
                            radioButton1.Checked = true;
                            ilktekliffirmaadres.Text = reader[6].ToString();
                        }
                        else
                        {
                            radioButton2.Checked = true;
                            ikincitekliffirmadres.Text = reader[6].ToString();
                        }
                    }
                   
                    baglan.Close();
                }
                

            }
            else
            {
                return;
            }
        }
        void BirinciTeklifDökümanHazırla()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
               var fliste2 = Firmalar.Where(s => s.Teklifverilentarih < tarih1).ToList();
                var tercihedilenfirmabilgi2 = Firmalar
               .OrderBy(k => k.Firmafiyat)
               .FirstOrDefault();
                birincitekliftercihedilenfirma = tercihedilenfirmabilgi2.Firmaisim;
              
                if (fliste2.Count == 1)
                {
                    if (!File.Exists(path1))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path1);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 2)
                {
                    if (!File.Exists(path2))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {
                        
                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path2);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 3)
                {
                    if (!File.Exists(path3))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path3);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 4)
                {
                    if (!File.Exists(path4))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path4);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 5)
                {
                    if (!File.Exists(path5))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path5);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 6)
                {
                    if (!File.Exists(path6))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path6);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 7)
                {
                    if (!File.Exists(path7))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path7);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 8)
                {
                    if (!File.Exists(path8))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path8);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma8"].Value = fliste2[7].Firmaisim;
                        document2.Variables["fiyat8"].Value = fliste2[7].Firmafiyat.ToString("0.##₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 9)
                {
                    if (!File.Exists(path9))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path9);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma8"].Value = fliste2[7].Firmaisim;
                        document2.Variables["fiyat8"].Value = fliste2[7].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma9"].Value = fliste2[8].Firmaisim;
                        document2.Variables["fiyat9"].Value = fliste2[8].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 10)
                {
                    if (!File.Exists(path10))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path10);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma8"].Value = fliste2[7].Firmaisim;
                        document2.Variables["fiyat8"].Value = fliste2[7].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma9"].Value = fliste2[8].Firmaisim;
                        document2.Variables["fiyat9"].Value = fliste2[8].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma10"].Value = fliste2[9].Firmaisim;
                        document2.Variables["fiyat10"].Value = fliste2[9].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);
                    }
                }
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 10;
                clicksayisi += 1;
            }
            else
            {
                var fliste2 = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar.Where(s => s.Teklifverilentarih < DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif.tarih1).ToList();
                var tercihedilenfirmabilgi2 = Firmalar
               .OrderBy(k => k.Firmafiyat)
               .FirstOrDefault();
                birincitekliftercihedilenfirma = tercihedilenfirmabilgi2.Firmaisim;

                if (fliste2.Count == 1)
                {
                    if (!File.Exists(path1))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path1);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");

                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 2)
                {
                    if (!File.Exists(path2))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path2);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 3)
                {
                    if (!File.Exists(path3))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path3);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 4)
                {
                    if (!File.Exists(path4))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path4);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 5)
                {
                    if (!File.Exists(path5))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path5);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 6)
                {
                    if (!File.Exists(path6))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path6);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 7)
                {
                    if (!File.Exists(path7))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path7);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 8)
                {
                    if (!File.Exists(path8))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path8);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma8"].Value = fliste2[7].Firmaisim;
                        document2.Variables["fiyat8"].Value = fliste2[7].Firmafiyat.ToString("0.##₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 9)
                {
                    if (!File.Exists(path9))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path9);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma8"].Value = fliste2[7].Firmaisim;
                        document2.Variables["fiyat8"].Value = fliste2[7].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma9"].Value = fliste2[8].Firmaisim;
                        document2.Variables["fiyat9"].Value = fliste2[8].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
                if (fliste2.Count == 10)
                {
                    if (!File.Exists(path10))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word2 = new Word.Application();
                        var document2 = word2.Documents.Add(path10);
                        document2.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document2.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document2.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document2.Variables["firma1"].Value = fliste2[0].Firmaisim;
                        document2.Variables["fiyat1"].Value = fliste2[0].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma2"].Value = fliste2[1].Firmaisim;
                        document2.Variables["fiyat2"].Value = fliste2[1].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma3"].Value = fliste2[2].Firmaisim;
                        document2.Variables["fiyat3"].Value = fliste2[2].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma4"].Value = fliste2[3].Firmaisim;
                        document2.Variables["fiyat4"].Value = fliste2[3].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma5"].Value = fliste2[4].Firmaisim;
                        document2.Variables["fiyat5"].Value = fliste2[4].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma6"].Value = fliste2[5].Firmaisim;
                        document2.Variables["fiyat6"].Value = fliste2[5].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma7"].Value = fliste2[6].Firmaisim;
                        document2.Variables["fiyat7"].Value = fliste2[6].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma8"].Value = fliste2[7].Firmaisim;
                        document2.Variables["fiyat8"].Value = fliste2[7].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma9"].Value = fliste2[8].Firmaisim;
                        document2.Variables["fiyat9"].Value = fliste2[8].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["firma10"].Value = fliste2[9].Firmaisim;
                        document2.Variables["fiyat10"].Value = fliste2[9].Firmafiyat.ToString("#,##0.00₺");
                        document2.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi2.Firmaisim;
                        document2.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi2.Firmafiyat.ToString("#,##0.00₺");
                        document2.Fields.Update();
                        document2.SaveAs2(path11);
                        word2.Quit();
                        System.Threading.Thread.Sleep(200);
                    }
                }
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 10;
                clicksayisi += 1;
            }
        }
        void İkinciTeklifDökümanHazırla()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                var fliste = İkinciTeklifVerenFirmalar.Where(s => s.Teklifverilentarih < NihaiTeklifTarihi).ToList();
                var tercihedilenfirmabilgi = İkinciTeklifVerenFirmalar
               .OrderBy(k => k.Firmafiyat)
               .FirstOrDefault();
                tercihedilenfirma = tercihedilenfirmabilgi.Firmaisim;
                ikincitekliftercihedilenfirma = tercihedilenfirmabilgi.Firmaisim;

                if (fliste.Count == 1)
                {
                    if (!File.Exists(path1))
                    {
                        XtraMessageBox.Show("Dosya Yok");
                    }
                    else
                    {

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path1);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(100);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path2);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                    
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path3);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        if (radioButton1.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path4);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path5);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path6);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);


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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path7);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path8);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["fiyat8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path9);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["fiyat8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["fiyat9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);


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

                        var word = new Word2.Application();
                        var document = word.Documents.Add(path10);
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["fiyat8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["fiyat9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma10"].Value = fliste[9].Firmaisim;
                        document.Variables["fiyat10"].Value = fliste[9].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();
                        System.Threading.Thread.Sleep(200);

                    }
                }
            }
            else
            {
                var fliste = DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifVerenFirmalar.Where(s => s.Teklifverilentarih < NihaiTeklifSüreci.NihaiTeklifSüresi).ToList();
                var tercihedilenfirmabilgi = İkinciTeklifVerenFirmalar
               .OrderBy(k => k.Firmafiyat)
               .FirstOrDefault();
                tercihedilenfirma = tercihedilenfirmabilgi.Firmaisim;
                ikincitekliftercihedilenfirma = tercihedilenfirmabilgi.Firmaisim;

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");

                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();


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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton1.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }

                        if (radioButton1.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ilktekliffirmaadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["fiyat8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["fiyat8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["fiyat9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

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
                        document.Variables["tarih"].Value = BelgeTarih.Text;
                        if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                        }
                        else
                        {
                            document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                        }
                        if (radioButton2.Checked == true)
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = ikincitekliffirmadres.Text;

                        }
                        else
                        {
                            document.Variables["tercihedilenfirmaadres"].Value = " ";

                        }
                        document.Variables["firma1"].Value = fliste[0].Firmaisim;
                        document.Variables["fiyat1"].Value = fliste[0].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma2"].Value = fliste[1].Firmaisim;
                        document.Variables["fiyat2"].Value = fliste[1].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma3"].Value = fliste[2].Firmaisim;
                        document.Variables["fiyat3"].Value = fliste[2].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma4"].Value = fliste[3].Firmaisim;
                        document.Variables["fiyat4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma5"].Value = fliste[4].Firmaisim;
                        document.Variables["fiyat5"].Value = fliste[4].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma6"].Value = fliste[5].Firmaisim;
                        document.Variables["fiyat6"].Value = fliste[5].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma7"].Value = fliste[6].Firmaisim;
                        document.Variables["fiyat7"].Value = fliste[6].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma8"].Value = fliste[7].Firmaisim;
                        document.Variables["fiyat8"].Value = fliste[7].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma9"].Value = fliste[8].Firmaisim;
                        document.Variables["fiyat9"].Value = fliste[8].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["firma10"].Value = fliste[9].Firmaisim;
                        document.Variables["fiyat10"].Value = fliste[9].Firmafiyat.ToString("#,##0.00₺");
                        document.Variables["tercihedilenfirmaad"].Value = tercihedilenfirmabilgi.Firmaisim;
                        document.Variables["tercihedilenfirmafiyat"].Value = tercihedilenfirmabilgi.Firmafiyat.ToString("#,##0.00₺");
                        document.Fields.Update();
                        document.SaveAs2(path12);
                        word.Quit();

                    }
                }
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 10;
                clicksayisi += 1;
            }
           
        }
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPiyasaFiyatArastırmaTutanağı where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        piyasafiyatarastırmasayac = Convert.ToInt32(reader[4]);
                    }
                    baglan.Close();
                    button2.Visible = true;

                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 10)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPiyasaFiyatArastırmaTutanağı where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        piyasafiyatarastırmasayac = Convert.ToInt32(reader[4]);
                    }
                    baglan.Close();
                    button2.Visible = true;

                }
            }

        }
        private void SistemBirinciTeklifFirmaGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                for (int i = 0; i < Firmalar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = Firmalar[i].Firmaisim.ToString();

                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 9)
            {
                for (int i = 0; i < Firmalar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar[i].Firmaisim.ToString();

                }
            }
            else
            {
                for (int i = 0; i < DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar[i].Firmaisim.ToString();

                }
            }
        }
        private void SistemİkinciTeklifFirmaGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (DoğrudanTeminSözleşmeliYapımİşiFormu.İkinciTeklifDurum == true)
                {
                    for (int i = 0; i < İkinciTeklifVerenFirmalar.Count; i++)
                    {
                        Label lb = new Label();
                        tableLayoutPanel2.Controls.Add(lb);
                        lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                        lb.Text = İkinciTeklifVerenFirmalar[i].Firmaisim.ToString();

                    }

                }

            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 9)
            {
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifDurum == true)
                {
                    for (int i = 0; i < DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifVerenFirmalar.Count; i++)
                    {
                        Label lb = new Label();
                        tableLayoutPanel2.Controls.Add(lb);
                        lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                        lb.Text = DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifVerenFirmalar[i].Firmaisim.ToString();

                    }

                }
            }
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                XtraMessageBox.Show("Tercih Ettiğiniz Teklifi Belirleyiniz.");
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    if (ilktekliffirmaadres.Text == "" || ilktekliffirmaadres.Text == "Tercih ettiğiniz firmaya göre doldurunuz.")
                    {
                        XtraMessageBox.Show("Birinci Teklif Adres Kısmını Doldurunuz.");
                        return;
                    }
                    else
                    {
                        if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                        {
                            if (piyasafiyatarastırmasayac == 10)
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;
                                backgroundWorker2.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                               

                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }
                            else
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;

                                backgroundWorker1.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }
                        }
                        else
                        {
                            if (clicksayisi > 0)
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;

                                backgroundWorker2.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }
                            else
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;

                                backgroundWorker1.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }

                        }


                    }
                }
                if (radioButton2.Checked == true)
                {
                    if (ikincitekliffirmadres.Text == "" || ikincitekliffirmadres.Text == "Tercih ettiğiniz firmaya göre doldurunuz.")
                    {
                        XtraMessageBox.Show("İkinci Teklif Adres Kısmını Doldurunuz.");
                        return;
                    }
                    else
                    {
                        if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                        {
                            if (piyasafiyatarastırmasayac == 10)
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;
                                backgroundWorker2.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);

                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }
                            else
                            {
                                button1.Enabled = false;
                                backgroundWorker1.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }
                        }
                        else
                        {
                            if (clicksayisi > 0)
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;

                                backgroundWorker2.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }
                            else
                            {
                                button1.Enabled = false;
                                button2.Enabled = false;

                                backgroundWorker1.RunWorkerAsync();
                                System.Threading.Thread.Sleep(200);
                                //DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                                //piyasa.ShowDialog();
                            }

                        }


                    }
                }
            }

        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BirinciTeklifDökümanHazırla();
            İkinciTeklifDökümanHazırla();
            VeritabanıKaydet();
            
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;

        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            BirinciTeklifDökümanHazırla();
            İkinciTeklifDökümanHazırla();
            VeritabanıGüncelle();
           
        }
        private void İlktekliffirmaadres_Enter(object sender, EventArgs e)
        {
            if (ilktekliffirmaadres.Text == "Tercih ettiğiniz firmaya göre doldurunuz.")
            {
                ilktekliffirmaadres.Clear();
                return;
            }
        }
        private void İkincitekliffirmadres_Enter(object sender, EventArgs e)
        {
            if (ikincitekliffirmadres.Text == "Tercih ettiğiniz firmaya göre doldurunuz.")
            {
                ikincitekliffirmadres.Clear();
                return;
            }
            
           
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                kabulkomisyonuonay = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;

            }
            else
            {
                kabulkomisyonuonay = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
            }
        }
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                gecicikesinkabul = true;
            }
            else
            {
                gecicikesinkabul = false;

            }
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                kesinkabul = true;
            }
            else
            {
                kesinkabul = false;

            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                DoğrudanTeminPiyasaFiyatArastırmaFormGöster piyasa = new DoğrudanTeminPiyasaFiyatArastırmaFormGöster();
                piyasa.ShowDialog();
            }
            catch (System.InvalidOperationException)
            {

                MessageBox.Show("Tekrar Deneyiniz.");
            }
            
        }
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                birinciteklifsecim = "BirinciTeklif";
                flowLayoutPanel2.Enabled = false;
                flowLayoutPanel1.Enabled = true;
            }
            else if (radioButton2.Checked == true)
            {
                ikinciteklifsecim = "İkinciTeklif";
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel2.Enabled = true;
            }
        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
           button2.Enabled = true;

        }
    }
}