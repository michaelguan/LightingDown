using System;
using System.Net;
namespace LightingDown.Download.Core
{
    public class ServerFileInfo
    {
        public long FileSize
        {
            get;
            set;
        }

        public string FileType
        {
            get;
            set;
        }

        public DateTime LastModified
        {
            get;
            set;
        }

        public string Method
        {
            get;
            set;
        }

        public Uri ResponseUri
        {
            get;
            set;
        }

        public string Server
        {
            get;
            set;
        }

        public bool AcceptRange
        {
            get;
            set;
        }

        public object StatueCode
        {
            get;
            set;
        }

        public string CharacterSet
        {
            get;
            set;
        }

        public string ContentEncoding
        {
            get;
            set;
        }

        public string ProtocolVersion
        {
            get;
            set;
        }

        public string StatusDescription
        {
            get;
            set;
        }
    }
}
