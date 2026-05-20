namespace LaundryManagementBlazor.Interfaces
{
    public interface IPackaging
    {
        string PackagingType { get; }
        string Describe();
    }

    public interface IDeliveryMethod
    {
        string Method { get; }
        string Describe();
    }

    public interface IDetergentType
    {
        string Detergent { get; }
        string Describe();
    }
}
