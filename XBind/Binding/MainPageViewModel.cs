using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binding
{
    public class MainPageViewModel : INotifyPropertyChanged
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
            for (int i = 0; i < 100; ++i)
                Customers.Add("Kunde" + i);
        }

        private void NotifyPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<string> Customers { get; } = new List<string>();

        private bool _isValid;

        public bool IsValid
        {
            get => _isValid;
            set
            {
                if(_isValid != value) 
                { 
                    _isValid = value;
                    NotifyPropertyChanged(nameof(IsValid));
                }
            }
        }

    }
}
