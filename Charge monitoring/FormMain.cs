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
    public partial class FormMain : Form
    {

        public static System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public static System.IO.Ports.SerialPort serialPort1 = new System.IO.Ports.SerialPort();

        FormParameter[] Settings = new FormParameter[16];
        public static bool[] SettingsShow = new bool[16];
        public FormMain()
        {
            InitializeComponent();   
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            全局变量.Portname = SerialPort.GetPortNames();//保存可用串口列表数组
            串口选择.Items.AddRange(全局变量.Portname);//显示可以串口列表数组w

            InitDisplayRows();

            for (int num = 0; num < 16; num++)
            {
                Settings[num] = new FormParameter(num);
                Settings[num].Text = "通道 " + (num+1) + " 参数显示";
                SettingsShow[num] = false;

                全局变量.MaxReadIndex[num] = 9;
            }

            timer1.Tick += new System.EventHandler(this.timer1_Tick);
            timer1.Interval = 160;//扫描间隔
        }

        private void InitDisplayRows()
        {
            Display.Rows.Clear();

            //in a real scenario, you may need to add different rows
            for (int intLoop = 0; intLoop < 16; intLoop++)
            {
                Display.Rows.Add(
                    (intLoop+1).ToString(),
                    "油库#号",
                    "-",
                    "-",
                    //String.Empty,
                    "单击",
                    "单击"
                    );
            }

            #region 导入备注文件或者创建备注文件
            //生成备注文件Remarks.txt
            try
            {
                if (File.Exists("Remarks.txt"))//判断备注文件是否存在
                {

                    StreamReader sr = File.OpenText("Remarks.txt");//打开文件
                    for (int num = 0; num < 16; num++)
                    {

                        string read_ling;
                        char read_char;//读取char
                        do
                        {
                            read_ling = sr.ReadLine();
                            if(read_ling==null)
                            {
                                read_ling = "油库#号";
                            }
                            read_char = read_ling[0];//读取char
                        } while (read_char == '#');
                        Display.Rows[num].Cells[1].Value = read_ling;
                    }
                    sr.Close();
                }
                else
                {

                    StreamWriter sw = File.CreateText("Remarks.txt");//创建文本文件Remarks.txt
                    sw.WriteLine("#备注文件!");
                    for (byte num = 0; num < 16; num++)
                    {
                        sw.WriteLine("#---地址" + num.ToString() + "备注");
                        sw.WriteLine("油库#号");
                        sw.WriteLine("#");
                        Display.Rows[num].Cells[1].Value = "油库#号";
                    }
                    sw.Close();


                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }//文件异常

            #endregion

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            全局变量.msg_show = false;
            //读取之前擦除状态
            Display.Rows[全局变量.NO_CHS].Cells[2].Value = "-";
            Display.Rows[全局变量.NO_CHS].Cells[3].Value = "-";
            try
            {

                    #region 读取NO_CHS通道的实时值


                    全局变量.read_sbuf[0] = 0x24;//send the ASCII code of $
                    全局变量.read_sbuf[1] = 全局变量.NO_CHS;//通道号
                    全局变量.read_sbuf[2] = 0x52;//send the ASCII code of R
                    全局变量.read_sbuf[3] = 0x45;//send the ASCII code of E
                    全局变量.read_sbuf[4] = 0x51;//send the ASCII code of Q
                //校验位
                    全局变量.read_sbuf[5] = (byte)(全局变量.read_sbuf[0] ^ 全局变量.read_sbuf[1] ^ 全局变量.read_sbuf[2] ^ 全局变量.read_sbuf[3] ^ 全局变量.read_sbuf[4]);
                    全局变量.read_sbuf[6] = 0x2A;//send the ASCII code if *          
                                                       
                                                       
                                                       
                                                       

                    serialPort1.DiscardInBuffer();//清空缓冲区
                    serialPort1.Write(全局变量.read_sbuf, 0, 7);//向下位机发送读取指令
                    Thread.Sleep(130);//发送完指令以后在这里做延时，给串口一点时间发送和接收数据此时串口可能正在接收数据呢
                    int BytesToRead = serialPort1.BytesToRead;
                    serialPort1.Read(全局变量.SBUF_TEMP, 0, BytesToRead);


                    if (全局变量.SBUF_TEMP[0] == 0x24 &&
                            全局变量.SBUF_TEMP[12] == 0x2A 
                            )//验证初始位$和结束位*
                    {
                        byte temp = (byte)(全局变量.SBUF_TEMP[0] ^
                            全局变量.SBUF_TEMP[1] ^
                            全局变量.SBUF_TEMP[2] ^
                            全局变量.SBUF_TEMP[3] ^
                            全局变量.SBUF_TEMP[4] ^
                            全局变量.SBUF_TEMP[5] ^
                            全局变量.SBUF_TEMP[6] ^
                            全局变量.SBUF_TEMP[7] ^
                            全局变量.SBUF_TEMP[8] ^
                            全局变量.SBUF_TEMP[9] ^
                            全局变量.SBUF_TEMP[10]
                            );
                            if (全局变量.SBUF_TEMP[11]==temp)//如果校验成功
                        {
                            if (全局变量.SBUF_TEMP[1] == 全局变量.NO_CHS)//确认地址
                            {
                                //显示型号
                                Display.Rows[全局变量.NO_CHS].Cells[2].Value = "AP-YB2101-" + 全局变量.byte_to_type(全局变量.SBUF_TEMP[2]);

                                //读取实时值
                                全局变量.read_sign[全局变量.NO_CHS] = 全局变量.SBUF_TEMP[3];//读取符号
                                全局变量.read_integer[全局变量.NO_CHS] = 全局变量.byte_to_int(全局变量.SBUF_TEMP[4], 全局变量.SBUF_TEMP[5]);//读取整数值
                                全局变量.read_decimal[全局变量.NO_CHS] = 全局变量.SBUF_TEMP[6];//读取小数值

                                if (全局变量.read_sign[全局变量.NO_CHS] == 0x2b)//电荷值为正，文本显示为正值
                                {
                                    Settings[全局变量.NO_CHS].real.Text = "+" + 全局变量.int_to_3Char(全局变量.read_integer[全局变量.NO_CHS]) + "." + 全局变量.int_to_2Char(全局变量.read_decimal[全局变量.NO_CHS]);

                                }
                                else if (全局变量.read_sign[全局变量.NO_CHS] == 0x2d)//电荷值为负，文本显示为负值，与下限进行比较
                                {
                                    Settings[全局变量.NO_CHS].real.Text = "-" + 全局变量.int_to_3Char(全局变量.read_integer[全局变量.NO_CHS]) + "." + 全局变量.int_to_2Char(全局变量.read_decimal[全局变量.NO_CHS]);

                                }
                                else
                                {
                                    throw new Exception("通道" + (全局变量.NO_CHS+1) + "符号上传有误");
                                }

                                //记录双精度的实时值
                                全局变量.read_double[全局变量.NO_CHS] = Double.Parse(Settings[全局变量.NO_CHS].real.Text);
                                
                                //记录上限值和下限值
                                全局变量.UpperLimit[全局变量.NO_CHS] = (int)全局变量.SBUF_TEMP[7];
                                全局变量.LowerLimit[全局变量.NO_CHS] = (int)全局变量.SBUF_TEMP[8];
                                //显示状态
                                if(全局变量.SBUF_TEMP[9]==0)
                                {
                                    Display.Rows[全局变量.NO_CHS].Cells[3].Value = "正常";
                                    Display.Rows[全局变量.NO_CHS].Cells[3].Style.ForeColor = Color.Black;
                                    Display.Rows[全局变量.NO_CHS].Cells[0].Style.BackColor = SystemColors.ControlLightLight;
                                    Display.Rows[全局变量.NO_CHS].Cells[0].Style.SelectionBackColor = SystemColors.ControlLightLight;
                                }
                                else if(全局变量.SBUF_TEMP[9]==1)
                                {
                                    Display.Rows[全局变量.NO_CHS].Cells[3].Value = "异常";
                                    Display.Rows[全局变量.NO_CHS].Cells[3].Style.ForeColor = Color.Red;
                                    Display.Rows[全局变量.NO_CHS].Cells[0].Style.BackColor = Color.Red;
                                    Display.Rows[全局变量.NO_CHS].Cells[0].Style.SelectionBackColor = Color.Red;
                                }
                                else
                                {
                                    throw new Exception("通道" + (全局变量.NO_CHS + 1) + "状态上传有误");
                                }
                                
                                //显示控制状态
                                if (全局变量.SBUF_TEMP[10] == 0)
                                {
                                    Display.Rows[全局变量.NO_CHS].Cells[4].Style.BackColor = SystemColors.ControlLightLight;
                                    Display.Rows[全局变量.NO_CHS].Cells[4].Style.SelectionBackColor = SystemColors.ControlLightLight;
                                }
                                else if (全局变量.SBUF_TEMP[10] == 1)
                                {
                                    Display.Rows[全局变量.NO_CHS].Cells[4].Style.BackColor = Color.LightPink;
                                    Display.Rows[全局变量.NO_CHS].Cells[4].Style.SelectionBackColor = Color.LightPink;
                                }
                                else
                                {
                                    throw new Exception("通道" + (全局变量.NO_CHS + 1) + "控制状态上传有误");
                                }

                                int NumOfPoint = (全局变量.MaxReadIndex[全局变量.NO_CHS] + 1) * 30;
                                //暂存实时值,最多为600个
                                for (int num = 0; num < 599; num++)
                                {
                                    Settings[全局变量.NO_CHS].the_time[599-num]=Settings[全局变量.NO_CHS].the_time[598-num];
                                    Settings[全局变量.NO_CHS].read_double[599-num]=Settings[全局变量.NO_CHS].read_double[598-num];

                                }
                                Settings[全局变量.NO_CHS].the_time[0] = DateTime.Now.ToLongTimeString();
                                Settings[全局变量.NO_CHS].read_double[0] = 全局变量.read_double[全局变量.NO_CHS];


                                    //更新实时图形的显示
                                    Settings[全局变量.NO_CHS].chart.Series[0].Points.Clear();
                                    全局变量.ValueMin[全局变量.NO_CHS] = 全局变量.ValueMax[全局变量.NO_CHS] = (int)Math.Abs(Settings[全局变量.NO_CHS].read_double[0]);
                                    //插入的显示的点的个数
                                    for (int num = 0; num < NumOfPoint; num++)
                                    {
                                        Settings[全局变量.NO_CHS].chart.Series[0].Points.AddXY(
                                        Settings[全局变量.NO_CHS].the_time[NumOfPoint-1 - num],
                                        Settings[全局变量.NO_CHS].read_double[NumOfPoint-1 - num]);
                                        //显示备注
                                        Settings[全局变量.NO_CHS].chart.Series[0].Points[num].ToolTip =
                                            Settings[全局变量.NO_CHS].the_time[NumOfPoint-1 - num]+" "+
                                            Settings[全局变量.NO_CHS].read_double[NumOfPoint - 1 - num].ToString("f2") + "μC/m³";

                                        int TempValue = (int)Math.Abs(Settings[全局变量.NO_CHS].read_double[NumOfPoint - 1 - num]);
                                        //更新最大值
                                        if (TempValue > 全局变量.ValueMax[全局变量.NO_CHS])
                                        {
                                            全局变量.ValueMax[全局变量.NO_CHS] = TempValue;
                                        }
                                        //更新最小值
                                        else if (TempValue < 全局变量.ValueMin[全局变量.NO_CHS])
                                        {
                                            全局变量.ValueMin[全局变量.NO_CHS] = TempValue;
                                        }
                                    }
                                    Settings[全局变量.NO_CHS].max.Text = 全局变量.int_to_2Char(全局变量.ValueMax[全局变量.NO_CHS]);
                                    Settings[全局变量.NO_CHS].min.Text = 全局变量.int_to_2Char(全局变量.ValueMin[全局变量.NO_CHS]);
                                

                                #region 填写日志文件
                                string Target= "通道" + (全局变量.NO_CHS+1) + Display.Rows[全局变量.NO_CHS].Cells[1].Value.ToString();
                                //如果文件夹不存在 则创建
                                DirectoryInfo find_log = new DirectoryInfo("log/" +Target+ "/");
                                if (find_log.Exists == false)
                                {
                                    find_log.Create();
                                }
                                //写入实时值日志文件
                                string today = DateTime.Now.ToString("yyyyMMdd");
                                if (!File.Exists("log/" + Target + "/" + today + ".txt"))//如果是这个日期文件不存在
                                {
                                    StreamWriter sw = File.CreateText("log/" + Target + "/" + today + ".txt");//创建文件或者打开空文件
                                    sw.Close();//关闭文件

                                }

                                StreamWriter sw2 = File.AppendText("log/" + Target + "/" + today + ".txt");
                                sw2.WriteLine(Settings[全局变量.NO_CHS].real.Text + " " + DateTime.Now.ToString("HH:mm:ss"));//实时值写入文件

                                //sw2.WriteLine(Settings[全局变量.NO_CHS].real.Text + " " + DateTime.Now.AddSeconds(1).ToString("HH:mm:ss"));//实时值+1s
                                //sw2.WriteLine(Settings[全局变量.NO_CHS].real.Text + " " + DateTime.Now.AddSeconds(2).ToString("HH:mm:ss"));//实时值+2s
                                //sw2.WriteLine(Settings[全局变量.NO_CHS].real.Text + " " + DateTime.Now.AddSeconds(3).ToString("HH:mm:ss"));//实时值+3s
                                sw2.Close();
                                
                                //写入最大值日志文件
                                if (!File.Exists("log/" + Target + "/" + today + "max.txt"))//如果是这个日期文件不存在
                                {
                                    StreamWriter sw = File.CreateText("log/" + Target + "/" + today + "max.txt");//创建文件或者打开空文件
                                    sw.Close();//关闭文件
                                }

                                StreamWriter sw3 = File.AppendText("log/" + Target + "/" + today +"max.txt");
                                sw3.WriteLine(全局变量.ValueMax[全局变量.NO_CHS].ToString() + " " + DateTime.Now.ToString("HH:mm:ss"));//最大值写入文件

                                //sw3.WriteLine(全局变量.ValueMax[全局变量.NO_CHS].ToString() + " " + DateTime.Now.AddSeconds(1).ToString("HH:mm:ss"));//最大值+1s
                                //sw3.WriteLine(全局变量.ValueMax[全局变量.NO_CHS].ToString() + " " + DateTime.Now.AddSeconds(2).ToString("HH:mm:ss"));//最大值+2s
                                //sw3.WriteLine(全局变量.ValueMax[全局变量.NO_CHS].ToString() + " " + DateTime.Now.AddSeconds(3).ToString("HH:mm:ss"));//最大值+3s
                                sw3.Close();
                                #endregion
                                
                            }
                            
                        }
                    }

                    #endregion
                

                全局变量.NO_CHS++;
                if (全局变量.NO_CHS > 5) 全局变量.NO_CHS = 0;
            }
            catch (Exception ex)
            {
                全局变量.msg.textBox1.Text = ex.Message;
                全局变量.msg_show = true;
            }

            //显示错误信息，时间间隔为每分钟,显示过的信息就不再显示
            if (全局变量.msg_show)
            {
                int alert_time = DateTime.Now.Minute;
                if (alert_time != 全局变量.time_temp_minute)
                {
                    全局变量.time_temp_minute = alert_time;
                    全局变量.msg.Show();
                    全局变量.msg_show = false;
                }
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 &&
                e.RowIndex >= 0 &&
                Display.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "单击")
            {
                try
                {

                    timer1.Enabled = false;
                    Thread.Sleep(160);

                    全局变量.control_sbuf[0] = 36;//send the ASCII code of $
                    全局变量.control_sbuf[1] = 全局变量.NO_CHS;//通道号
                    全局变量.control_sbuf[2] = 67;//send the ASCII code of C
                    全局变量.control_sbuf[3] = 76;//send the ASCII code of L
                    全局变量.control_sbuf[4] = 84;//send the ASCII code of T
                    //校验位
                    全局变量.control_sbuf[5] = (byte)(全局变量.control_sbuf[0] ^ 全局变量.control_sbuf[1] ^ 全局变量.control_sbuf[2] ^ 全局变量.control_sbuf[3] ^ 全局变量.control_sbuf[4]);
                    全局变量.control_sbuf[6] = 42;//send the ASCII code if *   


                    serialPort1.DiscardInBuffer();//清空缓冲区
                    serialPort1.Write(全局变量.read_sbuf, 0, 6);//向下位机发送读取指令
                    Thread.Sleep(130);//发送完指令以后在这里做延时，给串口一点时间发送和接收数据此时串口可能正在接收数据呢
                    timer1.Enabled = true;

                }
                catch (Exception ex)//
                {
                    MessageBox.Show(ex.Message);
                }
                
            }

            if (e.ColumnIndex == 5 &&
                e.RowIndex >= 0 &&
                Display.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "单击")
            {
                Settings[e.RowIndex].Show();
                SettingsShow[e.RowIndex] = true;
                Settings[e.RowIndex].remarks.Text = Display.Rows[e.RowIndex].Cells[1].Value.ToString();
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)//点击红叉的关闭函数
        {
            SaveRemarks();  
        }
        //保存备注文件
       private void SaveRemarks()
        {
            StreamWriter sw = File.CreateText("Remarks.txt");//创建文本文件Remarks.txt
            sw.WriteLine("#备注文件!");
            for (byte num = 0; num < 16; num++)
            {
                sw.WriteLine("#---地址" + num.ToString() + "备注");
                sw.WriteLine(Display.Rows[num].Cells[1].Value.ToString());//关闭后将备注写入文件
                sw.WriteLine("#");
            }
            sw.Close();
        }

       private void Start_Click(object sender, EventArgs e)
       {
           Button B = sender as Button;
           try
           {
               switch (B.Text)
               {
                   case "开始":
                       {
                           if (!serialPort1.IsOpen)
                           {
                               serialPort1.PortName = 串口选择.Text;//读取选择的串口
                               serialPort1.Open();
                           }
                           else
                           {
                               if (serialPort1.PortName != 串口选择.Text)
                               {
                                   serialPort1.Close();
                                   serialPort1.PortName = 串口选择.Text;//读取选择的串口
                                   serialPort1.Open();
                               }
                           }
                           Display.Columns[1].ReadOnly = true;
                           timer1.Start();
                           //timer1.Enabled = true;

                           B.Text = "停止";
                           B.BackColor = Color.Lime;//加上颜色更显眼
                           B.Cursor = Cursors.Hand;//设定鼠标样式
                       } break;
                   case "停止":
                       {
                           timer1.Stop();
                           Thread.Sleep(160);
                           serialPort1.Close();

                           Display.Columns[1].ReadOnly = false;
                           for (int num = 0; num < 16;num++ )
                           {
                               Display.Rows[num].Cells[2].Value = "-";
                               Display.Rows[num].Cells[3].Value = "-";
                           }
                               

                           B.Text = "开始";
                           B.BackColor = SystemColors.Control;//加上颜色更显眼
                           B.Cursor = Cursors.Arrow;//设定鼠标样式
                       } break;
               }
           }
           catch (Exception ex)//
           {
               MessageBox.Show(ex.Message);
           }
       }

        
    }
}
