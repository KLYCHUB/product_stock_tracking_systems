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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _212701035_eren_kalayci
{
    public partial class Form5 : Form
    {
        
        public Form5()
        {
            InitializeComponent();
        }

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        //DataBase ile bağlantıyı sağladık
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=212701035;Integrated Security=True");

        //Ürünlistesini görüntülemek için fonksiyon oloşturdu
        public void kayit_listele()
        {
            //ürün_ekle tablosunu seçti ve bağlandık
            da = new SqlDataAdapter("Select * From calisan_Ekle", baglan);
            ds = new DataSet();
            baglan.Open();
            //ilk model_no olan satırsan doldurmaya başladık
            da.Fill(ds, "calisan_tc");
            dataGridView1.DataSource = ds.Tables["calisan_tc"];
            baglan.Close();
        }

        //Veri tabanından veri eklendikten veya silindikten sonra en güncel listeyi görmek için oluşturulan fonksiyon
        DataTable yenile()
        {
            //ilk model_no olan satırsan doldurmaya başladık
            baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from calisan_Ekle", baglan);
            DataTable tablo = new DataTable();
            //Tabloyu dolduruyor
            adtr.Fill(tablo);
            baglan.Close();
            return tablo;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                //Veri tabanına bağlandık
                baglan.Open();              //Uurn ekele tablosunda model noya göre silme    //Satırlardailerlemek için    //Sıfırıncı indiisn başlangıcı
                SqlCommand komut = new SqlCommand("delete from calisan_Ekle where calisan_tc='" + dataGridView1.SelectedRows[i].Cells["calisan_tc"].Value.ToString() + "'", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            MessageBox.Show("Kayıt Silindi");
            //Listeyi Silindiktenn sonra güncelledik
            dataGridView1.DataSource = yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Burda tabloda ki model noyu kayit string değişkneine atıyıyoruz
            string kayit = "Select * From calisan_Ekle Where calisan_tc=@calisan_tc";
            //Aratma işlemi için
            SqlCommand komut = new SqlCommand(kayit, baglan);

            //textboxa model noyu yazarak tablodan aratıyoruz
            komut.Parameters.AddWithValue("@calisan_tc", textBox1.Text);

            SqlDataAdapter da = new SqlDataAdapter(komut);

            //Tabloyu aradaığımız değerle Dolduruyoruz - tabi veri tabanında varsa
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Tüm ürünleri Listeliyor
            kayit_listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
