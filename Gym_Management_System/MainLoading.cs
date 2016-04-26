using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{
    public partial class MainLoading : Form
    {
        bool flag;
       
        public MainLoading()
        {
            InitializeComponent();
        }

        private void MainLoading_Load(object sender, EventArgs e)
        {
            flag = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 99)
            {
                if (flag)
                {
                    flag = false;
                    label1.Text = "Loading.";
                }
                else
                {
                    flag = true;
                    label1.Text = "Loading..";
                }
                progressBar1.Value += 10;
                if (progressBar1.Value > 50)
                {
                    timer2.Enabled = true;
                    timer2.Start();
                }
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.03;
            if (this.Opacity <= 0)
            {
                timer2.Enabled = false;
                this.Visible = false;
                new Login().Show();
            }
        }
    }
}
