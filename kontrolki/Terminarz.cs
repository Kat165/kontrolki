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
    public partial class Terminarz : UserControl
    {
        TermDetails termDetails = new TermDetails();
        int rowstart;
        int col;
        int rowend;

        List<Class1> events = new List<Class1>();

        public Terminarz()
        {
            InitializeComponent();
            label392.Text = "";
        }

        private void label372_Click(object sender, EventArgs e)
        {
            termDetails.ShowDialog();
            var label = sender as Label;
            rowstart = tableLayoutPanel2.GetRow(label);
            col = tableLayoutPanel2.GetColumn(label);
            SetData();
        }

        public void SetData()
        {
            TableLayoutControlCollection controls = tableLayoutPanel2.Controls;

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is Label)
                {
                    if(controls[i].Text == TermDetails.Start)
                    {
                        rowstart = tableLayoutPanel2.GetRow(controls[i]);
                    }

                    if (controls[i].Text == TermDetails.End)
                    {
                        rowend = tableLayoutPanel2.GetRow(controls[i]);
                    }
                }
            }

            for (int y = rowstart; y <= rowend; y++)
            {
                var d = tableLayoutPanel2.GetControlFromPosition(col, y);
                if(d is Label)
                {
                    d.BackColor = TermDetails.color;
                }
            }

            var l = tableLayoutPanel2.GetControlFromPosition(col, rowstart);
            if (l is Label)
            {
                l.Text = TermDetails.TermDetailsName;
            }

            events.Add(new Class1(TermDetails.TermDetailsName, rowstart, col, rowend, TermDetails.color));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;

            string workHours = DateTime.Now.ToString("HH:mm");
            double hours = TimeSpan.Parse(workHours).TotalHours;
            DateTime dt = new DateTime();
            int day = (int)time.DayOfWeek;
            if (events.Count == 0)
                return;

            foreach(var ee in events)
            {
                if (day == ee.col)
                {
                    var x = ee.rowstart * 30;
                    TimeSpan st = TimeSpan.FromMinutes(x);
                    string starttime = string.Format("{0:00}:{1:00}", (int)st.TotalHours, st.Minutes);
                    double t2 = TimeSpan.Parse(starttime).TotalHours;
                    if (t2 - hours < 30)
                    {
                        label392.Text = "Przypominam o " + ee.name;

                    }
                }
                    
            }
        }
    }
}
