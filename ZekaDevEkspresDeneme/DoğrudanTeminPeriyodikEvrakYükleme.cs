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
    public partial class DoğrudanTeminPeriyodikEvrakYükleme : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPeriyodikEvrakYükleme()
        {
            InitializeComponent();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
        }
        public static string sözlesmetaslağı1;
        public static string sözlesmetaslağı2;
        public static string damgavergisi;
        double Süre;
        int ay;
        private void DoğrudanTeminPeriyodikEvrakYükleme_Load(object sender, EventArgs e)
        {
            if (DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.sözlesmetaslagıackapa == true)
            {
                groupBox3.Enabled = false;
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = true;
                groupBox2.Enabled = false;
            }
        }
        void DökümanVeritabanıYükle()
        {
          
            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminPeriyodikSözlesmeEvrakEklemeTablosu (SatınAlma_id,id,SözlesmeDosya,DamgaVergisiDosya) values (@SatınAlma_id ,@id,@SözlesmeDosya,@DamgaVergisiDosya )", sqlConnection);
                komut.Parameters.Clear();
                if (DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.sözlesmetaslagıackapa == true)
                {
                    komut.Parameters.AddWithValue("@SözlesmeDosya", File.ReadAllBytes(sözlesmetaslağı1));

                }
                else
                {
                    komut.Parameters.AddWithValue("@SözlesmeDosya", File.ReadAllBytes(sözlesmetaslağı2));

                }
                komut.Parameters.AddWithValue("@DamgaVergisiDosya", File.ReadAllBytes(damgavergisi));
                komut.Parameters.AddWithValue("@id", 2);

                komut.Parameters.AddWithValue("@SatınAlma_id", 0);
     
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            openFileDialog1.Title = "Sözleşme Evrağını Yükleyiniz";
            if (openFileDialog1.FileName != null)
            {
                label2.Text = "Sözleşme Evrağı Başarıyla Yüklendi";
                label2.ForeColor = Color.Green;
                label1.Visible = true;
                sözlesmetaslağı1 = openFileDialog1.FileName;
                label1.Text = "Eklenilen Dosya : " + " " + openFileDialog1.SafeFileName.ToString();
            }

        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.ShowDialog();
            openFileDialog2.Title = "Sözleşme Evrağını Yükleyiniz";
            if (openFileDialog2.FileName != null)
            {
                label4.Text = "Sözleşme Evrağı Başarıyla Yüklendi";
                label4.ForeColor = Color.Green;
                label3.Visible = true;
                sözlesmetaslağı2 = openFileDialog2.FileName;
                label3.Text = "Eklenilen Dosya : " + " " + openFileDialog2.SafeFileName.ToString();
                label10.Enabled = true;
                label11.Enabled = true;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                groupBox5.Enabled = true;
            }
        }
        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            openFileDialog3.ShowDialog();
            openFileDialog3.Title = "Damga Vergisi Dekont Yükleyiniz";
            if (openFileDialog3.FileName != null)
            {
                label6.Text = "Damga Vergisi Dekont Başarıyla Yüklendi";
                label6.ForeColor = Color.Green;
                label5.Visible = true;
                damgavergisi = openFileDialog3.FileName;
                label5.Text = "Eklenilen Dosya : " + " " + openFileDialog3.SafeFileName.ToString();

            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama.sözlesmetaslagıackapa == true)
            {
                if (sözlesmetaslağı1 == null || damgavergisi ==null)
                {
                    XtraMessageBox.Show("Dosya Eklemeyi unutmayınız");
                    return;
                }
                else
                {
                    DökümanVeritabanıYükle();

                }
            }
            else
            {
                if (sözlesmetaslağı2 == null || damgavergisi == null)
                {
                    XtraMessageBox.Show("Dosya Eklemeyi unutmayınız");
                    return;
                }
                else
                {
                    DökümanVeritabanıYükle();

                }
            }
        }

        private void AylıkText_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            //---------------------------------------//
        }
        void SüreHesapla()
        {
            Süre = dateTimePicker2.Value.Subtract(dateTimePicker1.Value).TotalDays;
            if (Süre >= 30)
            {
                Süre = (Süre / 30);
                Süre = (Süre / ay);
                Süre = Convert.ToInt32(Süre);
            }

        }
        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}