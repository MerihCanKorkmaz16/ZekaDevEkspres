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
    public partial class DoğrudanTeminPeriyodikFirmaEkleme : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPeriyodikFirmaEkleme()
        {
            InitializeComponent();
        }
        public static List<FirmaBilgileri> Firmalar = new List<FirmaBilgileri>();
        public static int clicksayisi;
        int firmaeklemesayac;
        private void FirmaİsimTextBox()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true && firmaeklemesayac == 2)
            {
                tableLayoutPanel1.Controls.Clear();
                int sayi = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel1.Controls.Add(txt);
                    txt.Name = "Firmaisim" + (i).ToString();
                    txt.Text = Firmalar[i].Firmaisim;
                    txt.Size = new Size(200, 24);
                }
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
            }
            else if (DoğrudanTeminPeriyodikBakımİsSecmeFormu.yarımkalansayac >= 2)
            {
                tableLayoutPanel1.Controls.Clear();

                int sayi = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel1.Controls.Add(txt);
                    txt.Name = "Firmaisim" + (i).ToString();
                    txt.Text = Firmalar[i].Firmaisim;
                    txt.Size = new Size(200, 24);
                }
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
            }
           
        }
        private void VeritabansızFirmaİsimTextBox()
        {
                tableLayoutPanel1.Controls.Clear();
                int sayi = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel1.Controls.Add(txt);
                    txt.Name = "Firmaisim" + (i).ToString();
                    txt.Size = new Size(200, 24);
                }
                label2.Visible = true;
                label3.Visible = true;
                button1.Visible = true;
           
        }
        void SayacAl()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminPeriyodikBakımİsSecmeFormu.conn))
                {
                    
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminPeriyodikFirmaEkleme where id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        firmaeklemesayac = Convert.ToInt32(dr[4]);
                        
                    }
                    dr.Close();
                    connn.Close();


                }
            }
            if (DoğrudanTeminPeriyodikBakımİsSecmeFormu.yarımkalansayac >= 2)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminPeriyodikBakımİsSecmeFormu.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminPeriyodikFirmaEkleme where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        firmaeklemesayac = Convert.ToInt32(dr[4]);

                    }
                    dr.Close();
                    connn.Close();

                }

            }
            else
            {
                return;
            }

        }
        void VeriAl()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true && firmaeklemesayac == 2)
            {
                
                Firmalar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikFirmaEkleme where id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        FirmaBilgileri firma = new FirmaBilgileri()
                        {
                            Firmafiyat = Convert.ToDecimal(reader[3]),
                            Firmaisim = Convert.ToString(reader[2]),

                        };
                        Firmalar.Add(firma);
                        textBox1.Text = Firmalar.Count.ToString();
                        button2.Enabled = true;
                    }
                    baglan.Close();
                    
                }
            }
            else if (DoğrudanTeminPeriyodikBakımİsSecmeFormu.yarımkalansayac >= 2)
            {
                Firmalar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikFirmaEkleme where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        FirmaBilgileri firma = new FirmaBilgileri()
                        {
                            Firmafiyat = Convert.ToDecimal(reader[3]),
                            Firmaisim = Convert.ToString(reader[2]),
                        };
                        Firmalar.Add(firma);
                    }
                    baglan.Close();
                    textBox1.Text = Firmalar.Count.ToString();
                }
            }
            textBox1.Text = Firmalar.Count.ToString();

        }
        private void FirmaBilgileriGetir()
        {
            try
            {
                Firmalar.Clear();
                for (int i = 0; i < Convert.ToInt32(textBox1.Text); i++)
                {
                    Firmalar.Add(new FirmaBilgileri()
                    {
                        Firmaisim = ((TextBox)tableLayoutPanel1.Controls["Firmaisim" + (i).ToString()]).Text,
                        Firmafiyat = Convert.ToDecimal(((TextBox)tableLayoutPanel2.Controls["firmafiyat" + (i).ToString()]).Text),
                    });
                }
            }
            catch (NullReferenceException)
            {
                XtraMessageBox.Show("Firma Sayısı ile Girdiğiniz Firma bilgileri arasında uyuşmazlık var");
            }

        }
        private void FirmaFiyatTextBox()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true && firmaeklemesayac ==2)
            {
                tableLayoutPanel2.Controls.Clear();

                int sayi = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel2.Controls.Add(txt);
                    txt.Name = "firmafiyat" + (i).ToString();
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                    txt.Text = Firmalar[i].Firmafiyat.ToString();
                    txt.Size = new Size(200, 24);
                }
            }
            else if (DoğrudanTeminPeriyodikBakımİsSecmeFormu.yarımkalansayac >= 2)
            {
               
                int sayi = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel2.Controls.Add(txt);
                    txt.Name = "firmafiyat" + (i).ToString();
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                    txt.Text = Firmalar[i].Firmafiyat.ToString();
                    txt.Size = new Size(200, 24);
                }
            }
            else
            {
                tableLayoutPanel2.Controls.Clear();
                int sayi = Convert.ToInt32(textBox1.Text);
                sayi += 1;
                for (int i = 1; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel2.Controls.Add(txt);
                    txt.Name = "firmafiyat" + (i - 1).ToString();
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                    txt.Size = new Size(200, 24);
                }
            }
           

        }
        private void VeritabansızFirmaFiyatTextBox()
        {
           
                tableLayoutPanel2.Controls.Clear();
                int sayi = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < sayi; i++)
                {
                    System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                    tableLayoutPanel2.Controls.Add(txt);
                    txt.Name = "firmafiyat" + (i).ToString();
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                    txt.Size = new Size(200, 24);
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
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            int sayi = 15;
            if (Convert.ToInt32(textBox1.Text) > sayi)
            {
                XtraMessageBox.Show("Maximum Firma Sayisi : " + sayi);
                textBox1.Text = "0";
                return;
            }
           
        }
        private void DoğrudanTeminPeriyodikFirmaEkleme_Load(object sender, EventArgs e)
        {
            SayacAl();
            VeriAl();
            FirmaİsimTextBox();
            FirmaFiyatTextBox();

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
        private void VeriTabanıEkleBosGecilemezKontrol()
        {
            foreach (Control ctl in tableLayoutPanel1.Controls)
            {
                if (ctl is TextBox)
                {
                    if (ctl.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Firma İsimleri Yerleri Doldurmayı unutmayınız");
                        return;
                    }

                }

            }
            foreach (Control ctl2 in tableLayoutPanel2.Controls)
            {
                if (ctl2 is TextBox)
                {
                    if (ctl2.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Firma Fiyatları Doldurmayı unutmayınız");
                        return;

                    }

                }

            }
            FirmaBilgileriGetir();
            VeritabanıEkle();
            clicksayisi += 1;
        }
        private void VeriTabanıGüncelleBosGecilemezKontrol()
        {
            foreach (Control ctl in tableLayoutPanel1.Controls)
            {
                if (ctl is TextBox)
                {
                    if (ctl.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Firma İsimleri Yerleri Doldurmayı unutmayınız");
                        return;
                    }

                }

            }
            foreach (Control ctl2 in tableLayoutPanel2.Controls)
            {
                if (ctl2 is TextBox)
                {
                    if (ctl2.Text == String.Empty)
                    {
                        XtraMessageBox.Show("Firma Fiyatları Doldurmayı unutmayınız");
                        return;

                    }

                }

            }
            FirmaBilgileriGetir();
            VeritabanıSil();
            VeritabanıEkle();
            
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                XtraMessageBox.Show("Firma Sayisi Boş Bırakılamaz.");
                return;
            }
            else
            {
                
                Firmalar.Clear();
                VeritabansızFirmaFiyatTextBox();
                VeritabansızFirmaİsimTextBox();
                button2.Enabled = false;
            }
           
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
            {
                if (firmaeklemesayac == 2)
                {
                    MessageBox.Show("1");
                    VeriTabanıGüncelleBosGecilemezKontrol();
                }
                else if (clicksayisi >0)
                {
                    MessageBox.Show("2");

                    VeriTabanıGüncelleBosGecilemezKontrol();
                }
                else
                {
                   VeriTabanıEkleBosGecilemezKontrol();
                }
            }
            else
            {
                if (clicksayisi > 0)
                {
                    

                    VeriTabanıGüncelleBosGecilemezKontrol();

                }
                else
                {
                    

                    VeriTabanıEkleBosGecilemezKontrol();
                }
            }
           
        }
        void VeritabanıEkle()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminPeriyodikBakımİsSecmeFormu.conn))
            using (SqlCommand komut2 = new SqlCommand("Insert into DoğrudanTeminPeriyodikFirmaEkleme(SatınAlma_id,id,firmaisim,firmafiyat,satınalmasayac) VALUES (@SatınAlma_id,@id,@firma,@firmafiyat,@satınalmasayac) ", baglan))
            {

                baglan.Open();
                foreach (var nesne in Firmalar)
                {
                    komut2.Parameters.Clear();
                    if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid);
                    }
                    else
                    {
                        komut2.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id);

                    }
                    komut2.Parameters.AddWithValue("@id", 2);
                    komut2.Parameters.AddWithValue("@satınalmasayac", 2);
                    komut2.Parameters.AddWithValue("@firma", nesne.Firmaisim);
                    komut2.Parameters.AddWithValue("@firmafiyat", nesne.Firmafiyat);
                    komut2.ExecuteNonQuery();
                   
                }
                baglan.Close();
                button2.Enabled = true;
                clicksayisi += 1;
                DoğrudanTeminPeriyodikBakımİsSecmeFormu.yarımkalansayac = 2;
            }
            
        }
        void VeritabanıSil()
        {
            using (SqlConnection baglanti = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn)
)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Delete from DoğrudanTeminPeriyodikFirmaEkleme where id = @id and SatınAlma_id = @SatınAlma_id ", baglanti);
                komut.Parameters.AddWithValue("@id", 2);
                if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id);
                }
                komut.ExecuteNonQuery();
                baglanti.Close();
            }
           
        }
        
    }
}