using System.Windows.Forms;
using LightingDown.UI;
using LightingDown.Download.Core;
using System.Diagnostics;
using LightingDown.Properties;
namespace LightingDown
{
    public partial class MainForm : Form
    {
        #region 主窗口单例模式
        private static  MainForm instance;
        
        private MainForm()
        {
            InitializeComponent();
        }

        public static MainForm Instance
        {
            get
            {
                if(instance==null)
                {
                    instance = new MainForm();
                }
                return instance;
            }
        }
        #endregion

        #region 字段

        public TaskListHold.TaskListHoder holder = new LightingDown.TaskListHold.TaskListHoder();

        #endregion

        #region 响应事件函数

        private void NewTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.NewTask();
        }

        private void MainTimer_Tick(object sender, System.EventArgs e)
        {
            this.SpeedLabel.Text= string.Format("{0:0.##KB/s}", DownloadManager.Instance.TotalDownloadRate / 1024.0);
            taskListForm1.UpdateTable();
        }

        private void StartSelectedTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.StartTask(false);
        }

        private void PauseSelectedTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.PauseTask(false);
        }

        private void RemoveSelectedTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.RemoveTask(false);
        }

        private void 退出XToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void StartAllTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.StartTask(true);
        }

        private void PauseAllTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.PauseTask(true);
        }

        private void RemoveAllTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.RemoveTask(true);
        }

        private void ClearEndedTask_Click(object sender, System.EventArgs e)
        {
            taskListForm1.ClearEndedTask();
        }

        private void AutoShutDown_Click(object sender, System.EventArgs e)
        {
            taskListForm1.IsAutoShutDown = !taskListForm1.IsAutoShutDown;
            shutDownLabel.Text = taskListForm1.IsAutoShutDown ? "自动关机状态:启动" : "自动关机状态:关闭";
        }

        private void AboutBox_Click(object sender, System.EventArgs e)
        {
            using (AboutBox aboutBox = new AboutBox())
            {
                aboutBox.ShowDialog();
            }
        }

        private void OpenDirectory_Click(object sender, System.EventArgs e)
        {
            taskListForm1.OpenDirectory();
        }

        private void HomePage_Click(object sender, System.EventArgs e)
        {
            Process.Start("iexplore.exe",@"http://www.cnblogs.com/michaelguan");
        }

        private void Config_Click(object sender, System.EventArgs e)
        {
            using (ConfigForm configform=new ConfigForm())
            {
                configform.ShowDialog(this);
            }
        }

        private void 退出XToolStripMenuItem1_Click(object sender, System.EventArgs e)
        {
            Close();
        }


        private void notifyIcon_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.WindowState==FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
                //this.ShowInTaskbar = false;
            }
            this.Activate();
        }

        private void ImportFromXml_Click(object sender, System.EventArgs e)
        {
            string path = string.Empty;
            using (OpenFileDialog fd=new OpenFileDialog())
            {
                fd.Filter = "Xml文件|*.xml";
                if(fd.ShowDialog()==DialogResult.OK)
                {
                    path = fd.FileName;
                }
            }
            holder.LoadTaskList(path);
        }
        #endregion

        #region 公有函数

        /// <summary>
        /// 在任务栏显示水泡提示
        /// </summary>
        /// <param name="timeOut"></param>
        /// <param name="tipTitle"></param>
        /// <param name="tipText"></param>
        /// <param name="tipIcon"></param>
        public void ShowBalloonTip(
            int timeOut,
            string tipTitle,
            string tipText,
            ToolTipIcon tipIcon)
        {
            this.notifyIcon.ShowBalloonTip(timeOut, tipTitle, tipText, tipIcon);
        }

        #endregion

        private void MainForm_Load(object sender, System.EventArgs e)
        {     
            holder.LoadTaskList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool allTaskEnd = true;
            for (int i = 0; i < DownloadManager.Instance.Downloaders.Count; i++)
            {
                allTaskEnd &= (!DownloadManager.Instance.Downloaders[i].IsWorking());
            }
            if (Settings.Default.ShutNotify==true && !allTaskEnd)
            {
                if (MessageBox.Show("当前有正在下载中的任务,确认要关闭程序吗?\n确认关闭请点是,继续下载请点否.","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            using (DownloadManager.Instance.locker.LockList(true))
            {
                for (int i = 0; i < DownloadManager.Instance.Downloaders.Count; i++)
                {
                    DownloadManager.Instance.Downloaders[i].Pause();
                }
            }
            holder.SaveTaskList();
            Settings.Default.Save();
            LightingDown.Download.Core.Helper.CoreSettings.Instance.Save();
        }

    }
        


}
