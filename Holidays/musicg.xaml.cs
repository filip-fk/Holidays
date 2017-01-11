using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MyToolkit.Multimedia;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class musicg : Page
    {
        public musicg()
        {
            this.InitializeComponent();
        }

        public StorageFile TemporaryFile = null;

        private async void addchb(object sender, RoutedEventArgs e)
        {
            {
                newname.Visibility = Visibility.Collapsed;
                btntext.Text = "Add song";


                var openPicker = new Windows.Storage.Pickers.FileOpenPicker();

                openPicker.FileTypeFilter.Add(".wmv");
                openPicker.FileTypeFilter.Add(".wma");
                openPicker.FileTypeFilter.Add(".mp3");

                var file = await openPicker.PickSingleFileAsync();

                ContentDialog add = new ContentDialog()
                {
                    Title = "Add name",
                    PrimaryButtonText = "Add",
                    SecondaryButtonText = "Cancel",
                    Background = new SolidColorBrush(Color.FromArgb(75, 255, 255, 255))
                };

                StackPanel grid = new StackPanel();
                add.Content = grid;


                TextBlock namenew = new TextBlock();
                namenew.Text = "File name:";
                grid.Children.Add(namenew);

                TextBox nameactnew = new TextBox();
                grid.Children.Add(nameactnew);

                if (file != null)
                {
                    ContentDialogResult result = await add.ShowAsync();
                    if (result == ContentDialogResult.Primary)
                    {
                        //add
                        // mediaPlayer is a MediaElement defined in XAML
                        if (file != null)
                        {
                            Grid newgrid = new Grid();
                            list1.Children.Add(newgrid);

                            //Button overall = new Button();
                            //overall.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                            //overall.Flyout = new Flyout();
                            //overall.Click += SubmitButton_Click;
                            //newgrid.Children.Add(overall);

                            //ProgressBar newprgbr = new ProgressBar();
                            //newprgbr.Maximum = 100;
                            //newprgbr.Value = mediaPlayer.ReadLocalValue;
                            //newprgbr.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                            //                  newprgbr.Foreground = new SolidColorBrush(Color.FromArgb(225, 217, 236, 248));
                            //newprgbr.Height = 22;
                            //                    newgrid.Children.Add(newprgbr);

                            StackPanel newstpmain = new StackPanel();
                            newstpmain.Orientation = Orientation.Vertical;
                            newgrid.Children.Add(newstpmain);

                            StackPanel newstp = new StackPanel();
                            newstp.Orientation = Orientation.Horizontal;
                            newstp.HorizontalAlignment = HorizontalAlignment.Center;
                            newstpmain.Children.Add(newstp);

                            SymbolIcon syi = new SymbolIcon();
                            syi.Symbol = Symbol.Audio;
                            syi.HorizontalAlignment = HorizontalAlignment.Center;
                            newstp.Children.Add(syi);

                            TextBlock newbtn = new TextBlock();
                            newbtn.FontFamily = new FontFamily("Tempus Sans ITC");
                            newbtn.Text = "    " + nameactnew.Text;
                            newbtn.HorizontalAlignment = HorizontalAlignment.Center;
                            newstp.Children.Add(newbtn);

                            MediaPlayerElement newmpe = new MediaPlayerElement();
                            newmpe.AreTransportControlsEnabled = true;
                            newmpe.Source = MediaSource.CreateFromStorageFile(file);
                            newmpe.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                            //newmpe.
                            newstpmain.Children.Add(newmpe);

                            //Border spliter = new Border();
                            //spliter.BorderThickness = new Thickness(2, 1, 0, 0);
                            //newstpmain.Children.Add(spliter);


                            //ProgressBar npb = new ProgressBar();
                            //pb.Value = mediaPlayer.AudioStreamCount;
                            //newstp.Children.Add(npb);
                        }
                    }
                    else
                    {
                        //cancel
                        // mediaPlayer is a MediaElement defined in XAML
                        if (file != null)
                        {
                            Grid newgrid = new Grid();
                            list1.Children.Add(newgrid);

                            //Button overall = new Button();
                            //overall.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                            //overall.Flyout = new Flyout();
                            //overall.Click += SubmitButton_Click;
                            //newgrid.Children.Add(overall);

                            //ProgressBar newprgbr = new ProgressBar();
                            //newprgbr.Maximum = 100;
                            //newprgbr.Value = mediaPlayer.ReadLocalValue;
                            //newprgbr.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                            //                  newprgbr.Foreground = new SolidColorBrush(Color.FromArgb(225, 217, 236, 248));
                            //newprgbr.Height = 22;
                            //                    newgrid.Children.Add(newprgbr);

                            StackPanel newstpmain = new StackPanel();
                            newstpmain.Orientation = Orientation.Vertical;
                            newgrid.Children.Add(newstpmain);

                            StackPanel newstp = new StackPanel();
                            newstp.Orientation = Orientation.Horizontal;
                            newstp.HorizontalAlignment = HorizontalAlignment.Center;
                            newstpmain.Children.Add(newstp);

                            SymbolIcon syi = new SymbolIcon();
                            syi.Symbol = Symbol.Audio;
                            syi.HorizontalAlignment = HorizontalAlignment.Center;
                            newstp.Children.Add(syi);

                            TextBlock newbtn = new TextBlock();
                            newbtn.FontFamily = new FontFamily("Tempus Sans ITC");
                            newbtn.Text = "    " + file.Name;
                            newbtn.HorizontalAlignment = HorizontalAlignment.Center;
                            newstp.Children.Add(newbtn);

                            MediaPlayerElement newmpe = new MediaPlayerElement();
                            newmpe.AreTransportControlsEnabled = true;
                            newmpe.Source = MediaSource.CreateFromStorageFile(file);
                            newmpe.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                            newstpmain.Children.Add(newmpe);

                            //Border spliter = new Border();
                            //spliter.BorderThickness = new Thickness(2, 1, 0, 0);
                            //newstpmain.Children.Add(spliter);


                            //ProgressBar npb = new ProgressBar();
                            //pb.Value = mediaPlayer.AudioStreamCount;
                            //newstp.Children.Add(npb);
                        }
                    }
                }
            }
        }

        //private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        //{
        // Call app specific code to submit form. For example:
        // form.Submit();
        //Windows.UI.Popups.MessageDialog messageDialog =
        //  new Windows.UI.Popups.MessageDialog("Thank you for your submission.");
        //await messageDialog.ShowAsync();

        //}

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
                        Title = "No songs to delete",
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
                        Title = "Delete songs?",
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


        StorageFolder localFolder = ApplicationData.Current.LocalFolder;
        

        private async void play(object sender, RoutedEventArgs e)
        {
            var uriid = vdid.Text;

            if (uriid != null)
            {
                ApplicationDataContainer lokalsettings = ApplicationData.Current.LocalSettings;
                StorageFile sampleFile = await localFolder.CreateFileAsync("savedvideoid.cs", CreationCollisionOption.ReplaceExisting);

                //RootObject1.

                string lines = (vdid.Text).ToString();
                await FileIO.WriteTextAsync(sampleFile, $"{lines}");


                video.HorizontalAlignment = HorizontalAlignment.Center;

                StackPanel newstp = new StackPanel();
                newstp.Orientation = Orientation.Horizontal;
                newstp.HorizontalAlignment = HorizontalAlignment.Center;
                video.Children.Add(newstp);

                StackPanel newstpforvideo = new StackPanel();
                newstpforvideo.Orientation = Orientation.Vertical;
                newstpforvideo.HorizontalAlignment = HorizontalAlignment.Center;
                newstp.Children.Add(newstpforvideo);

                StackPanel newstp1 = new StackPanel();
                newstp1.Orientation = Orientation.Horizontal;
                newstp1.HorizontalAlignment = HorizontalAlignment.Center;
                newstpforvideo.Children.Add(newstp1);

                SymbolIcon syi = new SymbolIcon();
                syi.Symbol = Symbol.Audio;
                syi.HorizontalAlignment = HorizontalAlignment.Left;
                newstp1.Children.Add(syi);

                TextBlock newbtn = new TextBlock();
                newbtn.FontFamily = new FontFamily("Tempus Sans ITC");
                newbtn.HorizontalAlignment = HorizontalAlignment.Left;
                newstp1.Children.Add(newbtn);

                MediaPlayerElement ytbplayer = new MediaPlayerElement();
                ytbplayer.AreTransportControlsEnabled = true;
                ytbplayer.Width = 640;
                ytbplayer.Height = 360;
                ytbplayer.HorizontalAlignment = HorizontalAlignment.Center;
                newstpforvideo.Children.Add(ytbplayer);
                
                ytbplayer.Visibility = Visibility.Visible;
                var videoUri = await YouTube.GetVideoUriAsync($"{uriid}", YouTubeQuality.QualityHigh);
                var nameofvideoyt = await YouTube.GetVideoTitleAsync($"{uriid}");
                if (videoUri != null)
                {
                    ytbplayer.Source = MediaSource.CreateFromUri(videoUri.Uri);
                    ytbplayer.AutoPlay = true;
                    newbtn.Text = "    " + nameofvideoyt;
                }
            }
        }
    }
}
