namespace CalculatorAppServiceProvider.ViewModels.Base
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private Frame _appFrame;
		private bool _isBusy;

        public Frame AppFrame => _appFrame;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public abstract Task OnNavigatedFrom(NavigationEventArgs args);

        public abstract Task OnNavigatedTo(NavigationEventArgs args);

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void SetAppFrame(Frame viewFrame)
        {
            _appFrame = viewFrame;
        }
	}
}
