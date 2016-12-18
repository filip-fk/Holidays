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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class shoplistg : Page
    {
        public shoplistg()
        {
            this.InitializeComponent();
        }

        private void addchb(object sender, RoutedEventArgs e)
        {
            if (newname.Visibility == Visibility.Collapsed)
            {
                newname.Visibility = Visibility.Visible;
                btntext.Text = "";
            }

            else
            {
                newname.Visibility = Visibility.Collapsed;
                btntext.Text = "Add item";
                CheckBox newcheckbox = new CheckBox();
                newcheckbox.FontFamily = new FontFamily("Tempus Sans ITC");
                newcheckbox.Content = newname.Text;
                list1.Children.Add(newcheckbox);
            }

        }

        private void save_edit(object sender, RoutedEventArgs e)
        {
            if (nameoflist.Visibility == Visibility.Visible)
            {
                nameoflist.Visibility = Visibility.Collapsed;
                editnol.Visibility = Visibility.Visible;
                f1.Symbol = Symbol.Save;
                f2.Symbol = Symbol.Cancel;
            }

            else if (nameoflist.Visibility == Visibility.Collapsed)
            {
                nameoflist.Visibility = Visibility.Visible;
                editnol.Visibility = Visibility.Collapsed;
                f1.Symbol = Symbol.Edit;
                f2.Symbol = Symbol.Delete;
                nameoflist.Text = editnol.Text;
            }
        }

        private async void deleteitems(object sender, RoutedEventArgs e)
        {
            if (nameoflist.Visibility == Visibility.Collapsed)
            {
                nameoflist.Visibility = Visibility.Visible;
                editnol.Visibility = Visibility.Collapsed;
                f1.Symbol = Symbol.Edit;
                f2.Symbol = Symbol.Delete;
            }

            else if (nameoflist.Visibility == Visibility.Visible)
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
                    list1.Children.Clear();
                }
            }
        }
    }
}
