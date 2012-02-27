using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace LightingDown.Download.Core
{
    public class DownloadLocker
    {
        private class WriteReleaser:IDisposable
        {
            private DownloadLocker locker;

            public WriteReleaser(DownloadLocker locker)
            {
                this.locker = locker;
            }

            #region IDisposable 成员

             void IDisposable.Dispose()
            {
                locker.locker.ReleaseWriterLock();
            }

            #endregion
        }

        private class ReadReleaser : IDisposable
        {
            private DownloadLocker locker;

            public ReadReleaser(DownloadLocker locker)
            {
                this.locker = locker;
            }



            #region IDisposable 成员

            void IDisposable.Dispose()
            {
                locker.locker.ReleaseReaderLock();
            }

            #endregion
        }


        private ReaderWriterLock locker;
        private WriteReleaser writeReleaser;
        private ReadReleaser readReleaser;

        public DownloadLocker()
        {
            locker = new ReaderWriterLock();
            writeReleaser = new WriteReleaser(this);
            readReleaser = new ReadReleaser(this);
        }


        public IDisposable LockList(bool lockForRead)
        {
            if (lockForRead)
            {
                locker.AcquireReaderLock(-1);
                return readReleaser;
            }

            else
            {
                locker.AcquireWriterLock(-1);

                return writeReleaser;
            }
        }
    }
}
