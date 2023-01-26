using Microsoft.Xaml.Interactivity;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Behaviors
{
    public class MyNumberTextBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
            base.OnDetaching();
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if(e.Key < VirtualKey.Number0 || e.Key > VirtualKey.Number9)
                e.Handled= true;
        }
    }
}
