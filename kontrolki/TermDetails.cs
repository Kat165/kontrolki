using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kontrolki
{
    public partial class TermDetails : Form
    {
        public static string TermDetailsName;
        public static string Start;
        public static string End;
        public static Color color;

        List<string> list = new List<string>() { "0:00","0:30","1:00","1:30","2:00","2:30","3:00","3:30","4:00","4:30","5:00","5:30",
            "6:00","6:30","7:00","7:30","8:00","8:30","9:00","9:30","10:00","10:30","11:00","11:30","12:00","12:30","13:00","13:30","14:00",
            "14:30","15:00","15:30","16:00","16:30","17:00","17:30","18:00","18:30","19:00","19:30","20:00","20:30","21:00","21:30","22:00",
            "22:30","23:00","23:30"};
        public TermDetails()
        {
            InitializeComponent();
            colorDialog1.AnyColor = true;
            ComboBoxInit();
        }

        private void ComboBoxInit()
        {
            
            
            foreach(string item in list)
            {
                comboBox1.Items.Add(item);
            }
            comboBox2.Enabled = false;
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            textBox2.BackColor = colorDialog1.Color;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all data!");
                return;
            }
            TermDetailsName = textBox1.Text;
            Start = comboBox1.SelectedItem.ToString();
            End = comboBox2.SelectedItem.ToString();
            color = textBox2.BackColor;
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;

            comboBox2.Items.Clear();

            for(int i = 0; i < list.Count - index; i++)
            {
                comboBox2.Items.Add(list[i + index]);
            }
            comboBox2.Enabled = true;
        }

        public void remind(int day)
        {
            DateTime date = DateTime.Now;
            string time = DateTime.Now.ToString("HH:mm");
            int dayy = (int)date.DayOfWeek;
            foreach (string s in list)
            {
                if(s == time && day == dayy)
                {
                    MessageBox.Show("Przypominam o wydarzeniu!");
                }
            }
        }

    }
}
