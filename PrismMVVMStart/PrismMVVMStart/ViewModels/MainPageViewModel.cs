using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Regions;
using PrismMVVMStart.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismMVVMStart.ViewModels
{
    internal class MainPageViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly ICustomerRepository _customerRepsoitory;

        public DelegateCommand GotoSettingsCommand { get; }

        public MainPageViewModel(IRegionManager regionManager, ICustomerRepository customerRepsoitory)
        {
            GotoSettingsCommand = new DelegateCommand(OnGotoSettings);

            _regionManager = regionManager; 
            _customerRepsoitory= customerRepsoitory;
        }

        private async void OnGotoSettings()
        {
            var customers = await _customerRepsoitory.GetAllCustomers();

            _regionManager.RequestNavigate("ContentRegion", "SettingsPage");
        }
    }
}
