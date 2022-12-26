using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodoroTimer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DateTime date1, timer, timer2;

        private void timer1_Tick(object sender, EventArgs e)
        {
            date1 = DateTime.Now;
            sessionNUD.Value = Convert.ToInt32(Math.Abs(timer.Subtract(date1).Minutes) + Math.Abs(TimeSpan.FromHours(timer.Subtract(date1).Hours).TotalMinutes));
            label1.Text = Math.Abs(timer.Subtract(DateTime.Now).Seconds).ToString();
            if(timer.Day == date1.Day && timer.Hour == date1.Hour && timer.Minute == date1.Minute && timer.Second == date1.Second)
            {
                MessageBox.Show("");
                timer1.Enabled = false;
                timer3.Enabled = true;
                date1 = DateTime.Now;
                timer2 = DateTime.Now;
                timer2 = timer2.AddMinutes(Convert.ToInt32(breakNUD.Value));
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            date1 = DateTime.Now;
            label4.Text = Math.Abs(timer2.Subtract(DateTime.Now).Seconds).ToString();
            breakNUD.Value = Convert.ToInt32(Math.Abs(timer2.Subtract(date1).Minutes) + Math.Abs(TimeSpan.FromHours(timer2.Subtract(date1).Hours).TotalMinutes));
            if (timer2.Day == date1.Day && timer2.Hour == date1.Hour && timer2.Minute == date1.Minute && timer2.Second == date1.Second)
            {
                var res = MessageBox.Show("Ваш отдых закончен");
                if(res == null)
                {
                    Console.Beep();
                }
                timer3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void startStopBTN_Click(object sender, EventArgs e)
        {
            date1 = DateTime.Now;
            timer = DateTime.Now;
            timer = timer.AddMinutes(Convert.ToInt32(sessionNUD.Value));
            timer1.Enabled = true;
        }
    }
}
