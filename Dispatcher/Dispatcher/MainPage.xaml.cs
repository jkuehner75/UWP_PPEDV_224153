using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Dispatcher
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly Timer _timer;
        private readonly CoreDispatcher _dispatcher;

        public MainPage()
        {
            this.InitializeComponent();

            _dispatcher = CoreApplication.GetCurrentView().CoreWindow.Dispatcher;
            _timer = new Timer(TimerElapsed, null, 0, 500);
        }

        private async void TimerElapsed(object state)
        {
            //.....
            await _dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () => 
            {
                ///await 
                txt.Text = "ztfztfzf";
            });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
                //System.Threading.Thread.Sleep(5000);    
                //vs
                await Task.Delay(5000);
        }
    }
}
