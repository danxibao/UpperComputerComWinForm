namespace Charge_monitoring
{
    partial class FormMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.串口选择 = new System.Windows.Forms.ComboBox();
            this.Start = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Conditon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Control = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Parameter = new System.Windows.Forms.DataGridViewLinkColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Display)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 12F);
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "串口选择";
            // 
            // 串口选择
            // 
            this.串口选择.Font = new System.Drawing.Font("SimSun", 15F);
            this.串口选择.FormattingEnabled = true;
            this.串口选择.Location = new System.Drawing.Point(97, 12);
            this.串口选择.Name = "串口选择";
            this.串口选择.Size = new System.Drawing.Size(121, 28);
            this.串口选择.TabIndex = 16;
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("SimSun", 12F);
            this.Start.Location = new System.Drawing.Point(236, 6);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(160, 40);
            this.Start.TabIndex = 21;
            this.Start.Text = "开始";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Display
            // 
            this.Display.AllowUserToAddRows = false;
            this.Display.AllowUserToDeleteRows = false;
            this.Display.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 15F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Display.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Display.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Position,
            this.Type,
            this.Conditon,
            this.Control,
            this.Parameter});
            this.Display.Location = new System.Drawing.Point(0, 52);
            this.Display.Name = "Display";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 15F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Display.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Display.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Display.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Display.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("SimSun", 15F);
            this.Display.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            this.Display.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.Display.RowTemplate.Height = 32;
            this.Display.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Display.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Display.Size = new System.Drawing.Size(826, 555);
            this.Display.TabIndex = 22;
            this.Display.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ID.HeaderText = "序号";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 80;
            // 
            // Position
            // 
            this.Position.HeaderText = "位置";
            this.Position.Name = "Position";
            this.Position.Width = 180;
            // 
            // Type
            // 
            this.Type.HeaderText = "型号";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 160;
            // 
            // Conditon
            // 
            this.Conditon.HeaderText = "状态";
            this.Conditon.Name = "Conditon";
            this.Conditon.ReadOnly = true;
            this.Conditon.Width = 120;
            // 
            // Control
            // 
            this.Control.ActiveLinkColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.Control.DefaultCellStyle = dataGridViewCellStyle2;
            this.Control.HeaderText = "安全控制";
            this.Control.Name = "Control";
            this.Control.ReadOnly = true;
            this.Control.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Control.Text = "单击";
            this.Control.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Control.Width = 120;
            // 
            // Parameter
            // 
            this.Parameter.ActiveLinkColor = System.Drawing.Color.Blue;
            this.Parameter.HeaderText = "参数";
            this.Parameter.LinkColor = System.Drawing.Color.Blue;
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Parameter.Text = "单击";
            this.Parameter.VisitedLinkColor = System.Drawing.Color.Blue;
            this.Parameter.Width = 120;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "Application.StartupPath + \"\\\\log\"";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 601);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.串口选择);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "油品电荷监控系统4.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox 串口选择;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.DataGridView Display;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Conditon;
        private System.Windows.Forms.DataGridViewLinkColumn Control;
        private System.Windows.Forms.DataGridViewLinkColumn Parameter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}