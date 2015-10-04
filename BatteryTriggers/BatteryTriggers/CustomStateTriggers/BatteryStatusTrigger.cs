namespace BatteryTriggers.CustomStateTriggers
{
    using Windows.UI.Xaml;

    public class BatteryStatusTrigger : StateTriggerBase
    {
        private static BatteryChargingStatus _charging;

        public enum BatteryChargingStatus
        {
            Charging = 0,
            Discharging = 1,
            Unknown = 2
        }

        public BatteryStatusTrigger()
        {
            UpdateStatus();

            Windows.Devices.Power.Battery.AggregateBattery.ReportUpdated += (s, a) =>
            {
                UpdateStatus();
            };
        }

        public BatteryChargingStatus BatteryStatus
        {
            get { return (BatteryChargingStatus)GetValue(BatteryStatusProperty); }
            set { SetValue(BatteryStatusProperty, value); }
        }

        public static readonly DependencyProperty BatteryStatusProperty =
            DependencyProperty.Register("BatteryStatus", typeof(BatteryChargingStatus), typeof(BatteryStatusTrigger),
            new PropertyMetadata(false, OnBatteryStatusPropertyChanged));

        private static void OnBatteryStatusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (BatteryStatusTrigger)d;
            var val = (BatteryChargingStatus)e.NewValue;

            obj.SetActive(val == _charging);
        }

        private void UpdateStatus()
        {
            var batteryReport = Windows.Devices.Power.Battery.AggregateBattery.GetReport();

            switch (batteryReport.Status)
            {
                case Windows.System.Power.BatteryStatus.Charging:
                    _charging = BatteryChargingStatus.Charging;
                    break;
                case Windows.System.Power.BatteryStatus.Discharging:
                    _charging = BatteryChargingStatus.Discharging;
                    break;
                default:
                    _charging = BatteryChargingStatus.Unknown;
                    break;
            }
        }
    }
}
