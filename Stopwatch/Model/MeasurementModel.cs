using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    public class MeasurementModel : NotifyPropertyChanged
    {
        #region Private Members

        private byte _number;

        private TimeSpan? _lapElapsedTime;

        private TimeSpan? _splitElapsedTime;        

        private TimeSpan? _lapTime;

        private TimeSpan? _splitTime;

        #endregion

        #region Properties

        public byte Number
        {
            get => _number; 
        }            

        public string LapTime
        {
            get => ((TimeSpan)_lapTime).ToString(@"mm\:ss\.ff");
        }
        
        public string SplitTime
        {
            get => ((TimeSpan)_splitTime).ToString(@"mm\:ss\.ff");
        }

        #endregion

        public MeasurementModel(byte number, DateTime? startTime, DateTime? previousLapTime, TimeSpan? splitElapsedTime)
        {
            _number = number;
            _splitTime = DateTime.Now - startTime;
            _lapTime = DateTime.Now - previousLapTime;
            _lapElapsedTime = TimeSpan.Zero;
            _splitElapsedTime = splitElapsedTime;
        }

        /// <summary>
        /// Update current measurement on demand at the current time 
        /// </summary>
        /// <param name="startTime">Time of the last start command</param>
        /// <param name="previousLapTime">Time of the last new lap command</param>
        public void UpdateMeasurement(DateTime? startTime, DateTime? previousLapTime)
        {
            if (startTime != null && previousLapTime != null )
            {
                _splitTime = DateTime.Now - startTime + _splitElapsedTime;
                _lapTime = DateTime.Now - previousLapTime + _lapElapsedTime;
            }
            else
            {
                _splitElapsedTime = _splitTime;
                _lapElapsedTime = _lapTime;
            }
        }
    }
}
