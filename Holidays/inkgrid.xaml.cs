using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input.Inking;
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
    public sealed partial class inkgrid : Page
    {
        public inkgrid()
        {
            this.InitializeComponent();
            inkCanvas.InkPresenter.InputDeviceTypes =
        Windows.UI.Core.CoreInputDeviceTypes.Mouse |
        Windows.UI.Core.CoreInputDeviceTypes.Pen |
        Windows.UI.Core.CoreInputDeviceTypes.Touch;

            // Set initial ink stroke attributes.
            InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
            drawingAttributes.Color = Windows.UI.Colors.Black;
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;
            inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        }
    }
}
