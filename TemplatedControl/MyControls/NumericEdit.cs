using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234235

namespace MyControls
{
    public sealed class NumericEdit : Control
    {
        public NumericEdit()
        {
            this.DefaultStyleKey = typeof(NumericEdit);
        }



        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(NumericEdit), new PropertyMetadata(null));

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if(Template != null) 
            {
                var btn = GetTemplateChild("PART_Increment") as Button;
                if(btn != null) 
                {
                    btn.Click += Btn_IncClick;
                }
            }
        }

        private void Btn_IncClick(object sender, RoutedEventArgs e)
        {
            Number = Number + "w";
        }
    }
}
