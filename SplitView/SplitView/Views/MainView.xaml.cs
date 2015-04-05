namespace SplitView.Views
{
	using Base;

	public sealed partial class MainView : PageBase
	{
		public MainView()
		{
			this.InitializeComponent();

			base.SplitViewFrame = SplitViewFrame;
		}
	}
}
