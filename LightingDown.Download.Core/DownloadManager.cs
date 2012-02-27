using System;
using System.Collections.Generic;

namespace LightingDown.Download.Core
{
    public class DownloadManager
    {
        #region 单例模式
        public static readonly DownloadManager Instance = new DownloadManager();

        private DownloadManager()
        {
        }
        #endregion

        #region 字段

        private List<Downloader> downloads = new List<Downloader>();

        public DownloadLocker locker = new DownloadLocker();

        #endregion

        #region 事件

        public event EventHandler<DownloadEventArgs> DownloadAdd;

        public event EventHandler<DownloadEventArgs> DownloadEnd;

        public event EventHandler<DownloadEventArgs> DownloadRemove;

        public event EventHandler<DownloadEventArgs> DownloadEndWithError;

        public event EventHandler<DownloadEventArgs> DownloadPaused;

        public event EventHandler AllDownloadEnd;

        #endregion

        #region 属性

        public List<Downloader> Downloaders
        {
            get
            {
                return this.downloads;
            }
        }

        public double TotalDownloadRate
        {
            get
            {
                double rate = 0;

                using (locker.LockList(true))
                {
                    for (int i = 0; i < downloads.Count; i++)
                    {
                        if (downloads[i].State==DownloadState.Working)
                        {
                            rate += downloads[i].Rate;
                        }
                    }
                }

                return rate;
            }

        }

        #endregion

        #region 公有方法

        public void Add(Downloader d, bool autoStart)
        {
            d.StateChanged+=new EventHandler(task_StateChanged);
            using (locker.LockList(false))
            {
                downloads.Add(d);
            }

            OnDownloadAdd(d);

            if (autoStart)
            {
                d.Start();
            }
        }

        /// <summary>
        /// 按给定的参数添加新的任务
        /// </summary>
        /// <param name="url"></param>
        /// <param name="localFilePath"></param>
        /// <param name="segmentCount"></param>
        /// <param name="autoStart"></param>
        /// <returns></returns>
        public Downloader Add(string url, string localFilePath, int segmentCount, bool autoStart)
        {
            Downloader task = new Downloader(url, localFilePath, segmentCount);

            Add(task, autoStart);

            return task;
        }

        public Downloader Add(string url, string localFilePath, int segmentCount, bool autoStart, List<Segment> segments, DateTime createdtime)
        {
            Downloader task = new Downloader(url, localFilePath, segmentCount, segments, createdtime);

            Add(task, autoStart);

            return task;
        }

        /// <summary>
        /// 删除给定的任务
        /// </summary>
        /// <param name="task"></param>
        public void Remove(Downloader task)
        {
            if (task.State!=DownloadState.NeedToPrepare ||
                task.State!=DownloadState.paused ||
                task.State!=DownloadState.Ended)
            {
                task.Pause();
            }

            using (locker.LockList(false))
            {
                downloads.Remove(task);
            }

            OnDownloadRemove(task);
        }

        /// <summary>
        /// 清除已完成任务
        /// </summary>
        public void ClearEnded()
        {
            using (locker.LockList(false))
            {
                for (int i = 0; i < downloads.Count; i++)
                {
                    if (downloads[i].State==DownloadState.Ended)
                    {
                        OnDownloadRemove(downloads[i]);
                        downloads.RemoveAt(i);
                    }
                }
            }
        }

        /// <summary>
        /// 删除给定索引的任务
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            Remove(downloads[index]);
        }

        #endregion

        #region 私有方法

        protected virtual void OnDownloadPaused(Downloader d)
        {
            if (DownloadPaused!=null)
            {
                DownloadPaused(this, new DownloadEventArgs(d));
            }
        }

        protected virtual void OnAllDownloadEnd()
        {
            if (AllDownloadEnd!=null)
            {
                AllDownloadEnd(this, EventArgs.Empty);
            }
        }
        protected virtual void OnDownloadEnd(Downloader d)
        {
            if (DownloadEnd!=null)
            {
                DownloadEnd(this, new DownloadEventArgs(d));
            }
        }

        protected virtual void OnDownloadEndWithError(Downloader d)
        {
            if (DownloadEndWithError!=null)
            {
                DownloadEndWithError(this, new DownloadEventArgs(d));
            }
        }
        protected virtual void OnDownloadAdd(Downloader d)
        {
            if (DownloadAdd!=null)
            {
                DownloadAdd(this, new DownloadEventArgs(d));
            }
        }

        protected virtual void OnDownloadRemove(Downloader d)
        {
            if (DownloadRemove!=null)
            {
                DownloadRemove(this, new DownloadEventArgs(d));
            }
        }

        protected void task_StateChanged(object sender, EventArgs e)
        {
            Downloader task = (Downloader)sender;

            switch (task.State)
            {
                case DownloadState.paused:
                    OnDownloadPaused(task);
                    break;
                case DownloadState.Ended:
                    OnDownloadEnd(task);
                    break;
                case DownloadState.EndedWithError:
                    OnDownloadEndWithError(task);
                    break;
                default:
                    break;
            }

            CheckAllEnd();
        }

        private void CheckAllEnd()
        {
            bool allTaskEnd = true;
            for (int i = 0; i < downloads.Count; i++)
            {
                allTaskEnd &= (!downloads[i].IsWorking());
            }
            if (allTaskEnd)
            {
                OnAllDownloadEnd();
            }
        }

        #endregion

    }
}
