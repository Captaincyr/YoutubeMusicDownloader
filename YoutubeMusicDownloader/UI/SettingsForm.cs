using Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            txtFileOutputPath.Text = ConfigurationManager.Config.FileOutputPath;
            chkDeleteMp4FilesAfterConversion.Checked = ConfigurationManager.Config.DeleteMp4FilesAfterConversion;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            ConfigurationManager.Config.FileOutputPath = txtFileOutputPath.Text;
            ConfigurationManager.Config.DeleteMp4FilesAfterConversion = chkDeleteMp4FilesAfterConversion.Checked;

            await ConfigurationManager.Save();

            Close();
        }
    }
}
