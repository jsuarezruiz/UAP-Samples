namespace Battery.ViewModels
{
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;
    using Base;

    public class MainViewModel : ViewModelBase
    {
        private string _status;
        private int _chargeRate;
        private int _fullChargeCapacity;
        private int _remainingCapacity;
        private double _percentage;

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }

        public int ChargeRate
        {
            get { return _chargeRate; }
            set
            {
                _chargeRate = value;
                RaisePropertyChanged();
            }
        }

        public int FullChargeCapacity
        {
            get { return _fullChargeCapacity; }
            set
            {
                _fullChargeCapacity = value;
                RaisePropertyChanged();
            }
        }

        public int RemainingCapacity
        {
            get { return _remainingCapacity; }
            set
            {
                _remainingCapacity = value;
                RaisePropertyChanged();
            }
        }

        public double Percentage
        {
            get { return _percentage; }
            set
            {
                _percentage = value;
                RaisePropertyChanged();
            }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            LoadBatteryInfo();

            return null;
        }

        private void LoadBatteryInfo()
        {
            var batteryReport = Windows.Devices.Power.Battery.AggregateBattery.GetReport();
            Status = batteryReport.Status.ToString();

            if (batteryReport.FullChargeCapacityInMilliwattHours != null && batteryReport.RemainingCapacityInMilliwattHours != null)
            {
                if (batteryReport.ChargeRateInMilliwatts != null)
                    ChargeRate = batteryReport.ChargeRateInMilliwatts.Value;

                FullChargeCapacity = batteryReport.FullChargeCapacityInMilliwattHours.Value;
                RemainingCapacity = batteryReport.RemainingCapacityInMilliwattHours.Value;

                var percentage = (batteryReport.RemainingCapacityInMilliwattHours.Value /
                    (double)batteryReport.FullChargeCapacityInMilliwattHours.Value) * 100;

                Percentage = percentage;
            }
        }
    }
}
