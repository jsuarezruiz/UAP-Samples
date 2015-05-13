namespace Ink.Views.Base
{
	using ViewModels.Base;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Navigation;

	public class PageBase : Page
    {
        private ViewModelBase _vm;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _vm = (ViewModelBase)this.DataContext;
            _vm.SetAppFrame(this.Frame);
            _vm.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            _vm.OnNavigatedFrom(e);
        }
    }
}
