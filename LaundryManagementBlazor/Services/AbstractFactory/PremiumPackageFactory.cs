using LaundryManagementBlazor.Interfaces;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    public class PremiumPackageFactory : ILaundryPackageFactory
    {
        public string PackageName => "Premium";
        public IPackaging CreatePackaging()           => new BrandedBoxPackaging();
        public IDeliveryMethod CreateDeliveryMethod() => new ExpressDelivery();
        public IDetergentType CreateDetergent()       => new HypoallergenicDetergent();
    }
}
