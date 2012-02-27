using System;
using LightingDown.Properties;
using System.IO;

namespace LightingDown
{
    public class DirectoryHelper
    {
        public static string GetDefaultDirectory()
        {
            string defaultFolder = string.Empty;

            if (!string.IsNullOrEmpty(Settings.Default.DefaultFolder))
            {
                defaultFolder = Settings.Default.DefaultFolder;
            }
            else
            {
                defaultFolder = Environment.CurrentDirectory;
            }

            defaultFolder += "\\" + "Download";
            if (!Directory.Exists(defaultFolder))
            {
                Directory.CreateDirectory(defaultFolder);
            }

            return defaultFolder;
        }
    }
}
