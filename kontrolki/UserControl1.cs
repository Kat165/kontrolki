using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kontrolki
{
    public partial class UserControl1: UserControl
    {
        List<char> SpeccharList = new List<char>() { '!','@','#','$','%'};
        List<char> GreatChar = new List<char>() {
            'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D',
            'F', 'G', 'H', 'J', 'K', 'L', 'Z', 'X', 'C', 'V', 'B', 'N', 'M' };

        List<char> Integrs = new List<char>() { '1','2','3','4','5','6','7','8','9','0'};

        int n = 8;
        public int MinLength { get { return n; } set { ChangeMinNumberOfChars(value); } }
        public List<Char> SpecialCharList { get { return SpeccharList; } set { SpeccharList = value; } }

        public UserControl1()
        {
            InitializeComponent();
        }

        public bool checkPasswordLength()
        {
            if(textBox1.Text.Length < n)
            {
                return false;
            }
            return true;
        }

        public bool oneSpecChar()
        {
            foreach (char c in SpeccharList)
            {
                if(textBox1.Text.Contains(c))
                    return true;
            }
            return false;
        }

        public bool oneGreatChar()
        {
            foreach(char c in GreatChar)
            {
                if (textBox1.Text.Contains(c))
                    return true;
            }
            return false;
        }

        public bool oneInteger()
        {
            foreach(char c in Integrs)
            {
                if (textBox1.Text.Contains(c))
                    return true;
            }
            return false;
        }

        public void NewSpecialChar(List<char> NewCharList)
        {
            SpeccharList.Clear();
            SpeccharList = NewCharList;
            oneSpecChar();
        }

        public void ChangeMinNumberOfChars(int number)
        {
            n = number;
            label2.Text = "min " + n.ToString() + " znaków?";
        }


        private void TextHasChanged(object sender, EventArgs e)
        {
            if (checkPasswordLength())
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
            if(oneSpecChar())
                checkBox2.Checked = true;
            else
                checkBox2.Checked= false;
            if (oneGreatChar())
                checkBox3.Checked = true;
            else
                checkBox3.Checked = false;
            if(oneInteger())
                checkBox4.Checked = true;
            else
                checkBox4.Checked = false;
        }

        public bool CheckPassword()
        {
            if(checkPasswordLength() && oneSpecChar() && oneGreatChar() && oneInteger())
                return true;
            return false;
        }
    }
}
