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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class wthgrid : Page
    {
        public wthgrid()
        {
            this.InitializeComponent();
            Button_Click();
            var updt = DateTime.Now;
            var nowh = updt.Hour;
            var nowm = updt.Minute;
            update.Text = "Updated as of " + $"{nowh}" + ":" + $"{nowm}" + " PM";
        }

        public async void Button_Click()
        {
            var position = await LocationManager.GetPosition();

            //ResultTextBlock.Text = $"{position.Coordinate.Latitude}" +", "+$"{position.Coordinate.Longitude}";


            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);

            string icon = String.Format("ms-appx:///Assets/Weather/{0}.png", myWeather.list[0].weather[0].icon);
            ResultImage1.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));

            degreesmxd1.Text = ((int)myWeather.list[0].main.temp_max).ToString();
            comm1.Text = myWeather.list[0].weather[0].description;
            place.Text = myWeather.city.name;
            windspeed.Text = "  " + ((int)myWeather.list[0].wind.speed).ToString() + " km/h";
            humidity.Text = "  " + (myWeather.list[0].main.humidity).ToString() + " %";
            Preasure.Text = "  " + ((int)myWeather.list[0].main.pressure).ToString() + " mb";
            feelslike.Text = ((int)myWeather.list[0].main.temp_max - 5).ToString();
            dewpoint.Text = ((int)myWeather.list[0].main.temp_max - 2).ToString();
            visibility.Text = "  " + "5" + " km";

            //degreesmnd1.Text = "  " + ((((int)myWeather.list[0].main.temp_max*9)/5+32).ToString());
        }

        private async void ftoc_ctof(object sender, RoutedEventArgs e)
        {

            var position = await LocationManager.GetPosition();
            RootObject myWeather = await OpenWeatherMapProxy.GetWeather(position.Coordinate.Latitude, position.Coordinate.Longitude);
            if (nowt.Text == "  C°")
            {
                nowt.Text = "  F°";
                couldbt.Content = "  C°";
                degreesmxd1.Text = "  " + ((((int)myWeather.list[0].main.temp_max * 9) / 5 + 32).ToString());
            }

            else
            {
                nowt.Text = "  C°";
                couldbt.Content = "  F°";
                degreesmxd1.Text = ((int)myWeather.list[0].main.temp_max).ToString();
            }
        }
    }
}