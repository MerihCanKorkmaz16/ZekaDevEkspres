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
    public partial class ParasalLimitler : DevExpress.XtraEditors.XtraForm
    {
        public ParasalLimitler()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection("Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ParasalLimitler;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        public DataTable table = new DataTable();
        bool yilKontrol = false;
        bool yilUpdateKontrol = false;

        double[] fiyatlar;
        double[] ufeler;
        decimal pazarlikUsulu122f;
        decimal pazarlikUsulu122g;
        decimal pazarlikUsulu3;
        decimal dogrudanTemin131b;
        decimal dogrudanTemin5;
        decimal teminatlar;

        void sütunCek()
        {
            table.Clear();
            table.Columns.Clear();
            con.Open();
            table.Columns.Add("Parasal Limit Turu");
            table.Columns.Add("Madde Icerigi");
            table.Columns.Add("2009 Fiyatı");
            cmd = new SqlCommand("select Yil from Ufe", con);

            reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                table.Columns.Add(reader[i].ToString() + " yılı fiyatı");
            }
            con.Close();
        }
        void satirCek()
        {
            con.Open();

            cmd = new SqlCommand("select ParasalLimitinTuru, MaddeIcerigi, Fiyat from Degisken", con);
            reader = cmd.ExecuteReader();
            object[] degiskenler = new object[3];
            while (reader.Read())
            {
                degiskenler[0] = reader["ParasalLimitinTuru"];
                degiskenler[1] = reader["MaddeIcerigi"];
                degiskenler[2] = reader["Fiyat"];
                table.Rows.Add(degiskenler);
            }
            con.Close();
        }
        public void zamliFiyatlar()
        {
            fiyatlar = new double[karmaDataGridView.ColumnCount - 3];
            for (int i = 0; i < karmaDataGridView.RowCount - 1; i++)
            {
                fiyatlar[0] = Convert.ToDouble(karmaDataGridView.Rows[i].Cells[2].Value);
                int fiyatSıra = 0;
                for (int j = 0; j < karmaDataGridView.ColumnCount - 3; j++)
                {
                    if (j == 0)
                        fiyatSıra = 0;
                    else
                        fiyatSıra = j - 1;
                    fiyatlar[j] = fiyatlar[fiyatSıra] * (ufeler[j] + 100) / 100;
                    karmaDataGridView.Rows[i].Cells[3 + j].Value = Math.Round(fiyatlar[j], 2); ;
                }
            }
        }
        void zamCek()
        {
            con.Open();
            ufeler = new double[karmaDataGridView.ColumnCount - 3];
            cmd = new SqlCommand("select Ufe from Ufe", con);
            reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                ufeler[i] = Convert.ToDouble(reader["ufe"]);
                i++;
            }
            con.Close();
        }
        void yilControl()
        {
            con.Open();
            yilKontrol = false;
            int i = 0;
            cmd = new SqlCommand("select Yil from Ufe", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32(yilTextBox.Text) == Convert.ToInt32(reader[0]))
                {
                    yilKontrol = true;
                    con.Close();
                    break;
                }
                i++;
            }
            con.Close();
        }
        void yillarTablosu()
        {
            DataTable yillarTable = new DataTable();
            yillarTable.Clear();
            con.Open();
            adapter = new SqlDataAdapter("select * from Ufe", con);
            adapter.Fill(yillarTable);
            ufeDataGridView.DataSource = yillarTable;
            con.Close();
        }
        void yilContolUpdate()
        {
            con.Open();
            yilUpdateKontrol = false;
            int i = 0;
            cmd = new SqlCommand("select Yil from Ufe where id= " + ufeDataGridView.CurrentRow.Cells[0].Value + "", con);
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (Convert.ToInt32(yilTextBox.Text) == Convert.ToInt32(reader[0]))
                {
                    yilUpdateKontrol = true;
                    con.Close();
                    break;
                }
                i++;
            }
            con.Close();
        }
        private void GuncelleButton_Click(object sender, EventArgs e)
        {
            if (ufeTextBox.Text != "")
            {
                yilContolUpdate();
                if (yilUpdateKontrol)
                {
                    con.Open();
                    cmd = new SqlCommand("update Ufe set  Yil=@Yil,Ufe=@Ufe where id=" + ufeDataGridView.CurrentRow.Cells[0].Value + "", con);
                    cmd.Parameters.AddWithValue("@Yil", yilTextBox.Text);
                    cmd.Parameters.AddWithValue("@Ufe", Convert.ToDecimal(ufeTextBox.Text));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    sütunCek();
                    satirCek();
                    karmaDataGridView.DataSource = table;
                    zamCek();
                    zamliFiyatlar();
                    yillarTablosu();
                    ufeTextBox.Clear();
                    yilTextBox.Clear();
                    sonDegerCek();
                    SonDegeriVeritabaninaKaydet();

                }
                else
                {
                    XtraMessageBox.Show("Güncellemek istediğiniz yıl tabloda mevcut olmayabilir veya seçili olmayabilir!");
                }
            }
            else
            {
                XtraMessageBox.Show("Zam oranı boş bırakılamaz!");
            }
        }
        public void sonDegerCek()
        {
            int a = karmaDataGridView.ColumnCount;
            pazarlikUsulu122f = Convert.ToDecimal(karmaDataGridView.Rows[0].Cells[a - 1].Value);
            pazarlikUsulu122g = Convert.ToDecimal(karmaDataGridView.Rows[1].Cells[a - 1].Value);
            pazarlikUsulu3 = Convert.ToDecimal(karmaDataGridView.Rows[2].Cells[a - 1].Value);
            dogrudanTemin131b = Convert.ToDecimal(karmaDataGridView.Rows[3].Cells[a - 1].Value);
            dogrudanTemin5 = Convert.ToDecimal(karmaDataGridView.Rows[4].Cells[a - 1].Value);
            teminatlar = Convert.ToDecimal(karmaDataGridView.Rows[5].Cells[a - 1].Value);
            
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("Silmek istiyor musunuz?", "Basarili", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection con = new SqlConnection("Data Source=CASPER\\SQLEXPRESS1;Initial Catalog=ParasalLimitler;Integrated Security=True "))
                {
                    con.Open();
                    SqlCommand komut = new SqlCommand("Delete from Ufe where id=@id");
                    komut.Connection = con;
                    komut.Parameters.AddWithValue("@id", ufeDataGridView.CurrentRow.Cells[0].Value);
                    komut.ExecuteNonQuery();
                    con.Close();
                    sütunCek();
                    satirCek();
                    karmaDataGridView.DataSource = table;
                    zamCek();
                    zamliFiyatlar();
                    yillarTablosu();
                    ufeTextBox.Clear();
                    yilTextBox.Clear();
                    sonDegerCek();
                    SonDegeriVeritabaninaKaydet();
                }
            }
        }
        public void UfeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yilTextBox.Text = ufeDataGridView.CurrentRow.Cells[1].Value.ToString();
            ufeTextBox.Text = ufeDataGridView.CurrentRow.Cells[2].Value.ToString();
            guncelleButton.Enabled = true;
        }
        private void EkleButton_Click(object sender, EventArgs e)
        {
            if (ufeTextBox.Text != "" && yilTextBox.Text !="")
            {
                yilControl();
                if (!yilKontrol)
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Ufe (Yil,Ufe) values (@Yil,@Ufe)", con);
                    cmd.Parameters.AddWithValue("Yil",yilTextBox.Text);
                    cmd.Parameters.AddWithValue("Ufe", Convert.ToDecimal(ufeTextBox.Text));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    sütunCek();
                    satirCek();
                    karmaDataGridView.DataSource = table;
                    zamCek();
                    zamliFiyatlar();
                    yillarTablosu();
                    ufeTextBox.Clear();
                    yilTextBox.Clear();
                    sonDegerCek();
                    SonDegeriVeritabaninaKaydet();
                }
                else
                {
                    XtraMessageBox.Show("EKLEMEK İSTEDİĞİNİZ YIL MEVCUT");
                }
            }
            else if(ufeTextBox.Text == "" && yilTextBox.Text != "")
            {
                XtraMessageBox.Show("Ufe Alanı Boş bırakılamaz!");
                return;
            }
            else if (yilTextBox.Text == "" && ufeTextBox.Text != "")
            {
                XtraMessageBox.Show("Yıl Alanı Boş bırakılamaz!");
                return;
            }
            else
            {
                XtraMessageBox.Show("Yıl Ve Üfe Oranı Kısmı Boş Bırakılamaz");
                return;
            }

        }
        void SonDegeriVeritabaninaKaydet()
        {
            cmd = new SqlCommand("update SonDegerTablosu  set ID =@ID,ParasalLimitinTuru2f=@ParasalLimitinTuru2f ,ParasalLimitinTuru2g=@ParasalLimitinTuru2g,ParasalLimitinTuru3 = @ParasalLimitinTuru3,[ParasalLimitinTuru13(1b)]=@a,ParasalLimitinTuru5= @ParasalLimitinTuru5,ParasalLimitinTuruTeminatlar=@ParasalLimitinTuruTeminatlar where ID=31", con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", 31);
            cmd.Parameters.AddWithValue("@ParasalLimitinTuru2f", pazarlikUsulu122f);
            cmd.Parameters.AddWithValue("@ParasalLimitinTuru2g", pazarlikUsulu122g);
            cmd.Parameters.AddWithValue("@ParasalLimitinTuru3", pazarlikUsulu3);
            cmd.Parameters.AddWithValue("@a", dogrudanTemin131b);
            cmd.Parameters.AddWithValue("@ParasalLimitinTuru5", dogrudanTemin5);
            cmd.Parameters.AddWithValue("@ParasalLimitinTuruTeminatlar", teminatlar);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void ParasalLimitler_Load(object sender, EventArgs e)
        {
            sütunCek();
            satirCek();
            karmaDataGridView.DataSource = table;
            zamCek();
            zamliFiyatlar();
            yillarTablosu();
        }

        private void YilTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void UfeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            if (e.KeyChar== ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }
    }
}