namespace PrismDeUniqueID.Interfaces
{
    public enum DeviceOrientation : int
    {
        Unknown = 0,
        Portrait = 1,
        Landscape = 2
    }

    public interface IDeviceInfo
    {
        string UniqueID { get; }
        string Model { get; }
        string Name { get; }
        DeviceOrientation Orientation { get; }
    }
}
