using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True;");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 fr = new Form3();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBLKisiler where HESAPNO=@P1 and SİFRE=@P2",baglanti);
            komut.Parameters.AddWithValue("@P1", mskhesapno.Text);
            komut.Parameters.AddWithValue("@P2",txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 fr = new Form2();
                fr.hesap = mskhesapno.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("HATALI KULLANICI GİRİŞİ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            baglanti.Close();

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
