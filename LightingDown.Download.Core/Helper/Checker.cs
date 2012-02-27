using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LightingDown.Download.Core
{
    public class Checker
    {
        /// <summary>
        /// 判断是否是一个合法的URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsvalidURL(string url)
        {
            return Regex.IsMatch(url, @"^(http|https|ftp)\://[\S]+$");         
        }

        /// <summary>
        /// 判断任务是否已在下载列表中
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool UrlExists(string url)
        {
            bool result=false;
            for (int i = 0; i < DownloadManager.Instance.Downloaders.Count; i++)
            {
                if (DownloadManager.Instance.Downloaders[i].URL==url)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
