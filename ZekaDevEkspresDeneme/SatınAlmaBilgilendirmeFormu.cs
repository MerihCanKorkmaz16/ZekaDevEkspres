using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZekaDevEkspresDeneme
{
    public partial class SatınAlmaBilgilendirmeFormu : Form
    {
        public SatınAlmaBilgilendirmeFormu()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            
        }
        public static int kullanıcıid,satınalmaid,sayac;
        public static bool yarımkalandurum = false;

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.doğrudanTeminBilgilendirmeTablosuTableAdapter.Fill(this.zekaDenemeProje1DataSet.DoğrudanTeminBilgilendirmeTablosu);

        }

        private void SatınAlmaBilgilendirmeFormu_FormClosing(object sender, FormClosingEventArgs e)
        {
            yarımkalandurum = false;
        }

        private void SatınAlmaBilgilendirmeFormu_Load(object sender, EventArgs e)
        {
            this.doğrudanTeminBilgilendirmeTablosuTableAdapter.Fill(this.zekaDenemeProje1DataSet.DoğrudanTeminBilgilendirmeTablosu);

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seçilialan = dataGridView1.SelectedCells[0].RowIndex;
            satınalmaid = Convert.ToInt32(dataGridView1.Rows[seçilialan].Cells[0].Value);
            kullanıcıid = Convert.ToInt32(dataGridView1.Rows[seçilialan].Cells[1].Value);
            sayac = Convert.ToInt32(dataGridView1.Rows[seçilialan].Cells[18].Value);
            yarımkalandurum = true;
            DoğrudanTeminSözleşmeliYapımİşiFormu yapım = new DoğrudanTeminSözleşmeliYapımİşiFormu();
            yapım.Show();
           
        }
    }
}
