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
            var chil = list1.Children.Count();
            numoflist.Text = "("+$"{chil}"+")";
        }

        //string ewitem;
        string items;

        Windows.Storage.ApplicationDataContainer localSettings =
    Windows.Storage.ApplicationData.Current.LocalSettings;
        Windows.Storage.StorageFolder localFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;

        async void ReadTimestamp()
        {
            object value = localSettings.Values["exampleSetting"];
            var forstring = value.ToString();
            string value1 = forstring;

            if (value != null)
            {
                foreach (var result in value1)
                {
                    CheckBox newcheckbox = new CheckBox();
                    newcheckbox.FontFamily = new FontFamily("Tempus Sans ITC");
                    newcheckbox.Content = result;
                    //newcheckbox.Content = $"{value}";
                    list1.Children.Add(newcheckbox);
                }
            }

            else { }

            /*
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
                String timestamp = await FileIO.ReadTextAsync(sampleFile);
                // Data is contained in timestamp
                if ($"{timestamp}" != "")
                {
                    

                    
                    foreach (char m in timestamp)
                    {
                        CheckBox newcheckbox = new CheckBox();
                        newcheckbox.FontFamily = new FontFamily("Tempus Sans ITC");
                        newcheckbox.Content = $"{timestamp}";
                        list1.Children.Add(newcheckbox);
                    }

                    var num = list1.Children.Count();
                    numoflist.Text = "(" + $"{num}" + ")";
                }
            }
            catch (Exception)
            {
                // Timestamp not found
            }

            */
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
                if (newname.Text == "")
                {
                    ContentDialog deleteFileDialog = new ContentDialog()
                    {
                        Title = "Nothing to add!",
                        PrimaryButtonText = "Ok",
                        IsSecondaryButtonEnabled = false
                    };

                    ContentDialogResult result = await deleteFileDialog.ShowAsync();
                }

                else
                {
                    /*
                      Windows.Storage.StorageFolder localFolder =
            Windows.Storage.ApplicationData.Current.LocalFolder;
                    ApplicationDataContainer lokalsettings = ApplicationData.Current.LocalSettings;

                    StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", CreationCollisionOption.ReplaceExisting);

                    */



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
                    //string ewitem = (newcheckbox.Content).ToString();
                    items += (newcheckbox.Content).ToString() + "\n";
                    localSettings.Values["exampleSetting"] = items;
                    // !!! await FileIO.WriteTextAsync(sampleFile, $"{items}");

                    //File.WriteAllLines(sampleFile, $"{lines}");
                    list1.Children.Add(newcheckbox);
                    var chil = list1.Children.Count();
                    numoflist.Text = "(" + $"{chil}" + ")";
                }
            }

        }

        private void save_click(object sender, RoutedEventArgs e)
        { }

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
                        var chil = list1.Children.Count();
                        numoflist.Text = "(" + $"{chil}" + ")";


                        /*
                        ApplicationDataContainer lokalsettings = ApplicationData.Current.LocalSettings;
                        StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", CreationCollisionOption.ReplaceExisting);
                        await FileIO.WriteTextAsync(sampleFile, "");
                        //lokalsettings.DeleteContainer("exampleContainer");
                        */

                    }
                }
            }
        }
    }
}
