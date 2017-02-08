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
using Windows.Foundation.Collections;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Holidays
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class photos : Page
    {
        public photos()
        {
            this.InitializeComponent();
            loadphotos();
        }

        public async void loadphotos()
        {
            var myPictures = await Windows.Storage.StorageLibrary.GetLibraryAsync (Windows.Storage.KnownLibraryId.Pictures);
            IObservableVector<Windows.Storage.StorageFolder> myPictureFolders = myPictures.Folders;
        }
    }
}
