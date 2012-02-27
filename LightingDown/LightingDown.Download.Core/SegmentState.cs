using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightingDown.Download.Core
{
    public enum SegmentState
    {
        Idle,         //空闲
        Connecting,   //连接
        Downloading,  //下载
        Paused,       //暂停
        Finished,     //完成
        Error,        //错误
    }
}
