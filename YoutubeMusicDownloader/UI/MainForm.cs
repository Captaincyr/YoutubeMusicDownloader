using Core;
using Core.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        private List<Video> _video = new List<Video>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int count = lsvVideos.Items.Count;

            Video nouvelleVideo = new Video(txtUrl.Text);

            ListViewItem item = new ListViewItem(nouvelleVideo.MetaData.FullName);
            item.Tag = nouvelleVideo.ID;
            
            lsvVideos.Items.Add(item);

            _video.Add(nouvelleVideo);
        }

        private async void btnLaunchDownload_Click(object sender, EventArgs e)
        {
            List<Task<Video>> downloadTasks = _video.Select(v => v.Download(ConfigurationManager.Config.FileOutputPath)).ToList();

            List<Task<Video>> conversionsToMp3 = new List<Task<Video>>();

            while (downloadTasks.Any())
            {
                Task<Video> task = await Task.WhenAny(downloadTasks);

                downloadTasks.Remove(task);

                Video videoDownloaded = await task;

                conversionsToMp3.Add(videoDownloaded.ConvertToMp3(ConfigurationManager.Config.FileOutputPath));
            }

            Video[] videosConverted = await Task.WhenAll(conversionsToMp3);

            UpdateListeView();
        }

        private void UpdateListeView()
        {
            foreach (ListViewItem item in lsvVideos.Items)
            {
                Guid videoID = (Guid)item.Tag;
                Video video = _video.Find(v => v.ID == videoID);
                if (video.Downloaded)
                {
                    if (video.ConvertedToMp3)
                    {
                        item.BackColor = Color.Green;
                        item.Text = video.MetaData.FullName + " - Done";
                    }
                    else
                    {
                        item.BackColor = Color.Red;
                        item.Text = video.MetaData.FullName + " - Error";
                    }
                }
            }
        }

        private void menuSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog(this);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _video = new List<Video>();
            lsvVideos.Items.Clear();
        }
    }
}
