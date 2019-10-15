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
using Word=  Microsoft.Office.Interop.Word;

namespace ZekaDevEkspresDeneme
{
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiSözleşmeTaslağı : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiSözleşmeTaslağı()
        {
            InitializeComponent();
        }

        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Sözleşme Taslağı2.docx";
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Periyodik\\Sözleşme Taslağı.docx";
        public const string conn = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ZekaDenemeProje1;Integrated Security=True";
        byte[] VeriTabanindenGelenBytes;
        public static int clicksayisi;
        int sözlesmetaslagısayac;
        private void dökümanyükle()
        {
            if (!File.Exists(path))
            {
                XtraMessageBox.Show("Dosya Yok");
            }
            else
            {
                var word = new Word.Application();
                var document = word.Documents.Add(path);
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                }
                else
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                }
                document.SaveAs2(path1);
                word.Quit();
                System.Threading.Thread.Sleep(500);
                richEditControl1.LoadDocument(path1);
            }

        }
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true )
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminSözlesmeTaslağı where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        sözlesmetaslagısayac = Convert.ToInt32(reader[3]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 2)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminSözlesmeTaslağı where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        sözlesmetaslagısayac = Convert.ToInt32(reader[3]);
                    }
                    baglan.Close();
                }
            }
            else
            {
                return;
            }
        }
        void VeritabanıKaydet()
        {
            using (var sqlConnection = new SqlConnection(conn))
            {
                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminSözlesmeTaslağı (SatınAlma_id,id,Dosya,satınalmasayac) values (@SatınAlma_id,@id,@dosya ,@satınalmasayac )", sqlConnection);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path1));
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@satınalmasayac", 2);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }
        void VerileriGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true && sözlesmetaslagısayac ==2)
            {
               using (SqlConnection connn = new SqlConnection(conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminSözlesmeTaslağı where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                    }
                    dr.Close();
                    connn.Close();
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path1, VeriTabanindenGelenBytes);
                            richEditControl1.LoadDocument(path1);

                        }
                    }

                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 2)
            {
                MessageBox.Show("2");
                using (SqlConnection connn = new SqlConnection(conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminSözlesmeTaslağı where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                    }
                    dr.Close();
                    connn.Close();
                    
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path1, VeriTabanindenGelenBytes);
                            richEditControl1.LoadDocument(path1);

                        }

                }

            }
            else
            {
              return;
            }
            //------------------------------
            if (sözlesmetaslagısayac == 2)
            {
                barButtonItem1.Enabled = true;
                 
            }

        }
        void VeritabanıGüncelle()
        {
           
            using (SqlConnection connn = new SqlConnection(conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminSözlesmeTaslağı set Dosya= @dosya where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path1));
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
            }
        }
        public void SözleşmeTaslağı_Load(object sender, EventArgs e)
        {
            SayacAl();
            VeriAlThread.RunWorkerAsync();
            if (sözlesmetaslagısayac == 2)
            {
                System.Threading.Thread.Sleep(200);
                richEditControl1.Options.Behavior.SaveAs = DevExpress.XtraRichEdit.DocumentCapability.Enabled;

            }
            else
            {
                System.Threading.Thread.Sleep(200);
                richEditControl1.Options.Behavior.SaveAs = DevExpress.XtraRichEdit.DocumentCapability.Disabled;
            }

        }
        private void VeriAlThread_DoWork(object sender, DoWorkEventArgs e)
        {
            VerileriGetir();
            if (sözlesmetaslagısayac < 2)
            {
                dökümanyükle();
            }
            else
            {
                return;
            }
            
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            VeritabanıGüncelle();

        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            clicksayisi += 1;
            VeritabanıKaydet();
        }
        private void FileSaveItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            richEditControl1.Options.Behavior.SaveAs = DevExpress.XtraRichEdit.DocumentCapability.Enabled;
        }
        private void FileSaveAsItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 2;
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (sözlesmetaslagısayac == 2)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    barButtonItem1.Enabled = true;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            else
            {
                if (clicksayisi > 0)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    barButtonItem1.Enabled = true;
                    backgroundWorker2.RunWorkerAsync();
                }
            }
        }
        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();

        }
      private void RichEditControl1_AutoCorrect(object sender, DevExpress.XtraRichEdit.AutoCorrectEventArgs e)
        {
            richEditControl1.Options.Behavior.SaveAs = DevExpress.XtraRichEdit.DocumentCapability.Disabled;

        }
    }
}