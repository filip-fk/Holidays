﻿using System;
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
