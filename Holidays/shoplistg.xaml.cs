using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
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
            ReadTimestamp();
        }

        

        async void ReadTimestamp()
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.cs");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                // Data is contained in timestamp
                if ($"{timestamp}" != "")
                {
                    CheckBox newcheckbox = new CheckBox();
                    newcheckbox.FontFamily = new FontFamily("Tempus Sans ITC");
                    newcheckbox.Content = $"{timestamp}";
                    list1.Children.Add(newcheckbox);
                }
            }
            catch (Exception)
            {
                // Timestamp not found
            }
        }

        private async void addchb(object sender, RoutedEventArgs e)
        {
            if (newname.Visibility == Visibility.Collapsed)
            {
                newname.Visibility = Visibility.Visible;
                btntext.Text = "";
            }

            else
            {
                ApplicationDataContainer lokalsettings = ApplicationData.Current.LocalSettings;
                
                StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.cs", CreationCollisionOption.ReplaceExisting);
                //var name10 = sampleFile.Name;

                //, CreationCollisionOption.ReplaceExisting

                newname.Visibility = Visibility.Collapsed;
                btntext.Text = "Add item";
                CheckBox newcheckbox = new CheckBox();
                newcheckbox.FontFamily = new FontFamily("Tempus Sans ITC");
                newcheckbox.Content = newname.Text;
                //newcheckbox.Content = $"{name10}";
                //await FileIO.WriteTextAsync(sampleFile, $"{newcheckbox.Content}");
                //await FileIO.WriteTextAsync(sampleFile, $"{newcheckbox.Content}");
                string lines = (newcheckbox.Content).ToString();
                await FileIO.WriteTextAsync(sampleFile, $"{lines}");
                //File.WriteAllLines(sampleFile, $"{lines}");
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
                if (list1.Children.Count == 0)
                {
                    ContentDialog deleteFileDialog = new ContentDialog()
                    {
                        Title = "No items to delete",
                        PrimaryButtonText = "Ok"
                    };

                    ContentDialogResult result = await deleteFileDialog.ShowAsync();

                    // Delete the file if the user clicked the primary button. 
                    /// Otherwise, do nothing. 
                    if (result == ContentDialogResult.Primary)
                    {

                    }
                }

                else
                {
                    ContentDialog deleteFileDialog = new ContentDialog()
                    {
                        Title = "Empty shopping list?",
                        PrimaryButtonText = "Empty",
                        SecondaryButtonText = "Cancel"
                    };

                    ContentDialogResult result = await deleteFileDialog.ShowAsync();

                    // Delete the file if the user clicked the primary button. 
                    /// Otherwise, do nothing. 
                    if (result == ContentDialogResult.Primary)
                    {
                        list1.Children.Clear();

                        ApplicationDataContainer lokalsettings = ApplicationData.Current.LocalSettings;
                        StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", CreationCollisionOption.ReplaceExisting);
                        await FileIO.WriteTextAsync(sampleFile, "");
                        //lokalsettings.DeleteContainer("exampleContainer");
                    }
                }
            }
        }

        Windows.Storage.ApplicationDataContainer localSettings =
    Windows.Storage.ApplicationData.Current.LocalSettings;
        Windows.Storage.StorageFolder localFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
    }
}
