using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Charge_monitoring
{
    public partial class FormParameter : Form
    {
        int CH_NO;

        //运行情况的记录
        public string[] the_time = new string[600];
        public double[] read_double = new double[600];
        
        //记录最大最小值
        public int ValueMax=0;
        public int ValueMin=1000;
        public FormParameter(int SetChannel)
        {            
            InitializeComponent();

            CH_NO = SetChannel;
            for (int num=0;num<600;num++)
            {
                read_double[num] = 0;
                the_time[num] = "0";
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;//取消窗体关闭的事件
            this.Hide();
            FormMain.SettingsShow[CH_NO] = false;
        }

        private void SetParameter_Click(object sender, EventArgs e)
        {
            Form_limit_set a = new Form_limit_set(CH_NO);
            a.Show();
        }

        private void FormParameter_Load(object sender, EventArgs e)
        {
            //real.Text = 全局变量.read_integer[全局变量.NO_CHS].ToString() + " " + DateTime.Now.ToString("HH:mm:ss");
        }


    }
}
