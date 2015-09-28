namespace CalculatorAppServiceClient.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Threading.Tasks;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml.Navigation;
    using Windows.ApplicationModel.AppService;
    using Windows.ApplicationModel.Core;
    using Base;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private AppServiceConnection _connection;
        private string _value1;
        private string _value2;
        private string _result;
        private string _status;

        // Commands
        private ICommand _openCommand;
        private ICommand _closeCommand;
        private ICommand _addCommand;
        private ICommand _substractCommand;
        private ICommand _multiplyCommand;

        public string Value1
        {
            get { return _value1; }
            set
            {
                _value1 = value;
                RaisePropertyChanged();
            }
        }

        public string Value2
        {
            get { return _value2; }
            set
            {
                _value2 = value;
                RaisePropertyChanged();
            }
        }

        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                RaisePropertyChanged();
            }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                RaisePropertyChanged();
            }
        }

        public ICommand OpenCommand
        {
            get { return _openCommand = _openCommand ?? new DelegateCommandAsync(OpenCommandExecute); }
        }

        public ICommand CloseCommand
        {
            get { return _closeCommand = _closeCommand ?? new DelegateCommand(CloseCommandExecute); }
        }

        public ICommand AddCommand
        {
            get { return _addCommand = _addCommand ?? new DelegateCommandAsync(AddCommandExecute); }
        }

        public ICommand SubstractCommand
        {
            get { return _substractCommand = _substractCommand ?? new DelegateCommandAsync(SubstractCommandExecute); }
        }

        public ICommand MultiplyCommand
        {
            get { return _multiplyCommand = _multiplyCommand ?? new DelegateCommandAsync(MultiplyCommandExecute); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            CloseConnection();

            return null;
        }

        public override async Task OnNavigatedTo(NavigationEventArgs args)
        {
            await OpenConnection();
        }

        private async void _connection_ServiceClosed(AppServiceConnection sender, AppServiceClosedEventArgs args)
        {
            await CoreApplication.MainView.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                if (_connection != null)
                {
                    _connection.Dispose();
                    _connection = null;
                }
            });
        }

        private async Task OpenCommandExecute()
        {
            await OpenConnection();
        }

        private void CloseCommandExecute()
        {
            CloseConnection();
        }

        private async Task OpenConnection()
        {
            if (_connection != null)
            {
                return;
            }

            Status = "Creating connection...";

            _connection = new AppServiceConnection
            {
                AppServiceName = "com.jsuarezruiz.calculator",
                PackageFamilyName = "39d7f8de-5d46-4473-bb4a-db6036b22f49_3b4dnjq9ntz50"
            };

            _connection.ServiceClosed += _connection_ServiceClosed;
            ;

            AppServiceConnectionStatus status = await _connection.OpenAsync();

            if (status == AppServiceConnectionStatus.Success)
            {
                Status = "Connection is open";
            }
            else
            {
                switch (status)
                {
                    case AppServiceConnectionStatus.AppNotInstalled:
                        Status = "The provider App is not installed.";
                        break;

                    case AppServiceConnectionStatus.AppUnavailable:
                        Status = "The provider app is not available.";
                        break;

                    case AppServiceConnectionStatus.AppServiceUnavailable:
                        Status = string.Format(
                            "The provider App is installed but it does not provide the service {0}.",
                            _connection.AppServiceName);
                        break;

                    case AppServiceConnectionStatus.Unknown:
                        Status = "An unkown error occurred.";
                        break;
                }

                _connection.Dispose();
                _connection = null;
            }
        }

        private void CloseConnection()
        {
            _connection.Dispose();
            _connection = null;

            Status = "Connection closed";
        }

        private async Task AddCommandExecute()
        {
            await Calculator("Add");
        }

        private async Task SubstractCommandExecute()
        {
            await Calculator("Substract");
        }

        private async Task MultiplyCommandExecute()
        {
            await Calculator("Multiply");
        }

        private async Task Calculator(string operation)
        {
            if (_connection == null)
            {
                await OpenConnection();
            }

            int first, second;

            int.TryParse(Value1, out first);
            int.TryParse(Value2, out second);

            if (first == 0 && second == 0)
            {
                return;
            }

            var inputs = new ValueSet { { "value1", first }, { "value2", second }, { "operation", operation } };
        
            if (_connection != null)
            {
                AppServiceResponse response = await _connection.SendMessageAsync(inputs);

                if (response.Status == AppServiceResponseStatus.Success)
                {
                    if (!response.Message.ContainsKey("result"))
                    {
                        return;
                    }

                    Result = response.Message["result"].ToString();
                }
                else
                {
                    switch (response.Status)
                    {
                        case AppServiceResponseStatus.Failure:
                            Status = "The service failed to acknowledge the message we sent it.";
                            break;

                        case AppServiceResponseStatus.ResourceLimitsExceeded:
                            Status = "The service exceeded the resources allocated to it.";
                            break;

                        case AppServiceResponseStatus.Unknown:
                        default:
                            Status = "An unkown error occurred.";
                            break;
                    }
                }
            }
        }
    }
}