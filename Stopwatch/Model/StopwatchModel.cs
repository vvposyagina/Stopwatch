using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    public class StopwatchModel
    {
        const int MAX_COUNT_MEASUREMENT = 12;

        #region Private Members

        private byte _currentNumber;

        private DateTime? _startTime;

        private DateTime? _previousLapTime;

        private TimeSpan? _splitElapsedTime;

        private MeasurementModel _currentMeasurement;

        private ObservableCollection<MeasurementModel> _allMeasurements;

        #endregion

        #region Properties

        public MeasurementModel CurrentMeasurement
        {
            get
            {          
                _currentMeasurement?.UpdateMeasurement(_startTime, _previousLapTime);
                return _currentMeasurement;
            }
        }       

        public ObservableCollection<MeasurementModel> AllMeasurements
        {
            get
            {
                return _allMeasurements;
            }
        }

        public bool IsRunning
        {
            get
            {
                return _currentMeasurement != null && _startTime != null;
            }
        }

        public bool IsOnPause
        {
            get
            {
                return _currentMeasurement != null && _startTime == null;
            }
        }

        public bool IsReset
        {
            get
            {
                return _currentMeasurement == null && _startTime == null;
            }
        }

        #endregion

        public StopwatchModel()
        {
            _currentNumber = 1;
            _allMeasurements = new ObservableCollection<MeasurementModel>();
            _splitElapsedTime = TimeSpan.Zero;
        }

        #region Methods

        public void Start()
        {
            if(_startTime == null)
                _startTime = DateTime.Now;

            if(_previousLapTime == null)
                _previousLapTime = DateTime.Now;

            if (_currentMeasurement == null)             
                _currentMeasurement = new MeasurementModel(_currentNumber, _startTime, _previousLapTime, _splitElapsedTime);  

            _currentMeasurement.UpdateMeasurement(_startTime, _previousLapTime);           
        }

        public void Pause()
        {
            _splitElapsedTime += DateTime.Now - _startTime;
            _startTime = null;
            _previousLapTime = null;
            _currentMeasurement.UpdateMeasurement(_startTime, _previousLapTime);            
        }

        public bool StartNewLap()
        {
            if(_currentNumber <= MAX_COUNT_MEASUREMENT)
            {
                _previousLapTime = DateTime.Now;
                _currentNumber++;
                _allMeasurements.Add(_currentMeasurement);                
                _currentMeasurement = new MeasurementModel(_currentNumber, _startTime, _previousLapTime, _splitElapsedTime);
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _startTime = null;
            _previousLapTime = null;
            _currentMeasurement = null;
            _currentNumber = 1;
            _splitElapsedTime = TimeSpan.Zero;
            _allMeasurements.Clear();
        }

        #endregion
    }
}
