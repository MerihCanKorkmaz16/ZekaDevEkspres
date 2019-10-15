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
    public partial class DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu()
        {
            InitializeComponent();
        }
        public static int satınalmaid;
        public static int kullanıcıid;
        public static bool yarımkalansürec;
        private void DoğrudanTeminPeriyodikSatınAlmaBilgilendirmeFormu_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'zekaDenemeProje1DataSet3.DoğrudanTeminPeriyodikBilgilendirmeTablosu' table. You can move, or remove it, as needed.
            this.doğrudanTeminPeriyodikBilgilendirmeTablosuTableAdapter.Fill(this.zekaDenemeProje1DataSet3.DoğrudanTeminPeriyodikBilgilendirmeTablosu);

            dataGridView1.ClearSelection();
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                satınalmaid = Convert.ToInt32(row.Cells[0].Value);
                kullanıcıid = Convert.ToInt32(row.Cells[1].Value);
                yarımkalansürec = true;
                DoğrudanTeminPeriyodikBakımFormu bakım = new DoğrudanTeminPeriyodikBakımFormu();
                bakım.Show();
            }
        }
    }
}