namespace LaundryManagementBlazor.Interfaces
{
    public interface ILaundryPackageFactory
    {
        string PackageName { get; }
        IPackaging CreatePackaging();
        IDeliveryMethod CreateDeliveryMethod();
        IDetergentType CreateDetergent();
    }
}
