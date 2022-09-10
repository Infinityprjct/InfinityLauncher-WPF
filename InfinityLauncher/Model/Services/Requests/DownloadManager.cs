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
        const string SERVER_ADDRESS = "http://127.0.0.1:8000/";

        private HttpClient _httpClient;
        private string currentDownloadLink = "http://127.0.0.1:8000/files/Adventure/Adventure.zip";
        private string currentFilePath = "C:\\Program Files (x86)\\Iny\\Infinity Launcher\\Adventure.zip";

        public async Task DownloadServerFolder(string serverName, string destinationFolder)
        {
            string fileName = serverName + ".zip";
            string downloadLink = SERVER_ADDRESS + @"files/Adventure/" + fileName;
            string filePath = destinationFolder + @"\" + fileName;

            MessageBox.Show("Downloading from" + downloadLink + "\n" + "To" + filePath);
            var httpClient = new HttpClient();
            var httpResult = await httpClient.GetAsync(currentDownloadLink);
            using var resultStream = await httpResult.Content.ReadAsStreamAsync();
            using var fileStream = File.Create(currentFilePath);
            resultStream.CopyTo(fileStream);
        }

        public async Task StartDownloadAsync(string downloadLink, string filePath)
        {


            MessageBox.Show("SAS");
            _httpClient = new HttpClient { Timeout = TimeSpan.FromDays(1) };

            using (var response = await _httpClient.GetAsync(currentDownloadLink, HttpCompletionOption.ResponseHeadersRead))
            {
                await DownloadFileFromHttpResponseMessageAsync(response);
            }
        }

        private async Task DownloadFileFromHttpResponseMessageAsync(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();

            var totalBytes = response.Content.Headers.ContentLength;

            using (var contentStream = await response.Content.ReadAsStreamAsync())
            {
                await ProcessContentStreamAsync(totalBytes, contentStream);
            }
        }

        private async Task ProcessContentStreamAsync(long? totalDownloadSize, Stream contentStream)
        {
            var bytesToRead = 0L;
            var readCount = 0L;
            var buffer = new byte[8192];
            var isMoreToRead = true;

            using (var fileStream = new FileStream(currentFilePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
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

        private static void TriggerProgressChanged(long? totalDownloadSize, long totalBytesRead)
        {
            
            //NotifyProperty here  ProgressChanged(totalDownloadSize, totalBytesRead, progressPercentage);
        }

        /*
        private static void DownloadFile(string downloadLink, string filePath)
        {
            int byteProcess = 0;

            Stream remoteStream = null;
            Stream localStream = null;
            WebResponse response = null;

            try
            {
                WebRequest request = WebRequest.Create(downloadLink);

                if (request != null)
                {
                    double BytesToRecieve = 0;
                    var RequestSize = HttpWebRequest.Create(new Uri(downloadLink));

                    RequestSize.Method = "Head";

                    using (var webResponse = RequestSize.GetResponse())
                    {
                        var fileSize = webResponse.Headers.Get("Content-Length");
                        BytesToRecieve = Convert.ToDouble(fileSize);
                    }

                    response = request.GetResponse();
                    if (response != null)
                    {
                        remoteStream = response.GetResponseStream();
                        localStream = File.Create(filePath);

                        byte[] buffer = new byte[1024];
                        int bytesRead = 0;

                        do
                        {
                            bytesRead = remoteStream.Read(buffer, 0, buffer.Length);
                            localStream.Write(buffer, 0, bytesRead);
                            byteProcess += bytesRead;

                            double bytesIn = double.Parse(byteProcess.ToString());
                            double downloadPercentage = bytesIn / BytesToRecieve * 100;

                            downloadPercentage = Math.Round(downloadPercentage, 0);
                            MessageBox.Show(downloadPercentage.ToString());
                        } while (bytesRead > 0);


                    }
                }
            }
            catch
            {
                // Exceptions here
            }
            finally
            {
                if (response != null) { response.Close(); }
                if (remoteStream != null) { remoteStream.Close(); }
                if (localStream != null) { localStream.Close(); }
            }

        }
        */
    }
}
