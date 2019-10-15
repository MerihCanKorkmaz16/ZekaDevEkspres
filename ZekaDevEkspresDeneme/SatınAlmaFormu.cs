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
    public partial class SatınAlmaFormu : DevExpress.XtraEditors.XtraForm
    {

        public SatınAlmaFormu()
        {
            InitializeComponent();

        }
        private void TekPanelBirçokFormAçma()
        {
            try
            {
                TreeNode TNode = new TreeNode();
                TNode = treeView1.SelectedNode;
                string secilenNode = TNode.Name;
                if (secilenNode != null)
                {
                    if (secilenNode == "Düğüm1")
                    {
                        HerkezeAçıkİhaleHizmetAlımı herkezeacıkihalehizmetalımı = new HerkezeAçıkİhaleHizmetAlımı();
                        herkezeacıkihalehizmetalımı.Show();
                    }
                    if (secilenNode == "Düğüm2")
                    {
                        HerkezeAçıkİhaleYapımİşi herkezacıksözlesmeyapımisi = new HerkezeAçıkİhaleYapımİşi();
                        herkezacıksözlesmeyapımisi.Show();
                    }
                    if (secilenNode == "Düğüm21")
                    {
                        HerkezeAçıkİhaleMalAlımı herkezeacıkihalemalalimi = new HerkezeAçıkİhaleMalAlımı();
                        herkezeacıkihalemalalimi.Show();
                    }
                    
                    if (secilenNode == "Node0")
                    {
                        DoğrudanTeminSözleşmeliYapımİşiFormu doğrudanteminyapımişi = new DoğrudanTeminSözleşmeliYapımİşiFormu();
                        doğrudanteminyapımişi.Show();
                    }
                    if (secilenNode == "Düğüm35")
                    {
                        PazarlıkÜsülüİhaleHizmetAlımı pazarlıküsülühizmetalımı = new PazarlıkÜsülüİhaleHizmetAlımı();
                        pazarlıküsülühizmetalımı.Show();
                    }
                    if (secilenNode == "Node1")
                    {
                        DoğrudanTeminPeriyodikBakımFormu periyodik = new DoğrudanTeminPeriyodikBakımFormu();
                        periyodik.Show();
                    }
                    if (secilenNode == "Düğüm36")
                    {
                        PazarlıkÜsülüİhaleYapımİsi pazarlıküsülüihaleyapımisi = new PazarlıkÜsülüİhaleYapımİsi();
                        pazarlıküsülüihaleyapımisi.Show();
                    }
                    if (secilenNode == "Düğüm37")
                    {
                        PazarlıkÜsülüİhaleAcıkİhaleYapılamayan pazarlıküsülüihaleacıkihaleyapılamayan = new PazarlıkÜsülüİhaleAcıkİhaleYapılamayan();
                        pazarlıküsülüihaleacıkihaleyapılamayan.Show();
                    }
                    if (secilenNode == "Düğüm39")
                    {
                        Belli_İstekliler_Hizmet_Alımı belliisteklilerhizmetalimi = new Belli_İstekliler_Hizmet_Alımı();
                        belliisteklilerhizmetalimi.Show();
                    }
                    if (secilenNode == "Düğüm40")
                    {
                        BelliİsteklilerYapımİşi belliİsteklileryapımişi = new BelliİsteklilerYapımİşi();
                        belliİsteklileryapımişi.Show();
                    }

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        
    }
        private void TekPanelBirçokSatınAlmaYarımFormAçma()
        {
            try
            {
                TreeNode TNode = new TreeNode();
                TNode = treeView1.SelectedNode;
                string secilenNode = TNode.Name;
                if (secilenNode != null)
                {
                   

                    if (secilenNode == "Node0")
                    {
                        SatınAlmaBilgilendirmeFormu doğrudanteminyapımişi = new SatınAlmaBilgilendirmeFormu();
                        doğrudanteminyapımişi.Show();
                    }
                    
                    }
                    if (secilenNode == "Node1")
                    {
                        DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu periyodik = new DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu();
                        periyodik.Show();
                    }
                   

                }

            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }
        private Form IsActive(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }

            }
            return null;
        }
       private void TreeView1_NodeMouseClick_1(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Name)
            {
                case "Düğüm1":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm2":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm21":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm35":
                    panelAc(SatınAlmaPaneli); break;
                case "Node0":
                    panelAc(SatınAlmaPaneli); break;
                case "Node1":
                    panelAc(SatınAlmaPaneli); break;
                case "Node2":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm36":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm37":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm38":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm39":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm40":
                    panelAc(SatınAlmaPaneli); break;
                case "Düğüm41":
                    panelAc(SatınAlmaPaneli); break;


                default:
                    temizle(); break;
            }
            void temizle()
            {
                SatınAlmaPaneli.Visible = false;
                
            }
            void panelAc(SidePanel pnl)
            {
                temizle();
                pnl.Visible = true;
                pnl.Location = new Point(263, 0);
                pnl.Size = new Size(997, 553);
                pnl.Dock = DockStyle.Fill;
            }
        }
        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            TekPanelBirçokFormAçma();
            SatınAlmaBilgilendirmeFormu.yarımkalandurum = false;
            DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac = 0;
            SatınAlmaBilgilendirmeFormu.satınalmaid = 0;
        }
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            TekPanelBirçokSatınAlmaYarımFormAçma();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            ParasalLimitler para = new ParasalLimitler();
            para.ShowDialog();
        }

    }
}
    

