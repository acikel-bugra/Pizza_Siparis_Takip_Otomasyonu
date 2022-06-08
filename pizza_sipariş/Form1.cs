using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.Net.Mail;

namespace pizza_siparis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Elif\\Documents\\pizzatakip.mdb");

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
          
            /*if (textBox3.Text != onaykodu)
            {
                MessageBox.Show("Hata olustu. ");
            }*/
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Bütün alanları doldurun.");
            }
            else
            {
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("select * from garsonbilgi where kullanıcıadı='" + textBox1.Text + "'", baglanti);
                OleDbDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read() == true)
                {
                    if (textBox1.Text == okuyucu["kullanıcıadı"].ToString() && textBox2.Text == okuyucu["sifre"].ToString())
                    {
                        MessageBox.Show("Hoşgeldiniz Sayın " + okuyucu["adsoyad"].ToString());
                        Form form = new anamenu();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Giriş bilgilerinizi kontrol edin!.");
                    }
                }
                else
                {
                    MessageBox.Show("Giriş bilgilerinizi kontrol edin!.");
                }
                baglanti.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        Random rnd = new Random();
        string onaykodu;
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into garsonbilgi (kullanıcıadı,sifre,adsoyad,mail) values ('" + textBox8.Text + "','" + textBox7.Text + "','" + textBox6.Text + "','" + textBox3.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Üye olma işlemi tamamlandı.");

            onaykodu = rnd.Next(100, 999).ToString();
            MailMessage sms = new MailMessage("elifgullac3@gmail.com", textBox3.Text,  "GÜVENLİK KODU İŞLEMİ", "güvenlik kodu=" + onaykodu);
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("elifgullac3@gmail.com", "E637g76614."); 
            smtpClient.Send(sms);
            baglanti.Close();
         }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
