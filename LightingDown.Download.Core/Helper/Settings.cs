
namespace LightingDown.Download.Core.Helper
{
    public class CoreSettings
    {
        public static CoreSettings Instance = new CoreSettings();
        private CoreSettings()
        {
        }

        public int MaxConnect
        {
            get
            {
                return LightingDown.Download.Core.Properties.Settings.Default.MaxConnect;
            }
            set
            {
                LightingDown.Download.Core.Properties.Settings.Default.MaxConnect = value;
            }
        }

        public int RetryDelay
        {
            get
            {
                return LightingDown.Download.Core.Properties.Settings.Default.RetryDelay;
            }
            set
            {
                LightingDown.Download.Core.Properties.Settings.Default.RetryDelay = value;
            }
        }

        public long MinSegmentSize
        {
            get
            {
                return LightingDown.Download.Core.Properties.Settings.Default.MinSegmentSize;
            }

            set
            {
                LightingDown.Download.Core.Properties.Settings.Default.MinSegmentSize = value;
            }
        }

        public void Save()
        {
            LightingDown.Download.Core.Properties.Settings.Default.Save();
        }
    }
}
