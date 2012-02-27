using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightingDown.Download.Core
{
    public static class ByteFormatter
    {
        private const float KB = 1024.0f;
        private const float MB = KB * 1024.0f;
        private const float GB = MB * 1024.0f;

        private const string BFormatPattern = "{0} b";
        private const string KBFormatPattern = "{0:0} KB";
        private const string MBFormatPattern = "{0:0.###} MB";
        private const string GBFormatPattern = "{0:0.###} GB";

        public static string ToString(long size)
        {
            if (size < KB)
            {
                return String.Format(BFormatPattern, size);
            }
            else if (size >= KB && size < MB)
            {
                return String.Format(KBFormatPattern, size / KB);
            }
            else if (size >= MB && size < GB)
            {
                return String.Format(MBFormatPattern, size /MB);
            }
            else
            {
                return String.Format(GBFormatPattern, size / GB);
            }
        }
    }
}
