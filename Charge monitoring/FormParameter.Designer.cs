namespace Charge_monitoring
{
    partial class FormParameter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1_2 = new System.Windows.Forms.Label();
            this.Label1_1 = new System.Windows.Forms.Label();
            this.remarks = new System.Windows.Forms.TextBox();
            this.SetParameter = new System.Windows.Forms.Button();
            this.real = new System.Windows.Forms.TextBox();
            this.min = new System.Windows.Forms.TextBox();
            this.max = new System.Windows.Forms.TextBox();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // label1_2
            // 
            this.label1_2.AutoSize = true;
            this.label1_2.Font = new System.Drawing.Font("SimSun", 15F);
            this.label1_2.Location = new System.Drawing.Point(24, 70);
            this.label1_2.Name = "label1_2";
            this.label1_2.Size = new System.Drawing.Size(399, 20);
            this.label1_2.TabIndex = 6;
            this.label1_2.Text = "(μC/m³)       (μC/m³)       (μC/m³) ";
            // 
            // Label1_1
            // 
            this.Label1_1.AutoSize = true;
            this.Label1_1.Font = new System.Drawing.Font("SimSun", 21F);
            this.Label1_1.Location = new System.Drawing.Point(15, 42);
            this.Label1_1.Name = "Label1_1";
            this.Label1_1.Size = new System.Drawing.Size(404, 28);
            this.Label1_1.TabIndex = 5;
            this.Label1_1.Text = "最大值     实时值     最小值";
            // 
            // remarks
            // 
            this.remarks.BackColor = System.Drawing.SystemColors.Control;
            this.remarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.remarks.Font = new System.Drawing.Font("SimSun", 21F);
            this.remarks.Location = new System.Drawing.Point(12, 5);
            this.remarks.MaxLength = 6;
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            this.remarks.Size = new System.Drawing.Size(240, 32);
            this.remarks.TabIndex = 0;
            this.remarks.Text = "油库#号";
            this.remarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SetParameter
            // 
            this.SetParameter.Font = new System.Drawing.Font("SimSun", 15F);
            this.SetParameter.Location = new System.Drawing.Point(258, 5);
            this.SetParameter.Name = "SetParameter";
            this.SetParameter.Size = new System.Drawing.Size(147, 32);
            this.SetParameter.TabIndex = 11;
            this.SetParameter.Text = "参数设置";
            this.SetParameter.UseVisualStyleBackColor = true;
            this.SetParameter.Click += new System.EventHandler(this.SetParameter_Click);
            // 
            // real
            // 
            this.real.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.real.Font = new System.Drawing.Font("SimSun", 18F);
            this.real.Location = new System.Drawing.Point(158, 93);
            this.real.Name = "real";
            this.real.ReadOnly = true;
            this.real.Size = new System.Drawing.Size(112, 35);
            this.real.TabIndex = 14;
            // 
            // min
            // 
            this.min.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.min.Font = new System.Drawing.Font("SimSun", 18F);
            this.min.Location = new System.Drawing.Point(342, 93);
            this.min.Name = "min";
            this.min.ReadOnly = true;
            this.min.Size = new System.Drawing.Size(50, 35);
            this.min.TabIndex = 17;
            // 
            // max
            // 
            this.max.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.max.Font = new System.Drawing.Font("SimSun", 18F);
            this.max.Location = new System.Drawing.Point(42, 93);
            this.max.Name = "max";
            this.max.ReadOnly = true;
            this.max.Size = new System.Drawing.Size(50, 35);
            this.max.TabIndex = 18;
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Location = new System.Drawing.Point(-4, 134);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Red};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(438, 279);
            this.chart.TabIndex = 19;
            this.chart.Text = "chart";
            // 
            // FormParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 415);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.max);
            this.Controls.Add(this.min);
            this.Controls.Add(this.real);
            this.Controls.Add(this.SetParameter);
            this.Controls.Add(this.remarks);
            this.Controls.Add(this.label1_2);
            this.Controls.Add(this.Label1_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormParameter";
            this.Text = "FormParameter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Load += new System.EventHandler(this.FormParameter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_2;
        private System.Windows.Forms.Label Label1_1;
        private System.Windows.Forms.Button SetParameter;
        public System.Windows.Forms.TextBox remarks;
        public System.Windows.Forms.TextBox real;
        public System.Windows.Forms.TextBox min;
        public System.Windows.Forms.TextBox max;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart;
    }
}