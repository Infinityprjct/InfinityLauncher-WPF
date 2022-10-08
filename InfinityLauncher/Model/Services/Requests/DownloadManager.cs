using InfinityLauncher.Model.Main;
using InfinityLauncher.View.Supporting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace InfinityLauncher.Model.Services.Requests
{
    public class DownloadManager : IDisposable
    {
        private ILauncherModel model;
        private int _downloadPercentage;
        const string SERVER_ADDRESS = "http://127.0.0.1:8000/";
        private HttpClient _httpClient;

        public int DownloadPercentage { get { return _downloadPercentage; } set { _downloadPercentage = value; } }

        public DownloadManager(ILauncherModel _model)
        {
            model = _model;
        }

        public async Task DownloadServerFolder(string serverName, string destinationFolder)
        {
            string fileName = "server.zip";
            string downloadLink = SERVER_ADDRESS + @"files/Adventure/" + fileName;
            string filePath = destinationFolder + @"\" + fileName;

            MessageBox.Show(downloadLink);

            await StartDownloadAsync(downloadLink, filePath);
        }

        public async Task DownloadFile(string fileUrl, string destinationFolder)
        {
            await StartDownloadAsync(fileUrl, destinationFolder);
        }

        public async Task StartDownloadAsync(string downloadLink, string filePath)
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };

            using (var response = await _httpClient.GetAsync(downloadLink, HttpCompletionOption.ResponseHeadersRead))
            {
                await DownloadFileFromHttpResponseMessageAsync(filePath,response);
            }
        }

        private async Task DownloadFileFromHttpResponseMessageAsync(string filePath,HttpResponseMessage response)
        {   

            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength;

            using (var contentStream = await response.Content.ReadAsStreamAsync())
            {
                await ProcessContentStreamAsync(filePath,totalBytes, contentStream);
            }
        }

        private async Task ProcessContentStreamAsync(string filePath,long? totalDownloadSize, Stream contentStream)
        {
            var bytesToRead = 0L;
            var readCount = 0L;
            var buffer = new byte[8192];
            var isMoreToRead = true;

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
            {
                do
                {
                    var bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                    {
                        isMoreToRead = false;
                        TriggerProgressChanged(totalDownloadSize, bytesToRead);
                        continue;
                    }

                    await fileStream.WriteAsync(buffer, 0, bytesRead);

                    bytesToRead += bytesRead;
                    readCount += 1;

                    if (readCount % 10 == 0)
                    {
                        TriggerProgressChanged(totalDownloadSize, bytesToRead);
                    }
                }
                while (isMoreToRead);
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }

        private void TriggerProgressChanged(long? totalDownloadSize, long totalBytesRead)
        {
            /* 
             if (ProgressChanged == null)
            {
                return;
            }

            double? progressPercentage = null;
            if (totalDownloadSize.HasValue)
            {
                progressPercentage = Math.Round((double)totalBytesRead / totalDownloadSize.Value * 100, 2);
            }

            ProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage);
             */
            /*
            MessageBox.Show("Current downloaded " + totalBytesRead.ToString());
            MessageBox.Show("Nado " + totalDownloadSize.ToString());
            double? p = (totalBytesRead * 100) / totalDownloadSize;
            MessageBox.Show("Current downloaded percent " + p.ToString());
            */

            double? progressPercentage = null;
            if (totalDownloadSize.HasValue)
            {
                _downloadPercentage = Convert.ToInt32(Math.Round((double)totalBytesRead / totalDownloadSize.Value * 100, 2));
                model.SetUpdaterPercentage(_downloadPercentage);
                //MessageBox.Show(Convert.ToInt32(_downloadPercentage).ToString());
            }


            //NotifyProperty here  ProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage);
        }
    }
}
