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
    public partial class DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            if (clicksayisi == 0)
            {
                Random rnd = new Random();
                SatınAlma_id = rnd.Next(1,1000000);

            }
            
        }
        static string ExeDosyaYolu = Application.StartupPath.ToString();
        string idari = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\1-1 İdari ve Teknik Şartname.docx";
        string idari1 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\12-1 İdari ve Teknik Şartname.docx";
        public static int eksizsayac = 0;
        public static bool sözlesmetaslagı = false;
        public static bool idariteknikdurum = false;
        public static string yapılacakisinadi;
        public static int SatınAlma_id;
        public const string conn = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ZekaDenemeProje1;Integrated Security=True";
        byte[] VeriTabanindenGelenBytes;
        public static int clicksayisi;
        public static int yarımkalansürecsayac;
        
        public static void NodelerarasıGeçiş()
        {
            foreach (Control item in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
            {
                if (item is TreeView)
                {
                    foreach (Control item1 in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
                    {
                        if (item1 is Panel)
                        {
                            DoğrudanTeminSözleşmeliYapımİşiFormu.renk(((TreeView)item).SelectedNode, ((TreeView)item));
                            DoğrudanTeminSözleşmeliYapımİşiFormu.nodeDegistirme(((TreeView)item).SelectedNode, ((TreeView)item), ((Panel)item1));
                            break;
                        }
                    }
                    break;
                }
            }
        }
        void VeritabanıKaydet()
        {
            Durum();
            using (var sqlConnection = new SqlConnection(conn))
            {
                
                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminİdariVeTeknikŞartname (SatınAlma_id,id,isinAdi,isinMaddeleri,sözlesmeMadde,Dosya,satınalmasayac,idariteknikackapat) values (@SatınAlma_id ,@id,@isinAdi, @isinMaddeleri,@sözlesmeMadde, @dosya , @satınalmasayac ,@idariteknikackapat )", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(idari1));
                komut.Parameters.AddWithValue("@SatınAlma_id",SatınAlma_id);
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@isinAdi", textBox2.Text);
                komut.Parameters.AddWithValue("@isinMaddeleri", textBox1.Text);
                komut.Parameters.AddWithValue("@sözlesmeMadde", sözlesmetaslagı);
                komut.Parameters.AddWithValue("@idariteknikackapat", idariteknikdurum);
                komut.Parameters.AddWithValue("@satınalmasayac", 1);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                using (var sqlConnection2 = new SqlConnection(conn))
                {

                    sqlConnection2.Open();
                    SqlCommand komut2 = new SqlCommand("update DoğrudanTeminBilgilendirmeTablosu set Ad='" + "merih" + "',Soyad='" + "Soyad" + "' where SatınAlma_id = SatınAlma_id");
                    komut2.Connection = sqlConnection2;
                    komut2.ExecuteNonQuery();
                    sqlConnection2.Close();
                }
            }
        }
        void Durum()
        {
            if (checkBox1.Checked == true)
            {
                idariteknikdurum = true;
            }
            else
            {
                idariteknikdurum = false;
            }
        }
        void İdariTeknikOlmadanVeritabanıKaydet()
        {
            Durum();
            using (var sqlConnection = new SqlConnection(conn))
            {

                SqlCommand komut = new SqlCommand("insert into DoğrudanTeminİdariVeTeknikŞartname (SatınAlma_id,id,isinAdi,sözlesmeMadde,satınalmasayac,idariteknikackapat) values (@SatınAlma_id ,@id,@isinAdi,@sözlesmeMadde, @satınalmasayac ,@idariteknikackapat )", sqlConnection);
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@SatınAlma_id", SatınAlma_id);
                komut.Parameters.AddWithValue("@id", 2);
                komut.Parameters.AddWithValue("@isinAdi", textBox2.Text);
                komut.Parameters.AddWithValue("@sözlesmeMadde", sözlesmetaslagı);
                komut.Parameters.AddWithValue("@idariteknikackapat", idariteknikdurum);
                komut.Parameters.AddWithValue("@satınalmasayac", 1);
                sqlConnection.Open();
                komut.ExecuteNonQuery();
                sqlConnection.Close();
                using (var sqlConnection2 = new SqlConnection(conn))
                {

                    sqlConnection2.Open();
                    SqlCommand komut2 = new SqlCommand("update DoğrudanTeminBilgilendirmeTablosu set Ad='" + "merih" + "',Soyad='" + "Soyad" + "' where SatınAlma_id = SatınAlma_id");
                    komut2.Connection = sqlConnection2;
                    komut2.ExecuteNonQuery();
                    sqlConnection2.Close();
                }
            }
        }
        void SözlesmeNodesDisabledEtme()
        {
            if (sözlesmetaslagı == false)
            {
                foreach (Control item in DoğrudanTeminSözleşmeliYapımİşiFormu.value)
                {
                    if (item is TreeView)
                    {
                        NodelerarasıGeçiş();
                        ((TreeView)(item)).Nodes[1].ForeColor = Color.Red;

                    }
                }
            }
        }
        void VerileriGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true )
            {
                using (SqlConnection connn = new SqlConnection(conn))
                {
                    yapılacakisinadi = textBox2.Text;
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminİdariVeTeknikŞartname where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {

                        textBox2.Text = dr[2].ToString();
                        textBox1.Text = dr[3].ToString();
                        sözlesmetaslagı = Convert.ToBoolean(dr[4]);
                        idariteknikdurum = Convert.ToBoolean(dr[7]);
                        if (idariteknikdurum == true)
                        {
                            checkBox1.Checked = true;
                            if (sözlesmetaslagı == true)
                            {
                                checkBox2.Checked = true;
                            }
                            else
                            {
                               checkBox2.Checked = false;
                            }
                        }
                        else
                        {
                            checkBox1.Checked = false;
                        }
                        if (checkBox1.Checked == true)
                        {
                            VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                        }
                       
                    }
                    dr.Close();
                    connn.Close();
                    if (checkBox1.Checked == true)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(idari1, VeriTabanindenGelenBytes);
                            richEditControl1.LoadDocument(idari1);

                        }
                        else
                        {
                            XtraMessageBox.Show("Dosya yüklenirken hata oluştu");
                        }
                    }

                }
            }
            if (yarımkalansürecsayac > 0)
            {
                using (SqlConnection connn = new SqlConnection(conn))
                {
                    yapılacakisinadi = textBox2.Text;
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminİdariVeTeknikŞartname where id = '" + 2 + "' and SatınAlma_id = '" + SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    if (dr.Read())
                    {
                        textBox2.Text = dr[2].ToString();
                        textBox1.Text = dr[3].ToString();
                        sözlesmetaslagı = Convert.ToBoolean(dr[4]);
                        if (idariteknikdurum == true)
                        {
                            checkBox1.Checked = true;
                            if (sözlesmetaslagı == true)
                            {
                                checkBox2.Checked = true;
                            }
                            else
                            {
                               checkBox2.Checked = false;
                            }
                        }
                        else
                        {
                            checkBox1.Checked = false;
                        }
                        if (checkBox1.Checked == true)
                        {
                            VeriTabanindenGelenBytes = (byte[])dr["Dosya"];

                        }
                    }
                    dr.Close();
                    connn.Close();
                    if (checkBox1.Checked == true)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(idari1, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(100);
                            richEditControl1.LoadDocument(idari1);

                        }
                        else
                        {
                            XtraMessageBox.Show("Dosya yüklenirken hata oluştu");
                        }
                    }
                    

                }

            }
            else
            {
                return;
            }

        }
        void VeritabanıGüncelle()
        {
            if (checkBox2.Checked == true)
            {
                sözlesmetaslagı = true;
            }
            else
            {
                sözlesmetaslagı = false;
            }
            Durum();
            using (SqlConnection connn = new SqlConnection(conn))
            {
                
                connn.Open();
                SqlCommand komut = new SqlCommand("update DoğrudanTeminİdariVeTeknikŞartname set isinAdi=@isinAdi,isinMaddeleri=@isinMaddeleri,Dosya= @dosya ,sözlesmeMadde=@sözlesmeMadde , idariteknikackapat = @idariteknikackapat where id= @id and  SatınAlma_id = @SatınAlma_id");
                if (SatınAlmaBilgilendirmeFormu.yarımkalandurum ==true)
                {
                    komut.Parameters.AddWithValue("@isinAdi",DoğrudanTeminSözleşmeliYapımİşiFormu.isinAdi);
                }
                else
                {
                    komut.Parameters.AddWithValue("@isinAdi", textBox2.Text);

                }
                komut.Parameters.AddWithValue("@isinMaddeleri", textBox1.Text);
                komut.Parameters.AddWithValue("@dosya", File.ReadAllBytes(idari1));
                komut.Parameters.AddWithValue("@sözlesmemadde", sözlesmetaslagı);
                komut.Parameters.AddWithValue("@idariteknikackapat", idariteknikdurum);
                if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                {
                    komut.Parameters.AddWithValue("@id", DoğrudanTeminSözleşmeliYapımİşiFormu.kullanıcıid);
                }
                else
                {
                    komut.Parameters.AddWithValue("@id", 2);

                }
                if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminSözleşmeliYapımİşiFormu.SatınAlma_id);
                }
                else
                {
                    komut.Parameters.AddWithValue("@SatınAlma_id", DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id);

                }
                komut.Connection = connn;
                komut.ExecuteNonQuery();
                connn.Close();
            }
        }
        void DökümanHazırla(string templateName, string output)
        {
            if (textBox1.Text == ""|| textBox2.Text == "")
            {
                XtraMessageBox.Show("Lütfen İlgili Yerleri Doldurunuz");
            }
            else
            {
                if (!File.Exists(templateName))
                {
                    XtraMessageBox.Show("Dosya Yok");
                }
                else
                {
                    yapılacakisinadi = textBox2.Text;
                    var word = new Word.Application();
                    var document = word.Documents.Add(templateName);
                    document.Variables["temelnitelik"].Value = textBox1.Text;
                    document.Variables["isAdi"].Value = textBox2.Text;
                    if (checkBox2.Checked == true)
                    {
                        sözlesmetaslagı = true;
                        document.Variables["sözlesmebelgesi"].Value = "3)Yüklenici ile ayrıca bir sözleşme imzalanacak olup Damga vergisi ve tüm yasal kesintiler Yükleniciye ait olacaktır. Damga vergisinin ödendiğine dair belge fatura ile birlikte Ajans’a teslim edilecektir";
                    }
                    else
                    {
                        sözlesmetaslagı = false;
                        document.Variables["sözlesmebelgesi"].Value = " ";
                    }
                    document.Fields.Update();
                    document.SaveAs2(output);
                    word.Quit();
                    System.Threading.Thread.Sleep(700);
                    richEditControl1.LoadDocument(idari1);
                    simpleButton2.Enabled = true;
                    clicksayisi += 1;
                    yarımkalansürecsayac = 1;
                }
            }
            
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                label1.Enabled = true;
                checkBox2.Enabled = true;
                button1.Enabled = true;
                simpleButton2.Enabled = false;
            }
            else if (checkBox1.Checked == false)
            {
                
                textBox1.Enabled = false;
                label1.Enabled = false;
                checkBox2.Enabled = false;
                 button1.Enabled = false;
                simpleButton2.Enabled = true;

            }
           
        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                XtraMessageBox.Show("Sonraki Dökümana Geçmeden Önce İşin Adı Kısmını doldurunuz.");
            }
            else
            {
                if (checkBox1.Checked == false)
                {
                    if (idariteknikdurum == true)
                    {
                        yarımkalansürecsayac = 1;
                        VeritabanıGüncelle();
                        clicksayisi += 1;
                        yapılacakisinadi = textBox2.Text;
                        NodelerarasıGeçiş();
                        SözlesmeNodesDisabledEtme();
                    }
                    else
                    {
                        yarımkalansürecsayac = 1;
                        İdariTeknikOlmadanVeritabanıKaydet();
                        clicksayisi += 1;
                        yapılacakisinadi = textBox2.Text;
                        NodelerarasıGeçiş();
                        SözlesmeNodesDisabledEtme();

                    }

                }
                else
                {

                    yapılacakisinadi = textBox2.Text;
                    NodelerarasıGeçiş();
                    SözlesmeNodesDisabledEtme();
                }
            }

        }
        private void DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName_Load(object sender, EventArgs e)
        {
           backgroundWorker1.RunWorkerAsync();
            
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            VerileriGetir();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true || clicksayisi > 0 || yarımkalansürecsayac == 1)
            {
                button1.Enabled = false;
                backgroundWorker3.RunWorkerAsync();
                
            }
            else
            {
                button1.Enabled = false;
                backgroundWorker2.RunWorkerAsync();
              
            }
        }
        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla(idari, idari1);
            VeritabanıKaydet();
        }
        private void BackgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }
        private void BackgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            DökümanHazırla(idari, idari1);
            VeritabanıGüncelle();
            System.Threading.Thread.Sleep(200);
        }
        private void BackgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            button1.Enabled = true;
        }

    }
}