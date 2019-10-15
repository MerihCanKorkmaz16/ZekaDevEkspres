using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ZekaMalAlimForm
{
    public partial class ParasalLimit : DevExpress.XtraEditors.XtraForm
    {
        public ParasalLimit()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-KFN5MJ2H\\AJANSSQL;Initial Catalog=ParasalLimitler; Integrated Security = True ");
        
         //   User ID = sa; Password = changeme
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter;
        DataTable table = new DataTable();
        bool yilKontrol = false;
        bool yilUpdateKontrol = false;

        double[] fiyatlar;
        double[] ufeler;

        //DataTable ufeTable = new DataTable();
        //DataTable karmaTable = new DataTable();

        //private void initUfeTable()
        //{
        //    ufeTable.Columns.Add("Yil", typeof(double));
        //    ufeTable.Columns.Add("Ufe Orani", typeof(decimal));

        //    string connString = "Data Source=LAPTOP-KFN5MJ2H\\AJANSSQL; Initial Catalog = ParasalLimitler; User ID = sa; Password = changeme";
        //    string query = "select Yil, Ufe as [Ufe Orani] from Ufe";

        //    SqlConnection conn = new SqlConnection(connString);
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    conn.Open();
        //    //Create a data reader and Execute the command
        //    SqlDataReader dataReader = cmd.ExecuteReader();
        //    double rowId = 0;
        //    while (dataReader.Read())
        //    {
        //        ufeTable.Rows.Add();
        //        ufeTable.Rows[rowId][0] = dataReader[0];
        //        ufeTable.Rows[rowId][1] = dataReader[1];
        //        rowId++;
        //    }
        //    dataReader.Close();
        //    conn.Close();
        //}

        //private void initKarmaTable()
        //{
        //    karmaTable.Columns.Add("Yil", typeof(double));
        //    karmaTable.Columns.Add("Ufe Orani", typeof(decimal));
        //    string connString = "Data Source=LAPTOP-KFN5MJ2H\\AJANSSQL; Initial Catalog = ParasalLimitler; User ID = sa; Password = changeme";
        //    string query = "select Yil, Ufe as [Ufe Orani] from Ufe ";

        //    SqlConnection conn = new SqlConnection(connString);
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    conn.Open();
        //    //Create a data reader and Execute the command
        //    SqlDataReader dataReader = cmd.ExecuteReader();
        //    double rowId = 0;
        //    while (dataReader.Read())
        //    {
        //        karmaTable.Rows.Add();
        //        karmaTable.Rows[rowId][0] = dataReader[0];
        //        Console.WriteLine(dataReader[1]);
        //        karmaTable.Rows[rowId][1] = dataReader[1];
        //        rowId++;
        //    }
        //    dataReader.Close();
        //    conn.Close();
        //}


        private void sütunCek()
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
        private void satirCek()
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
        private void zamliFiyatlar()
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
        private void zamCek()
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

        private void yilControl()
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
        private void yillarTablosu()
        {
            DataTable yillarTable = new DataTable();
            yillarTable.Clear();
            con.Open();
            adapter = new SqlDataAdapter("select * from Ufe", con);
            adapter.Fill(yillarTable);
            ufeDataGridView.DataSource = yillarTable;
            con.Close();
        }
        private void yilContolUpdate()
        {
            con.Open();
            yilUpdateKontrol = false;
            int i = 0;
            cmd = new SqlCommand("select Yil from Ufe where id= "+ ufeDataGridView.CurrentRow.Cells[0].Value + "", con);
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




        private void EkleButton_Click(object sender, EventArgs e)
        {
            if (ufeTextBox.Text != "")
            {
                yilControl();
                if (!yilKontrol)
                {
                    con.Open();
                    cmd = new SqlCommand("insert into Ufe (Yil,Ufe) values ("+Convert.ToInt32(yilTextBox.Text)+"," + Convert.ToDecimal(ufeTextBox.Text) + ")", con);
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
                }
                else
                {
                    MessageBox.Show("EKLEMEK İSTEDİĞİNİZ YIL MEVCUT");
                }

            }
            else
            {
                MessageBox.Show("Zam oranı boş bırakılamaz!");
            }
        }

        private void GuncelleButton_Click(object sender, EventArgs e)
        {
            if (ufeTextBox.Text != "")
            {
                yilContolUpdate();
                if (yilUpdateKontrol)
                {
                    con.Open();
                    cmd = new SqlCommand("update Ufe set  Yil=" + Convert.ToInt32(yilTextBox.Text) + ",Ufe=" + Convert.ToDecimal(ufeTextBox.Text) + " where id=" + ufeDataGridView.CurrentRow.Cells[0].Value + "", con);
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

                }
                else
                {
                    MessageBox.Show("Güncellemek istediğiniz yıl tabloda mevcut olmayabilir veya seçili olmayabilir!");
                }
            }
            else
            {
                MessageBox.Show("Zam oranı boş bırakılamaz!");
            }
        }

        private void ParasalLimit_Load(object sender, EventArgs e)
        {
            sütunCek();
            satirCek();
            karmaDataGridView.DataSource = table;
            zamCek();
            zamliFiyatlar();
            yillarTablosu();

            //initUfeTable();
            //ufeDataGridView.DataSource = ufeTable;
            //initKarmaTable();
            //karmaDataGridView.DataSource = karmaTable;
        }

        private void UfeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yilTextBox.Text = ufeDataGridView.CurrentRow.Cells[1].Value.ToString();
            ufeTextBox.Text = ufeDataGridView.CurrentRow.Cells[2].Value.ToString();
            guncelleButton.Enabled = true;
        }
    }
}