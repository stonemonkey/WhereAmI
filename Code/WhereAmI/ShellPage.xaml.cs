using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace WhereAmI
{
    public sealed partial class ShellView : Page
    {
        public ShellView()
        {
            this.InitializeComponent();
            //GetCurrentLocation();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        //private void  GetCurrentLocation()
        //{
        //    //IGPSPositionProvider gpsPositionProvider = new GPSPositionProvider(new GPSPositionProviderConfiguration(), new GeopositionToGPSPositionConverter());
        //    GPSPositionProvider gpsPositionProvider = GPSPositionProvider.CurrentInstance;
        //    var result = gpsPositionProvider.GetCurrentPositionAsync();
        //    //var g = result.GetAwaiter();
        //    //while (!g.IsCompleted)
        //    //{

        //    //}
        //    GPSPosition position = null;

        //    //try
        //    //{
        //    //    GPSPosition location = null;
        //    //   // location = gpsPositionProvider.GetCurrentPositionAsync();
        //    //  //  Task.Run(() => location =  gpsPositionProvider.GetCurrentPositionAsync().GetResult());
        //    Task.Run(() => position = gpsPositionProvider.GetCurrentPositionAsync().Result).Wait();
        //    //    position = location;
        //    //}
        //    //catch (COMException comException)
        //    //{
        //    //    // The GPS location was not resolved.             
        //    //}

        //    //return position;
        //}
    }
}
