using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Glazer_Calculation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.calculateButton.IsEnabled = false;
        }

        public int getWidth() {
            return Convert.ToInt32(this.Length.Text);
        }

        public int getHeight() {
            return Convert.ToInt32(this.Height.Text);
        }

        public int getQuantity() {
            return Convert.ToInt32(this.Quantity.Value);
        }

        public string getColor() {
            ComboBoxItem item = (ComboBoxItem)this.Color.SelectedItem;
            string value = item.Content.ToString();
            return value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GlazerCalculator glazerCal = new GlazerCalculator();
            glazerCal.calcGlassArea(this);
            double woodLength = glazerCal.calcWoodLength(this);
            double glassArea = glazerCal.calcGlassArea(this);

            glazerCal.woodLegth = woodLength;
            glazerCal.glassArea = glassArea;
            glazerCal.quantity = this.getQuantity();
            glazerCal.color = this.getColor();

            this.Frame.Navigate(typeof(Result), glazerCal);
        }

        private bool IsNumeric(string s)
        {
            Regex r = new Regex(@"^[0-9]+$");

            return r.IsMatch(s);
        }

        private void Width_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key) {
                case Windows.System.VirtualKey.Number1:break;
                case Windows.System.VirtualKey.Number0: break;
                case Windows.System.VirtualKey.Number2: break;
                case Windows.System.VirtualKey.Number3: break;
                case Windows.System.VirtualKey.Number4: break;
                case Windows.System.VirtualKey.Number5: break;
                case Windows.System.VirtualKey.Number6: break;
                case Windows.System.VirtualKey.Number7: break;
                case Windows.System.VirtualKey.Number8:break;
                case Windows.System.VirtualKey.Number9: e.Handled =false; break;
                default: e.Handled = true; break;
            }

        }

        private void Height_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Number1: break;
                case Windows.System.VirtualKey.Number0: break;
                case Windows.System.VirtualKey.Number2: break;
                case Windows.System.VirtualKey.Number3: break;
                case Windows.System.VirtualKey.Number4: break;
                case Windows.System.VirtualKey.Number5: break;
                case Windows.System.VirtualKey.Number6: break;
                case Windows.System.VirtualKey.Number7: break;
                case Windows.System.VirtualKey.Number8: break;
                case Windows.System.VirtualKey.Number9: e.Handled = false; break;
                default: e.Handled = true; break;
            }
        }

        private void Height_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Height.Text !="" && this.Length.Text !="") {
                this.calculateButton.IsEnabled = true;
            } else {
                this.calculateButton.IsEnabled = false;
            }
        }

        private void Length_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Height.Text != "" && this.Length.Text !=""){
                this.calculateButton.IsEnabled = true;
            } else {
                this.calculateButton.IsEnabled = false;
            }
        }
    }
}
