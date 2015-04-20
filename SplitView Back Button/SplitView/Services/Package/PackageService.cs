namespace SplitView.Services.Package
{
	public class PackageService : IPackageService
	{
		public string GetAppName()
		{
			var package = Windows.ApplicationModel.Package.Current;
			return package.DisplayName;
		}

		public string GetVersion()
		{
			var package = Windows.ApplicationModel.Package.Current;
			var version = package.Id.Version;

			return string.Format("{0}.{1}.{2}.{3}",
				version.Major, version.Minor, version.Build, version.Revision);
		}
	}
}
