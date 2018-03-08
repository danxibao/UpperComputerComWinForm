namespace Charge_monitoring
{
    partial class Form_limit_set
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_limit_set));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.max = new System.Windows.Forms.MaskedTextBox();
            this.min = new System.Windows.Forms.MaskedTextBox();
            this.period = new System.Windows.Forms.ComboBox();
            this.label1_2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 21F);
            this.label2.Location = new System.Drawing.Point(55, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "上限值";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 21F);
            this.label3.Location = new System.Drawing.Point(55, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "下限值";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(155, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 32);
            this.button1.TabIndex = 8;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 21F);
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "最大读取时间";
            // 
            // max
            // 
            this.max.Font = new System.Drawing.Font("SimSun", 15F);
            this.max.Location = new System.Drawing.Point(212, 16);
            this.max.Mask = "99";
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(50, 30);
            this.max.TabIndex = 13;
            // 
            // min
            // 
            this.min.Font = new System.Drawing.Font("SimSun", 15F);
            this.min.Location = new System.Drawing.Point(212, 66);
            this.min.Mask = "99";
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(50, 30);
            this.min.TabIndex = 14;
            // 
            // period
            // 
            this.period.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.period.Font = new System.Drawing.Font("SimSun", 15F);
            this.period.FormattingEnabled = true;
            this.period.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.period.Location = new System.Drawing.Point(212, 117);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(50, 28);
            this.period.TabIndex = 15;
            // 
            // label1_2
            // 
            this.label1_2.AutoSize = true;
            this.label1_2.Font = new System.Drawing.Font("SimSun", 15F);
            this.label1_2.Location = new System.Drawing.Point(278, 23);
            this.label1_2.Name = "label1_2";
            this.label1_2.Size = new System.Drawing.Size(89, 20);
            this.label1_2.TabIndex = 16;
            this.label1_2.Text = "(μC/m³)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 15F);
            this.label4.Location = new System.Drawing.Point(280, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "(μC/m³)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("SimSun", 15F);
            this.label5.Location = new System.Drawing.Point(300, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "分钟";
            // 
            // Form_limit_set
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 223);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1_2);
            this.Controls.Add(this.period);
            this.Controls.Add(this.min);
            this.Controls.Add(this.max);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_limit_set";
            this.ShowIcon = false;
            this.Text = "上下限";
            this.Load += new System.EventHandler(this.Form_limit_set_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox max;
        private System.Windows.Forms.MaskedTextBox min;
        private System.Windows.Forms.ComboBox period;
        private System.Windows.Forms.Label label1_2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}