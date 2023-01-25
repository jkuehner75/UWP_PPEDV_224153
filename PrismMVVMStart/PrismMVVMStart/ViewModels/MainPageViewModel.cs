using Prism.Commands;
using Prism.Common;
using Prism.Mvvm;
using Prism.Regions;
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

        public DelegateCommand GotoSettingsCommand { get; }

        public MainPageViewModel(IRegionManager regionManager)
        {
            GotoSettingsCommand = new DelegateCommand(OnGotoSettings);

            _regionManager = regionManager; 
        }

        private void OnGotoSettings()
        {
            _regionManager.RequestNavigate("ContentRegion", "SettingsPage");
        }
    }
}
