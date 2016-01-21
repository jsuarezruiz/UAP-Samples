namespace Fingerprint.ViewModels
{
    using Fingerprint.ViewModels.Base;
    using Services.Dialog;
    using Services.UserConsentVerifier;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class MainViewModel : ViewModelBase
    {
        // Variables
        private bool _isUserConsentAvalaible;
        private string _message;

        // Commands
        private ICommand _availabilityCommand;
        private ICommand _verificationCommand;

        // Services 
        private IUserConsentVerifierService _userConsentVerifierService;
        private IDialogService _dialogService;

        public MainViewModel(IUserConsentVerifierService userConsentVerifierService,
            IDialogService dialogService)
        {
            _userConsentVerifierService = userConsentVerifierService;
            _dialogService = dialogService;
        }

        public bool IsUserConsentAvalaible
        {
            get { return _isUserConsentAvalaible; }
            set
            {
                _isUserConsentAvalaible = value;
                RaisePropertyChanged();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AvailabilityCommand
        {
            get { return _availabilityCommand = _availabilityCommand ?? new DelegateCommandAsync(AvailabilityCommandExecute); }
        }

        public ICommand VerificationCommand
        {
            get { return _verificationCommand = _verificationCommand ?? new DelegateCommandAsync(VerificationCommandExecute); }
        }

        public async Task AvailabilityCommandExecute()
        {
            IsUserConsentAvalaible = await _userConsentVerifierService.CheckUserConsentAvailabilityAsync();
        }

        public async Task VerificationCommandExecute()
        {
            if(string.IsNullOrEmpty(Message))
            {
                _dialogService.Show("Message in required!");
                return;
            }

            var result = await _userConsentVerifierService.GetRequestUserConsentVerificationAsync(Message);
            var message = string.Empty;

            switch(result)
            {
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.Canceled:
                    message = "Consent request prompt was canceled.";
                    break;
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceBusy:
                    message = "Biometric device is busy.";
                    break;
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.DeviceNotPresent:
                    message = "Biometric device not found.";
                    break;
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.DisabledByPolicy:
                    message = "Disabled by policy.";
                    break;
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.NotConfiguredForUser:
                    message = "No fingeprints registered.";
                    break;
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.RetriesExhausted:
                    message = "Too many retries.";
                    break;
                case Windows.Security.Credentials.UI.UserConsentVerificationResult.Verified:
                    message = "User verified.";
                    break;
            }

            _dialogService.Show(message);
        }
    }
}