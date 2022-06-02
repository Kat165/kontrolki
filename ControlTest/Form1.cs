using kontrolki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int value))
            {
                MessageBox.Show("to musi być liczba naturalna!");
                return;
            }
            userControl11.ChangeMinNumberOfChars(value);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string NewChar = textBox2.Text;
            List<char> Chars = new List<char>();
            Chars.AddRange(NewChar);
            Chars.Distinct();
            userControl11.NewSpecialChar(Chars);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (userControl11.CheckPassword())
                MessageBox.Show("Dobre hasło");
            else
                MessageBox.Show("Złe hasło");
        }
    }
}
