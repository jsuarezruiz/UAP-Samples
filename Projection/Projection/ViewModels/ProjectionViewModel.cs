using System;
using Projection.ViewModels.Base;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Projection.Services.Projection;

namespace Projection.ViewModels
{
    public class ProjectionViewModel : ViewModelBase
    {
        // Commands
        private ICommand _switchViewCommand;
        private ICommand _stopCommand;

        // Services
        private IProjectionService _projectionService;

        public ProjectionViewModel(IProjectionService projectionService)
        {
            _projectionService = projectionService;
        }

        public ICommand SwitchViewCommand
        {
            get { return _switchViewCommand = _switchViewCommand ?? new DelegateCommandAsync(SwitchViewCommandExecute); }
        }

        public ICommand StopCommand
        {
            get { return _stopCommand = _stopCommand ?? new DelegateCommandAsync(StopCommandExecute); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            return null;
        }

        public async Task SwitchViewCommandExecute()
        {
            try
            {
                await _projectionService.SwapProjection(App.MainViewId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public async Task StopCommandExecute()
        {
            try
            {
                await _projectionService.StopProjection(App.MainViewId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}