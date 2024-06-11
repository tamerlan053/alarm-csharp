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
            
        }
    }
}
