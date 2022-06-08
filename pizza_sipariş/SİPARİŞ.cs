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
    public partial class SİPARİŞ : Form
    {
        public SİPARİŞ()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Elif\\Documents\\pizzatakip.mdb");

        private void btnsiparis_Click(object sender, EventArgs e)
        {
            decimal ucret = 0;
            string ekstra = "";
            string soslar = "";
            string çıtır = "";
            string tatlı = "";
            if (chket.Checked == true)
            {
                ekstra += "et";
                ucret = 6;
            }
            else if(chkmantar.Checked==true)
            {
                ekstra += "" + "mantar";
                ucret += 4;
            }
            else if (chkpeynir.Checked == true)
            {
                ekstra += "" + "peynir";
                ucret += 3;
            }
            else if (chksosis.Checked == true)
            {
                ekstra += "" + "sosis";
                ucret += 5;
            }
            else if (chksucuk.Checked == true)
            {
                ekstra += "" + "sucuk"; 
                ucret += 5;
            }
            else if (chkzeytin.Checked == true)
            {
                ekstra += "" + "zeytin";
                ucret += 3;
            }
            if (chkacı.Checked==true)
            {
                soslar += "acısos";
                ucret += 3;
            }
            else if (chkbarbekü.Checked == true)
            {
                soslar += "" + "barbeküsos";
                ucret += 3;
            }
            else if (chkketçap.Checked == true)
            {
                soslar += "" + "ketçap";
                ucret += 1;
            }
            else if (chkmayonez.Checked == true)
            {
                soslar += "" + "mayonez";
                ucret += 1;
            }
            else if (chksarımsak.Checked == true)
            {
                soslar += "" + "sarımsaklısos";
                ucret += 3;
            }
            else if (chkpizzabaharat.Checked == true)
            {
                soslar += "" + "pizzabaharatı";
                ucret += 1;
            }
            if (chkpatateskovası.Checked == true)
            {
                çıtır += "patateskovası";
                ucret += 10;
            }
            else if (chktavukkovası.Checked == true)
            {
                çıtır += ""+"tavukkovası";
                ucret += 20;
            }
            else if (chkçıtır.Checked == true)
            {
                çıtır += ""+"çıtırkovası";
                ucret += 20;
            }
            if (chkdondurma.Checked == true)
            {
                tatlı += "dondurma";
                ucret += 8;
            }
            else if (chksuffle.Checked == true)
            {
                tatlı += "" + "çikolatalısuffle";
                ucret += 12;
            }
            if (cmbpizzaboy.Text == "küçük")
            {
                ucret += nmrpizzaadet.Value * 25;
            }
            else if (cmbpizzaboy.Text == "orta")
            {
                ucret += nmrpizzaadet.Value * 30;
            }
            else if (cmbpizzaboy.Text == "büyük")
            {
                ucret += nmrpizzaadet.Value * 40;
            }
            if(cmbiicecek.Text=="2,5 litre Coco Cola")
            {
                ucret += nmricecekadet.Value * 15;
            }
            else if (cmbiicecek.Text == "1 litre Fanta")
            {
                ucret += nmricecekadet.Value * 10;
            }
            else if (cmbiicecek.Text == "1 litre Sprite")
            {
                ucret += nmricecekadet.Value * 10;
            }
            else if (cmbiicecek.Text == "Soda")
            {
                ucret += nmricecekadet.Value * 3;
            }
            else if (cmbiicecek.Text == "Su")
            {
                ucret += nmricecekadet.Value * 3;
            }
            else if (cmbiicecek.Text == "Ayran")
            {
                ucret += nmricecekadet.Value * 7;
            }
            else if (cmbiicecek.Text == "Kutu Kola")
            {
                ucret += nmricecekadet.Value * 8;
            }
            else if (cmbiicecek.Text == "Karışık Meyvesuyu")
            {
                ucret += nmricecekadet.Value * 8;
            }

            listadsoyad.Items.Add(txtadsoyad.Text);
            listtel.Items.Add(txttel.Text);
            listpizzaboyadet.Items.Add("Adet "+nmrpizzaadet.Value+" Boyut "+cmbpizzaboy.Text);
            listekstra.Items.Add(ekstra);
            listicecekadet.Items.Add("Adet "+nmricecekadet.Value+" Boyut "+cmbiicecek.Text);
            listucret.Items.Add(ucret + " TL");
            listsoslar.Items.Add(soslar);
            listçıtırlezzetler.Items.Add(çıtır);
            listtatlı.Items.Add(tatlı);
            listmasa.Items.Add(txtmasa.Text);
            listnotlar.Items.Add(txtnotlar.Text);


           
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Kasa (Masa,Ücret,AdıSoyadı,Telefon,Pizzaboyveadet,Ekstra,İçecekboyveadet,Çıtırlezzetler,Soslar,Tatlı,ID) values ('" + txtmasa.Text + "','" + (ucret + " TL") + "','" + txtadsoyad.Text +"','"+ txttel.Text + "','"  + ("Adet " + nmrpizzaadet.Value + " Boyut " + cmbpizzaboy.Text)+ "','" + ekstra+ "','" + ("Adet " + nmricecekadet.Value + " Boyut " + cmbiicecek.Text) + "','" + çıtır + "','" + soslar + "','" +tatlı+"','"+ textBox1.Text+ "')",baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler kasaya iletildi.");
            baglanti.Close();

        }

        private void SİPARİŞ_Load(object sender, EventArgs e)
        {
            cmbpizzaboy.Items.Add("küçük");
            cmbpizzaboy.Items.Add("orta");
            cmbpizzaboy.Items.Add("büyük");

            cmbiicecek.Items.Add("2,5 litre Coco Cola");
            cmbiicecek.Items.Add("1 litre Fanta");
            cmbiicecek.Items.Add("1 litre Sprite");
            cmbiicecek.Items.Add("Soda");
            cmbiicecek.Items.Add("Su");
            cmbiicecek.Items.Add("Ayran");
            cmbiicecek.Items.Add("Kutu Kola");
            cmbiicecek.Items.Add("Karışık Meyvesuyu");

        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtadsoyad.Text = "";
            txttel.Text = null;
            txtnotlar.Text = null;
            txtmasa.Text = null;
            txtnotlar.Text = null;

            cmbiicecek.Text = "";
            cmbpizzaboy.Text = "";

            nmricecekadet.Value = 0;
            nmrpizzaadet.Value = 0;

            chket.Checked = false;
            chkmantar.Checked = false;
            chkpeynir.Checked = false;
            chksosis.Checked = false;
            chksucuk.Checked = false;
            chkzeytin.Checked = false;

            listadsoyad.Items.Clear();
            listekstra.Items.Clear();
            listicecekadet.Items.Clear();
            listpizzaboyadet.Items.Clear();
            listtel.Items.Clear();
            listucret.Items.Clear();
            listçıtırlezzetler.Items.Clear();
            listsoslar.Items.Clear();
            listtatlı.Items.Clear();
            listnotlar.Items.Clear();
        }

        private void btnsiparistemizle_Click(object sender, EventArgs e)
        {
            txtadsoyad.Text = "";
            txttel.Text = null;
            txtnotlar.Text = null;
            txtmasa.Text = null;
            txtnotlar.Text = null;

            cmbiicecek.Text = "";
            cmbpizzaboy.Text = "";

            nmricecekadet.Value = 0;
            nmrpizzaadet.Value = 0;

            chket.Checked = false;
            chkmantar.Checked = false;
            chkpeynir.Checked = false;
            chksosis.Checked = false;
            chksucuk.Checked = false;
            chkzeytin.Checked = false;

            chkacı.Checked = false;
            chkbarbekü.Checked = false;
            chkketçap.Checked = false;
            chkmayonez.Checked = false;
            chksarımsak.Checked = false;
            chkpizzabaharat.Checked = false;

            chkpatateskovası.Checked = false;
            chktavukkovası.Checked = false;
            chkçıtır.Checked = false;

            chksuffle.Checked = false;
            chkdondurma.Checked = false;
        }

        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnmutfak_Click(object sender, EventArgs e)
        {
            string ekstra = "";
            string soslar = "";
            string çıtır = "";
            string tatlı = "";
            if (chket.Checked == true)
            {
                ekstra += "et";
            }
            else if (chkmantar.Checked == true)
            {
                ekstra += "" + "mantar";
            }
            else if (chkpeynir.Checked == true)
            {
                ekstra += "" + "peynir";
            }
            else if (chksosis.Checked == true)
            {
                ekstra += "" + "sosis";
            }
            else if (chksucuk.Checked == true)
            {
                ekstra += "" + "sucuk";
            }
            else if (chkzeytin.Checked == true)
            {
                ekstra += "" + "zeytin";
            }
            if (chkacı.Checked == true)
            {
                soslar += "acısos";
            }
            else if (chkbarbekü.Checked == true)
            {
                soslar += "" + "barbeküsos";
            }
            else if (chkketçap.Checked == true)
            {
                soslar += "" + "ketçap";
            }
            else if (chkmayonez.Checked == true)
            {
                soslar += "" + "mayonez";
            }
            else if (chksarımsak.Checked == true)
            {
                soslar += "" + "sarımsaklısos";
            }
            else if (chkpizzabaharat.Checked == true)
            {
                soslar += "" + "pizzabaharatı";
            }
            if (chkpatateskovası.Checked == true)
            {
                çıtır += "patateskovası";
            }
            else if (chktavukkovası.Checked == true)
            {
                çıtır += "" + "tavukkovası";
            }
            else if (chkçıtır.Checked == true)
            {
                çıtır += "" + "çıtırkovası";
            }
            if (chkdondurma.Checked == true)
            {
                tatlı += "dondurma";
            }
            else if (chksuffle.Checked == true)
            {
                tatlı += "" + "çikolatalısuffle";
            }

            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("insert into Mutfak (Masa,Pizzaboyveadet,Ekstra,İçecekboyveadet,Çıtırlezzetler,Soslar,Tatlı,Notlar,ID) values ('" + txtmasa.Text + "','" + ("Adet " + nmrpizzaadet.Value + " Boyut " + cmbpizzaboy.Text) + "','" + ekstra + "','" + ("Adet " + nmricecekadet.Value + " Boyut " + cmbiicecek.Text) + "','" + çıtır + "','" + soslar + "','" + tatlı +"','" + txtnotlar.Text + "','" + textBox1.Text + "')",baglanti);
            komut.ExecuteNonQuery();
            MessageBox.Show("Bilgiler mutfağa iletildi.");
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }    
    }
}
