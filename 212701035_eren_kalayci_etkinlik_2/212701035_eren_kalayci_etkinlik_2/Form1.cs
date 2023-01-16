using System;
using System.Windows.Forms;

namespace _212701035_eren_kalayci
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //yönetici giirþ ekranýna yönlendimek için
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //çalýþan giirþ ekranýna yönlendimek için
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }
    }
}