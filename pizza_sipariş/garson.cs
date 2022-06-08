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
    public partial class garson : Form
    {
        public garson()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Elif\\Documents\\pizzatakip.mdb");
        OleDbCommand komut = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand(" Select * From garsonbilgi" , baglanti);
            komut.ExecuteReader();
            MessageBox.Show("Bilgiler kasaya iletildi.");
            baglanti.Close();

        }
    }
}
