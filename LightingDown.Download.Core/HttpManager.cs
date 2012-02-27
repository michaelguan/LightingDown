using System.Net;
using System.IO;

namespace LightingDown.Download.Core
{
    public class HttpManager
    {
        public ServerFileInfo GetFileInfo(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            ServerFileInfo fileinfo = new ServerFileInfo();
            fileinfo.ResponseUri = response.ResponseUri;
            fileinfo.FileType = response.ContentType;
            fileinfo.FileSize = response.ContentLength;
            fileinfo.LastModified = response.LastModified;
            fileinfo.Method = response.Method;
            fileinfo.Server = response.Server;
            fileinfo.AcceptRange = string.Compare(response.Headers["Accept-Ranges"], "bytes", true) == 0;
            fileinfo.StatueCode = response.StatusCode;
            fileinfo.CharacterSet = response.CharacterSet;
            fileinfo.ContentEncoding = response.ContentEncoding;
            fileinfo.ProtocolVersion = response.ProtocolVersion.ToString();
            fileinfo.StatusDescription = response.StatusDescription;

            response.Close();

            return fileinfo;
        }

        public Stream GetStream(string url,long startPosition,long endPosition)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            if (endPosition==0)
            {
                request.AddRange((int)startPosition);
            }
            else
            {
                request.AddRange((int)startPosition, (int)endPosition);
            }

            WebResponse response=request.GetResponse();
            
            return response.GetResponseStream();
        }
    }
}
