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
    public partial class KullanıcıBilgileri : DevExpress.XtraEditors.XtraForm
    {
        public KullanıcıBilgileri()
        {
            InitializeComponent();
        }

        private void Label16_Click(object sender, EventArgs e)
        {
            
        }

        private void KullanıcıBilgileri_Load(object sender, EventArgs e)
        {
            label2.Text = KullaniciGirisi.ad.ToString();
            label4.Text = KullaniciGirisi.soyad.ToString();
            label6.Text = KullaniciGirisi.tc.ToString();
            label8.Text = KullaniciGirisi.ünvan.ToString();
            label10.Text = KullaniciGirisi.görev.ToString();
            label12.Text = KullaniciGirisi.mail.ToString();
            label14.Text = KullaniciGirisi.kadi.ToString();
        }
    }
}