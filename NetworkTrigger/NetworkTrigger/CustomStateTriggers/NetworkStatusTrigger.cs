namespace NetworkTrigger.CustomStateTriggers
{
    using System;
    using Windows.Networking.Connectivity;
    using Windows.UI.Core;
    using Windows.UI.Xaml;

    public class NetworkStatusTrigger : StateTriggerBase
    {
        private static NetworkStatus _status;

        public enum NetworkStatus
        {
            Connected = 0,
            NoConnection = 1,
            Unknown = 2
        }

        public NetworkStatusTrigger()
        {
            CheckConnection();

            NetworkInformation.NetworkStatusChanged += NetworkStatusChanged;
        }

        public NetworkStatus Status
        {
            get { return (NetworkStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }

        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(NetworkStatus), typeof(NetworkStatusTrigger),
            new PropertyMetadata(false, OnNetworkStatusPropertyChanged));

        private static void OnNetworkStatusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (NetworkStatusTrigger)d;
            var val = (NetworkStatus)e.NewValue;

            obj.SetActive(val == _status);
        }

        private void NetworkStatusChanged(object sender)
        {
            CheckConnection();
        }

        private async void CheckConnection()
        {
            try
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    _status = NetworkInformation.GetInternetConnectionProfile() != null
                        ? NetworkStatus.Connected
                        : NetworkStatus.NoConnection;
                });
            }
            catch
            {
                _status = NetworkStatus.Unknown;
            }
        }
    }
}