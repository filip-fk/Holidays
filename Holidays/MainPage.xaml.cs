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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            var now = DateTime.Now;
            var greeting =
                now.Hour < 12 ? "Good morning" :
                now.Hour < 16 ? "Good afternoon" :
                now.Hour < 20 ? "Good evening" :
                /* otherwise */ "Good night";
            Greeting.Text = $"{greeting}";

            var daytoday =
                now.Day;

            var daysleft = 25 - daytoday;

            days.Text = $"{ daysleft }";
        }


        private void opensplitview(object sender, RoutedEventArgs e)
        {
            spv.IsPaneOpen = !spv.IsPaneOpen;
        }

        private void svp_sc(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);

            Greeting.Text = lbi.Content.ToString();

            if (lbi.Content.ToString() == "Home")
            {
                Frame.Navigate(typeof(MainPage));
            }

            else if(lbi.Content.ToString() == "Calendar")
            {
                Frame.Navigate(typeof(cmgrid));
            }
            
        }
    }
}