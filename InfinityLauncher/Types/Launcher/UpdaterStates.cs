using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityLauncher.Types.Launcher
{
    /// <summary>
    /// Class to present updater info to other classes
    /// </summary>
    public class UpdaterStates
    {
        private string _updaterState;
        private string _updaterInformation;
        private int _updaterPercentage;
        private bool _updaterIsIndeterminate;

        public string UpdaterState
        {
            get { return _updaterState; }
            set { _updaterState = value; }
        }
        public string UpdaterInformation
        {
            get { return _updaterInformation; }
            set { _updaterInformation = value; }
        }
        public int UpdaterPercentage
        {
            get { return _updaterPercentage; }
            set
            {
                _updaterPercentage = value;
            }
        }
        public bool UpdaterIsIndeterminate
        {
            get { return _updaterIsIndeterminate; }
            set
            {
                _updaterIsIndeterminate = value;
            }
        }

        public UpdaterStates(string _state, string _info, int _percentage, bool _updaterIsIndeterminate)
        {
            UpdaterState = _state;
            UpdaterInformation = _info;
            UpdaterPercentage = _percentage;
        }

        public UpdaterStates()
        {
            UpdaterState = "";
            UpdaterInformation = "";
            UpdaterPercentage = 0;
            UpdaterIsIndeterminate = false;
        }

    }
}
