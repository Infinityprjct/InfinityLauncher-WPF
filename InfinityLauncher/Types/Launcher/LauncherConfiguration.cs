using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InfinityLauncher.Types.Launcher
{
    public class LauncherConfiguration
    {
        string DEFAULT_HEAD_FOLDER = @"C:\Program Files (x86)\Spectrum Studio";
        string DEFAULT_LAUNCHER_FOLDER = @"C:\Program Files (x86)\Spectrum Studio\Infinity Launcher";
        public string LauncherFolder
        {
            get { return Settings.Default.LauncherFolder.ToString(); }
            set 
            { 
                Settings.Default.LauncherFolder = value;
                Settings.Default.Save();
            }
        }
        public string UserAccessToken
        {
            get { return Settings.Default.LauncherFolder.ToString(); }
            set
            {
                Settings.Default.AccessToken = value;
                Settings.Default.Save();
            }
        }
        public string UserRefreshToken
        {
            get { return Settings.Default.LauncherFolder.ToString(); }
            set
            {
                Settings.Default.RefreshToken = value;
                Settings.Default.Save();
            }
        }

        public LauncherConfiguration()
        {
            InitializeFolders();
        }

        public void InitializeFolders()
        {
            if (DEFAULT_LAUNCHER_FOLDER == LauncherFolder && (!Directory.Exists(DEFAULT_HEAD_FOLDER)))
            {
                Directory.CreateDirectory(DEFAULT_HEAD_FOLDER);
            }
            if (!Directory.Exists(LauncherFolder))
            {
                DirectoryInfo dir = Directory.CreateDirectory(LauncherFolder);
            }
        }

        public void UpdateLauncherFolder(string _folderPath)
        {
            LauncherFolder = _folderPath;
        }
        public void UpdateUserAccessToken(string _token)
        {
            UserAccessToken = _token;
        }
        public void UpdateUserRefreshToken(string _token)
        {
            UserRefreshToken = _token;
        }

    }
}
