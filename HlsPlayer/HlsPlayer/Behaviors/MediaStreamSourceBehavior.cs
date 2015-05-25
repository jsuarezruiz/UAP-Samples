namespace HlsPlayer.Behaviors
{
    using Microsoft.Xaml.Interactivity;
    using System;
    using Windows.Media.Streaming.Adaptive;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class MediaStreamSourceBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            var control = associatedObject as MediaElement;
            if (control == null)
                throw new ArgumentException(
                    "MediaStreamSourceBehavior can be attached only to MediaElement.");

            AssociatedObject = associatedObject;
        }

        public void Detach()
        {
            AssociatedObject = null;
        }

        public AdaptiveMediaSource Media
        {
            get { return (AdaptiveMediaSource)GetValue(MediaProperty); }
            set { SetValue(MediaProperty, value); }
        }

        public static readonly DependencyProperty MediaProperty =
            DependencyProperty.Register("Media",
            typeof(AdaptiveMediaSource),
            typeof(MediaStreamSourceBehavior),
            new PropertyMetadata(null, OnMediaChanged));

        private static void OnMediaChanged(object sender,
        DependencyPropertyChangedEventArgs e)
        {
            var behavior = sender as MediaStreamSourceBehavior;
            if (behavior.AssociatedObject == null || e.NewValue == null) return;

            var mediaElement = behavior.AssociatedObject as MediaElement;
            if (mediaElement != null)
                mediaElement.SetMediaStreamSource((AdaptiveMediaSource)e.NewValue);
        }
    }
}
