using Locations.Data.Interfaces;
using MarkEmbling.PostcodesIO;
using Newtonsoft.Json;
using System.Net;

namespace Locations.Services
{
    public class PostCodeService : IPostCodeService
    {
        public void GetLatitudeLongitude(string postCode, out double? latitude, out double? longitude)
        {
            var client = new PostcodesIOClient();
            var result = client.Lookup(postCode);
            latitude = result.Latitude;
            longitude = result.Longitude;
        }
    }
}
