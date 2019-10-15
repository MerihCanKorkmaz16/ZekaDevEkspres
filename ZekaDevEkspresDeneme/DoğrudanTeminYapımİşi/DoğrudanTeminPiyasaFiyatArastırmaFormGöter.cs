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
    public partial class DoğrudanTeminPiyasaFiyatArastırmaFormGöster : DevExpress.XtraEditors.XtraForm
    {
        public DoğrudanTeminPiyasaFiyatArastırmaFormGöster()
        {
            InitializeComponent();
        }
        byte[] VeriTabanindenGelenBytes;
        byte[] VeriTabanindenGelenBytes2;
        public static string ExeDosyaYolu = Application.StartupPath.ToString();
        string path11 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\Piyasa Fiyat Araştırması Tutanağı.docx";
        string path12 = ExeDosyaYolu + "\\Doğrudan Temin Üsülü Yapım İşi Yapım İşi\\Piyasa Fiyat Araştırma Tutanağı\\Piyasa Fiyat Araştırması Tutanağı .docx";

        void VerileriGetir()
        {
            if (SatınAlmaBilgilendirmeFormu.yarımkalandurum == true)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminPiyasaFiyatArastırmaTutanağı where id = '" + SatınAlmaBilgilendirmeFormu.kullanıcıid + "' and SatınAlma_id = '" + SatınAlmaBilgilendirmeFormu.satınalmaid + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                        VeriTabanindenGelenBytes2 = (byte[])dr["İkinciDosya"];
                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path11, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path11);
                        }
                    }
                    if (VeriTabanindenGelenBytes2 != null)
                    {
                        if (VeriTabanindenGelenBytes2.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path12, VeriTabanindenGelenBytes2);
                            System.Threading.Thread.Sleep(200);
                            richEditControl2.LoadDocument(path12);
                        }
                    }
                    dr.Close();
                    connn.Close();

                }

            }
            else if (DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.yarımkalansürecsayac > 2)
            {
                using (SqlConnection connn = new SqlConnection(DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.conn))
                {
                    connn.Open();
                    SqlCommand komut = new SqlCommand();
                    komut.Connection = connn;
                    komut.CommandText = ("select * from  DoğrudanTeminPiyasaFiyatArastırmaTutanağı where id = '" + 2 + "' and SatınAlma_id = '" + DoğrudanTeminÜsülüSözleşmeliYapımİşiİdariVeTeknikŞartName.SatınAlma_id + "'");
                    SqlDataReader dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        VeriTabanindenGelenBytes = (byte[])dr["Dosya"];
                        VeriTabanindenGelenBytes2 = (byte[])dr["İkinciDosya"];
                    }
                    if (VeriTabanindenGelenBytes != null)
                    {
                        if (VeriTabanindenGelenBytes.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path11, VeriTabanindenGelenBytes);
                            System.Threading.Thread.Sleep(200);
                            richEditControl1.LoadDocument(path11);
                        }
                    }
                    if (VeriTabanindenGelenBytes2 != null)
                    {
                        if (VeriTabanindenGelenBytes2.Length > 0)
                        {
                            System.IO.File.WriteAllBytes(path11, VeriTabanindenGelenBytes2);
                            System.Threading.Thread.Sleep(200);
                            richEditControl2.LoadDocument(path11);
                        }
                    }
                    dr.Close();
                    connn.Close();

                }

                //}
            }
        }
        private void DoğrudanTeminPiyasaFiyatArastırmaFormGöster_Load(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(300);
            VeriAlThread.RunWorkerAsync();
        }

        private void VeriAlThread_DoWork(object sender, DoWorkEventArgs e)
        {
            VerileriGetir();
        }

        private void DoğrudanTeminPiyasaFiyatArastırmaFormGöster_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}