using System.Windows.Forms;
using LightingDown.Properties;
using LightingDown.Download.Core.Helper;
using LightingDown.Download.Core;
using LightingDown.Helper;

namespace LightingDown.UI
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            try
            {
                Settings.Default.PlayAudio = audioCheckBox.Checked;
                Settings.Default.AutoStart = AutoStartCheckBox.Checked;
                Settings.Default.EndOpration = EndOPComboBox.Text;
                Settings.Default.DefaultFolder = folderTextBox.Text;
                Settings.Default.ShutNotify = shutNitifyBox.Checked;
                Settings.Default.IsRuntoStart = runToStartBox.Checked;
                Settings.Default.DefaultSegmentCount = (int)segmentCountBox.Value;
                CoreSettings.Instance.MinSegmentSize = (long)minSegmentSizeBox.Value;
                CoreSettings.Instance.MaxConnect = (int)linkTimeBox.Value;
                CoreSettings.Instance.RetryDelay = (int)reTryDelayBox.Value;
                WindowsStartUpHelper.Register(StartUpBox.Checked);
                Settings.Default.Save();
                CoreSettings.Instance.Save();
                this.DialogResult = DialogResult.OK;
            }
            catch
            {
                MessageBox.Show("设置失败","闪电下载2009",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void ConfigForm_Load(object sender, System.EventArgs e)
        {
            audioCheckBox.Checked = Settings.Default.PlayAudio;
            AutoStartCheckBox.Checked = Settings.Default.AutoStart;
            EndOPComboBox.Text = Settings.Default.EndOpration;
            folderTextBox.Text = Settings.Default.DefaultFolder;
            shutNitifyBox.Checked = Settings.Default.ShutNotify;
            runToStartBox.Checked = Settings.Default.IsRuntoStart;
            segmentCountBox.Value = (decimal)Settings.Default.DefaultSegmentCount;
            minSegmentSizeBox.Value = (decimal)CoreSettings.Instance.MinSegmentSize;
            linkTimeBox.Value = (decimal)CoreSettings.Instance.MaxConnect;
            reTryDelayBox.Value = (decimal)CoreSettings.Instance.RetryDelay;
            fileSizeLabel.Text = ByteFormatter.ToString(CoreSettings.Instance.MinSegmentSize);
            StartUpBox.Checked = WindowsStartUpHelper.IsRegistered();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fdialog = new FolderBrowserDialog();
            fdialog.ShowNewFolderButton = true;
            
            if (fdialog.ShowDialog()==DialogResult.OK)
            {
                folderTextBox.Text = fdialog.SelectedPath;
            }
        }

        private void minSegmentSizeBox_ValueChanged(object sender, System.EventArgs e)
        {
            fileSizeLabel.Text =ByteFormatter.ToString((long)minSegmentSizeBox.Value);
        }
    }
}
