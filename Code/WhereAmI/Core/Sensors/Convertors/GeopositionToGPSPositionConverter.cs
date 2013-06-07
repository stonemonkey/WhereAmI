using WhereAmI.Core.Convertor;
using WhereAmI.Core.Model;
using Windows.Devices.Geolocation;

namespace WhereAmI.Core.Sensors.Convertors
{
    public class GeopositionToGPSPositionConverter : IConverter<Geoposition, GPSPosition>
    {
        public GPSPosition Convert(Geoposition position)
        {
            return new GPSPosition()
            {
                Latitude = position.Coordinate.Latitude,
                Longitude = position.Coordinate.Longitude,
                Altitude = position.Coordinate.Altitude ?? 0,
            };
        }
    }
}
