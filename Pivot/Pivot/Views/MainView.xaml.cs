using Pivot.Views.Base;

namespace Pivot
{
    public sealed partial class MainView : PageBase
    {
        public MainView()
        {
            this.InitializeComponent();

            base.SplitViewFrame = SplitViewFrame;
        }
    }
}