using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace InkToolbar_Sample.Views
{
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();

            InkCanvas.InkPresenter.InputDeviceTypes = 
                CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Pen | CoreInputDeviceTypes.Touch;
        }

        public void OnClear()
        {
            InkCanvas.InkPresenter.StrokeContainer.Clear();
        }
    }
}
