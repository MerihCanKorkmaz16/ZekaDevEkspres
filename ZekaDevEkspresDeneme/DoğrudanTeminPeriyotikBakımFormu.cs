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
    public partial class DoğrudanTeminPeriyodikBakımFormu : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPeriyodikBakımFormu()
        {
            InitializeComponent();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

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

        private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.ForeColor == Color.Black)
            {
                renk(e.Node, treeView1);
                switch (e.Node.Name)
                {
                    case "Node0":
                        İsAdiEkleme(panel1);
                        break;
                    case "Node2":
                        FirmaTeklifEkleme(panel1);
                        break;
                    case "Node3":
                        FirmaSec(panel1);
                        break;
                    case "Node4":
                        EvrakEkleme(panel1); ; break;
                    case "Node31":
                        ServisFormuEkleme(panel1); ; break;


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
        private static void İsAdiEkleme(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminPeriyodikBakımİsSecmeFormu işEkleme = new DoğrudanTeminPeriyodikBakımİsSecmeFormu();
            işEkleme.TopLevel = false;
            işEkleme.Dock = DockStyle.Fill;
            işEkleme.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(işEkleme);
            işEkleme.Show();
        }
        private static void FirmaTeklifEkleme(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminPeriyodikFirmaEkleme firma = new DoğrudanTeminPeriyodikFirmaEkleme();
            firma.TopLevel = false;
            firma.Dock = DockStyle.Fill;
            firma.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(firma);
            firma.Show();
        }
        private static void FirmaSec(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama firmaSec = new DoğrudanTeminPeriyodikFirmaTeklifSecmeVeSözlesmeHazırlama();
            firmaSec.TopLevel = false;
            firmaSec.Dock = DockStyle.Fill;
            firmaSec.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(firmaSec);
            firmaSec.Show();
        }

        private static void EvrakEkleme(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DoğrudanTeminPeriyodikEvrakYükleme evrak = new DoğrudanTeminPeriyodikEvrakYükleme();
            evrak.TopLevel = false;
            evrak.Dock = DockStyle.Fill;
            evrak.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(evrak);
            evrak.Show();
        }
        private static void ServisFormuEkleme(Panel pnl)
        {
            temizle(pnl);
            pnl.Visible = true;
            pnl.Location = new Point(263, 0);
            pnl.Size = new Size(997, 553);
            pnl.Dock = DockStyle.Fill;
            DogrudanTeminPeriyodikServisBakımFormu servis = new DogrudanTeminPeriyodikServisBakımFormu();
            servis.TopLevel = false;
            servis.Dock = DockStyle.Fill;
            servis.FormBorderStyle = FormBorderStyle.None;
            pnl.Controls.Add(servis);
            servis.Show();
        }
        private void DoğrudanTeminPeriyotikBakımFormu_Load(object sender, EventArgs e)
        {
           
        }
    }
}