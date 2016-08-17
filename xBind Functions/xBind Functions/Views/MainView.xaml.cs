using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using xBind_Functions.Models;

namespace xBind_Functions.Views
{
    public sealed partial class MainView : Page
    {
        private ObservableCollection<House> _houses;

        public MainView()
        {
            this.InitializeComponent();

            // Init
            IsVisible = true;
            IsNotVisible = false;

            Dictionary = new Dictionary<string, string>()
            {
                { "Clave", "Valor" }
            };

            Element = new TextBlock
            {
                Text = "Cool"
            };
        }
               
        public string UserPassword { get; set; }
        public bool IsVisible { get; set; }
        public bool IsNotVisible { get; set; }
        public Dictionary<string, string> Dictionary { get; set; }
        public object Element { get; set; }

        public ObservableCollection<House> Houses
        {
            get
            {
                if (_houses == null)
                    LoadHouses();

                return _houses;
            }
        }

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

        private void LoadHouses()
        {
            _houses = new ObservableCollection<House>();

            _houses.Add(new House
            {
                Name = "Home 1"
            });
            _houses.Add(new House
            {
                Name = "Home 2"
            });
        }
    }
}