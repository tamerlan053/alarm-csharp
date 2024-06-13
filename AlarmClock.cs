using System.Media;
using System.Windows;
using System.Windows.Threading;

namespace AlarmClock
{
    public class AlarmClock
    {
        private DateTime _alarmTime;
        private DispatcherTimer _alarmTimer;

        public int Duration { get; set; }

        public AlarmClock()
        {
            _alarmTimer = new DispatcherTimer();
            _alarmTimer.Interval = TimeSpan.FromMilliseconds(100);
            _alarmTimer.Tick += AlarmTimer_Tick;

            _alarmTime = DateTime.MaxValue;
        }

        public DateTime AlarmTime {  
            get {
                return _alarmTime;
            } 
            set {
                if (value <= DateTime.Now)
                {
                    value = value.AddDays(1);
                }

                _alarmTime = value; 
            }
        }

        public bool IsAlarmTimePassed()
        {
            bool value = DateTime.Now >= _alarmTime;
            if (value)
            {
                _alarmTimer.Start();
            }
            return value;
        }

        public bool ShouldStopBeeping()
        {
            bool value = DateTime.Now >= _alarmTime.AddSeconds(Duration);
            if (value)
            {
                _alarmTimer.Stop();
            }
            return value;
        }

        private void AlarmTimer_Tick(object sender, EventArgs e)
        {
            SystemSounds.Beep.Play()
        }
    }
}
