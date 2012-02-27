using System;
using LightingDown.Download.Core;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Text;
using LightingDown.Properties;

namespace LightingDown.UI
{
    public partial class NewTaskForm : Form
    {
        #region 属性

        public string URL
        {
            get
            {
                return this.textURl.Text;
            }
        }

        public string LocalPath
        {
            get
            {
                return this.textLocalFile.Text;
            }
        }

        public string FileName
        {
            get
            {
                return this.textFileName.Text;
            }
        }

        public string LocalFile
        {
            get
            {
                return Path.Combine(this.LocalPath, this.FileName);
            }
        }

        public int SegmentCount
        {
            get
            {
                return (int)this.numericSegmentCount.Value;
            }
            
        }

        public bool IsAutoStart
        {
            get
            {
                return this.checkBoxIsAutoStart.Checked;
            }
        }
        #endregion

        #region 构造函数

        public NewTaskForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件处理函数

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    if (!Checker.IsvalidURL(this.URL))
                    {
                        MessageBox.Show("这是一个非法的URL,请输入正确的下载地址!",
                            MainForm.Instance.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DialogResult = DialogResult.None;
                        return;
                    }

                    if (Checker.UrlExists(this.URL))
                    {
                        MessageBox.Show("文件已在下载列表中,不需要建立新任务.",
                            MainForm.Instance.Text,MessageBoxButtons.OK,MessageBoxIcon.Information);

                        DialogResult = DialogResult.OK;
                        return;
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;

                        Downloader task = DownloadManager.Instance.Add(
                            this.URL,
                            this.LocalFile,
                            this.SegmentCount,
                            this.IsAutoStart);

                    }
                }
                catch
                {
                    DialogResult = DialogResult.None;

                    MessageBox.Show("出现未知错误！", MainForm.Instance.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
        }

        private void textURl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int index=URL.LastIndexOf('/');
                string text=URL.Substring(index+1);
                textFileName.Text = text;
            }
            catch
            {
                textFileName.Text = string.Empty;  
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdialog = new FolderBrowserDialog();
            fdialog.ShowNewFolderButton = true;

            if (fdialog.ShowDialog()==DialogResult.OK)
            {
                this.textLocalFile.Text = fdialog.SelectedPath;
            }
        }
        

        private void NewTaskForm_Load(object sender, EventArgs e)
        {
            this.textURl.Text = ClipBoardManager.GetText();
            this.textLocalFile.Text = DirectoryHelper.GetDefaultDirectory();
            checkBoxIsAutoStart.Checked = Settings.Default.AutoStart;
        }

        #endregion
    }
}
