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

namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminSözleşmeliYapımİşiFirmaEkle : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminSözleşmeliYapımİşiFirmaEkle()
        {
            InitializeComponent();
        }
        public static List<FirmaBilgileri> Firmalar = new List<FirmaBilgileri>();
        public static int clicksayisi;
        public static int birinciteklifsayac;
        public static int sayi2;
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
               
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİlkTeklifFirmalar where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        birinciteklifsayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                    
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİlkTeklifFirmalar where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        birinciteklifsayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }
            else
            {
                
                return;
            }
        }
        private void VeritabansızFirmaİsimTextBox()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                tableLayoutPanel1.Controls.Add(txt);
                txt.Name = "Firmaisim" + (i-1).ToString();

            }

        }
        private void VeriTabansızFirmaFiyatTextBox()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                tableLayoutPanel4.Controls.Add(txt);
                txt.Name = "firmafiyat" + (i - 1).ToString();
                txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
               
            }

        }
        private void VeriTabansızDateTimePicker()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                System.Windows.Forms.DateTimePicker date = new System.Windows.Forms.DateTimePicker();
                tableLayoutPanel6.Controls.Add(date);
                date.Name = "firmatarih" + (i - 1).ToString();

            }

        }
        private void VeriTabansızFirmaİsimLabel()
        {

            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                Label lb = new Label();
                tableLayoutPanel2.Controls.Add(lb);
                
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = i.ToString() + "." + "Firma";

            }
        }
        private void VeriTabansızFirmaFiyatLabel()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                Label lb = new Label();
                tableLayoutPanel3.Controls.Add(lb);
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = i.ToString() + "." + "Firma Teklif";

            }
        }
        private void VeriTabansızFirmaTeklifTarihiLabel()
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            sayi += 1;
            for (int i = 1; i < sayi; i++)
            {
                Label lb = new Label();
                tableLayoutPanel5.Controls.Add(lb);
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = i.ToString() + "." + "Teklif Tarihi";

            }

        }
        private void VeritabanlıFirmaİsimGetirTextBox()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    textBox1.Text = Firmalar.Count.ToString();
                    for (int i = 1; i < Convert.ToInt32(textBox1.Text)+1; i++)
                    {
                        System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                        tableLayoutPanel1.Controls.Add(txt);
                        txt.Name = "Firmaisim" + (i - 1).ToString();
                        txt.Text = Firmalar[i-1].Firmaisim;

                    }
                    button1.Visible = true;
                }
                
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                textBox1.Text = Firmalar.Count.ToString();
                for (int i = 1; i < Convert.ToInt32(textBox1.Text)+1; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel1.Controls.Add(txt);
                    txt.Name = "Firmaisim" + (i - 1).ToString();
                    txt.Text = Firmalar[i-1].Firmaisim;

                }
                button1.Visible = true;
            }

        }
        private void VeriTabanlıFirmaFiyatTextBox()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    textBox1.Text = Firmalar.Count.ToString();
                    for (int i = 1; i < Convert.ToInt32(textBox1.Text) + 1; i++)
                    {
                        System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                        tableLayoutPanel4.Controls.Add(txt);
                        txt.Name = "firmafiyat" + (i - 1).ToString();
                        txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                        txt.Text = Firmalar[i-1].Firmafiyat.ToString();

                    }
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                textBox1.Text = Firmalar.Count.ToString();
                for (int i = 1; i < Convert.ToInt32(textBox1.Text) + 1; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel4.Controls.Add(txt);
                    txt.Name = "firmafiyat" + (i-1).ToString();
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                    txt.Text = Firmalar[i-1].Firmafiyat.ToString();

                }
            }

        }
        private void VeriTabanlıDateTimePicker()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    textBox1.Text = Firmalar.Count.ToString();
                    for (int i = 1; i < Convert.ToInt32(textBox1.Text) + 1; i++)
                    {
                        System.Windows.Forms.DateTimePicker date = new System.Windows.Forms.DateTimePicker();
                        tableLayoutPanel6.Controls.Add(date);
                        date.Name = "firmatarih" + (i - 1).ToString();
                        date.Text = Firmalar[i-1].Teklifverilentarih.ToString();
                        date.Value = Firmalar[i-1].Teklifverilentarih;

                    }
                }
                
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                textBox1.Text = Firmalar.Count.ToString();
                for (int i = 1; i < Convert.ToInt32(textBox1.Text) + 1; i++)
                {
                    System.Windows.Forms.DateTimePicker date = new System.Windows.Forms.DateTimePicker();
                    tableLayoutPanel6.Controls.Add(date);
                    date.Name = "firmatarih" + (i - 1).ToString();
                    date.Text = Firmalar[i-1].Teklifverilentarih.ToString();
                    date.Value = Firmalar[i-1].Teklifverilentarih;

                }
            }

        }
        private void VeriTabanlıFirmaİsimLabel()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    for (int i = 1; i < Firmalar.Count+1; i++)
                    {
                        Label lb = new Label();
                        tableLayoutPanel2.Controls.Add(lb);

                        lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                        lb.Text = i.ToString() + "." + "Firma";

                    }

                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                for (int i = 1; i < Firmalar.Count; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel2.Controls.Add(lb);

                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = i.ToString() + "." + "Firma";

                }

            }
        }
        private void VeriTabanlıFirmaFiyatLabel()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    for (int i = 1; i < Firmalar.Count+1; i++)
                    {
                        Label lb = new Label();
                        tableLayoutPanel3.Controls.Add(lb);
                        lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                        lb.Text = i.ToString() + "." + "Firma Teklif";

                    }
                }
                
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                for (int i = 1; i < Firmalar.Count+1; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel3.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = i.ToString() + "." + "Firma Teklif";

                }
            }
        }
        private void VeriTabanlıFirmaTeklifTarihiLabel()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    for (int i = 1; i < Firmalar.Count+1; i++)
                    {
                        Label lb = new Label();
                        tableLayoutPanel5.Controls.Add(lb);
                        lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                        lb.Text = i.ToString() + "." + "Teklif Tarihi";

                    }
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 4)
            {
                for (int i = 1; i < Firmalar.Count+1; i++)
                {
                    Label lb = new Label();
                    tableLayoutPanel5.Controls.Add(lb);
                    lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                    lb.Text = i.ToString() + "." + "Teklif Tarihi";

                }
            }

        }
        private void SistemFirmaLabelGöster()
        {
           for (int i = 0; i < Firmalar.Count; i++)
            {
                Label lb = new Label();
                tableLayoutPanel7.Controls.Add(lb);
                lb.Font = new Font("Calibri", 11, FontStyle.Bold);
                lb.Text = Firmalar[i].Firmaisim.ToString();
                label2.Visible = true;
            }
        }
        private void FirmaBilgileriGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4 )
                {
                    try
                    {
                        tableLayoutPanel7.Controls.Clear();
                        Firmalar.Clear();
                        for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                        {
                            Firmalar.Add(new FirmaBilgileri()
                            {
                                Firmaisim = ((TextBox)tableLayoutPanel1.Controls["Firmaisim" + (i).ToString()]).Text,
                                Firmafiyat = Convert.ToDecimal(((TextBox)tableLayoutPanel4.Controls["firmafiyat" + (i).ToString()]).Text),
                                Teklifverilentarih = Convert.ToDateTime(((DateTimePicker)tableLayoutPanel6.Controls["firmatarih" + (i).ToString()]).Text)
                            });
                        }
                        SistemFirmaLabelGöster();
                        DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 4;
                        clicksayisi += 1;
                    }
                    catch (NullReferenceException)
                    {

                        XtraMessageBox.Show("Firma Sayısı ile Girdiğiniz Firma bilgileri arasında uyuşmazlık var");
                    }
                    
                    
                }
                else
                {
                    tableLayoutPanel7.Controls.Clear();
                    int sayi = Convert.ToInt32(textBox1.Text);
                    
                    Firmalar.Clear();

                    for (int i = 0; i < sayi; i++)
                    {
                        Firmalar.Add(new FirmaBilgileri()
                        {
                            Firmaisim = ((TextBox)tableLayoutPanel1.Controls["Firmaisim" + (i).ToString()]).Text,
                            Firmafiyat = Convert.ToDecimal(((TextBox)tableLayoutPanel4.Controls["firmafiyat" + (i).ToString()]).Text),
                            Teklifverilentarih = Convert.ToDateTime(((DateTimePicker)tableLayoutPanel6.Controls["firmatarih" + (i).ToString()]).Text)
                        });
                    }
                    SistemFirmaLabelGöster();
                    DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 4;
                    clicksayisi += 1;
                }
            }
            else
            {
                tableLayoutPanel7.Controls.Clear();
                int sayi = Convert.ToInt32(textBox1.Text);
                Firmalar.Clear();

                for (int i = 0; i < sayi; i++)
                {
                    Firmalar.Add(new FirmaBilgileri()
                    {
                        Firmaisim = ((TextBox)tableLayoutPanel1.Controls["Firmaisim" + (i).ToString()]).Text,
                        Firmafiyat = Convert.ToDecimal(((TextBox)tableLayoutPanel4.Controls["firmafiyat" + (i).ToString()]).Text),
                        Teklifverilentarih = Convert.ToDateTime(((DateTimePicker)tableLayoutPanel6.Controls["firmatarih" + (i).ToString()]).Text)
                    });
                }
                SistemFirmaLabelGöster();
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 4;
                clicksayisi += 1;
            }
            
        }
        void VeritabanıEkle()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut2 = new SqlCommand("Insert into DoğrudanTeminİlkTeklifFirmalar(SatınAlma_id,id,firmaisim,firmafiyat,firmateklif,satınalmasayac) VALUES (@SatınAlma_id,@id,@firma,@firmafiyat,@firmateklif,@satınalmasayac) ", baglan))
            {
                
                baglan.Open();
                foreach (var nesne in Firmalar)
                {
                    komut2.Parameters.Clear();
                    if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                    }
                    else
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);

                    }
                    komut2.Parameters.AddWithValue("@id", 2);
                    komut2.Parameters.AddWithValue("@satınalmasayac", 4);
                    komut2.Parameters.AddWithValue("@firma", nesne.Firmaisim);
                    komut2.Parameters.AddWithValue("@firmafiyat", nesne.Firmafiyat);
                    komut2.Parameters.AddWithValue("@firmateklif", nesne.Teklifverilentarih);
                    komut2.ExecuteNonQuery();
                }
                baglan.Close();
            }
        }
        void VeritabanıSil()
        {
            SqlConnection baglanti = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from DoğrudanTeminİlkTeklifFirmalar where id = @id and SatınAlma_id = @SatınAlma_id ",baglanti);
            komut.Parameters.AddWithValue("@id",2);
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
        private void BosGecilemezKontrol()
        {
            foreach (Control ctl in tableLayoutPanel4.Controls)
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
            foreach (Control ctl2 in tableLayoutPanel1.Controls)
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
            VeritabanıEkle();
        }
        private void GüncelleBosGecilemezKontrol()
        {
            foreach (Control ctl in tableLayoutPanel4.Controls)
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
            foreach (Control ctl2 in tableLayoutPanel1.Controls)
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
            VeritabanıSil();
            VeritabanıEkle();
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
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                XtraMessageBox.Show("Lütfen İlgili alanları Doldurunuz");
                
            }
            else
            {
                Firmalar.Clear();
                tableLayoutPanel1.Controls.Clear();
                tableLayoutPanel2.Controls.Clear();
                tableLayoutPanel3.Controls.Clear();
                tableLayoutPanel4.Controls.Clear();
                tableLayoutPanel5.Controls.Clear();
                tableLayoutPanel6.Controls.Clear();
                VeriTabansızFirmaFiyatTextBox();
                VeriTabansızDateTimePicker();
                VeriTabansızFirmaFiyatLabel();
                VeritabansızFirmaİsimTextBox();
                VeriTabansızFirmaTeklifTarihiLabel();
                VeriTabansızFirmaİsimLabel();
                button1.Visible = true;
            }
            
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (birinciteklifsayac == 4)
                {
                    GüncelleBosGecilemezKontrol();
                }
                else if (clicksayisi > 0)
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
        void verial()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true && birinciteklifsayac == 4)
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
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 3 )
            {
                Firmalar.Clear();
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
                }
            }
        }
        private void DoğrudanTeminSözleşmeliYapımİşiFirmaEkle_Load(object sender, EventArgs e)
        {
            SayacAl();
            verial();
            VeriTabanlıFirmaFiyatTextBox();
            VeriTabanlıFirmaFiyatLabel();
            VeritabanlıFirmaİsimGetirTextBox();
            VeriTabanlıFirmaİsimLabel();
            VeriTabanlıFirmaTeklifTarihiLabel();
            VeriTabanlıDateTimePicker();
            SistemFirmaLabelGöster();
            
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int uzunluk = 20;
            if (textBox1.Text != "")
            {
                if (int.Parse(textBox1.Text) > uzunluk)
                {
                    XtraMessageBox.Show("Belirlenen Maksimum Firma Sayısı :" + uzunluk + "dir");
                    simpleButton1.Enabled = false;
                }
                else
                {

                    simpleButton1.Enabled = true;
                }
 
               
            }
           
          
        }
        void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}