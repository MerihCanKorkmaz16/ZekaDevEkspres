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
    public partial class DoğrudanTeminPeriyodikBakımİsSecmeFormu : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPeriyodikBakımİsSecmeFormu()
        {
            InitializeComponent();
            Random rnd = new Random();
            SatınAlma_id = rnd.Next(1000000);
        }
        public const string conn = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ZekaDenemeProje1;Integrated Security=True";
        public static int SatınAlma_id;
        int clicksayisi;
        public static int yarımkalansayac;
        public static int iseklemesayac;
        
        void VerileriGetir()
        {
            using (SqlConnection baglanti = new SqlConnection(conn))
            {
                SqlCommand komut = new SqlCommand();
                komut.CommandText = "SELECT * FROM DoğrudanTeminPeriyodikİşler ORDER BY isAdi";
                komut.Connection = baglanti;
                komut.CommandType = CommandType.Text;

                SqlDataReader dr;
                baglanti.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["isAdi"]);
                }
                baglanti.Close();
            }
           
            
        }
        void isEkle()
        {
            
            using (var sqlConnection = new SqlConnection(conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminPeriyodikİşler (isAdi) values (@isAdi)", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isAdi", textBox1.Text);
               
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                label4.Visible = true;
                label4.Text = "Değişiklikler Başarıyla Uygulandı.";
                label4.ForeColor = Color.Green;
                groupBox1.Enabled = true;
                
            }
        }
        void SayacAl()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
            {
                using (SqlConnection connn = new SqlConnection(conn))
                {

                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminPeriyodikİsEklemeTablosu where id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        iseklemesayac = Convert.ToInt32(dr[3]);
                    }
                    dr.Close();
                    connn.Close();


                }
            }
            if (yarımkalansayac > 0)
            {
                using (SqlConnection connn = new SqlConnection(conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminİdariVeTeknikŞartname where id = '" + 2 + "' and SatınAlma_id = '" + SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        iseklemesayac = Convert.ToInt32(dr[3]);

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
        void VeritabanıisEkleTablosuDoldur()
        {
            using (var sqlConnection = new SqlConnection(conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminPeriyodikİsEklemeTablosu (SatınAlma_id,id,isAdi,satınalmasayac) values (@SatınAlma_id,@id,@isAdi,@satınalmasayac)", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", 2);
                if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlma_id);

                }
                komut.Parameters.AddWithValue("@isAdi", comboBox1.Text);
                komut.Parameters.AddWithValue("@satınalmasayac", 1);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                clicksayisi += 1;
                yarımkalansayac = 1;
            }
        }
        void VeritabanıisEkleTablosuGüncelle()
        {
          using (var sqlConnection = new SqlConnection(conn))
                {

                    SqlCommand komut = new SqlCommand("update DoğrudanTeminPeriyodikİsEklemeTablosu set isAdi = @isAdi  where id = @id and SatınAlma_id = @SatınAlma_id", sqlConnection);
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@id", 2);
                    if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                    {
                        komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid);
                    }
                    else
                    {
                        komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlma_id);

                    }
                    komut.Parameters.AddWithValue("@isAdi", comboBox1.Text);

                    sqlConnection.Open();
                    komut.ExecuteNonQuery();
                    sqlConnection.Close();


                }
        }
        void KaydedilmişVerileriGetir()
        {
            if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
            {
                using (SqlConnection connn = new SqlConnection(conn))
                {
                    
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminPeriyodikİsEklemeTablosu where id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        comboBox1.Text = dr[2].ToString();
                    }
                    dr.Close();
                    connn.Close();
                    

                }
            }
            if (yarımkalansayac > 0)
            {
                using (SqlConnection connn = new SqlConnection(conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminİdariVeTeknikŞartname where id = '" + 2 + "' and SatınAlma_id = '" + SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        comboBox1.Text = dr[2].ToString();

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
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                groupBox2.Visible = true;
                groupBox1.Enabled = false;
            }
            else
            {
                groupBox2.Visible = false;
                groupBox1.Enabled = true;
            }
        }
        private void DoğrudanTeminPeriyodikBakımİsSecmeFormu_Load(object sender, EventArgs e)
        {
            SayacAl();
            VerileriGetir();
            KaydedilmişVerileriGetir();
        }
        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (groupBox2.Visible == true)
            {
                if (textBox1.Text == "")
                {
                    XtraMessageBox.Show("'İşin Tanımı' Alanını Doldurmayı Unutmayiniz.");
                }
                else
                {
                    if (comboBox1.Items.IndexOf(textBox1.Text) != -1) XtraMessageBox.Show("Eklemek İstediğiniz İş Adı Zaten Mevcut");
                    else
                    {
                        isEkle();
                        VerileriGetir();
                    }
                       
                }
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label3.Visible = true;
            label3.Text = comboBox1.SelectedItem.ToString();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                XtraMessageBox.Show("İş Tanımı Kısmı Boş Bırakılamaz");
            }
            else
            {
                if (DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu.yarımkalansürec == true)
                {
                    if (iseklemesayac == 1)
                    {
                        button2.Enabled = false;
                        backgroundWorker2.RunWorkerAsync();
                    }
                    else
                    {
                        button2.Enabled = false;
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    if (clicksayisi > 0)
                    {
                        button2.Enabled = false;
                        backgroundWorker2.RunWorkerAsync();
                    }
                    else
                    {
                        button2.Enabled = false;
                        backgroundWorker1.RunWorkerAsync();

                    }
                }  
               
            }
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            VeritabanıisEkleTablosuDoldur();
        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            VeritabanıisEkleTablosuGüncelle();
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button2.Enabled = true;
        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button2.Enabled = true;
        }
    }
}