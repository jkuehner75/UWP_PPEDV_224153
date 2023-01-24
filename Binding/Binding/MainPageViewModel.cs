using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;

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
                    RaisePropertyChanged(nameof(HasFullName));
            }
        }

        public int Counter { get; set; } = 1234;

        public bool HasFullName => !string.IsNullOrEmpty(FullName);

        public MainPageViewModel()
        {
            FullName = "Hallo Welt";
            for (int i = 0; i < 100; ++i)
                Customers.Add(new CustomerItemViewModel() { Name = $"Kunde {i}", LastName = $"LastName {i}", Email = $"Email {i}" });

            DeleteCommand = new DelegateCommand<CustomerItemViewModel>(OnDelete, CanDelete);
            AddCommand = new DelegateCommand(OnAdd);
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

        public DelegateCommand<CustomerItemViewModel> DeleteCommand { get; }

        private void OnDelete(CustomerItemViewModel customer)
        {
            Customers.Remove(customer);
            SelectedCustomer = null;
        }

        private bool CanDelete(CustomerItemViewModel _) => SelectedCustomer != null;

        public DelegateCommand AddCommand { get; }

        private async void OnAdd()
        {
            IsBusy = true;
            try
            {
                var newCustomer = new CustomerItemViewModel() { LastName = FullName, Name = Guid.NewGuid().ToString(), Email = Guid.NewGuid().ToString() };
                Customers.Add(newCustomer);
                SelectedCustomer = newCustomer;
                await Task.Delay(2000);
            }
            finally
            {
                IsBusy = false;
            }
        }


        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set =>  SetProperty(ref _isBusy, value);
        }
    }
}