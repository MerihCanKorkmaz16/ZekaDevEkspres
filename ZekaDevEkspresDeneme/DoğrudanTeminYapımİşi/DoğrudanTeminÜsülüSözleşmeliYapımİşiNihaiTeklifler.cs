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
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
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
        public static List<FirmaBilgileri> İkinciTeklifVerenFirmalar = new List<FirmaBilgileri>();
        public static List<FirmaBilgileri> Firmalar = new List<FirmaBilgileri>();
        public static decimal nihaiyaklasikmaliyet;
        public static bool İkinciTeklifDurum = false;
        decimal toplam = 0;
        DateTime NihaiTeklifSüresi;
        public static int clicksayisi;
        public static int ikinciteklifsayac;

        void verial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                İkinciTeklifVerenFirmalar.Clear();
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
                        nihaiyaklasikmaliyet = Convert.ToDecimal(reader[7]);
                        İkinciTeklifDurum = Convert.ToBoolean(reader[9]);
                        dateTimePicker1.Text = reader[2].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader[2]);
                        if (İkinciTeklifDurum == true)
                        {
                            checkBox1.Checked = true;
                        }
                        else
                        {
                            checkBox1.Checked = false;
                        }
                    }
                    baglan.Close();
                }
                Hesapİslemleri();
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 7)
            {
                İkinciTeklifVerenFirmalar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİkinciTeklifFirma where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
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
                        nihaiyaklasikmaliyet = Convert.ToDecimal(reader[7]);
                        İkinciTeklifDurum = Convert.ToBoolean(reader[9]);
                        dateTimePicker1.Text = reader[2].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(reader[2]);
                        if (İkinciTeklifDurum == true)
                        {
                            checkBox1.Checked = true;
                        }
                        else
                        {
                            checkBox1.Checked = false;
                        }
                    }
                    baglan.Close();
                }
                Hesapİslemleri();
            }
        }
        void İlkTeklifFirmaVeriAl()
        {
            Firmalar.Clear();
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
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
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 7)
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
            textBox1.Text = Firmalar.Count.ToString();
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
                    NihaiTeklifSüresi = Convert.ToDateTime(reader[3]);
                }
                baglan.Close();
            }
        }
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİkinciTeklifFirma where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        ikinciteklifsayac = Convert.ToInt32(reader[8]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 7)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİkinciTeklifFirma where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        ikinciteklifsayac = Convert.ToInt32(reader[8]);
                    }
                    baglan.Close();
                }
            }

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int sistemfirmasayisi = Firmalar.Count;
            int uzunluk = 10;
            if (textBox1.Text == "")
            {
                XtraMessageBox.Show("2.Teklif Firma Sayısı Alanı Doldurmak Zorunludur.");
            }
            else
            {
                if (int.Parse(textBox1.Text) == 0)
                {
                    XtraMessageBox.Show("Girilen değer Sıfır olamaz");
                    return;
                }
                else
                {
                    if (int.Parse(textBox1.Text) > sistemfirmasayisi)
                    {
                        XtraMessageBox.Show("Girdiğiniz 2.Teklif Firma sayısı Sisteme Girilen Firma Sayısından Fazla !");
                        simpleButton3.Enabled = false;
                        return;
                    }
                    else
                    {
                        simpleButton3.Enabled = true;
                        if (textBox1.Text != "")
                        {
                            if (int.Parse(textBox1.Text) > uzunluk)
                            {
                                XtraMessageBox.Show("Belirlenen Maksimum Firma Sayısı :" + uzunluk + "dir");
                                simpleButton3.Enabled = false;
                                return;
                            }
                            else
                            {

                                simpleButton3.Enabled = true;
                            }
                        }

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
        private void SistemKayıtlıFirmaGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 8)
            {
                for (int i = 0; i < Firmalar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = Firmalar[i].Firmaisim;

                }
            }
            else
            {
                for (int i = 0; i < DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel1.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = DoğrudanTeminSözleşmeliYapımİşiFirmaEkle.Firmalar[i].Firmaisim;

                }
            }
        }
        private void FirmaİsimTextler()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < sayi; i++)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                tableLayoutPanel2.Controls.Add(txt);
                txt.Name = "Firmaisim" + i.ToString();
            }

        }
        private void FirmaFiyatTextler()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < sayi; i++)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                tableLayoutPanel3.Controls.Add(txt);
                txt.Name = "firmafiyat" + i.ToString();
                txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
            }
        }
        void VeritabanıSil()
        {
            SqlConnection baglanti = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from DoğrudanTeminİkinciTeklifFirma where id = @id and SatınAlma_id = @SatınAlma_id ", baglanti);
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
        private void FirmaTeklifText()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            for (int i = 0; i < sayi; i++)
            {
                System.Windows.Forms.DateTimePicker date = new System.Windows.Forms.DateTimePicker();
                tableLayoutPanel4.Controls.Add(date);
                date.Name = "firmatarih" + i.ToString();

            }
        }
        private void VeritabanıFirmaİsimTextler()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 8)
            {
                if (ikinciteklifsayac == 8)
                {
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {
                        System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                        tableLayoutPanel2.Controls.Add(txt);
                        txt.Name = "Firmaisim" + i.ToString();
                        txt.Text = İkinciTeklifVerenFirmalar[i].Firmaisim;

                    }

                }

            }
        }
        private void VeriTabanıFirmaFiyatTextler()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 8)
            {
                if (ikinciteklifsayac == 8)
                {
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {
                        System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                        tableLayoutPanel3.Controls.Add(txt);
                        txt.Name = "firmafiyat" + i.ToString();
                        txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                        txt.Text = İkinciTeklifVerenFirmalar[i].Firmafiyat.ToString();

                    }

                }

            }
           
        }
        private void VeriTabanıFirmaTeklifText()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 8)
            {

                if (ikinciteklifsayac == 8)
                {
                    for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                    {
                        System.Windows.Forms.DateTimePicker date = new System.Windows.Forms.DateTimePicker();
                        tableLayoutPanel4.Controls.Add(date);
                        date.Name = "firmatarih" + i.ToString();
                        date.Text = İkinciTeklifVerenFirmalar[i].Teklifverilentarih.ToString();

                    }


                }

            }
        }
        private void BosGecilemezKontrol()
        {
            if (textBox1.Text == "")
            {
                XtraMessageBox.Show("Lütfen 2.Teklifler Kısmını Boş bırakmayınız.");
            }
            else
            {
                İkinciTeklifVerenFirmalar.Clear();
                foreach (Control ctl in tableLayoutPanel2.Controls)
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
                foreach (Control ctl2 in tableLayoutPanel3.Controls)
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
                VeritabanıEkle();
            }
            

        }
        private void GüncelleBosGecilemezKontrol()
        {
            if (textBox1.Text == "")
            {
                XtraMessageBox.Show("Lütfen 2.Teklifler Kısmını Boş bırakmayınız.");
            }
            else
            {
                foreach (Control ctl in tableLayoutPanel2.Controls)
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
                foreach (Control ctl2 in tableLayoutPanel3.Controls)
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
                İkinciTeklifVerenFirmalar.Clear();
                FirmaBilgileriGetir();
                DökümanHazırla();
                VeritabanıSil();
                VeritabanıEkle();
            }


        }
        private void FirmaBilgileriGetir()
        {
            İkinciTeklifVerenFirmalar.Clear();
            for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
            {
                İkinciTeklifVerenFirmalar.Add(new FirmaBilgileri()
                {
                    Firmaisim = ((TextBox)tableLayoutPanel2.Controls["Firmaisim" + (i).ToString()]).Text,
                    Firmafiyat = Convert.ToDecimal(((TextBox)tableLayoutPanel3.Controls["firmafiyat" + (i).ToString()]).Text),
                    Teklifverilentarih = Convert.ToDateTime(((DateTimePicker)tableLayoutPanel4.Controls["firmatarih" + (i).ToString()]).Text)
                });
            }
        }
        void VeritabanıEkle()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut2 = new SqlCommand("Insert into DoğrudanTeminİkinciTeklifFirma(SatınAlma_id,id,BelgeTarih,firmaisim,firmafiyat,firmateklifTarihi,satınalmasayac,Dosya,nihaiyaklasıkmaliyet,ikinciteklifdurum) VALUES (@SatınAlma_id,@id,@BelgeTarih,@firma,@firmafiyat,@firmateklif,@satınalmasayac,@dosya,@nihaiyaklasıkmaliyet, @ikinciteklifdurum) ", baglan))
            {
                baglan.Open();
                foreach (var nesne in İkinciTeklifVerenFirmalar)
                {
                    komut2.Parameters.Clear();
                    if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                    }
                    else
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id",DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                    }
                    komut2.Parameters.AddWithValue("@id", 2);
                    komut2.Parameters.AddWithValue("@satınalmasayac", 8);
                    komut2.Parameters.AddWithValue("@BelgeTarih",dateTimePicker1.Value);
                    komut2.Parameters.AddWithValue("@firma", nesne.Firmaisim);
                    komut2.Parameters.AddWithValue("@firmafiyat", nesne.Firmafiyat);
                    komut2.Parameters.AddWithValue("@firmateklif", nesne.Teklifverilentarih);
                    komut2.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path11));
                    komut2.Parameters.AddWithValue("@nihaiyaklasıkmaliyet", nihaiyaklasikmaliyet); 
                    komut2.Parameters.AddWithValue("@ikinciteklifdurum", İkinciTeklifDurum);
                    komut2.ExecuteNonQuery();
                }
                baglan.Close();
            }
        }
        void Hesapİslemleri()
        {
            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet != 0)
            {
                label8.Text = DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet.ToString("#,##0.00₺");

            }
            else
            {
                label8.Text = DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet.ToString("#,##0.00₺");

            }
            label9.Visible = true;
            label10.Visible = true;
            label10.Text = nihaiyaklasikmaliyet.ToString("#,##0.00₺");

            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet != 0)
            {
                if (nihaiyaklasikmaliyet < DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet)
                {
                    groupBox4.Visible = true;
                    label11.Text = "DÜŞÜK✓";
                    label11.ForeColor = Color.Green;
                    İkinciTeklifDurum = true;
                }
                else
                {

                    groupBox4.Visible = true;
                    label11.Text = "YÜKSEK!";
                    label11.ForeColor = Color.Red;
                }
            }
            else
            {
                if (nihaiyaklasikmaliyet < DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet)
                {
                    groupBox4.Visible = true;
                    label11.Text = "DÜŞÜK✓";
                    label11.ForeColor = Color.Green;
                    İkinciTeklifDurum = true;
                }
                else
                {

                    groupBox4.Visible = true;
                    label11.Text = "YÜKSEK!";
                    label11.ForeColor = Color.Red;
                }
            }

        }
        void txt_KeyPress(object sender, KeyPressEventArgs e)
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
        private void DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler_Load(object sender, EventArgs e)
        {
            TarihVeriAl();
            SayacAl();
            İlkTeklifFirmaVeriAl();
            SistemKayıtlıFirmaGetir();
            verial();
            VeriTabanıFirmaFiyatTextler();
            VeriTabanıFirmaTeklifText();
            VeritabanıFirmaİsimTextler();
            Hesapİslemleri();
            
        }
        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                XtraMessageBox.Show("Lütfen İlgili alanları Doldurunuz");

            }
            else
            {
                İkinciTeklifDurum = true;
                İkinciTeklifVerenFirmalar.Clear();
                tableLayoutPanel2.Controls.Clear();
                tableLayoutPanel3.Controls.Clear();
                tableLayoutPanel4.Controls.Clear();
                FirmaFiyatTextler();
                FirmaTeklifText();
                FirmaİsimTextler();
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {

            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (ikinciteklifsayac == 8)
                {
                    GüncelleBosGecilemezKontrol();
                }
                else
                {
                    BosGecilemezKontrol();
                }
            }
            else if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == false)
            {
                if (clicksayisi> 0)
                {
                    GüncelleBosGecilemezKontrol();
                }
                else
                {
                    BosGecilemezKontrol();
                }
            }
            Hesapİslemleri();
        }
        void DökümanHazırla()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 8)
            {
                try
                {
                    var fliste = İkinciTeklifVerenFirmalar.Where(s => s.Teklifverilentarih < NihaiTeklifSüresi).ToList();
                    for (int i = 0; i < fliste.Count; i++)//1-2
                    {
                        toplam += fliste[i].Firmafiyat;
                    }
                    nihaiyaklasikmaliyet = ((toplam) / fliste.Count);
                    nihaiyaklasikmaliyet = Math.Truncate(100 * nihaiyaklasikmaliyet) / 100;
                    DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;
                    clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;
                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra8"].Value = "8";
                            document.Variables["firma8"].Value = fliste[7].Firmaisim;
                            document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra8"].Value = "8";
                            document.Variables["firma8"].Value = fliste[7].Firmaisim;
                            document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra9"].Value = "9";
                            document.Variables["firma9"].Value = fliste[8].Firmaisim;
                            document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra8"].Value = "8";
                            document.Variables["firma8"].Value = fliste[7].Firmaisim;
                            document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra9"].Value = "9";
                            document.Variables["firma9"].Value = fliste[8].Firmaisim;
                            document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra10"].Value = "10";
                            document.Variables["firma10"].Value = fliste[9].Firmaisim;
                            document.Variables["satıs10"].Value = fliste[9].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
                            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;

                        }
                    }
                }
                catch (DivideByZeroException)
                {

                    MessageBox.Show("Girdiğiniz Firmalar Geç Teklif Vermiş Dikkat Ediniz.");
                }
                

            }
            else
            {
                try
                {
                    var fliste = İkinciTeklifVerenFirmalar.Where(s => s.Teklifverilentarih < NihaiTeklifSüreci.NihaiTeklifSüresi).ToList();
                    for (int i = 0; i < fliste.Count; i++)//1-2
                    {
                        toplam += fliste[i].Firmafiyat;
                    }
                    nihaiyaklasikmaliyet = ((toplam) / fliste.Count);
                    nihaiyaklasikmaliyet = Math.Truncate(100 * nihaiyaklasikmaliyet) / 100;
                    DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 8;
                    clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("#,##0.00₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");

                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra8"].Value = "8";
                            document.Variables["firma8"].Value = fliste[7].Firmaisim;
                            document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra8"].Value = "8";
                            document.Variables["firma8"].Value = fliste[7].Firmaisim;
                            document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra9"].Value = "9";
                            document.Variables["firma9"].Value = fliste[8].Firmaisim;
                            document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);

                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
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
                            if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                            }
                            else
                            {
                                document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                            }
                            document.Variables["tarih"].Value = dateTimePicker1.Text;
                            document.Variables["firma1"].Value = fliste[0].Firmaisim;
                            document.Variables["satıs1"].Value = fliste[0].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra2"].Value = "2";
                            document.Variables["firma2"].Value = fliste[1].Firmaisim;
                            document.Variables["satıs2"].Value = fliste[1].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra3"].Value = "3";
                            document.Variables["firma3"].Value = fliste[2].Firmaisim;
                            document.Variables["satıs3"].Value = fliste[2].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra4"].Value = "4";
                            document.Variables["firma4"].Value = fliste[3].Firmaisim;
                            document.Variables["satıs4"].Value = fliste[3].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra5"].Value = "5";
                            document.Variables["firma5"].Value = fliste[4].Firmaisim;
                            document.Variables["satıs5"].Value = fliste[4].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra6"].Value = "6";
                            document.Variables["firma6"].Value = fliste[5].Firmaisim;
                            document.Variables["satıs6"].Value = fliste[5].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra7"].Value = "7";
                            document.Variables["firma7"].Value = fliste[6].Firmaisim;
                            document.Variables["satıs7"].Value = fliste[6].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra8"].Value = "8";
                            document.Variables["firma8"].Value = fliste[7].Firmaisim;
                            document.Variables["satıs8"].Value = fliste[7].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra9"].Value = "9";
                            document.Variables["firma9"].Value = fliste[8].Firmaisim;
                            document.Variables["satıs9"].Value = fliste[8].Firmafiyat.ToString("0.##₺");
                            document.Variables["sıra10"].Value = "10";
                            document.Variables["firma10"].Value = fliste[9].Firmaisim;
                            document.Variables["satıs10"].Value = fliste[9].Firmafiyat.ToString("0.##₺");
                            document.Variables["ortalama"].Value = nihaiyaklasikmaliyet.ToString("0.##₺");
                            document.Fields.Update();
                            document.SaveAs2(path11);
                            word.Quit();
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path11);
                            clicksayisi += 1;
                        }
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Girdiğiniz Firmalar Geç Teklif Vermiş Dikkat Ediniz.");

                }





            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox3.Enabled = true;
                label7.Visible = true;
                label8.Visible = true;
            }
            else
            {
                
                groupBox3.Enabled = false;
                label7.Visible = false;
                label8.Visible = false;
            }
        }
        
    }
}