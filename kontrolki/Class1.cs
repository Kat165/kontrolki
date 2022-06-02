using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolki
{
    internal class Class1
    {
        public string name;
        public int rowstart;
        public int col;
        public int rowend;
        public Color color;

        public Class1(string name, int rows, int col, int rowe, Color c)
        {
            this.name = name;
            this.rowstart = rows;
            this.col = col;
            this.rowend = rowe;
            this.color = c;
        }
    }
}
