using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MağazaOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aBCAnaliziToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        SqlConnection baglanti = new SqlConnection("Data Source = DESKTOP-853VGEV; Initial Catalog=Stok3;Integrated Security = True");
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();

        }

        private void Listele()//Veritabanındaki güncel kayıtların görünütlenmesi için
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select *from Urunler",baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//EKLE
            String t1 = textBox1.Text; // ürün kodu
            String t2 = textBox2.Text; // ürün adi
            String t3 = textBox3.Text; // yillik satis
            String t4 = textBox4.Text; // birim fiyat
            String t5 = textBox5.Text; // Min Stok
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO Urunler(UrunKodu,UrunAdi,YillikSatis,BirimFiyat,MinStok) Values('"+t1+ "','"+t2+ "','"+t3+ "','"+t4+ "','"+t5+"')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {//SİL
            String t1 = textBox1.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("DELETE FROM Urunler WHERE UrunKodu=('"+t1+"')",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {//güncelleme
            String t1 = textBox1.Text; 
            String t2 = textBox2.Text;
            String t3 = textBox3.Text; 
            String t4 = textBox4.Text; 
            String t5 = textBox5.Text;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("UPDATE Urunler SET UrunKodu ='"+t1+ "',UrunAdi = '"+t2+ "',YillikSatis = '"+t3+ "',BirimFiyat = '"+t4+ "',MinStok = '"+t5+ "'WHERE UrunKodu = '"+t1+"' ", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }
    }
}
