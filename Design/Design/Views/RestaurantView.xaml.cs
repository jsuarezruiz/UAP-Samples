namespace Design.Views
{
    using System;
    using Windows.Storage.Streams;
    using Windows.Foundation;
    using Windows.UI.Xaml.Controls.Maps;
    using Base;

    public sealed partial class RestaurantView : PageBase
    {
        public RestaurantView()
        {
            InitializeComponent();

            Map.Loaded += (sender, args) =>
            {
                AddPushPin();
            };
        }

        private void AddPushPin()
        {
            var mapIconStreamReference = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/Burger.png"));

            MapIcon mapIcon = new MapIcon
            {
                Location = Map.Center,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = "Burger Restaurant",
                Image = mapIconStreamReference,
                ZIndex = 0
            };

            Map.MapElements.Add(mapIcon);
        }
    }
}