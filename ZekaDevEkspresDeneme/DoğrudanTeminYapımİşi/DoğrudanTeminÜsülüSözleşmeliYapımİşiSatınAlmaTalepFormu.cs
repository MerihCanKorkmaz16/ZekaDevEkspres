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
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiSatınAlmaTalepFormu : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiSatınAlmaTalepFormu()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\03 Satınalma Talep Formu (EK-1).doc";
        string path2 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\032 Satınalma Talep Formu (EK-1).doc";

        public static string ödenek;
        int clicksayisi;
        byte[] VeriTabanindenGelenBytes;
        public static int satınalmatalepformusayac;
        
        void SayacAl()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminSatınAlmaTalepFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        satınalmatalepformusayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac == 6)
            {
                using (SqlConnection baglan = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                using (SqlCommand komut = new SqlCommand("select * from DoğrudanTeminSatınAlmaTalepFormu where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "' ", baglan))
                {
                    baglan.Open();
                    SqlDataReader reader = komut.ExecuteReader();
                    while (reader.Read())
                    {
                        satınalmatalepformusayac = Convert.ToInt32(reader[5]);
                    }
                    baglan.Close();
                }
            }

        }
        void DökümanHazırla()
        {
            if (gerekcetextbox.Text == "")
            {
                XtraMessageBox.Show("Lütfen Gerekli Alanları Doldurunuz.");
            }
            else
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
                    if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi != null)
                    {
                        document.Variables["isAdi"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yapılacakisinadi;

                    }
                    else
                    {
                        document.Variables["isAdi"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi;

                    }
                    document.Variables["gerekce"].Value = gerekcetextbox.Text;
                    if (DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet != 0)
                    {
                        document.Variables["maliyet"].Value = DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu.yaklasikmaliyet.ToString("0.##₺");
                    }
                    else
                    {
                        document.Variables["maliyet"].Value = DoğrudanTeminSözleşmeliYapımİşiFormu.yaklasikmaliyet.ToString("0.##₺");

                    }


                    document.Fields.Update();
                    document.SaveAs2(path2);
                    word.Quit();
                    System.Threading.Thread.Sleep(500);
                    richEditControl1.LoadDocument(path2);
                    clicksayisi += 1;
                    DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 6;
                }
            }

        }
        void VeritabanıGüncelle()
        {
            using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminSatınAlmaTalepFormu set BelgeTarih=@BelgeTarih,gerekce=@gerekce,Dosya= @dosya  where id= @id and  SatınAlma_id = @SatınAlma_id");
                komut.Parameters.AddWithValue("@BelgeTarih", dateTimePicker1.Value);
                if (SatınAlmaBilgilendirmeFormu.satınalmaid != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlmaBilgilendirmeFormu.satınalmaid);
                }
                if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id != 0)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);
                }
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@gerekce", gerekcetextbox.Text);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
            }
        }
        void VeritabanıKaydet()
        {
           
            using (var sqlConnection = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminSatınAlmaTalepFormu (SatınAlma_id,id,BelgeTarih,gerekce,Dosya,satınalmasayac) values (@SatınAlma_id ,@id,@BelgeTarih,@gerekce,@dosya,@satınalmasayac )", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(path2));
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
                komut.Parameters.AddWithValue("@gerekce", gerekcetextbox.Text);
                komut.Parameters.AddWithValue("@satınalmasayac", 6);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
               
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
                    komut.CommandText = ("select * from  DoğrudanTeminSatınAlmaTalepFormu where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        dateTimePicker1.Value = Convert.ToDateTime(dr[2]);
                        dateTimePicker1.Text = (dr[2]).ToString();
                        gerekcetextbox.Text = dr[3].ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];

                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(500);
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
                    komut.CommandText = ("select * from  DoğrudanTeminSatınAlmaTalepFormu where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {

                        dateTimePicker1.Value = Convert.ToDateTime(dr[2]);
                        dateTimePicker1.Text = (dr[2]).ToString();
                        gerekcetextbox.Text = dr[3].ToString();
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];

                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path2, VeriTabanindenGelenBytes);
                            richEditControl1.LoadDocument(path2);
                        }
                    }

                    dr.Close();
                    connn.Close();

                }

            }
        }
        private void SatınAlmaTalepFormu_Load(object sender, EventArgs e)
        {
            VeriAlThread.RunWorkerAsync();
        }
        private void Gerekcetextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.NodelerarasıGeçiş();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                if (satınalmatalepformusayac == 6)
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
                if (clicksayisi > 0 )
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
        private void VeriAlThread_DoWork(object sender, DoWorkEventArgs e)
        {
            SayacAl();
            VeriAl();
        }
    }
}