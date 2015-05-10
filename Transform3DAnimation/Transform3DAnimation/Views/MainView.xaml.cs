namespace Transform3DAnimation
{ 
    using Windows.Foundation;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainView : Page
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        private void LayoutRootSizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            var newSize = e.NewSize;
            UpdateForSizeChanged(newSize.Width, newSize.Height);
        }

        private void UpdateForSizeChanged(double newWidth, double newHeight)
        {
            // The rotation creates a rectangular prism effect.
            // The center of rotation should be at X = Width / 2 and Z = -Width / 2
            var centerX = newWidth / 2.0;
            RootTransform.CenterX = centerX;
            NextContentTransform.CenterX = centerX;

            var centerZ = -newWidth / 2.0;
            RootTransform.CenterZ = centerZ;
            NextContentTransform.CenterZ = centerZ;

            // Clip to our left and right bounds so the effect doesn't get too crazy.
            ClipGeometry.Rect = new Rect(0.0, -1024.0, newWidth, newHeight + 1024.0);
        }
    }
}