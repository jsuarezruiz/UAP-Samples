namespace Design.Behaviors
{
    using System;
    using Windows.UI;
    using Windows.UI.ViewManagement;
    using Windows.UI.Xaml;
    using Microsoft.Xaml.Interactivity;

    public class TitleBarBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            var titleBar = associatedObject as UIElement;
            if (titleBar == null)
                throw new ArgumentException(
                    "TitleBarBehavior can be attached only to UIElement!");

            Window.Current.SetTitleBar(titleBar);

            AssociatedObject = associatedObject;
        }

        public void Detach()
        {
            AssociatedObject = null;
        }

        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor",
            typeof(Color),
            typeof(TitleBarBehavior),
            new PropertyMetadata(false, OnBackgroundColorChanged));

        private static void OnBackgroundColorChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            applicationView.TitleBar.BackgroundColor = (Color)e.NewValue;
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title",
            typeof(string),
            typeof(TitleBarBehavior),
            new PropertyMetadata(string.Empty, OnTitleChanged));

        private static void OnTitleChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            applicationView.Title = (string)e.NewValue;
        }

        public Color ForegroundColor
        {
            get { return (Color)GetValue(ForegroundColorProperty); }
            set { SetValue(ForegroundColorProperty, value); }
        }

        public static readonly DependencyProperty ForegroundColorProperty =
            DependencyProperty.Register("ForegroundColor",
            typeof(Color),
            typeof(TitleBarBehavior),
            new PropertyMetadata(false, OnForegroundColorChanged));

        private static void OnForegroundColorChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            applicationView.TitleBar.ForegroundColor = (Color)e.NewValue;
        }

        public Color ButtonForegroundColor
        {
            get { return (Color)GetValue(ButtonForegroundColorProperty); }
            set { SetValue(ButtonForegroundColorProperty, value); }
        }

        public static readonly DependencyProperty ButtonForegroundColorProperty =
            DependencyProperty.Register("ButtonForegroundColor",
            typeof(Color),
            typeof(TitleBarBehavior),
            new PropertyMetadata(false, OnButtonForegroundColorChanged));

        private static void OnButtonForegroundColorChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            applicationView.TitleBar.ButtonForegroundColor = (Color)e.NewValue;
        }

        public Color ButtonBackgroundColor
        {
            get { return (Color)GetValue(ButtonBackgroundColorProperty); }
            set { SetValue(ButtonBackgroundColorProperty, value); }
        }

        public static readonly DependencyProperty ButtonBackgroundColorProperty =
            DependencyProperty.Register("ButtonBackgroundColor",
            typeof(Color),
            typeof(TitleBarBehavior),
            new PropertyMetadata(false, OnButtonBackgroundColorChanged));

        private static void OnButtonBackgroundColorChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            applicationView.TitleBar.ButtonBackgroundColor = (Color)e.NewValue;
        }
    }
}
