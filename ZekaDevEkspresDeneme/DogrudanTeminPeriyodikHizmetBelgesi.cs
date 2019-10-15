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
    public partial class DogrudanTeminPeriyodikServisBakımFormu : DevExpress.XtraEditors.XtraForm
    {
        public DogrudanTeminPeriyodikServisBakımFormu()
        {
            InitializeComponent();
        }
        int sayi = 8;
        public static string servisformu;
        public static int islemsırası;
        int kayitsayisi;
        private void VeritabansızServisBakımFormuLabel()
        {
            tableLayoutPanel1.Controls.Clear();

            for (int i = 1; i < sayi+1; i++)
            {
                System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
                tableLayoutPanel1.Controls.Add(lbl);
                lbl.Size = new Size(200, 24);
                lbl.Text = i.ToString() + "." + "Servis Formu :";

            }


        }
        void VisibleAyarlama()
        {
            if (sayi == 1)
            {
                label1.Visible = true;
                dateTimePicker1.Visible = true;
                button1.Visible = true;
            }
            else if(sayi == 2)
            {
                label1.Visible = true;
                label2.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;

            }
            else if (sayi == 3)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;

            }
            else if (sayi == 4)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
            else if (sayi == 5)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;

            }
            else if (sayi == 6)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;

            }
            else if (sayi == 7)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;

            }
            else if (sayi == 8)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = true;
                dateTimePicker8.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;


            }
            else if (sayi == 9)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;



            }
            else if (sayi == 10)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                dateTimePicker10.Visible = true;

                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;


            }
            else if (sayi == 11)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                dateTimePicker10.Visible = true;
                dateTimePicker11.Visible = true;

                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;


            }
            else if (sayi == 12)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker6.Visible = true;
                dateTimePicker7.Visible = true;
                dateTimePicker8.Visible = true;
                dateTimePicker9.Visible = true;
                dateTimePicker10.Visible = true;
                dateTimePicker11.Visible = true;
                dateTimePicker12.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
                button10.Visible = true;
                button11.Visible = true;
                button12.Visible = true;


            }
            else
            {
                XtraMessageBox.Show("Hata");
                return;
            }

        }
        void DoldurulanKısmıAlma()
        {

           
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM DoğrudanTeminPeriyodikServisFonu", baglan))
            {
                baglan.Open();
                
                kayitsayisi = Convert.ToInt32(komut.ExecuteScalar());
                baglan.Close();
                
               
            }


        }
        void BirinciKısımVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikServisFonu where İslemSırası = '" + 1 + "' and SatınAlma_id = '" + 0 + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    dateTimePicker1.Text = reader[5].ToString();
                    button1.Text = "1.Servis Formu Güncelle";
                    label1.Text = "1.Servis Formu Yüklendi✔";
                    label1.ForeColor = Color.Green;
                }
                baglan.Close();
            }


        }
        void İkinciKısımVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikServisFonu where İslemSırası = '" + 2 + "' and SatınAlma_id = '" + 0 + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    dateTimePicker2.Text = reader[5].ToString();
                    button2.Text = "2.Servis Formu Güncelle";
                    label2.Text = "2.Servis Formu Yüklendi✔";
                    label2.ForeColor = Color.Green;
                    button2.Enabled = true;
                    dateTimePicker2.Enabled = true;
                }
                baglan.Close();
            }


        }
        void ÜcüncüKısımVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikServisFonu where İslemSırası = '" + 3 + "' and SatınAlma_id = '" + 0 + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    dateTimePicker3.Text = reader[5].ToString();
                    button3.Text = "3.Servis Formu Güncelle";
                    label3.Text = "3.Servis Formu Yüklendi✔";
                    label3.ForeColor = Color.Green;
                    button3.Enabled = true;
                    dateTimePicker3.Enabled = true;
                }
                baglan.Close();
            }


        }
        void DördüncüKısımVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikServisFonu where İslemSırası = '" + 4 + "' and SatınAlma_id = '" + 0 + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    dateTimePicker4.Text = reader[5].ToString();
                    button4.Text = "4.Servis Formu Güncelle";
                    label4.Text = "4.Servis Formu Yüklendi✔";
                    label4.ForeColor = Color.Green;
                    button4.Enabled = true;
                    dateTimePicker4.Enabled = true;
                }
                baglan.Close();
            }


        }
        void BeşinciKısımVeriAl()
        {
            using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminPeriyodikServisFonu where İslemSırası = '" + 5 + "' and SatınAlma_id = '" + 0 + "' ", baglan))
            {
                baglan.Open();
                SqlDataReader reader = komut.ExecuteReader();
                while (reader.Read())
                {
                    dateTimePicker5.Text = reader[5].ToString();
                    button5.Text = "5.Servis Formu Güncelle";
                    label5.Text = "5.Servis Formu Yüklendi✔";
                    label5.ForeColor = Color.Green;
                    button5.Enabled = true;
                    dateTimePicker5.Enabled = true;
                }
                baglan.Close();
            }


        }
        void ButtonAktifEtme()
        {
            if (kayitsayisi == 1)
            {
                button2.Enabled = true;
                dateTimePicker2.Enabled = true;

            }
            else if (kayitsayisi == 2)
            {
                button3.Enabled = true;
                dateTimePicker3.Enabled = true;
            }
            else if (kayitsayisi == 3)
            {
                button4.Enabled = true;
                dateTimePicker4.Enabled = true;
            }
            else if (kayitsayisi == 4)
            {
                button5.Enabled = true;
                dateTimePicker5.Enabled = true;
            }
            else if (kayitsayisi == 5)
            {
                button6.Enabled = true;
                dateTimePicker6.Enabled = true;
            }
        }
        void DökümanVeritabanıYükle()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {

                    SqlCommand komut = new SqlCommand("insert into DoğrudanTeminPeriyodikServisFonu (SatınAlma_id,id,İslemSırası,Dosya,İslemTarihi) values (@SatınAlma_id ,@id,@İslemSırası,@Dosya,@İslemTarihi )", sqlConnection);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@Dosya", File.ReadAllBytes(servisformu));
                    komut.Parameters.AddWithValue("@id", 2);
                    komut.Parameters.AddWithValue("@İslemSırası", islemsırası);
                    if (label1.Text == "1.Servis Formu Yüklenmedi." && button1.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker1.Value);

                    }
                    else if (label2.Text == "2.Servis Formu Yüklenmedi." && button2.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker2.Value);

                    }
                    else if (label3.Text == "3.Servis Formu Yüklenmedi." && button3.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker3.Value);

                    }
                    else if (label4.Text == "4.Servis Formu Yüklenmedi." && button4.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker4.Value);

                    }
                    else if (label5.Text == "5.Servis Formu Yüklenmedi." && button5.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker5.Value);

                    }
                    else if (label6.Text == "6.Servis Formu Yüklenmedi." && button6.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker6.Value);

                    }
                    else if (label7.Text == "7.Servis Formu Yüklenmedi." && button7.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker7.Value);

                    }
                    else if (label8.Text == "8.Servis Formu Yüklenmedi." && button8.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker8.Value);

                    }
                    else if (label9.Text == "9.Servis Formu Yüklenmedi." && button9.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker9.Value);

                    }
                    else if (label10.Text == "10.Servis Formu Yüklenmedi." && button10.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker10.Value);

                    }
                    else if (label11.Text == "11.Servis Formu Yüklenmedi." && button11.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker11.Value);

                    }
                    else if (label12.Text == "12.Servis Formu Yüklenmedi." && button12.Enabled == true)
                    {
                        komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker12.Value);

                    }
                    komut.Parameters.AddWithValue("@SatınAlma_id", 0);

                    sqlConnection.Open();
                    komut.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (System.ArgumentException)
            {

                XtraMessageBox.Show("Lütfen Yüklenicek Servis Formunu Seçiniz");
            }
            
        }
        void DökümanVeritabanıGüncelle()
        {
            try
            {
                using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {

                    SqlCommand komut = new SqlCommand("update from DoğrudanTeminPeriyodikServisFonu set Dosya= @Dosya, İslemTarihi=@İslemTarihi) where SatınAlma_id = @SatınAlma_id and İslemSırası = @İslemSırası");
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@Dosya", File.ReadAllBytes(servisformu));
                    komut.Parameters.AddWithValue("@İslemSırası", 1);
                    komut.Parameters.AddWithValue("@İslemTarihi", dateTimePicker1.Value);
                    komut.Parameters.AddWithValue("@SatınAlma_id", 0);

                    sqlConnection.Open();
                    komut.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (System.ArgumentException)
            {

                XtraMessageBox.Show("Lütfen Yüklenicek Servis Formunu Seçiniz");
            }

        }
        private void DogrudanTeminPeriyodikHizmetBelgesi_Load(object sender, EventArgs e)
        {
            DoldurulanKısmıAlma();
            ButtonAktifEtme();
            BirinciKısımVeriAl();
            İkinciKısımVeriAl();
            ÜcüncüKısımVeriAl();
            DördüncüKısımVeriAl();
            BeşinciKısımVeriAl();
            VeritabansızServisBakımFormuLabel();
            VisibleAyarlama();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.CustomFormat== " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 1;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label1.Text = "1.Servis Formu Yüklendi✔";
                    label1.ForeColor = Color.Green;
                    dateTimePicker2.Enabled = true;
                    button2.Enabled = true;
                }
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
        private void DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker4.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker5.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker6.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker7_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker7.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker8_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker8.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker9_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker9.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker10_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker10.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker11_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker11.CustomFormat = "dd/MM/yyyy";
        }
        private void DateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker12.CustomFormat = "dd/MM/yyyy";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 2;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label2.Text = "3.Servis Formu Yüklendi✔";
                    label2.ForeColor = Color.Green;
                    dateTimePicker3.Enabled = true;
                    button3.Enabled = true;
                }
            }

            
        }
        private void Button3_Click(object sender, EventArgs e)
        {

            if (dateTimePicker3.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 3;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label3.Text = "3.Servis Formu Yüklendi✔";
                    label3.ForeColor = Color.Green;
                    dateTimePicker4.Enabled = true;
                    button4.Enabled = true;
                }
            }
            
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            if (dateTimePicker4.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 4;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label4.Text = "4.Servis Formu Yüklendi✔";
                    label4.ForeColor = Color.Green;
                    dateTimePicker5.Enabled = true;
                    button5.Enabled = true;
                }
            }
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            if (dateTimePicker5.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 5;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label5.Text = "5.Servis Formu Yüklendi✔";
                    label5.ForeColor = Color.Green;
                    dateTimePicker6.Enabled = true;
                    button6.Enabled = true;
                }
            }
        }
        private void Button6_Click(object sender, EventArgs e)
        {
            if (dateTimePicker6.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 6;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label6.Text = "6.Servis Formu Yüklendi✔";
                    label6.ForeColor = Color.Green;
                    dateTimePicker7.Enabled = true;
                    button7.Enabled = true;
                }
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            if (dateTimePicker7.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 7;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label7.Text = "7.Servis Formu Yüklendi✔";
                    label7.ForeColor = Color.Green;
                    dateTimePicker8.Enabled = true;
                    button8.Enabled = true;
                }
            }
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            if (dateTimePicker8.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 8;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label8.Text = "8.Servis Formu Yüklendi✔";
                    label8.ForeColor = Color.Green;
                    dateTimePicker8.Enabled = true;
                    button8.Enabled = true;
                }
            }
        }
        private void Button9_Click(object sender, EventArgs e)
        {
            if (dateTimePicker9.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 9;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label9.Text = "9.Servis Formu Yüklendi✔";
                    label9.ForeColor = Color.Green;
                    dateTimePicker10.Enabled = true;
                    button10.Enabled = true;
                }
            }
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            if (dateTimePicker10.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 10;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label10.Text = "10.Servis Formu Yüklendi✔";
                    label10.ForeColor = Color.Green;
                    dateTimePicker11.Enabled = true;
                    button11.Enabled = true;
                }
            }
        }
        private void Button11_Click(object sender, EventArgs e)
        {
            if (dateTimePicker11.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 11;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label11.Text = "11.Servis Formu Yüklendi✔";
                    label11.ForeColor = Color.Green;
                    dateTimePicker12.Enabled = true;
                    button12.Enabled = true;
                }
            }
        }
        private void Button12_Click(object sender, EventArgs e)
        {
            if (dateTimePicker12.CustomFormat == " ")
            {
                XtraMessageBox.Show("Tarih Alanı Boş Bırakılamaz");
                return;
            }
            else
            {
                islemsırası = 12;
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.ShowDialog();
                openFileDialog1.Title = "Servis Formu Yükleyiniz";
                if (openFileDialog1.FileName != "")
                {
                    servisformu = openFileDialog1.FileName;
                    DökümanVeritabanıYükle();
                    label12.Text = "12.Servis Formu Yüklendi✔";
                    label2.ForeColor = Color.Green;

                }
            }
        }
    }
}