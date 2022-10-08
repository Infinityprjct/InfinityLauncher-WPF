using GalaSoft.MvvmLight.Messaging;
using InfinityLauncher.Model.Main;
using InfinityLauncher.Model.Services.Requests;
using InfinityLauncher.Types.Files;
using InfinityLauncher.Types.Launcher;
using InfinityLauncher.Utils.Hash;
using InfinityLauncher.View.Supporting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Threading;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace InfinityLauncher.Model.Services
{
    public class UpdateManager
    {
        UpdaterStates updaterStates = new UpdaterStates();
        private ILauncherModel model;
        private string launcherFolder = Settings.Default.LauncherFolder;
        private string downloadServerURL = "http://127.0.0.1:8000/files/";

        public UpdateManager(ILauncherModel _model)
        {
            model = _model;
        }

        private void UpdateState(string newState)
        {
            updaterStates.UpdaterState = newState;
            model.SetUpdaterStates(updaterStates);
        }
        private void UpdateInfo(string newInfo)
        {
            updaterStates.UpdaterInformation = newInfo;
            model.SetUpdaterStates(updaterStates);
        }
        private void UpdatePercentage(int newPercentage)
        {
            updaterStates.UpdaterPercentage = newPercentage;
            model.SetUpdaterStates(updaterStates);
        }

        private void UpdateIsIndeterminate(bool isIndeterminate)
        {
            updaterStates.UpdaterIsIndeterminate = isIndeterminate;
            model.SetUpdaterStates(updaterStates);
        }

        async public Task UpdateServerFolders(string serverName)
        {
            UpdateState("Проверка файлов");
            UpdateIsIndeterminate(true);

            string folderPath = model.LauncherConfig.LauncherFolder + @"\" + serverName;
            InitializeFolder(folderPath);

            List<ILauncherFile> remoteFolder = GetRemoteFolder(serverName);
            List<ILauncherFile> localFolder = GetLocalFolder(folderPath);
            List<ILauncherFile> toDownload = new List<ILauncherFile>();

            CompareFolders(folderPath, ref remoteFolder, ref localFolder, ref toDownload);

            foreach (var file in localFolder)
            {

                // Garbage collector will interfere to delete
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                string filePath = folderPath + file.Path.Replace(serverName,"");
                MessageBox.Show("DELETING ODD FILE " + file.Name);
                MessageBox.Show(filePath);
                File.Delete(filePath);
            }

            // Download files
            UpdateState("Обновление файлов");
            UpdateIsIndeterminate(false);
            foreach (var file in toDownload)
            {
                UpdateInfo("Скачивание файла " + file.Name);
                UpdatePercentage(model.DownloadManager.DownloadPercentage);
                // Todo.. oh god...
                string fileURL = downloadServerURL + file.Path.Replace(@"\","/");
                string destinationFilePath = folderPath + file.Path.Replace(serverName, "");
                string destinationFolderPath = destinationFilePath.Replace(file.Name, "");

                if (!File.Exists(destinationFolderPath))
                {
                    Directory.CreateDirectory(destinationFolderPath);
                }

                await model.DownloadManager.DownloadFile(fileURL, destinationFilePath);
            }

            UpdateState("");
            UpdateInfo("");
            UpdatePercentage(0);

            Application.Current.Dispatcher.Invoke(() => new InfoBox("Информация", "Обновление завершено").Show());
        }

        async public void InitializeFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        private List<ILauncherFile> GetRemoteFolder(string serverName)
        {
            List<ILauncherFile> remoteFolder = new List<ILauncherFile>();

            GetServerFilesRequest serverFilesRequest = new GetServerFilesRequest(Settings.Default.AccessToken, serverName);
            JObject response = serverFilesRequest.Request();
            if (response != null)
            {
                if (response["error"] != null)
                {
                    if (response["error"].ToString() == "Unauthorized")
                    {
                        model.account.UpdateAccessToken();
                        new GetServerFilesRequest(Settings.Default.AccessToken, serverName);
                        response = serverFilesRequest.Request();
                    }
                }
            }

            JArray responseArray = JArray.Parse(response["files"].ToString());
            foreach (var file in responseArray)
            {
                JObject currentFile = JObject.Parse(file.ToString());
                remoteFolder.Add(new RemoteFile(currentFile["name"].ToString(), currentFile["path"].ToString(), currentFile["hash"].ToString(), long.Parse(currentFile["size"].ToString())));
            }

            return remoteFolder;
        }

        private List<ILauncherFile> GetLocalFolder(string folderPath)
        {
            List<FileInfo> files = new List<FileInfo>();
            GetFilesFromFolder(folderPath, ref files);

            List<ILauncherFile> localFolder = new List<ILauncherFile>();

            foreach (FileInfo file in files)
            {
                localFolder.Add(new LocalFile(file.Name, file.FullName));
            }

            return localFolder;
        }

        private void GetFilesFromFolder(string folderPath, ref List<FileInfo> files)
        {

            DirectoryInfo dir = new DirectoryInfo(folderPath);

            foreach (var folder in dir.GetDirectories())
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    files.Add(file);
                }
                GetFilesFromFolder(folderPath + "\\" + folder.Name, ref files);
            }
        }

        private void CompareFolders(string serverFolder,ref List<ILauncherFile> remoteFolder, ref List<ILauncherFile> localFolder, ref List<ILauncherFile> toDownload)
        {

            foreach (var file in remoteFolder)
            {
                string fileName = file.Name;
                string fileHash = file.Hash;
                string filePath = file.Path;
                long fileSize = file.Size;

                var fileToFind = localFolder.Find(f => f.Name == fileName && f.Path == filePath);
                
                if (fileToFind == null)
                {
                    toDownload.Add(file);
                }
                else
                {
                    if (fileToFind.Hash == file.Hash && fileToFind.Size == file.Size)
                    {
                        localFolder.Remove(fileToFind);
                    }
                    else
                    {
                        toDownload.Add(fileToFind);
                        localFolder.Remove(fileToFind);
                        MessageBox.Show("LOCAL TO DOWN " + toDownload[toDownload.Count - 1].Name);
                    }
                }
            }
        }

    }
}
