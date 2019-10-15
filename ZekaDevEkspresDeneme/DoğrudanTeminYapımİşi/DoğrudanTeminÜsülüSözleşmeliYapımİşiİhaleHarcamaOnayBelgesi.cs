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
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiİhaleHarcamaOnayBelgesi : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiİhaleHarcamaOnayBelgesi()
        {
            InitializeComponent();
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\04 İhale - Harcama Onay Belgesi (EK-3).doc";
        string path1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\İhale - Harcama Onay Belgesi.doc";
        public static int clicksayisi;
        public static int ihaleharcamaonaysayac;
        byte[] VeriTabanindenGelenBytes;
        void DökümanHazırla()
        {
            if (!File.Exists(path))
            {
                XtraMessageBox.Show("Dosya Yok");
            }
            else
            {
                var word = new Word.Application();
                var document = word.Documents.Add(path);
                document.Variables["tarih"].Value = dateTimePicker1.Text;
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi == null)
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                }
                else
                {
                    document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                }
                document.Variables["nitelik"].Value = textBox1.Text;
                if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                {
                    if (DoğrudanTeminSözleşmeliYapımİşiFormu.İkinciTeklifDurum == false)
                    {
                        document.Variables["yaklasıkmaliyet"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet.ToString("#,##0.00₺");
                    }
                    else
                    {
                        document.Variables["yaklasıkmaliyet"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.nihaiyaklasikmaliyet.ToString("#,##0.00₺");

                    }
                }
                else
                {
                    if (DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.İkinciTeklifDurum == false)
                    {
                        document.Variables["yaklasıkmaliyet"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet.ToString("#,##0.00₺");
                    }
                    else
                    {
                        document.Variables["yaklasıkmaliyet"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler.nihaiyaklasikmaliyet.ToString("#,##0.00₺");

                    }
                }
                document.Fields.Update();
                document.SaveAs2(path1);
                word.Quit();
                System.Threading.Thread.Sleep(200);
                richEditControl1.LoadDocument(path1);
                clicksayisi += 1;
                DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 9;
            }
        }
        void VeritabanıKaydet()
        {

            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminİhaleHarcamaOnayFormu (SatınAlma_id,id,BelgeTarih,İsinNiteligi,Dosya,satınalmasayac) values (@SatınAlma_id ,@id,@BelgeTarih,@isinniteliği,@dosya,@satınalmasayac )", sqlConnection);
                komut.Parameters.Clear();
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
                komut.Parameters.AddWithValue("@BelgeTarih", dateTimePicker1.Value); ;
                komut.Parameters.AddWithValue("@isinniteliği", textBox1.Text); ;
                komut.Parameters.AddWithValue("@satınalmasayac", 9);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();

            }
        }
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİhaleHarcamaOnayFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        ihaleharcamaonaysayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac >= 6)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminİhaleHarcamaOnayFormu where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        ihaleharcamaonaysayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }

        }
        void VeriAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminİhaleHarcamaOnayFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(dr[2]);
                        dateTimePicker1.Text = (dr[2]).ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                        textBox1.Text = dr[3].ToString();

                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path1, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path1);
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
                    komut.CommandText = ("select * from  DoğrudanTeminİhaleHarcamaOnayFormu where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(dr[2]);
                        dateTimePicker1.Text = (dr[2]).ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                        textBox1.Text = dr[3].ToString();

                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path1, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path1);
                        }
                    }

                    dr.Close();
                    connn.Close();

                }

            }
        }
        void VeritabanıGüncelle()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminİhaleHarcamaOnayFormu set BelgeTarih=@BelgeTarih,İsinNiteligi=@İsinNiteligi,Dosya= @dosya  where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Parameters.AddWithValue("@BelgeTarih", dateTimePicker1.Value);
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                else 
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@İsinNiteligi", textBox1.Text);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path1));
                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
            }
        }
        private void SimpleButton3_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
        }
        private void DoğrudanTeminÜsülüSözleşmeliYapımİşiİhaleHarcamaOnayBelgesi_Load(object sender, EventArgs e)
        {
            VerialThread.RunWorkerAsync();
        }
        private void VerialThread_DoWork(object sender, DoWorkEventArgs e)
        {
            SayacAl();
            VeriAl();
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıKaydet();
        }
        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla();
            VeritabanıGüncelle();
        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (ihaleharcamaonaysayac == 9)
                {
                    button1.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();

                }
            }
            else
            {
                if (clicksayisi > 0)
                {
                    button1.Enabled = false;
                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    button1.Enabled = false;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
        }
    }
}