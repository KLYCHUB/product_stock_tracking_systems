using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace _212701035_eren_kalayci
{
    public partial class Form2 : Form
    {
        //İşlemler için gerekli değişkenleri oluşturduk
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            //Prpporties kısmında maskedtexbox ın PasswordChar kısmını "*" yaptım
            string password = maskedTextBox1.Text;

            //DataBase ile bağlantıyı sağladık
            con = new SqlConnection("Data Source=.;Initial Catalog=212701035;Integrated Security=True");
            com = new SqlCommand();
            //Bağlantıyı Açtık
            con.Open();
            com.Connection = con;

            //Texbox 1 ve 2 den tc ve şifreyi alıyoruz sonra buları veri tabanında ki tabloda karşılaştıracağız
            com.CommandText= "Select*From kullanici_Bilgi where yonetici_tc_no='" + textBox1.Text +"'And sifre='"+ maskedTextBox1.Text + "'";
            //Burada kullanıcı adı ve ifre kontrolleri yapıyoruz
            dr = com.ExecuteReader();

            //Bilgileri okuyor, karşılaştırma doğru ise  form geçişi sağlanıyor
            if (dr.Read())
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            else
            {
                //şifre yanlış olunca
                MessageBox.Show("Hatalı Giriş! Lütfen Tekrar Deneyin");
            }
            //bağlantıyı kapatıyoruz
            con.Close();
            
            //databasede önetici şifresini 123 tc sinide 123 diye kayıt ettim
        }
    }
}
