namespace Locations.Data.Interfaces
{
    public interface IPostCodeService
    {
        void GetLatitudeLongitude(string postCode, out double? latitude, out double? longitude);
    }
}
