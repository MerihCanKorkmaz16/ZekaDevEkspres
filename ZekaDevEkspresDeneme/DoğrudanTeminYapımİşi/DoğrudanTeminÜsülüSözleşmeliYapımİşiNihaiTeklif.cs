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
using Word = Microsoft.Office.Interop.Word;

namespace ZekaDevEkspresDeneme
{
    public partial class NihaiTeklifSüreci : DevExpress.XtraEditors.XtraForm
    {
        public NihaiTeklifSüreci()
        {
            InitializeComponent();
        }
        DoğrudanTeminSözleşmeliYapımİşiFormu ys = new DoğrudanTeminSözleşmeliYapımİşiFormu();
        public static DateTime NihaiTeklifSüresi;

        public const string conn = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ZekaDenemeProje1;Integrated Security=True";


        static string ExeDosyaYolu = Application.StartupPath.ToString();
        static string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Nihai Teklifler\\05 Nihai Teklif.docx";
        static string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Nihai Teklifler\\052 Nihai Teklif.docx";
        static string path3 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\EKSİZ DOSYALAR\\05 Nihai Teklif EKSİZ.docx";
        static string path4 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\EKSİZ DOSYALAR\\051 Nihai Teklif EKSİZ.docx";
        static string path5 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\EKSİZ DOSYALAR\\052 Nihai Teklif EKSİZ.docx";
        byte[] VeriTabanindenGelenBytes;
        int clicksayisi = 0;
        public static int nihaiteklifsayac;

        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminNihaiTeklif where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        nihaiteklifsayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 7)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminNihaiTeklif where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        nihaiteklifsayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }

        }
        void VeritabanıKaydet()
        {
            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminNihaiTeklif (SatınAlma_id,id,BelgeTarih,FirmaTanınanSaat,FirmaTanınanTarih,Dosya,satınalmasayac) values (@SatınAlma_id ,@id,@BelgeTarih,@Firmasaat,@Firmatarih,@dosya,@satınalmasayac )", sqlConnection);
                komut.Parameters.Clear();
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);

                }
                if (DoğrudanTeminSözleşmeliYapımİşiFormu.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminSözleşmeliYapımİşiFormu.SatınAlma_id);

                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@BelgeTarih", dateTimePicker1.Value); 
                komut.Parameters.AddWithValue("@Firmasaat", dateEdit3.Text); 
                komut.Parameters.AddWithValue("@Firmatarih", firmazaman.Value); 
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
                komut.Parameters.AddWithValue("@satınalmasayac", 7);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                

            }
        }
        void VeritabanıGüncelle()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminNihaiTeklif set BelgeTarih=@BelgeTarih,FirmaTanınanTarih=@FirmaTanınanTarih,Dosya= @dosya ,FirmaTanınanSaat=@FirmaTanınanSaat where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Parameters.AddWithValue("@BelgeTarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@id", SatınAlmaBilgilendirmeFormu.kullanıcıid);
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@FirmaTanınanSaat", dateEdit3.Text);
                komut.Parameters.AddWithValue("@FirmaTanınanTarih", firmazaman.Value);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
            }
            NihaiTeklifSüresi = firmazaman.Value;
        }
        void VerileriGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminNihaiTeklif where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {

                        dateTimePicker1.Text = dr[2].ToString();
                        firmazaman.Text = dr[3].ToString();
                        dateEdit3.Text = dr[6].ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path2);
                        }
                    }

                    dr.Close();
                    connn.Close();

                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 6)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminNihaiTeklif where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {

                        dateTimePicker1.Text = dr[2].ToString();
                        firmazaman.Text = dr[3].ToString();
                        dateEdit3.Text = dr[6].ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path2);
                        }
                    }

                    dr.Close();
                    connn.Close();

                }

            }
        }
        void DökümanHazırla()
        {

            if (!File.Exists(path))
            {
                XtraMessageBox.Show("Dosya Yok");
            }
            else
            {
                NihaiTeklifSüresi = firmazaman.Value;
                var word = new Word.Application();
                var document = word.Documents.Add(path);
                document.Variables["tarih"].Value = dateTimePicker1.Text;
                document.Variables["firmadate"].Value = firmazaman.Text;
                document.Variables["süre"].Value = dateEdit3.Text;
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                }
                else
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                }
                document.Fields.Update();
                document.SaveAs2(path2);
                word.Quit();
                System.Threading.Thread.Sleep(500);
                richEditControl1.LoadDocument(path2);
                clicksayisi += 1;
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 7;
            }
            
        }
        private void NihaiTeklifSüreci_Load(object sender, EventArgs e)
        {
             VeriAlThread.RunWorkerAsync();
       }
        private void VeriAlThread_DoWork(object sender, DoWorkEventArgs e)
        {
            SayacAl();
            VerileriGetir();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (nihaiteklifsayac == 7)
                {
                   button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    button1.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
                
            }
            else
            {
                if (clicksayisi > 0)
                {
                    button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();

                }
                else
                {
                    button1.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
               
            }
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıGüncelle();
        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıKaydet();
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;

        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
    }
}

