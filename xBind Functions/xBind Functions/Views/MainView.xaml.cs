using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using xBind_Functions.Models;

namespace xBind_Functions.Views
{
    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        public string UserPassword { get; set; }

        public SolidColorBrush PasswordStrengthBrush(string password)
        {
            if (string.IsNullOrEmpty(password))
                return new SolidColorBrush(Colors.Transparent);

            int length = password.Length;

            if (length >= 3 && length < 6)
                return new SolidColorBrush(Colors.Orange);
            if (length >= 6)
                return new SolidColorBrush(Colors.Green);

            return new SolidColorBrush(Colors.Red);
        }

        public double PasswordStrengthValue(string password)
        {
            if (string.IsNullOrEmpty(password))
                return 0;

            int length = password.Length;

            if (length >= 3 && length < 6)
                return 66;
            if (length >= 6)
                return 100;

            return 33;
        }
    }
}
