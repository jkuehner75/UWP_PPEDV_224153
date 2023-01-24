using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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

            DeleteCommand = new DelegateCommand(OnDelete, CanDelete);
        }

        public IList<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

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
            set
            {
                if (SetProperty(ref _selectedCustomer, value))
                    DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand DeleteCommand { get; }

        private void OnDelete()
        {
            Customers.Remove(SelectedCustomer);
        }

        private bool CanDelete() => SelectedCustomer != null;
    }
}