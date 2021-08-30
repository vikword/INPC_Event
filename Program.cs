//реализовать интерфейс INotifyPropertyChanged на произвольном классе,
//продемонстрировать его работу

namespace INPC_Event
{
    class Program
    {
        private static void Main()
        {
            var view = new View(new ViewModel(new Model()));
            view.Show();
        }
    }
}