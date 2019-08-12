using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Stopwatch
{
    public class StopwatchViewModel : NotifyPropertyChanged
    {
        private StopwatchModel _stopwatchModel;

        private DispatcherTimer _timer;

        #region Properties
        public string CurrentMeasurement
        {
            get
            {
                return _stopwatchModel.CurrentMeasurement != null ? _stopwatchModel.CurrentMeasurement.SplitTime : TimeSpan.Zero.ToString();
            }
        }

        public ObservableCollection<MeasurementModel> PreviousLaps
        {
            get
            {
                return _stopwatchModel.AllMeasurements;
            }
        }

        public bool IsRunning
        {
            get
            {
                return _stopwatchModel.IsRunning;
            }
        }

        public bool IsOnPause
        {
            get
            {
                return _stopwatchModel.IsOnPause;
            }
        }

        public bool IsReset
        {
            get
            {
                return _stopwatchModel.IsReset;
            }
        }

        public Command StartCmd { get; set; }

        public Command PauseCmd { get; set; }

        public Command StartNewLapCmd { get; set; }

        public Command ResetCmd { get; set; }

        #endregion

        public StopwatchViewModel()
        {
            _stopwatchModel = new StopwatchModel();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += HandleTick;
            _timer.Start();

            StartCmd = new Command(() => Start());
            PauseCmd = new Command(() => Pause());
            StartNewLapCmd = new Command(() => StartNewLap());
            ResetCmd = new Command(() => Reset());
        }

        #region Methods
        private void HandleTick(Object sender, EventArgs e)
        {
            OnPropertChanged("CurrentMeasurement");
        }

        private void Start()
        {
            _stopwatchModel.Start();
            VisibilityPropertyChange();
        }

        private void Pause()
        {
            _stopwatchModel.Pause();
            VisibilityPropertyChange();
        }

        private void Reset()
        {
            _stopwatchModel.Reset();
            VisibilityPropertyChange();
        }

        private void StartNewLap()
        {

            if (_stopwatchModel.StartNewLap())
            {
                OnPropertChanged("PreviousLaps");
                VisibilityPropertyChange();
            }
            else
            {
                Pause();
                MessageBox.Show("Please, reset the previous results.");
            }
        }

        public void VisibilityPropertyChange()
        {
            OnPropertChanged("IsRunning");
            OnPropertChanged("IsOnPause");
            OnPropertChanged("IsReset");
        }
        #endregion
    }
}
