namespace LightingDown.UI
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.EndOPComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AutoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.audioCheckBox = new System.Windows.Forms.CheckBox();
            this.StartUpBox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.linkTimeBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.reTryDelayBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.minSegmentSizeBox = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.segmentCountBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.runToStartBox = new System.Windows.Forms.CheckBox();
            this.shutNitifyBox = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkTimeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reTryDelayBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minSegmentSizeBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentCountBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 269);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(428, 269);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(420, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "常规";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.runToStartBox);
            this.groupBox2.Controls.Add(this.EndOPComboBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.AutoStartCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(9, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务属性";
            // 
            // EndOPComboBox
            // 
            this.EndOPComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EndOPComboBox.FormattingEnabled = true;
            this.EndOPComboBox.Items.AddRange(new object[] {
            "无操作",
            "打开文件",
            "打开文件夹"});
            this.EndOPComboBox.Location = new System.Drawing.Point(116, 68);
            this.EndOPComboBox.Name = "EndOPComboBox";
            this.EndOPComboBox.Size = new System.Drawing.Size(121, 20);
            this.EndOPComboBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "任务完成后操作:";
            // 
            // AutoStartCheckBox
            // 
            this.AutoStartCheckBox.AutoSize = true;
            this.AutoStartCheckBox.Location = new System.Drawing.Point(17, 25);
            this.AutoStartCheckBox.Name = "AutoStartCheckBox";
            this.AutoStartCheckBox.Size = new System.Drawing.Size(126, 16);
            this.AutoStartCheckBox.TabIndex = 3;
            this.AutoStartCheckBox.Text = "新任务立即开始(&S)";
            this.AutoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shutNitifyBox);
            this.groupBox1.Controls.Add(this.audioCheckBox);
            this.groupBox1.Controls.Add(this.StartUpBox);
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "常规";
            // 
            // audioCheckBox
            // 
            this.audioCheckBox.AutoSize = true;
            this.audioCheckBox.Location = new System.Drawing.Point(17, 50);
            this.audioCheckBox.Name = "audioCheckBox";
            this.audioCheckBox.Size = new System.Drawing.Size(150, 16);
            this.audioCheckBox.TabIndex = 1;
            this.audioCheckBox.Text = "任务完成后播放声音(&P)";
            this.audioCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartUpBox
            // 
            this.StartUpBox.AutoSize = true;
            this.StartUpBox.Location = new System.Drawing.Point(17, 20);
            this.StartUpBox.Name = "StartUpBox";
            this.StartUpBox.Size = new System.Drawing.Size(138, 16);
            this.StartUpBox.TabIndex = 0;
            this.StartUpBox.Text = "开机启动闪电下载(&A)";
            this.StartUpBox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.folderTextBox);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(420, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "目录";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(234, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "浏览(&B)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(21, 39);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(198, 21);
            this.folderTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "默认目录:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(420, 244);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "连接";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.linkTimeBox);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.reTryDelayBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(8, 105);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(395, 86);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "超时";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "(1-20)";
            // 
            // linkTimeBox
            // 
            this.linkTimeBox.Location = new System.Drawing.Point(108, 50);
            this.linkTimeBox.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.linkTimeBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.linkTimeBox.Name = "linkTimeBox";
            this.linkTimeBox.Size = new System.Drawing.Size(58, 21);
            this.linkTimeBox.TabIndex = 4;
            this.linkTimeBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "重试次数:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(172, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "毫秒 (2000-60000)";
            // 
            // reTryDelayBox
            // 
            this.reTryDelayBox.Location = new System.Drawing.Point(108, 16);
            this.reTryDelayBox.Maximum = new decimal(new int[] {
            60000,
            0,
            0,
            0});
            this.reTryDelayBox.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.reTryDelayBox.Name = "reTryDelayBox";
            this.reTryDelayBox.Size = new System.Drawing.Size(58, 21);
            this.reTryDelayBox.TabIndex = 1;
            this.reTryDelayBox.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "重试等待时间:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.fileSizeLabel);
            this.groupBox3.Controls.Add(this.minSegmentSizeBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.segmentCountBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(8, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(395, 87);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "限制";
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Location = new System.Drawing.Point(211, 53);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(0, 12);
            this.fileSizeLabel.TabIndex = 5;
            // 
            // minSegmentSizeBox
            // 
            this.minSegmentSizeBox.Location = new System.Drawing.Point(108, 48);
            this.minSegmentSizeBox.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
            this.minSegmentSizeBox.Minimum = new decimal(new int[] {
            204800,
            0,
            0,
            0});
            this.minSegmentSizeBox.Name = "minSegmentSizeBox";
            this.minSegmentSizeBox.Size = new System.Drawing.Size(87, 21);
            this.minSegmentSizeBox.TabIndex = 4;
            this.minSegmentSizeBox.Value = new decimal(new int[] {
            204800,
            0,
            0,
            0});
            this.minSegmentSizeBox.ValueChanged += new System.EventHandler(this.minSegmentSizeBox_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "段的最小大小:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "(1-10)";
            // 
            // segmentCountBox
            // 
            this.segmentCountBox.Location = new System.Drawing.Point(108, 15);
            this.segmentCountBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.segmentCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.segmentCountBox.Name = "segmentCountBox";
            this.segmentCountBox.Size = new System.Drawing.Size(41, 21);
            this.segmentCountBox.TabIndex = 1;
            this.segmentCountBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segmentCountBox.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "默认线程(段)数:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定(&O)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(332, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(&C)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // runToStartBox
            // 
            this.runToStartBox.AutoSize = true;
            this.runToStartBox.Location = new System.Drawing.Point(17, 49);
            this.runToStartBox.Name = "runToStartBox";
            this.runToStartBox.Size = new System.Drawing.Size(234, 16);
            this.runToStartBox.TabIndex = 6;
            this.runToStartBox.Text = "启动闪电下载后立即开始未完成任务(&M)";
            this.runToStartBox.UseVisualStyleBackColor = true;
            // 
            // shutNitifyBox
            // 
            this.shutNitifyBox.AutoSize = true;
            this.shutNitifyBox.Location = new System.Drawing.Point(17, 80);
            this.shutNitifyBox.Name = "shutNitifyBox";
            this.shutNitifyBox.Size = new System.Drawing.Size(216, 16);
            this.shutNitifyBox.TabIndex = 2;
            this.shutNitifyBox.Text = "关闭时如有未完成任务,是否提醒(&N)";
            this.shutNitifyBox.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 305);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(436, 338);
            this.MinimumSize = new System.Drawing.Size(436, 338);
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.linkTimeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reTryDelayBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minSegmentSizeBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentCountBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox audioCheckBox;
        private System.Windows.Forms.CheckBox StartUpBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox EndOPComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox AutoStartCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown segmentCountBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown minSegmentSizeBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown linkTimeBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown reTryDelayBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.CheckBox runToStartBox;
        private System.Windows.Forms.CheckBox shutNitifyBox;

    }
}