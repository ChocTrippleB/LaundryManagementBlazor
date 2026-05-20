using LaundryManagementBlazor.Interfaces;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    public class BusinessPackageFactory : ILaundryPackageFactory
    {
        public string PackageName => "Business";
        public IPackaging CreatePackaging()           => new GarmentBagPackaging();
        public IDeliveryMethod CreateDeliveryMethod() => new SameDayCourier();
        public IDetergentType CreateDetergent()       => new CommercialDetergent();
    }
}
