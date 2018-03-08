using System;
using System.Collections.Generic;

namespace Charge_monitoring//这是工程的大包一层层向下包含
{

    public static class 全局变量
    {

        public static string[] Portname;//这样才子是字符数组
        
        //我自己定义或者修改的全局变量

        public static byte NO_CHS = 0;//设定当前通道数量
        public static byte[] SBUF_TEMP = new byte[4096];//这是串口读取数组缓冲区

        public static byte[] read_sbuf = new byte[7];//请求实时值的缓冲区
        public static byte[] control_sbuf = new byte[7];//安全控制缓冲区
        public static byte[] limit_set_sbuf = new byte[7];//设置上下限缓冲区

        public static int[] UpperLimit = new int[16];
        public static int[] LowerLimit = new int[16];

        public static byte[] read_sign = new byte[16];
        public static int[] read_integer = new int[16];
        public static int[] read_decimal = new int[16];

        public static string[] read_string = new string[16];
        public static double[] read_double = new double[16];

        public static int[] ValueMax = new int[16];
        public static int[] ValueMin = new int[16];

        public static int limit_set_max;
        public static int limit_set_min;
        public static Form_msg msg = new Form_msg();
        public static bool msg_show = false;
        public static int time_temp_minute;//每分钟记录
        public static int time_temp_second;//每秒记录
        public static string message;

        public static int[] MaxReadIndex=new int[16];
        public static void int_to_byte(int limit,out byte Hi,out byte Lo)
        {
            Hi=(byte)(limit/255);
            Lo=(byte)(limit-Hi*255);
        }


        public static string byte_to_string(byte Hi, byte Lo)
        {
            int temp = Hi << 8;
            temp |= Lo;
            if(temp>999)
                throw new Exception("2byte转换三位十进制数超出量程");
            else if (temp > 99)
                return Convert.ToString(temp);
            else if (temp > 9)
                return "0" + Convert.ToString(temp);
            else
                return "00" + Convert.ToString(temp);
        }

        public static int byte_to_int(byte Hi, byte Lo)
        {
            int temp = Hi << 8;
            temp |= Lo;
            if (temp > 999)
                throw new Exception("2byte转换三位十进制数超出量程");
            else
                return temp;
        }

        public static string int_to_3Char(int temp)
        {
            if (temp > 999)
                throw new Exception("2byte转换三位十进制数超出量程");
            else if (temp > 99)
                return Convert.ToString(temp);
            else if (temp > 9)
                return "0" + Convert.ToString(temp);
            else
                return "00" + Convert.ToString(temp);
        }

        public static string int_to_2Char(int temp)
        {
            if (temp > 99)
                throw new Exception("1byte转换两位十进制数超出量程");
            else if (temp > 9)
                return Convert.ToString(temp);
            else 
                return "0" + Convert.ToString(temp);
        }

        public static int byte_to_type(byte index)
        {
            int temp = 0;
            switch (index)
            {
                case 65: temp = 20;//A
                    break;
                case 66: temp = 25;//B
                    break;
                case 67: temp = 40;//C
                    break;
                case 68: temp = 50;//D
                    break;
                case 69: temp = 80;//E
                    break;
                case 70: temp = 100;//F
                    break;
                case 71: temp = 200;//G
                    break;
                case 72: temp = 700;//G
                    break;
            }
            return temp;
        }

    };



}
