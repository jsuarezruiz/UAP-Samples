using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Projection.Services.Projection
{
    public class ProjectionService : IProjectionService
    {
        public async Task<IEnumerable<DeviceInformation>> GetProjectionDevices()
        {
            // List wired/wireless displays
            String projectorSelectorQuery = ProjectionManager.GetDeviceSelector();

            // Use device API to find devices based on the query 
            var projectionDevices = await DeviceInformation.FindAllAsync(projectorSelectorQuery);

            var devices = new ObservableCollection<DeviceInformation>();
            foreach (var device in projectionDevices)
                devices.Add(device);

            return devices;
        }

        public async Task<int> ProjectAsync(Type viewType, DeviceInformation device = null)
        {
            int mainViewId = ApplicationView.GetForCurrentView().Id;
            int? secondViewId = null;

            var view = CoreApplication.CreateNewView();
            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                secondViewId = ApplicationView.GetForCurrentView().Id;
                var rootFrame = new Frame();
                rootFrame.Navigate(viewType, null);
                Window.Current.Content = rootFrame;
                Window.Current.Activate();
            });

            if (secondViewId.HasValue)
            {
                if(device == null)
                    await ProjectionManager.StartProjectingAsync(secondViewId.Value, mainViewId);
                else
                    await ProjectionManager.StartProjectingAsync(secondViewId.Value, mainViewId, device);
            }

            return mainViewId;
        }

        public async Task<int> RequestProjectAsync(Type viewType, Rect? position = null)
        {
            int mainViewId = ApplicationView.GetForCurrentView().Id;
            int? secondViewId = null;

            var view = CoreApplication.CreateNewView();
            await view.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                secondViewId = ApplicationView.GetForCurrentView().Id;
                var rootFrame = new Frame();
                rootFrame.Navigate(viewType, mainViewId);
                Window.Current.Content = rootFrame;
                Window.Current.Activate();
            });

            if (secondViewId.HasValue)
            {
                var defaultPosition = new Rect(0.0, 0.0, 200.0, 200.0);
                await ProjectionManager.RequestStartProjectingAsync(secondViewId.Value, mainViewId, position.HasValue ? position.Value : defaultPosition);
            }

            return mainViewId;
        }

        public async Task StopProjection(int mainViewId)
        {
            await ProjectionManager.StopProjectingAsync(       
                ApplicationView.GetForCurrentView().Id,
                mainViewId);
        }

        public async Task SwapProjection(int mainViewId)
        {
            await ProjectionManager.SwapDisplaysForViewsAsync(
                ApplicationView.GetForCurrentView().Id,
                mainViewId);
        }
    }
}
