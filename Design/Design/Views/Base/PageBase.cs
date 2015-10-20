namespace Design.Views.Base
{
	using ViewModels.Base;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Navigation;
    using Extensions;

    public class PageBase : Page
	{
		private ViewModelBase _vm;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            _vm = (ViewModelBase)this.DataContext;
            _vm.SetAppFrame(this.Frame);

            var splitView = this.GetFirstDescendantOfType<SplitView>();
            var frame = splitView?.Content as Frame;

            if (frame != null)
                _vm.SetSplitFrame(frame);

            _vm.OnNavigatedTo(e);
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			_vm.OnNavigatedFrom(e);
		}
	}
}
