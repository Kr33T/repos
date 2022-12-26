using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountTo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DateTime dateNow = DateTime.Now;

        DateTime tim3 = DateTime.Now;

        private void timer1_Tick(object sender, EventArgs e)
        {
            dateNow = DateTime.Now;
            dayTB.Text = dateNow.Subtract(tim3).Days.ToString().Replace("-", "");
            hourTB.Text = dateNow.Subtract(tim3).Hours.ToString().Replace("-", "");
            minTB.Text = dateNow.Subtract(tim3).Minutes.ToString().Replace("-", "");
            secTB.Text = dateNow.Subtract(tim3).Seconds.ToString().Replace("-", "");

            if (dateNow.Day == tim3.Day && dateNow.Hour == tim3.Hour && dateNow.Minute == tim3.Minute && dateNow.Second == tim3.Second)
            {
                timer1.Enabled = false;
                setEnTimer = !setEnTimer;
                button2.Text = "START";
                dayTB.Text = hourTB.Text = minTB.Text = secTB.Text = "";

                dayTB.ReadOnly = false;
                hourTB.ReadOnly = false;
                minTB.ReadOnly = false;
                secTB.ReadOnly = false;

                MessageBox.Show("Timer is over", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool setEnTimer = true;

        private void button2_Click(object sender, EventArgs e)
        {
            if (!setEnTimer)
            {
                timer1.Enabled = false;
                setEnTimer = !setEnTimer;
                button2.Text = "START";
                dayTB.ReadOnly = false;
                hourTB.ReadOnly = false;
                minTB.ReadOnly = false;
                secTB.ReadOnly = false;
            }
            else
            {
                if(String.IsNullOrEmpty(dayTB.Text) && String.IsNullOrEmpty(hourTB.Text) && String.IsNullOrEmpty(minTB.Text) && String.IsNullOrEmpty(secTB.Text))
                {
                    MessageBox.Show("Fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dayTB.ReadOnly = true;
                    hourTB.ReadOnly = true;
                    minTB.ReadOnly = true;
                    secTB.ReadOnly = true;

                    tim3 = DateTime.Now;
                    tim3 = tim3.AddDays(checkNullString(dayTB.Text));
                    tim3 = tim3.AddHours(checkNullString(hourTB.Text));
                    tim3 = tim3.AddMinutes(checkNullString(minTB.Text));
                    tim3 = tim3.AddSeconds(checkNullString(secTB.Text));
                    timer1.Enabled = true;
                    setEnTimer = !setEnTimer;
                    button2.Text = "STOP";
                }
            }
        }

        private int checkNullString(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            setEnTimer = !setEnTimer;
            button2.Text = "START";

            dayTB.ReadOnly = false;
            hourTB.ReadOnly = false;
            minTB.ReadOnly = false;
            secTB.ReadOnly = false;

            dayTB.Text = hourTB.Text = minTB.Text = secTB.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (dayTB.Text.Contains("-"))
            {
                dayTB.Text = dayTB.Text.Replace("-", "");
            }
            if (hourTB.Text.Contains("-"))
            {
                hourTB.Text = hourTB.Text.Replace("-", "");
            }
            if (minTB.Text.Contains("-"))
            {
                minTB.Text = minTB.Text.Replace("-", "");
            }
            if (secTB.Text.Contains("-"))
            {
                secTB.Text = secTB.Text.Replace("-", "");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
