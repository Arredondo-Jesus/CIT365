using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Glazer_Calculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Result : Page
    {
        public Result()
        {
            this.InitializeComponent();
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Object)
            {
                var calc = (GlazerCalculator)e.Parameter;
                this.Height.Text = $"{calc.height.ToString()} inches";
                this.Width.Text = $"{calc.width.ToString()} inches";
                this.Length.Text = $"{calc.woodLegth.ToString()} inches";
                this.Area.Text = $"{calc.glassArea.ToString()} inches";
                this.Color.Text = $"{calc.color.ToString()}";
                this.Quantity.Text = $"{calc.quantity.ToString()}";
            }
            else
            {
                Area.Text = "There was an error with one of the parameters";
            }
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        
    }
}
