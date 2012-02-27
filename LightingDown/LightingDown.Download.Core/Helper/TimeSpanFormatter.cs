using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightingDown.Download.Core
{
    public static class TimeSpanFormatter
    {
        public static string ToString(TimeSpan ts)
        {
            string str = ts.ToString();
            int index = str.LastIndexOf('.');
            if (index > 0)
            {
                return str.Remove(index);
            }
            else
            {
                return str;
            }
        }
    }
}
