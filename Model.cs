using System;
using System.Timers;

//реализовать интерфейс INotifyPropertyChanged на произвольном классе,
//продемонстрировать его работу

namespace INPC_Event
{
    class Model
    {
        private Timer _timer;
        public event Action<DateTime> TimeChanged;
        public Model()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }
        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            TimeChanged?.Invoke(e.SignalTime);
        }
    }
}