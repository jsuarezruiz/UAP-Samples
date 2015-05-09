namespace XPhase
{
    using System;
    using Windows.UI.Xaml.Controls;
    using ViewModels;

    public sealed partial class MainView : Page
    {
        private object Datetime;

        public MainView()
        {
            var date = DateTime.Now;
            this.InitializeComponent();

            this.Loaded += (s, e) =>
            {
                var diff = DateTime.Now - date;

                var vm = DataContext as MainViewModel;
                if(vm !=  null)
                {
                    vm.Time = diff.ToString();
                }
            };
        }
    }
}
