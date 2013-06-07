    using Bing.Maps;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace WhereAmI.Components.Navigation
{
    public sealed partial class NavigatePageView : Page
    {
        public NavigatePageView()
        {
            InitializeComponent();
        }

        private MapShapeLayer CreateMapShapeLayer(Location startLocation, Location endLocation)
        {
            MapShapeLayer shapeLayer = new MapShapeLayer();
            MapPolyline polyline = new MapPolyline();

            polyline.Locations = new LocationCollection { startLocation, endLocation };
            polyline.Color = Color.FromArgb(255,255,120,56);
            polyline.Width = 10;

            shapeLayer.Shapes.Add(polyline);
            mainMap.ShapeLayers.Add(shapeLayer);

            return shapeLayer;
        }

        private void mainMap_LayoutUpdated(object sender, object e)
        {
            NavigatePageViewModel viewModel = (NavigatePageViewModel)DataContext;
            CreateMapShapeLayer(
                new Location(viewModel.CurrentLocation.Position.Latitude, viewModel.CurrentLocation.Position.Longitude),
                new Location(viewModel.DestinationLocation.Position.Latitude, viewModel.DestinationLocation.Position.Longitude));

        }
    }
}
