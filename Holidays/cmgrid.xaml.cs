using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class cmgrid : Page
    {
        public cmgrid()
        {
            this.InitializeComponent();
        }

        private void adddate(object sender, RoutedEventArgs e)
        {
            
        }

        


        private void dateadd(object sender, DatePickerValueChangedEventArgs e)
        {
            Grid item = new Grid();
            newdateslist.Children.Add(item);

            TextBlock date = new TextBlock();
            date.FontFamily = new FontFamily("segoe print");
            var now = DateTime.Now;
            var today2 = now.Day;
            var today3 = now.Month;
            var today = now.DayOfYear;
            var datechosen = dtpk.Date;
            var endpoint = datechosen.DayOfYear;
            var endpoint2 = datechosen.Day;
            var endpoint3 = datechosen.Month;

            if (endpoint > today)
            {
                var daysleft = $"{endpoint - today}";
                date.Text = "\nFrom the " + $"{today2}" + "/" + $"{today3}" + " to the " + $"{endpoint2}" + "/" + $"{endpoint3}" + " there are " + $"{daysleft}" + " days left.";
            }

            else if (endpoint < today)
            {
                var daysleft = $"{today + (366 - today) + endpoint - 366 + (366 - today)}";
                date.Text = "\nFrom the " + $"{today2}" + "/" + $"{today3}" + " to the " + $"{endpoint2}" + "/" + $"{endpoint3}" + " there are " + $"{daysleft}" + " days left.";
            }

            item.Children.Add(date);

            StackPanel stpnew = new StackPanel();
            stpnew.Orientation = Orientation.Horizontal;
            stpnew.HorizontalAlignment = HorizontalAlignment.Right;
            item.Children.Add(stpnew);

            CheckBox tryn = new CheckBox();
            tryn.FontFamily = new FontFamily("segoe mdl2 assets");
            tryn.Content = "   ";
            tryn.VerticalAlignment = VerticalAlignment.Center;
            tryn.FontSize = 25;
            tryn.Foreground = new SolidColorBrush(Colors.Yellow);
            tryn.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            stpnew.Children.Add(tryn);

            CheckBox chb = new CheckBox();
            chb.IsChecked = true;
            chb.Content = "Show on Homepage  ";
            stpnew.Children.Add(chb);
        }

        private async void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (newdateslist.Children.Count == 0)
            {

            }

            else
            {

                ContentDialog deleteFileDialog = new ContentDialog()
                {
                    Title = "Delete date?",
                    PrimaryButtonText = "Delete",
                    SecondaryButtonText = "Cancel"
                };

                ContentDialogResult result = await deleteFileDialog.ShowAsync();

                // Delete the file if the user clicked the primary button. 
                /// Otherwise, do nothing. 
                if (result == ContentDialogResult.Primary)
                {
                    newdateslist.Children.Clear();
                }
            }
        }

        private void perbar_ch(object sender, RoutedEventArgs e)
        {
            perbargrid.Visibility = Visibility.Visible;
        }

        private async void perbar_unch(object sender, RoutedEventArgs e)
        {
            perbargrid.Visibility = Visibility.Collapsed;

            if (newdateslist.Children.Count == 0)
            {

            }

            else
            {
                ContentDialog deleteFileDialog = new ContentDialog()
                {
                    Title = "Delete date?",
                    Content = "Do you want to delete all dates",
                    PrimaryButtonText = "Delete",
                    SecondaryButtonText = "Store"
                };

                ContentDialogResult result = await deleteFileDialog.ShowAsync();

                // Delete the file if the user clicked the primary button. 
                /// Otherwise, do nothing. 
                if (result == ContentDialogResult.Primary)
                {
                    newdateslist.Children.Clear();
                }
            }
        }
    }
}
