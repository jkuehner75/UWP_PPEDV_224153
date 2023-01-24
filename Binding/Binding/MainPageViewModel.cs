using Prism.Mvvm;
using System.Collections.Generic;

namespace Binding
{
    internal class MainPageViewModel : BindableBase
    {
        private string _fullName;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (SetProperty(ref _fullName, value))
                    HasFullName = !string.IsNullOrEmpty(FullName);
            }
        }

        public int Counter { get; set; } = 1234;

        private bool _hasFullName;

        public bool HasFullName
        {
            get => _hasFullName;
            set
            {
                SetProperty(ref _hasFullName, value);
            }
        }

        public MainPageViewModel()
        {
            FullName = "Hallo Welt";
            for (int i = 0; i < 100; ++i)
                Customers.Add(new CustomerItemViewModel() { Name = $"Kunde {i}", LastName = $"LastName {i}", Email = $"Email {i}" });
        }

        public List<CustomerItemViewModel> Customers { get; } = new List<CustomerItemViewModel>();

        private bool _isValid;

        public bool IsValid
        {
            get => _isValid;
            set
            {
                SetProperty(ref _isValid, value);
            }
        }

        private CustomerItemViewModel _selectedCustomer;

        public CustomerItemViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value);
        }
    }
}