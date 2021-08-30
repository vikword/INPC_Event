//реализовать интерфейс INotifyPropertyChanged на произвольном классе,
//продемонстрировать его работу

namespace INPC_Event
{
    class Binding
    {
        public string DataContextPropertyName { get; }

        public Binding(string dataContextPropertyName)
        {
            DataContextPropertyName = dataContextPropertyName;
        }
    }
}