using System;

namespace LightingDown.Download.Core
{
    public class DownloadEventArgs : EventArgs
    {
        #region 字段

        private Downloader downloader;

        #endregion

        #region 构造函数

        public DownloadEventArgs(Downloader downloader)
        {
            this.downloader = downloader;
        }

        #endregion

        #region 属性

        public Downloader Downloader
        {
            get
            {
                return this.downloader;
            }
        }
        #endregion

    }

    public class SegmentEventArgs : DownloadEventArgs
    {
        private Segment segment;

        public SegmentEventArgs(Downloader download, Segment segment)
            : base(download)
        {
            this.segment = segment;
        }

        public Segment Segment
        {
            get
            {
                return segment;
            }
        }
    }
}
