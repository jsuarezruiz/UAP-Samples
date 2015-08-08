namespace XDeferLoadStrategy.ViewModels
{
    using System.Threading.Tasks;
    using Windows.UI.Xaml.Navigation;
    using Base;
    using System.Windows.Input;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml;

    public class MainViewModel : ViewModelBase
    {      
        // Commands
        private ICommand _realizeElementsCommand;

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public ICommand RealizeElementsCommand
        {
            get { return _realizeElementsCommand = _realizeElementsCommand ?? new DelegateCommand(RealizeElementsCommandExecute); }
        }

        private void RealizeElementsCommandExecute()
        {
            var frame = (Frame)Window.Current.Content;
            var page = (Page)frame.Content;

            page.FindName("DeferredPanel"); 
        }
    }
}
