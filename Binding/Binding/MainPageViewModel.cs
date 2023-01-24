using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {

        private string _fullName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FullName 
        { get => _fullName;
          set
          {
                if(_fullName != value)
                {
                    _fullName = value;
                    NotifyPropertyChanged(nameof(FullName));
                }
          }
        }

        public int Counter { get; set; } = 1234;


        public MainPageViewModel()
        {
            FullName = "Hallo Welt";
        }

        private void NotifyPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
