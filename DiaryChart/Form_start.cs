using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DiaryChart
{
    public partial class Form_start : Form
    {
        long num;

        public Form_start()
        {
            InitializeComponent();
        }

        private void Form_start_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
            this.TransparencyKey = Color.Red;
            this.Opacity = 0;

      

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            num++;
            if ((this.Opacity != 1) && (num < 200))
            {
                this.Opacity += 0.05;
            }
            if ((this.Opacity != 0) && (num > 350))
            {
                this.Opacity -= 0.05;
            }

            if(num == 400)
            this.Close();
        }
    }
}
