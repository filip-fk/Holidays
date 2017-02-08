using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.Security.Credentials.UI;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Input.Inking;
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
            connectioncheck1();

            /*
            blanc.Visibility = Visibility.Visible;
            Button signinagain = new Button();
            signinagain.Content = "Sign in";
            signinagain.HorizontalAlignment = HorizontalAlignment.Center;
            signinagain.VerticalAlignment = VerticalAlignment.Center;
            signinagain.Click += Signinagain_Click;
            blanc.Children.Add(signinagain);
            signin();
            */

            inkCanvas.InkPresenter.InputDeviceTypes =
        Windows.UI.Core.CoreInputDeviceTypes.Mouse |
        Windows.UI.Core.CoreInputDeviceTypes.Pen |
        Windows.UI.Core.CoreInputDeviceTypes.Touch;

            var now = DateTime.Now;
            var greeting =
                now.Hour < 12 ? "Good morning" :
                now.Hour < 16 ? "Good afternoon" :
                now.Hour < 20 ? "Good evening" :
                /* otherwise */ "Good night";
            Greeting.Text = $"{greeting}";

            var daytoday =
                now.Day;

            var year = now.Year;
            var month = now.Month;
            var day = now.Day;


            //DateTime date1 = new DateTime(year, month, day, 0, 0, 0);
            DateTime date1 = new DateTime(2017, 12, 25, 0, 0, 0);
            //days.Text = $"{date1}";
            DateTime date2 = new DateTime(year, month, day, 0, 0, 0);
            //days.Text = $"{date2}";
            //int result = DateTime.Compare(date1, date2);
            //string relationship;

            //if (result == 0)
            //days.Text = "0";
            //else

            TimeSpan duration = date1 - date2;


            days.Text = $"{ duration.Days }";


            var daysleft = 25 - daytoday;

            //days.Text = "--";
            //days.Text = $"{ daysleft }";
        }

        public async void connectioncheck1()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
            String timestamp = await FileIO.ReadTextAsync(sampleFile);

            /*
            DispatcherTimer dispatcherTimer;
            DateTimeOffset startTime;
            DateTimeOffset stopTime;

            dispatcherTimer = new DispatcherTimer();
            //dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            startTime = DateTimeOffset.Now;
            dispatcherTimer.Start();
            if (dispatcherTimer.Equals(20))
            {
                dispatcherTimer.Stop();
                connflyout.Visibility = Visibility.Collapsed;
            }
            //IsEnabled should now be true after calling start
            */
            
            if ($"{timestamp}" == "No internet")
            {
                connection.Visibility = Visibility.Visible;
                connection.Text = "❌";
                connection.Visibility = Visibility.Visible;
                connectionstatusflyout.Content = "❌ No internet";
            }

            else
            {
                connection.Text = "✔";
                connection.Visibility = Visibility.Visible;
            }
        }

        public async void signin()
        {
        }
        /*{
            UserConsentVerificationResult consentResult = await UserConsentVerifier.RequestVerificationAsync("Please sign in");
            if (consentResult.Equals(UserConsentVerificationResult.Verified))
            {

                // continue
                //master10.Children.Clear();
                blanc.Visibility = Visibility.Collapsed;
            }

            else
            {
                blanc.Visibility = Visibility.Visible;
                /*
                Grid white = new Grid();
                white.Background = new SolidColorBrush(Color.FromArgb(10,0,0,0));
                //white.Opacity = 10;
                master10.Children.Add(white);

                Button signinagain = new Button();
                signinagain.Content = "Sign in";
                signinagain.HorizontalAlignment = HorizontalAlignment.Center;
                signinagain.VerticalAlignment = VerticalAlignment.Center;
                signinagain.Click += Signinagain_Click;
                white.Children.Add(signinagain);
                
            }
        }

        private void Signinagain_Click(object sender, RoutedEventArgs e)
        {
            signin();
        }
*/

        private string[] selectionItems = new string[] { "Weather", "try 2", "random 3", "my 4" };

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = selectionItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (sugg.Text == "Weather")
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Visible;
                inkg.Visibility = Visibility.Collapsed;
            }
        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
        }

        private void opensplitview(object sender, RoutedEventArgs e)
        {
            spv.IsPaneOpen = !spv.IsPaneOpen;
        }

        private void svp_sc(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);

            if (home.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Visible;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Collapsed;
                inkg.Visibility = Visibility.Collapsed;
            }

            if (calendar.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Visible;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Collapsed;
                inkg.Visibility = Visibility.Collapsed;
            }

            if (shoplidt.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Visible;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Collapsed;
                inkg.Visibility = Visibility.Collapsed;
            }

            if (movies.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Visible;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Collapsed;
                inkg.Visibility = Visibility.Collapsed;
            }

            if (music.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Visible;
                wthg.Visibility = Visibility.Collapsed;
                inkg.Visibility = Visibility.Collapsed;
            }

            if (weather.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Visible;
                inkg.Visibility = Visibility.Collapsed;
            }
            if (ink.IsSelected == true)
            {
                mastergrid.Visibility = Visibility.Collapsed;
                cmg.Visibility = Visibility.Collapsed;
                shmg.Visibility = Visibility.Collapsed;
                mvg.Visibility = Visibility.Collapsed;
                msg.Visibility = Visibility.Collapsed;
                wthg.Visibility = Visibility.Collapsed;
                inkg.Visibility = Visibility.Visible;


                /*
                 inkg.Height = master10.Height - 100;
                inkg.Width = master10.Width - 70;
                 inkg.HorizontalAlignment = HorizontalAlignment.Right;
                inkg.VerticalAlignment = VerticalAlignment.Bottom;
                 */
            }
        }

        private void showwhite(object sender, RoutedEventArgs e)
        {
            backg.Visibility = Visibility.Visible;
        }

        private void hidewhite(object sender, RoutedEventArgs e)
        {
            backg.Visibility = Visibility.Collapsed;
        }

        private void writerec(object sender, RoutedEventArgs e)
        {
            //recognize.Visibility = Visibility.Visible;
        }

        private void drawnorec(object sender, RoutedEventArgs e)
        {
            //recognize.Visibility = Visibility.Collapsed;
        }

        //string newstr = "";

        private async void recognizetext(object sender, RoutedEventArgs e)
        {
            if (rectangleItems.Items.Count > 0)
            {
                rectangleItems.Items.Clear();
            }

            // Get all strokes on the InkCanvas.
            IReadOnlyList<InkStroke> currentStrokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();


            // Ensure an ink stroke is present.
            if (currentStrokes.Count > 0)
            {
                // Create a manager for the InkRecognizer object
                // used in handwriting recognition.
                InkRecognizerContainer inkRecognizerContainer =
                    new InkRecognizerContainer();

                // inkRecognizerContainer is null if a recognition engine is not available.
                if (!(inkRecognizerContainer == null))
                {
                    // Recognize all ink strokes on the ink canvas.
                    IReadOnlyList<InkRecognitionResult> recognitionResults =
                        await inkRecognizerContainer.RecognizeAsync(
                            inkCanvas.InkPresenter.StrokeContainer,
                            InkRecognitionTarget.All);
                    // Process and display the recognition results.
                    if (recognitionResults.Count > 0)
                    {
                        //string str = "Recognition result\n";
                        // Iterate through the recognition results.
                        foreach (var result in recognitionResults)
                        {
                            // Get all recognition candidates from each recognition result.
                            IReadOnlyList<string> candidates = result.GetTextCandidates();
                            //str += "Candidates: " + candidates.Count.ToString() + "\n";
                            foreach (string candidate in candidates)
                            {
                                Button ncan = new Button();
                                ncan.Content = candidate;
                                ncan.Click += Ncan_Click;
                                //newstr += ncan.Content + " ";
                                rectangleItems.Items.Add(ncan);
                                //str += candidate + " ";
                            }
                        }
                        // Display the recognition candidates.
                        //recognitionResult.Text = str;
                        // Clear the ink canvas once recognition is complete.
                        inkCanvas.InkPresenter.StrokeContainer.Clear();
                    }
                    else
                    {
                        //recognitionResult.Text = "No recognition results.";
                    }
                }
                else
                {
                    Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("You must install handwriting recognition engine.");
                    await messageDialog.ShowAsync();
                }
            }
            else
            {
                //recognitionResult.Text = "No ink strokes to recognize.";
            }
        }

        private void Ncan_Click(object sender, RoutedEventArgs e)
        {
            //recognitionResult.Text = newstr;

        }

        private void svp_sc2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void hideflyout(object sender, RoutedEventArgs e)
        {
            connflyout.Hide();
        }
    }
}