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
    public partial class DoğrudanTeminSözleşmeliYapımİşiFormu : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminSözleşmeliYapımİşiFormu()
        {
            InitializeComponent();

        }

        public static void renk(TreeNode node, TreeView tree)
        {
            foreach (TreeNode item in tree.Nodes)
            {
                if (item.BackColor == SystemColors.Highlight)
                {
                    item.BackColor = Color.Transparent;
                    item.ForeColor = Color.Black;
                    break;
                }
            }

        }
        public static string conn = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ZekaDenemeProje1;Integrated Security=True";
        public static string conn2 = "Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ParasalLimitler;Integrated Security=True";

        public static SqlConnection baglanti = null;
        public static SqlCommand cmd;
        public static SqlDataReader oku;
        public static Control.ControlCollection value;
        public static int SatınAlma_id;
        public static int kullanıcıid;
        public static decimal yaklasikmaliyet;
        public static decimal nihaiyaklasikmaliyet;
        public static string isinAdi;
        public static bool İkinciTeklifDurum;
        public static decimal ParasalLimitinTuru131b;


        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ForeColor == Color.Black)
            {
                renk(e.Node, treeView1);
                switch (e.Node.Name)
                {
                    case "Düğüm31":
                        idariteknikşartnameac(panel1);
                        break;
                    case "Düğüm0":
                        YaklasikTeklifAc(panel1);
                        break;
                    case "Düğüm3152":
                        FirmaEkle(panel1);
                        break;
                    case "Düğüm2":
                        YaklasıkMaliyetAc(panel1); ; break;
                    case "Düğüm3":
                        SatınAlmaFormuAc(panel1); break;
                    case "Düğüm4":
                        ihaleonayac(panel1); break;
                    case "Düğüm5":
                        NihaiAc(panel1); break;
                    case "Node00":
                        NihaiTeklifVerenFirmaAc(panel1); break;
                    case "Düğüm6":
                        PiyasafiyataraştırmaAc(panel1); break;
                    case "Düğüm7":
                        KontrolTeminListesiAc(panel1); break;
                    case "Düğüm8":
                        kabulkomisyonuoluryazısı(panel1); break;
                    case "Düğüm9":
                        kesinkabultutanağıac(panel1); break;
                    case "Düğüm11":
                        SözlesmeTaslağıAc(panel1); break;

                    default:
                        break;
                }

            }
        }
        private static void temizle(Panel pnl)
        {
            System.Threading.Thread.Sleep(200);
            pnl.Controls.Clear();
            pnl.Visible = false;
        }
        private static void NihaiAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            NihaiTeklifSüreci nihai = new NihaiTeklifSüreci();
            nihai.TopLevel = false;
            nihai.Dock = DockStyle.Fill;
            nihai.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(nihai);
            nihai.Show();
        }
        private static void YaklasıkMaliyetAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu yaklasik = new DoğrudanTeminÜsülüSözleşmeliYapımİşiTipYaklaşıkMaliyetFormu();
            yaklasik.TopLevel = false;
            yaklasik.Dock = DockStyle.Fill;
            yaklasik.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(yaklasik);
            yaklasik.Show();

        }
        private static void YaklasikTeklifAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif yaklasikteklif = new DoğrudanTeminÜsülüSözleşmeliYapımİşiYaklaşıkMaliyetTeklif();
            yaklasikteklif.TopLevel = false;
            yaklasikteklif.Dock = DockStyle.Fill;
            yaklasikteklif.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(yaklasikteklif);
            yaklasikteklif.Show();

        }
        private static void SatınAlmaFormuAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiSatınAlmaTalepFormu satınalmaformu = new DoğrudanTeminÜsülüSözleşmeliYapımİşiSatınAlmaTalepFormu();
            satınalmaformu.TopLevel = false;
            satınalmaformu.Dock = DockStyle.Fill;
            satınalmaformu.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(satınalmaformu);
            satınalmaformu.Show();
        }
        private static void PiyasafiyataraştırmaAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiPiyasaFiyatAraştırmaTutanağı piyasa = new DoğrudanTeminÜsülüSözleşmeliYapımİşiPiyasaFiyatAraştırmaTutanağı();
            piyasa.TopLevel = false;
            piyasa.Dock = DockStyle.Fill;
            piyasa.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(piyasa);
            piyasa.Show();
        }
        private static void KontrolTeminListesiAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanKontrolTeminListesi doğrudankontrollitesi = new DoğrudanKontrolTeminListesi();
            doğrudankontrollitesi.TopLevel = false;
            doğrudankontrollitesi.Dock = DockStyle.Fill;
            doğrudankontrollitesi.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(doğrudankontrollitesi);
            doğrudankontrollitesi.Show();
        }
        private static void SözlesmeTaslağıAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiSözleşmeTaslağı sözlesmetaslağı = new DoğrudanTeminÜsülüSözleşmeliYapımİşiSözleşmeTaslağı();
            sözlesmetaslağı.TopLevel = false;
            sözlesmetaslağı.Dock = DockStyle.Fill;
            sözlesmetaslağı.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(sözlesmetaslağı);
            sözlesmetaslağı.Show();
        }
        private static void kabulkomisyonuoluryazısı(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı kabul = new DoğrudanTeminÜsülüSözleşmeliYapımİşiKabulKomisyonuOlurYazısı();
            kabul.TopLevel = false;
            kabul.Dock = DockStyle.Fill;
            kabul.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(kabul);
            kabul.Show();
        }
        private static void kesinkabultutanağıac(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiKesinKabulTutanağı kesinkabul = new DoğrudanTeminÜsülüSözleşmeliYapımİşiKesinKabulTutanağı();
            kesinkabul.TopLevel = false;
            kesinkabul.Dock = DockStyle.Fill;
            kesinkabul.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(kesinkabul);
            kesinkabul.Show();
        }
        private static void idariteknikşartnameac(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName idari = new DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName();
            idari.TopLevel = false;
            idari.Dock = DockStyle.Fill;
            idari.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(idari);
            idari.Show();
        }
        private static void ihaleonayac(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİhaleHarcamaOnayBelgesi ihale = new DoğrudanTeminÜsülüSözleşmeliYapımİşiİhaleHarcamaOnayBelgesi();
            ihale.TopLevel = false;
            ihale.Dock = DockStyle.Fill;
            ihale.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(ihale);
            ihale.Show();
        }
        private static void NihaiTeklifVerenFirmaAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler nihaiteklifverenler = new DoğrudanTeminÜsülüSözleşmeliYapımİşiNihaiTeklifler();
            nihaiteklifverenler.TopLevel = false;
            nihaiteklifverenler.Dock = DockStyle.Fill;
            nihaiteklifverenler.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(nihaiteklifverenler);
            nihaiteklifverenler.Show();
        }
        private static void FirmaEkle(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminSözleşmeliYapımİşiFirmaEkle firmaekle = new DoğrudanTeminSözleşmeliYapımİşiFirmaEkle();
            firmaekle.TopLevel = false;
            firmaekle.Dock = DockStyle.Fill;
            firmaekle.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(firmaekle);
            firmaekle.Show();
        }
        private void YeniSatınAlmaFormu_Load(object sender, EventArgs e)
        {
            value = this.Controls;
            VeriAlDeğiskenlereAt();
            İkinciTeklifDurumAl();
            ParasalLimitlerVeriAl();
        }
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.SelectedNode != null && Color.Silver == e.Node.ForeColor)
                e.Cancel = true;
        }
        public static void nodeDegistirme(TreeNode param, TreeView tree, Panel pnl)
        {
            param.NextNode.ForeColor = Color.Black;
            tree.SelectedNode = param.NextNode;

            switch (param.NextNode.Name)
            {
                case "Düğüm31":
                    idariteknikşartnameac(pnl);
                    break;
                case "Düğüm0":
                    YaklasikTeklifAc(pnl);
                    break;
                case "Düğüm3152":
                    FirmaEkle(pnl);
                    break;
                case "Düğüm2":
                    YaklasıkMaliyetAc(pnl); ; break;
                case "Düğüm3":
                    SatınAlmaFormuAc(pnl); break;
                case "Düğüm4":
                    ihaleonayac(pnl); break;
                case "Düğüm5":
                    NihaiAc(pnl); break;
                case "Node00":
                    NihaiTeklifVerenFirmaAc(pnl); break;
                case "Düğüm6":
                    PiyasafiyataraştırmaAc(pnl); break;
                case "Düğüm7":
                    KontrolTeminListesiAc(pnl); break;
                case "Düğüm8":
                    kabulkomisyonuoluryazısı(pnl); break;
                case "Düğüm9":
                    kesinkabultutanağıac(pnl); break;
                case "Düğüm11":
                    SözlesmeTaslağıAc(pnl); break;

                default:

                    temizle(pnl); break;
            }
            param.NextNode.ForeColor = Color.White;
            param.NextNode.BackColor = SystemColors.Highlight;

        }
        void VeriAlDeğiskenlereAt()
        {
            using (SqlConnection connn = new SqlConnection(conn))
            {
                connn.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = connn;
                komut.CommandText = ("select * from  DoğrudanTeminİdariVeTeknikŞartname where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {

                    SatınAlma_id = Convert.ToInt32(dr[0]);
                    kullanıcıid = Convert.ToInt32(dr[1]);
                    isinAdi = dr[2].ToString();
                    
                }
                dr.Close();
                connn.Close();
                
            }
            using (SqlConnection connn = new SqlConnection(conn))
            {
                connn.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = connn;
                komut.CommandText = ("select * from  DoğrudanTeminBirinciTeklifTipYaklasıkMaliyet where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {

                     yaklasikmaliyet = Convert.ToDecimal(dr[3]);
                    

                }
                dr.Close();
                connn.Close();

            }
        }
        void ParasalLimitlerVeriAl()
        {
            using (SqlConnection connn = new SqlConnection(conn2))
            {
                connn.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = connn;
                komut.CommandText = ("select * from  SonDegerTablosu where id = '" + 31 + "' ");
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {
                   ParasalLimitinTuru131b = Convert.ToDecimal(dr[4]);
                }
                dr.Close();
                connn.Close();

            }
           
        }
        void İkinciTeklifDurumAl()
        {
           
            using (SqlConnection connn = new SqlConnection(conn))
            {
                connn.Open();
                SqlCommand komut = new SqlCommand();
                komut.Connection = connn;
                komut.CommandText = ("select * from  DoğrudanTeminİkinciTeklifFirma where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                SqlDataReader dr = komut.ExecuteReader();
                while (dr.Read())
                {

                    İkinciTeklifDurum = Convert.ToBoolean(dr[9]);
                    nihaiyaklasikmaliyet = Convert.ToDecimal(dr[7]);

                }
                dr.Close();
                connn.Close();

            }
        }
    }
    }

