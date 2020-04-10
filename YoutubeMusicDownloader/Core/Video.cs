using Core.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Model;

namespace Core
{
    public class Video
    {
        public Guid ID { get; set; }
        public VideoLibrary.Video MetaData { get; set; }
        public string Url { get; set; }

        public string VideoFilePath { get; set; }
        public bool Downloaded { get; set; }
        public bool ConvertedToMp3 { get; set; }

        public Video(string url)
        {
            ID = Guid.NewGuid();
            Url = url;

            GetMetadata();
        }

        private void GetMetadata()
        {
            MetaData = YouTube.Default.GetVideo(Url);
        }

        public async Task<Video> Download(string outputhPath)
        {
            try
            {
                byte[] videoContent = await MetaData.GetBytesAsync();
                VideoFilePath = outputhPath + @"\" + MetaData.FullName;

                await File.WriteAllBytesAsync(VideoFilePath, videoContent);

                Downloaded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Downloaded = false;
            }

            return this;
        }

        public async Task<Video> ConvertToMp3(string outputPath)
        {
            if (String.IsNullOrEmpty(VideoFilePath))
                throw new Exception("Video not downloaded yet, please call Download method first");

            try
            {
                string outputAudioFile = outputPath + @"\" + MetaData.FullName.Replace(".mp4", ".mp3");

                Console.WriteLine(Directory.GetCurrentDirectory());

                IConversionResult result = await Conversion.ExtractAudio(VideoFilePath, outputAudioFile).Start();

                ConvertedToMp3 = result.Success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ConvertedToMp3 = false;
            }

            if (ConfigurationManager.Config.DeleteMp4FilesAfterConversion)
            {
                DeleteVideoFile();
            }

            return this;
        }

        public void DeleteVideoFile()
        {
            File.Delete(VideoFilePath);
        }
    }
}
