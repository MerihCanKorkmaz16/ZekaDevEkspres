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

namespace ZekaDevEkspresDeneme
{
   
    public partial class DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama : DevExpress.XtraEditors.XtraForm
    {
       
        public DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Sözleşme2.docx";
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Sözleşme.docx";
        public static List<FirmaBilgileri> Firmalar = new List<FirmaBilgileri>();
        public static string tercihedilenfirma;
        public static string vergino;
        public static string telno;
        public static string faxno;
        public static string eposta;
        public static string adres;
        public static DateTime sözlesmebaslamatarihi;
        public static DateTime sözlesmebitistarihi;
        public static bool sözlesmetaslagıackapa;
        public static bool idariveteknikackapa;
        public static int firmasecmesayac;
        byte[] VeriTabanindenGelenBytes;
        Double Süre;
        int ay;
        int clicksayisi;
        void FirmaBilgileriVeriAl()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true  )
            {
                Firmalar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikFirmaEkleme where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
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
                }
            }
            else
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
                }
            }
           


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
                    komut.CommandText = ("select * from  DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma where id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        firmasecmesayac = Convert.ToInt32(dr[9]);

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
                    komut.CommandText = ("select * from  DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        firmasecmesayac = Convert.ToInt32(dr[8]);

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
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true && firmasecmesayac == 3)
            {
                Firmalar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        tercihedilenfirma = reader[4].ToString();
                        sözlesmetaslagıackapa = Convert.ToBoolean(reader[5]);
                        if (sözlesmetaslagıackapa == true)
                        {
                            sözlesmebaslamatarihi = Convert.ToDateTime(reader[6]);
                            sözlesmebitistarihi = Convert.ToDateTime(reader[7]);
                            checkBox1.Checked = true;
                            comboBox1.Text = reader[2].ToString();
                            Süre = Convert.ToDouble(reader[3]);
                            VeriTabanindenGelenBytes = (byte[])reader["SözlesmeBelgesi"];
                            if (VeriTabanindenGelenBytes != null)
                            {
                                label12.Text = "Sözlesme Taslağı Başarıyla Hazırlandı";
                            }
                            
                        }

                    }
                    reader.Close();
                    baglan.Close();
                    label2.Visible = true;
                    label2.Text = tercihedilenfirma;
                  
                }

            }
            else if (DoğrudanTeminPeriyodikBakımİsSecmeFormu.yarımkalansayac >= 2)
            {
                Firmalar.Clear();
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        tercihedilenfirma = reader[4].ToString();
                        label2.Text = tercihedilenfirma;
                        sözlesmetaslagıackapa = Convert.ToBoolean(reader[5]);
                        if (sözlesmetaslagıackapa == true)
                        {
                            sözlesmebaslamatarihi = Convert.ToDateTime(reader[6]);
                            sözlesmebitistarihi = Convert.ToDateTime(reader[7]);
                            checkBox1.Checked = true;
                            comboBox1.Text = reader[2].ToString();
                            Süre = Convert.ToDouble(reader[3]);
                            VeriTabanindenGelenBytes = (byte[])reader["SözlesmeBelgesi"];
                            if (VeriTabanindenGelenBytes != null)
                            {
                                label12.Text = "Sözlesme Taslağı Başarıyla Hazırlandı";
                            }

                        }
                        
                    }
                    reader.Close();
                    baglan.Close();
                }

            }
        }
        private void FirmaİsimCheckBox()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true && firmasecmesayac == 3 )
            {
                tableLayoutPanel1.Controls.Clear();
                for (int i = 0; i < Firmalar.Count; i++)
                {
                    System.Windows.Forms.RadioButton chck = new System.Windows.Forms.RadioButton();
                    tableLayoutPanel1.Controls.Add(chck);
                    chck.Name = "Firmaisim" + (i).ToString();
                    chck.Size = new Size(400, 24);
                    chck.Text = Firmalar[i].Firmaisim;
                    chck.CheckedChanged += new EventHandler(Chk_Fund_CheckedChange);
                }
            }
            tableLayoutPanel1.Controls.Clear();
           for (int i = 0; i < Firmalar.Count; i++)
            {
                System.Windows.Forms.RadioButton chck = new System.Windows.Forms.RadioButton();
                tableLayoutPanel1.Controls.Add(chck);
                chck.Name = "Firmaisim" + (i).ToString();
                chck.Size = new Size(400, 24);
                chck.Text = Firmalar[i].Firmaisim;
                chck.CheckedChanged += new EventHandler(Chk_Fund_CheckedChange);
            }
            

        }
        void FirmaHavuzAdresGetir()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikFirmaHavuzu where FirmaAdı = '" + label2.Text + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    using (SqlConnection baglan2 = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                    using (SqlCommand komut2 = new SqlCommand("select * from DoğrudanTeminPeriyodikFirmaHavuzu where FirmaAdı = '" + label2.Text + "' ", baglan2))
                    {
                        baglan2.Open();
                        SqlDataReader reader2 = komut2.ExecuteReader();
                        while (reader2.Read())
                        {

                            verginotext.Text = reader2[1].ToString();
                            adrestext.Text = reader2[2].ToString();
                            telnotext1.Text = reader2[3].ToString();
                            faxnotext1.Text = reader2[4].ToString();
                            epostatext.Text = reader2[5].ToString();


                        }
                        verginotext.Enabled = false;
                        adrestext.Enabled = false;
                        telnotext1.Enabled = false;
                        faxnotext1.Enabled = false;
                        epostatext.Enabled = false;
                        checkBox2.Visible = true;
                        baglan2.Close();
                        groupBox3.Enabled = true;
                        button3.Visible = false;
                        checkBox3.Enabled = true;
                    }

                }
                else
                {
                    verginotext.Enabled = true;
                    adrestext.Enabled = true;
                    telnotext1.Enabled = true;
                    faxnotext1.Enabled = true;
                    epostatext.Enabled = true;
                    button3.Visible = true;
                    checkBox2.Visible = false;
                    groupBox3.Enabled = true;
                    checkBox3.Enabled = false;
                }
                baglan.Close();
            }

           
        }
        void VeritabanıFirmaHavuzuTablosuDoldur()
        {

            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminPeriyodikFirmaHavuzu (FirmaAdı,VergiDairesiVeNumarası,Adres,TelefonNumarası,FaxNumarası,Eposta) VALUES (@FirmaAdı,@VergiDairesiVeNumarası,@Adres,@TelefonNumarası,@FaxNumarası,@Eposta)", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@FirmaAdı", label2.Text);
                komut.Parameters.AddWithValue("@VergiDairesiVeNumarası", verginotext.Text);
                komut.Parameters.AddWithValue("@Adres", adrestext.Text);
                komut.Parameters.AddWithValue("@TelefonNumarası", telnotext1.Text);
                komut.Parameters.AddWithValue("@FaxNumarası", faxnotext1.Text) ;
                komut.Parameters.AddWithValue("@Eposta", epostatext.Text);
                
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                label7.Visible = true;
                label7.Text = "Bilgiler Başarıyla Kaydedildi.";
                checkBox1.Enabled = true;
            }
        }
        private void DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama_Load(object sender, EventArgs e)
        {
            SayacAl();
            VeriAl();
            FirmaBilgileriVeriAl();
            FirmaİsimCheckBox();
        }
        public void Chk_Fund_CheckedChange(object sender, EventArgs e)
        {
            for (int i = 0; i < Firmalar.Count; i++)
            {
                var chck = ((RadioButton)tableLayoutPanel1.Controls["Firmaisim" + (i).ToString()]) as RadioButton;
                if (chck.Checked)
                {
                    verginotext.Clear();
                    adrestext.Clear();
                    telnotext1.Clear();
                    faxnotext1.Clear();
                    epostatext.Clear();
                    label2.Visible = true;
                    label2.Text = chck.Text;
                    tercihedilenfirma = chck.Text;
                    FirmaHavuzAdresGetir();
                    vergino = verginotext.Text;
                    adres = adrestext.Text;
                    telno = telnotext1.Text;
                    faxno = faxnotext1.Text;
                    eposta = epostatext.Text;
                    label7.Visible = false;
                    checkBox3.Enabled = true;
                    button2.Visible = false;
                    checkBox1.Enabled = true;
                    groupBox5.Enabled = true;
                }
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox4.Visible = true;
                sözlesmetaslagıackapa = true;
                button4.Enabled = false;
            }
            else
            {
                groupBox4.Visible = false;
                sözlesmetaslagıackapa = false;
                button4.Enabled = true;

            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (label2.Text == "label2")
            {
                XtraMessageBox.Show("Tercih Ettiğiniz Firmayı Seçiniz");
                return;
            }
            else
            {
                if (comboBox1.Text == "")
                {
                    XtraMessageBox.Show("Aylık Bakım Süresini Girmeyi unutmayınız");
                    return;
                }
                else
                {
                    if (dateTimePicker1.CustomFormat == " " || dateTimePicker2.CustomFormat == " ")
                    {
                        XtraMessageBox.Show("Tarihleri eksiksiz giriniz.");
                        return;
                    }
                    else
                    {

                        if (dateTimePicker1.Value > dateTimePicker2.Value)
                        {
                            XtraMessageBox.Show("Sözlesme başlama tarihi,bitiş tarihinden küçük olamaz");
                            return;
                        }
                        else
                        {

                            sözlesmebaslamatarihi = dateTimePicker1.Value;
                            sözlesmebitistarihi = dateTimePicker2.Value;
                            SüreHesapla();
                            MessageBox.Show(Süre.ToString());
                            DoğrudanTeminPeriyodikSözlesmeTaslağı sözlesme = new DoğrudanTeminPeriyodikSözlesmeTaslağı(this);
                            sözlesme.ShowDialog();
                        }

                    }
                }
               
            }
        }
        void SüreHesapla()
        {
            if (comboBox1.Text == "Aylık")
            {
                ay = 1;
            }
            else if (comboBox1.Text == "3 Aylık")
            {
                ay = 3;
            }
            else if (comboBox1.Text == "Yıllık")
            {
                ay = 12;
            }
            Süre = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).TotalDays;
            if (Süre >= 30)
            {
                Süre = (Süre / 30);
                Süre = (Süre / ay);
                Süre = Convert.ToInt32(Süre);
            }

        }
        void VeritabanıisEkleTablosuGüncelle()
        {

            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("update DoğrudanTeminPeriyodikFirmaHavuzu set VergiDairesiVeNumarası = @VergiDairesiVeNumarası, Adres = @Adres, TelefonNumarası = @TelefonNumarası,FaxNumarası = @FaxNumarası,Eposta = @Eposta where FirmaAdı = @FirmaAdı", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@VergiDairesiVeNumarası", verginotext.Text);
                komut.Parameters.AddWithValue("@adres", adrestext.Text);
                komut.Parameters.AddWithValue("@TelefonNumarası", telnotext1.Text);
                komut.Parameters.AddWithValue("@FaxNumarası", faxnotext1.Text);
                komut.Parameters.AddWithValue("@Eposta", epostatext.Text);
                komut.Parameters.AddWithValue("@FirmaAdı",label2.Text);
                
                label7.Visible = true;
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();


            }
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                verginotext.Enabled = true;
                adrestext.Enabled = true;
                telnotext1.Enabled = true;
                faxnotext1.Enabled = true;
                epostatext.Enabled = true;
                button2.Visible = true;
            }
            else
            {
                verginotext.Enabled = false;
                adrestext.Enabled = false;
                telnotext1.Enabled = false;
                faxnotext1.Enabled = false;
                epostatext.Enabled = false;
                button2.Visible = false;

            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (verginotext.Text == "" || adrestext.Text == "" || telnotext1.MaskFull == false|| faxnotext1.Text == "" || epostatext.Text == "")
            {
                XtraMessageBox.Show("Boş Alan Bırakılamaz");
            }
            else
            {
                VeritabanıisEkleTablosuGüncelle();
            }
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            if (verginotext.Text == "" || adrestext.Text == "" || telnotext1.MaskFull == false || faxnotext1.MaskFull == false || epostatext.Text == "")
            {
                XtraMessageBox.Show("Boş Alan Bırakılamaz");
            }
            else
            {
                VeritabanıFirmaHavuzuTablosuDoldur();
            }
        }
        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }
        void VeritabanıEkle()
        {
            if (sözlesmetaslagıackapa == true)
            {
                using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {

                    SqlCommand komut = new SqlCommand("insert into DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma (Süre,SatınAlma_id,BakımSüresi,id,tercihedilenfirma,SözlesmeTaslagı,SözlesmeBaslangıcTarihi,SözlesmeBitisTarihi,satınalmasayac,SözlesmeBelgesi) values (@Süre,@SatınAlma_id,@BakımSüresi,@id,@tercihedilenfirma,@SözlesmeTaslagı,@SözlesmeBaslangıcTarihi,@SözlesmeBitisTarihi,@satınalmasayac,@SözlesmeBelgesi)", sqlConnection);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", 2);
                    if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                    {
                        komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid);

                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id);

                    }
                    komut.Parameters.AddWithValue("SözlesmeBelgesi", File.ReadAllBytes(path1));
                    komut.Parameters.AddWithValue("@tercihedilenfirma", label2.Text);
                    komut.Parameters.AddWithValue("@SözlesmeTaslagı", sözlesmetaslagıackapa);
                    komut.Parameters.AddWithValue("@SözlesmeBaslangıcTarihi", sözlesmebaslamatarihi);
                    komut.Parameters.AddWithValue("@SözlesmeBitisTarihi", sözlesmebitistarihi);
                    komut.Parameters.AddWithValue("@satınalmasayac", 3);
                    komut.Parameters.AddWithValue("@BakımSüresi", comboBox1.Text);
                    komut.Parameters.AddWithValue("@Süre", Süre);

                    sqlConnection.Open();
                    komut.ExecuteNonQuery();
                    sqlConnection.Close();
                    clicksayisi += 1;

                }

            }
            else
            {
                using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {

                    SqlCommand komut = new SqlCommand("insert into DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma (SatınAlma_id,id,SözlesmeTaslagı,tercihedilenfirma,satınalmasayac) values (@SatınAlma_id,@id,@SözlesmeTaslagı,@tercihedilenfirma,@satınalmasayac)", sqlConnection);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", 2);
                    if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                    {
                        komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid);

                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id);

                    }
                    komut.Parameters.AddWithValue("@tercihedilenfirma", label2.Text);
                    komut.Parameters.AddWithValue("@satınalmasayac", 3);
                    komut.Parameters.AddWithValue("@SözlesmeTaslagı", sözlesmetaslagıackapa);
                    sqlConnection.Open();
                    komut.ExecuteNonQuery();
                    sqlConnection.Close();
                    clicksayisi += 1;

                }

            }
        }
        void VeritabanıGüncelle()
        {
            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("update DoğrudanTeminFirmaSecmeVeSözlesmeOlusturma set  Süre=@Süre, BakımSüresi = @BakımSüresi ,tercihedilenfirma = @tercihedilenfirma,SözlesmeTaslagı = @SözlesmeTaslagı,SözlesmeBelgesi = @SözlesmeBelgesi,SözlesmeBaslangıcTarihi = @SözlesmeBaslangıcTarihi ,SözlesmeBitisTarihi=@SözlesmeBitisTarihi) where SatınAlma_id = @SatınAlma_id and id = @id ", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikBakımİsSecmeFormu.SatınAlma_id);
                komut.Parameters.AddWithValue("@tercihedilenfirma", label2.Text);
                komut.Parameters.AddWithValue("SözlesmeBelgesi", File.ReadAllBytes(path1));
                komut.Parameters.AddWithValue("@SözlesmeTaslagı", sözlesmetaslagıackapa);
                komut.Parameters.AddWithValue("@SözlesmeBaslangıcTarihi", sözlesmebaslamatarihi);
                komut.Parameters.AddWithValue("@SözlesmeBitisTarihi", sözlesmebitistarihi);
                komut.Parameters.AddWithValue("@BakımSüresi",comboBox1.Text);
                komut.Parameters.AddWithValue("@Süre", Süre);
                

                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (groupBox4.Visible == true && label12.Text == "Sözleşme Taslağı Hazırlanmadı Hazırlanmadı")
            {
                XtraMessageBox.Show("Sözleşme Dosyasını Oluşturunuz.");
                return;
            }
            else
            {
                if (clicksayisi > 0)
                    {
                       
                        VeritabanıGüncelle();
                    }
               else
                    {
                       
                        VeritabanıEkle();
                    }
            }
        }
        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                idariveteknikackapa = true;
                idarigrupbox.Visible = true;
            }
            else
            {
                idariveteknikackapa = false;
                idarigrupbox.Visible = false;
            }
        }
       

       
    }
}