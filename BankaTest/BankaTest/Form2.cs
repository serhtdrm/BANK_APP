using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaTest
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True;");

        void bakiye()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select BAKIYE from TBLHesap where HESAPNO="+hesap, baglanti);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                lblbakiye.Text = rd[0].ToString();
            }
            baglanti.Close();
        }
        void gelen()
        {
            SqlCommand komut = new SqlCommand("EXECUTE GELEN @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", lblhesapno.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }
        void giden()
        {
            SqlCommand komut1 = new SqlCommand("EXECUTE GIDEN @P1", baglanti);
            komut1.Parameters.AddWithValue("@P1", lblhesapno.Text);
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }
        public string hesap;
        private void Form2_Load(object sender, EventArgs e)
        {
            lblhesapno.Text = hesap;
            baglanti.Open();
            
            SqlCommand komut = new SqlCommand("Select *from TBLKisiler where HESAPNO="+hesap,baglanti);
            komut.Parameters.AddWithValue("@P1",hesap);
            SqlDataReader rd = komut.ExecuteReader();
            while (rd.Read())
            {
                lbladsoyad.Text = rd[1] + " " + rd[2];
                lbltc.Text = rd[3].ToString();
                lbltelefon.Text = rd[4].ToString();
            }
            baglanti.Close();
            bakiye();
            gelen();
            giden();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {    //gonderilen hesabın para artışı
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLHareket(GONDEREN,ALICI,TUTAR) values(@P1,@P2,@P3)",baglanti);
            komut.Parameters.AddWithValue("@P1", lblhesapno.Text);
            komut.Parameters.AddWithValue("@P2", mskhesapno.Text);
            komut.Parameters.AddWithValue("@P3",Convert.ToDecimal( txttutar.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İŞLEM GERÇEKLEŞTİRİLDİ");
            bakiye();
            gelen();
            giden();

            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        private void lblbakiye_Click(object sender, EventArgs e)
        {

        }
    }
}
