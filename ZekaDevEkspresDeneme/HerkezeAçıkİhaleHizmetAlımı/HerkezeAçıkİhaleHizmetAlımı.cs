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

namespace ZekaDevEkspresDeneme
{
    public partial class HerkezeAçıkİhaleHizmetAlımı : DevExpress.XtraEditors.XtraForm
    {
        public HerkezeAçıkİhaleHizmetAlımı()
        {
            InitializeComponent();
        }
        public static Control.ControlCollection value;
        private void HerkezeAçıkİhaleHizmetAlımı_Load(object sender, EventArgs e)
        {
            value = this.Controls;
            
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
        private static void nodeDegistirme(TreeNode param, TreeView tree, Panel pnl)
        {
            param.NextNode.ForeColor = Color.Black;
            tree.SelectedNode = param.NextNode;

            //switch (param.NextNode.Name)
            //{
            //    case "Node0":
            //        ÖnTeklifAc(pnl);
            //        break;
            //    case "Node1":
            //        TipYaklasikAc(pnl);
            //        break;
            //    case "Node2":
            //        SatınAlmaTalepAc(pnl);
            //        break;
            //    case "Node3":
            //        HarcamaOnayAc(pnl);
            //        break;
            //    case "Node4":
            //        SonTeklifAc(pnl);
            //        break;
            //    case "Node5":
            //        PiyasaFiyatAc(pnl);
            //        break;
            //    case "Node6":
            //        SözleşmeAc(pnl);
            //        break;
            //    case "Node7":
            //        KesinKabulAc(pnl);
            //        break;
            //    case "Node8":
            //        İdariVeTeknikAc(pnl);
            //        break;
            //    case "Node9":
            //        OlurYazısıAc(pnl);
            //        break;
            //    case "Node10":
            //        FirmaEkleAc(pnl);
            //        break;
            //    case "Node11":
            //        SonTeklifFirmaEkleAc(pnl);
            //        break;
            //    default:

            //        temizle(pnl); break;
            //}
            //param.NextNode.ForeColor = Color.White;
            //param.NextNode.BackColor = SystemColors.Highlight;

        }
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (treeView1.SelectedNode != null && Color.Silver == e.Node.ForeColor)
                e.Cancel = true;
        }
        private void İhaleİlanıAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıİhaleİlanı ihaleilan = new HerkezeAçıkİhaleHizmetAlımıİhaleİlanı();
            ihaleilan.TopLevel = false;
            ihaleilan.Dock = DockStyle.Fill;
            ihaleilan.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(ihaleilan);
            ihaleilan.Show();
        }
        private void OlurYazısıAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleKomisyonOlurYazısı oluryazısı = new HerkezeAçıkİhaleKomisyonOlurYazısı();
            oluryazısı.TopLevel = false;
            oluryazısı.Dock = DockStyle.Fill;
            oluryazısı.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(oluryazısı);
            oluryazısı.Show();
        }
        private void KomisyonAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkeseAçıkİhaleHizmetAlımıMuayeneVeKabulKomisyonuOluşturmaYazısı oluryazısıs = new HerkeseAçıkİhaleHizmetAlımıMuayeneVeKabulKomisyonuOluşturmaYazısı();
            oluryazısıs.TopLevel = false;
            oluryazısıs.Dock = DockStyle.Fill;
            oluryazısıs.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(oluryazısıs);
            oluryazısıs.Show();
        }
        private void Komisyon2Ac(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıKontrolVeMuayneKomisyonTablosu oluryazısı2 = new HerkezeAçıkİhaleHizmetAlımıKontrolVeMuayneKomisyonTablosu();
            oluryazısı2.TopLevel = false;
            oluryazısı2.Dock = DockStyle.Fill;
            oluryazısı2.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(oluryazısı2);
            oluryazısı2.Show();
        }
        private void İdariVeTeknikAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıİdariŞartName idari = new HerkezeAçıkİhaleHizmetAlımıİdariŞartName();
            idari.TopLevel = false;
            idari.Dock = DockStyle.Fill;
            idari.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(idari);
            idari.Show();
        }
        private void TeknikAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıTeknikŞartName teknik = new HerkezeAçıkİhaleHizmetAlımıTeknikŞartName();
            teknik.TopLevel = false;
            teknik.Dock = DockStyle.Fill;
            teknik.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(teknik);
            teknik.Show();
        }
        private static void temizle(Panel pnl)
        {
            pnl.Controls.Clear();
            pnl.Visible = false;
        }
        private void TipYaklasikAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu tip = new HerkezeAçıkİhaleHizmetAlımıTipYaklasikMaliyetFormu();
            tip.TopLevel = false;
            tip.Dock = DockStyle.Fill;
            tip.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(tip);
            tip.Show();
        }
        private void SatınAlmaAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu satın = new HerkezeAçıkİhaleHizmetAlımıSatınAlmaTalepFormu();
            satın.TopLevel = false;
            satın.Dock = DockStyle.Fill;
            satın.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(satın);
            satın.Show();
        }
        private void İhaleOnayAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi ihale = new HerkesAçıkİhaleHizmetAlımıİhaleHarcamaOnayBelgesi();
            ihale.TopLevel = false;
            ihale.Dock = DockStyle.Fill;
            ihale.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(ihale);
            ihale.Show();
        }
        private void ÖnYeterlilikAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkeseAçıkİhaleHizmetAlımıİhaleÖnYeterlilikFormu ön = new HerkeseAçıkİhaleHizmetAlımıİhaleÖnYeterlilikFormu();
            ön.TopLevel = false;
            ön.Dock = DockStyle.Fill;
            ön.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(ön);
            ön.Show();
        }
        private void AlındıBelgesiAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıAlındıBelgesi alındı = new HerkezeAçıkİhaleHizmetAlımıAlındıBelgesi();
            alındı.TopLevel = false;
            alındı.Dock = DockStyle.Fill;
            alındı.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(alındı);
            alındı.Show();
        }
        private void ZarfAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıZarfAçmaKontrolTutanağı zarf = new HerkezeAçıkİhaleHizmetAlımıZarfAçmaKontrolTutanağı();
            zarf.TopLevel = false;
            zarf.Dock = DockStyle.Fill;
            zarf.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(zarf);
            zarf.Show();
        }
        private void DısAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıDeğerlendirmeDışıBırakılanTekliflerİçinİhaleKomisyonuTutanağı dış = new HerkezeAçıkİhaleHizmetAlımıDeğerlendirmeDışıBırakılanTekliflerİçinİhaleKomisyonuTutanağı();
            dış.TopLevel = false;
            dış.Dock = DockStyle.Fill;
            dış.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(dış);
            dış.Show();
        }
        private void TutanakAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıTeklifEdilenTutarlarTutanağı tutar = new HerkezeAçıkİhaleHizmetAlımıTeklifEdilenTutarlarTutanağı();
            tutar.TopLevel = false;
            tutar.Dock = DockStyle.Fill;
            tutar.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(tutar);
            tutar.Show();
        }
        private void İhaleKararıAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı kihale = new HerkezeAçıkİhaleHizmetAlımıİhaleKomisyonuKararı();
            kihale.TopLevel = false;
            kihale.Dock = DockStyle.Fill;
            kihale.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(kihale);
            kihale.Show();
        }
        private void KesinlesenKararAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu mektub = new HerkezeAçıkİhaleHizmetAlımıKesinlesenİhaleKararıBildirimMektubu();
            mektub.TopLevel = false;
            mektub.Dock = DockStyle.Fill;
            mektub.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(mektub);
            mektub.Show();
        }
        private void İptalAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAcıkİhaleHizmetAlımıİhaleİptalKararıBildirimMektubu iptal = new HerkezeAcıkİhaleHizmetAlımıİhaleİptalKararıBildirimMektubu();
            iptal.TopLevel = false;
            iptal.Dock = DockStyle.Fill;
            iptal.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(iptal);
            iptal.Show();
        }
        private void SözlesmeDavetAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıSözleşmeDavetMektubu davet = new HerkezeAçıkİhaleHizmetAlımıSözleşmeDavetMektubu();
            davet.TopLevel = false;
            davet.Dock = DockStyle.Fill;
            davet.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(davet);
            davet.Show();

        }
        private void SözlesmeTaslakAc(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            HerkezeAçıkİhaleHizmetAlımıSözleşmeTaslağı s1 = new HerkezeAçıkİhaleHizmetAlımıSözleşmeTaslağı();
            s1.TopLevel = false;
            s1.Dock = DockStyle.Fill;
            s1.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(s1);
            s1.Show();

        }
        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ForeColor == Color.Black)
            {
                renk(e.Node, treeView1);
                switch (e.Node.Name)
                {
                    case "Node24":
                        İhaleİlanıAc(panel1);
                        break;
                    case "Node34":
                        OlurYazısıAc(panel1);
                        break;
                    case "Node35":
                        KomisyonAc(panel1);
                        break;
                    case "Node38":
                        TipYaklasikAc(panel1);
                        break;
                    case "Node39":
                        SatınAlmaAc(panel1);
                        break;
                    case "Node40":
                        İhaleOnayAc(panel1);
                        break;
                    case "Node42":
                        ÖnYeterlilikAc(panel1);
                        break;
                    case "Node43":
                        AlındıBelgesiAc(panel1);
                        break;
                    case "Node44":
                        ZarfAc(panel1);
                        break;
                    case "Node45":
                        DısAc(panel1);
                        break;
                    case "Node46":
                        TutanakAc(panel1);
                        break;
                    case "Node47":
                        İhaleKararıAc(panel1);
                        break;
                    case "Node48":
                        KesinlesenKararAc(panel1);
                        break;
                    case "Node49":
                        İptalAc(panel1);
                        break;
                    case "Node50":
                        SözlesmeDavetAc(panel1);
                        break;
                    case "Node61":
                        Komisyon2Ac(panel1);
                        break;
                    case "Node58":
                        İdariVeTeknikAc(panel1);
                        break;
                    case "Node59":
                        TeknikAc(panel1);
                        break;
                    case "Node60":
                        SözlesmeTaslakAc(panel1);
                        break;


                    default:
                        break;
                }

            }
        }
    }
}