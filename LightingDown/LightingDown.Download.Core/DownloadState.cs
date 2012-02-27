using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LightingDown.Download.Core
{
     public enum DownloadState:byte
     {
         NeedToPrepare=0,  //需要准备，指一个新的任务还没有开始的状态
         Preparing,         //正在准备中,主要是任务分段
         prepared,          //准备完成
         Working,          //正在下载状态
         pausing,          //正在暂停
         paused,           //暂停状态，指一个任务从下载状态暂停后的状态
         WaitForConnect,   //指一个任务连接服务器失败，等待重新连接的状态或接收不到数据的状态
         WaitForStart,     //一个任务处于等待状态，但由于同时下载的任务数有限，所以需要等待，当有任务下载完成时自动开始下载
         Ended,            //正常下载结束状态
         EndedWithError    //在连接次数超过限定次数仍没有接到数据，则任务失败状态
     }
}
