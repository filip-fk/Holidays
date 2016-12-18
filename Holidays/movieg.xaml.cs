using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
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
    public sealed partial class movieg : Page
    {
        public movieg()
        {
            this.InitializeComponent();
        }

        private async void addchb(object sender, RoutedEventArgs e)
        {
            {
                newname.Visibility = Visibility.Collapsed;
                btntext.Text = "Add movie";


                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
                picker.FileTypeFilter.Add(".mov");
                picker.FileTypeFilter.Add(".avi");
                picker.FileTypeFilter.Add(".mp4");

                var file = await picker.PickSingleFileAsync();

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
                    syi.Symbol = Symbol.Play;
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

        private void saveedit_click(object sender, RoutedEventArgs e)
        {
            if (nameoflist.Visibility == Visibility.Visible)
            {
                nameoflist.Visibility = Visibility.Collapsed;
                editnol.Visibility = Visibility.Visible;
                saveedit.Visibility = Visibility.Collapsed;
                save.Visibility = Visibility.Visible;
            }

        }

        private void save_click(object sender, RoutedEventArgs e)
        {
            nameoflist.Visibility = Visibility.Visible;
            editnol.Visibility = Visibility.Collapsed;
            nameoflist.Text = editnol.Text;
            saveedit.Visibility = Visibility.Visible;
            save.Visibility = Visibility.Collapsed;
        }
    }
}
