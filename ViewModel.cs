using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

//реализовать интерфейс INotifyPropertyChanged на произвольном классе,
//продемонстрировать его работу

namespace INPC_Event
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _time;
        public string Time
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
                NotifyPropertyChanged();
            }
        }

        public ViewModel(Model model)
        {
            Time = "00:00:00";
            model.TimeChanged += ModelOnTimeChanged;
        }
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void ModelOnTimeChanged(DateTime dateTime)
        {
            Time = dateTime.ToLongTimeString();
        }
    }
}
