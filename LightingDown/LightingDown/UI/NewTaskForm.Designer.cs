using LightingDown.Properties;

namespace LightingDown.UI
{
    partial class NewTaskForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textURl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textLocalFile = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericSegmentCount = new System.Windows.Forms.NumericUpDown();
            this.checkBoxIsAutoStart = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericSegmentCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "网址(URL):";
            // 
            // textURl
            // 
            this.textURl.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.textURl.Location = new System.Drawing.Point(83, 27);
            this.textURl.Name = "textURl";
            this.textURl.Size = new System.Drawing.Size(216, 21);
            this.textURl.TabIndex = 1;
            this.textURl.TextChanged += new System.EventHandler(this.textURl_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "存储目录：";
            // 
            // textLocalFile
            // 
            this.textLocalFile.Location = new System.Drawing.Point(83, 63);
            this.textLocalFile.Name = "textLocalFile";
            this.textLocalFile.Size = new System.Drawing.Size(216, 21);
            this.textLocalFile.TabIndex = 3;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(305, 62);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(38, 23);
            this.btn_Browse.TabIndex = 4;
            this.btn_Browse.Text = "...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "另存名称:";
            // 
            // textFileName
            // 
            this.textFileName.Location = new System.Drawing.Point(83, 99);
            this.textFileName.Name = "textFileName";
            this.textFileName.Size = new System.Drawing.Size(216, 21);
            this.textFileName.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "分段数:";
            // 
            // numericSegmentCount
            // 
            this.numericSegmentCount.Location = new System.Drawing.Point(83, 134);
            this.numericSegmentCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericSegmentCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericSegmentCount.Name = "numericSegmentCount";
            this.numericSegmentCount.Size = new System.Drawing.Size(35, 21);
            this.numericSegmentCount.TabIndex = 8;
            this.numericSegmentCount.Value = new decimal(new int[] {
            Settings.Default.DefaultSegmentCount,
            0,
            0,
            0});
            // 
            // checkBoxIsAutoStart
            // 
            this.checkBoxIsAutoStart.AutoSize = true;
            //this.checkBoxIsAutoStart.Checked = Settings.Default.AutoStart;
            this.checkBoxIsAutoStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsAutoStart.Location = new System.Drawing.Point(160, 136);
            this.checkBoxIsAutoStart.Name = "checkBoxIsAutoStart";
            this.checkBoxIsAutoStart.Size = new System.Drawing.Size(72, 16);
            this.checkBoxIsAutoStart.TabIndex = 9;
            this.checkBoxIsAutoStart.Text = "立即开始";
            this.checkBoxIsAutoStart.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(113, 187);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 10;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(224, 187);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 11;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // NewTaskForm
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(353, 223);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.checkBoxIsAutoStart);
            this.Controls.Add(this.numericSegmentCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.textLocalFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textURl);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(361, 256);
            this.Name = "NewTaskForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新建任务";
            this.Load += new System.EventHandler(this.NewTaskForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericSegmentCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textURl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textLocalFile;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericSegmentCount;
        private System.Windows.Forms.CheckBox checkBoxIsAutoStart;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}