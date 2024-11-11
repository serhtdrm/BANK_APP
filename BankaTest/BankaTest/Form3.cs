using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BankaTest
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=SerhatDemir\SQLEXPRESS;Initial Catalog=DbBankaTest;Integrated Security=True;");
      private void btnhesapno_Click(object sender, EventArgs e)
        {
         

            }


        
        private void btnKaydet_Click(object sender, EventArgs e)
        {try { 
                baglanti.Open();

                Random rastegele = new Random();
                var sayi = rastegele.Next(100000, 1000000);
                SqlCommand komut = new SqlCommand("insert into TBLKisiler(AD,SOYAD,TC,TELEFON,HESAPNO,SİFRE) values(@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
                komut.Parameters.AddWithValue("@P1", txtAd.Text);
                komut.Parameters.AddWithValue("@P2", txtSoyad.Text);
                komut.Parameters.AddWithValue("@P3", msktc.Text);
                komut.Parameters.AddWithValue("@P4", msktelefon.Text);
                komut.Parameters.AddWithValue("@P5", sayi);
                komut.Parameters.AddWithValue("@P6", txtSifre.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                txtAd.Text = "";
                txtSoyad.Text = "";
                msktc.Text = "";
                msktelefon.Text = "";
                mskhesapno.Text = "";
                txtSifre.Text = "";
                baglanti.Open();
                SqlCommand komut2 = new SqlCommand("insert into TBLHesap(HESAPNO,BAKIYE) values(@P1,@P2)", baglanti);
                komut2.Parameters.AddWithValue("@P1", sayi);
                komut2.Parameters.AddWithValue("@P2", 0.000);
                komut2.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Müşteri Bilgileri Kaydedildi!\nHESAP NUMARANIZ: "+sayi);
                this.Close();
                this.Close();


            }
            
            
            catch {
                MessageBox.Show("HESAP NUMARANIZDA SORUN VAR TEKRAR DENEYİN!");
            
            }
         
        
          
          
            //hesap tablosuna bilgileri kaydetme
          
        }

     

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            this.Hide();
            fr.Show();
           
        }
    }
}
