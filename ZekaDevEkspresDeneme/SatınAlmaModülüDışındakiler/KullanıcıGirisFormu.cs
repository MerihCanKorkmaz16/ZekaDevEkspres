using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZekaDevEkspresDeneme
{
    public partial class KullaniciGirisi : DevExpress.XtraEditors.XtraForm
    {
        public KullaniciGirisi()
        {
            InitializeComponent();
        }
        public static string id="2";
        public static string ad;
        public static string soyad;
        public static string tc;
        public static string ünvan;
        public static string görev;
        public static string mail;
        public static string kadi;
        public static string ksifre;
        public static string yetkilendirme;

        public const string conn = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ZekaDenemeProje1;Integrated Security=True";

        SqlConnection baglanti = null;
        
        public void getir()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminSözleşmeliYapımİşiFormu.conn))
            {
                connn.Open();
                SqlCommand komut = new SqlCommand("select * from  kullanicilar where Kullanıcı_adi = '" + KullaniciAdiTextBox.Text + "' and Kullanici_sifre = '" + SifreTextBox.Text + "'", baglanti);
                komut.Connection = connn;
                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    id = dr[0].ToString();
                    ad = dr[1].ToString();
                    soyad = dr[2].ToString();
                    tc = dr[3].ToString();
                    ünvan = dr[4].ToString();
                    görev = dr[5].ToString();
                    mail = dr[6].ToString();
                    kadi = dr[7].ToString();
                    ksifre = dr[8].ToString();
                    yetkilendirme = dr[9].ToString();
                }
                dr.Close();
                connn.Close();
            }
        }

        

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            KullaniciAdiTextBox.Text = Properties.Settings.Default["kuladi"].ToString();
            SifreTextBox.Text = Properties.Settings.Default["sifre"].ToString();
            if (KullaniciAdiTextBox.Text.Count()>1)
            {
                checkBox2.Checked = true;
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            
            if (checkBox2.Checked)
            {
                Properties.Settings.Default["kuladi"] = KullaniciAdiTextBox.Text;
                Properties.Settings.Default["sifre"] = SifreTextBox.Text;
            }
            else
            {
                Properties.Settings.Default["kuladi"] = KullaniciAdiTextBox.Text;
                Properties.Settings.Default["sifre"] = SifreTextBox.Text;

            }
            Properties.Settings.Default.Save();

            if (KullaniciAdiTextBox.Text == "" && SifreTextBox.Text == "")
            {
                label3.Text = "Lütfen Kullanıcı Adı ve Şifrenizi giriniz!!";
                label3.ForeColor = Color.Red;
            }
            else
            {
                getir();
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminSözleşmeliYapımİşiFormu.conn))
                {

                    connn.Open();
                    SqlCommand komut = new SqlCommand("select * from kullanicilar where Kullanıcı_adi = '" + KullaniciAdiTextBox.Text + "' and Kullanici_sifre = '" + SifreTextBox.Text + "' ");
                    komut.Connection = connn;
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {

                        this.Hide();
                        AnaForm anaform = new AnaForm();
                        anaform.Show();
                    }
                    else
                    {

                        label3.Text = "Kullanıcı Adınız veya Şifre yanlış!";
                        label3.ForeColor = Color.Red;
                    }

                    connn.Close();
                }

            }

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                SifreTextBox.UseSystemPasswordChar = false;
            }

            else
            {
                SifreTextBox.UseSystemPasswordChar = true;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
