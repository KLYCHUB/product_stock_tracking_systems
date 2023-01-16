using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace _212701035_eren_kalayci
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        //DataBase ile bağlantıyı sağladık
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=212701035;Integrated Security=True");

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        //Ürünlistesini görüntülemek için fonksiyon oloşturdum
        public void kayit_listele()
        {
            //ürün_ekle tablosunu seçti ve bağlandık
            da = new SqlDataAdapter("Select * From urun_Ekle", baglan);
            ds = new DataSet();
            baglan.Open();
            //ilk model_no olan satırsan doldurmaya başladık
            da.Fill(ds, "model_no");
            dataGridView1.DataSource = ds.Tables["model_no"];
            baglan.Close();
        }

        //Veri tabanından veri eklendikten veya silindikten sonra en güncel listeyi görmek için oluşturulan fonksiyon
        DataTable yenile()
        {
            baglan.Open();
            //ilk model_no olan satırsan doldurmaya başladık
            SqlDataAdapter adtr = new SqlDataAdapter("select *from urun_Ekle", baglan);
            DataTable tablo = new DataTable();
            //Tabloyu dolduruyor
            adtr.Fill(tablo);
            baglan.Close();
            return tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kayıt Giriş Alanlarının Boş Bırakılmamamsı İçin 
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                baglan.Open();
                //urun tablosuna ürün bilgilerini kaydediyoruz
                SqlCommand komut = new SqlCommand("Insert into urun_Ekle (model_no,urun_rengi,toplam_hacim,enerji_sinifi) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakamazsınız!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Tüm ürünleri Listeliyor
            kayit_listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Tabloyu güncelliyor
            dataGridView1.DataSource = yenile();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {   //Veri tabanına bağlandık
                baglan.Open();              //Uurn ekele tablosunda model noya göre silme    //Satırlardailerlemek için    //Sıfırıncı indiisn başlangıcı
                SqlCommand komut = new SqlCommand("delete from urun_ekle where model_no='" + dataGridView1.SelectedRows[i].Cells["model_no"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            MessageBox.Show("Kayıt Silindi");
            //Listeyi Silindiktenn sonra güncelledik
            dataGridView1.DataSource = yenile();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Burda tabloda ki model noyu kayit string değişkneine atıyıyoruz
            string kayit = "Select * From urun_Ekle Where model_no=@model_no";
            //Aratma işlemi için
            SqlCommand komut = new SqlCommand(kayit, baglan);

            //textboxa model noyu yazarak tablodan aratıyoruz
            komut.Parameters.AddWithValue("@model_no", textBox16.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            //Tabloyu aradaığımız değerle Dolduruyoruz - tabi veri tabanında varsa
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void button61_Click(object sender, EventArgs e)
        {
            baglan.Open();
            //Güncelleme işlemi //where ile de model no yu etketledik komut.Parameters.AddWithValue("@model_no", textBox1.Text); de de bunu değiştirilmez yapacağız
            string guncelle = "UPDATE urun_Ekle SET  model_no= '" + textBox1.Text + "',urun_rengi='" + textBox2.Text + "',toplam_hacim='" + textBox3.Text + "',enerji_sinifi='" + textBox4.Text + "' WHERE model_no='" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand(guncelle, baglan);
            //model noyu değiştirilmez yaptık 
            komut.Parameters.AddWithValue("@model_no", textBox1.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Başarıyla güncellendi.");
        }

        //gridviewin tıklama özelliğini eventsten açtık
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçtiğimi satırı textboxa doldurmak için
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }

}
