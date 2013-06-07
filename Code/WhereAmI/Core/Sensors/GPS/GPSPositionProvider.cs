using WhereAmI.Core.Convertor;
using WhereAmI.Core.Model;
using WhereAmI.Core.Sensors.Convertors;
using Windows.Devices.Geolocation;

namespace WhereAmI.Core.Sensors.GPS
{
    public class GPSPositionProvider
    {
        private readonly GPSPositionProviderConfiguration _configuration;
        private readonly IConverter<Geoposition, GPSPosition> _converter;
        private Geolocator _geolocator;

        public static GPSPositionProvider CurrentInstance = new GPSPositionProvider(new GPSPositionProviderConfiguration(), new GeopositionToGPSPositionConverter());

        public GPSPositionProvider(GPSPositionProviderConfiguration configuration, IConverter<Geoposition, GPSPosition> converter)
        {
            _configuration = configuration;
            _converter = converter;
            InitGeolocator();
        }

        private void InitGeolocator()
        {
            _geolocator = new Geolocator();

        }

        private bool isGPSWarmUp = false;
        private object padLockGPSWarmUp = new object();


        // public async Task<GPSPosition> GetCurrentPositionAsync()
        public GPSPosition GetCurrentPositionAsync()
        {
            //Geoposition position = await _geolocator.GetGeopositionAsync();
            //return _converter.Convert(position);
            return new GPSPosition()
            {
                Latitude = 13f,
                Longitude = 15f
            };
        }
    }
}
