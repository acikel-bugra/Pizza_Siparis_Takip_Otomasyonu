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

namespace pizza_siparis
{
    public partial class siparişlistesi : Form
    {
        public siparişlistesi()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Elif\\Documents\\pizzatakip.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void verilerigörüntüle()
        {
            listView1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("Select *from Kasa");
            OleDbDataReader oku =komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["AdıSoyadı"].ToString();
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Pizzaboyveadet"].ToString());
                ekle.SubItems.Add(oku["Ekstra"].ToString());
                ekle.SubItems.Add(oku["İçecekboyveadet"].ToString());
                ekle.SubItems.Add(oku["Çıtırlezzetler"].ToString());
                ekle.SubItems.Add(oku["Soslar"].ToString());
                ekle.SubItems.Add(oku["Tatlı"].ToString());
                ekle.SubItems.Add(oku["Ücret"].ToString());
                ekle.SubItems.Add(oku["Masa"].ToString());
                ekle.SubItems.Add(oku["ID"].ToString());
                listView1.Items.Add(ekle);
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigörüntüle();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = ("(delete from Kasa where AdıSoyadı='"+txtad.Text+"')");
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigörüntüle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update Kasa set Masa='"+txtmasa.Text+ "',Ücret='" + textücret.Text + "',Telefon='" + texttel.Text + "',Pizzaboyveadet='" + textpizza.Text + "',Ekstra='" + textekstra.Text + "',İçecekboyveadet='" + textiçecek.Text + "',Çıtırlezzetler='" + textçıtırlezzetler.Text + "',Soslar='" + textsoslar.Text + "',Tatlı='" + texttatlı.Text +"',ID='"+textid.Text+ "' where AdıSoyadı='" + txtad.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigörüntüle();
        }

        private void siparişlistesi_Load(object sender, EventArgs e)
        {

        }
    }
}
