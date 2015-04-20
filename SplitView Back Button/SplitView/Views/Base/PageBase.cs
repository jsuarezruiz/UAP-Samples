namespace SplitView.Views.Base
{
	using ViewModels.Base;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Navigation;

	public class PageBase : Page
	{
		private ViewModelBase _vm;
		private Frame _splitViewFrame;

		public Frame SplitViewFrame
		{
			get { return _splitViewFrame; }
			set
			{
				_splitViewFrame = value;

				if(_vm == null)
					_vm = (ViewModelBase)this.DataContext;

				_vm.SetSplitFrame(_splitViewFrame);
			}
		}

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
