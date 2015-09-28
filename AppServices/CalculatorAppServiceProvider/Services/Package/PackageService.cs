namespace CalculatorAppServiceProvider.Services.Package
{
    public class PackageService : IPackageService
    {
        public string GetPackageProductId()
        {
            return Windows.ApplicationModel.Package.Current.Id.ProductId;
        }

        public string GetPackagePublisher()
        {
            return Windows.ApplicationModel.Package.Current.Id.Publisher;
        }

        public string GetPackageFamilyName()
        {
            return Windows.ApplicationModel.Package.Current.Id.FamilyName;
        }
    }
}
