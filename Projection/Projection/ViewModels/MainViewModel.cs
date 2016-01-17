using System;
using Projection.ViewModels.Base;
using Projection.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Windows.Devices.Enumeration;
using System.Collections.ObjectModel;
using Projection.Services.Projection;

namespace Projection.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        // Variables
        private bool _isProjectionDisplayAvailable;
        private ObservableCollection<DeviceInformation> _devices;
        private DeviceInformation _selectedDevice;
     
        // Commands
        private ICommand _projectCommand;
        private ICommand _selectTargetCommand;

        // Services
        private IProjectionService _projectionService;

        public MainViewModel(IProjectionService projectionService)
        {
            _projectionService = projectionService;
        }

        public bool IsProjectionDisplayAvailable
        {
            get { return _isProjectionDisplayAvailable; }
            set
            {
                _isProjectionDisplayAvailable = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<DeviceInformation> Devices
        {
            get { return _devices; }
            set
            {
                _devices = value;
                RaisePropertyChanged();
            }
        }

        public DeviceInformation SelectedDevice
        {
            get { return _selectedDevice; }
            set
            {
                _selectedDevice = value;
                if (_selectedDevice != null)
                    Project(_selectedDevice);

                RaisePropertyChanged();
            }
        }

        public ICommand ProjectCommand
        {
            get { return _projectCommand = _projectCommand ?? new DelegateCommandAsync(ProjectCommandExecute); }
        }

        public ICommand SelectTargetCommand
        {
            get { return _selectTargetCommand = _selectTargetCommand ?? new DelegateCommandAsync(SelectTargetCommandExecute); }
        }

        public override Task OnNavigatedFrom(NavigationEventArgs args)
        {
            ProjectionManager.ProjectionDisplayAvailableChanged -= ProjectionManager_ProjectionDisplayAvailableChanged;

            return null;
        }

        public override Task OnNavigatedTo(NavigationEventArgs args)
        {
            ProjectionManager.ProjectionDisplayAvailableChanged += ProjectionManager_ProjectionDisplayAvailableChanged;

            return null;
        }

        private void ProjectionManager_ProjectionDisplayAvailableChanged(object sender, object e)
        {
            // Occurs when a projector or other secondary display becomes available or unavailable.
            IsProjectionDisplayAvailable = ProjectionManager.ProjectionDisplayAvailable;
        }

        public async Task ProjectCommandExecute()
        {
            App.MainViewId = await _projectionService.ProjectAsync(typeof(ProjectionView));
        }

        public async Task SelectTargetCommandExecute()
        {
            try
            {
                Devices = new ObservableCollection<DeviceInformation>(await _projectionService.GetProjectionDevices());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task Project(DeviceInformation device)
        {
            try
            {
                // Show the view on a second display (if available) 
                App.MainViewId = await _projectionService.ProjectAsync(typeof(ProjectionView), device);

                Debug.WriteLine("Projection started in {0} successfully!", device.Name);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
