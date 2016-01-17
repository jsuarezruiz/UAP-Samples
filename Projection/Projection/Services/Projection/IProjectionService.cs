using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;

namespace Projection.Services.Projection
{
    public interface IProjectionService
    {
        Task<IEnumerable<DeviceInformation>> GetProjectionDevices();
        Task<int> ProjectAsync(Type viewType, DeviceInformation device = null);
        Task<int> RequestProjectAsync(Type viewType, Rect? position = null);
        Task SwitchProjection(int mainViewId);
        Task StopProjection(int mainViewId);
    }
}
