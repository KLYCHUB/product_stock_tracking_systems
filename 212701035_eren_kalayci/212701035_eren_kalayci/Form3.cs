using _212701035_eren_kalayci_etkinlik_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _212701035_eren_kalayci
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //çalışan ekleme ekranına yönlendirir
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //çalışan çıkarma ekranına yönlendirir
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
