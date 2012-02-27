using System;
using System.IO;

namespace LightingDown.Download.Core
{
    public class Segment
    {
        #region 字段

        private SegmentState state;

        private long tempStartPosition;

        private DateTime startTime;

        private double rate;

        private TimeSpan leftTime;

        #endregion

        #region 属性

        /// <summary>
        /// 流的开始位置
        /// </summary>
        public long StartPosition
        {
            get;
            set;
        }

        /// <summary>
        /// 段的开始位置
        /// </summary>
        public long InitialPosition
        {
            get;
            set;
        }

        /// <summary>
        /// 段的结束位置
        /// </summary>
        public long EndPosition
        {
            get;
            set;
        }

        /// <summary>
        ///段的大小
        /// </summary>
        public long TotalSize
        {
            get
            {
                return EndPosition - InitialPosition;
            }
        }

        /// <summary>
        /// 已经下载部分的大小
        /// </summary>
        public long DownloadedSize
        {
            get
            {
                return StartPosition - InitialPosition;
            }
        }

        /// <summary>
        /// 剩下部分的大小
        /// </summary>
        public long LeftSize
        {
            get
            {
                return EndPosition - StartPosition;
            }
        }

        /// <summary>
        /// 段的输入流，用于从网络读数据
        /// </summary>
        public Stream InputStream
        {
            get;
            set;
        }

        /// <summary>
        /// 段的输出流，用于向本地写数据
        /// </summary>
        public Stream OutputStream
        {
            get;
            set;
        }

        /// <summary>
        /// 段的下载进度
        /// </summary>
        public double Progress
        {
            get
            {
                return (double)DownloadedSize / (double)TotalSize * 100.0f;
            }
        }

        /// <summary>
        /// 段的索引号
        /// </summary>
        public int Index
        {
            get;
            set;
        }

        /// <summary>
        /// 剩余下载时间
        /// </summary>
        public TimeSpan LeftTime
        {
            get
            {
                return this.leftTime;
            }
        }

        /// <summary>
        /// 段的下载状态
        /// </summary>
        public SegmentState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                switch (value)
                {
                    case SegmentState.Downloading:
                        tempStartPosition = StartPosition;
                        startTime = DateTime.Now;
                        break;
                    case SegmentState.Connecting:
                    case SegmentState.Paused:
                    case SegmentState.Finished:
                    case SegmentState.Error:
                        rate = 0.0;
                        leftTime = TimeSpan.Zero;
                        break;
                }
            }
        }

        /// <summary>
        /// 段的下载速度
        /// </summary>
        public double Rate
        {
            get
            {
                if(state==SegmentState.Downloading)
                {
                    UpdateStartPosition(0);
                    return rate;
                }
                else
                {
                    return 0.0;
                }
            }

            
        }

        #endregion

        #region 方法

        public void UpdateStartPosition(long size)
        {
            lock (this)
            {
                DateTime now = DateTime.Now;

                StartPosition += size;

                if (this.state == SegmentState.Downloading)
                {
                    TimeSpan ts = (now - startTime);
                    if (0==ts.TotalSeconds)
                    {
                        return;
                    }

                    rate=((double)(StartPosition-tempStartPosition))/ts.TotalSeconds;

                    if(rate>0)
                    {
                        leftTime = TimeSpan.FromSeconds(LeftSize / rate);
                    }
                    else
                    {
                        leftTime = TimeSpan.MaxValue;
                    }
                }

                else
                {
                    tempStartPosition = StartPosition;
                    startTime = DateTime.Now;
                }
            }
        }

        #endregion
    }
}
