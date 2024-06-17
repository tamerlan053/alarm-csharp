using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlarmClock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AlarmClock _alarmClock;
        private DispatcherTimer _clockTimer;
        
        public MainWindow()
        {
            InitializeComponent();
            
            _alarmClock = new AlarmClock();
            _alarmClock.Duration = 10;

            _clockTimer = new DispatcherTimer();
            _clockTimer.Interval = TimeSpan.FromSeconds(1); 
            _clockTimer.Tick += ClockTimer_Tick;
            _clockTimer.Start();

            currentTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            currentTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");

            if (_alarmClock.IsAlarmTimePassed())
            {
                if (_alarmClock.ShouldStopBeeping())
                {
                    alarmTextBox.Text = "";
                    _alarmClock.Reset();
                }
            }
        }
    }
}
