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

namespace _212701035_eren_kalayci_etkinlik_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        //DataBase ile bağlantıyı sağladık
        SqlConnection baglan = new SqlConnection("Data Source=.;Initial Catalog=212701035;Integrated Security=True");

        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        string cinsiyet;

        //Kayıtlı kişileri listeleme
        public void kayit_listele()
        {
            //calisan ekle tablosundaki calisan ekle tablosuna bağlandık ve ordaki verileri çektik
            da = new SqlDataAdapter("Select * From calisan_Ekle", baglan);
            ds = new DataSet();
            baglan.Open();
            da.Fill(ds, "caslisan_tc");
            dataGridView1.DataSource = ds.Tables["caslisan_tc"];
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kayıt Giriş Alanlarının Boş Bırakılmamamsı İçin 
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && (radioButton1.Checked || radioButton2.Checked))
            {
                baglan.Open();

                //1. radiobuton seçili ise cinsiyet değişkenine erkek 2 ise kadını atadık ve 60. satırda yerleştirdik
                if (radioButton1.Checked)
                {
                    cinsiyet = "Erkek";
                }

                if (radioButton2.Checked)
                {
                    cinsiyet = "Kadın";
                }

                //Çalışan ekle tablosuna textboxlardan veri ekledik
                SqlCommand komut = new SqlCommand("Insert into calisan_Ekle (calisan_tc,sicil_no,ad,soya,cinsiyet) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + cinsiyet + "')", baglan);
                komut.ExecuteNonQuery();
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakamazsınız!");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView in içini silip tekrar çakığdır bu şekilde en güncel halini gördük
            dataGridView1.DataSource = "";
            kayit_listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
