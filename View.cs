using System;
using System.ComponentModel;

//реализовать интерфейс INotifyPropertyChanged на произвольном классе,
//продемонстрировать его работу

namespace INPC_Event
{
    class View
    {
        public object DataContext { get; }
        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                Update();
            }
        }

        public View(ViewModel viewModel)
        {
            DataContext = viewModel;
            var binding = new Binding("Time");
            SetBinding(nameof(Text), binding);
        }

        private void SetBinding(string dependencyPropertyName, Binding binding)
        {
            var sourceProperty = DataContext.GetType()
                .GetProperty(binding.DataContextPropertyName);

            var targetProperty = GetType().GetProperty(dependencyPropertyName);

            targetProperty.SetValue(this, sourceProperty.GetValue(DataContext));

            if (DataContext is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == binding.DataContextPropertyName)
                    {
                        var sourcePropertyLoc = DataContext.GetType()
                                       .GetProperty(binding.DataContextPropertyName);

                        var targetPropertyLoc = GetType().GetProperty(dependencyPropertyName);

                        targetPropertyLoc.SetValue(this, sourcePropertyLoc.GetValue(DataContext));
                    }
                };
            }
        }

        public void Show()
        {
            Update();
            Console.ReadLine();
        }

        private void Update()
        {
            Console.Clear();
            foreach (var text in Text)
            {
                Console.Write(text);
            }
        }
    }
}