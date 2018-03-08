using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Timers;
using System.IO;
using System.IO.Ports;//这是外设端口的包   你要引用进来  和头文件一样
using System.Threading;
using System.Diagnostics;

namespace Charge_monitoring
{
    public partial class Form_limit_set : Form
    {
        int CH_NO;//从0开始
        public Form_limit_set(int SetChannel)
        {
            InitializeComponent();

            CH_NO = SetChannel;
            
        }

        private void Form_limit_set_Load(object sender, EventArgs e)
        {
            max.Text = 全局变量.int_to_2Char(全局变量.UpperLimit[CH_NO]);
            min.Text = 全局变量.int_to_2Char(全局变量.LowerLimit[CH_NO]);
            period.SelectedIndex = 全局变量.MaxReadIndex[CH_NO];
        }

        public void button1_Click(object sender, EventArgs e)
        {

            FormMain.timer1.Enabled = false;//关闭计时器，停止数据的读取
            Thread.Sleep(160);//延迟保证串口读取结束

            try
            {

                #region 设定上下限
                全局变量.limit_set_sbuf[0] = 0x24;//send the ASCII code of $
                全局变量.limit_set_sbuf[1] = (byte)CH_NO;//通道号
                全局变量.limit_set_sbuf[2] = 0x58;//send the ASCII code of X
                全局变量.limit_set_sbuf[3] = (byte)int.Parse(max.Text);
                全局变量.limit_set_sbuf[4] = (byte)int.Parse(min.Text);
                全局变量.limit_set_sbuf[5] = (byte)(全局变量.limit_set_sbuf[0] ^ 全局变量.limit_set_sbuf[1] ^ 全局变量.limit_set_sbuf[2] ^ 全局变量.limit_set_sbuf[3] ^ 全局变量.limit_set_sbuf[4]);
                全局变量.limit_set_sbuf[6] = 0x2A;//send the ASCII code if * 

                FormMain.serialPort1.DiscardInBuffer();//清空缓冲区
                FormMain.serialPort1.Write(全局变量.limit_set_sbuf, 0, 7);//向下位机发送设定指令
                Thread.Sleep(130);//发送完指令以后在这里做延时，给串口一点时间发送和接收数据，此时串口可能正在接收数据呢
                //读取数据
                #endregion
                //设定最大读取时间
                全局变量.MaxReadIndex[CH_NO] = period.SelectedIndex;

            }
            catch (Exception ex)//
            {
                MessageBox.Show(ex.Message);
            }
            FormMain.timer1.Enabled = true;

            this.Close();
        }




    }
}
