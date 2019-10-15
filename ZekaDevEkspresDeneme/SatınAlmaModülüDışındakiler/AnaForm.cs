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
    public partial class AnaForm : DevExpress.XtraEditors.XtraForm
    {
        public AnaForm()
        {
            InitializeComponent();
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

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(KullanıcıBilgileri));
            if (form == null)
            {
                KullanıcıBilgileri f = new KullanıcıBilgileri();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void BarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(SatınAlmaFormu));
            if (form == null)
            {
                SatınAlmaFormu f1 = new SatınAlmaFormu();
                f1.MdiParent = this;
                f1.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            if (KullaniciGirisi.yetkilendirme == "Kullanıcı ")
            {
                barButtonItem2.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            
          
        }

        private void BarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = IsActive(typeof(YöneticiAyarları));
            if (form == null)
            {
                YöneticiAyarları f2 = new YöneticiAyarları();
                f2.MdiParent = this;
                f2.Show();
            }
            else
            {
                form.Activate();
            }
        }
    }
}