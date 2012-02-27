using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Windows.Forms;
using LightingDown.Download.Core;
using System.IO;
using LightingDown.Properties;

namespace LightingDown.TaskListHold
{
    public class TaskListHoder
    {
        #region 类的定义
        [Serializable]
        public class XmlDownloader
        {
            public string URL;

            public string LocalFilePath;

            public int SegmentCount;

            public DateTime CreatedTime;

            public XmlSegment[] Segments;
        }


        [Serializable]
        public class XmlSegment
        {
            public int Index;

            public long InitialPosition;

            public long StartPosition;

            public long EndPosition;
        }
        #endregion

        #region 字段

        private XmlSerializer serializer;

        #endregion

        #region 构造函数

        public TaskListHoder()
        {
            serializer = new XmlSerializer(typeof(XmlDownloader[]));
        }

        #endregion

        #region 公有方法

        public void LoadTaskList()
        {
            if (File.Exists(GetXmlFilePath()))
            {
                try
                {
                    using (FileStream fs=new FileStream(GetXmlFilePath(),FileMode.Open))
                    {
                        XmlDownloader[] downloads = (XmlDownloader[])serializer.Deserialize(fs);
                        LoadDownloads(downloads);
                    }
                }
                catch
                {                 

                }
            }
        }

        public void LoadTaskList(string XmlFilePath)
        {
            if (File.Exists(XmlFilePath))
            {
                try
                {
                    using (FileStream fs=new FileStream(XmlFilePath,FileMode.Open))
                    {
                        XmlDownloader[] downloads = (XmlDownloader[])serializer.Deserialize(fs);
                        LoadDownloads(downloads);
                    }
                }
                catch 
                {

                }
            }
        }
        public void SaveTaskList()
        {
            List<XmlDownloader> xmldownloads = new List<XmlDownloader>();

            using (DownloadManager.Instance.locker.LockList(true))
            {
                List<Downloader> downloaders = DownloadManager.Instance.Downloaders;

                for (int i = 0; i < downloaders.Count; i++)
                {
                    if (downloaders[i].State==DownloadState.Ended)
                    {
                        continue;
                    }

                    XmlDownloader xmlDownload = new XmlDownloader();

                    xmlDownload.CreatedTime = downloaders[i].CreatedTime;
                    xmlDownload.LocalFilePath = downloaders[i].LocalFilePath;
                    xmlDownload.SegmentCount = downloaders[i].SementCount;
                    xmlDownload.URL = downloaders[i].URL;

                    xmlDownload.Segments=new XmlSegment[downloaders[i].Segments.Count];
                    for (int j = 0; j < downloaders[i].Segments.Count; j++)
                    {
                        XmlSegment xmlSegment = new XmlSegment();
                        xmlSegment.StartPosition = downloaders[i].Segments[j].StartPosition;
                        xmlSegment.InitialPosition = downloaders[i].Segments[j].InitialPosition;
                        xmlSegment.Index = downloaders[i].Segments[j].Index;
                        xmlSegment.EndPosition = downloaders[i].Segments[j].EndPosition;

                        xmlDownload.Segments[j] = xmlSegment;
                    }

                    xmldownloads.Add(xmlDownload);
                }
            }

            SaveDownloads(xmldownloads.ToArray());
        }

        #endregion

        #region 私有方法

        private void SaveDownloads(XmlDownloader[] xmldownloads)
        {
            try
            {
                using (FileStream fs=new FileStream(GetXmlFilePath(),FileMode.Create))
                {
                    serializer.Serialize(fs, xmldownloads);
                }
            }
            catch 
            {

            }
        }

        private string GetXmlFilePath()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath)+"\\tasklist.xml";
            return path;
        }

        private void LoadDownloads(XmlDownloader[] downloads)
        {
            for (int i = 0; i < downloads.Length; i++)
            {
                List<Segment> segments = new List<Segment>();
                for (int j = 0; j < downloads[i].Segments.Length; j++)
                {
                    Segment segment = new Segment();
                    segment.Index = downloads[i].Segments[j].Index;
                    segment.InitialPosition = downloads[i].Segments[j].InitialPosition;
                    segment.StartPosition = downloads[i].Segments[j].StartPosition;
                    segment.EndPosition = downloads[i].Segments[j].EndPosition;

                    segments.Add(segment);
                }

                DownloadManager.Instance.Add(
                    downloads[i].URL,
                    downloads[i].LocalFilePath,
                    downloads[i].SegmentCount,
                    Settings.Default.IsRuntoStart,
                    segments,
                    downloads[i].CreatedTime);
            }
        }

        #endregion
    }

}
