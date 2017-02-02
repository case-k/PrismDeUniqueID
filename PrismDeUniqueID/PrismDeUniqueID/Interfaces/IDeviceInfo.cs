namespace PrismDeUniqueID.Interfaces
{
    public interface IDeviceInfo
    {
        string UniqueID { get; }
        string Model { get; }
        string Name { get; }
    }
}
