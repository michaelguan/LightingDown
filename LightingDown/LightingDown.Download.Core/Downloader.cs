using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using LightingDown.Download.Core.Properties;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace LightingDown.Download.Core
{
    public class Downloader
    {
        #region 字段

        private ImageList imageList = FileTypeImageList.GetSharedInstance();

        private int segmentCount;
        private List<Segment> segments;
        private DownloadState state;

        private DateTime createdTime;

        private Thread mainThread;
        private List<Thread> threads;

        private string localFilePath;

        private TimeSpan usedTime;

        private ServerFileInfo serverFileInfo;

        private DateTime startTime;

        private string url;

        private HttpManager httpManager;

        private Calculator httpcalculator;

        #endregion

        #region 事件

        public event EventHandler StateChanged;
        public event EventHandler<SegmentEventArgs> SegmentStopped;
        public event EventHandler<SegmentEventArgs> SegmentStarted;
        public event EventHandler<SegmentEventArgs> SegmentFailed;
        public event EventHandler Ending;
        public event EventHandler SegmentsCreated;
        #endregion

        #region 属性

        public List<Segment> Segments
        {
            get
            {
                return this.segments;
            }
        }

        public int SementCount
        {
            get
            {
                return this.segmentCount;
            }
        }
        /// <summary>
        /// URL
        /// </summary>
        public string URL
        {
            get
            {
                return this.url;
            }
        }

        /// <summary>
        /// 文件类型名称
        /// </summary>
        public string FileTypeName
        {
            get
            {
                return FileInfoReader.GetFileTypeName(Path.GetExtension(localFilePath));
            }

        }

        /// <summary>
        /// 任务的下载进度
        /// </summary>
        public double Progress
        {
            get
            {
                if (this.segments.Count>0)
                {
                    double progress = 0.0;
                    foreach (var item in segments)
                    {
                        progress += item.Progress;
                    }

                    return progress / segments.Count;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 任务的平均下载速度
        /// </summary>
        public double Rate
        {
            get
            {
                double rate = 0.0;
                if (DownloadState.Working==state)
                {
                    foreach (var item in segments)
                    {
                        rate += item.Rate;
                    }
                }
                return rate;
            }
        }

        public Calculator HttpCalculator
        {
            get
            {
                return httpcalculator;
            }

            set
            {
                httpcalculator = value;
            }
        }

        /// <summary>
        /// 任务的下载状态
        /// </summary>
        public DownloadState State
        {
            get
            {
                return state;
            }
        }

        /// <summary>
        /// 任务的创建时间
        /// </summary>
        public DateTime CreatedTime
        {
            get
            {
                return createdTime;
            }
        }

        /// <summary>
        /// 任务的开始时间
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return startTime;
            }
        }

        /// <summary>
        /// 文件的大小
        /// </summary>
        public long FileSize
        {
            get
            {
                if (serverFileInfo != null)
                {
                    return serverFileInfo.FileSize;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 文件在本地在存储路径
        /// </summary>
        public string LocalFilePath
        {
            get { return localFilePath; }
        }

        /// <summary>
        /// 任务的剩余下载时间
        /// </summary>
        public TimeSpan LeftTime
        {
            get
            {
                if (Rate==0)
                {
                    return TimeSpan.Zero;
                }
                double leftSize = 0.0;
                foreach (var item in segments)
                {
                    leftSize += item.LeftSize;
                }

                return TimeSpan.FromSeconds(leftSize/Rate);
            }
        }

        /// <summary>
        /// 任务的已用下载时间
        /// </summary>
        public TimeSpan UsedTime
        {
            get 
            { 
                return usedTime;
            }
        }

        /// <summary>
        /// 文件已经下载部分的大小
        /// </summary>
        public long DownloadedSize
        {
            get 
            {
                if (segments.Count > 0)
                {
                    long size = 0;
                    foreach (var item in segments)
                    {
                        size += item.DownloadedSize;
                    }
                    return size;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 远程目标文件的信息
        /// </summary>
        public ServerFileInfo ServerFileInfo
        {
            get { return serverFileInfo; }
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName
        {
            get
            {
                return Path.GetFileName(this.localFilePath);
            }
        }

        /// <summary>
        /// 文件的图标
        /// </summary>
        public Image FileIcon
        {
            get
            {
                string ext = Path.GetExtension(this.localFilePath).ToLower();

                return imageList.Images[FileTypeImageList.GetImageIndexByExtention(ext)];
            }
        }

        #endregion

        #region 构造函数

        private Downloader(string url, string localFilePath)
        {
            this.url = url;
            this.localFilePath = localFilePath;
            threads = new List<Thread> { };
            httpManager = new HttpManager();
            httpcalculator = new Calculator();
        }

        public Downloader(string url,string localFilePath,int segmentCount):this(url,localFilePath)
        {
            this.segmentCount = segmentCount;
            this.createdTime = DateTime.Now;
            segments = new List<Segment> { };
            SetState(DownloadState.NeedToPrepare);

         //   MessageBox.Show(FileInfoReader.GetFileTypeName(this.localFilePath));

        }

        public Downloader(string url, string localFilePath, int segmentCount, List<Segment> segments, DateTime createdtime):this(url,localFilePath)
        {
            if (segments.Count>0)
            {
                SetState(DownloadState.prepared);
            }
            else
            {
                SetState(DownloadState.NeedToPrepare);
            }

            this.segments = segments;
            this.createdTime = createdtime;
            this.segmentCount = segmentCount;
        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 任务是否正在工作
        /// </summary>
        /// <returns></returns>
        public bool IsWorking()
        {
            if (state == DownloadState.Ended ||
                state == DownloadState.EndedWithError ||
                state == DownloadState.NeedToPrepare ||
                state == DownloadState.paused ||
                state == DownloadState.WaitForStart ||
                state==DownloadState.prepared
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 设置任务的下载状态，并触发状态改变事件
        /// </summary>
        /// <param name="value">状态</param>
        public void SetState(DownloadState value)
        {
            this.state = value;
            OnStateChanged();
        }

        /// <summary>
        /// 开始下载
        /// </summary>
        public void Start()
        {
            this.startTime = DateTime.Now;

            if (state==DownloadState.NeedToPrepare)
            {
                mainThread = new Thread(new ThreadStart(StartNeedToPrepare));
                mainThread.Start();
            }
            else if(
                state!=DownloadState.pausing &&
                state!=DownloadState.Preparing &&
                state!=DownloadState.Working &&
                state!=DownloadState.WaitForConnect &&
                state!=DownloadState.Ended
                //state==DownloadState.paused
                 )
            {
                mainThread = new Thread(new ThreadStart(StartPrepared));
                mainThread.Start();
            }
        }

        /// <summary>
        /// 暂停下载
        /// </summary>
        public void Pause()
        {
            if (state==DownloadState.Preparing)
            {
                segments.Clear();
                mainThread.Abort();
                mainThread = null;
                SetState(DownloadState.paused);
                SetState(DownloadState.NeedToPrepare);
                return;
            }

            if (state==DownloadState.Working)
            {
                SetState(DownloadState.pausing);

                //如果服务器不支持断点续传，则重置流的开始位置
                if (serverFileInfo != null && !serverFileInfo.AcceptRange)
                {
                    if (MessageBox.Show("目标文件服务器不支持断点续传,重新开始下载会丢失已下载部分,确认暂停吗?", "提示",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
                    {
                        SetState(DownloadState.Working);
                        return;
                    }
                    segments[0].StartPosition = 0;
                }

                lock (threads)
                {
                    threads.Clear();
                }

                mainThread.Abort();
                mainThread = null;

                SetState(DownloadState.paused);
            }
        }

        #endregion

        #region 私有方法

        protected virtual void OnSegmentFailed(Segment segment)
        {
            if (SegmentFailed!=null)
            {
                SegmentFailed(this, new SegmentEventArgs(this,segment));
            }
        }

        protected virtual void OnSegmentStarted(Segment segment)
        {
            if (SegmentStarted!=null)
            {
                SegmentStarted(this, new SegmentEventArgs(this,segment));
            }
        }

        private void OnStateChanged()
        {
            if (this.StateChanged != null)
            {
                StateChanged(this, EventArgs.Empty);
            }
        }

        protected virtual void OnSegmentStopped(Segment segment)
        {
            if (SegmentStopped != null)
            {
                SegmentStopped(this, new SegmentEventArgs(this,segment));
            }
        }

        private void OnEnding()
        {
            if (Ending!=null)
            {
                Ending(this, EventArgs.Empty);
            }
        }

        private void OnSegmentsCreated()
        {
            if (SegmentsCreated!=null)
            {
                SegmentsCreated(this, EventArgs.Empty);
            }
        }

        private void StartNeedToPrepare()
        {
            int errorTime = 0;
            SetState(DownloadState.Preparing);

            do
            {
                if (state == DownloadState.pausing)
                {
                    SetState(DownloadState.NeedToPrepare);
                    return;
                }

                SetState(DownloadState.Preparing);
                errorTime++;

                try
                {
                    serverFileInfo = httpManager.GetFileInfo(url);
                    if ((HttpStatusCode)serverFileInfo.StatueCode == HttpStatusCode.OK)
                    {
                        break;
                    }
                }
                catch (ThreadAbortException)
                {
                    SetState(DownloadState.NeedToPrepare);
                    return;
                }
                catch (Exception ex)
                {
                    if (errorTime < Settings.Default.MaxConnect)
                    {
                        SetState(DownloadState.WaitForConnect);
                        Thread.Sleep(TimeSpan.FromMilliseconds(Settings.Default.RetryDelay));
                    }
                    else
                    {
                        SetState(DownloadState.NeedToPrepare);
                        return;
                    }
                }

            } while (true);

            try
            {
                CreateSegments();
            }
            catch(ThreadAbortException)
            {
                throw;
            }
            catch 
            {
                SetState(DownloadState.EndedWithError);
            }
            
        }

        private void CreateSegments()
        {
            try
            {
                CreateLocalFile();
            }
            catch 
            {
                MessageBox.Show("创建本地文件失败!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            CalculatedSegment[] calculatedSegments;

            //如果不支持流的定位，则只创建一个段
            if (!serverFileInfo.AcceptRange)
            {
                calculatedSegments = new CalculatedSegment[] { new CalculatedSegment(0, serverFileInfo.FileSize) };
            }
            else
            {
                calculatedSegments = httpcalculator.GetSegments(segmentCount, serverFileInfo.FileSize);
            }

            lock (segments)
            {
                segments.Clear();
            }

            lock (threads)
            {
                threads.Clear();
            }

            for (int i = 0; i < calculatedSegments.Length; i++)
            {
                Segment segment = new Segment();

                segment.Index = i;
                segment.InitialPosition = calculatedSegments[i].StartPosition;
                segment.StartPosition = calculatedSegments[i].StartPosition;
                segment.EndPosition = calculatedSegments[i].EndPosition;
                segment.State = SegmentState.Idle;

                segments.Add(segment);
            }

            SetState(DownloadState.prepared);
            OnSegmentsCreated();
            StartSegments();
        }

        private void StartSegments()
        {
            SetState(DownloadState.Working);

            using (FileStream fs = new FileStream(this.localFilePath, FileMode.Open, FileAccess.Write))
            {

                for (int i = 0; i < segments.Count; i++)
                {
                    if (segments[i].State==SegmentState.Finished)
                    {
                        continue;
                    }
                    segments[i].State = SegmentState.Connecting;
                    segments[i].OutputStream = fs;
                    int connectTime = 0;
                    do
                    {
                        connectTime++;
                        try
                        {
                            segments[i].InputStream = httpManager.GetStream(url, segments[i].StartPosition, segments[i].EndPosition);
                            break;
                        }
                        catch
                        {
                            if (connectTime<Settings.Default.MaxConnect)
                            {
                                Thread.Sleep(TimeSpan.FromMilliseconds(Settings.Default.RetryDelay));
                            }
                            else
                            {
                                segments[i].State = SegmentState.Error;
                                OnSegmentFailed(segments[i]);
                                return;
                            }
                        }

                    } while (true);

                    RunSegments(segments[i]);

                   // Debug.WriteLine("Segment[" + i + "]开始下载");
                }
                while (!AllWorkersStopped(500)) 
                    ;
            }


            for (int i = 0; i < this.segments.Count; i++)
            {
                if (segments[i].State == SegmentState.Error)
                {
                   SetState(DownloadState.EndedWithError);
                    return;
                }
            }

            SetState(DownloadState.Ended);

        }

        private void RunSegments(Segment segment)
        {
            Thread segmentThread = new Thread(new ParameterizedThreadStart(StartSegment));

            segmentThread.Start(segment);

            lock (threads)
            {
                threads.Add(segmentThread);
            }
        }


        private bool AllWorkersStopped(int timeOut)
        {
            bool allFinished = true;

            Thread[] workers;

            lock (threads)
            {
                workers = threads.ToArray();
            }

            foreach (Thread t in workers)
            {
                bool finished = t.Join(timeOut);
                allFinished = allFinished & finished;

                if (finished)
                {
                    lock (threads)
                    {
                        threads.Remove(t);
                    }
                }
            }

            return allFinished;
        }


        /// <summary>
        /// 下载核心代码
        /// </summary>
        /// <param name="segmenttoStart"></param>
        private void StartSegment(object segmenttoStart)
        {
            Segment segment = (Segment)segmenttoStart;

            try
            {
                if (segment.EndPosition > 0 && segment.StartPosition >= segment.EndPosition)
                {
                    segment.State = SegmentState.Finished;
                    OnSegmentStopped(segment);
                }

                int bufferSize = 7168;
                byte[] buffer = new byte[bufferSize];
                segment.State = SegmentState.Connecting;

                using (segment.InputStream)
                {
                    OnSegmentStarted(segment);

                    segment.State = SegmentState.Downloading;
                    long readSize = 0;
                    do
                    {
                        readSize = segment.InputStream.Read(buffer, 0, bufferSize);
                        //IAsyncResult asyncResult = segment.InputStream.BeginRead(buffer, 0, bufferSize,null,null);
                        //readSize = segment.InputStream.EndRead(asyncResult);
                        if (segment.EndPosition > 0 && segment.StartPosition + readSize > segment.EndPosition)
                        {
                            readSize = segment.EndPosition - segment.StartPosition;
                            if (readSize <= 0)
                            {
                                segment.StartPosition = segment.EndPosition;
                                break;
                            }
                        }

                        lock (segment.OutputStream)
                        {
                            segment.OutputStream.Position = segment.StartPosition;
                            segment.OutputStream.Write(buffer, 0, (int)readSize);
                        }

                        segment.UpdateStartPosition(readSize);

                        if (segment.EndPosition > 0 && segment.StartPosition >= segment.EndPosition)
                        {
                            segment.StartPosition = segment.EndPosition;
                            break;
                        }

                        if (this.state == DownloadState.pausing)
                        {
                            segment.State = SegmentState.Paused;
                            break;
                        }

                    } while (readSize > 0);

                    if (state == DownloadState.Working && segment.StartPosition >= segment.EndPosition)
                    {
                        segment.State = SegmentState.Finished;
                        OnSegmentStopped(segment);
                    }
                }
            }
            catch (ThreadAbortException)
            {
                throw;
            }
            catch
            {
                segment.State = SegmentState.Error;
                OnSegmentFailed(segment);
            }
            finally
            {
                segment.InputStream = null;
            }
        }

        /// <summary>
        /// 创建本地文件
        /// </summary>
        private void CreateLocalFile()
        {
            FileInfo fileInfo = new FileInfo(this.localFilePath);
            if (!Directory.Exists(fileInfo.DirectoryName))
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);
            }

            if (fileInfo.Exists)
            {
                // 如果文件已经存在，则自动重命名
                int count = 1;

                string fileExitWithoutExt = Path.GetFileNameWithoutExtension(this.localFilePath);
                string ext = Path.GetExtension(this.localFilePath);

                string newFileName;

                do
                {
                    newFileName = fileInfo.DirectoryName;
                    if (!fileInfo.DirectoryName.EndsWith(Path.DirectorySeparatorChar.ToString()))
                    {
                        newFileName += Path.DirectorySeparatorChar.ToString();
                    }
                    newFileName =newFileName
                        + fileExitWithoutExt + String.Format("({0})", count++) + ext;
                }
                while (File.Exists(newFileName));

                localFilePath = newFileName;
            }

            using (FileStream fs = new FileStream(localFilePath, FileMode.Create, FileAccess.Write))
            {
                fs.SetLength(Math.Max(this.FileSize, 0));
            }
        }

        /// <summary>
        /// 开始暂停的任务
        /// </summary>
        private void StartPrepared()
        {
            int errorTime = 0;
            try
            {
                do
                {
                    errorTime++;

                    try
                    {
                        serverFileInfo = httpManager.GetFileInfo(url);
                        break;
                    }
                    catch
                    {
                        if (errorTime < Settings.Default.MaxConnect)
                        {
                            SetState(DownloadState.WaitForConnect);
                            Thread.Sleep(TimeSpan.FromMilliseconds(Settings.Default.RetryDelay));
                        }
                        else
                        {
                            return;
                        }
                    }

                } while (true);
            }
            finally
            {
                SetState(DownloadState.prepared);
            }

            StartSegments();
        }

        #endregion
    }
}
