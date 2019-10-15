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
using DevExpress.XtraGrid.Views.Grid;


namespace ZekaDevEkspresDeneme
{
    public partial class YöneticiAyarları : DevExpress.XtraEditors.XtraForm
    {
        public YöneticiAyarları()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = null;


        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                sifretextbox.UseSystemPasswordChar = false;
                sifretekrartext.UseSystemPasswordChar = false;
            }

            else
            {
                sifretextbox.UseSystemPasswordChar = true;
                sifretekrartext.UseSystemPasswordChar = true;
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            
            baglanti = new SqlConnection(DoğrudanTeminSözleşmeliYapımİşiFormu.conn);
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select TC from kullanicilar where TC = '" + tctextbox.Text + "'");
            komut.Connection = baglanti;
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                XtraMessageBox.Show("TC kimlik sistemimizde mevcut kontrol ediniz.", "UYARI! ");
                baglanti.Close();
                dr.Close();
                baglanti.Dispose();
            }

            else
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminSözleşmeliYapımİşiFormu.conn))
                {
                    connn.Open();
                    SqlCommand komut1 = new SqlCommand("insert into kullanicilar (Ad,Soyad,TC,Ünvan,Görev,Mail,Kullanıcı_adi,Kullanici_sifre,yetki) values ('" + adtextbox.Text.ToString() + "','" + soyadtextbox.Text.ToString() + "', '" + tctextbox.Text.ToString() + "','" + ünvantextbox.Text.ToString() + "','" + görevtextbox.Text.ToString() + "' , '" + mailtextbox.Text.ToString() + "' , '" + kullanicitextbox.Text.ToString() + "' , '" + sifretextbox.Text.ToString() + "','" + yetkicombobox.SelectedItem.ToString() + "')", connn);
                    komut1.ExecuteNonQuery();
                    XtraMessageBox.Show("Kayıt Başarılı", "Başarılı ! ");
                    //MessageBox.Show("Kayıt Başarılı..", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    kullanicitextbox.Text = "";
                    sifretextbox.Text = "";
                    sifretekrartext.Text = "";
                    tctextbox.Text = "";
                    görevtextbox.Text = "";
                    adtextbox.Text = "";
                    soyadtextbox.Text = "";
                    ünvantextbox.Text = "";
                    adtextbox.Text = "";
                    mailtextbox.Text = "";

                    connn.Close();
                    
                }

            }


        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                e.Handled = false;//eğer rakamsa  yazdır.
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma

            }
            
        }

        private void KayıtFormu_Load(object sender, EventArgs e)
        {
            tctextbox.MaxLength = 11;
            // TODO: Bu kod satırı 'zekaDenemeProje1DataSet2.kullanicilar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            gridView1.ClearSelection();
           
        }

        private void TextEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void TextEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void TextEdit4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }


        private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }

        private void GridControl1_Click(object sender, EventArgs e)
        {

        }

       
       
        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Kullanıcı Silmek istediğinize emin misiniz ?", "Başarılı ! ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminSözleşmeliYapımİşiFormu.conn))
                {
                   
                    connn.Open();
                    SqlCommand komut = new SqlCommand("DELETE FROM kullanicilar WHERE id=@id");
                    komut.Connection = connn;
                    komut.Parameters.AddWithValue("@id", gridView1.GetFocusedRowCellValue("id").ToString());
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kullanıcı başarıyla silindi.", "Başarılı !");
                    connn.Close();
                    
                }


            }
        }

        private void SimpleButton1_Click_1(object sender, EventArgs e)
        {
            if (adtextbox.Text == "" || soyadtextbox.Text == "" || tctextbox.Text == "" || ünvantextbox.Text == "" || görevtextbox.Text == "" || mailtextbox.Text == "" || kullanicitextbox.Text == "" || sifretextbox.Text == "" || yetkicombobox.Text == "")
            {
                XtraMessageBox.Show("Bilgisini Güncellemek istediğiniz Kullanıcıyı seçiniz.", "Dikat edin ! ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminSözleşmeliYapımİşiFormu.conn))
                {
                    
                    connn.Open();
                    SqlCommand komut = new SqlCommand("update kullanicilar set Ad='" + adtextbox.Text + "',Soyad='" + soyadtextbox.Text + "',TC='" + tctextbox.Text + "',Ünvan='" + ünvantextbox.Text + "',Görev='" + görevtextbox.Text + "',Mail='" + mailtextbox.Text + "',Kullanıcı_adi='" + kullanicitextbox.Text + "',Kullanici_sifre='" + sifretextbox.Text + "', yetki = '" + yetkicombobox.SelectedItem.ToString() + "' where TC= '" + tctextbox.Text + "'");
                    komut.Connection = connn;
                    komut.ExecuteNonQuery();
                    XtraMessageBox.Show("Kullanıcı başarıyla güncellenmiştir", "Başarılı ! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    connn.Close();
                }

            }
        }

       

        private void GridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {

                string ad1 = dr[1].ToString();
                string soyad1 = dr[2].ToString();
                string tc1 = dr[3].ToString();
                string ünvan1 = dr[4].ToString();
                string görev1 = dr[5].ToString();
                string mail1 = dr[6].ToString();
                string kullanici1 = dr[7].ToString();
                string sifre1 = dr[8].ToString();
                string yetki1 = dr[9].ToString();

                adtextbox.Text = ad1;
                soyadtextbox.Text = soyad1;
                tctextbox.Text = tc1;
                ünvantextbox.Text = ünvan1;
                görevtextbox.Text = görev1;
                mailtextbox.Text = mail1;
                kullanicitextbox.Text = kullanici1;
                sifretextbox.Text = sifre1;
                yetkicombobox.Text = yetki1;
                sifretekrartext.Text = sifre1;

            }

        }
    }
}   