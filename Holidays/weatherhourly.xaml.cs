using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class weatherhourly : Page
    {
        public weatherhourly()
        {
            this.InitializeComponent();


            var now = DateTime.Now;
            var date1n = now.Day;
            var dow = now.DayOfWeek;



            if (mwg.Width == 300)
            {

            }

            else if (mwg.Width < 300)
            {

            }

            /*
            Random rnd = new Random();

            string[] mystrings = "snow|snow|snow|snow|sun|cloud|cloud|cloud|cloud|cloud|cloud".Split('|');

            string[] snowcomm = "Snow|Blizard|Light snow|Light snow|Light snow|Snow".Split('|');
            string[] suncomm = "Sunny|Partially sunny".Split('|');
            string[] cloudcomm = "Cloudy|Partially cloudy|Mostly cloudy".Split('|');

            Random rnd1 = new Random();

            string blah1 = mystrings[rnd.Next(mystrings.Length)];

            string snowcomm1 = snowcomm[rnd.Next(snowcomm.Length)];
            string suncomm1 = suncomm[rnd.Next(suncomm.Length)];
            string cloudcomm1 = cloudcomm[rnd.Next(cloudcomm.Length)];

            TextBlock rndr = new TextBlock();
            rndr.Text = $"{ blah1 }";

            if (rndr.Text == "snow")
            {
                weatherd1snow.Visibility = Visibility.Visible;
                weatherd1sun.Visibility = Visibility.Collapsed;
                weatherd1cloud.Visibility = Visibility.Collapsed;
                int tsmx = rnd.Next(1, 10);
                int tsmn = rnd.Next(-10, 0);
                degreesmxd1.Text = $"{ tsmx }";
                degreesmnd1.Text = $"{ tsmn }";
                comm1.Text = $"{snowcomm1}";
            }

            else if (rndr.Text == "sun")
            {
                weatherd1snow.Visibility = Visibility.Collapsed;
                weatherd1sun.Visibility = Visibility.Visible;
                weatherd1cloud.Visibility = Visibility.Collapsed;
                int tumx = rnd.Next(12, 20);
                int tumn = rnd.Next(6, 10);
                degreesmxd1.Text = $"{ tumx }";
                degreesmnd1.Text = $"{ tumn }";
                comm1.Text = $"{suncomm1}";
            }

            else if (rndr.Text == "cloud")
            {
                weatherd1snow.Visibility = Visibility.Collapsed;
                weatherd1sun.Visibility = Visibility.Collapsed;
                weatherd1cloud.Visibility = Visibility.Visible;
                int tumx = rnd.Next(5, 15);
                int tumn = rnd.Next(-3, 5);
                degreesmxd1.Text = $"{ tumx }";
                degreesmnd1.Text = $"{ tumn }";
                comm1.Text = $"{cloudcomm1}";
            }

            */

            Button_Click();
        }

        public async void Button_Click()
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
            String timestamp = await FileIO.ReadTextAsync(sampleFile);

            if ($"{timestamp}" == "No internet")
            {
            }

            else
            {
                var position = await LocationManager.GetPosition();

                //ResultTextBlock.Text = $"{position.Coordinate.Latitude}" +", "+$"{position.Coordinate.Longitude}";

                RootObject myWeather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);

                string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.list[0].weather[0].icon);
                ResultImage1.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));


                degreesmxd1.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm1.Text = myWeather.list[0].weather[0].description;
                windd1.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";


                ResultImage2.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //degreesmnd2.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd2.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm2.Text = myWeather.list[0].weather[0].description;
                windd2.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";

                ResultImage3.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //    degreesmnd3.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd3.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm3.Text = myWeather.list[0].weather[0].description;
                windd3.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";


                ResultImage4.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //   degreesmnd4.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd4.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm4.Text = myWeather.list[0].weather[0].description;
                windd4.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";

                ResultImage5.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //   degreesmnd5.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd5.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm5.Text = myWeather.list[0].weather[0].description;
                windd5.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";

                ResultImage6.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                // degreesmnd6.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd6.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm6.Text = myWeather.list[0].weather[0].description;
                windd6.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";

                ResultImage7.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                // degreesmnd7.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd7.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm7.Text = myWeather.list[0].weather[0].description;
                windd7.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";

                ResultImage8.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //   degreesmnd8.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd8.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm8.Text = myWeather.list[0].weather[0].description;
                windd8.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";


                ResultImage9.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                //degreesmnd9.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd9.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm9.Text = myWeather.list[0].weather[0].description;
                windd9.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";

                ResultImage10.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
                // degreesmnd10.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd10.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm10.Text = myWeather.list[0].weather[0].description;
                windd10.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";


                /*

                ResultImage2.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/10d.png", UriKind.Absolute));
                degreesmnd2.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd2.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm2.Text = myWeather.list[0].weather[0].description;

                ResultImage3.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/04n.png", UriKind.Absolute));
                degreesmnd3.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd3.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm3.Text = myWeather.list[0].weather[0].description;


                ResultImage4.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/01n.png", UriKind.Absolute));
                degreesmnd4.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd4.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm4.Text = myWeather.list[0].weather[0].description;

                ResultImage5.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/11n.png", UriKind.Absolute));
                degreesmnd5.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd5.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm5.Text = myWeather.list[0].weather[0].description;

                ResultImage6.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/50d.png", UriKind.Absolute));
                degreesmnd6.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd6.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm6.Text = myWeather.list[0].weather[0].description;

                ResultImage7.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/10n.png", UriKind.Absolute));
                degreesmnd7.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd7.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm7.Text = myWeather.list[0].weather[0].description;

                ResultImage8.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/01d.png", UriKind.Absolute));
                degreesmnd8.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd8.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm8.Text = myWeather.list[0].weather[0].description;


                ResultImage9.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/03d.png", UriKind.Absolute));
                degreesmnd9.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd9.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm9.Text = myWeather.list[0].weather[0].description;

                ResultImage10.Source = new BitmapImage(new Uri("ms-appx:///Assets/Weather/02n.png", UriKind.Absolute));
                degreesmnd10.Text = ((int)myWeather.list[0].main.temp_min - 1).ToString();
                degreesmxd10.Text = ((int)myWeather.list[0].main.temp_max + 1).ToString();
                comm10.Text = myWeather.list[0].weather[0].description;

                */


                /*
                if (mwg.Width == 300)
                {

                }

                else if (mwg.Width > 300)
                {
                    degreesmxd4.Text = ((int)myWeather.main.temp_max + 4).ToString();
                }
                */
            }
        }
    }
}