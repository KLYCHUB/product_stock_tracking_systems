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

namespace _212701035_eren_kalayci
{
    public partial class Form6 : Form
    {
        //İşlemler için gerekli değişkenleri oluşturduk
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            //Prpporties kısmında maskedtexbox ın PasswordChar kısmını "*" yaptım
            string password = maskedTextBox1.Text;

            //DataBase ile bağlantıyı sağladık
            con = new SqlConnection("Data Source=.;Initial Catalog=212701035;Integrated Security=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;

            //Texbox 1 ve 2 den tc ve şifreyi alıyoruz sonra buları veri tabanında ki tabloda karşılaştıracağız
            com.CommandText = "Select*From calisan_Ekle where calisan_tc='" + textBox1.Text + "'And sicil_no='" + maskedTextBox1.Text + "'";
            //Burada kullanıcı adı ve ifre kontrolleri yapıyoruz 
            dr = com.ExecuteReader();

            //Bilgileri okuyor, karşılaştırma doğru ise  form geçişi sağlanıyor
            if (dr.Read())
            {
                Form7 form7 = new Form7();
                form7.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş! Lütfen Tekrar Deneyin");
            }
            con.Close();
        }
    }
}
