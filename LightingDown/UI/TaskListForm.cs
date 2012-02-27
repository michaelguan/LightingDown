using System.Windows.Forms;
using LightingDown.Download.Core;
using XPTable.Models;
using LightingDown.Properties;
using System;
using System.Collections;
using System.Media;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace LightingDown.UI
{
    //[ToolboxBitmap("")]
    public partial class TaskListForm : UserControl
    {
        #region 私有变量

        Hashtable rowToTask = new Hashtable();
        Hashtable taskToRow = new Hashtable();
        private bool isAutoShutDown=false;

        #endregion

        #region 属性

        public bool IsAutoShutDown
        {
            get
            {
                return isAutoShutDown;
            }
            set
            {
                isAutoShutDown = value;
            }
        }

        #endregion

        #region 构造函数

        public TaskListForm()
        {
            InitializeComponent();

            DownloadManager.Instance.DownloadAdd += new System.EventHandler<DownloadEventArgs>(Instance_DownloadAdd);
            DownloadManager.Instance.DownloadEnd += new System.EventHandler<DownloadEventArgs>(Instance_DownloadEnd);
            DownloadManager.Instance.DownloadRemove += new System.EventHandler<DownloadEventArgs>(Instance_DownloadRemove);
            DownloadManager.Instance.DownloadPaused += new EventHandler<DownloadEventArgs>(Instance_DownloadPaused);
            DownloadManager.Instance.DownloadEndWithError += new EventHandler<DownloadEventArgs>(Instance_DownloadEndWithError);
            DownloadManager.Instance.AllDownloadEnd += new EventHandler(Instance_AllDownloadEnd);
            

            for (int i = 0; i < DownloadManager.Instance.Downloaders.Count; i++)
            {
                AddTask(DownloadManager.Instance.Downloaders[i]);
            }
        }

        #endregion

        #region 事件处理函数

        void Instance_DownloadEndWithError(object sender, DownloadEventArgs e)
        {
            SetStateImage(e.Downloader, Resources.Error);
            Row row = taskToRow[e.Downloader] as Row;
            row.Cells[3].Text = "0KB/s";
            ShowThreadInfo(string.Format("任务{0}下载失败.URL:{1}",e.Downloader.FileName,e.Downloader.URL),Color.DarkGreen);
        }

        void Instance_DownloadRemove(object sender, DownloadEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                Row row = taskToRow[e.Downloader] as Row;
                if (row!=null)
                {
                    row.Cells.Clear();
                }
                taskToRow[e.Downloader] = null;
                rowToTask[row] = null;
                tableModel.Rows.Remove(row);
                ShowThreadInfo(string.Format("任务{0}被删除.URL:{1}", e.Downloader.FileName,e.Downloader.URL), Color.DarkGreen);
            });
        }

        void Instance_AllDownloadEnd(object sender, EventArgs e)
        {
            if (isAutoShutDown)
            {
                SystemManager.ShutDown();
            }
        }

        void Instance_DownloadPaused(object sender, DownloadEventArgs e)
        {
            SetStateImage(e.Downloader, Resources.Paused);
            Row row = taskToRow[e.Downloader] as Row;
            row.Cells[3].Text = "0KB/s";
            ShowThreadInfo(string.Format("任务{0}用户取消下载.URL:{1}", e.Downloader.FileName,e.Downloader.URL), Color.DarkGreen);
        }

        void Instance_DownloadEnd(object sender, DownloadEventArgs e)
        {
            SetStateImage(e.Downloader, Resources.Completed);
            Row row = taskToRow[e.Downloader] as Row;
            row.Cells[2].Data = 100;
            row.Cells[3].Text = "0KB/s";
            row.Cells[4].Text = row.Cells[5].Text;

            if (Settings.Default.PlayAudio)
            {
                SoundPlayer.PlayCompleteSound();
            }

            if (Settings.Default.EndOpration=="打开文件夹")
            {
                Process.Start("explorer.exe",Path.GetDirectoryName(e.Downloader.LocalFilePath));
            }
            else if (Settings.Default.EndOpration=="打开文件")
            {
                Process.Start(e.Downloader.LocalFilePath);
            }
            MainForm.Instance.ShowBalloonTip(30, "提示", string.Format("任务{0}下载完成了.", e.Downloader.FileName), ToolTipIcon.Info);
            ShowThreadInfo(string.Format("任务{0}下载完成.URL:{1}", e.Downloader.FileName,e.Downloader.URL), Color.DarkGreen);
        }

        void Instance_DownloadAdd(object sender, DownloadEventArgs e)
        {
            if (IsHandleCreated)
            {
                this.BeginInvoke((MethodInvoker)delegate() { AddTask(e.Downloader); });
            }
            else
            {
                AddTask(e.Downloader);
            }
            ShowThreadInfo(string.Format("任务{0}创建了.URL:{1}", e.Downloader.FileName,e.Downloader.URL), Color.DarkGreen);
        }

        void d_SegmentStopped(object sender, SegmentEventArgs e)
        {
            ShowThreadInfo(string.Format("任务{0},线程{1}下载完成.",e.Downloader.FileName,e.Segment.Index),Color.Blue);
        }

        void d_SegmentStarted(object sender, SegmentEventArgs e)
        {
            ShowThreadInfo(string.Format("任务{0},线程{1}开始下载.", e.Downloader.FileName, e.Segment.Index),Color.Blue);
        }

        void d_SegmentFailed(object sender, SegmentEventArgs e)
        {
            ShowThreadInfo(string.Format("任务{0},线程{1}停止下载.", e.Downloader.FileName, e.Segment.Index),Color.Blue);
        }

        private void Start_Click(object sender, System.EventArgs e)
        {
            StartTask(false);
        }

        private void StartAll_Click(object sender, System.EventArgs e)
        {
            StartTask(true);
        }

        private void Pause_Click(object sender, System.EventArgs e)
        {
            PauseTask(false);
        }

        private void PauseAll_Click(object sender, System.EventArgs e)
        {
            PauseTask(true);
        }

        private void Remove_Click(object sender, System.EventArgs e)
        {
            RemoveTask(false);
        }

        private void RemoveAll_Click(object sender, System.EventArgs e)
        {
            RemoveTask(true);
        }

        private void Clear_Click(object sender, System.EventArgs e)
        {
            ClearEndedTask();
        }

        /// <summary>
        /// 任务完成后，双击任务可以打开下载的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tasktable_CellDoubleClick(object sender, XPTable.Events.CellMouseEventArgs e)
        {
            Row row = e.Cell.Row;
            Downloader d = rowToTask[row] as Downloader;
            if (d.State == DownloadState.Ended)
            {
                Process.Start(d.LocalFilePath);
            }
        }

        private void tasktable_SelectionChanged(object sender, XPTable.Events.SelectionEventArgs e)
        {
            if (tableModel.Selections.SelectedItems.Length == 1)
            {
                Row row = tableModel.Selections.SelectedItems[0];
                Downloader d = rowToTask[row] as Downloader;

                string taskinformation = string.Format("文件名称:{0}\n文件大小:{1}\n文件类型:{2}\n本地文件:{3}\nURL:{4}\n创建时间:{5}\n开始时间:{6}\n下载状态:{7}",
                                                   d.FileName,
                                                   ByteFormatter.ToString(d.FileSize),
                                                   d.FileTypeName,
                                                   d.LocalFilePath,
                                                   d.URL,
                                                   d.CreatedTime,
                                                   d.StartTime,
                                                   d.State
                                                    );
                ShowTaskInfo(taskinformation);

                string linkinformation = string.Empty;
                if (d.ServerFileInfo != null)
                {
                    linkinformation = string.Format("ResponseUri:{0}\nServer:{1}\nMethod:{2}\nLastModified:{3}\nFileType:{4}\nAcceptRange:{5}\nFileSize:{6}\nStatusCode:{7}\nStatusDescription:{8}\nCharacterSet:{9}\nContent-Encoding:{10}\nProtocol Version:{11}",
                                          d.ServerFileInfo.ResponseUri,
                                          d.ServerFileInfo.Server,
                                          d.ServerFileInfo.Method,
                                          d.ServerFileInfo.LastModified,
                                          d.ServerFileInfo.FileType,
                                          d.ServerFileInfo.AcceptRange,
                                          d.ServerFileInfo.FileSize,
                                          d.ServerFileInfo.StatueCode,
                                          d.ServerFileInfo.StatusDescription,
                                          d.ServerFileInfo.CharacterSet,
                                          d.ServerFileInfo.ContentEncoding,
                                          d.ServerFileInfo.ProtocolVersion
                                          );
                }

                ShowLinkInfo(linkinformation);
            }
            else
            {
                ClearTextBox();
            }
        }

        private void 清除记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            threadTextBox.Clear();
        }


        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (tableModel.Selections.SelectedItems.Length==1)
            {
                Row row = tableModel.Selections.SelectedItems[0];
                Downloader d = rowToTask[row] as Downloader;
                Clipboard.SetText(d.URL);
                MessageBox.Show("URL已复制到剪贴板.");
            }
        }

        private void OpenDirectory_Click(object sender, System.EventArgs e)
        {
            OpenDirectory();
        }


        /// <summary>
        /// 当有任务的段创建完成时保存任务列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void d_SegmentsCreated(object sender, EventArgs e)
        {
            MainForm.Instance.holder.SaveTaskList();
        }

        #endregion

        #region 公有函数

        /// <summary>
        /// 显示新建任务窗口
        /// </summary>
        public void NewTask()
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                using (NewTaskForm taskForm = new NewTaskForm())
                {
                    taskForm.ShowDialog();
                }
            });
        }

        /// <summary>
        /// 更新界面数据
        /// </summary>
        public void UpdateTable()
        {
            for (int i = 0; i <tasktable.TableModel.Rows.Count; i++)
            {
                Row row = tasktable.TableModel.Rows[i];
                if (row==null)
                {
                    break;
                }

                Downloader d = rowToTask[row] as Downloader;
                if (d==null)
                {
                    break;
                }

                if (d.State==DownloadState.Working)
                {
                    SetStateImage(d, Resources.Working);
                    row.Cells[2].Data = (int)Math.Round(d.Progress);
                    row.Cells[3].Text = string.Format("{0:0.00}KB/s", d.Rate / 1024.0f);
                    row.Cells[4].Text = ByteFormatter.ToString(d.DownloadedSize);
                    row.Cells[5].Text = ByteFormatter.ToString(d.FileSize);
                    row.Cells[6].Text = TimeSpanFormatter.ToString(d.LeftTime);
                   // row.Cells[7].Text = TimeSpanFormatter.ToString(d.UsedTime);
                }
            }         
        }

        /// <summary>
        /// 开始任务
        /// </summary>
        public void StartTask(bool isAll)
        {
            int j = isAll ? tableModel.Rows.Count : tableModel.Selections.SelectedItems.Length;
            for (int i = 0; i < j; i++)
            {
                Row row = isAll ? tableModel.Rows[i] : tableModel.Selections.SelectedItems[i];
                Downloader d = rowToTask[row] as Downloader;
                d.Start();
                //SetStateImage(d, Resources.Working);
                ShowThreadInfo(string.Format("任务{0}创建了.URL:{1}", d.FileName,d.URL), Color.DarkGreen);
            }
        }

        /// <summary>
        /// 暂停任务
        /// </summary>
        public void PauseTask(bool isAll)
        {
            int j = isAll ? tableModel.Rows.Count : tableModel.Selections.SelectedItems.Length;

            for (int i = 0; i < j; i++)
            {
                Row row = isAll ? tableModel.Rows[i] : tableModel.Selections.SelectedItems[i];
                Downloader d = rowToTask[row] as Downloader;
                d.Pause();
            }
        }

        /// <summary>
        /// 删除任务
        /// </summary>
        /// <param name="isAll"></param>
        public void RemoveTask(bool isAll)
        {
            if ((!isAll && tableModel.Selections.SelectedItems.Length < 1) || (isAll && tableModel.Rows.Count<1))
            {
                return;
            }
            if (MessageBox.Show("确认要删除任务吗?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                int j = isAll ? tableModel.Rows.Count : tableModel.Selections.SelectedItems.Length;

                for (int i = 0; i < j; i++)
                {
                    Row row = isAll ? tableModel.Rows[i] : tableModel.Selections.SelectedItems[i];
                    Downloader d = rowToTask[row] as Downloader;
                    DownloadManager.Instance.Remove(d);
                  //  File.Delete(d.LocalFilePath);
                }
            }
            ClearTextBox();
        }

        /// <summary>
        /// 移除已完成任务
        /// </summary>
        public void ClearEndedTask()
        {
            for (int i = 0; i < tableModel.Rows.Count; i++)
            {
                Row row = tableModel.Rows[i];
                Downloader d = rowToTask[row] as Downloader;
                if (d.State==DownloadState.Ended)
                {
                    DownloadManager.Instance.Remove(d);
                }
            }
        }

        public void OpenDirectory()
        {
            if (tableModel.Selections.SelectedItems.Length == 1)
            {
                Row row = tableModel.Selections.SelectedItems[0];
                Downloader d = rowToTask[row] as Downloader;
                Process.Start("Explorer.exe",Path.GetDirectoryName(d.LocalFilePath));
            }
            else
            {
                string folder = DirectoryHelper.GetDefaultDirectory();
                Process.Start("Explorer.exe", folder);
            }
        }
        #endregion

        #region 私有函数
        /// <summary>
        /// 添加新的任务
        /// </summary>
        /// <param name="d"></param>
        private void AddTask(Downloader d)
        {
            d.SegmentFailed += new EventHandler<SegmentEventArgs>(d_SegmentFailed);
            d.SegmentStarted += new EventHandler<SegmentEventArgs>(d_SegmentStarted);
            d.SegmentStopped += new EventHandler<SegmentEventArgs>(d_SegmentStopped);
            d.SegmentsCreated += new EventHandler(d_SegmentsCreated);

            Row row = new Row();
            row.Cells.AddRange(new Cell[] {
                                            new Cell(),
                                            new Cell(d.FileName,d.FileIcon),
                                            new Cell((int)Math.Round(d.Progress)),
                                            new Cell(string.Format("{0:0.00}KB/s",d.Rate/1024.0f)),
                                            new Cell(ByteFormatter.ToString(d.DownloadedSize)),
                                            new Cell(ByteFormatter.ToString(d.FileSize)),
                                            new Cell(TimeSpanFormatter.ToString(d.LeftTime)),
                                            //new Cell(TimeSpanFormatter.ToString(d.UsedTime)),
                                            new Cell(d.FileTypeName)
                                            });

            row.Cells[1].ToolTipText = row.Cells[1].Text;
            rowToTask[row] = d;
            taskToRow[d] = row;

            if (d.State == DownloadState.NeedToPrepare ||
                d.State == DownloadState.paused || d.State==DownloadState.prepared)
            {
                SetStateImage(d, Resources.Paused);
            }
            else
            {
                SetStateImage(d, Resources.Working);
            }
            tasktable.TableModel.Rows.Add(row);

        }

        /// <summary>
        /// 设置表示状态的图片
        /// </summary>
        /// <param name="task"></param>
        /// <param name="image"></param>
        private void SetStateImage(Downloader task,Image image)
        {
            Row row = taskToRow[task] as Row;
            row.Cells[0].Image = image;
        }

        private void ShowThreadInfo(string information,Color color)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    if (threadTextBox.Text.Length>0)
                    {
                        threadTextBox.SelectionStart = threadTextBox.Text.Length;
                    }
                    threadTextBox.SelectionColor = color;
                    threadTextBox.AppendText(DateTime.Now + ":" + information + Environment.NewLine);
                });
            }
            catch 
            {
            }
            
        }

        private void ShowTaskInfo(string information)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    taskTextBox.Clear();
                    taskTextBox.SelectionColor = Color.Blue;
                    taskTextBox.AppendText(information);
                });
            }
            catch 
            {
            }
        }

        private void ShowLinkInfo(string information)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    linkTextBox.Clear();
                    linkTextBox.SelectionColor = Color.DarkGreen;
                    linkTextBox.AppendText(information);
                });
            }
            catch
            {

            }
        }

        private void ClearTextBox()
        {
            taskTextBox.Clear();
            linkTextBox.Clear();
        }

        #endregion

    }
}
