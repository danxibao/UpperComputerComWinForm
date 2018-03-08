using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiaryChart
{
    public partial class FormChart : Form
    {
        string FileName;
        public FormChart()
        {
            InitializeComponent();


            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.LineColor = Color.Blue;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            chart.ChartAreas[0].CursorY.AutoScroll = true;
            chart.ChartAreas[0].AxisY.ScrollBar.Enabled = true;
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.LineColor = Color.Blue;
            chart.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;

            //chart.ChartAreas[0].AxisX.ScaleView.Position = 1;
            //chart.ChartAreas[0].AxisX.ScaleView.Size = 300;

            //将滚动内嵌到坐标轴中
            //chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            // 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            //chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFileDialog1.InitialDirectory = Application.StartupPath + "\\log";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 你的 处理文件路径代码
                    chart.Series[0].Points.Clear();

                    FileName = openFileDialog1.FileName;

                    StreamReader ReadDiaryText = File.OpenText(FileName);
                    string line;
                    string[] list = new string[2];
                    int num = 0;
                    while ((line = ReadDiaryText.ReadLine()) != null)
                    {
                        list = line.Split(' ');
                        chart.Series[0].Points.AddXY(
                                                list[1],
                                                list[0]);
                        chart.Series[0].Points[num].ToolTip = list[1] + " " + list[0] + "μC/m³";
                        num++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
