namespace ParallaxEffect.Controls
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Media3D;

    public class ParallaxHub : Hub
    {
        private ScrollViewer _scrollViewer;
        private CompositeTransform3D _backgroundTransform;

        public ParallaxHub()
        {
            this.DefaultStyleKey = typeof(ParallaxHub);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _scrollViewer = GetTemplateChild("ScrollViewer") as ScrollViewer;
            _backgroundTransform = GetTemplateChild("BackgroundTransform") as CompositeTransform3D;

            if (_scrollViewer != null && _backgroundTransform != null)
            {
                _scrollViewer.SizeChanged += ScrollViewer_SizeChanged;
            }
        }

        private void UpdateForSizeChanged()
        {
            // Since the background Border will always start in the top left, we don't need to use
            // the TransformToVisual() trick here.

            var horizontalOffset = _scrollViewer.ViewportWidth / 2.0;
            var verticalOffset = _scrollViewer.ViewportHeight / 2.0;

            _backgroundTransform.CenterX = horizontalOffset;
            _backgroundTransform.CenterY = verticalOffset;
        }

        private void ScrollViewer_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateForSizeChanged();
        }
    }
}
