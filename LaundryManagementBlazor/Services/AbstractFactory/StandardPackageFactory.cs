using LaundryManagementBlazor.Interfaces;

namespace LaundryManagementBlazor.Services.AbstractFactory
{
    public class StandardPackageFactory : ILaundryPackageFactory
    {
        public string PackageName => "Standard";
        public IPackaging CreatePackaging()       => new PlasticBagPackaging();
        public IDeliveryMethod CreateDeliveryMethod() => new StandardDelivery();
        public IDetergentType CreateDetergent()   => new RegularDetergent();
    }
}
