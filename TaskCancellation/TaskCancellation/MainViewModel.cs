using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.WindowManagement;

namespace TaskCancellation
{
    internal class MainViewModel : BindableBase
    {
        public DelegateCommand StartCommand { get; }
        public DelegateCommand CancelCommand { get; }

        private CancellationTokenSource _cts;

        public MainViewModel()
        {
            StartCommand = new DelegateCommand(OnStart, CanStart);
            CancelCommand = new DelegateCommand(OnCancel, CanCancel);   
        }

        private bool CanStart() => !_isBusy;
        private async void OnStart()
        {
            _cts = new CancellationTokenSource();
            IsBusy = true;
            try
            {
                await DoSomethingLong(_cts.Token);
            }
            catch (Exception)
            {
                Counter = 0;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task DoSomethingLong(CancellationToken ct)
        {
                for (int i = 0; i < 100; i++)
                {
                    ct.ThrowIfCancellationRequested();
                    await Task.Delay(500);
                    Counter++;
                }
        }

        private bool CanCancel() => _isBusy;   

        private void OnCancel()
        {
            _cts.Cancel();
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                {
                    StartCommand.RaiseCanExecuteChanged();
                    CancelCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private int _counter = 0;

        public int Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);    
        }
    }
}
