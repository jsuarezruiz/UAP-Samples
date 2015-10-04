namespace BatteryTriggers.CustomStateTriggers
{
    using Windows.UI.Xaml;

    public class BatteryPercentageTrigger : StateTriggerBase
    {
        private static BaterryPercentageState _batteryPercentageState;

        public enum BaterryPercentageState
        {
            VeryHight = 0,
            Hight = 1,
            Medium = 2,
            Low = 3,
            Verylow = 4,
            Unknown = 5
        }

        public BatteryPercentageTrigger()
        {
            UpdatePercentage();

            Windows.Devices.Power.Battery.AggregateBattery.ReportUpdated += (s, a) =>
            {
                UpdatePercentage();
            };
        }

        public BaterryPercentageState BaterryPercentage
        {
            get { return (BaterryPercentageState)GetValue(BaterryPercentageProperty); }
            set { SetValue(BaterryPercentageProperty, value); }
        }

        public static readonly DependencyProperty BaterryPercentageProperty =
            DependencyProperty.Register("BaterryPercentage", typeof(BaterryPercentageState), typeof(BatteryPercentageTrigger),
            new PropertyMetadata(BaterryPercentageState.Unknown, OnBaterryPercentagePropertyChanged));

        private static void OnBaterryPercentagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var obj = (BatteryPercentageTrigger)d;
            var val = (BaterryPercentageState)e.NewValue;

            obj.SetActive(val == _batteryPercentageState);
        }

        private void UpdatePercentage()
        {
            var batteryReport = Windows.Devices.Power.Battery.AggregateBattery.GetReport();

            if (batteryReport.FullChargeCapacityInMilliwattHours != null && batteryReport.RemainingCapacityInMilliwattHours != null)
            {
                var percentage = (batteryReport.RemainingCapacityInMilliwattHours.Value /
                    (double)batteryReport.FullChargeCapacityInMilliwattHours.Value) * 100;

                if (percentage <= 100 && percentage > 80)
                {
                    _batteryPercentageState = BaterryPercentageState.VeryHight;
                }
                else if (percentage <= 80 && percentage > 60)
                {
                    _batteryPercentageState = BaterryPercentageState.Hight;
                }
                else if (percentage <= 60 && percentage > 40)
                {
                    _batteryPercentageState = BaterryPercentageState.Medium;
                }
                else if (percentage <= 40 && percentage > 20)
                {
                    _batteryPercentageState = BaterryPercentageState.Low;
                }
                else if (percentage <= 20 && percentage > 1)
                {
                    _batteryPercentageState = BaterryPercentageState.Verylow;
                }
                else
                {
                    _batteryPercentageState = BaterryPercentageState.Unknown;
                }
            }
        }
    }
}
